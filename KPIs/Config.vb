Public Class Config

    Private Sub Config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckBox1.Checked = My.Settings.RememberScreen
        CheckBox2.Checked = My.Settings.ShowStartup
        Label1.Text = My.Settings.ScreenNumber
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        My.Settings.RememberScreen = CheckBox1.Checked
        My.Settings.Save()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        My.Settings.ShowStartup = CheckBox2.Checked
        My.Settings.Save()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub
End Class