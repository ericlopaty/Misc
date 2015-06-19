<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.tbBefore = New System.Windows.Forms.TextBox
        Me.gridTest = New System.Windows.Forms.DataGridView
        Me.tbAfter = New System.Windows.Forms.TextBox
        Me.lbEvents = New System.Windows.Forms.ListBox
        Me.btnClear = New System.Windows.Forms.Button
        Me.column_first = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.column_second = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.column_third = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.gridTest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbBefore
        '
        Me.tbBefore.Location = New System.Drawing.Point(12, 12)
        Me.tbBefore.Name = "tbBefore"
        Me.tbBefore.Size = New System.Drawing.Size(100, 20)
        Me.tbBefore.TabIndex = 0
        '
        'gridTest
        '
        Me.gridTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridTest.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.column_first, Me.column_second, Me.column_third})
        Me.gridTest.Location = New System.Drawing.Point(12, 38)
        Me.gridTest.Name = "gridTest"
        Me.gridTest.Size = New System.Drawing.Size(366, 218)
        Me.gridTest.TabIndex = 1
        '
        'tbAfter
        '
        Me.tbAfter.Location = New System.Drawing.Point(12, 262)
        Me.tbAfter.Name = "tbAfter"
        Me.tbAfter.Size = New System.Drawing.Size(100, 20)
        Me.tbAfter.TabIndex = 2
        '
        'lbEvents
        '
        Me.lbEvents.FormattingEnabled = True
        Me.lbEvents.Location = New System.Drawing.Point(384, 12)
        Me.lbEvents.Name = "lbEvents"
        Me.lbEvents.Size = New System.Drawing.Size(386, 472)
        Me.lbEvents.TabIndex = 3
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(206, 461)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(102, 23)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear Events"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'column_first
        '
        Me.column_first.HeaderText = "First"
        Me.column_first.Name = "column_first"
        '
        'column_second
        '
        Me.column_second.HeaderText = "Second"
        Me.column_second.Items.AddRange(New Object() {"One", "Two", "Three", "Four", "Five"})
        Me.column_second.Name = "column_second"
        '
        'column_third
        '
        Me.column_third.HeaderText = "Third"
        Me.column_third.Name = "column_third"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 501)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.lbEvents)
        Me.Controls.Add(Me.tbAfter)
        Me.Controls.Add(Me.gridTest)
        Me.Controls.Add(Me.tbBefore)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.gridTest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbBefore As System.Windows.Forms.TextBox
    Friend WithEvents gridTest As System.Windows.Forms.DataGridView
    Friend WithEvents tbAfter As System.Windows.Forms.TextBox
    Friend WithEvents lbEvents As System.Windows.Forms.ListBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents column_first As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents column_second As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents column_third As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
