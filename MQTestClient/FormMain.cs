using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using IBM.WMQ;

namespace MQTestClient
{
    public partial class FormMain : Form
    {
        private MQQueueManager queueManager = null;
        private bool sendReplyPressed = false;
        private string sendReplyQueue;
        private byte[] messageID;
        private bool timerEnabled = false;
        private long policyNumber = 10000000;
        private bool processComplete = true;

        public FormMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void ConnectToQueueManager()
        {
            /*
        'Initialize the MQEnvironment object
        MQEnvironment.Channel = My.Settings.MQ_QMGR_Custom_Channel_Name
        MQEnvironment.Hostname = My.Settings.MQ_QMGR_Host_Name
        MQEnvironment.Port = My.Settings.MQ_QMGR_Port
        MQEnvironment.SecurityExit = My.Settings.MQ_SecurityExit.Trim()

        Try
            If _oQMgr IsNot Nothing AndAlso _oQMgr.IsConnected Then
                _oQMgr.Disconnect()
            End If

            'Initialize the MQQueueManager object
            _oQMgr = New MQQueueManager(My.Settings.MQ_QMGR_Queue_Manager)
            UpdateStatusBar(Nothing, "Successfully connected to MQ Queue Manager " & My.Settings.MQ_QMGR_Queue_Manager)
        Catch ex As MQException
            UpdateStatusBar(Nothing, "Error connecting to MQ Queue manager '" & My.Settings.MQ_QMGR_Queue_Manager & "'. Reason code = " & ex.ReasonCode.ToString & ", " & ex.Message, True)
        End Try
            */
        }
    }
}



