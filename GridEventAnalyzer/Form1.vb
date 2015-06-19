Public Class Form1

    Dim msg As String

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        lbEvents.Items.Clear()
    End Sub

    Private Sub gridTest_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridTest.Enter
        Try
            If gridTest.CurrentCell IsNot Nothing Then
                msg = String.Format("Enter: Row {0} Col {1}", gridTest.CurrentCell.RowIndex, gridTest.CurrentCell.ColumnIndex)
            Else
                msg = String.Format("Enter")
            End If
            lbEvents.Items.Insert(0, msg)
        Catch ex As Exception
            lbEvents.Items.Insert(0, ex.Message)
        End Try
    End Sub

    Private Sub gridTest_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gridTest.CellBeginEdit
        Try
            msg = String.Format("CellBeginEdit: Row {0} Col {1}", e.RowIndex, e.ColumnIndex)
            lbEvents.Items.Insert(0, msg)
        Catch ex As Exception
            lbEvents.Items.Insert(0, ex.Message)
        End Try
    End Sub

    Private Sub gridTest_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridTest.CellClick
        'Try
        '    msg = String.Format("CellClick: Row {0} Col {1}", e.RowIndex, e.ColumnIndex)
        '    lbEvents.Items.Insert(0, msg)
        'Catch ex As Exception
        '    lbEvents.Items.Insert(0, ex.Message)
        'End Try
    End Sub

    Private Sub gridTest_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridTest.CellEndEdit
        Try
            msg = String.Format("CellEndEdit: Row {0} Col {1}", e.RowIndex, e.ColumnIndex)
            lbEvents.Items.Insert(0, msg)
        Catch ex As Exception
            lbEvents.Items.Insert(0, ex.Message)
        End Try
    End Sub

    Private Sub gridTest_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridTest.CellEnter
        'Try
        '    msg = String.Format("CellEnter: Row {0} Col {1}", e.RowIndex, e.ColumnIndex)
        '    lbEvents.Items.Insert(0, msg)
        'Catch ex As Exception
        '    lbEvents.Items.Insert(0, ex.Message)
        'End Try
    End Sub

    Private Sub gridTest_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridTest.CellValidating
        Try
            msg = String.Format("CellValidating: Row {0} Col {1} Value {2} Old {3}", e.RowIndex, e.ColumnIndex, e.FormattedValue, gridTest.CurrentCell.Value)
            If e.FormattedValue.ToString().Length > 10 Then
                gridTest.CurrentCell.Value=e.
                e.Cancel = True
            End If
            lbEvents.Items.Insert(0, msg)
        Catch ex As Exception
            lbEvents.Items.Insert(0, ex.Message)
        End Try
    End Sub

    Private Sub gridTest_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridTest.CellValueChanged
        Try
            msg = String.Format("CellValueChanged: Row {0} Col {1} Value {2}", e.RowIndex, e.ColumnIndex, gridTest.CurrentCell.Value)
            'gridTest.Item(e.ColumnIndex, e.RowIndex).Value = "FUBAR"
            lbEvents.Items.Insert(0, msg)
        Catch ex As Exception
            lbEvents.Items.Insert(0, ex.Message)
        End Try
    End Sub

    Private Sub gridTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridTest.Click
        'Try
        '    msg = String.Format("Click")
        '    lbEvents.Items.Insert(0, msg)
        'Catch ex As Exception
        '    lbEvents.Items.Insert(0, ex.Message)
        'End Try
    End Sub

    Private Sub gridTest_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridTest.CellValidated
        Try
            msg = String.Format("CellValidated: Row {0} Col {1}", e.RowIndex, e.ColumnIndex)
            lbEvents.Items.Insert(0, msg)
        Catch ex As Exception
            lbEvents.Items.Insert(0, ex.Message)
        End Try
    End Sub

    Private Sub gridTest_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridTest.KeyDown
        'Try
        '    msg = String.Format("KeyDown: KeyCode {0} KeyValue {1} KeyData {2} Shift {3} Ctrl {4} Alt {5} ", e.KeyCode, e.KeyValue, e.KeyData, e.Shift, e.Control, e.Alt)
        '    lbEvents.Items.Insert(0, msg)
        'Catch ex As Exception
        '    lbEvents.Items.Insert(0, ex.Message)
        'End Try
    End Sub

    Private Sub gridTest_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridTest.KeyPress
        'Try
        '    msg = String.Format("KeyPress: KeyChar {0}", e.KeyChar)
        '    lbEvents.Items.Insert(0, msg)
        'Catch ex As Exception
        '    lbEvents.Items.Insert(0, ex.Message)
        'End Try
    End Sub

End Class
