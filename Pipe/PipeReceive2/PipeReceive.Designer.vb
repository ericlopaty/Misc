<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PipeReceive
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
        Me.btnStartReceive = New System.Windows.Forms.Button
        Me.tbData = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnStartReceive
        '
        Me.btnStartReceive.Location = New System.Drawing.Point(12, 12)
        Me.btnStartReceive.Name = "btnStartReceive"
        Me.btnStartReceive.Size = New System.Drawing.Size(270, 23)
        Me.btnStartReceive.TabIndex = 0
        Me.btnStartReceive.Text = "Start Receive"
        Me.btnStartReceive.UseVisualStyleBackColor = True
        '
        'tbData
        '
        Me.tbData.Location = New System.Drawing.Point(12, 41)
        Me.tbData.Name = "tbData"
        Me.tbData.Size = New System.Drawing.Size(270, 20)
        Me.tbData.TabIndex = 1
        '
        'PipeReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 238)
        Me.Controls.Add(Me.tbData)
        Me.Controls.Add(Me.btnStartReceive)
        Me.Name = "PipeReceive"
        Me.Text = "PipeReceive"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStartReceive As System.Windows.Forms.Button
    Friend WithEvents tbData As System.Windows.Forms.TextBox

End Class
