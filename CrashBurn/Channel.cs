using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Timers;
using Microsoft.Win32;

namespace CommonLib
{
    public class Channel : IDisposable
    {
        #region Declarations

        private bool disposed = false;
        private const string moduleName = "Channel";
        private Logger log = null;
        private bool keepReceiverAlive = true;
        private bool keepSenderAlive = true;

        public delegate void ChannelEventHandler(object sender, ChannelEventArgs e);
        public event ChannelEventHandler Notify;

        private System.Timers.Timer heartBeat;

        private string userName = "";
        private string srcName = "";
        private string dstName = "";

        private string sndEventName = "";
        private string sndPipeName = "";
        private string rcvEventName = "";
        private string rcvPipeName = "";

        private Thread senderThread = null;
        private Thread receiverThread = null;

        private static object syncSend;
        private static object syncRecv;

        private List<string> sendQueue;
        private bool sending = false;
        private AsyncCallback sendCallback = null;
        private IAsyncResult asyncSendState;
        private NamedPipeServerStream sndPipe = null;
        private System.Timers.Timer sendTimeout;

        public class ChannelEventArgs : EventArgs
        {
            private string data;
            public ChannelEventArgs(string data) { this.data = data; }
            public string Data
            {
                get { return data; }
            }
        }

        #endregion

        #region Initialization and Housekeeping

        static Channel()
        {
            syncSend = new object();
            syncRecv = new object();
        }

        public Channel(string source, string destination, CommonLib.Logger log)
        {
            string methodName = moduleName + ".Channel";
            try
            {
                this.log = (log != null) ? log : new CommonLib.Logger("", "", LogLevel.None, 0);
                srcName = source;
                dstName = destination;
                userName = System.Environment.UserName;
                sndEventName = userName + ".EVENT." + srcName + "." + dstName;
                sndPipeName = userName + ".PIPE." + srcName + "." + dstName;
                rcvEventName = userName + ".EVENT." + dstName + "." + srcName;
                rcvPipeName = userName + ".PIPE." + dstName + "." + srcName;
                sendQueue = new List<string>();
                receiverThread = new Thread(AsyncReceiver);
                receiverThread.Start();
                heartBeat = new System.Timers.Timer(500);
                heartBeat.AutoReset = true;
                heartBeat.Elapsed += new ElapsedEventHandler(StatusCheck);
                heartBeat.Enabled = true;
            }
            catch (Exception x)
            {
                this.log.LogError(string.Format("{0} {1}", methodName, x.Message));
            }
        }

        private void StatusCheck(object sender, ElapsedEventArgs e)
        {
            string methodName = moduleName + ".StatusCheck";
            try
            {
                if (!receiverThread.IsAlive)
                {
                    log.LogInfo(string.Format("{0} restarting receiver thread.", methodName));
                    receiverThread = new Thread(AsyncReceiver);
                    receiverThread.Start();
                }
                if ((senderThread == null || !senderThread.IsAlive) && sendQueue.Count > 0)
                {
                    log.LogInfo(string.Format("{0} restarting sender thread.", methodName));
                    senderThread = new Thread(AsyncSender);
                    senderThread.Start();
                }
            }
            catch (Exception x)
            {
                this.log.LogError(string.Format("{0} {1}", methodName, x.Message));
            }
        }

        #endregion

        #region Send

        public void Send(string msg)
        {
            string methodName = moduleName + ".Send";
            try
            {
                sendQueue.Add(msg);
                if (senderThread == null)
                {
                    senderThread = new Thread(AsyncSender);
                    senderThread.Start();
                }
                if (!senderThread.IsAlive)
                {
                    senderThread = new Thread(AsyncSender);
                    senderThread.Start();
                }
            }
            catch (Exception x)
            {
                log.LogError(string.Format("{0} {1}", methodName, x.Message));
            }
        }

