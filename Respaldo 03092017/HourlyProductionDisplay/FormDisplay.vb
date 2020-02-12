Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports Transitions

Public Class FormDisplay

    Dim fechaserver As Date

    Public cn As New SqlClient.SqlConnection("Data Source=" & My.Settings.MARSServer & ";workstation id=;Persist Security Info=True;User ID=" & My.Settings.MARSUser & ";password=" & Decrypt(My.Settings.MARSPwd) & ";initial catalog=" & My.Settings.MARSBD)
    Dim cmd As New SqlClient.SqlCommand("", cn)
    Dim ds As New DataSet
    Dim da As New SqlClient.SqlDataAdapter("SELECT * FROM [hmo].[GetHourlyProdTable] (9,'2 - 3','2016-10-15')", cn)


    Dim CurrAssetID As String = ""
    Dim CurrSubResID As String = ""
    Dim CurrShiftName As String = ""
    Dim CurrFecha As Date
    Dim ResourceName As String = ""
    Dim ResourceCode As String = ""

    Dim CurrResIndex As Integer = 0
    Dim CurrSlideInex As Integer = 0

    Public paused As Boolean = False

    Public targetfront As Boolean = True
    Public ShowTargetlabel As Boolean = True

    Dim TBLMETHDR As DataTable
    Dim TBLMETHDA As DataTable

    Public changeovertarget As Integer = 1200    ''20 minutos 20*60=1200 (segundos)

    Dim actualyellowtarget As Integer = 82
    Dim actualgreentarget As Integer = 85




    Private Sub FormDisplay_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Right Then
            If paused Then Exit Sub
            If TimerChange.Enabled = True Then
                TimerChange.Stop()
                TimerChange_Tick(sender, e)
                'If TimerChange.Enabled Then TimerChange.Start()
                Exit Sub
            End If
            If TimerSlides.Enabled Then
                TimerSlides.Stop()
                TimerSlides_Tick(sender, e)
                'If TimerSlides.Enabled Then TimerSlides.Start()
                Exit Sub
            End If
        End If

        If e.KeyCode = Keys.P Or e.KeyCode = Keys.Pause Then
            paused = Not paused
            If paused Then
                Picpause.Visible = True
                Picpause.BringToFront()
            Else
                Picpause.Visible = False
            End If
        End If

        If e.KeyCode = Keys.Up Then
            My.Settings.FontIncrement = My.Settings.FontIncrement + 1
            My.Settings.Save()
            formatlabels()
        End If
        If e.KeyCode = Keys.Down Then
            My.Settings.FontIncrement = My.Settings.FontIncrement - 1
            My.Settings.Save()
            formatlabels()
        End If

        If e.KeyCode = Keys.Add Then

            My.Settings.FontIncrement2 = My.Settings.FontIncrement2 + 1
            My.Settings.Save()
            formatlabelsseries()

        End If
        If e.KeyCode = Keys.Subtract Then
            My.Settings.FontIncrement2 = My.Settings.FontIncrement2 - 1
            My.Settings.Save()
            formatlabelsseries()
        End If

        If e.KeyCode = Keys.T Then
            targetfront = Not targetfront
        End If

    End Sub
    Dim seriesfontsizeoriginal As Single

    Sub formatlabelsseries()

        LblFontIncrement.Text = IIf(My.Settings.FontIncrement2 > 0, "+" & My.Settings.FontIncrement2.ToString, My.Settings.FontIncrement2.ToString)
        LblFontIncrement.Visible = True
        LblFontIncrement.BringToFront()

        TimerFontSize.Enabled = True

        Chart1.Series(1).Font = New Font(Chart1.Series(1).Font.Name, seriesfontsizeoriginal + My.Settings.FontIncrement2, Chart1.Series(1).Font.Style)
        Chart1.Series(2).Font = New Font(Chart1.Series(2).Font.Name, seriesfontsizeoriginal + My.Settings.FontIncrement2, Chart1.Series(2).Font.Style)

        Chart2.Series(1).Font = New Font(Chart2.Series(1).Font.Name, seriesfontsizeoriginal + My.Settings.FontIncrement2, Chart2.Series(1).Font.Style)
        Chart2.Series(2).Font = New Font(Chart2.Series(2).Font.Name, seriesfontsizeoriginal + My.Settings.FontIncrement2, Chart2.Series(2).Font.Style)

    End Sub

    Sub formatlabels()
        LblFontIncrement.Text = IIf(My.Settings.FontIncrement > 0, "+" & My.Settings.FontIncrement.ToString, My.Settings.FontIncrement.ToString)

        LblFontIncrement.Visible = True
        LblFontIncrement.BringToFront()

        TimerFontSize.Enabled = True

        LblResource.Font = New Font(LblResource.Font.Name, LblResource.Tag + My.Settings.FontIncrement, LblResource.Font.Style)
        LblPart.Font = New Font(LblPart.Font.Name, LblPart.Tag + My.Settings.FontIncrement, LblPart.Font.Style)
        LblShifTarget.Font = New Font(LblShifTarget.Font.Name, LblShifTarget.Tag + My.Settings.FontIncrement, LblShifTarget.Font.Style)
        LblShifTarget.Top = LblPart.Top
        LblShifTarget.Height = LblPart.Height
        LblAverage.Font = New Font(LblAverage.Font.Name, LblAverage.Tag + My.Settings.FontIncrement, LblAverage.Font.Style)
        LblCurrentActual.Font = New Font(LblCurrentActual.Font.Name, LblCurrentActual.Tag + My.Settings.FontIncrement, LblCurrentActual.Font.Style)
        LblCurrentActual.Top = LblAverage.Top
        LblCurrentActual.Height = LblAverage.Height

        LblCurrentActualValue.Font = New Font(LblCurrentActualValue.Font.Name, LblCurrentActualValue.Tag + My.Settings.FontIncrement, LblCurrentActualValue.Font.Style)
        LblCurrentActualValue.Top = LblAverage.Top
        LblCurrentActualValue.Left = LblCurrentActual.Left + LblCurrentActual.Width
        LblCurrentActualValue.Height = LblAverage.Height


        LblShiftDelta.Font = New Font(LblShiftDelta.Font.Name, LblShiftDelta.Tag + My.Settings.FontIncrement, LblShiftDelta.Font.Style)
        LblShiftDelta.Top = LblCurrentActual.Top + LblCurrentActual.Height  'LblCurrentTarget.Top
        LblShiftDelta.Width = LblCurrentActual.Width
        LblShiftDelta.Left = LblCurrentActual.Left
        LblShiftDelta.Height = LblCurrentTarget.Height

        LblShiftDeltaValue.Font = New Font(LblShiftDeltaValue.Font.Name, LblShiftDeltaValue.Tag + My.Settings.FontIncrement, LblShiftDeltaValue.Font.Style)
        LblShiftDeltaValue.Top = LblCurrentActual.Top + LblCurrentActual.Height 'LblCurrentTarget.Top
        LblShiftDeltaValue.Left = LblCurrentActual.Left + LblCurrentActual.Width
        LblShiftDeltaValue.Height = LblCurrentTarget.Height

        LblCurrentTarget.Font = New Font(LblCurrentTarget.Font.Name, LblCurrentTarget.Tag + My.Settings.FontIncrement, LblCurrentTarget.Font.Style)
        LblFechaHora.Font = New Font(LblFechaHora.Font.Name, LblFechaHora.Tag + My.Settings.FontIncrement, LblFechaHora.Font.Style)
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''GUARDAR VALOR ORIGINAL DEL TAMAÑO DE LETRA EN LOS TAGS
        LblResource.Tag = LblResource.Font.Size
        LblPart.Tag = LblPart.Font.Size
        LblShifTarget.Tag = LblShifTarget.Font.Size
        LblAverage.Tag = LblAverage.Font.Size
        LblCurrentActual.Tag = LblCurrentActual.Font.Size
        LblCurrentActualValue.Tag = LblCurrentActualValue.Font.Size

        LblShiftDelta.Tag = LblShiftDelta.Font.Size
        LblShiftDeltaValue.Tag = LblShiftDelta.Font.Size


        LblCurrentTarget.Tag = LblCurrentTarget.Font.Size
        LblFechaHora.Tag = LblFechaHora.Font.Size

        seriesfontsizeoriginal = Chart1.Series(1).Font.Size

        formatlabels()
        formatlabelsseries()

        TimerChange.Interval = My.Settings.Timer * 1000
        TimerSlides.Interval = My.Settings.Timer * 1000

        If Debugger.IsAttached Then
            'Dim seg As Integer
            'seg = InputBox("Segundos: ", "Segundos", "0")
            TimerChange.Interval = 5000
            TimerSlides.Interval = 5000
        End If

        Chart2.Size = Chart1.Size
        Chart2.Location = Chart1.Location
        Chart2.Left = Me.Width
        Chart2.Visible = False

        PicSlide1.Size = Me.Size
        PicSlide1.Location = Me.Bounds.Location
        PicSlide1.Left = Me.Width
        PicSlide1.Visible = False

        PicSlide2.Size = Me.Size
        PicSlide2.Location = Me.Bounds.Location
        PicSlide2.Left = Me.Width
        PicSlide2.Visible = False

        CargarRunRates()
        'prepararsubrecursos()

        If My.Settings.RESOURCES.Rows.Count <= 0 Then
            MsgBox("No resources configured", MsgBoxStyle.Exclamation, "Resource required!")
            Application.Exit()
        End If

        Me.Visible = False
        Me.Refresh()
        Me.ResizeRedraw = True
        Showing=Chart1 
        cargardatos(Chart1)




        Me.Visible = True
    End Sub
    Sub CargarRunRates()
        Dim Con As New Odbc.OdbcConnection("DSN=" & My.Settings.DSN & ";UID=" & My.Settings.CMSUser & ";PWD=" & My.Settings.CMSPwd)
        Try

            Con.Open()

            Dim Ds1 As New DataSet
            Dim da As New Odbc.OdbcDataAdapter("SELECT * FROM " & My.Settings.DSN & ".METHDR", Con)
            da.Fill(ds, "METHDR")
            TBLMETHDR = ds.Tables("METHDR").Copy

            da.SelectCommand.CommandText = "SELECT * FROM " & My.Settings.DSN & ".METHDA"
            da.Fill(ds, "METHDA")

            TBLMETHDA = ds.Tables("METHDA").Copy

            Con.Close()
            da = Nothing
            Ds1 = Nothing

        Catch ex As Exception
            'MsgBox("Error loading RunRates " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        Finally
            If Con.State = ConnectionState.Open Then Con.Close()
        End Try
    End Sub

    Private Structure Breaks
        Dim inicio As String
        Dim fin As String
    End Structure

    Sub cargarbreaks()
        ' MsgBox("BREAKS")
        Dim Con As New Odbc.OdbcConnection("DSN=" & My.Settings.DSN & ";UID=" & My.Settings.CMSUser & ";PWD=" & My.Settings.CMSPwd)
        Try

            Con.Open()

            Dim DAYSTART As String = "00:00:00"
            Dim ENDSTR As String = "01"
            Dim STARTSTR As String = "02"
            Dim BREAKS As New List(Of String)

            Dim Ds1 As New DataSet
            Dim da As New Odbc.OdbcDataAdapter("SELECT * FROM " & My.Settings.DSN & ".METHDR", Con)

            Dim breaksList As New List(Of Breaks)

            For i = 0 To My.Settings.RESOURCES.DefaultView.Count - 1
                '5 y 6  dpto y resc
                da.SelectCommand.CommandText = "SELECT * FROM " & My.Settings.DSN & ".CPCTY WHERE DYDEPT='" & My.Settings.RESOURCES.DefaultView.Item(i).Item(5).ToString & "' AND DYRESR='" & My.Settings.RESOURCES.DefaultView.Item(i).Item(6).ToString & "' AND DYDATE='" & fechaserver.ToString("yyyy-MM-dd") & "'"
                da.Fill(ds, "LABOR")

                If ds.Tables("LABOR").DefaultView.Count > 0 Then
                    If ds.Tables("LABOR").DefaultView.Item(0).Item("DYST01").ToString <> DAYSTART Then
                        Dim break As New Breaks
                        break.inicio = DAYSTART
                        break.fin = ds.Tables("LABOR").DefaultView.Item(0).Item("DYST01").ToString
                        breaksList.Add(break)
                    End If
                End If

                For y = 0 To ds.Tables("LABOR").DefaultView.Count - 1
                    ''Todos los posibles espacios de programacion "16"
                    Dim xpos As Integer = 0
                    For x = 1 To 16
                        ''END 01 AL START 02
                        ENDSTR = "0" + x.ToString
                        STARTSTR = "0" & (x + 1).ToString
                        If ds.Tables("LABOR").DefaultView.Item(y).Item("DYST" + STARTSTR).ToString <> "00:00:00" Then
                            Dim break As New Breaks
                            break.inicio = ds.Tables("LABOR").DefaultView.Item(y).Item("DYEN" + ENDSTR).ToString
                            break.fin = ds.Tables("LABOR").DefaultView.Item(y).Item("DYST" + STARTSTR).ToString
                            breaksList.Add(break)
                        End If

                        If ds.Tables("LABOR").DefaultView.Item(y).Item("DYST0" & x.ToString).ToString = "00:00:00" And ds.Tables("LABOR").DefaultView.Item(y).Item("DYEN0" & x.ToString).ToString = "00:00:00" Then
                            xpos = x - 1
                            Exit For
                        End If
                    Next

                    If ds.Tables("LABOR").DefaultView.Item(y).Item("DYEN0" & xpos.ToString).ToString <> "23:59:00" Then
                        Dim break As New Breaks
                        break.inicio = ds.Tables("LABOR").DefaultView.Item(y).Item("DYEN0" & xpos.ToString).ToString
                        break.fin = "23:59:00"
                        breaksList.Add(break)
                    End If

                Next


                cmd.CommandText = "DELETE FROM hmo.breaks where Department='" & My.Settings.RESOURCES.DefaultView.Item(i).Item(5).ToString & "' AND ResourceCode='" & My.Settings.RESOURCES.DefaultView.Item(i).Item(6).ToString & "' AND Fecha='" & fechaserver.ToString("MM/dd/yyyy") & "'"
                cmd.ExecuteScalar()
                For n = 0 To breaksList.Count - 1
                    cmd.CommandText = "INSERT INTO hmo.breaks(ResourceCode,Department,Start,[End],Fecha) values ('" & My.Settings.RESOURCES.DefaultView.Item(i).Item(6).ToString & "'," & _
                        "'" & My.Settings.RESOURCES.DefaultView.Item(i).Item(5).ToString & "'," & _
                        "'" & breaksList(n).inicio & "'," & _
                        "'" & breaksList(n).fin & "'," & _
                        "'" & fechaserver.ToString("MM/dd/yyyy") & "')"
                    cmd.ExecuteScalar()
                Next

                breaksList.Clear()
                ds.Tables.Clear()

            Next

            'Dim Ds1 As New DataSet
            'Dim da As New Odbc.OdbcDataAdapter("SELECT * FROM " & My.Settings.DSN & ".METHDR", Con)
            'da.Fill(ds, "METHDR")
            'TBLMETHDR = ds.Tables("METHDR").Copy

            'da.SelectCommand.CommandText = "SELECT * FROM " & My.Settings.DSN & ".METHDA"
            'da.Fill(ds, "METHDA")

            'TBLMETHDA = ds.Tables("METHDA").Copy

            'Con.Close()
            'da = Nothing
            'Ds1 = Nothing

        Catch ex As Exception
            MsgBox("Error loading RunRates " & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        Finally
            If Con.State = ConnectionState.Open Then Con.Close()
        End Try
    End Sub
    Dim ActualShift As String = ""
    Dim ActualFechaServer As Date = "01/01/1900"
    Dim segundossetup As Integer = 0
    Dim SPM As Integer = 0

    Sub cargardatos(ByRef Elchart As Chart)
        Try
            CurrAssetID = My.Settings.RESOURCES.DefaultView.Item(CurrResIndex).Item(0).ToString
            ResourceName = My.Settings.RESOURCES.DefaultView.Item(CurrResIndex).Item(1).ToString
            ResourceCode = My.Settings.RESOURCES.DefaultView.Item(CurrResIndex).Item(6).ToString

            Try
                CurrSubResID = My.Settings.RESOURCES.DefaultView.Item(CurrResIndex).Item(7).ToString
            Catch ex As Exception
                CurrSubResID = "1"
            End Try

            segundossetup = 0

            If cn.State = ConnectionState.Closed Then cn.Open()

            cmd.CommandText = "select getdate()"
            fechaserver = cmd.ExecuteScalar

            cmd.CommandText = "select count(*) from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='hmo' and TABLE_NAME='TiempoMuerto'"

            If cmd.ExecuteScalar <= 0 Or 1 = 1 Then

                PanelPrensas.Visible = False
                GoTo saltarbottombar
            End If

            cmd.CommandText = "select top 1 datediff(second,fecha,fecha_end) as segundos from hmo.TiempoMuerto where diechange=1 and iscurrent=0 and assetcode='" & ResourceCode.Trim.Replace(" ", "") & "' order by id desc"

            segundossetup = cmd.ExecuteScalar

            cmd.CommandText = "select SPM from hmo.running where prensa='" & ResourceCode.Trim.Replace(" ", "") & "'"

            SPM = cmd.ExecuteScalar

            If segundossetup > 0 Then
                PanelPrensas.Visible = True
                Lblsetupactual.Text = secondstohourminutesecondA(segundossetup)
                LblSetupTarget.Text = secondstohourminutesecondA(changeovertarget)

                If segundossetup > changeovertarget Then
                    Lblsetupactual.BackColor = Color.Red
                Else
                    Lblsetupactual.BackColor = Color.Lime
                End If

                LblSPMActual.Text = SPM.ToString

            Else
                PanelPrensas.Visible = False

            End If

saltarbottombar:

            'RANGOS DE ROJO VERDE AMARILLO

            RadialGaugeArc4.RangeEnd = actualyellowtarget

            RadialGaugeArc6.RangeStart = actualyellowtarget
            RadialGaugeArc6.RangeEnd = actualgreentarget

            RadialGaugeArc5.RangeStart = actualgreentarget
            RadialGaugeArc5.RangeEnd = 100


            ''LblFechaHora.Text = fechaserver.ToLongDateString & " " & fechaserver.ToShortTimeString
            LblFechaHora.Text = fechaserver.ToString("dd/MM/yyyy") & " " & fechaserver.ToShortTimeString

            LblFechaHora.ForeColor = Color.Black

            cmd.CommandText = "Select ProductionShiftName from pro.ResourceStatus where Asset_ID=" & CurrAssetID
            CurrShiftName = cmd.ExecuteScalar

            If fechaserver.ToShortDateString <> ActualFechaServer.ToShortDateString Then
                cargarbreaks()
                ActualFechaServer = fechaserver
            End If

            cmd.CommandText = "Select ProductionDate from pro.ResourceStatus where Asset_ID=" & CurrAssetID
            CurrFecha = cmd.ExecuteScalar
            ds.Tables.Clear()

            da.SelectCommand.CommandText = "SELECT * FROM [hmo].[GetHourlyProdTable] (" & CurrAssetID & ",'" & CurrShiftName & "','" & CurrFecha.ToString("MM/dd/yyyy") & "'," & CurrSubResID & ") where CURRENTTARGET>=1"

            'da.SelectCommand.CommandText = "SELECT * FROM [hmo].[GetHourlyProdTable] (" & CurrAssetID & ",'" & CurrShiftName & "','" & CurrFecha.ToString("MM/dd/yyyy") & "')"

            da.Fill(ds, "Production")

            Dim cmsrunrate As Double

            Try
                For I = 0 To ds.Tables("Production").DefaultView.Count - 1
                    TBLMETHDR.DefaultView.RowFilter = "AOPART='" & ds.Tables("Production").DefaultView.Item(I).Item("PARTNUMBER") & "' AND AODEPT = '" & My.Settings.RESOURCES.DefaultView.Item(CurrResIndex).Item("DepartmentCode") & "' AND AORESC='" & My.Settings.RESOURCES.DefaultView.Item(CurrResIndex).Item("ResourceCode") & "'"
                    TBLMETHDA.DefaultView.RowFilter = "ARPART='" & ds.Tables("Production").DefaultView.Item(I).Item("PARTNUMBER") & "' AND ARDEPT = '" & My.Settings.RESOURCES.DefaultView.Item(CurrResIndex).Item("DepartmentCode") & "' AND ARRESC='" & My.Settings.RESOURCES.DefaultView.Item(CurrResIndex).Item("ResourceCode") & "'"
                    If TBLMETHDR.DefaultView.Count = 0 Then
                        '' NO TIENE RUNRATE DEBE SER ALTERNO
                        If TBLMETHDA.DefaultView.Item(0).Item("ARFUTD") > 0 Then
                            '' TIENE RUN RATE TEORICO
                            cmsrunrate = TBLMETHDA.DefaultView.Item(0).Item("ARFUTD") ''/ TBLMETHDA.DefaultView.Item(0).Item("AR#MCH")
                        Else
                            ''NO TIENE TEORICO TONS LO QUE ES
                            cmsrunrate = TBLMETHDA.DefaultView.Item(0).Item("ARRUNS") ''/ TBLMETHDA.DefaultView.Item(0).Item("AR#MCH")
                        End If
                    Else
                        ''SI TIENE NO ES ALTERNO
                        If TBLMETHDR.DefaultView.Item(0).Item("AOFUTD") > 0 Then
                            '' TIENE RUN RATE TEORICO
                            cmsrunrate = TBLMETHDR.DefaultView.Item(0).Item("AOFUTD") ''/ TBLMETHDR.DefaultView.Item(0).Item("AO#MCH")
                        Else
                            ''NO TIENE TEORICO TONS LO QUE ES
                            cmsrunrate = TBLMETHDR.DefaultView.Item(0).Item("AORUNS") ''/ TBLMETHDR.DefaultView.Item(0).Item("AO#MCH")
                        End If
                    End If

                    If ds.Tables("Production").DefaultView.Item(I).Item("RUNRATE") <> cmsrunrate Then
                        '' MARS NO TIENE BIEN EL RUNRATE
                        ''calcular nuevo rate
                        ds.Tables("Production").DefaultView.Item(I).Item("CURRENTTARGET") = (cmsrunrate * ds.Tables("Production").DefaultView.Item(I).Item("CURRENTTARGET")) / ds.Tables("Production").DefaultView.Item(I).Item("RUNRATE")
                        '' poner el runrate de cms
                        ds.Tables("Production").DefaultView.Item(I).Item("RUNRATE") = cmsrunrate
                    End If
                Next
            Catch ex As Exception

            End Try
            

            Elchart.Series(0).Points.Clear()
            Elchart.Series(1).Points.Clear()
            Elchart.Series(2).Points.Clear()
            Elchart.Series(3).Points.Clear()

            'Elchart.Series(0).Points.AddXY("AVG", 88)
            'Elchart.Series(1).Points.AddXY("AVG", 90)
            Dim totalprod As Integer = 0
            Dim ShiftTarget As Double = 0.0

            Dim totalhoras As Double = 0.0
            Dim SegundosBreaks As Double = 0.0
            For i = 0 To ds.Tables("Production").DefaultView.Count - 1
                Elchart.Series(0).Points.AddXY(ds.Tables("Production").DefaultView.Item(i).Item("PARTNUMBER"), ds.Tables("Production").DefaultView.Item(i).Item("CURRENTTARGET"))
                Elchart.Series(3).Points.AddXY(ds.Tables("Production").DefaultView.Item(i).Item("PARTNUMBER"), ds.Tables("Production").DefaultView.Item(i).Item("CURRENTTARGET"))

                Elchart.Series(1).Points.AddXY(ds.Tables("Production").DefaultView.Item(i).Item("PARTNUMBER"), ds.Tables("Production").DefaultView.Item(i).Item("TOTAL"))
                Elchart.Series(2).Points.AddXY(ds.Tables("Production").DefaultView.Item(i).Item("PARTNUMBER"), 0)
                SegundosBreaks = SegundosBreaks + ds.Tables("Production").DefaultView.Item(i).Item("SEGUNDOSBREAK")
                totalprod = totalprod + ds.Tables("Production").DefaultView.Item(i).Item("TOTAL")
                ShiftTarget = ShiftTarget + ds.Tables("Production").DefaultView.Item(i).Item("CURRENTTARGET")
            Next

            totalhoras = (DateDiff(DateInterval.Second, CType(ds.Tables("Production").DefaultView.Item(0).Item("STARTTIME"), Date), fechaserver) - SegundosBreaks) / 3600

            LblPart.Text = "PART: " & ds.Tables("Production").DefaultView.Item(ds.Tables("Production").DefaultView.Count - 1).Item("PARTNUMBER").ToString
            LblResource.Text = "Resource: " & ResourceName & IIf(CurrSubResID > 1, " " + CurrSubResID.ToString, "")
            LblShifTarget.Text = "Shift current target: " & Math.Round(ShiftTarget).ToString("F0")
            LblCurrentActualValue.Text = totalprod.ToString

            LblShiftDeltaValue.Text = (totalprod - Math.Round(ShiftTarget)).ToString("F0")

            If LblShiftDeltaValue.Text > 0 Then LblShiftDeltaValue.Text = "+" & LblShiftDeltaValue.Text

            If totalhoras < 0.01 Then
                totalhoras = 0
            End If

            LblAverage.Text = "Average: " & ((totalprod) / totalhoras).ToString("F2")

            If totalprod = 0 Then LblAverage.Text = "Average: 0"

            Dim eff As Double
            eff = (totalprod * 100) / ShiftTarget
            LblCurrentActualValue.BackColor = Color.Gainsboro
            LblShiftDeltaValue.BackColor = Color.Gainsboro


            If eff < actualyellowtarget Then
                LblCurrentActualValue.BackColor = Color.Red
                LblShiftDeltaValue.BackColor = Color.FromArgb(127, Color.Red)
            End If
            If eff >= actualyellowtarget Then
                LblCurrentActualValue.BackColor = Color.Yellow
                LblShiftDeltaValue.BackColor = Color.FromArgb(127, Color.Yellow)
            End If
            If eff >= actualgreentarget Then
                LblCurrentActualValue.BackColor = Color.Lime
                LblShiftDeltaValue.BackColor = Color.FromArgb(127, Color.Lime)
            End If

            RadialGaugeNeedle2.Value = eff

            'If eff < 70 Then
            '    RadialGaugeNeedle2.BackColor = Color.Red
            '    RadialGaugeNeedle2.BackColor2 = Color.Red
            'End If
            'If eff >= 70 And eff < 85 Then
            '    RadialGaugeNeedle2.BackColor = Color.Orange
            '    RadialGaugeNeedle2.BackColor2 = Color.Orange
            'End If
            'If eff >= 85 Then
            '    RadialGaugeNeedle2.BackColor = Color.Lime
            '    RadialGaugeNeedle2.BackColor2 = Color.Lime
            'End If

            RadialGaugeSingleLabel1.LabelText = eff.ToString("f2") & "%"

            LblCurrentTarget.Text = "Current Hourly Target: " & ds.Tables("Production").DefaultView.Item(ds.Tables("Production").DefaultView.Count - 1).Item("RUNRATE")
            LblSPMTarget.Text = (ds.Tables("Production").DefaultView.Item(ds.Tables("Production").DefaultView.Count - 1).Item("RUNRATE") / 60).ToString

            If SPM >= Math.Ceiling(ds.Tables("Production").DefaultView.Item(ds.Tables("Production").DefaultView.Count - 1).Item("RUNRATE") / 60) Then
                LblSPMActual.BackColor = Color.Lime
            Else
                LblSPMActual.BackColor = Color.Red
            End If

            ''NO MOSTRAR LA SERIE DEL TARGET
            Elchart.Series(0).Enabled = False  ' Not targetfront
            Elchart.Series(3).Enabled = False ' targetfront


            For i = 0 To Elchart.Series(1).Points.Count - 1

                Dim AheadBehind As Double

                AheadBehind = Elchart.Series(1).Points(i).YValues(0) - Math.Round(Elchart.Series(0).Points(i).YValues(0))

                ''label de la linea del target
                Elchart.Series(0).Points(i).Label = Math.Round(Elchart.Series(0).Points(i).YValues(0)).ToString("F0")
                Elchart.Series(3).Points(i).Label = Math.Round(Elchart.Series(3).Points(i).YValues(0)).ToString("F0")

                AheadBehind = Math.Ceiling(AheadBehind) ''Math.Ceiling(AheadBehind)

                Select Case AheadBehind
                    Case Is = 0
                        Elchart.Series(1).Points(i).Color = Color.Lime
                        Elchart.Series(2).Points(i).Label = "   "

                    Case Is < 0

                        If (Elchart.Series(1).Points(i).YValues(0) * 100) / Elchart.Series(0).Points(i).YValues(0) < actualyellowtarget Then
                            Elchart.Series(1).Points(i).Color = Color.Red
                        End If

                        If (Elchart.Series(1).Points(i).YValues(0) * 100) / Elchart.Series(0).Points(i).YValues(0) >= actualyellowtarget Then
                            Elchart.Series(1).Points(i).Color = Color.Yellow
                        End If

                        If (Elchart.Series(1).Points(i).YValues(0) * 100) / Elchart.Series(0).Points(i).YValues(0) >= actualgreentarget Then
                            Elchart.Series(1).Points(i).Color = Color.Lime
                        End If

                        Elchart.Series(2).Points(i).SetValueY(AheadBehind * -1)
                        Elchart.Series(2).Points(i).Label = ((AheadBehind).ToString)
                        Elchart.Series(2).Points(i).Color = Color.FromArgb(35, Elchart.Series(1).Points(i).Color)

                    Case Is > 0
                        Elchart.Series(1).Points(i).Color = Color.Lime
                        Elchart.Series(1).Points(i).SetValueY(Elchart.Series(0).Points(i).YValues(0))

                        Elchart.Series(2).Points(i).SetValueY(AheadBehind)

                        Elchart.Series(2).Points(i).Label = "+" & (AheadBehind).ToString("F0")

                        Elchart.Series(2).Points(i).Color = Color.FromArgb(127, Color.Lime)

                        Elchart.Series(1).Points(i).Label = Math.Round(Elchart.Series(0).Points(i).YValues(0)) + (AheadBehind)

                End Select

                'If Elchart.Series(1).Points(i).YValues(0) = Elchart.Series(0).Points(i).YValues(0) Then
                '    Elchart.Series(1).Points(i).Color = Color.Lime
                'End If

                'Dim valchart As Double = Elchart.Series(0).Points(i).YValues(0) - Elchart.Series(1).Points(i).YValues(0)

                'If Elchart.Series(1).Points(i).YValues(0) > Elchart.Series(0).Points(i).YValues(0) Then
                '    Elchart.Series(1).Points(i).Color = Color.Lime

                '    Elchart.Series(1).Points(i).SetValueY(Elchart.Series(0).Points(i).YValues(0))

                '    Elchart.Series(2).Points(i).SetValueY(valchart * -1)
                '    Elchart.Series(2).Points(i).Label = "+" & (valchart * -1).ToString("F2")
                '    Elchart.Series(2).Points(i).Color = Color.FromArgb(127, Color.Lime)

                '    Elchart.Series(1).Points(i).Label = Elchart.Series(0).Points(i).YValues(0) + (valchart * -1)

                'Else
                '    Elchart.Series(1).Points(i).Color = Color.Red
                '    If (Elchart.Series(1).Points(i).YValues(0) * 100) / Elchart.Series(0).Points(i).YValues(0) >= 85 Then
                '        Elchart.Series(1).Points(i).Color = Color.Yellow
                '    End If

                '    Elchart.Series(2).Points(i).SetValueY(valchart)
                '    Elchart.Series(2).Points(i).Color = Color.FromArgb(25, Elchart.Series(1).Points(i).Color)
                '    Elchart.Series(2).Points(i).Label = (valchart * -1).ToString("F2")
                '    If valchart = 0 Then Elchart.Series(2).Points(i).Label = "   "
                'End If
            Next

            Elchart.Series(1).IsValueShownAsLabel = True
            Elchart.Series(1)("BarLabelStyle") = "Center"
            Elchart.Series(1).LabelAngle = 90

            Dim parteactual As String = Elchart.Series(0).Points(0).AxisLabel
            LblChangeOverBlue.Visible = False

            Elchart.ChartAreas(0).AxisX.CustomLabels.Clear()
            Elchart.ChartAreas(0).AxisX2.CustomLabels.Clear()

            Dim cuentahoras As Double = 0

            For i = 0 To Elchart.Series(0).Points.Count - 1
                Elchart.ChartAreas(0).AxisX.CustomLabels.Add(New CustomLabel(i + 0.5, i + 1.5, Elchart.Series(0).Points(i).AxisLabel, 0, LabelMarkStyle.None))
                If Elchart.Series(0).Points(i).AxisLabel <> parteactual Then
                    Elchart.ChartAreas(0).AxisX.CustomLabels(Elchart.ChartAreas(0).AxisX.CustomLabels.Count - 1).ForeColor = Color.Blue
                    LblChangeOverBlue.Visible = True
                End If

                If ds.Tables("Production").DefaultView.Item(i).Item("ENDTIME") Is DBNull.Value Then
                    ''SI ES NULO ES LA HORA ACTUAL
                    If DatePart(DateInterval.Hour, CType(ds.Tables("Production").DefaultView.Item(i).Item("OPENEDDATE"), Date)).ToString = ds.Tables("Production").DefaultView.Item(i).Item("HORA") Then
                        Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(i + 0.5, i + 1.5, CType(ds.Tables("Production").DefaultView.Item(i).Item("OPENEDDATE"), Date).ToString("HH:mm") & " - " & fechaserver.ToString("HH:mm"), 0, LabelMarkStyle.None))
                    Else
                        Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(i + 0.5, i + 1.5, CType(ds.Tables("Production").DefaultView.Item(i).Item("STARTTIME"), Date).ToString("HH:mm") & " - " & fechaserver.ToString("HH:mm"), 0, LabelMarkStyle.None))
                    End If
                Else

                    If Not ds.Tables("Production").DefaultView.Item(i).Item("CLOSEDDATE") Is DBNull.Value Then

                        If DatePart(DateInterval.Hour, CType(ds.Tables("Production").DefaultView.Item(i).Item("CLOSEDDATE"), Date)).ToString = ds.Tables("Production").DefaultView.Item(i).Item("HORA") Then
                            If DatePart(DateInterval.Hour, CType(ds.Tables("Production").DefaultView.Item(i).Item("OPENEDDATE"), Date)).ToString = ds.Tables("Production").DefaultView.Item(i).Item("HORA") Then
                                Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(i + 0.5, i + 1.5, CType(ds.Tables("Production").DefaultView.Item(i).Item("OPENEDDATE"), Date).ToString("HH:mm") & " - " & CType(ds.Tables("Production").DefaultView.Item(i).Item("CLOSEDDATE"), Date).ToString("HH:mm"), 0, LabelMarkStyle.None))
                            Else
                                Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(i + 0.5, i + 1.5, CType(ds.Tables("Production").DefaultView.Item(i).Item("STARTTIME"), Date).ToString("HH:mm") & " - " & CType(ds.Tables("Production").DefaultView.Item(i).Item("CLOSEDDATE"), Date).ToString("HH:mm"), 0, LabelMarkStyle.None))
                            End If
                        Else
                            If DatePart(DateInterval.Hour, CType(ds.Tables("Production").DefaultView.Item(i).Item("OPENEDDATE"), Date)).ToString = ds.Tables("Production").DefaultView.Item(i).Item("HORA") Then
                                Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(i + 0.5, i + 1.5, CType(ds.Tables("Production").DefaultView.Item(i).Item("OPENEDDATE"), Date).ToString("HH:mm") & " - " & CType(ds.Tables("Production").DefaultView.Item(i).Item("ENDTIME"), Date).ToString("HH:mm"), 0, LabelMarkStyle.None))
                            Else
                                Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(i + 0.5, i + 1.5, CType(ds.Tables("Production").DefaultView.Item(i).Item("STARTTIME"), Date).ToString("HH:mm") & " - " & CType(ds.Tables("Production").DefaultView.Item(i).Item("ENDTIME"), Date).ToString("HH:mm"), 0, LabelMarkStyle.None))
                            End If
                        End If

                    Else
                        If Not ds.Tables("Production").DefaultView.Item(i).Item("OPENEDDATE") Is DBNull.Value Then
                            If DatePart(DateInterval.Hour, CType(ds.Tables("Production").DefaultView.Item(i).Item("OPENEDDATE"), Date)).ToString = ds.Tables("Production").DefaultView.Item(i).Item("HORA") Then
                                Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(i + 0.5, i + 1.5, CType(ds.Tables("Production").DefaultView.Item(i).Item("OPENEDDATE"), Date).ToString("HH:mm") & " - " & CType(ds.Tables("Production").DefaultView.Item(i).Item("ENDTIME"), Date).ToString("HH:mm"), 0, LabelMarkStyle.None))
                            Else
                                Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(i + 0.5, i + 1.5, CType(ds.Tables("Production").DefaultView.Item(i).Item("STARTTIME"), Date).ToString("HH:mm") & " - " & CType(ds.Tables("Production").DefaultView.Item(i).Item("ENDTIME"), Date).ToString("HH:mm"), 0, LabelMarkStyle.None))
                            End If
                        Else
                            Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(i + 0.5, i + 1.5, CType(ds.Tables("Production").DefaultView.Item(i).Item("STARTTIME"), Date).ToString("HH:mm") & " - " & CType(ds.Tables("Production").DefaultView.Item(i).Item("ENDTIME"), Date).ToString("HH:mm"), 0, LabelMarkStyle.None))
                        End If
                    End If

                    'If ds.Tables("Production").DefaultView.Item(i).Item("STARTTIME") <> ds.Tables("Production").DefaultView.Item(i).Item("ENDTIME") Then
                    '    If i > 0 Then
                    '        If (ds.Tables("Production").DefaultView.Item(i).Item("Hora") = ds.Tables("Production").DefaultView.Item(i - 1).Item("Hora")) Then
                    '            Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(i + 0.5, i + 1.5, CType(ds.Tables("Production").DefaultView.Item(i).Item("OPENEDDATE"), Date).ToString("HH:mm") & " - " & CType(ds.Tables("Production").DefaultView.Item(i).Item("ENDTIME"), Date).ToString("HH:mm"), 0, LabelMarkStyle.None))
                    '        Else
                    '            Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(i + 0.5, i + 1.5, CType(ds.Tables("Production").DefaultView.Item(i).Item("STARTTIME"), Date).ToString("HH:mm") & " - " & CType(ds.Tables("Production").DefaultView.Item(i).Item("ENDTIME"), Date).ToString("HH:mm"), 0, LabelMarkStyle.None))
                    '        End If
                    '    Else
                    '        Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(i + 0.5, i + 1.5, CType(ds.Tables("Production").DefaultView.Item(i).Item("STARTTIME"), Date).ToString("HH:mm") & " - " & CType(ds.Tables("Production").DefaultView.Item(i).Item("ENDTIME"), Date).ToString("HH:mm"), 0, LabelMarkStyle.None))
                    '    End If
                    'Else
                    '    Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(i + 0.5, i + 1.5, CType(ds.Tables("Production").DefaultView.Item(i).Item("STARTTIME"), Date).ToString("HH:mm") & " - " & CType(ds.Tables("Production").DefaultView.Item(i).Item("CLOSEDDATE"), Date).ToString("HH:mm"), 0, LabelMarkStyle.None))
                    'End If
                End If
                parteactual = Elchart.Series(0).Points(i).AxisLabel

                If ds.Tables("Production").DefaultView.Item(i).Item("SEGUNDOSBREAK") > 0 Then
                    Elchart.ChartAreas(0).AxisX2.CustomLabels(Elchart.ChartAreas(0).AxisX2.CustomLabels.Count - 1).ForeColor = Color.Blue
                End If

            Next

            If Elchart.Series(0).Points.Count > 8 Then
                Dim textohoras As String()
                For i = 0 To Elchart.Series(0).Points.Count - 1
                    textohoras = Elchart.ChartAreas(0).AxisX2.CustomLabels(i).Text.Split("-")
                    Elchart.ChartAreas(0).AxisX2.CustomLabels(i).Text = textohoras(0).Trim & vbCrLf & textohoras(1).Trim
                Next
            End If

            'Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(0.5, 1.5, "06:00 - 07:00", 0, LabelMarkStyle.Box))
            'Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(1.5, 2.5, "07:00 - 08:00", 0, LabelMarkStyle.Box))
            'Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(2.5, 3.5, "08:00 - 09:00", 0, LabelMarkStyle.Box))
            'Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(3.5, 4.5, "09:00 - 10:00", 0, LabelMarkStyle.Box))
            'Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(4.5, 5.5, "10:00 - 11:00", 0, LabelMarkStyle.Box))
            'Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(5.5, 6.5, "10:00 - 11:00", 0, LabelMarkStyle.Box))
            'Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(6.5, 7.5, "11:00 - 12:00", 0, LabelMarkStyle.Box))
            'Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(7.5, 8.5, "12:00 - 13:00", 0, LabelMarkStyle.Box))
            'Elchart.ChartAreas(0).AxisX2.CustomLabels.Add(New CustomLabel(8.5, 9.5, "13:00 - 14:00", 0, LabelMarkStyle.Box))
            'Elchart.ChartAreas(0).AxisX2.IsReversed = True

        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            LblFechaHora.Text = ex.Message
            LblFechaHora.ForeColor = Color.Red

        End Try
    End Sub

    Public Function Decrypt(ByVal cipherText As String) As String
        Try
            Dim passPhrase As String = "MREADOWNTIME123"
            Dim saltValue As String = "vdurazo23"
            Dim hashAlgorithm As String = "SHA1"

            Dim passwordIterations As Integer = 2
            Dim initVector As String = "@1B2c3D4e5F6g7H8"
            Dim keySize As Integer = 256
            ' Convert strings defining encryption key characteristics into byte
            ' arrays. Let us assume that strings only contain ASCII codes.
            ' If strings include Unicode characters, use Unicode, UTF7, or UTF8
            ' encoding.
            Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
            Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)

            ' Convert our ciphertext into a byte array.
            Dim cipherTextBytes As Byte() = Convert.FromBase64String(cipherText)

            ' First, we must create a password, from which the key will be 
            ' derived. This password will be generated from the specified 
            ' passphrase and salt value. The password will be created using
            ' the specified hash algorithm. Password creation can be done in
            ' several iterations.
            Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)

            ' Use the password to generate pseudo-random bytes for the encryption
            ' key. Specify the size of the key in bytes (instead of bits).
            Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)

            ' Create uninitialized Rijndael encryption object.
            Dim symmetricKey As New RijndaelManaged()

            ' It is reasonable to set encryption mode to Cipher Block Chaining
            ' (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC

            ' Generate decryptor from the existing key bytes and initialization 
            ' vector. Key size will be defined based on the number of the key 
            ' bytes.
            Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)

            ' Define memory stream which will be used to hold encrypted data.
            Dim memoryStream As New MemoryStream(cipherTextBytes)

            ' Define cryptographic stream (always use Read mode for encryption).
            Dim cryptoStream As New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)

            ' Since at this point we don't know what the size of decrypted data
            ' will be, allocate the buffer long enough to hold ciphertext;
            ' plaintext is never longer than ciphertext.
            Dim plainTextBytes As Byte() = New Byte(cipherTextBytes.Length - 1) {}

            ' Start decrypting.
            Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)

            ' Close both streams.
            memoryStream.Close()
            cryptoStream.Close()

            ' Convert decrypted data into a string. 
            ' Let us assume that the original plaintext string was UTF8-encoded.
            Dim plainText As String = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)

            ' Return decrypted string.   
            Return plainText
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub TimerDatos_Tick(sender As Object, e As EventArgs) Handles TimerDatos.Tick
        If currentchart = 1 Then
            cargardatos(Chart1)
        Else
            cargardatos(Chart2)
        End If

    End Sub

    Dim currentchart As Integer = 1
    Dim currentslide As Integer = 1
    Private Sub TimerChange_Tick(sender As Object, e As EventArgs) Handles TimerChange.Tick
        If paused Then Exit Sub
        If My.Settings.RESOURCES Is Nothing Then Exit Sub
        If My.Settings.RESOURCES.Rows.Count <= 1 Then Exit Sub
        TimerDatos.Enabled = False
        CurrResIndex = CurrResIndex + 1
        If CurrResIndex > My.Settings.RESOURCES.DefaultView.Count - 1 Then
            If My.Settings.SLIDES.Rows.Count = 0 Then
                ''se resetean los recursos
                CurrResIndex = 0
            Else
                '' se empieza con los slides.
                CurrResIndex = -1

                currentslide = 1
                CurrSlideInex = 0

                TimerSlides.Enabled = True
                TimerChange.Enabled = False
                TimerSlides.Stop()

                TimerSlides_Tick(sender, e)
                ' TimerSlides.Start()

                Exit Sub
            End If

        End If

        If currentchart = 1 Then
            cargardatos(Chart2)
            currentchart = 2

            Dim t2 As New Transition(New TransitionType_EaseInEaseOut(1000))
            AddHandler t2.TransitionCompletedEvent, AddressOf Anim_TransitionCompletedEvent

            Chart2.Left = Me.Width
            Chart2.SendToBack()

            ''el que sale
            Showing.Visible = True
            t2.add(Showing, "Left", 0 - Me.Width)
            t2.run()

            ''El que entra
            Chart2.Visible = True
            Dim T1 As New Transition(New TransitionType_EaseInEaseOut(1000))
            T1.add(Chart2, "Left", 0)
            T1.run()

            Showing = Chart2

        Else
            cargardatos(Chart1)
            currentchart = 1

            Dim t2 As New Transition(New TransitionType_EaseInEaseOut(1000))
            AddHandler t2.TransitionCompletedEvent, AddressOf Anim_TransitionCompletedEvent

            Chart1.Left = Me.Width
            Chart1.SendToBack()

            ''El que sale
            Showing.Visible = True
            t2.add(Showing, "Left", 0 - Me.Width)
            t2.run()

            ''el que entra
            Chart1.Visible = True
            Dim T1 As New Transition(New TransitionType_EaseInEaseOut(1000))
            T1.add(Chart1, "Left", 0)
            T1.run()

            Showing = Chart1
        End If
        TimerChange.Enabled = True
    End Sub

    Public Showing As Object

    Private Sub Anim_TransitionCompletedEvent(sender As Object, e As Transition.Args)
        ''saliente.Visible = False
        TimerDatos.Enabled = True
    End Sub

    Private Sub TimerSlides_Tick(sender As Object, e As EventArgs) Handles TimerSlides.Tick
        If paused Then Exit Sub
        Try

            If CurrSlideInex > My.Settings.SLIDES.Rows.Count - 1 Then
                TimerSlides.Enabled = False
                TimerChange.Enabled = True
                CurrResIndex = -1
                CurrSlideInex = 0
                TimerChange_Tick(sender, e)
                Exit Sub
            End If

            Dim img As Image = Image.FromFile(My.Settings.SLIDES.Rows(CurrSlideInex).Item(0))

            If currentslide = 1 Then
                PicSlide1.Image = img
                PicSlide1.SizeMode = PictureBoxSizeMode.Zoom
                currentslide = 2


                Dim t2 As New Transition(New TransitionType_EaseInEaseOut(1000))
                AddHandler t2.TransitionCompletedEvent, AddressOf Anim_TransitionCompletedEvent

                PicSlide1.Left = Me.Width
                PicSlide1.BringToFront()

                ''el que sale
                Showing.Visible = True
                t2.add(Showing, "Left", 0 - Me.Width)
                t2.run()

                ''El que entra
                PicSlide1.Visible = True
                Dim T1 As New Transition(New TransitionType_EaseInEaseOut(1000))
                T1.add(PicSlide1, "Left", 0)
                T1.run()

                Showing = PicSlide1

            Else
                PicSlide2.Image = img
                PicSlide2.SizeMode = PictureBoxSizeMode.Zoom
                currentslide = 1

                Dim t2 As New Transition(New TransitionType_EaseInEaseOut(1000))
                AddHandler t2.TransitionCompletedEvent, AddressOf Anim_TransitionCompletedEvent

                PicSlide2.Left = Me.Width
                PicSlide2.BringToFront()

                ''el que sale
                Showing.Visible = True
                t2.add(Showing, "Left", 0 - Me.Width)
                t2.run()

                ''El que entra
                PicSlide2.Visible = True
                Dim T1 As New Transition(New TransitionType_EaseInEaseOut(1000))
                T1.add(PicSlide2, "Left", 0)
                T1.run()

                Showing = PicSlide2


            End If
            CurrSlideInex = CurrSlideInex + 1
            img = Nothing
            img.Dispose()

        Catch ex As Exception

        End Try
        TimerSlides.Enabled = True
    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click

    End Sub

    Private Sub TimerFontSize_Tick(sender As Object, e As EventArgs) Handles TimerFontSize.Tick
        LblFontIncrement.Visible = False
        TimerFontSize.Enabled = False
    End Sub

    Private Sub LblCurrentActualValue_Click(sender As Object, e As EventArgs) Handles LblCurrentActualValue.Click

    End Sub

    Private Sub RadRadialGauge2_Click(sender As Object, e As EventArgs) Handles RadRadialGauge2.Click

    End Sub

    Private Sub LblFechaHora_Click(sender As Object, e As EventArgs) Handles LblFechaHora.Click

    End Sub

    Function secondstohourminutesecondA(ByVal seconds As Integer) As String
        Try
            'Dim H, M As Integer
            'H = seconds / 3600
            'seconds = seconds Mod 3600
            'M = seconds / 60
            'seconds = seconds Mod 60
            'Return H.ToString.PadLeft(2, "0"c) + ":" + M.ToString.PadLeft(2, "0"c) + ":" + seconds.ToString.PadLeft(2, "0"c)
            Dim iSpan As TimeSpan = TimeSpan.FromSeconds(seconds)


            Return (iSpan.Hours * 60 + iSpan.Minutes).ToString.PadLeft(2, "0"c) & ":" & _
            iSpan.Seconds.ToString.PadLeft(2, "0"c)


            'Return H.ToString.PadLeft(2, "0"c) + " :" + M.ToString.PadLeft(2, "0"c) + ":" + seconds.ToString.PadLeft(2, "0"c)
        Catch ex As Exception
        End Try
        Return ""
    End Function

End Class