/*
    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ConnectToQueueManager()
        ButtonMQCmd.Text = "Send MQ Datagram Message"

    End Sub

    Private Sub MainForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If _oQMgr IsNot Nothing AndAlso _oQMgr.IsConnected Then
                _oQMgr.Disconnect()
            End If


        Catch ex As Exception
        End Try
    End Sub

    Private Sub ConnectToQueueManager()
    End Sub

    Private Sub MQCommandButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonMQCmd.Click
        Dim iCount As Integer
        Try

            If _bTimerEnabled Then
                MessageBox.Show("Timer is enabled. Please stop the timer to continue...", Application.ProductName)
                Return
            End If
            ButtonMQCmd.Enabled = False
            Select Case MQTabControl.SelectedTab.Name
                Case "TabPageDatagramReceive"
                    For iCount = 0 To My.Settings.Datagram_Receive_Msgs - 1
                        Dim oGetMsg As MQMessage = GetMessage(My.Settings.MQ_Datagram_Receive_Queue, My.Settings.MQ_Datagram_Receive_Wait_Interval, _
                                    MQC.MQMT_DATAGRAM)
                        oGetMsg.Format = MQC.MQFMT_STRING
                        If oGetMsg IsNot Nothing AndAlso oGetMsg.TotalMessageLength > 0 Then
                            If TextBoxDatagramReceive.Text.Trim = "" Then
                                TextBoxDatagramReceive.Text = oGetMsg.ReadString(oGetMsg.MessageLength)
                            Else
                                TextBoxDatagramReceive.Text = TextBoxDatagramReceive.Text & vbCrLf & oGetMsg.ReadString(oGetMsg.MessageLength)
                            End If
                        Else
                            Exit For
                        End If
                    Next
                Case "TabPageDatagramSend"
                    For iCount = 0 To My.Settings.Datagram_Send_Msgs - 1
                        Dim oSendMsg As New MQMessage
                        oSendMsg.MessageType = MQC.MQMT_DATAGRAM
                        oSendMsg.Format = MQC.MQFMT_STRING
                        oSendMsg.WriteString(TextBoxDatagramSend.Text)
                        PutMessage(oSendMsg, My.Settings.MQ_Datagram_Send_Queue, My.Settings.MQ_Datagram_Send_Timeout_Interval)
                    Next
                Case "TabPageSendReqWaitReply"
                    Dim iFirstPolicyNo As Integer
                    Dim iPolicyNo As Integer
                    Dim sPolicyPrefix As String = ""
                    Dim sMsgWithoutPolicy As String = ""
                    Dim sMsgPolicy As String = ""
                    Dim iNoOfMsgs As Integer

                    TextBoxRequestReply.Text = ""
                    iNoofMsgs = My.Settings.Send_Request_Msgs
                    If TextBoxRequestSend.Text.Trim.Length < 10 AndAlso iNoofMsgs > 1 Then
                        MessageBox.Show("Please give the valid message")
                        Return
                    End If
                    If iNoOfMsgs > 1 Then
                        sPolicyPrefix = TextBoxRequestSend.Text.Trim.Substring(0, 5)
                        iFirstPolicyNo = TextBoxRequestSend.Text.Trim.Substring(5, 4)
                        sMsgWithoutPolicy = TextBoxRequestSend.Text.Substring(20)
                    End If

                    For iCount = 0 To iNoofMsgs - 1
                        Dim oSendMsg As New MQMessage
                        Dim oReplyMsg As MQMessage
                        Dim sPolicy As String

                        If iNoOfMsgs > 1 Then
                            iPolicyNo = iFirstPolicyNo + iCount
                            sPolicy = sPolicyPrefix & iPolicyNo.ToString
                            sMsgPolicy = sPolicy.PadRight(20, " ") & sMsgWithoutPolicy
                            If iCount > 0 Then
                                TextBoxRequestSend.Text = TextBoxRequestSend.Text & vbCrLf & sMsgPolicy
                            End If
                        Else
                            sMsgPolicy = TextBoxRequestSend.Text
                        End If
                        oSendMsg.MessageType = MQC.MQMT_REQUEST
                        oSendMsg.Format = MQC.MQFMT_STRING
                        oSendMsg.WriteString(sMsgPolicy)
                        oSendMsg.ReplyToQueueName = My.Settings.MQ_SendRequestReply_ReplyQueue
                        If PutMessage(oSendMsg, My.Settings.MQ_SendRequestReply_Queue, My.Settings.MQ_SendRequestReply_Timeout_Interval) Then
                            oReplyMsg = GetMessage(My.Settings.MQ_SendRequestReply_ReplyQueue, My.Settings.MQ_SendRequestReply_Timeout_Interval, MQC.MQMT_REPLY, oSendMsg.CorrelationId)
                            If oReplyMsg IsNot Nothing Then
                                If TextBoxRequestReply.Text.Trim = "" Then
                                    TextBoxRequestReply.Text = oReplyMsg.ReadString(oReplyMsg.MessageLength)
                                Else
                                    TextBoxRequestReply.Text = TextBoxRequestReply.Text & vbCrLf & oReplyMsg.ReadString(oReplyMsg.MessageLength)
                                End If
                                UpdateStatusBar(Nothing, "Successfully received " & iCount + 1 & "Message(s)")
                            End If
                        End If
                    Next

                Case "TabPageGetRequestSendReply"
                    '                    For iCount = 0 To My.Settings.Get_Request_Msgs - 1
                    Dim oGetMsg As MQMessage = GetMessage(My.Settings.MQ_GetRequestReply_RequestQueue, My.Settings.MQ_GetRequestReply_Timeout_Interval, _
                                MQC.MQMT_REQUEST)
                    oGetMsg.Format = MQC.MQFMT_STRING
                    If oGetMsg IsNot Nothing AndAlso oGetMsg.TotalMessageLength > 0 Then

                        TextBoxReceiveRequest.Text = oGetMsg.ReadString(oGetMsg.MessageLength)
                        'If TextBoxReceiveRequest.Text.Trim = "" Then
                        '    TextBoxReceiveRequest.Text = oGetMsg.ReadString(oGetMsg.MessageLength)
                        'Else
                        '    TextBoxReceiveRequest.Text = TextBoxReceiveRequest.Text & vbCrLf & oGetMsg.ReadString(oGetMsg.MessageLength)
                        'End If
                        ButtonMQCmd.Enabled = False
                        ButtonMQCmd2.Visible = True
                        ButtonMQCmd2.Text = "Send MQ Reply Message " '& iCount + 1

                        _strSendReplyQueue = oGetMsg.ReplyToQueueName
                        _bytMessageID = oGetMsg.MessageId
                        While Not _bSendReplyPressed
                            My.Application.DoEvents()
                        End While
                        'Else
                        '    Exit For
                    End If
                    'Next
            End Select
        Catch ex As Exception
            UpdateStatusBar(Nothing, "Unexpected Error " & ex.Message, True)
        Finally
            _bSendReplyPressed = False
            ButtonMQCmd.Enabled = True
            ButtonMQCmd2.Visible = False
        End Try
    End Sub

    Private Sub ButtonMQCmd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMQCmd2.Click
        If MQTabControl.SelectedTab.Name = "TabPageGetRequestSendReply" Then
            Dim oSendReplyMsg As New MQMessage
            oSendReplyMsg.MessageType = MQC.MQMT_REPLY
            oSendReplyMsg.Format = MQC.MQFMT_STRING
            oSendReplyMsg.WriteString(TextBoxSendReply.Text)
            oSendReplyMsg.ReplyToQueueName = My.Settings.MQ_SendRequestReply_ReplyQueue
            oSendReplyMsg.MessageId = _bytMessageID
            PutMessage(oSendReplyMsg, _strSendReplyQueue, My.Settings.MQ_GetRequestReply_Timeout_Interval)
            _bSendReplyPressed = True
        End If
    End Sub

    Public Function GetMessage(ByVal QueueName As String, ByVal WaitInterval As Integer, ByVal MsgType As Integer, _
                               Optional ByRef CorrelID As Byte() = Nothing) As MQMessage
        'Me.Cursor = Cursors.WaitCursor

        'Set up the options on the queue we wish to open
        Dim openOptions As Integer = MQC.MQOO_INPUT_AS_Q_DEF Or MQC.MQOO_FAIL_IF_QUIESCING
        'Define a WebSphere MQ message buffer to receive the message into..
        Dim oRetrievedMessage As MQMessage = New MQMessage()
        Dim strTemp As String

        'Now specify the queue that we wish to open,and the open options... 
        Dim oReceiveQueue As MQQueue

        Try
            oReceiveQueue = _oQMgr.AccessQueue(QueueName, openOptions)

        Catch ex As IBM.WMQ.MQException
            strTemp = "Failed retrieving " & GetMessageType(MsgType) & " message, Completion code = " & ex.CompletionCode & _
                      ", Reason code = " & ex.ReasonCode
            UpdateStatusBar(oRetrievedMessage, strTemp, True)
            'Me.Cursor = Cursors.Arrow
            Return Nothing
        End Try

        'Set the get message options.. 
        Dim gmo As MQGetMessageOptions = New MQGetMessageOptions()
        gmo.Options = MQC.MQGMO_WAIT Or MQC.MQGMO_FAIL_IF_QUIESCING Or MQC.MQGMO_SYNCPOINT

        gmo.WaitInterval = WaitInterval * 1000 'Convert to milliseconds
        oRetrievedMessage.Format = MQC.MQFMT_STRING
        'Get the message off the queue with the specified options
        Try
            If CorrelID IsNot Nothing Then
                gmo.Options = gmo.Options Or MQC.MQMO_MATCH_CORREL_ID
                oRetrievedMessage.CorrelationId = CorrelID
            End If

            oReceiveQueue.Get(oRetrievedMessage, gmo)

            'Commit the transaction
            _oQMgr.Commit()

            If oRetrievedMessage.MessageType = MsgType Then
                UpdateStatusBar(oRetrievedMessage, "Received MQ " & GetMessageType(oRetrievedMessage) & " message successfully.")
            Else
                UpdateStatusBar(oRetrievedMessage, "Received MQ " & GetMessageType(oRetrievedMessage) & " message successfully, but was expecting " & _
                                GetMessageType(MsgType) & " message.")
            End If
        Catch ex As IBM.WMQ.MQException
            If ex.ReasonCode = MQC.MQRC_NO_MSG_AVAILABLE Then
                strTemp = "No " & GetMessageType(MsgType) & " messages on queue " & QueueName & "."
            Else
                strTemp = "Failed retrieving " & GetMessageType(MsgType) & " message, Completion code = " & oReceiveQueue.CompletionCode & _
                          ", Reason code = " & oReceiveQueue.ReasonCode
            End If

            _oQMgr.Backout()
            UpdateStatusBar(Nothing, strTemp, True)
            'Me.Cursor = Cursors.Arrow
            Return Nothing
        End Try

        'Me.Cursor = Cursors.Arrow
        Return oRetrievedMessage
    End Function

    Public Function PutMessage(ByRef oSendMsg As MQMessage, ByVal QueueName As String, ByVal TimeoutInterval As Integer) As Boolean
        'Me.Cursor = Cursors.WaitCursor

        Dim strTemp As String
        'Set up the options on the queue we wish to open
        Dim openOptions As Integer = MQC.MQOO_OUTPUT Or MQC.MQOO_FAIL_IF_QUIESCING
        Dim oSendQueue As MQQueue = Nothing

        Try
            oSendQueue = _oQMgr.AccessQueue(QueueName, openOptions)
        Catch ex As IBM.WMQ.MQException
            strTemp = "Failed accessing queue to send " & GetMessageType(oSendMsg) & " message, Completion code = " & ex.CompletionCode & _
                      ", Reason code = " & ex.ReasonCode
            UpdateStatusBar(Nothing, strTemp, True)
            'Me.Cursor = Cursors.Arrow
            Return False
        End Try

        'Set the put message options.. 
        Dim pmo As MQPutMessageOptions = New MQPutMessageOptions()
        pmo.Options = MQC.MQPMO_FAIL_IF_QUIESCING Or MQC.MQPMO_SYNCPOINT

        Try
            'Put the message on the queue with the specified options and wait for the reply message
            oSendQueue.Put(oSendMsg, pmo)

            'Commit the transaction
            _oQMgr.Commit()

            UpdateStatusBar(oSendMsg, "Sent MQ " & GetMessageType(oSendMsg) & " message successfully.")
        Catch ex As IBM.WMQ.MQException
            strTemp = "Failed sending " & GetMessageType(oSendMsg) & " message, Completion code = " & oSendQueue.CompletionCode & _
                          ", Reason code = " & oSendQueue.ReasonCode

            _oQMgr.Backout()
            UpdateStatusBar(Nothing, strTemp, True)
            'Me.Cursor = Cursors.Arrow
            Return False
        End Try

        'Me.Cursor = Cursors.Arrow
        Return True
    End Function

    Private Sub UpdateStatusBar(ByRef oMsg As MQMessage, ByVal strStatus As String, Optional ByVal bErrorMsg As Boolean = False)
        Dim strTemp As String = ""

        StatusStrip.Items("MsgType").Text = GetMessageType(oMsg)

        If bErrorMsg Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
            StatusStrip.Items("Status").ForeColor = Color.Red
        Else
            StatusStrip.Items("Status").ForeColor = Color.Black
        End If

        StatusStrip.Items("Status").Text = strStatus
        StatusStrip.Items("LastDateTime").Text = Now.ToString("h:m:ss tt")
    End Sub

    Private Sub ButtonSettings_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSettings.Click
        Dim oFrm As New SettingsForm

        Select Case MQTabControl.SelectedTab.Name
            Case "TabPageDatagramReceive", "TabPageDatagramSend"
                oFrm.TabControl1.SelectedTab = oFrm.TabPage2

            Case "TabPageSendReqWaitReply"
                oFrm.TabControl1.SelectedTab = oFrm.TabPage3

            Case "TabPageGetRequestSendReply"
                oFrm.TabControl1.SelectedTab = oFrm.TabPage4
        End Select

        If oFrm.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then
            My.Settings.Reload()
        Else
            My.Settings.Save()
            ConnectToQueueManager()
        End If

    End Sub

    Private Function GetMessageType(ByVal iMsgType As Integer) As String
        Dim strTemp As String = "Unknown"

        Select Case iMsgType
            Case MQC.MQMT_DATAGRAM
                strTemp = "Datagram"
            Case MQC.MQMT_REQUEST
                strTemp = "Request"
            Case MQC.MQMT_REPLY
                strTemp = "Reply"
            Case Else
                strTemp = "Unknown"
        End Select

        Return strTemp
    End Function

    Private Function GetMessageType(ByRef oMsg As MQMessage) As String
        If oMsg Is Nothing Then
            Return "Unknown"
        Else
            Return GetMessageType(oMsg.MessageType)
        End If
    End Function

    Private Sub ButtonCopyClipBrd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCopyClipBrd.Click
        My.Computer.Clipboard.SetText(_oCopyClipboardTextBox.Text)
    End Sub

    Private Sub TabMQ_Selected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles MQTabControl.Selected
        Select Case e.TabPage.Name
            Case "TabPageDatagramReceive"
                ButtonMQCmd.Text = "Get MQ Datagram Message"
                ButtonCopyClipBrd.Text = "Copy Datagram Message to Clipboard"
                _oCopyClipboardTextBox = TextBoxDatagramReceive

            Case "TabPageDatagramSend"
                ButtonMQCmd.Text = "Send MQ Datagram Message"
                ButtonCopyClipBrd.Text = "Copy Datagram Message to Clipboard"
                _oCopyClipboardTextBox = TextBoxDatagramSend

            Case "TabPageSendReqWaitReply"
                ButtonMQCmd.Text = "Send MQ Request Message"
                ButtonCopyClipBrd.Text = "Copy Reply Message to Clipboard"
                _oCopyClipboardTextBox = TextBoxRequestReply

            Case "TabPageGetRequestSendReply"
                ButtonMQCmd.Text = "Get MQ Request Message"
                ButtonCopyClipBrd.Text = "Copy Request Message to Clipboard"
                _oCopyClipboardTextBox = TextBoxReceiveRequest
        End Select
    End Sub

    

    Private Sub cmdProceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProceed.Click
        Dim oQueue As MQQueue = Nothing
        Dim sQueueName As String
        Dim pmo As MQPutMessageOptions = New MQPutMessageOptions()
        Dim oSendMsg As New MQMessage
        Dim openOptions As Integer = MQC.MQOO_BROWSE Or MQC.MQOO_OUTPUT Or MQC.MQOO_FAIL_IF_QUIESCING Or MQC.MQOO_INPUT_EXCLUSIVE Or MQC.MQOO_INQUIRE Or MQC.MQOO_PASS_ALL_CONTEXT Or MQC.MQOO_SET Or MQC.MQOO_SET_ALL_CONTEXT
        Dim icount As Integer
        Dim iMaxMsg As Integer

        Try

            sQueueName = txtQueueName.Text.Trim
            If sQueueName.Trim = "" Then
                MessageBox.Show("Please enter the Queue Name to Proceed........", Application.ProductName)
                Return
            ElseIf chkMQRC_PUT_INHIBITED.Checked AndAlso chkMQRC_Q_FULL.Checked Then
                MessageBox.Show("MQRC_PUT_INHIBITED and MQRC_Q_FULL selected. Please select any one of this...", Application.ProductName)
                Return
            End If

            pmo.Options = MQC.MQPMO_FAIL_IF_QUIESCING Or MQC.MQPMO_SYNCPOINT

            '_oQMgr.Begin()

            oQueue = _oQMgr.AccessQueue(sQueueName, openOptions)


            If chkMQRC_PUT_INHIBITED.CheckState = CheckState.Checked Then
                oQueue.InhibitGet = MQC.MQQA_GET_INHIBITED
            Else
                oQueue.InhibitGet = MQC.MQQA_GET_ALLOWED
            End If

            If chkMQRC_GET_INHIBITED.CheckState = CheckState.Checked Then
                oQueue.InhibitPut = MQC.MQQA_PUT_INHIBITED
            Else
                oQueue.InhibitPut = MQC.MQQA_PUT_ALLOWED
            End If


            If chkMQRC_Q_FULL.CheckState = CheckState.Checked Then
                iMaxMsg = oQueue.MaximumDepth - oQueue.CurrentDepth
                For icount = 0 To iMaxMsg - 1
                    oSendMsg.MessageType = MQC.MQMT_DATAGRAM
                    oSendMsg.Format = MQC.MQFMT_STRING
                    oSendMsg.WriteString(icount.ToString)
                    oQueue.Put(oSendMsg, pmo)
                Next

            End If

            _oQMgr.Commit()

        Catch ex As IBM.WMQ.MQException
            _oQMgr.Backout()
            MessageBox.Show(ex.Message & " Reason Code : " & ex.ReasonCode)

        Finally

        End Try



    End Sub

    Private Sub tmrTestApp_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTestApp.Tick
        Try
            If _bProcessCompleted Then
                _bProcessCompleted = False
                SendRequset_WaitReply()
                If My.Settings.EnableMQAppReply Then
                    GetRequest_WaitReply()
                End If
                _bProcessCompleted = True
            End If

        Catch ex As IBM.WMQ.MQException
            WritetoLog(ex.Message & " Reason Code : " & ex.ReasonCode)
            _bProcessCompleted = True
        Catch ex As Exception
            WritetoLog(ex.Message)
            _bProcessCompleted = True
        Finally

        End Try

    End Sub

    Private Sub btnStartTimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartTimer.Click
        tmrTestApp.Interval = My.Settings.Timer_Interval * 1000
        _bTimerEnabled = True
        tmrTestApp.Enabled = True
        btnStartTimer.Enabled = False
        btnStopTimer.Enabled = True
    End Sub

    Private Sub btnStopTimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopTimer.Click
        _bTimerEnabled = False
        tmrTestApp.Enabled = False
        btnStopTimer.Enabled = False
        btnStartTimer.Enabled = True
    End Sub
    Private Sub SendRequset_WaitReply()
        Dim oSendMsg As New MQMessage
        Dim oSendMsg_AppRequest As New MQMessage

        Dim oReplyMsg As MQMessage
        Dim sMsgPolicy As String
        Dim sApp_Status_Message As String
        Dim sApp_Request_Message As String
        Dim sSendRequestReply_Queue As String = My.Settings.MQ_SendRequestReply_Queue
        Dim sSendRequestReply_ReplyQueue As String = My.Settings.MQ_SendRequestReply_ReplyQueue
        Dim sDatagram_Send_Queue As String = My.Settings.MQ_Datagram_Send_Queue
        Dim sDatagram_Receive_Queue As String = My.Settings.MQ_Datagram_Receive_Queue


        Try
            'AppStatus
            _lngPolicyNo = _lngPolicyNo + 1
            sMsgPolicy = _lngPolicyNo.ToString
            sMsgPolicy = sMsgPolicy.Substring(0, 8)

            If My.Settings.EnableMQAppStatus Then
                If My.Settings.ValidateMsgFormat Then
                    sApp_Status_Message = sMsgPolicy.PadRight(20, " ") & "PRO0258526APP1236526"
                Else
                    sApp_Status_Message = My.Settings.InvalidMsg
                End If
                oSendMsg.MessageType = MQC.MQMT_REQUEST
                oSendMsg.Format = MQC.MQFMT_STRING
                oSendMsg.WriteString(sApp_Status_Message)
                oSendMsg.ReplyToQueueName = sSendRequestReply_ReplyQueue
                If PutMessage(oSendMsg, sSendRequestReply_Queue, My.Settings.MQ_SendRequestReply_Timeout_Interval) Then
                    WritetoLog("MQAppStatus : " & sApp_Status_Message & " - Message sent to " & sSendRequestReply_Queue)
                    oReplyMsg = GetMessage(sSendRequestReply_ReplyQueue, My.Settings.MQ_SendRequestReply_Timeout_Interval, MQC.MQMT_REPLY, oSendMsg.CorrelationId)
                    If oReplyMsg IsNot Nothing Then
                        WritetoLog("MQAppStatus : " & oReplyMsg.ReadString(oReplyMsg.MessageLength) & " - Message Received from " & sSendRequestReply_ReplyQueue)
                    Else
                        WritetoLog("MQAppStatus : Reply Message not Received from " & sSendRequestReply_ReplyQueue)
                    End If
                End If
            End If

            'AppRequest
            If My.Settings.EnableMQAppRequest Then
                If My.Settings.ValidateMsgFormat Then
                    sApp_Request_Message = sMsgPolicy.PadRight(20, " ") & "0000000001A000001542X000001             JRes_Input           Res_Input           1                   DEPTT021548452154785DIV00002547852145852PGL00002547852145852B10                  "
                Else
                    sApp_Request_Message = My.Settings.InvalidMsg
                End If

                oSendMsg_AppRequest.MessageType = MQC.MQMT_REQUEST
                oSendMsg.Format = MQC.MQFMT_STRING
                oSendMsg_AppRequest.WriteString(sApp_Request_Message)
                oSendMsg_AppRequest.ReplyToQueueName = sDatagram_Receive_Queue
                If PutMessage(oSendMsg_AppRequest, sDatagram_Send_Queue, My.Settings.MQ_Datagram_Send_Timeout_Interval) Then
                    WritetoLog("MQAppRequest : " & sApp_Request_Message & " - Message sent to " & sDatagram_Send_Queue)
                    oReplyMsg = GetMessage(sDatagram_Receive_Queue, My.Settings.MQ_Datagram_Receive_Wait_Interval, MQC.MQMT_REPLY, oSendMsg_AppRequest.CorrelationId)
                    If oReplyMsg IsNot Nothing Then
                        WritetoLog("MQAppRequest : " & oReplyMsg.ReadString(oReplyMsg.MessageLength) & " - Message Received from " & sDatagram_Receive_Queue)
                    Else
                        WritetoLog("MQAppRequest : Reply Message not Received from " & sDatagram_Receive_Queue)
                    End If
                End If
            End If


        Catch ex As IBM.WMQ.MQException
            '            _oQMgr.Backout()
            WritetoLog(ex.Message & " Reason Code : " & ex.ReasonCode)
        Catch ex As Exception
            WritetoLog(ex.Message)
            'MessageBox.Show(ex.Message)
        Finally

        End Try

    End Sub
    Private Sub GetRequest_WaitReply()
        Dim sGetRequestReply_RequestQueue As String = My.Settings.MQ_GetRequestReply_RequestQueue
        Dim sReplyMsg As String

        Try
            Dim oGetMsg As MQMessage = GetMessage(sGetRequestReply_RequestQueue, My.Settings.MQ_GetRequestReply_Timeout_Interval, _
            MQC.MQMT_REQUEST)
            Dim oSendReplyMsg As New MQMessage
            If oGetMsg IsNot Nothing AndAlso oGetMsg.TotalMessageLength > 0 Then
                WritetoLog("MQAppReply : " & oGetMsg.ReadString(oGetMsg.MessageLength) & " - Message received from " & sGetRequestReply_RequestQueue)
                _strSendReplyQueue = oGetMsg.ReplyToQueueName
                _bytMessageID = oGetMsg.MessageId
                oSendReplyMsg.MessageType = MQC.MQMT_REPLY
                oSendReplyMsg.Format = MQC.MQFMT_STRING
                If My.Settings.ValidateMsgFormat Then
                    sReplyMsg = _lngPolicyNo.ToString
                Else
                    sReplyMsg = My.Settings.InvalidMsg
                End If

                oSendReplyMsg.WriteString(sReplyMsg)
                oSendReplyMsg.ReplyToQueueName = My.Settings.MQ_SendRequestReply_ReplyQueue
                oSendReplyMsg.MessageId = _bytMessageID
                PutMessage(oSendReplyMsg, _strSendReplyQueue, My.Settings.MQ_GetRequestReply_Timeout_Interval)
                WritetoLog("MQAppReply : " & sReplyMsg & " - Message sent to " & _strSendReplyQueue)
            Else
                WritetoLog("MQAppReply : No Message in " & sGetRequestReply_RequestQueue)
            End If

        Catch ex As IBM.WMQ.MQException
            WritetoLog(ex.Message & " Reason Code : " & ex.ReasonCode)
        Catch ex As Exception
            WritetoLog(ex.Message)
        Finally

        End Try

    End Sub

    Private Sub WritetoLog(ByVal sMsg As String)
        Dim oFileStream As FileStream
        Dim oStreamWriter As StreamWriter
        Dim sFilename As String = "TestApp_" & Date.Today.ToString("MMddyyyy") & ".log"

        Try
            oFileStream = New FileStream(sFilename, FileMode.Append, FileAccess.Write)
            oStreamWriter = New StreamWriter(oFileStream)
            oStreamWriter.WriteLine(Now & " : " & sMsg)
            oStreamWriter.Close()
        Catch ex As Exception

        Finally
            oFileStream.Dispose()
            oStreamWriter.Dispose()
        End Try

    End Sub

End Class
*/