        private void AsyncSender()
        {
            string methodName = moduleName + ".AsyncSender";
            EventWaitHandle sndEvent = null;
            if (sendCallback == null)
                sendCallback = new AsyncCallback(OnSendConnect);
            string msg;
            while (sendQueue.Count > 0 && keepSenderAlive)
            {
                try
                {
                    if (sndEvent == null)
                        sndEvent = EventWaitHandle.OpenExisting(sndEventName);
                    if (!sending)
                    {
                        sndPipe = new NamedPipeServerStream(sndPipeName, PipeDirection.Out, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
                        msg = sendQueue[0];
                        sendQueue.RemoveAt(0);
                        InitSendTimeout();
                        sndEvent.Set();
                        sending = true;
                        asyncSendState = sndPipe.BeginWaitForConnection(sendCallback, msg);
                    }
                    //Thread.Sleep(100);
                }
                catch (Exception x)
                {
                    this.log.LogError(string.Format("{0} {1}", methodName, x.Message));
                }
            }
        }

        private void InitSendTimeout()
        {
            sendTimeout = new System.Timers.Timer();
            sendTimeout.Elapsed += new ElapsedEventHandler(OnSendTimeout);
            sendTimeout.Interval = 10000;
            sendTimeout.AutoReset = false;
            sendTimeout.Start();
        }

        private void DisableSendTimeout()
        {
            sendTimeout.Enabled = false;
            sendTimeout.Close();
            sendTimeout.Dispose();
            sendTimeout = null;
        }

        private void OnSendConnect(IAsyncResult asyncResult)
        {
            string methodName = moduleName + ".OnSendConnect";
            try
            {
                try
                {
                    DisableSendTimeout();
                }
                catch { }
                lock (syncSend)
                {
                    sndPipe.EndWaitForConnection(asyncResult);
                    StreamWriter sndStream = new StreamWriter(sndPipe);
                    sndStream.AutoFlush = true;
                    string message = (string)asyncResult.AsyncState;
                    sndStream.WriteLine(message);
                    sndStream.Close();
                    sndStream.Dispose();
                    sndPipe = null;
                }
            }
            catch (Exception x)
            {
                this.log.LogError(string.Format("{0} {1}", methodName, x.Message));
            }
            finally
            {
                sending = false;
            }
        }

        private void OnSendTimeout(object sender, ElapsedEventArgs e)
        {
            string methodName = moduleName + ".OnSendTimeout";
            try
            {
                sndPipe.EndWaitForConnection(asyncSendState);
                sending = false;
                sndPipe.Dispose();
                sndPipe = null;
            }
            catch (Exception x)
            {
                this.log.LogError(string.Format("{0} {1}", methodName, x.Message));
            }
        }

        #endregion

        #region Receive

        private void AsyncReceiver()
        {
            string methodName = moduleName + ".AsyncReceiver";
            try
            {
                EventWaitHandle rcvEvent;
                rcvEvent = new EventWaitHandle(false, EventResetMode.AutoReset, rcvEventName);
                while (keepReceiverAlive)
                {
                    try
                    {
                        bool context = rcvEvent.WaitOne(1000);
                        if (context)
                        {
                            lock (syncRecv)
                            {
                                using (NamedPipeClientStream rcvPipe = new NamedPipeClientStream(".", rcvPipeName, PipeDirection.In))
                                {
                                    string data = "";
                                    rcvPipe.Connect(2000);
                                    if (rcvPipe.IsConnected)
                                        using (StreamReader rcvStream = new StreamReader(rcvPipe))
                                        {
                                            data = rcvStream.ReadToEnd().Trim();
                                            rcvStream.Close();
                                        }
                                    rcvPipe.Close();
                                    if (data.Length > 0)
                                        Notify(this, new ChannelEventArgs(data));
                                }
                            }
                        }
                    }
                    catch (Exception x)
                    {
                        this.log.LogError(string.Format("{0} {1}", methodName, x.Message));
                    }
                }
            }
            catch (Exception x)
            {
                this.log.LogError(string.Format("{0} {1}", methodName, x.Message));
            }
        }

        #endregion

        #region Disposal

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (senderThread != null)
                    {
                        keepSenderAlive = false;
                        senderThread.Abort();
                    }
                    if (receiverThread != null)
                    {
                        keepReceiverAlive = false;
                        receiverThread.Abort();
                    }
                    heartBeat.Close();
                    heartBeat.Dispose();
                }
                disposed = true;
            }
        }

        ~Channel()
        {
            Dispose(false);
        }

        #endregion
    }
}
