Public Class SubResourceCMS
    Public edit As Boolean = False
    Function validar() As Boolean
        ErrorProvider1.Clear()

        If TxtName.Text.Trim = "" Then
            ErrorProvider1.SetError(TxtName, "Required!")
            Return False
        End If
        If TxtDesc.Text.Trim = "" Then
            ErrorProvider1.SetError(TxtDesc, "Required!")
            Return False
        End If

        If TxtDevice.Text.Trim = "" Then
            ErrorProvider1.SetError(TxtDevice, "Required!")
            Return False
        End If

        If TxtDepartment.Text.Trim = "" Then
            ErrorProvider1.SetError(TxtDepartment, "Required!")
            Return False
        End If

        Return True
    End Function

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub SubResourceCMS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class