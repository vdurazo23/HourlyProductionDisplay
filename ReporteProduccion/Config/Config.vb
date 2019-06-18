Public Class Config
    Dim cn As New SqlClient.SqlConnection("")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cn.ConnectionString = "Data Source=" & TxtServer.Text.Trim & ";workstation id=;Persist Security Info=True;User ID=" & TxtUsuario.Text & ";password=" & TxtPwd.Text & ";initial catalog=" & TxtBD.Text
        Try
            If cn.State = ConnectionState.Open Then cn.Close()
            cn.Open()
            MsgBox("Conexión a BD Reporte exitosa", MsgBoxStyle.Information, "Conexión Reporte")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub Config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TxtServer.Text = My.Settings.Server
            TxtBD.Text = My.Settings.BD
            TxtUsuario.Text = My.Settings.usuario
            TxtPwd.Text = My.Settings.contraseña

            TxtServerMARS.Text = My.Settings.MARSServer
            TXTBDMARS.Text = My.Settings.MARSBD
            TXTUSUARIOMARS.Text = My.Settings.MARSUsuario
            TXTPWDMARS.Text = My.Settings.MARSContraseña

            TxtServerMPS.Text = My.Settings.MPSServer
            TXTBDMPS.Text = My.Settings.MPSBD
            TXTUsuarioMPS.Text = My.Settings.MPSUsuario
            TXTContrasaeñaMPS.Text = My.Settings.MPSContraseña

            TxtDSN.Text = My.Settings.dsnCMS
            TXTUIDCMS.Text = My.Settings.uidCMS
            TXTPWDCMS.Text = My.Settings.pwdCMS

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cn.ConnectionString = "Data Source=" & TxtServerMARS.Text.Trim & ";workstation id=;Persist Security Info=True;User ID=" & TXTUSUARIOMARS.Text & ";password=" & TXTPWDMARS.Text & ";initial catalog=" & TXTBDMARS.Text
        Try
            If cn.State = ConnectionState.Open Then cn.Close()
            cn.Open()
            MsgBox("Conexión a MARS exitosa", MsgBoxStyle.Information, "Conexión MARS")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            My.Settings.Server = TxtServer.Text
            My.Settings.contraseña = TxtPwd.Text
            My.Settings.usuario = TxtUsuario.Text
            My.Settings.BD = TxtBD.Text

            My.Settings.MARSServer = TxtServerMARS.Text
            My.Settings.MARSContraseña = TXTPWDMARS.Text
            My.Settings.MARSUsuario = TXTUSUARIOMARS.Text
            My.Settings.MARSBD = TXTBDMARS.Text

            My.Settings.MPSServer = TxtServerMPS.Text
            My.Settings.MPSBD = TXTBDMPS.Text
            My.Settings.MPSUsuario = TXTUsuarioMPS.Text
            My.Settings.MPSContraseña = TXTContrasaeñaMPS.Text

            My.Settings.dsnCMS = TxtDSN.Text
            My.Settings.uidCMS = TXTUIDCMS.Text
            My.Settings.pwdCMS = TXTPWDCMS.Text

            My.Settings.Save()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        cn.ConnectionString = "Data Source=" & TxtServerMPS.Text.Trim & ";workstation id=;Persist Security Info=True;User ID=" & TXTUsuarioMPS.Text & ";password=" & TXTContrasaeñaMPS.Text & ";initial catalog=" & TXTBDMPS.Text
        Try
            If cn.State = ConnectionState.Open Then cn.Close()
            cn.Open()
            MsgBox("Conexión a MPS exitosa", MsgBoxStyle.Information, "Conexión MPS")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim con As New Odbc.OdbcConnection("DSN=" & TxtDSN.Text & ";UID=" & TXTUIDCMS.Text & ";PWD=" & TXTPWDCMS.Text)
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            'con.Open()
            MsgBox("Conexión a CMS exitosa", MsgBoxStyle.Information, "Conexión CMS")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub
End Class