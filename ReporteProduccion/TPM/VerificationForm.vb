Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Public Class VerificationForm

    Public Data As AppData
    Dim intentos As Integer = 0
    Public escomedor As Boolean = False
    Public conf As Boolean = False
    Public numemp As String

    Sub New(ByVal data As AppData)
        InitializeComponent()
        Me.Data = data
    End Sub
    Sub OnComplete(ByVal Control As Object, ByVal FeatureSet As DPFP.FeatureSet, ByRef EventHandlerStatus As DPFP.Gui.EventHandlerStatus) Handles VerificationControl.OnComplete
        Dim ver As New DPFP.Verification.Verification()
        Dim res As New DPFP.Verification.Verification.Result()

        For Each template As DPFP.Template In Data.Templates
            If Not template Is Nothing Then
                ver.Verify(FeatureSet, template, res)
                Data.IsFeatureSetMatched = res.Verified
                Data.FalseAcceptRate = res.FARAchieved
                If res.Verified Then
                    EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Success
                    Me.DialogResult = DialogResult.OK
                    Exit For
                End If
            End If
        Next

        If Not res.Verified Then EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Failure
        intentos += 1

        BtnIntentos.Text = "Tiene " & (3 - intentos).ToString & " intentos disponibles"
        If intentos = 3 And Not res.Verified Then
            If Not escomedor Then
                MsgBox("No se pudo comprobar la huella", MsgBoxStyle.Exclamation, "Huella")
            End If
            Me.DialogResult = DialogResult.Cancel
        End If
        Data.Update()

    End Sub

    Private Sub VerificationForm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

    End Sub

    Private Sub VerificationForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        intentos = 0
        BtnIntentos.Text = "Tiene 3 intentos disponibles"

    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub ButtonX3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnCancelar.KeyUp

    End Sub
    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIntentos.Click

    End Sub
    Private Sub ButtonX1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnIntentos.GotFocus

    End Sub
    Private Sub ButtonX1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnIntentos.KeyUp

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub


    Private Function GenerateHash(ByVal sourcetext As String)
        Dim ue As UnicodeEncoding = New UnicodeEncoding()
        Dim bytesourcetext As Byte() = ue.GetBytes(sourcetext)
        Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
        Dim bytehash As Byte() = md5.ComputeHash(bytesourcetext)
        Return Convert.ToBase64String(bytehash)
    End Function

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs)

    End Sub


End Class