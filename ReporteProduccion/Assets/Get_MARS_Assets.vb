Public Class Get_MARS_Assets

    Private Sub Get_MARS_Assets_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub Get_MARS_Assets_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub Get_MARS_Assets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RadGridView1.DataSource = SQLCon.GetMARSAssets.DefaultView
            For i = 0 To RadGridView1.Columns.Count - 1
                RadGridView1.Columns(i).BestFit()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub RadGridView1_CellDoubleClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles RadGridView1.CellDoubleClick
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub RadGridView1_Click(sender As Object, e As EventArgs) Handles RadGridView1.Click

    End Sub
End Class