Public Class Add_category
    Private Sub Add_category_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim s As DataTable
            s = SQLCon.TPMcategories
            ComboBox1.DataSource = s
            ComboBox1.ValueMember = "ID"
            ComboBox1.DisplayMember = "Categoria"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedIndex <> -1 And TextBox1.Text.Trim <> "" Then
            Me.DialogResult = DialogResult.OK
        Else
            MsgBox("Llene correctamente los datos solicitados", MsgBoxStyle.Critical)

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class