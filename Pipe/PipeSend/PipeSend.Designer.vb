<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PipeSend
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
        Me.btnSendData = New System.Windows.Forms.Button
        Me.btnStartThread = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnSendData
        '
        Me.btnSendData.Location = New System.Drawing.Point(12, 41)
        Me.btnSendData.Name = "btnSendData"
        Me.btnSendData.Size = New System.Drawing.Size(268, 23)
        Me.btnSendData.TabIndex = 1
        Me.btnSendData.Text = "Send Data"
        Me.btnSendData.UseVisualStyleBackColor = True
        '
        'btnStartThread
        '
        Me.btnStartThread.Location = New System.Drawing.Point(12, 12)
        Me.btnStartThread.Name = "btnStartThread"
        Me.btnStartThread.Size = New System.Drawing.Size(268, 23)
        Me.btnStartThread.TabIndex = 2
        Me.btnStartThread.Text = "Start Thread"
        Me.btnStartThread.UseVisualStyleBackColor = True
        '
        'PipeSend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 197)
        Me.Controls.Add(Me.btnStartThread)
        Me.Controls.Add(Me.btnSendData)
        Me.Name = "PipeSend"
        Me.Text = "PipeSend"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSendData As System.Windows.Forms.Button
    Friend WithEvents btnStartThread As System.Windows.Forms.Button

End Class
