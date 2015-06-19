<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Server
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
        Me.tbData = New System.Windows.Forms.TextBox
        Me.btnSetText = New System.Windows.Forms.Button
        Me.btnDirect = New System.Windows.Forms.Button
        Me.btnShowText = New System.Windows.Forms.Button
        Me.lblBefore = New System.Windows.Forms.Label
        Me.lblAfter = New System.Windows.Forms.Label
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'tbData
        '
        Me.tbData.Location = New System.Drawing.Point(12, 12)
        Me.tbData.Name = "tbData"
        Me.tbData.Size = New System.Drawing.Size(270, 20)
        Me.tbData.TabIndex = 1
        '
        'btnSetText
        '
        Me.btnSetText.Enabled = False
        Me.btnSetText.Location = New System.Drawing.Point(12, 96)
        Me.btnSetText.Name = "btnSetText"
        Me.btnSetText.Size = New System.Drawing.Size(75, 23)
        Me.btnSetText.TabIndex = 2
        Me.btnSetText.Text = "Set Text"
        Me.btnSetText.UseVisualStyleBackColor = True
        '
        'btnDirect
        '
        Me.btnDirect.Location = New System.Drawing.Point(12, 67)
        Me.btnDirect.Name = "btnDirect"
        Me.btnDirect.Size = New System.Drawing.Size(75, 23)
        Me.btnDirect.TabIndex = 4
        Me.btnDirect.Text = "Direct"
        Me.btnDirect.UseVisualStyleBackColor = True
        '
        'btnShowText
        '
        Me.btnShowText.Location = New System.Drawing.Point(12, 38)
        Me.btnShowText.Name = "btnShowText"
        Me.btnShowText.Size = New System.Drawing.Size(75, 23)
        Me.btnShowText.TabIndex = 5
        Me.btnShowText.Text = "Show Text"
        Me.btnShowText.UseVisualStyleBackColor = True
        '
        'lblBefore
        '
        Me.lblBefore.AutoSize = True
        Me.lblBefore.Location = New System.Drawing.Point(114, 47)
        Me.lblBefore.Name = "lblBefore"
        Me.lblBefore.Size = New System.Drawing.Size(38, 13)
        Me.lblBefore.TabIndex = 6
        Me.lblBefore.Text = "Before"
        '
        'lblAfter
        '
        Me.lblAfter.AutoSize = True
        Me.lblAfter.Location = New System.Drawing.Point(117, 76)
        Me.lblAfter.Name = "lblAfter"
        Me.lblAfter.Size = New System.Drawing.Size(29, 13)
        Me.lblAfter.TabIndex = 7
        Me.lblAfter.Text = "After"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 134)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 95)
        Me.ListBox1.TabIndex = 8
        '
        'Server
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 269)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.lblAfter)
        Me.Controls.Add(Me.lblBefore)
        Me.Controls.Add(Me.btnShowText)
        Me.Controls.Add(Me.btnDirect)
        Me.Controls.Add(Me.btnSetText)
        Me.Controls.Add(Me.tbData)
        Me.Name = "Server"
        Me.Text = "WCF Server"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbData As System.Windows.Forms.TextBox
    Friend WithEvents btnSetText As System.Windows.Forms.Button
    Friend WithEvents btnDirect As System.Windows.Forms.Button
    Friend WithEvents btnShowText As System.Windows.Forms.Button
    Friend WithEvents lblBefore As System.Windows.Forms.Label
    Friend WithEvents lblAfter As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox

End Class
