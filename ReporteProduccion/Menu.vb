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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FormatoFecha = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
            Me.IsMdiContainer = True
            'Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
            'MsgBox(My.Resources.LocalizableStrings.RECURSO)

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

            'Dim lg As New Login
            'Me.Hide()
            'If lg.ShowDialog = Windows.Forms.DialogResult.OK Then
            '    Me.Show()
            cargardatos()
            'Else
            'Application.Exit()
            'End If

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
    End Sub


    Dim assts As New Assets
    Dim stateq As New StationsEquipment
    Dim depconc As New DepartmentsConcepts


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


        End Select
    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
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

    Private Sub RadPageCaptura_Paint(sender As Object, e As PaintEventArgs) Handles RadPageCaptura.Paint

    End Sub
End Class
