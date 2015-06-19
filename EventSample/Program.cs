using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.IO.Pipes;

namespace EventSample
{
    public class Pipe: IDisposable
    {
        public class PipeEventArgs : EventArgs
        {
            private string message;

            public PipeEventArgs(string message)
            {
                this.message = message;
            }

            public string Message
            {
                get { return this.message; }
            }
        }

        public delegate void PipeDataReceivedHandler(object sender, PipeEventArgs e);

        public event PipeDataReceivedHandler DataReceived;

        private string pipeName;
        private bool abort;
        private bool disposed = false;

        public Pipe(string pipeName)
        {
            this.pipeName = pipeName;
        }

        public void Abort()
        {
            this.abort = true;
        }

        protected virtual void OnPipeReceive(PipeEventArgs e)
        {
            Pipe.PipeDataReceivedHandler handler = DataReceived;
            if (handler != null)
                handler(this, e);
        }

        public void Start()
        {
            abort = false;
            for (int i=0;i<5;i++)
            {
                System.Threading.Thread.Sleep(500);
                PipeEventArgs e = new PipeEventArgs("Message");
                OnPipeReceive(e);
            }
        }

        public void Wait()
        {
            while (!abort)
            {
            }
        }

        public void Close()
        {
            this.abort = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // cleanup managed resources
                }
                // cleanup unmanaged resources
                disposed = true;
            }
        }

        public void SendData(string s)
        {
            try
            {
                using (NamedPipeServerStream pipe = new NamedPipeServerStream(pipeName, PipeDirection.Out))
                {
                    using (StreamWriter writer = new StreamWriter(pipe))
                    {
                        pipe.WaitForConnection();
                        writer.AutoFlush = true;
                        writer.WriteLine(s);
                        writer.Close();
                    }
                    pipe.Close();
                }
            }
            catch (IOException x)
            {
                Console.WriteLine("IO Exception: {0}", x.Message);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: {0}", x.Message);
            }
        }

        public string ReceiveData()
        {
            string s = "";
            try
            {
                using (NamedPipeClientStream pipe = new NamedPipeClientStream(".", "PIPE", PipeDirection.In))
                {
                    pipe.Connect();
                    if (pipe.IsConnected)
                    using (StreamReader reader=new StreamReader(pipe))
                    {
                        s = reader.ReadToEnd();
                        reader.Close();
                    }
                    pipe.Close();
                }
            }
            catch (IOException x)
            {
                Console.WriteLine("IO Exception: {0}", x.Message);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: {0}", x.Message);
            }
            return s;
        }
    }

    class Program
    {
          
        public static void Main(string[] args)
        {
            Pipe pipe = new Pipe("PIPE");
            pipe.DataReceived += new Pipe.PipeDataReceivedHandler(OnDataReceive);
            pipe.Start();
        }

        public static void OnDataReceive(object sender, Pipe.PipeEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}




/*
    Public Sub AsyncWait()
        Dim xml As StringBuilder = New StringBuilder()
        Dim temp As String
        Dim context As Boolean = False
        basFWError.DebugToFile("[FWApp.AsyncWait] Starting", eDEBUG_MODE.ModeError)
        Do While ThreadContinue
            context = waitHandleAppConnectorToPIWD.WaitOne(1000)
            If context Then
                context = False
                basFWError.DebugToFile("[FWApp.AsyncWait] Context set", eDEBUG_MODE.ModeError)
                basFWError.DebugToFile("[FWApp.AsyncWait] Calling Close/Open PipeAppConnectorToPIWD", eDEBUG_MODE.ModeError)
                ClosePipeAppConnectorToPIWD()
                OpenPipeAppConnectorToPIWD()
                If Not pipeAppConnectorToPIWD.IsConnected Then
                    basFWError.DebugToFile("[FWApp.AsyncWait] Connect", eDEBUG_MODE.ModeError)
                    pipeAppConnectorToPIWD.Connect()
                End If
                basFWError.DebugToFile("[FWApp.AsyncWait] ReadLine", eDEBUG_MODE.ModeError)
                Try
                    'temp = pipeStreamReader.ReadLine()
                    'While temp IsNot Nothing
                    'xml.Append(temp)
                    'basFWError.DebugToFile("[FWApp.AsyncWait] ReadLine", eDEBUG_MODE.ModeError)
                    'temp = pipeStreamReader.ReadLine()
                    'End While
                    xml.Append(pipeStreamReader.ReadToEnd())
                    ClosePipeAppConnectorToPIWD()
                    basFWError.DebugToFile("[FWApp.AsyncWait] Calling InvokeOperation", eDEBUG_MODE.ModeError)
                    If xml.ToString().Length > 0 Then
                        InvokeOperation(xml.ToString())
                    End If
                    basFWError.DebugToFile("[FWApp.AsyncWait] Calling ClosePipeAppConnectorToPIWD", eDEBUG_MODE.ModeError)
                Catch iox As IOException
                    basFWError.DebugToFile("[FWApp.AsyncWait] IO Error: " + iox.Message, eDEBUG_MODE.ModeError)
                Catch ex As Exception
                    basFWError.DebugToFile("[FWApp.AsyncWait] Error: " + ex.Message, eDEBUG_MODE.ModeError)
                End Try
                xml = New StringBuilder()
            End If
        Loop
        basFWError.DebugToFile("[FWApp.AsyncWait] Terminating", eDEBUG_MODE.ModeError)
    End Sub



   If waitHandleAppConnectorToPIWD Is Nothing Then waitHandleAppConnectorToPIWD = New EventWaitHandle(False, EventResetMode.AutoReset, userName & DefineEventAppConnectorToPIWD)

    waitForAppConnector = New Thread(New ThreadStart(AddressOf AsyncWait))
    waitForAppConnector.Start()
*/