Public Class BuscarCodigo
    Dim dtCodes As DataTable

    Private Sub BuscarCodigo_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                If GridProduction.Rows.Count > 0 Then Me.DialogResult = Windows.Forms.DialogResult.OK
            Case Keys.Escape
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Case Keys.Back
                txtcomments.Focus()

            Case Else
        End Select
    End Sub
    Private Sub BuscarCodigo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtCodes = SQLCon.GetDowntimeCodesBis
            GridProduction.DataSource = dtCodes.DefaultView
            GridProduction.Visible = True

            GridProduction.Columns("ID").IsVisible = False
            GridProduction.Columns("Department_ID").IsVisible = False
            GridProduction.Columns("Concept_ID").IsVisible = False

            For i = 0 To GridProduction.Columns.Count - 1
                GridProduction.Columns(i).BestFit()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub txtcomments_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcomments.KeyDown
       
    End Sub

    Private Sub txtcomments_KeyUp(sender As Object, e As KeyEventArgs) Handles txtcomments.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                If GridProduction.Rows.Count > 0 Then Me.DialogResult = Windows.Forms.DialogResult.OK
            Case Keys.Escape
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Case Keys.Down
                GridProduction.Focus()

            Case Else
        End Select
    End Sub

    Private Sub txtcomments_TextChanged(sender As Object, e As EventArgs) Handles txtcomments.TextChanged
        Try
            If txtcomments.Text = "" Then
                dtCodes.DefaultView.RowFilter = ""
            Else
                dtCodes.DefaultView.RowFilter = "Description like '%" & txtcomments.Text & "%'"
            End If
        Catch ex As Exception
            Console.Write(ex.Message)
        End Try

    End Sub

    Private Sub GridProduction_CellDoubleClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles GridProduction.CellDoubleClick
        If Not GridProduction.CurrentCell Is Nothing Then Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub GridProduction_Click(sender As Object, e As EventArgs) Handles GridProduction.Click

    End Sub
End Class