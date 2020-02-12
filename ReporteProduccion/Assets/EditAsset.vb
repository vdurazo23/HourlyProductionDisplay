Public Class EditAsset
    Public elid As Integer
    Private Sub EditAsset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargardatos()
    End Sub
    Sub cargardatos()
        Try
            Dim dt As DataTable = SQLCon.GetLineaByID(elid)
            GridAssets.DataSource = dt.DefaultView
            For i = 0 To GridAssets.Columns.Count - 1
                GridAssets.Columns(i).BestFit()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        SQLCon.EditAsset(elid, CheckBox1.Checked)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub RadButton2_Click(sender As Object, e As EventArgs) Handles RadButton2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class