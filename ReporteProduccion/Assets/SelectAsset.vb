Public Class SelectAsset
    Dim dt As New DataTable
    Public returnRow() As DataRow

    Private Sub SelectAsset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dt = SQLCon.GetLineas
            ComboBox1.DataSource = dt.DefaultView
            ComboBox1.DisplayMember = "Name"
            ComboBox1.ValueMember = "ID"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        returnRow = dt.Select("ID=" & ComboBox1.SelectedValue.ToString)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class