<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.txtSecurityExit = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.lblGetRequest = New System.Windows.Forms.Label
        Me.lblSendRequest = New System.Windows.Forms.Label
        Me.lblDatagramReceive = New System.Windows.Forms.Label
        Me.lblDatagramSend = New System.Windows.Forms.Label
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.lblInvalidMsg = New System.Windows.Forms.Label
        Me.lblTimerInterval = New System.Windows.Forms.Label
        Me.SettingsFormBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MQQMgrPortNum = New System.Windows.Forms.TextBox
        Me.MQQMgrCustomChannel = New System.Windows.Forms.TextBox
        Me.MQQMgrHostName = New System.Windows.Forms.TextBox
        Me.MQQMgrName = New System.Windows.Forms.TextBox
        Me.DatagramReceiveWaitInterval = New System.Windows.Forms.TextBox
        Me.DatagramReceiveQName = New System.Windows.Forms.TextBox
        Me.DatagramSendTimeoutInt = New System.Windows.Forms.TextBox
        Me.DatagramSendQName = New System.Windows.Forms.TextBox
        Me.ReqReplyReplyQName = New System.Windows.Forms.TextBox
        Me.ReqReplyTimeout = New System.Windows.Forms.TextBox
        Me.ReqReplyQName = New System.Windows.Forms.TextBox
        Me.GetRequestReplyTimeout = New System.Windows.Forms.TextBox
        Me.GetRequestQName = New System.Windows.Forms.TextBox
        Me.txtDatagramSend = New System.Windows.Forms.TextBox
        Me.txtGetRequest = New System.Windows.Forms.TextBox
        Me.txtSendRequest = New System.Windows.Forms.TextBox
        Me.txtDataGramReceive = New System.Windows.Forms.TextBox
        Me.txtInvaidMsg = New System.Windows.Forms.TextBox
        Me.chkValidateMsgFormat = New System.Windows.Forms.CheckBox
        Me.txtTimer_Interval = New System.Windows.Forms.TextBox
        Me.chkEnableMQAppReply = New System.Windows.Forms.CheckBox
        Me.chkEnableMQAppRequest = New System.Windows.Forms.CheckBox
        Me.chkEnableMQAppStatus = New System.Windows.Forms.CheckBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        CType(Me.SettingsFormBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(419, 281)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 0
        Me.Cancel_Button.Text = "Cancel"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Location = New System.Drawing.Point(7, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(558, 266)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtSecurityExit)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.MQQMgrPortNum)
        Me.TabPage1.Controls.Add(Me.MQQMgrCustomChannel)
        Me.TabPage1.Controls.Add(Me.MQQMgrHostName)
        Me.TabPage1.Controls.Add(Me.MQQMgrName)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(550, 240)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Queue Manager"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtSecurityExit
        '
        Me.txtSecurityExit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "MQ_SecurityExit", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtSecurityExit.Location = New System.Drawing.Point(177, 136)
        Me.txtSecurityExit.Name = "txtSecurityExit"
        Me.txtSecurityExit.Size = New System.Drawing.Size(294, 20)
        Me.txtSecurityExit.TabIndex = 9
        Me.txtSecurityExit.Text = Global.MQTestClient.My.MySettings.Default.MQ_SecurityExit
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(17, 139)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 13)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Security Exit"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Custom Channel Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Host Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Port Number"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Queue Manager Name"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(550, 240)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Datagram"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DatagramReceiveWaitInterval)
        Me.GroupBox3.Controls.Add(Me.DatagramReceiveQName)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 113)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(479, 93)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Receive Queue Settings"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(28, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Wait Interval"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(28, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Queue Name"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DatagramSendTimeoutInt)
        Me.GroupBox2.Controls.Add(Me.DatagramSendQName)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(479, 93)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Send Queue Settings"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Timeout Interval"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Queue Name"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(550, 240)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Send Request/Wait Reply"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ReqReplyReplyQName)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 113)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(479, 61)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reply Queue Settings"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(28, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Queue Name"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ReqReplyTimeout)
        Me.GroupBox4.Controls.Add(Me.ReqReplyQName)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(479, 93)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Send Queue Settings"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(28, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Timeout Interval"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(28, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Queue Name"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GetRequestReplyTimeout)
        Me.TabPage4.Controls.Add(Me.Label13)
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Controls.Add(Me.GetRequestQName)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(550, 240)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Get Request/Send Reply"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(40, 67)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Timeout Interval"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(40, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Queue Name"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.txtDatagramSend)
        Me.TabPage5.Controls.Add(Me.txtGetRequest)
        Me.TabPage5.Controls.Add(Me.lblGetRequest)
        Me.TabPage5.Controls.Add(Me.lblSendRequest)
        Me.TabPage5.Controls.Add(Me.lblDatagramReceive)
        Me.TabPage5.Controls.Add(Me.lblDatagramSend)
        Me.TabPage5.Controls.Add(Me.txtSendRequest)
        Me.TabPage5.Controls.Add(Me.txtDataGramReceive)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(550, 240)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "No of Messages"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'lblGetRequest
        '
        Me.lblGetRequest.AutoSize = True
        Me.lblGetRequest.Location = New System.Drawing.Point(120, 149)
        Me.lblGetRequest.Name = "lblGetRequest"
        Me.lblGetRequest.Size = New System.Drawing.Size(127, 13)
        Me.lblGetRequest.TabIndex = 6
        Me.lblGetRequest.Text = "Get Request/Send Reply"
        '
        'lblSendRequest
        '
        Me.lblSendRequest.AutoSize = True
        Me.lblSendRequest.Location = New System.Drawing.Point(120, 106)
        Me.lblSendRequest.Name = "lblSendRequest"
        Me.lblSendRequest.Size = New System.Drawing.Size(132, 13)
        Me.lblSendRequest.TabIndex = 4
        Me.lblSendRequest.Text = "Send Request/Wait Reply"
        '
        'lblDatagramReceive
        '
        Me.lblDatagramReceive.AutoSize = True
        Me.lblDatagramReceive.Location = New System.Drawing.Point(120, 72)
        Me.lblDatagramReceive.Name = "lblDatagramReceive"
        Me.lblDatagramReceive.Size = New System.Drawing.Size(96, 13)
        Me.lblDatagramReceive.TabIndex = 2
        Me.lblDatagramReceive.Text = "Datagram Receive"
        '
        'lblDatagramSend
        '
        Me.lblDatagramSend.AutoSize = True
        Me.lblDatagramSend.Location = New System.Drawing.Point(120, 29)
        Me.lblDatagramSend.Name = "lblDatagramSend"
        Me.lblDatagramSend.Size = New System.Drawing.Size(81, 13)
        Me.lblDatagramSend.TabIndex = 0
        Me.lblDatagramSend.Text = "Datagram Send"
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.lblInvalidMsg)
        Me.TabPage6.Controls.Add(Me.lblTimerInterval)
        Me.TabPage6.Controls.Add(Me.txtInvaidMsg)
        Me.TabPage6.Controls.Add(Me.chkValidateMsgFormat)
        Me.TabPage6.Controls.Add(Me.txtTimer_Interval)
        Me.TabPage6.Controls.Add(Me.chkEnableMQAppReply)
        Me.TabPage6.Controls.Add(Me.chkEnableMQAppRequest)
        Me.TabPage6.Controls.Add(Me.chkEnableMQAppStatus)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(550, 240)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Timer"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'lblInvalidMsg
        '
        Me.lblInvalidMsg.AutoSize = True
        Me.lblInvalidMsg.Location = New System.Drawing.Point(66, 194)
        Me.lblInvalidMsg.Name = "lblInvalidMsg"
        Me.lblInvalidMsg.Size = New System.Drawing.Size(84, 13)
        Me.lblInvalidMsg.TabIndex = 14
        Me.lblInvalidMsg.Text = "Invalid Message"
        '
        'lblTimerInterval
        '
        Me.lblTimerInterval.AutoSize = True
        Me.lblTimerInterval.Location = New System.Drawing.Point(66, 158)
        Me.lblTimerInterval.Name = "lblTimerInterval"
        Me.lblTimerInterval.Size = New System.Drawing.Size(122, 13)
        Me.lblTimerInterval.TabIndex = 11
        Me.lblTimerInterval.Text = "Timer Interval (Seconds)"
        '
        'SettingsFormBindingSource
        '
        Me.SettingsFormBindingSource.DataSource = GetType(MQTestClient.SettingsForm)
        '
        'MQQMgrPortNum
        '
        Me.MQQMgrPortNum.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "MQ_QMGR_Port", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.MQQMgrPortNum.Location = New System.Drawing.Point(177, 108)
        Me.MQQMgrPortNum.Name = "MQQMgrPortNum"
        Me.MQQMgrPortNum.Size = New System.Drawing.Size(294, 20)
        Me.MQQMgrPortNum.TabIndex = 7
        Me.MQQMgrPortNum.Text = Global.MQTestClient.My.MySettings.Default.MQ_QMGR_Port
        '
        'MQQMgrCustomChannel
        '
        Me.MQQMgrCustomChannel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "MQ_QMGR_Custom_Channel_Name", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.MQQMgrCustomChannel.Location = New System.Drawing.Point(177, 81)
        Me.MQQMgrCustomChannel.Name = "MQQMgrCustomChannel"
        Me.MQQMgrCustomChannel.Size = New System.Drawing.Size(294, 20)
        Me.MQQMgrCustomChannel.TabIndex = 5
        Me.MQQMgrCustomChannel.Text = Global.MQTestClient.My.MySettings.Default.MQ_QMGR_Custom_Channel_Name
        '
        'MQQMgrHostName
        '
        Me.MQQMgrHostName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "MQ_QMGR_Host_Name", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.MQQMgrHostName.Location = New System.Drawing.Point(177, 53)
        Me.MQQMgrHostName.Name = "MQQMgrHostName"
        Me.MQQMgrHostName.Size = New System.Drawing.Size(294, 20)
        Me.MQQMgrHostName.TabIndex = 3
        Me.MQQMgrHostName.Text = Global.MQTestClient.My.MySettings.Default.MQ_QMGR_Host_Name
        '
        'MQQMgrName
        '
        Me.MQQMgrName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "MQ_QMGR_Queue_Manager", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.MQQMgrName.Location = New System.Drawing.Point(177, 26)
        Me.MQQMgrName.Name = "MQQMgrName"
        Me.MQQMgrName.Size = New System.Drawing.Size(294, 20)
        Me.MQQMgrName.TabIndex = 1
        Me.MQQMgrName.Text = Global.MQTestClient.My.MySettings.Default.MQ_QMGR_Queue_Manager
        '
        'DatagramReceiveWaitInterval
        '
        Me.DatagramReceiveWaitInterval.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "MQ_Datagram_Receive_Wait_Interval", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DatagramReceiveWaitInterval.Location = New System.Drawing.Point(186, 52)
        Me.DatagramReceiveWaitInterval.Name = "DatagramReceiveWaitInterval"
        Me.DatagramReceiveWaitInterval.Size = New System.Drawing.Size(271, 20)
        Me.DatagramReceiveWaitInterval.TabIndex = 3
        Me.DatagramReceiveWaitInterval.Text = Global.MQTestClient.My.MySettings.Default.MQ_Datagram_Receive_Wait_Interval
        '
        'DatagramReceiveQName
        '
        Me.DatagramReceiveQName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "MQ_Datagram_Receive_Queue", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DatagramReceiveQName.Location = New System.Drawing.Point(186, 24)
        Me.DatagramReceiveQName.Name = "DatagramReceiveQName"
        Me.DatagramReceiveQName.Size = New System.Drawing.Size(271, 20)
        Me.DatagramReceiveQName.TabIndex = 1
        Me.DatagramReceiveQName.Text = Global.MQTestClient.My.MySettings.Default.MQ_Datagram_Receive_Queue
        '
        'DatagramSendTimeoutInt
        '
        Me.DatagramSendTimeoutInt.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "MQ_Datagram_Send_Timeout_Interval", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DatagramSendTimeoutInt.Location = New System.Drawing.Point(186, 58)
        Me.DatagramSendTimeoutInt.Name = "DatagramSendTimeoutInt"
        Me.DatagramSendTimeoutInt.Size = New System.Drawing.Size(271, 20)
        Me.DatagramSendTimeoutInt.TabIndex = 3
        Me.DatagramSendTimeoutInt.Text = Global.MQTestClient.My.MySettings.Default.MQ_Datagram_Send_Timeout_Interval
        '
        'DatagramSendQName
        '
        Me.DatagramSendQName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "MQ_Datagram_Send_Queue", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DatagramSendQName.Location = New System.Drawing.Point(186, 24)
        Me.DatagramSendQName.Name = "DatagramSendQName"
        Me.DatagramSendQName.Size = New System.Drawing.Size(271, 20)
        Me.DatagramSendQName.TabIndex = 1
        Me.DatagramSendQName.Text = Global.MQTestClient.My.MySettings.Default.MQ_Datagram_Send_Queue
        '
        'ReqReplyReplyQName
        '
        Me.ReqReplyReplyQName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "MQ_SendRequestReply_ReplyQueue", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ReqReplyReplyQName.Location = New System.Drawing.Point(186, 20)
        Me.ReqReplyReplyQName.Name = "ReqReplyReplyQName"
        Me.ReqReplyReplyQName.Size = New System.Drawing.Size(271, 20)
        Me.ReqReplyReplyQName.TabIndex = 1
        Me.ReqReplyReplyQName.Text = Global.MQTestClient.My.MySettings.Default.MQ_SendRequestReply_ReplyQueue
        '
        'ReqReplyTimeout
        '
        Me.ReqReplyTimeout.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "MQ_SendRequestReply_Timeout_Interval", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ReqReplyTimeout.Location = New System.Drawing.Point(186, 50)
        Me.ReqReplyTimeout.Name = "ReqReplyTimeout"
        Me.ReqReplyTimeout.Size = New System.Drawing.Size(271, 20)
        Me.ReqReplyTimeout.TabIndex = 3
        Me.ReqReplyTimeout.Text = Global.MQTestClient.My.MySettings.Default.MQ_SendRequestReply_Timeout_Interval
        '
        'ReqReplyQName
        '
        Me.ReqReplyQName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "MQ_SendRequestReply_Queue", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ReqReplyQName.Location = New System.Drawing.Point(186, 22)
        Me.ReqReplyQName.Name = "ReqReplyQName"
        Me.ReqReplyQName.Size = New System.Drawing.Size(271, 20)
        Me.ReqReplyQName.TabIndex = 1
        Me.ReqReplyQName.Text = Global.MQTestClient.My.MySettings.Default.MQ_SendRequestReply_Queue
        '
        'GetRequestReplyTimeout
        '
        Me.GetRequestReplyTimeout.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "MQ_GetRequestReply_Timeout_Interval", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.GetRequestReplyTimeout.Location = New System.Drawing.Point(198, 59)
        Me.GetRequestReplyTimeout.Name = "GetRequestReplyTimeout"
        Me.GetRequestReplyTimeout.Size = New System.Drawing.Size(271, 20)
        Me.GetRequestReplyTimeout.TabIndex = 3
        Me.GetRequestReplyTimeout.Text = Global.MQTestClient.My.MySettings.Default.MQ_GetRequestReply_Timeout_Interval
        '
        'GetRequestQName
        '
        Me.GetRequestQName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "MQ_GetRequestReply_RequestQueue", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.GetRequestQName.Location = New System.Drawing.Point(198, 26)
        Me.GetRequestQName.Name = "GetRequestQName"
        Me.GetRequestQName.Size = New System.Drawing.Size(271, 20)
        Me.GetRequestQName.TabIndex = 1
        Me.GetRequestQName.Text = Global.MQTestClient.My.MySettings.Default.MQ_GetRequestReply_RequestQueue
        '
        'txtDatagramSend
        '
        Me.txtDatagramSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDatagramSend.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "Datagram_Send_Msgs", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtDatagramSend.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtDatagramSend.Location = New System.Drawing.Point(262, 29)
        Me.txtDatagramSend.MaxLength = 4
        Me.txtDatagramSend.Name = "txtDatagramSend"
        Me.txtDatagramSend.Size = New System.Drawing.Size(43, 20)
        Me.txtDatagramSend.TabIndex = 1
        Me.txtDatagramSend.Text = Global.MQTestClient.My.MySettings.Default.Datagram_Send_Msgs
        '
        'txtGetRequest
        '
        Me.txtGetRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGetRequest.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "Get_Request_Msgs", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtGetRequest.Location = New System.Drawing.Point(262, 146)
        Me.txtGetRequest.MaxLength = 4
        Me.txtGetRequest.Name = "txtGetRequest"
        Me.txtGetRequest.Size = New System.Drawing.Size(43, 20)
        Me.txtGetRequest.TabIndex = 7
        Me.txtGetRequest.Text = Global.MQTestClient.My.MySettings.Default.Get_Request_Msgs
        '
        'txtSendRequest
        '
        Me.txtSendRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSendRequest.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "Send_Request_Msgs", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtSendRequest.Location = New System.Drawing.Point(262, 103)
        Me.txtSendRequest.MaxLength = 4
        Me.txtSendRequest.Name = "txtSendRequest"
        Me.txtSendRequest.Size = New System.Drawing.Size(43, 20)
        Me.txtSendRequest.TabIndex = 5
        Me.txtSendRequest.Text = Global.MQTestClient.My.MySettings.Default.Send_Request_Msgs
        '
        'txtDataGramReceive
        '
        Me.txtDataGramReceive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDataGramReceive.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "Datagram_Receive_Msgs", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtDataGramReceive.Location = New System.Drawing.Point(262, 69)
        Me.txtDataGramReceive.MaxLength = 4
        Me.txtDataGramReceive.Name = "txtDataGramReceive"
        Me.txtDataGramReceive.Size = New System.Drawing.Size(43, 20)
        Me.txtDataGramReceive.TabIndex = 3
        Me.txtDataGramReceive.Text = Global.MQTestClient.My.MySettings.Default.Datagram_Receive_Msgs
        '
        'txtInvaidMsg
        '
        Me.txtInvaidMsg.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "InvalidMsg", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtInvaidMsg.Location = New System.Drawing.Point(194, 191)
        Me.txtInvaidMsg.Name = "txtInvaidMsg"
        Me.txtInvaidMsg.Size = New System.Drawing.Size(305, 20)
        Me.txtInvaidMsg.TabIndex = 13
        Me.txtInvaidMsg.Text = Global.MQTestClient.My.MySettings.Default.InvalidMsg
        '
        'chkValidateMsgFormat
        '
        Me.chkValidateMsgFormat.AutoSize = True
        Me.chkValidateMsgFormat.Checked = Global.MQTestClient.My.MySettings.Default.ValidateMsgFormat
        Me.chkValidateMsgFormat.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkValidateMsgFormat.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.MQTestClient.My.MySettings.Default, "ValidateMsgFormat", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkValidateMsgFormat.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkValidateMsgFormat.Location = New System.Drawing.Point(194, 121)
        Me.chkValidateMsgFormat.Name = "chkValidateMsgFormat"
        Me.chkValidateMsgFormat.Size = New System.Drawing.Size(151, 18)
        Me.chkValidateMsgFormat.TabIndex = 12
        Me.chkValidateMsgFormat.Text = "Validate Message Format"
        Me.chkValidateMsgFormat.UseVisualStyleBackColor = True
        '
        'txtTimer_Interval
        '
        Me.txtTimer_Interval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTimer_Interval.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.MQTestClient.My.MySettings.Default, "Timer_Interval", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtTimer_Interval.Location = New System.Drawing.Point(194, 156)
        Me.txtTimer_Interval.MaxLength = 4
        Me.txtTimer_Interval.Name = "txtTimer_Interval"
        Me.txtTimer_Interval.Size = New System.Drawing.Size(43, 20)
        Me.txtTimer_Interval.TabIndex = 10
        Me.txtTimer_Interval.Text = Global.MQTestClient.My.MySettings.Default.Timer_Interval
        '
        'chkEnableMQAppReply
        '
        Me.chkEnableMQAppReply.AutoSize = True
        Me.chkEnableMQAppReply.Checked = Global.MQTestClient.My.MySettings.Default.EnableMQAppReply
        Me.chkEnableMQAppReply.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEnableMQAppReply.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.MQTestClient.My.MySettings.Default, "EnableMQAppReply", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkEnableMQAppReply.Location = New System.Drawing.Point(194, 83)
        Me.chkEnableMQAppReply.Name = "chkEnableMQAppReply"
        Me.chkEnableMQAppReply.Size = New System.Drawing.Size(128, 17)
        Me.chkEnableMQAppReply.TabIndex = 2
        Me.chkEnableMQAppReply.Text = "Enable MQ AppReply"
        Me.chkEnableMQAppReply.UseVisualStyleBackColor = True
        '
        'chkEnableMQAppRequest
        '
        Me.chkEnableMQAppRequest.AutoSize = True
        Me.chkEnableMQAppRequest.Checked = Global.MQTestClient.My.MySettings.Default.EnableMQAppRequest
        Me.chkEnableMQAppRequest.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEnableMQAppRequest.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.MQTestClient.My.MySettings.Default, "EnableMQAppRequest", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkEnableMQAppRequest.Location = New System.Drawing.Point(194, 50)
        Me.chkEnableMQAppRequest.Name = "chkEnableMQAppRequest"
        Me.chkEnableMQAppRequest.Size = New System.Drawing.Size(141, 17)
        Me.chkEnableMQAppRequest.TabIndex = 1
        Me.chkEnableMQAppRequest.Text = "Enable MQ AppRequest"
        Me.chkEnableMQAppRequest.UseVisualStyleBackColor = True
        '
        'chkEnableMQAppStatus
        '
        Me.chkEnableMQAppStatus.AutoSize = True
        Me.chkEnableMQAppStatus.Checked = Global.MQTestClient.My.MySettings.Default.EnableMQAppStatus
        Me.chkEnableMQAppStatus.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEnableMQAppStatus.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.MQTestClient.My.MySettings.Default, "EnableMQAppStatus", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkEnableMQAppStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkEnableMQAppStatus.Location = New System.Drawing.Point(194, 17)
        Me.chkEnableMQAppStatus.Name = "chkEnableMQAppStatus"
        Me.chkEnableMQAppStatus.Size = New System.Drawing.Size(137, 18)
        Me.chkEnableMQAppStatus.TabIndex = 0
        Me.chkEnableMQAppStatus.Text = "Enable MQ AppStatus"
        Me.chkEnableMQAppStatus.UseVisualStyleBackColor = True
        '
        'SettingsForm
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(577, 322)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SettingsForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SettingsForm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        CType(Me.SettingsFormBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ReqReplyReplyQName As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ReqReplyTimeout As System.Windows.Forms.TextBox
    Friend WithEvents ReqReplyQName As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GetRequestQName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GetRequestReplyTimeout As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents MQQMgrName As System.Windows.Forms.TextBox
    Friend WithEvents MQQMgrPortNum As System.Windows.Forms.TextBox
    Friend WithEvents MQQMgrCustomChannel As System.Windows.Forms.TextBox
    Friend WithEvents MQQMgrHostName As System.Windows.Forms.TextBox
    Friend WithEvents DatagramSendTimeoutInt As System.Windows.Forms.TextBox
    Friend WithEvents DatagramSendQName As System.Windows.Forms.TextBox
    Friend WithEvents DatagramReceiveWaitInterval As System.Windows.Forms.TextBox
    Friend WithEvents DatagramReceiveQName As System.Windows.Forms.TextBox
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents txtDatagramSend As System.Windows.Forms.TextBox
    Friend WithEvents lblDatagramSend As System.Windows.Forms.Label
    Friend WithEvents txtGetRequest As System.Windows.Forms.TextBox
    Friend WithEvents lblGetRequest As System.Windows.Forms.Label
    Friend WithEvents txtSendRequest As System.Windows.Forms.TextBox
    Friend WithEvents lblSendRequest As System.Windows.Forms.Label
    Friend WithEvents txtDataGramReceive As System.Windows.Forms.TextBox
    Friend WithEvents lblDatagramReceive As System.Windows.Forms.Label
    Friend WithEvents SettingsFormBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents chkEnableMQAppStatus As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableMQAppReply As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableMQAppRequest As System.Windows.Forms.CheckBox
    Friend WithEvents lblTimerInterval As System.Windows.Forms.Label
    Friend WithEvents txtTimer_Interval As System.Windows.Forms.TextBox
    Friend WithEvents chkValidateMsgFormat As System.Windows.Forms.CheckBox
    Friend WithEvents lblInvalidMsg As System.Windows.Forms.Label
    Friend WithEvents txtInvaidMsg As System.Windows.Forms.TextBox
    Friend WithEvents txtSecurityExit As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label

End Class
