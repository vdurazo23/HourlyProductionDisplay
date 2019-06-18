Imports Microsoft.Reporting.WinForms

Public Class Menu
    Dim dt As New DataTable
    Public returnRow() As DataRow

    Dim FormatoFecha As String

    Function GetCommandLineArgs() As String()
        ' Declare variables.
        Dim separators As String = " "
        Dim commands As String = Microsoft.VisualBasic.Command()
        Dim args() As String = commands.Split(separators.ToCharArray)
        Return args
    End Function

    Sub activaopciones()
        If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Recursos") Then RadPageAssets.Enabled = False
        If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Operaciones") Then RadPageStations.Enabled = False
        If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Departamentos") Then RadPageDepartments.Enabled = False
        If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Características") Then RadPageCharacteristics.Enabled = False
        If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM") Then RadPageTPM.Enabled = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Text = Me.Text & " " & System.String.Format("Version {0}.{1} Build {2} Rev. {3}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

            FormatoFecha = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
            Me.IsMdiContainer = True

            If My.Settings.UPGRADEREQUIRED Then
                My.MySettings.Default.Upgrade()
                My.MySettings.Default.UPGRADEREQUIRED = False
                My.MySettings.Default.Save()
            End If

            'Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
            'MsgBox(My.Resources.LocalizableStrings.RECURSO)

            'MsgBox(My.Settings.UserId)
            If My.Settings.UserId.Trim = "" Then
                My.Settings.UserId = "0"
                My.Settings.Save()
            End If


            Dim str() As String
            str = GetCommandLineArgs()
            'MsgBox(str(0))
            If (UBound(str) >= 0) Then
                If str(0) = "c" Or str(0) = "C" Then
                    Me.Hide()
                    Dim conf As New Config
                    If conf.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Me.Show()
                    Else
                        Application.Exit()
                    End If
                End If
            End If
            If My.Settings.Server.Trim = "" Then
                Me.Hide()
                Dim conf As New Config
                If conf.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Me.Show()
                Else
                    Application.Exit()
                End If
            End If

            Dim lg As New Login
            Me.Hide()
            If lg.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Show()
                cargardatos()
                LblUsername.Text = My.Settings.UserName
            Else
                Application.Exit()
            End If

            cargardatos()

            activaopciones()

            'Dim param As New ReportParameter("ReportParameter1", "Test")
            'Dim myparams As New ReportParameterCollection
            'myparams.Add(param)
            'Me.ReportViewer1.LocalReport.SetParameters(myparams)


            'Dim dt As New DataTable
            'dt = SQLCon.GetDowntime(22, "2018-02-27", "1")

            'Me.ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("Downtime", dt))

            'Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try



    End Sub
    Sub cargardatos()
        Try
            dt = SQLCon.GetLineas
            CboResource.DataSource = Nothing
            CboResource.DataSource = dt.DefaultView
            CboResource.ValueMember = "ID"
            CboResource.DisplayMember = "Name"

            Try
                CboResource.SelectedValue = My.Settings.PreferedSubresource
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        DateTimePicker1.Value = Now
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        GroupBox1.Enabled = Not CheckBox1.Checked

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboResource.SelectedIndexChanged
        If CboResource.ValueMember = "" Then Exit Sub
        CboTurno.DataSource = SQLCon.GetMARSShifts(CboResource.SelectedValue, Now)
        CboTurno.DisplayMember = "Name"
        CboTurno.ValueMember = "ShiftID"


        CboTurno2.DataSource = SQLCon.GetMARSShifts(CboResource.SelectedValue, Now)
        CboTurno2.DisplayMember = "Name"
        CboTurno2.ValueMember = "ShiftID"
    End Sub

    Dim assts As New Assets
    Dim stateq As New StationsEquipment
    Dim depconc As New DepartmentsConcepts
    Dim feat As New PartFeatures
    Dim tpm As New TPM
    Private Sub RadPageView1_SelectedPageChanged(sender As Object, e As EventArgs) Handles RadPageView1.SelectedPageChanged
        If RadPageView1.SelectedPage.Name = "" Then Exit Sub
        Select Case RadPageView1.SelectedPage.Name
            Case RadPageCaptura.Name
                cargardatos()
            Case RadPageAssets.Name
                assts = Nothing
                assts = New Assets
                assts.TopLevel = False
                assts.Visible = True
                assts.Dock = DockStyle.Fill
                assts.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                RadPageAssets.Controls.Add(assts)
                assts.Show()
            Case RadPageStations.Name
                stateq = Nothing
                stateq = New StationsEquipment
                stateq.TopLevel = False
                stateq.Visible = True
                stateq.Dock = DockStyle.Fill
                stateq.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                RadPageStations.Controls.Add(stateq)
                stateq.Show()
            Case RadPageDepartments.Name
                depconc = Nothing
                depconc = New DepartmentsConcepts
                depconc.TopLevel = False
                depconc.Visible = True
                depconc.Dock = DockStyle.Fill
                depconc.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                RadPageDepartments.Controls.Add(depconc)
                depconc.Show()
            Case RadPageCharacteristics.Name
                feat = Nothing
                feat = New PartFeatures
                feat.TopLevel = False
                feat.Visible = True
                feat.Dock = DockStyle.Fill
                feat.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                RadPageCharacteristics.Controls.Add(feat)
                feat.Show()
            Case RadPageTPM.Name
                tpm = Nothing
                tpm = New TPM
                tpm.TopLevel = False
                tpm.Visible = True
                tpm.Dock = DockStyle.Fill
                tpm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                RadPageTPM.Controls.Add(tpm)
                tpm.Show()
                tpm.activaopciones()


        End Select
    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        If CboResource.SelectedValue Is Nothing Then Exit Sub
        'If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Captura") Then
        '    MsgBox("No tiene permisos para esta opción" & vbCrLf & "Consulte al Administrador del Sistema", MsgBoxStyle.Exclamation, "Permisos")
        '    Exit Sub
        'End If

        returnRow = dt.Select("ID=" & CboResource.SelectedValue.ToString)
        My.Settings.PreferedSubresource = CboResource.SelectedValue
        My.Settings.Save()

        Me.Hide()
        Dim rep As New ReporteProduccion
        rep.RecursoDatarow = returnRow

        If SQLCon.GetMARSProductionDate(returnRow(0).Item("ID"), returnRow(0).Item("SubResourceId")).ToString("MM/dd/yyyy") = DateTimePicker1.Value.ToString("MM/dd/yyyy") And SQLCon.GetMARSProductionShiftName(returnRow(0).Item("ID"), returnRow(0).Item("SubResourceId")) = CboTurno.Text Then
            CheckBox1.Checked = True
        End If

        If CheckBox1.Checked Then
            rep.IscurrentShift = True
            rep.CurrentProductionDate = SQLCon.GetMARSProductionDate(returnRow(0).Item("ID"), returnRow(0).Item("SubResourceId"))
            rep.CurrentShiftName = SQLCon.GetMARSProductionShiftName(returnRow(0).Item("ID"), returnRow(0).Item("SubResourceId"))
        Else
            rep.IscurrentShift = False
            rep.CurrentProductionDate = DateTimePicker1.Value.Date
            rep.CurrentShiftName = CboTurno.Text
        End If

        rep.ShowDialog()
        rep.Dispose()
        rep = Nothing
        Me.Show()

    End Sub


    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        GroupBox2.Enabled = Not CheckBox2.Checked
    End Sub

    Private Sub CboTurno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboTurno.SelectedIndexChanged

    End Sub

    Private Sub CboTurno2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboTurno2.SelectedIndexChanged

    End Sub
End Class
