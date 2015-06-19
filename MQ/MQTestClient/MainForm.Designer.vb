<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.ButtonMQCmd = New System.Windows.Forms.Button
        Me.ButtonSettings = New System.Windows.Forms.Button
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.Status = New System.Windows.Forms.ToolStripStatusLabel
        Me.MsgType = New System.Windows.Forms.ToolStripStatusLabel
        Me.LastDateTime = New System.Windows.Forms.ToolStripStatusLabel
        Me.ButtonCopyClipBrd = New System.Windows.Forms.Button
        Me.MQTabControl = New System.Windows.Forms.TabControl
        Me.TabPageDatagramSend = New System.Windows.Forms.TabPage
        Me.TextBoxDatagramSend = New System.Windows.Forms.TextBox
        Me.TabPageDatagramReceive = New System.Windows.Forms.TabPage
        Me.TextBoxDatagramReceive = New System.Windows.Forms.TextBox
        Me.TabPageSendReqWaitReply = New System.Windows.Forms.TabPage
        Me.SplitContainerSendReqReply = New System.Windows.Forms.SplitContainer
        Me.TextBoxRequestSend = New System.Windows.Forms.TextBox
        Me.TextBoxRequestReply = New System.Windows.Forms.TextBox
        Me.TabPageGetRequestSendReply = New System.Windows.Forms.TabPage
        Me.SplitContainerGetReqReply = New System.Windows.Forms.SplitContainer
        Me.TextBoxReceiveRequest = New System.Windows.Forms.TextBox
        Me.TextBoxSendReply = New System.Windows.Forms.TextBox
        Me.tabSimulateErrors = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblQueueName = New System.Windows.Forms.Label
        Me.txtQueueName = New System.Windows.Forms.TextBox
        Me.cmdProceed = New System.Windows.Forms.Button
        Me.chkMQRC_Q_FULL = New System.Windows.Forms.CheckBox
        Me.chkMQRC_GET_INHIBITED = New System.Windows.Forms.CheckBox
        Me.chkMQRC_PUT_INHIBITED = New System.Windows.Forms.CheckBox
        Me.ButtonMQCmd2 = New System.Windows.Forms.Button
        Me.tmrTestApp = New System.Windows.Forms.Timer(Me.components)
        Me.btnStartTimer = New System.Windows.Forms.Button
        Me.btnStopTimer = New System.Windows.Forms.Button
        Me.StatusStrip.SuspendLayout()
        Me.MQTabControl.SuspendLayout()
        Me.TabPageDatagramSend.SuspendLayout()
        Me.TabPageDatagramReceive.SuspendLayout()
        Me.TabPageSendReqWaitReply.SuspendLayout()
        Me.SplitContainerSendReqReply.Panel1.SuspendLayout()
        Me.SplitContainerSendReqReply.Panel2.SuspendLayout()
        Me.SplitContainerSendReqReply.SuspendLayout()
        Me.TabPageGetRequestSendReply.SuspendLayout()
        Me.SplitContainerGetReqReply.Panel1.SuspendLayout()
        Me.SplitContainerGetReqReply.Panel2.SuspendLayout()
        Me.SplitContainerGetReqReply.SuspendLayout()
        Me.tabSimulateErrors.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonMQCmd
        '
        Me.ButtonMQCmd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonMQCmd.AutoSize = True
        Me.ButtonMQCmd.Location = New System.Drawing.Point(0, 377)
        Me.ButtonMQCmd.Name = "ButtonMQCmd"
        Me.ButtonMQCmd.Size = New System.Drawing.Size(140, 23)
        Me.ButtonMQCmd.TabIndex = 1
        Me.ButtonMQCmd.Text = "Command"
        Me.ButtonMQCmd.UseVisualStyleBackColor = True
        '
        'ButtonSettings
        '
        Me.ButtonSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonSettings.Location = New System.Drawing.Point(305, 377)
        Me.ButtonSettings.MinimumSize = New System.Drawing.Size(75, 15)
        Me.ButtonSettings.Name = "ButtonSettings"
        Me.ButtonSettings.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSettings.TabIndex = 2
        Me.ButtonSettings.Text = "Settings"
        Me.ButtonSettings.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Status, Me.MsgType, Me.LastDateTime})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 409)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(752, 22)
        Me.StatusStrip.TabIndex = 3
        Me.StatusStrip.Text = "StatusStrip"
        '
        'Status
        '
        Me.Status.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.Status.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(567, 17)
        Me.Status.Spring = True
        Me.Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MsgType
        '
        Me.MsgType.AutoSize = False
        Me.MsgType.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.MsgType.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.MsgType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.MsgType.Name = "MsgType"
        Me.MsgType.Size = New System.Drawing.Size(80, 17)
        Me.MsgType.ToolTipText = "Message type of message last sent/received"
        '
        'LastDateTime
        '
        Me.LastDateTime.AutoSize = False
        Me.LastDateTime.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.LastDateTime.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.LastDateTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LastDateTime.Name = "LastDateTime"
        Me.LastDateTime.Size = New System.Drawing.Size(90, 17)
        Me.LastDateTime.ToolTipText = "Time last operation attempted"
        '
        'ButtonCopyClipBrd
        '
        Me.ButtonCopyClipBrd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonCopyClipBrd.AutoSize = True
        Me.ButtonCopyClipBrd.Location = New System.Drawing.Point(548, 377)
        Me.ButtonCopyClipBrd.Name = "ButtonCopyClipBrd"
        Me.ButtonCopyClipBrd.Size = New System.Drawing.Size(149, 24)
        Me.ButtonCopyClipBrd.TabIndex = 4
        Me.ButtonCopyClipBrd.Text = "Copy Message to Clipboard"
        Me.ButtonCopyClipBrd.UseVisualStyleBackColor = True
        '
        'MQTabControl
        '
        Me.MQTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MQTabControl.Controls.Add(Me.TabPageDatagramSend)
        Me.MQTabControl.Controls.Add(Me.TabPageDatagramReceive)
        Me.MQTabControl.Controls.Add(Me.TabPageSendReqWaitReply)
        Me.MQTabControl.Controls.Add(Me.TabPageGetRequestSendReply)
        Me.MQTabControl.Controls.Add(Me.tabSimulateErrors)
        Me.MQTabControl.Location = New System.Drawing.Point(0, 12)
        Me.MQTabControl.Name = "MQTabControl"
        Me.MQTabControl.SelectedIndex = 0
        Me.MQTabControl.Size = New System.Drawing.Size(740, 344)
        Me.MQTabControl.TabIndex = 5
        '
        'TabPageDatagramSend
        '
        Me.TabPageDatagramSend.Controls.Add(Me.TextBoxDatagramSend)
        Me.TabPageDatagramSend.Location = New System.Drawing.Point(4, 22)
        Me.TabPageDatagramSend.Name = "TabPageDatagramSend"
        Me.TabPageDatagramSend.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDatagramSend.Size = New System.Drawing.Size(732, 318)
        Me.TabPageDatagramSend.TabIndex = 1
        Me.TabPageDatagramSend.Text = "Datagram Send"
        Me.TabPageDatagramSend.UseVisualStyleBackColor = True
        '
        'TextBoxDatagramSend
        '
        Me.TextBoxDatagramSend.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDatagramSend.Location = New System.Drawing.Point(3, 3)
        Me.TextBoxDatagramSend.Multiline = True
        Me.TextBoxDatagramSend.Name = "TextBoxDatagramSend"
        Me.TextBoxDatagramSend.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxDatagramSend.Size = New System.Drawing.Size(726, 312)
        Me.TextBoxDatagramSend.TabIndex = 2
        '
        'TabPageDatagramReceive
        '
        Me.TabPageDatagramReceive.Controls.Add(Me.TextBoxDatagramReceive)
        Me.TabPageDatagramReceive.Location = New System.Drawing.Point(4, 22)
        Me.TabPageDatagramReceive.Name = "TabPageDatagramReceive"
        Me.TabPageDatagramReceive.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDatagramReceive.Size = New System.Drawing.Size(732, 318)
        Me.TabPageDatagramReceive.TabIndex = 0
        Me.TabPageDatagramReceive.Text = "Datagram Receive"
        Me.TabPageDatagramReceive.UseVisualStyleBackColor = True
        '
        'TextBoxDatagramReceive
        '
        Me.TextBoxDatagramReceive.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxDatagramReceive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDatagramReceive.Location = New System.Drawing.Point(3, 3)
        Me.TextBoxDatagramReceive.Multiline = True
        Me.TextBoxDatagramReceive.Name = "TextBoxDatagramReceive"
        Me.TextBoxDatagramReceive.ReadOnly = True
        Me.TextBoxDatagramReceive.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxDatagramReceive.Size = New System.Drawing.Size(726, 312)
        Me.TextBoxDatagramReceive.TabIndex = 1
        '
        'TabPageSendReqWaitReply
        '
        Me.TabPageSendReqWaitReply.Controls.Add(Me.SplitContainerSendReqReply)
        Me.TabPageSendReqWaitReply.Location = New System.Drawing.Point(4, 22)
        Me.TabPageSendReqWaitReply.Name = "TabPageSendReqWaitReply"
        Me.TabPageSendReqWaitReply.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageSendReqWaitReply.Size = New System.Drawing.Size(732, 318)
        Me.TabPageSendReqWaitReply.TabIndex = 2
        Me.TabPageSendReqWaitReply.Text = "Send Request/Wait Reply"
        Me.TabPageSendReqWaitReply.UseVisualStyleBackColor = True
        '
        'SplitContainerSendReqReply
        '
        Me.SplitContainerSendReqReply.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerSendReqReply.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainerSendReqReply.Name = "SplitContainerSendReqReply"
        '
        'SplitContainerSendReqReply.Panel1
        '
        Me.SplitContainerSendReqReply.Panel1.Controls.Add(Me.TextBoxRequestSend)
        '
        'SplitContainerSendReqReply.Panel2
        '
        Me.SplitContainerSendReqReply.Panel2.Controls.Add(Me.TextBoxRequestReply)
        Me.SplitContainerSendReqReply.Size = New System.Drawing.Size(726, 312)
        Me.SplitContainerSendReqReply.SplitterDistance = 342
        Me.SplitContainerSendReqReply.TabIndex = 0
        '
        'TextBoxRequestSend
        '
        Me.TextBoxRequestSend.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxRequestSend.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxRequestSend.Multiline = True
        Me.TextBoxRequestSend.Name = "TextBoxRequestSend"
        Me.TextBoxRequestSend.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxRequestSend.Size = New System.Drawing.Size(342, 312)
        Me.TextBoxRequestSend.TabIndex = 3
        '
        'TextBoxRequestReply
        '
        Me.TextBoxRequestReply.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxRequestReply.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxRequestReply.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxRequestReply.Multiline = True
        Me.TextBoxRequestReply.Name = "TextBoxRequestReply"
        Me.TextBoxRequestReply.ReadOnly = True
        Me.TextBoxRequestReply.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxRequestReply.Size = New System.Drawing.Size(380, 312)
        Me.TextBoxRequestReply.TabIndex = 3
        '
        'TabPageGetRequestSendReply
        '
        Me.TabPageGetRequestSendReply.Controls.Add(Me.SplitContainerGetReqReply)
        Me.TabPageGetRequestSendReply.Location = New System.Drawing.Point(4, 22)
        Me.TabPageGetRequestSendReply.Name = "TabPageGetRequestSendReply"
        Me.TabPageGetRequestSendReply.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageGetRequestSendReply.Size = New System.Drawing.Size(732, 318)
        Me.TabPageGetRequestSendReply.TabIndex = 3
        Me.TabPageGetRequestSendReply.Text = "Get Request/Send Reply"
        Me.TabPageGetRequestSendReply.UseVisualStyleBackColor = True
        '
        'SplitContainerGetReqReply
        '
        Me.SplitContainerGetReqReply.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerGetReqReply.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainerGetReqReply.Name = "SplitContainerGetReqReply"
        '
        'SplitContainerGetReqReply.Panel1
        '
        Me.SplitContainerGetReqReply.Panel1.Controls.Add(Me.TextBoxReceiveRequest)
        '
        'SplitContainerGetReqReply.Panel2
        '
        Me.SplitContainerGetReqReply.Panel2.Controls.Add(Me.TextBoxSendReply)
        Me.SplitContainerGetReqReply.Size = New System.Drawing.Size(726, 312)
        Me.SplitContainerGetReqReply.SplitterDistance = 342
        Me.SplitContainerGetReqReply.TabIndex = 0
        '
        'TextBoxReceiveRequest
        '
        Me.TextBoxReceiveRequest.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxReceiveRequest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxReceiveRequest.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxReceiveRequest.Multiline = True
        Me.TextBoxReceiveRequest.Name = "TextBoxReceiveRequest"
        Me.TextBoxReceiveRequest.ReadOnly = True
        Me.TextBoxReceiveRequest.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxReceiveRequest.Size = New System.Drawing.Size(342, 312)
        Me.TextBoxReceiveRequest.TabIndex = 4
        '
        'TextBoxSendReply
        '
        Me.TextBoxSendReply.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxSendReply.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxSendReply.Multiline = True
        Me.TextBoxSendReply.Name = "TextBoxSendReply"
        Me.TextBoxSendReply.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxSendReply.Size = New System.Drawing.Size(380, 312)
        Me.TextBoxSendReply.TabIndex = 5
        '
        'tabSimulateErrors
        '
        Me.tabSimulateErrors.Controls.Add(Me.GroupBox1)
        Me.tabSimulateErrors.Location = New System.Drawing.Point(4, 22)
        Me.tabSimulateErrors.Name = "tabSimulateErrors"
        Me.tabSimulateErrors.Size = New System.Drawing.Size(732, 318)
        Me.tabSimulateErrors.TabIndex = 4
        Me.tabSimulateErrors.Text = "Simulate MQ Errors"
        Me.tabSimulateErrors.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblQueueName)
        Me.GroupBox1.Controls.Add(Me.txtQueueName)
        Me.GroupBox1.Controls.Add(Me.cmdProceed)
        Me.GroupBox1.Controls.Add(Me.chkMQRC_Q_FULL)
        Me.GroupBox1.Controls.Add(Me.chkMQRC_GET_INHIBITED)
        Me.GroupBox1.Controls.Add(Me.chkMQRC_PUT_INHIBITED)
        Me.GroupBox1.Location = New System.Drawing.Point(177, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(345, 234)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Simulate MQ Errors"
        '
        'lblQueueName
        '
        Me.lblQueueName.AutoSize = True
        Me.lblQueueName.Location = New System.Drawing.Point(23, 65)
        Me.lblQueueName.Name = "lblQueueName"
        Me.lblQueueName.Size = New System.Drawing.Size(76, 13)
        Me.lblQueueName.TabIndex = 11
        Me.lblQueueName.Text = "Queue Name :"
        '
        'txtQueueName
        '
        Me.txtQueueName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQueueName.Location = New System.Drawing.Point(105, 62)
        Me.txtQueueName.Name = "txtQueueName"
        Me.txtQueueName.Size = New System.Drawing.Size(128, 20)
        Me.txtQueueName.TabIndex = 10
        '
        'cmdProceed
        '
        Me.cmdProceed.Location = New System.Drawing.Point(105, 170)
        Me.cmdProceed.Name = "cmdProceed"
        Me.cmdProceed.Size = New System.Drawing.Size(104, 32)
        Me.cmdProceed.TabIndex = 9
        Me.cmdProceed.Text = "Proceed"
        Me.cmdProceed.UseVisualStyleBackColor = True
        '
        'chkMQRC_Q_FULL
        '
        Me.chkMQRC_Q_FULL.AutoSize = True
        Me.chkMQRC_Q_FULL.Location = New System.Drawing.Point(105, 134)
        Me.chkMQRC_Q_FULL.Name = "chkMQRC_Q_FULL"
        Me.chkMQRC_Q_FULL.Size = New System.Drawing.Size(104, 17)
        Me.chkMQRC_Q_FULL.TabIndex = 8
        Me.chkMQRC_Q_FULL.Text = "MQRC_Q_FULL"
        Me.chkMQRC_Q_FULL.UseVisualStyleBackColor = True
        '
        'chkMQRC_GET_INHIBITED
        '
        Me.chkMQRC_GET_INHIBITED.AutoSize = True
        Me.chkMQRC_GET_INHIBITED.Location = New System.Drawing.Point(105, 111)
        Me.chkMQRC_GET_INHIBITED.Name = "chkMQRC_GET_INHIBITED"
        Me.chkMQRC_GET_INHIBITED.Size = New System.Drawing.Size(146, 17)
        Me.chkMQRC_GET_INHIBITED.TabIndex = 6
        Me.chkMQRC_GET_INHIBITED.Text = "MQRC_GET_INHIBITED"
        Me.chkMQRC_GET_INHIBITED.UseVisualStyleBackColor = True
        '
        'chkMQRC_PUT_INHIBITED
        '
        Me.chkMQRC_PUT_INHIBITED.AutoSize = True
        Me.chkMQRC_PUT_INHIBITED.Location = New System.Drawing.Point(105, 88)
        Me.chkMQRC_PUT_INHIBITED.Name = "chkMQRC_PUT_INHIBITED"
        Me.chkMQRC_PUT_INHIBITED.Size = New System.Drawing.Size(146, 17)
        Me.chkMQRC_PUT_INHIBITED.TabIndex = 5
        Me.chkMQRC_PUT_INHIBITED.Text = "MQRC_PUT_INHIBITED"
        Me.chkMQRC_PUT_INHIBITED.UseVisualStyleBackColor = True
        '
        'ButtonMQCmd2
        '
        Me.ButtonMQCmd2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonMQCmd2.AutoSize = True
        Me.ButtonMQCmd2.Location = New System.Drawing.Point(158, 377)
        Me.ButtonMQCmd2.Name = "ButtonMQCmd2"
        Me.ButtonMQCmd2.Size = New System.Drawing.Size(122, 23)
        Me.ButtonMQCmd2.TabIndex = 6
        Me.ButtonMQCmd2.Text = "Command"
        Me.ButtonMQCmd2.UseVisualStyleBackColor = True
        Me.ButtonMQCmd2.Visible = False
        '
        'tmrTestApp
        '
        '
        'btnStartTimer
        '
        Me.btnStartTimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnStartTimer.Location = New System.Drawing.Point(386, 377)
        Me.btnStartTimer.MinimumSize = New System.Drawing.Size(75, 15)
        Me.btnStartTimer.Name = "btnStartTimer"
        Me.btnStartTimer.Size = New System.Drawing.Size(75, 23)
        Me.btnStartTimer.TabIndex = 7
        Me.btnStartTimer.Text = "Start Timer"
        Me.btnStartTimer.UseVisualStyleBackColor = True
        '
        'btnStopTimer
        '
        Me.btnStopTimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnStopTimer.Enabled = False
        Me.btnStopTimer.Location = New System.Drawing.Point(467, 378)
        Me.btnStopTimer.MinimumSize = New System.Drawing.Size(75, 15)
        Me.btnStopTimer.Name = "btnStopTimer"
        Me.btnStopTimer.Size = New System.Drawing.Size(75, 23)
        Me.btnStopTimer.TabIndex = 8
        Me.btnStopTimer.Text = "Stop Timer"
        Me.btnStopTimer.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 431)
        Me.Controls.Add(Me.btnStopTimer)
        Me.Controls.Add(Me.btnStartTimer)
        Me.Controls.Add(Me.ButtonMQCmd2)
        Me.Controls.Add(Me.MQTabControl)
        Me.Controls.Add(Me.ButtonCopyClipBrd)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.ButtonSettings)
        Me.Controls.Add(Me.ButtonMQCmd)
        Me.MinimumSize = New System.Drawing.Size(544, 200)
        Me.Name = "MainForm"
        Me.Text = "MQ Test Application"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MQTabControl.ResumeLayout(False)
        Me.TabPageDatagramSend.ResumeLayout(False)
        Me.TabPageDatagramSend.PerformLayout()
        Me.TabPageDatagramReceive.ResumeLayout(False)
        Me.TabPageDatagramReceive.PerformLayout()
        Me.TabPageSendReqWaitReply.ResumeLayout(False)
        Me.SplitContainerSendReqReply.Panel1.ResumeLayout(False)
        Me.SplitContainerSendReqReply.Panel1.PerformLayout()
        Me.SplitContainerSendReqReply.Panel2.ResumeLayout(False)
        Me.SplitContainerSendReqReply.Panel2.PerformLayout()
        Me.SplitContainerSendReqReply.ResumeLayout(False)
        Me.TabPageGetRequestSendReply.ResumeLayout(False)
        Me.SplitContainerGetReqReply.Panel1.ResumeLayout(False)
        Me.SplitContainerGetReqReply.Panel1.PerformLayout()
        Me.SplitContainerGetReqReply.Panel2.ResumeLayout(False)
        Me.SplitContainerGetReqReply.Panel2.PerformLayout()
        Me.SplitContainerGetReqReply.ResumeLayout(False)
        Me.tabSimulateErrors.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonMQCmd As System.Windows.Forms.Button
    Friend WithEvents ButtonSettings As System.Windows.Forms.Button
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MsgType As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ButtonCopyClipBrd As System.Windows.Forms.Button
    Friend WithEvents LastDateTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MQTabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPageDatagramReceive As System.Windows.Forms.TabPage
    Friend WithEvents TabPageDatagramSend As System.Windows.Forms.TabPage
    Friend WithEvents TabPageSendReqWaitReply As System.Windows.Forms.TabPage
    Friend WithEvents TextBoxDatagramReceive As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDatagramSend As System.Windows.Forms.TextBox
    Friend WithEvents TabPageGetRequestSendReply As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainerSendReqReply As System.Windows.Forms.SplitContainer
    Friend WithEvents TextBoxRequestSend As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxRequestReply As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainerGetReqReply As System.Windows.Forms.SplitContainer
    Friend WithEvents TextBoxReceiveRequest As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxSendReply As System.Windows.Forms.TextBox
    Friend WithEvents ButtonMQCmd2 As System.Windows.Forms.Button
    Friend WithEvents tabSimulateErrors As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdProceed As System.Windows.Forms.Button
    Friend WithEvents chkMQRC_Q_FULL As System.Windows.Forms.CheckBox
    Friend WithEvents chkMQRC_GET_INHIBITED As System.Windows.Forms.CheckBox
    Friend WithEvents chkMQRC_PUT_INHIBITED As System.Windows.Forms.CheckBox
    Friend WithEvents lblQueueName As System.Windows.Forms.Label
    Friend WithEvents txtQueueName As System.Windows.Forms.TextBox
    Friend WithEvents tmrTestApp As System.Windows.Forms.Timer
    Friend WithEvents btnStartTimer As System.Windows.Forms.Button
    Friend WithEvents btnStopTimer As System.Windows.Forms.Button


End Class
