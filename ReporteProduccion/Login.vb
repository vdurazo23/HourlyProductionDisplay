Imports System.Text
Imports System.Security.Cryptography

Public Class Login
    Dim cn As New SqlClient.SqlConnection("Data Source=" & My.Settings.MPSServer.Trim & ";workstation id=;Persist Security Info=True;User ID=" & My.Settings.MPSUsuario & ";password=" & My.Settings.MPSContraseña & ";initial catalog=" & My.Settings.MPSBD)

    Private Sub Login_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.Alt And e.Control And e.KeyCode = Keys.C Then
            Dim conf As New Config
            conf.ShowDialog()
        End If
    End Sub
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim cone As New OleDb.OleDbConnection("")
        'Dim coneodbc As New Odbc.OdbcConnection("DSN=HMOCMS;UID=IGEAR;PWD=IGEAR123")
        'Try
        '    cone.ConnectionString = "Provider=IBMDA400;Data Source=10.251.10.12;User Id=IGEAR;Password=IGEAR123;"
        '    cone.Open()

        '    coneodbc.Open()

        '    Dim timeOLE, timeODBC As Integer
        '    Dim inicio, fin As DateTime

        '    Dim DA As New OleDb.OleDbDataAdapter("SELECT * FROM HMOCMS.STKA", cone)
        '    Dim DS As New DataSet

        '    inicio = Now

        '    DA.Fill(DS, "TST")
        '    fin = Now

        '    timeOLE = DateDiff(DateInterval.Second, inicio, fin)

        '    Dim DAOD As New Odbc.OdbcDataAdapter("SELECT * FROM HMOCMS.STKA", coneodbc)

        '    inicio = Now
        '    DAOD.Fill(DS, "TST2")
        '    fin = Now

        '    timeODBC = DateDiff(DateInterval.Second, inicio, fin)


        '    MsgBox(DS.Tables(0).DefaultView.Count.ToString & vbCrLf & "Ole:" & timeOLE.ToString & " -  odbc:" & timeODBC.ToString, MsgBoxStyle.Information, "Registros")

        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'Finally
        '    cone.Close()
        'End Try
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        'Version {0}.{1} Build {2} Rev. {3}
        If Debugger.IsAttached Then
            txtpwd.Text = "Elchoco1"
            txtUsuario.Text = "Admin"
        End If

    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        ErrorProvider1.Clear()
        If txtUsuario.Text.Trim = "" Then
            ErrorProvider1.SetError(txtUsuario, "Requerido")
            txtUsuario.Focus()

            Exit Sub
        End If

        If txtpwd.Text.Trim = "" Then
            ErrorProvider1.SetError(txtpwd, "Requerido")
            txtpwd.Focus()

            Exit Sub
        End If

        Try

            Dim loginstr As String
            loginstr = SQLCon.Login(txtUsuario.Text, GenerateHash(txtpwd.Text))
            If loginstr = "OK" Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
                Exit Sub
            Else
                MsgBox(loginstr, MsgBoxStyle.Exclamation, "Login")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Public Function GenerateHash(ByVal SourceText As String) As String
        'Create an encoding object to ensure the encoding standard for the source text
        Dim Ue As New UnicodeEncoding
        'Retrieve a byte array based on the source text
        Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
        'Instantiate an MD5 Provider object
        Dim Md5 As New MD5CryptoServiceProvider
        'Compute the hash value from the source
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        'And convert it to String format for return
        Return Convert.ToBase64String(ByteHash)
    End Function

End Class