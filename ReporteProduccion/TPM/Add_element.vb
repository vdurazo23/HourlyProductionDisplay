Public Class Add_element
    Public texto As String
    Public ShowColor As Boolean = False
    Function Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ErrorProvider1.Clear()
        If TextBox1.Text.Trim = "" Then
            ErrorProvider1.SetError(TextBox1, "Requerido...!")
            Exit Function
        End If
        texto = TextBox1.Text
        Me.DialogResult = DialogResult.OK
        Return TextBox1.Text.Trim

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Enter Then
            Button1.PerformClick()
        End If
        If keyData = Keys.Escape Then
            Button2.PerformClick()
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub Add_element_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CboClas.SelectedIndex < 0 Then CboClas.SelectedIndex = 0
        LblClas.Visible = ShowColor
        CboClas.Visible = ShowColor
    End Sub
End Class