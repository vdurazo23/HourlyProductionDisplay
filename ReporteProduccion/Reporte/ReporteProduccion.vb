Imports Telerik.WinControls.UI
Imports System.Data.SqlClient
Imports Telerik.WinControls

Public Class ReporteProduccion
    Public RecursoDatarow() As DataRow
    Dim ProductionDataTable As DataTable
    Public DownTimeDatatable As DataTable
    Public MARSDownTimeDataTable As DataTable
    Public AdjustmentsDatatable As DataTable
    Public PlannedDownTimeDatatable As DataTable
    Dim ReworkDatatable As DataTable
    Dim ReportDetailTable As DataTable

    Public CurrentProductionDate As Date
    Public CurrentShiftName As String
    Dim CurrentMARSHour As Integer

    Dim reworkrowindex As Integer
    Dim downtimerowindex As Integer
    Dim ajustesrowindex As Integer
    Dim planneddowntimerowindex As Integer

    Dim ShiftLength As Double    ''DURACIÓN DEL TURNO DE INICIO A FIN6-2 (8 HRS)
    Dim PlannedProductionTime As Double    'TIEMPO PLANEADO DE PRODUCCION DURACION DEL TURNO - PAROS PLANEADOS (8 HRS - 30 MINS COMIDA = 7.5 HRS)
    Dim OperatingTime As Double     'TIEMPO DE OPERACION = TIEMPO PLANEADO DE PRODUCCION - PAROS NO PLANEADOS

    Dim UnplannedDowntime As Double    'TOTAL DE PAROS NO PLANEADOS  (DOWNTIME)
    Dim TotalPlannedDowntime As Double  'TOTAL PAROS PLANEADOS (BREADKS SHUTDOWNS ETC)

    Dim TotalPartsProduced As Integer
    Dim TotalRejected As Integer

    Dim ShiftStartTime As DateTime
    Dim ShiftEndTime As DateTime
    Dim currentTime As DateTime

    Dim Availability As Double
    Dim Performance As Double
    Dim Quality As Double
    Dim OEE As Double

    Dim JPH As Integer
    Dim CycleTime As Double

    Dim LstShiftTimes As List(Of DateTime)

    Dim CurrentSelectedrow As Integer = -1
    Dim CurrentSelectedCell As Integer = -1

    Public IscurrentShift As Boolean
    Dim GaugeIndicator As New AquaControls.AquaGauge

    Public ELID As Integer = -1
    Public Editar As Boolean = False

    Dim FormatoFecha As String

    Dim gridpopulated As Boolean = False

    Private Sub ReporteProduccion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        guardarreporte()
    End Sub

    Private Sub Reporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Captura") Then
                BtnSave.Enabled = False
            End If

            FormatoFecha = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
            BtnDetails_Click(sender, e)
            GaugeIndicator.Font = New Font(Font.FontFamily, 14)
            GaugeIndicator.DialText = "OEE"
            GaugeIndicator.MaxValue = 100
            GaugeIndicator.MinValue = 0
            GaugeIndicator.NoOfDivisions = 10
            GaugeIndicator.NoOfSubDivisions = 5
            GaugeIndicator.RecommendedValue = 92.5
            GaugeIndicator.ThresholdPercent = 15
            GaugeIndicator.RecommendedValue2 = 40
            GaugeIndicator.ThresholdPercent2 = 80
            GaugeIndicator.RecommendedValue3 = 82.5
            GaugeIndicator.ThresholdPercent3 = 5
            PanelGauge.Controls.Add(GaugeIndicator)

            GaugeIndicator.Size = PanelGauge.Size

            Me.Text = RecursoDatarow(0).Item("Name").ToString

            'If IscurrentShift Then CurrentProductionDate = SQLCon.GetMARSProductionDate(RecursoDatarow(0).Item("ID"), RecursoDatarow(0).Item("SubResourceId"))
            'If IscurrentShift Then CurrentShiftName = SQLCon.GetMARSProductionShiftName(RecursoDatarow(0).Item("ID"), RecursoDatarow(0).Item("SubResourceId"))

            Timer1.Enabled = True
            cargardatos()

            ELID = SQLCon.GetReportID(RecursoDatarow(0).Item("ID"), CurrentProductionDate, CurrentShiftName)
            If ELID > 0 Then Editar = True
            If Editar And SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Eliminar") Then BtnDelete.Enabled = True

            ''DEPENDENCY :   ........
            'If IscurrentShift Then SqlDependencyStart()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

    Sub cargardatos()
        Try
            '
            cargarproduccionmars()
            '
            cargaradjustments()
            'MsgBox("1 Ok")
            cargardowntime()
            'MsgBox("2 Ok")
            cargarplannedDowntime()
            'MsgBox("3 Ok")
            importardowntime()

            CargarRework()
            'MsgBox("4 Ok")
            Getdetails()
            'MsgBox("5 Ok")
            If Editar And SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Eliminar") Then BtnDelete.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Sub importardowntime()
        Try
            Dim Temp As DataRow()
            Temp = MARSDownTimeDataTable.Select()
            Dim Dtdt As DataRow()
            Dim PDtdt As DataRow()

            For Each dr As DataRow In Temp
                Dtdt = DownTimeDatatable.Select("DT_Id=" & dr("ID").ToString)
                PDtdt = PlannedDownTimeDatatable.Select("DT_Id=" & dr("ID").ToString)
                If Dtdt.Length > 0 Or PDtdt.Length > 0 Then
                    ''ya existe no duplicar
                Else
                    ''No existe Agregar
                    'dt.ShiftName = CurrentShiftName
                    'dt.ProductionDate = CurrentProductionDate
                    'dt.AssetID = RecursoDatarow(0).Item("ID")
                    'dt.currenthour = CurrentMARSHour                    
                    Dim _Hour, _StartTime, _EndTime, _TempEndTime As DateTime
                    Dim _Segundos As Integer
                    Dim _Minutos As Double
                    _Hour = dr("StartTime")
                    _StartTime = dr("StartTime")
                    _EndTime = dr("EndTime")

                    _Segundos = DateDiff(DateInterval.Second, dr("StartTime"), dr("EndTime"))
                    _Minutos = _Segundos / 60
                    If dr("diechange") = True Then
                        If _Minutos > 18 Then
                            ''SI ES UN DIECHANGE ENTONCES SE GUARDA EN LA HORA QUE SE TERMINÓ EL CHANGE OVER (POR SI TARDA MAS DE UNA HORA)
                            SQLCon.NewDowntime(RecursoDatarow(0).Item("ID"), CurrentProductionDate.ToString("MM/dd/yyyy"), CurrentShiftName, _EndTime.ToString("MM/dd/yyyy HH:00:00"), -1, -1, _Minutos - 15, "ChangeOver", dr("PartNumber").ToString, _StartTime.ToString("MM/dd/yyyy HH:mm:ss"), _EndTime.ToString("MM/dd/yyyy HH:mm:ss"), dr("ID"))
                        End If
                    Else
                        If _Minutos >= 3 Then
                            'If (DatePart(DateInterval.Hour, _EndTime) <> DatePart(DateInterval.Hour, _StartTime)) Then
                            '    'Hay que separar el dt en los minutos que corresponden a cada hora
                            '    _TempEndTime = Convert.ToDateTime(_EndTime.ToString("MM/dd/yyy") & " " & DatePart(DateInterval.Hour, _StartTime).ToString & ":00:00")
                            'Else
                            ''Como va
                            SQLCon.NewDowntime(RecursoDatarow(0).Item("ID"), CurrentProductionDate.ToString("MM/dd/yyyy"), CurrentShiftName, _Hour.ToString("MM/dd/yyyy HH:00:00"), -1, -1, _Minutos, "", dr("PartNumber").ToString, _StartTime.ToString("MM/dd/yyyy HH:mm:ss"), _EndTime.ToString("MM/dd/yyyy HH:mm:ss"), dr("ID"))
                            ' End If
                        End If
                    End If
                End If
            Next
            ''MsgBox("Importar Tiemo Muerto Ha finalizado correctamente", MsgBoxStyle.Information, "Importar")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            cargardowntime()
            cargarplannedDowntime()
            'adddetails()
        End Try
    End Sub

    Sub cargarproduccionmars()
        Try
            'If IscurrentShift Then

            LstShiftTimes = SQLCon.GetMARSDateTimes(RecursoDatarow(0).Item("ID"), CurrentShiftName, CurrentProductionDate)

            ShiftStartTime = Convert.ToDateTime(CurrentProductionDate.ToString(FormatoFecha) & " " & LstShiftTimes(0).Hour & ":" & LstShiftTimes(0).Minute & ":" & LstShiftTimes(0).Second)
            ShiftEndTime = Convert.ToDateTime(CurrentProductionDate.ToString(FormatoFecha) & " " & LstShiftTimes(1).Hour & ":" & LstShiftTimes(1).Minute & ":" & LstShiftTimes(1).Second)

            If ShiftStartTime > ShiftEndTime Then
                ShiftEndTime = ShiftEndTime.AddDays(1)
                ''ShiftStartTime = ShiftStartTime.AddDays(-1)
            End If

            currentTime = LstShiftTimes(2)

            If (SQLCon.GetMARSProductionDate(RecursoDatarow(0).Item("ID"), RecursoDatarow(0).Item("SubResourceId")) <> CurrentProductionDate) Or (SQLCon.GetMARSProductionShiftName(RecursoDatarow(0).Item("ID"), RecursoDatarow(0).Item("SubResourceId")) <> CurrentShiftName) Then
                Console.Write("Ya paso")
                IscurrentShift = False
            End If

            'Else
            '    Dim tblshifttimes As DataTable
            '    tblshifttimes = SQLCon.GetMARSShifts(RecursoDatarow(0).Item("ID"), CurrentProductionDate)

            '    tblshifttimes.DefaultView.RowFilter = "Name='" & CurrentShiftName & "'"

            '    LstShiftTimes.Add(tblshifttimes.DefaultView.Item(0).Item(""))

            'End If

            CurrentMARSHour = CInt(LstShiftTimes(2).ToString("HH"))

            ProductionDataTable = SQLCon.GetMARSProduction(RecursoDatarow(0).Item("ID"), RecursoDatarow(0).Item("SubResourceId"), ShiftEndTime.ToString("MM/dd/yyyy HH:mm:ss"), CurrentProductionDate.ToString("MM/dd/yyyy"), CurrentShiftName)

            If Not IsDBNull(RecursoDatarow(0).Item("UseTheoretical")) Then
                If RecursoDatarow(0).Item("UseTheoretical") = True Then
                    ''CAMBIAR EL RATE AL TEORICO
                    Dim Rateteorico As Integer
                    For i = 0 To ProductionDataTable.DefaultView.Count - 1
                        Rateteorico = SQLCon.GetCMSTheoricalRate(ProductionDataTable.DefaultView.Item(i).Item("PartNumber"), RecursoDatarow(0).Item("DepartmentCode"), RecursoDatarow(0).Item("ResourceCode"))
                        If Rateteorico > 0 Then
                            ProductionDataTable.DefaultView.Item(i).Item("RUNRATE") = Rateteorico
                        End If
                    Next
                End If
            End If


            MARSDownTimeDataTable = SQLCon.GetMARSDowntime(RecursoDatarow(0).Item("ID"), RecursoDatarow(0).Item("SubResourceId"), ShiftEndTime.ToString("MM/dd/yyyy HH:mm:ss"), CurrentProductionDate.ToString("MM/dd/yyyy"), CurrentShiftName)


            Dim _part As String
            For i = 0 To ProductionDataTable.DefaultView.Count - 1
                _part = ProductionDataTable.DefaultView.Item(i).Item("PARTNUMBER").ToString



            Next

            GridProduction.DataSource = Nothing
            GridProduction.DataSource = ProductionDataTable.DefaultView

            If ProductionDataTable.DefaultView.Count = 0 Then


            End If



            'For i = 0 To partesdt.DefaultView.Count - 1
            '    GridDetalle.Rows.Add(partesdt.DefaultView.Item(i).Item(0).ToString, partesdt.DefaultView.Item(i).Item(1).ToString)
            '    JPH = partesdt.DefaultView.Item(i).Item(1)
            'Next

            'For i = 0 To GridDetalle.Rows.Count - 1
            '    For j = 2 To GridDetalle.Columns.Count - 1
            '        If GridDetalle.Columns(j).HeaderText.StartsWith("H") Or GridDetalle.Columns(j).HeaderText.StartsWith("T") Then
            '            If GridDetalle.Columns(j).HeaderText.StartsWith("H") Then GridDetalle.Columns(j).IsVisible = False
            '        Else
            '            GridDetalle.Columns(j).IsVisible = True
            '            'If Convert.ToDateTime(GridDetalle.Columns(j).Tag).AddHours(1) > Convert.ToDateTime(Convert.ToDateTime(GridDetalle.Columns(j).Tag).ToString("MM/dd/yyyy") & " " & LstShiftTimes(1).ToString("HH:mm:ss")) Then GridDetalle.Columns(j).IsVisible = False
            '            ProductionDataTable.DefaultView.RowFilter = "PartNumber='" & GridDetalle.Rows(i).Cells(0).Value.ToString & "' and Hora=" & Convert.ToDateTime(GridDetalle.Columns(j).Tag(0)).Hour
            '            If ProductionDataTable.DefaultView.Count > 0 Then
            '                GridDetalle.Rows(i).Cells(j).Value = ProductionDataTable.DefaultView.Item(0).Item("TOTAL")
            '            End If
            '        End If
            '    Next

            '    ProductionDataTable.DefaultView.RowFilter = ""
            '    GridDetalle.Rows(i).Cells("TOTAL").Value = ProductionDataTable.Compute("Sum(Total)", "PartNumber='" & GridDetalle.Rows(i).Cells(0).Value.ToString & "'")
            'Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub cargaradjustments()
        Try
            AdjustmentsDatatable = SQLCon.GetAdjustments(RecursoDatarow(0).Item("ID"), CurrentProductionDate, CurrentShiftName)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub cargardowntime()
        Try

            DownTimeDatatable = SQLCon.GetDowntime(RecursoDatarow(0).Item("ID"), CurrentProductionDate, CurrentShiftName)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Sub loadgridAdjustments()
        Try
            AdjustmentsDatatable.DefaultView.RowFilter = ""
            GridAdjustments.DataSource = Nothing
            GridAdjustments.DataSource = AdjustmentsDatatable.DefaultView
            ''GRUPOS
            GridAdjustments.AutoExpandGroups = False
            GridAdjustments.EnableGrouping = True
            GridAdjustments.GroupDescriptors.Clear()
            GridAdjustments.GroupDescriptors.Add("Hour", System.ComponentModel.ListSortDirection.Ascending)

            ''SUMMARY
            GridAdjustments.SummaryRowsBottom.Clear()
            GridAdjustments.MasterTemplate.ShowTotals = True
            GridAdjustments.MasterTemplate.ShowGroupedColumns = True

            Dim summaryItemShipName As New GridViewSummaryItem("PartNumber", "Cuenta: {0}", GridAggregateFunction.Count)
            Dim summaryItemFreight As New GridViewSummaryItem("Quantity", "Total = {0} ", GridAggregateFunction.Sum)
            Dim summaryRowItem As New GridViewSummaryRowItem()
            summaryRowItem.Add(summaryItemFreight)
            summaryRowItem.Add(summaryItemShipName)
            Me.GridAdjustments.SummaryRowsBottom.Add(summaryRowItem)


            GridAdjustments.AutoExpandGroups = True

            For Each column As Telerik.WinControls.UI.GridViewDataColumn In GridAdjustments.Columns
                column.BestFit()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Sub LoadGridDowntime()
        Try
            DownTimeDatatable.DefaultView.RowFilter = ""
            GridDownTime.DataSource = Nothing
            GridDownTime.DataSource = DownTimeDatatable.DefaultView

            ''GRUPOS
            GridDownTime.AutoExpandGroups = False
            GridDownTime.EnableGrouping = True
            GridDownTime.GroupDescriptors.Clear()
            GridDownTime.GroupDescriptors.Add("Hour", System.ComponentModel.ListSortDirection.Ascending)

            ''SUMMARY
            GridDownTime.SummaryRowsBottom.Clear()
            GridDownTime.MasterTemplate.ShowTotals = True
            GridDownTime.MasterTemplate.ShowGroupedColumns = True

            Dim summaryItemShipName As New GridViewSummaryItem("Description", "Cuenta: {0}", GridAggregateFunction.Count)
            Dim summaryItemFreight As New GridViewSummaryItem("minutes", "Total = {0} min", GridAggregateFunction.Sum)
            Dim summaryRowItem As New GridViewSummaryRowItem()
            summaryRowItem.Add(summaryItemFreight)
            summaryRowItem.Add(summaryItemShipName)
            Me.GridDownTime.SummaryRowsBottom.Add(summaryRowItem)


            GridDownTime.AutoExpandGroups = True

            For Each column As Telerik.WinControls.UI.GridViewDataColumn In GridDownTime.Columns
                column.BestFit()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CargarRework()
        Try
            ReworkDatatable = SQLCon.GetRework(RecursoDatarow(0).Item("ID"), CurrentProductionDate, CurrentShiftName)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub LoadGridRework()
        Try
            GridRework.DataSource = Nothing
            GridRework.DataSource = ReworkDatatable.DefaultView

            ''GRUPOS
            GridRework.AutoExpandGroups = False
            GridRework.EnableGrouping = True
            GridRework.GroupDescriptors.Clear()
            GridRework.GroupDescriptors.Add("Hour", System.ComponentModel.ListSortDirection.Ascending)

            ''SUMMARY
            GridRework.SummaryRowsBottom.Clear()
            GridRework.MasterTemplate.ShowTotals = True
            GridRework.MasterTemplate.ShowGroupedColumns = True

            Dim summaryItemFreight As New GridViewSummaryItem("Quantity", "Total = {0}", GridAggregateFunction.Sum)
            Dim summaryRowItem As New GridViewSummaryRowItem()
            summaryRowItem.Add(summaryItemFreight)

            Me.GridRework.SummaryRowsBottom.Add(summaryRowItem)

            GridRework.AutoExpandGroups = True
            For Each column As Telerik.WinControls.UI.GridViewDataColumn In GridRework.Columns
                column.BestFit()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cargarplannedDowntime()
        Try
            PlannedDownTimeDatatable = SQLCon.GetPlannedDT(RecursoDatarow(0).Item("ID"), CurrentProductionDate, CurrentShiftName)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub loadGridPlannedDt()
        Try
            PlannedDownTimeDatatable.DefaultView.RowFilter = ""
            GridPlannedDT.DataSource = Nothing
            GridPlannedDT.DataSource = PlannedDownTimeDatatable.DefaultView

            ''GRUPOS
            GridPlannedDT.AutoExpandGroups = False
            GridPlannedDT.EnableGrouping = True
            GridPlannedDT.GroupDescriptors.Clear()
            GridPlannedDT.GroupDescriptors.Add("Hour", System.ComponentModel.ListSortDirection.Ascending)

            ''SUMMARY
            GridPlannedDT.SummaryRowsBottom.Clear()
            GridPlannedDT.MasterTemplate.ShowTotals = True
            GridPlannedDT.MasterTemplate.ShowGroupedColumns = True

            Dim summaryItemShipName As New GridViewSummaryItem("Description", "Cuenta: {0}", GridAggregateFunction.Count)
            Dim summaryItemFreight As New GridViewSummaryItem("minutes", "Total = {0} min", GridAggregateFunction.Sum)
            Dim summaryRowItem As New GridViewSummaryRowItem()
            summaryRowItem.Add(summaryItemFreight)
            summaryRowItem.Add(summaryItemShipName)
            Me.GridPlannedDT.SummaryRowsBottom.Add(summaryRowItem)

            GridPlannedDT.AutoExpandGroups = True
            For Each column As Telerik.WinControls.UI.GridViewDataColumn In GridPlannedDT.Columns
                column.BestFit()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Sub Getdetails()
        Dim start As DateTime
        start = Now
        Try
            Dim horasdt As DataTable
            Dim partesdt As DataTable
            Dim Horainicio As DateTime
            Dim Horafin As DateTime
            Dim currpart As String = ""
            Dim CURROPENEDDATE As DateTime
            Dim OpenedDate As DateTime
            Dim ClosedDate As DateTime
            Dim TotalSegundos As Integer
            Dim TOTALPart As Integer
            Dim TotalAjuste As Integer
            GridTemp.Rows.Clear()
            Dim PartDt() As DataRow

            loadgridAdjustments()
            LoadGridDowntime()
            LoadGridRework()
            loadGridPlannedDt()
            If ProductionDataTable.DefaultView.Count = 0 Then
                ELID = SQLCon.GetReportID(RecursoDatarow(0).Item("ID"), CurrentProductionDate, CurrentShiftName)
                If ELID <> 0 Then
                    ''SI ENTRA X AQUI ES QUE NO HAY DATOS DE MARS PERO SI EXISTE UN REPORTE GUARDADO
                    ''ENTONCES CARGAR TODO DE SQL Y SALTAR LO DE MARS.
                    ReportDetailTable = SQLCon.GetReportDetails(ELID)
                    Dim r As Integer
                    For r = 0 To DateDiff(DateInterval.Hour, ShiftStartTime, ShiftEndTime) - 1
                        Dim lsthorainiciofin As New List(Of DateTime)
                        lsthorainiciofin.Add(ShiftStartTime.AddHours(r))
                        lsthorainiciofin.Add(ShiftStartTime.AddHours(r).AddMinutes(60))

                        GridTemp.Columns(r + 2).HeaderText = lsthorainiciofin(0).ToString("hh:mm") & " - " & lsthorainiciofin(1).ToString("hh:mm tt")
                        GridTemp.Columns(r + 2).Tag = lsthorainiciofin
                        GridTemp.Columns(r + 2).IsVisible = True
                    Next

                    TotalPartsProduced = ReportDetailTable.Compute("Sum(TOTAL)", "")
                    If AdjustmentsDatatable.DefaultView.Count > 0 Then
                        ''si hay ajustes hay que sumarlos
                        TotalPartsProduced = TotalPartsProduced + AdjustmentsDatatable.Compute("Sum(Quantity)", "")
                    End If

                    If DownTimeDatatable.DefaultView.Count > 0 Then
                        UnplannedDowntime = DownTimeDatatable.Compute("Sum(Minutes)", "")
                    Else
                        UnplannedDowntime = 0
                    End If
                    If PlannedDownTimeDatatable.DefaultView.Count > 0 Then
                        TotalPlannedDowntime = PlannedDownTimeDatatable.Compute("sum(minutes)", "") 'ProductionDataTable.Compute("Sum(SEGUNDOSBREAK)", "")
                    Else
                        TotalPlannedDowntime = 0
                    End If
                    If ReworkDatatable.DefaultView.Count > 0 Then
                        TotalRejected = ReworkDatatable.Compute("sum(Quantity)", "")
                    Else
                        TotalRejected = 0
                    End If

                    ShiftLength = (DateDiff(DateInterval.Second, ShiftStartTime, IIf(currentTime > ShiftEndTime, ShiftEndTime, currentTime))) / 3600

                    For i = 0 To ReportDetailTable.DefaultView.Count - 1
                        If ReportDetailTable.DefaultView.Item(i).Item("PART") <> currpart Or ReportDetailTable.DefaultView.Item(i).Item("START") <> CURROPENEDDATE Then
                            ''nueva parte
                            currpart = ReportDetailTable.DefaultView.Item(i).Item("PART")
                            CURROPENEDDATE = ReportDetailTable.DefaultView.Item(i).Item("START")
                            GridTemp.Rows.Add(currpart, ReportDetailTable.DefaultView.Item(i).Item("JPH"), ReportDetailTable.DefaultView.Item(i).Item("H1"), ReportDetailTable.DefaultView.Item(i).Item("H2"), ReportDetailTable.DefaultView.Item(i).Item("H3"), ReportDetailTable.DefaultView.Item(i).Item("H4"), ReportDetailTable.DefaultView.Item(i).Item("H5"), ReportDetailTable.DefaultView.Item(i).Item("H6"), ReportDetailTable.DefaultView.Item(i).Item("H7"), ReportDetailTable.DefaultView.Item(i).Item("H8"), ReportDetailTable.DefaultView.Item(i).Item("H9"), ReportDetailTable.DefaultView.Item(i).Item("H10"), ReportDetailTable.DefaultView.Item(i).Item("H11"), ReportDetailTable.DefaultView.Item(i).Item("H12"), ReportDetailTable.DefaultView.Item(i).Item("H13"), ReportDetailTable.DefaultView.Item(i).Item("H14"), ReportDetailTable.DefaultView.Item(i).Item("TOTAL"), ReportDetailTable.DefaultView.Item(i).Item("Start"), ReportDetailTable.DefaultView.Item(i).Item("End"), ReportDetailTable.DefaultView.Item(i).Item("Hours"), ReportDetailTable.DefaultView.Item(i).Item("PPT"), ReportDetailTable.DefaultView.Item(i).Item("OT"), ReportDetailTable.DefaultView.Item(i).Item("Downtime"), ReportDetailTable.DefaultView.Item(i).Item("PlannedDowntime"), ReportDetailTable.DefaultView.Item(i).Item("Rejected"))
                            TOTALPart = ReportDetailTable.Compute("Sum(Total)", "Part='" & currpart & "' and Start='" & CType(ReportDetailTable.DefaultView.Item(i).Item("start"), DateTime).ToString(FormatoFecha & " HH:mm:ss.fff") & "'")
                            TotalAjuste = 0
                            If Not IsDBNull(AdjustmentsDatatable.Compute("Sum(Quantity)", "PartNumber='" & currpart & "'")) Then
                                TotalAjuste = AdjustmentsDatatable.Compute("Sum(Quantity)", "PartNumber='" & currpart & "'")
                                TOTALPart = TOTALPart + TotalAjuste
                            End If

                            Dim oeeloc As Double
                            Dim LocDowntime As Double
                            'LocDowntime = DownTimeDatatable.Compute("sum(minutes)", "PartNumber='" & currpart & "' and Hour>=" & OpenedDate.ToString("HH") & " And Hour<=" & ClosedDate.ToString("HH"))

                            If GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Downtime").Value Is Nothing Then GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Downtime").Value = 0
                            If GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Planneddowntime").Value Is Nothing Then GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Planneddowntime").Value = 0
                            If GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Rejected").Value Is Nothing Then GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Rejected").Value = 0

                            JPH = GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("JPH").Value

                            TotalSegundos = ReportDetailTable.DefaultView.Item(i).Item("Hours") * 3600

                            oeeloc = CalculateOEE(TotalSegundos / 3600, GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Downtime").Value, GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Planneddowntime").Value, GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Rejected").Value, TOTALPart)

                            GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Hours").Value = (TotalSegundos / 3600).ToString
                            GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("PPT").Value = PlannedProductionTime
                            GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("OT").Value = OperatingTime
                            GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Availability").Value = Availability.ToString
                            GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Performance").Value = Performance.ToString
                            GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Quality").Value = Quality.ToString
                            GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("OEE").Value = oeeloc.ToString
                        End If
                    Next
                End If
            Else
                horasdt = ProductionDataTable.DefaultView.ToTable(True, "STARTTIME")
                partesdt = ProductionDataTable.DefaultView.ToTable(True, "PartNumber", "RUNRATE")

                ' ''Validar si le faltaron horas al MARS
                'Do While (horasdt.DefaultView.Item(horasdt.DefaultView.Count - 1)(0) < ShiftEndTime.AddHours(-1))
                '    horasdt.Rows.Add(CType(horasdt.DefaultView.Item(horasdt.DefaultView.Count - 1)(0), DateTime).AddHours(1))
                'Loop

                For i = 0 To horasdt.DefaultView.Count - 1
                    Dim lsthorainiciofin As New List(Of DateTime)
                    lsthorainiciofin.Add(horasdt.DefaultView.Item(i).Item(0))
                    Horafin = Convert.ToDateTime(horasdt.DefaultView.Item(i).Item(0)).AddMinutes(60 - Convert.ToDateTime(horasdt.DefaultView.Item(i).Item(0)).Minute)
                    lsthorainiciofin.Add(Horafin)
                    GridTemp.Columns(i + 2).HeaderText = lsthorainiciofin(0).ToString("hh:mm") & " - " & lsthorainiciofin(1).ToString("hh:mm tt")
                    GridTemp.Columns(i + 2).Tag = lsthorainiciofin
                    GridTemp.Columns(i + 2).IsVisible = True
                Next

                


                TotalPartsProduced = ProductionDataTable.Compute("Sum(TOTAL)", "")
                If AdjustmentsDatatable.DefaultView.Count > 0 Then
                    ''si hay ajustes hay que sumarlos
                    TotalPartsProduced = TotalPartsProduced + +AdjustmentsDatatable.Compute("Sum(Quantity)", "")
                End If
                If DownTimeDatatable.DefaultView.Count > 0 Then
                    UnplannedDowntime = DownTimeDatatable.Compute("Sum(Minutes)", "")
                Else
                    UnplannedDowntime = 0
                End If
                CycleTime = 60 / JPH

                If PlannedDownTimeDatatable.DefaultView.Count > 0 Then
                    TotalPlannedDowntime = PlannedDownTimeDatatable.Compute("sum(minutes)", "") 'ProductionDataTable.Compute("Sum(SEGUNDOSBREAK)", "")
                Else
                    TotalPlannedDowntime = 0
                End If

                If ReworkDatatable.DefaultView.Count > 0 Then
                    TotalRejected = ReworkDatatable.Compute("sum(Quantity)", "")
                Else
                    TotalRejected = 0
                End If

                ShiftLength = (DateDiff(DateInterval.Second, ShiftStartTime, IIf(currentTime > ShiftEndTime, ShiftEndTime, currentTime))) / 3600

                ProductionDataTable.DefaultView.RowFilter = ""

                For i = 0 To ProductionDataTable.DefaultView.Count - 1
                    If ProductionDataTable.DefaultView.Item(i).Item("PARTNUMBER") <> currpart Or ProductionDataTable.DefaultView.Item(i).Item("OPENEDDATE") <> CURROPENEDDATE Then  ' 
                        ''nueva parte

                        currpart = ProductionDataTable.DefaultView.Item(i).Item("PARTNUMBER")
                        CURROPENEDDATE = ProductionDataTable.DefaultView.Item(i).Item("OPENEDDATE")

                        Dim BreaksMARS As Integer
                        BreaksMARS = ProductionDataTable.Compute("count(OPENEDDATE)", "PARTNUMBER='" & currpart & "'")

                        If BreaksMARS > 1 Then
                            ''TIENE AL MENOS DOS VECES ABIERTO EL MISMO NRO. OpenedDate = CType(ProductionDataTable.Compute("MIN(OPENEDDATE)", "PARTNUMBER='" & currpart & "'"), DateTime).ToString(FormatoFecha & " HH:mm:ss.fff")    ClosedDate = CType(ProductionDataTable.Compute("MAX(CLOSEDDATE)", "PARTNUMBER='" & currpart & "'"), DateTime).ToString(FormatoFecha & " HH:mm:ss.fff")
                        End If

                        OpenedDate = CType(ProductionDataTable.DefaultView.Item(i).Item("OPENEDDATE"), DateTime).ToString(FormatoFecha & " HH:mm:ss.fff")

                        If i = 0 Then OpenedDate = CType(ProductionDataTable.DefaultView.Item(i).Item("STARTTIME"), DateTime).ToString(FormatoFecha & " HH:mm:ss.fff")
                        If (String.IsNullOrEmpty(ProductionDataTable.DefaultView.Item(i).Item("CLOSEDDATE").ToString)) Then
                            ClosedDate = LstShiftTimes(2)
                        Else
                            ClosedDate = CType(ProductionDataTable.DefaultView.Item(i).Item("CLOSEDDATE"), DateTime).ToString(FormatoFecha & " HH:mm:ss.fff")
                        End If


                        ''Corregir openeddate de mars si está mal
                        If i > 0 Then
                            If OpenedDate <> CType(GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("End").Value, DateTime) Then
                                OpenedDate = CType(GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("End").Value, DateTime)
                            End If
                        End If

                        Dim mismaparte As Boolean = False
                        'Corregir cuando es un cambio al mismo no. de parte
                        If GridTemp.Rows.Count = 0 Then
                            GridTemp.Rows.Add(currpart, ProductionDataTable.DefaultView.Item(i).Item("RUNRATE")) ', , , ,oeeloc.ToString, )
                        Else
                            If GridTemp.Rows(GridTemp.Rows.Count - 1).Cells(0).Value = currpart Then
                                ''Es la misma parte entonces no hay que volver a agregarla
                                mismaparte = True
                            Else
                                GridTemp.Rows.Add(currpart, ProductionDataTable.DefaultView.Item(i).Item("RUNRATE")) ', , , ,oeeloc.ToString, )
                            End If
                        End If
                        OpenedDate = CType(OpenedDate.ToString(FormatoFecha & " HH:mm:ss.fff"), DateTime)
                        If mismaparte Then
                            ''entonces el opened date es el anterior
                            OpenedDate = GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Start").Value
                        End If

                        PartDt = Nothing

                        If (String.IsNullOrEmpty(ProductionDataTable.DefaultView.Item(i).Item("CLOSEDDATE").ToString)) Then
                            PartDt = ProductionDataTable.Select("PARTNUMBER='" & currpart & "' AND OPENEDDATE>='" & OpenedDate.ToString(FormatoFecha & " HH:mm:ss.fff") & "' AND ((CLOSEDDATE<='" & ClosedDate.ToString(FormatoFecha & " HH:mm:ss.fff") & "') OR CLOSEDDATE IS NULL)")
                        Else
                            PartDt = ProductionDataTable.Select("PARTNUMBER='" & currpart & "' AND OPENEDDATE>='" & OpenedDate.ToString(FormatoFecha & " HH:mm:ss.fff") & "' AND ((CLOSEDDATE<='" & ClosedDate.ToString(FormatoFecha & " HH:mm:ss.fff") & "') )")
                        End If

                        For Y = 0 To PartDt.Count - 1
                            For z = 2 To 15
                                If Not GridTemp.Columns(z).Tag Is Nothing Then
                                    If GridTemp.Columns(z).Tag(0) = PartDt(Y)("STARTTIME") Then
                                        GridTemp.Rows(GridTemp.Rows.Count - 1).Cells(z).Value = PartDt(Y)("Total")
                                        Dim ajuste As Integer
                                        ''If Not IsDBNull(AdjustmentsDatatable.Compute("Sum(Quantity)", "PartNumber = '" & currpart & "' AND hour>='" & CType(GridTemp.Columns(z).Tag(0), DateTime).ToString(FormatoFecha & " HH:mm:ss") & "' And hour<='" & CType(GridTemp.Columns(z).Tag(1), DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'")) Then
                                        If Not IsDBNull(AdjustmentsDatatable.Compute("Sum(Quantity)", "PartNumber = '" & currpart & "' AND hour = '" & CType(GridTemp.Columns(z).Tag(0), DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'")) Then
                                            ajuste = AdjustmentsDatatable.Compute("Sum(Quantity)", "PartNumber = '" & currpart & "' AND hour>='" & CType(GridTemp.Columns(z).Tag(0), DateTime).ToString(FormatoFecha & " HH:mm:ss") & "' And hour<='" & CType(GridTemp.Columns(z).Tag(1), DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'")
                                            '''solo de la hora inicial si no se duplica
                                            ajuste = AdjustmentsDatatable.Compute("Sum(Quantity)", "PartNumber = '" & currpart & "' AND hour ='" & CType(GridTemp.Columns(z).Tag(0), DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'")
                                            GridTemp.Rows(GridTemp.Rows.Count - 1).Cells(z).Value = PartDt(Y)("Total") + ajuste
                                            GridTemp.Rows(GridTemp.Rows.Count - 1).Cells(z).Tag = ajuste
                                        End If
                                        GridTemp.Columns(z).IsVisible = True
                                    Else
                                        'z = z + 1
                                        Console.Write("XX")
                                        GridTemp.Columns(z).IsVisible = True
                                    End If
                                End If
                            Next
                        Next

                        'If ClosedDate > ShiftEndTime Then
                        '    ClosedDate = ShiftEndTime
                        'End If

                        ClosedDate = CType(ClosedDate.ToString(FormatoFecha & " HH:mm:ss.fff"), DateTime)

                        ''Corregir ClosedDate de MArs si biene mal                       
                        ''Si el closed date es mayor que el shiftend solo tomar hasta el shiftend
                        TotalSegundos = DateDiff(DateInterval.Second, OpenedDate, IIf(ClosedDate > ShiftEndTime, ShiftEndTime, ClosedDate))
                        TOTALPart = ProductionDataTable.Compute("Sum(Total)", "PartNumber='" & currpart & "' and OPENEDDATE='" & CType(ProductionDataTable.DefaultView.Item(i).Item("OPENEDDATE"), DateTime).ToString(FormatoFecha & " HH:mm:ss.fff") & "'")
                        If mismaparte Then
                            'TOTALPart = ProductionDataTable.Compute("Sum(Total)", "PartNumber='" & currpart & "' AND ((CLOSEDDATE<='" & ClosedDate.ToString(FormatoFecha & " HH:mm:ss.fff") & "') ) ")
                            TOTALPart = ProductionDataTable.Compute("Sum(Total)", "PartNumber='" & currpart & "' AND ((CLOSEDDATE<='" & ClosedDate.ToString(FormatoFecha & " HH:mm:ss.fff") & "' OR CLOSEDDATE IS NULL) ) ")
                        End If

                        TotalAjuste = 0
                        If Not IsDBNull(AdjustmentsDatatable.Compute("Sum(Quantity)", "PartNumber='" & currpart & "'")) Then
                            If Not IsDBNull(AdjustmentsDatatable.Compute("Sum(Quantity)", "PartNumber='" & currpart & "' And Hour<='" & ClosedDate.ToString & "'")) Then
                                TotalAjuste = AdjustmentsDatatable.Compute("Sum(Quantity)", "PartNumber='" & currpart & "' And Hour<='" & ClosedDate.ToString & "'")
                            End If
                            TOTALPart = TOTALPart + TotalAjuste
                        End If

                        Dim oeeloc As Double
                        Dim LocDowntime As Double
                        'LocDowntime = DownTimeDatatable.Compute("sum(minutes)", "PartNumber='" & currpart & "' and Hour>=" & OpenedDate.ToString("HH") & " And Hour<=" & ClosedDate.ToString("HH"))

                        GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Downtime").Value = DownTimeDatatable.Compute("Sum(Minutes)", "PartNumber='" & currpart & "' and hour>='" & CType(OpenedDate, DateTime).ToString(FormatoFecha & " HH:00:00") & "' And hour<'" & CType(ClosedDate, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'")
                        GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Planneddowntime").Value = PlannedDownTimeDatatable.Compute("Sum(Minutes)", "PartNumber='" & currpart & "' and hour>='" & CType(OpenedDate, DateTime).ToString(FormatoFecha & " HH:00:00") & "' And hour<'" & CType(ClosedDate, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'")
                        GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Rejected").Value = ReworkDatatable.Compute("Sum(Quantity)", "PartNumber='" & currpart & "' and hour>='" & CType(OpenedDate, DateTime).ToString(FormatoFecha & " HH:00:00") & "' And hour<'" & CType(ClosedDate, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'")

                        If GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Downtime").Value Is Nothing Then GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Downtime").Value = 0
                        If GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Planneddowntime").Value Is Nothing Then GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Planneddowntime").Value = 0
                        If GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Rejected").Value Is Nothing Then GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Rejected").Value = 0



                        GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Total").Value = TOTALPart.ToString
                        GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Start").Value = OpenedDate
                        GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("End").Value = ClosedDate
                        JPH = GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("JPH").Value

                        oeeloc = CalculateOEE(TotalSegundos / 3600, GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Downtime").Value, GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Planneddowntime").Value, GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Rejected").Value, TOTALPart)

                        GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Hours").Value = (TotalSegundos / 3600).ToString
                        GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("PPT").Value = PlannedProductionTime
                        GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("OT").Value = OperatingTime
                        GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Availability").Value = Availability.ToString
                        GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Performance").Value = Performance.ToString
                        GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("Quality").Value = Quality.ToString
                        GridTemp.Rows(GridTemp.Rows.Count - 1).Cells("OEE").Value = oeeloc.ToString
                    End If
                Next
            End If
togridpopulated:
            ''YA UNA VEZ PINTADO TODO AGREGAR LAS FILAS DE TIEIMPOMUERTO, RECHAZOS Y PAROSPLANEADOS
            adddetails()

            ''PONER EN CADA HORA LOS VALORES (DT, PDT, Y RWK)

            For i = 2 To GridTemp.Columns.Count - 1
                If Not IsNothing(GridTemp.Columns(i).Tag) Then
                    'End If
                    'If GridTemp.Columns(i).HeaderText.StartsWith("H") Or GridTemp.Columns(i).HeaderText.StartsWith("T") Then
                    'Else
                    GridTemp.Rows(reworkrowindex).Cells(i).Value = ReworkDatatable.Compute("Sum(Quantity)", "hour>='" & CType(GridTemp.Columns(i).Tag(0), DateTime).ToString(FormatoFecha & " HH:mm:ss") & "' And hour<'" & CType(GridTemp.Columns(i).Tag(1), DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'")
                    GridTemp.Rows(downtimerowindex).Cells(i).Value = DownTimeDatatable.Compute("Sum(Minutes)", "hour>='" & CType(GridTemp.Columns(i).Tag(0), DateTime).ToString(FormatoFecha & " HH:mm:ss") & "' And hour<'" & CType(GridTemp.Columns(i).Tag(1), DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'")
                    GridTemp.Rows(planneddowntimerowindex).Cells(i).Value = PlannedDownTimeDatatable.Compute("Sum(Minutes)", "hour>='" & CType(GridTemp.Columns(i).Tag(0), DateTime).ToString(FormatoFecha & " HH:mm:ss") & "' And hour<'" & CType(GridTemp.Columns(i).Tag(1), DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'")
                    GridTemp.Rows(ajustesrowindex).Cells(i).Value = AdjustmentsDatatable.Compute("Sum(Quantity)", "hour>='" & CType(GridTemp.Columns(i).Tag(0), DateTime).ToString(FormatoFecha & " HH:mm:ss") & "' And hour<'" & CType(GridTemp.Columns(i).Tag(1), DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'")
                End If
            Next

            ''AGREGAR TOTALES
            GridTemp.Rows(reworkrowindex).Cells("TOTAL").Value = ReworkDatatable.Compute("Sum(Quantity)", "")
            GridTemp.Rows(downtimerowindex).Cells("TOTAL").Value = DownTimeDatatable.Compute("Sum(Minutes)", "")
            GridTemp.Rows(planneddowntimerowindex).Cells("TOTAL").Value = PlannedDownTimeDatatable.Compute("Sum(Minutes)", "")
            GridTemp.Rows(ajustesrowindex).Cells("TOTAL").Value = AdjustmentsDatatable.Compute("Sum(Quantity)", "")

            For I = 0 To GridTemp.Columns.Count - 1
                GridTemp.Columns(I).BestFit()
            Next

            TotalPlannedDowntime = TotalPlannedDowntime / 60 '3600   'CONV A HORAS
            PlannedProductionTime = ShiftLength - TotalPlannedDowntime
            OperatingTime = PlannedProductionTime - (UnplannedDowntime / 60)

            'Availability = OperatingTime / PlannedProductionTime
            'Performance = ((CycleTime * TotalPartsProduced) / (OperatingTime * 60))
            'Quality = (TotalPartsProduced - TotalRejected) / TotalPartsProduced

            'OEE = ((Availability * Performance * Quality) * 100)

            'Availability = Availability * 100
            'Performance = Performance * 100
            'Quality = Quality * 100

            lblfecha.Text = CurrentProductionDate.ToString(FormatoFecha)
            LblTurno.Text = CurrentShiftName
            Lblturno2.Text = LstShiftTimes(0).ToString("hh:mm tt") & " - " & LstShiftTimes(1).ToString("hh:mm tt") & " Turno: " & ShiftLength.ToString("F2") & ", Tiempo Planeado:" & PlannedProductionTime.ToString("F2") & ", Tiempo Operativo: " & OperatingTime.ToString("F2") ''LstShiftTimes(0).Hour & ":" & LstShiftTimes(0).Minute & ":" & LstShiftTimes(0).Second & " - " & LstShiftTimes(1).Hour & ":" & LstShiftTimes(1).Minute & ":" & LstShiftTimes(1).Second

            'LblTiempos.Text = "Tiempo Planeado = (Tiempo Turno - Paros Planeados) = (" & ShiftLength.ToString("f2") & " - " & TotalPlannedDowntime.ToString("F2") & " ) = " & PlannedProductionTime.ToString("F2")
            'LblTiempos2.Text = "Tiempo Operativo = (Tiempo Planeado - Tiempo Muerto) = (" & PlannedProductionTime.ToString("F2") & " - " & (UnplannedDowntime / 60).ToString("F2") & ") = " & OperatingTime.ToString("F2")

            Dim MultAvail As Double
            Dim MultPerf As Double
            Dim MultQual As Double

            MultAvail = 0
            MultPerf = 0
            MultQual = 0

            For i = 0 To GridTemp.Rows.Count - 1
                If Not (Double.IsNaN(GridTemp.Rows(i).Cells("Availability").Value)) Then MultAvail = MultAvail + (GridTemp.Rows(i).Cells("Availability").Value * GridTemp.Rows(i).Cells("PPT").Value)
                If Not (Double.IsNaN(GridTemp.Rows(i).Cells("Performance").Value)) Then MultPerf = MultPerf + (GridTemp.Rows(i).Cells("Performance").Value * GridTemp.Rows(i).Cells("OT").Value)
                If Not (Double.IsNaN(GridTemp.Rows(i).Cells("Quality").Value)) Then MultQual = MultQual + (GridTemp.Rows(i).Cells("Quality").Value * GridTemp.Rows(i).Cells("Total").Value)
            Next
            Availability = MultAvail / PlannedProductionTime
            Performance = MultPerf / OperatingTime
            Quality = MultQual / TotalPartsProduced

            OEE = (Availability * Performance * Quality)

            LblAvailability.BackColor = Utils.GetAvailabilityColor(Math.Round(Availability, 2, MidpointRounding.AwayFromZero))
            LblPerformance.BackColor = Utils.GetPerformanceColor(Math.Round(Performance, 2, MidpointRounding.AwayFromZero))
            LblQuality.BackColor = Utils.GetQualityColor(Math.Round(Quality, 2, MidpointRounding.AwayFromZero))

            LblOEE.BackColor = Utils.GetOEEColor(Math.Round(OEE, 2, MidpointRounding.AwayFromZero))


            Availability = Availability * 100
            Performance = Performance * 100
            Quality = Quality * 100

            OEE = OEE * 100

            GC.Collect()

            LblProdTot.Text = TotalPartsProduced.ToString("F0")
            ' LblCycleTime.Text = CycleTime.ToString("F2")

            LblAvailability.Text = Availability.ToString("F2") & " %" '(Availability * 100).ToString("F2") & " %"
            LblPerformance.Text = Performance.ToString("F2") & " %" '(Performance * 100).ToString("F2") & " %"
            LblQuality.Text = Quality.ToString("F2") & " %" '(Quality * 100).ToString("F2") & " %"
            LblOEE.Text = OEE.ToString("F2") & " %"

            GaugeIndicator.Value = OEE
            If OEE < 0 Then GaugeIndicator.Value = 0
            If OEE > GaugeIndicator.MaxValue Then GaugeIndicator.Value = GaugeIndicator.MaxValue
            GaugeIndicator.Update()

            'Me.Text = Availability.ToString("F6") & " " & Performance.ToString("f6") & " " & Quality.ToString("F6") & " " & (Availability * Performance * Quality).ToString("F4")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            ' MsgBox(DateDiff(DateInterval.Second, start, Now).ToString, MsgBoxStyle.Information)
        End Try
    End Sub

    Sub adddetails()
        Try
            GridTemp.Rows.Add("Tiempo Muerto")
            downtimerowindex = GridTemp.Rows.Count - 1
            GridTemp.Rows.Add("Unidades Rechazadas")
            reworkrowindex = GridTemp.Rows.Count - 1
            GridTemp.Rows.Add("Paro Planeado")
            planneddowntimerowindex = GridTemp.Rows.Count - 1
            GridTemp.Rows.Add("Ajustes")
            ajustesrowindex = GridTemp.Rows.Count - 1
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Function CalculateOEE(ByVal InTotalHours As Double, ByVal InTotalDowntime As Double, ByVal InTotalPlannedDowntime As Double, ByVal InRework As Integer, ByVal InTotalParts As Integer) As Double
        Try

            CycleTime = 60 / JPH

            InTotalDowntime = InTotalDowntime / 60
            InTotalPlannedDowntime = InTotalPlannedDowntime / 60



            PlannedProductionTime = InTotalHours - InTotalPlannedDowntime

            OperatingTime = PlannedProductionTime - InTotalDowntime

            Dim AVAIL, PERF, QUAL, OUTOEE As Double

            Availability = OperatingTime / PlannedProductionTime

            Performance = ((CycleTime * InTotalParts) / (OperatingTime * 60))

            Quality = (InTotalParts - InRework) / InTotalParts

            OEE = (Availability * Performance * Quality)

            Return OEE

        Catch ex As Exception

        End Try
    End Function
    Public deleted As Boolean = False
    Sub guardarreporte()
        Try
            If deleted Then Exit Sub

            If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Captura") Then
                BtnSave.Enabled = False
                Exit Sub
            End If

            If Double.IsNaN(OEE) Or OEE <= 0 Then
                Exit Sub
            End If

            If OEE <= 25 Then
                If MsgBox("El valor de OEE es muy bajo: " & OEE.ToString("F2") & vbCrLf & "¿Seguro que desea guardar el reporte?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                    If Editar Then SQLCon.DeleteReport(ELID)
                    Exit Sub
                End If
            End If

            Dim e As System.EventArgs
            BtnRefresh_Click(Me, e)

            If Editar Then
                SQLCon.EditReport(ELID, TotalPartsProduced, Availability, Performance, Quality, OEE, JPH, ShiftLength, PlannedProductionTime, OperatingTime, ShiftStartTime, ShiftEndTime, UnplannedDowntime, TotalPlannedDowntime * 60, TotalRejected)
                If SQLCon.DeleteReportDetails(ELID) Then
                    For I = 0 To GridTemp.Rows.Count - 4 - 1
                        SQLCon.SaveReportDetails(ELID, GridTemp.Rows(I).Cells(0).Value, GridTemp.Rows(I).Cells(1).Value, GridTemp.Rows(I).Cells(2).Value, GridTemp.Rows(I).Cells(3).Value, GridTemp.Rows(I).Cells(4).Value, GridTemp.Rows(I).Cells(5).Value, GridTemp.Rows(I).Cells(6).Value, GridTemp.Rows(I).Cells(7).Value, GridTemp.Rows(I).Cells(8).Value, GridTemp.Rows(I).Cells(9).Value, GridTemp.Rows(I).Cells(10).Value, GridTemp.Rows(I).Cells(11).Value, GridTemp.Rows(I).Cells(12).Value, GridTemp.Rows(I).Cells(13).Value, GridTemp.Rows(I).Cells(14).Value, GridTemp.Rows(I).Cells(15).Value, GridTemp.Rows(I).Cells(16).Value, CType(GridTemp.Rows(I).Cells("Start").Value, DateTime).ToString("MM/dd/yyyy HH:mm:ss"), CType(GridTemp.Rows(I).Cells("End").Value, DateTime).ToString("MM/dd/yyyy HH:mm:ss"), GridTemp.Rows(I).Cells("Hours").Value.ToString, GridTemp.Rows(I).Cells("PPT").Value.ToString, GridTemp.Rows(I).Cells("OT").Value.ToString, GridTemp.Rows(I).Cells("Downtime").Value.ToString, GridTemp.Rows(I).Cells("PlannedDowntime").Value.ToString, GridTemp.Rows(I).Cells("Rejected").Value.ToString, GridTemp.Rows(I).Cells("Availability").Value.ToString, GridTemp.Rows(I).Cells("Performance").Value.ToString, GridTemp.Rows(I).Cells("Quality").Value.ToString, GridTemp.Rows(I).Cells("OEE").Value.ToString)
                    Next
                End If
            Else
                ELID = SQLCon.NewReport(RecursoDatarow(0).Item("ID"), CurrentProductionDate, CurrentShiftName, TotalPartsProduced, Availability, Performance, Quality, OEE, JPH, ShiftLength, PlannedProductionTime, OperatingTime, ShiftStartTime, ShiftEndTime, UnplannedDowntime, TotalPlannedDowntime * 60, TotalRejected)
                Editar = True
                If SQLCon.DeleteReportDetails(ELID) Then
                    For I = 0 To GridTemp.Rows.Count - 4 - 1
                        SQLCon.SaveReportDetails(ELID, GridTemp.Rows(I).Cells(0).Value, GridTemp.Rows(I).Cells(1).Value, GridTemp.Rows(I).Cells(2).Value, GridTemp.Rows(I).Cells(3).Value, GridTemp.Rows(I).Cells(4).Value, GridTemp.Rows(I).Cells(5).Value, GridTemp.Rows(I).Cells(6).Value, GridTemp.Rows(I).Cells(7).Value, GridTemp.Rows(I).Cells(8).Value, GridTemp.Rows(I).Cells(9).Value, GridTemp.Rows(I).Cells(10).Value, GridTemp.Rows(I).Cells(11).Value, GridTemp.Rows(I).Cells(12).Value, GridTemp.Rows(I).Cells(13).Value, GridTemp.Rows(I).Cells(14).Value, GridTemp.Rows(I).Cells(15).Value, GridTemp.Rows(I).Cells(16).Value, CType(GridTemp.Rows(I).Cells("Start").Value, DateTime).ToString("MM/dd/yyyy HH:mm:ss"), CType(GridTemp.Rows(I).Cells("End").Value, DateTime).ToString("MM/dd/yyyy HH:mm:ss"), GridTemp.Rows(I).Cells("Hours").Value.ToString, GridTemp.Rows(I).Cells("PPT").Value.ToString, GridTemp.Rows(I).Cells("OT").Value.ToString, GridTemp.Rows(I).Cells("Downtime").Value.ToString, GridTemp.Rows(I).Cells("PlannedDowntime").Value.ToString, GridTemp.Rows(I).Cells("Rejected").Value.ToString, GridTemp.Rows(I).Cells("Availability").Value.ToString, GridTemp.Rows(I).Cells("Performance").Value.ToString, GridTemp.Rows(I).Cells("Quality").Value.ToString, GridTemp.Rows(I).Cells("OEE").Value.ToString)
                    Next
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not IscurrentShift Then Exit Sub
        Try
            Timer1.Stop()
            If GridTemp.Rows.Count > 0 Then CurrentSelectedrow = GridTemp.SelectedRows(0).Index
            For Each column As Telerik.WinControls.UI.GridViewCellInfo In GridTemp.SelectedRows(0).Cells
                If column.IsCurrent Then CurrentSelectedCell = column.ColumnInfo.Index
            Next
            cargarproduccionmars()
            cargardowntime()
            'MsgBox("2 Ok")            
            'MsgBox("3 Ok")
            importardowntime()
            Getdetails()
            GridTemp.SelectedRows(0).IsSelected = False
            If CurrentSelectedrow >= 0 Then
                GridTemp.Rows(CurrentSelectedrow).IsSelected = True
                GridTemp.Rows(CurrentSelectedrow).IsCurrent = True
                GridTemp.Rows(CurrentSelectedrow).Cells(CurrentSelectedCell).IsSelected = True
            End If
            'guardarreporte()
            Timer1.Start()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Timer1.Start()
        End Try
    End Sub

    Public Sub SqlDependencyStart()
        Try

            SqlDependency.Stop(SQLCon.constringMARS)
            SqlDependency.Start(SQLCon.constringMARS)
            Using cn As SqlConnection = New SqlConnection(SQLCon.constringMARS)
                Using cmd1 As SqlCommand = cn.CreateCommand
                    cmd1.CommandType = CommandType.Text
                    cmd1.CommandText = "SELECT sum(TOTAL) FROM [hmo].[GetHourlyProdTableReport] (" & RecursoDatarow(0).Item("ID") & ",'" & CurrentShiftName & "','" & CurrentProductionDate.ToString("MM/dd/yyyy") & "'," & RecursoDatarow(0).Item("SubResourceId") & ") where starttime<'" & ShiftEndTime.ToString("MM/dd/yyyy HH:mm:ss") & "'"  ''where CURRENTTARGET>0"
                    'RecursoDatarow(0).Item("ID"), RecursoDatarow(0).Item("SubResourceId"), ShiftEndTime.ToString("MM/dd/yyyy HH:mm:ss"), CurrentProductionDate.ToString("MM/dd/yyyy"), CurrentShiftName
                    ', CurrentShiftName, CurrentProductionDate
                    cmd1.Notification = Nothing
                    Dim dep As SqlDependency = New SqlDependency(cmd1)
                    ' creates an event handler for the notification of data changes in the database
                    AddHandler dep.OnChange, AddressOf dep_onchange
                    cn.Open()
                    Using dr As SqlDataReader = cmd1.ExecuteReader
                        While dr.Read
                            Me.Invoke(Sub()
                                          ''HACER LO DEL TIMER AQUÍ
                                          If GridTemp.Rows.Count > 0 Then CurrentSelectedrow = GridTemp.SelectedRows(0).Index
                                          For Each column As Telerik.WinControls.UI.GridViewCellInfo In GridTemp.SelectedRows(0).Cells
                                              If column.IsCurrent Then CurrentSelectedCell = column.ColumnInfo.Index
                                          Next
                                          cargardatos()
                                          GridTemp.SelectedRows(0).IsSelected = False
                                          If CurrentSelectedrow >= 0 Then
                                              GridTemp.Rows(CurrentSelectedrow).IsSelected = True
                                              GridTemp.Rows(CurrentSelectedrow).IsCurrent = True
                                              GridTemp.Rows(CurrentSelectedrow).Cells(CurrentSelectedCell).IsSelected = True
                                          End If
                                      End Sub)

                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub dep_onchange(ByVal sender As System.Object, ByVal e As System.Data.SqlClient.SqlNotificationEventArgs)
        ' this event is run asynchronously so you will need to invoke to run on the UI thread(if required)

        SqlDependencyStart()

        ' this will remove the event handler since the dependency is only for a single notification
        Dim dep As SqlDependency = DirectCast(sender, SqlDependency)
        RemoveHandler dep.OnChange, AddressOf dep_onchange
    End Sub


    Sub NuevoEditarAdjustment(Optional ByVal EsEditar As Boolean = False, Optional ByVal Specifichour As Integer = -1)
        If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Ajustes") Then
            MsgBox("No tiene permisos para esta opción" & vbCrLf & "Consulte al Administrador", vbExclamation, "Permisos")
            Exit Sub
        End If

        If EsEditar And GridAdjustments.Rows.Count <= 0 Then Exit Sub
        If EsEditar Then
            If GridAdjustments.CurrentRow.Cells(0).Value Is Nothing Then Exit Sub
            If String.IsNullOrEmpty(GridAdjustments.CurrentRow.Cells(0).Value.ToString) Then Exit Sub
        End If


        Try
            Timer1.Enabled = False
            Dim tbltemp As New DataTable
            Dim TblPartsTemp As New DataTable
            Dim TblPartsHoursTemp As New DataTable
            tbltemp = ProductionDataTable.DefaultView.ToTable("Horas", True, "STARTTIME")
            tbltemp.Columns.Add("Hora12")

            TblPartsTemp = ProductionDataTable.DefaultView.ToTable("Partes", False, "PARTNUMBER", "STARTTIME")
            TblPartsHoursTemp = ProductionDataTable.DefaultView.ToTable("Partes", True, "STARTTIME", "PARTNUMBER")

            Dim Horafin As DateTime
            For i = 0 To tbltemp.DefaultView.Count - 1
                'tbltemp.Rows(i).Item(2) = tbltemp.DefaultView.Item(i).Item(0)
                Horafin = Convert.ToDateTime(tbltemp.DefaultView.Item(i).Item(0)).AddMinutes(60 - Convert.ToDateTime(tbltemp.DefaultView.Item(i).Item(0)).Minute)
                tbltemp.Rows(i).Item(1) = CType(GridTemp.Columns(i + 2).Tag(0), DateTime).ToString("hh:mm") & " - " & Horafin.ToString("hh:mm tt")
            Next

            Dim dt As New NewAdjustment
            If EsEditar Then
                dt.ELID = GridAdjustments.CurrentRow.Cells(0).Value
                dt.Editar = True
            End If
            'Dim horasdt As DataTable = ProductionDataTable.DefaultView.ToTable(True, "Hora")
            dt.tblhours = tbltemp

            dt.tblparts = TblPartsTemp
            dt.tblpartsHours = TblPartsHoursTemp


            'dt.CboHora.DataSource = horasdt.DefaultView
            'dt.CboHora.ValueMember = "Hora"
            'dt.CboHora.DisplayMember = "Hora"
            dt.ShiftName = CurrentShiftName
            dt.ProductionDate = CurrentProductionDate
            dt.AssetID = RecursoDatarow(0).Item("ID")
            dt.currenthour = CurrentMARSHour

            If Specifichour >= 0 Then
                dt.currenthour = Specifichour
            End If

            dt.DowntimeDatatable = DownTimeDatatable.Copy
            dt.PlannedDownTimeDatatable = PlannedDownTimeDatatable.Copy

            dt.TblProd = ProductionDataTable.Copy

            If dt.ShowDialog = Windows.Forms.DialogResult.OK Then

                ' cargardatos()
                cargaradjustments()
                Getdetails()
                guardarreporte()
            End If

            dt.Dispose()
            dt = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Timer1.Enabled = True
        End Try
    End Sub

    Sub NuevoEditarDowntime(Optional ByVal EsEditar As Boolean = False, Optional ByVal Specifichour As Integer = -1)
        If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Captura") Then
            MsgBox("No tiene permisos para esta opción" & vbCrLf & "Consulte al Administrador", vbExclamation, "Permisos")
            Exit Sub
        End If

        If EsEditar And GridDownTime.Rows.Count <= 0 Then Exit Sub
        If EsEditar Then
            If GridDownTime.CurrentRow.Cells(0).Value Is Nothing Then Exit Sub
            If String.IsNullOrEmpty(GridDownTime.CurrentRow.Cells(0).Value.ToString) Then Exit Sub
        End If


        Try
            Timer1.Enabled = False
            Dim tbltemp As New DataTable
            Dim TblPartsTemp As New DataTable
            Dim TblPartsHoursTemp As New DataTable

            If ProductionDataTable.DefaultView.Count = 0 Then
                tbltemp = ReportDetailTable.DefaultView.ToTable("Hours", True, "Start")

            Else
                tbltemp = ProductionDataTable.DefaultView.ToTable("Horas", True, "STARTTIME")
                tbltemp.Columns.Add("Hora12")
                TblPartsTemp = ProductionDataTable.DefaultView.ToTable("Partes", False, "PARTNUMBER", "STARTTIME")
                TblPartsHoursTemp = ProductionDataTable.DefaultView.ToTable("Partes", True, "STARTTIME", "PARTNUMBER")

                Dim Horafin As DateTime
                For i = 0 To tbltemp.DefaultView.Count - 1
                    'tbltemp.Rows(i).Item(2) = tbltemp.DefaultView.Item(i).Item(0)
                    Horafin = Convert.ToDateTime(tbltemp.DefaultView.Item(i).Item(0)).AddMinutes(60 - Convert.ToDateTime(tbltemp.DefaultView.Item(i).Item(0)).Minute)
                    tbltemp.Rows(i).Item(1) = CType(GridTemp.Columns(i + 2).Tag(0), DateTime).ToString("hh:mm") & " - " & Horafin.ToString("hh:mm tt")
                Next
            End If

            Dim dt As New NewDowntime
            If EsEditar Then
                dt.ELID = GridDownTime.CurrentRow.Cells(0).Value
                dt.Editar = True
            End If
            'Dim horasdt As DataTable = ProductionDataTable.DefaultView.ToTable(True, "Hora")
            dt.tblhours = tbltemp

            dt.tblparts = TblPartsTemp
            dt.tblpartsHours = TblPartsHoursTemp


            'dt.CboHora.DataSource = horasdt.DefaultView
            'dt.CboHora.ValueMember = "Hora"
            'dt.CboHora.DisplayMember = "Hora"
            dt.ShiftName = CurrentShiftName
            dt.ProductionDate = CurrentProductionDate
            dt.AssetID = RecursoDatarow(0).Item("ID")
            dt.currenthour = CurrentMARSHour

            If Specifichour >= 0 Then
                dt.currenthour = Specifichour
            End If

            dt.DowntimeDatatable = DownTimeDatatable.Copy
            dt.PlannedDownTimeDatatable = PlannedDownTimeDatatable.Copy

            dt.TblProd = ProductionDataTable.Copy

            If dt.ShowDialog = Windows.Forms.DialogResult.OK Then
                'cargardatos()
                guardarreporte()
            End If

            dt.Dispose()
            dt = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Timer1.Enabled = True
        End Try
    End Sub

    Sub NuevoEditarRetrabajo(Optional ByVal EsEditar As Boolean = False, Optional ByVal Specifichour As Integer = -1)
        If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Captura") Then
            MsgBox("No tiene permisos para esta opción" & vbCrLf & "Consulte al Administrador", vbExclamation, "Permisos")
            Exit Sub
        End If
        If EsEditar And GridRework.Rows.Count <= 0 Then Exit Sub
        If EsEditar Then
            If GridRework.CurrentRow.Cells(0).Value Is Nothing Then Exit Sub
            If String.IsNullOrEmpty(GridRework.CurrentRow.Cells(0).Value.ToString) Then Exit Sub
        End If

        Try
            Timer1.Enabled = False
            Dim tbltemp As New DataTable
            Dim TblPartsTemp As New DataTable
            Dim TblPartsHoursTemp As New DataTable
            tbltemp = ProductionDataTable.DefaultView.ToTable("Horas", True, "STARTTIME")
            tbltemp.Columns.Add("Hora12")

            TblPartsTemp = ProductionDataTable.DefaultView.ToTable("Partes", False, "PARTNUMBER", "STARTTIME")
            TblPartsHoursTemp = ProductionDataTable.DefaultView.ToTable("Partes", True, "STARTTIME", "PARTNUMBER")

            Dim Horafin As DateTime
            For i = 0 To tbltemp.DefaultView.Count - 1
                'tbltemp.Rows(i).Item(2) = tbltemp.DefaultView.Item(i).Item(0)
                Horafin = Convert.ToDateTime(tbltemp.DefaultView.Item(i).Item(0)).AddMinutes(60 - Convert.ToDateTime(tbltemp.DefaultView.Item(i).Item(0)).Minute)
                tbltemp.Rows(i).Item(1) = CType(GridTemp.Columns(i + 2).Tag(0), DateTime).ToString("hh:mm") & " - " & Horafin.ToString("hh:mm tt")
            Next

            Dim dt As New NewRework
            If EsEditar Then
                dt.ELID = GridRework.CurrentRow.Cells(0).Value
                dt.Editar = True
            End If
            dt.tblhours = tbltemp
            dt.tblparts = TblPartsTemp
            dt.tblpartsHours = TblPartsHoursTemp
            dt.ShiftName = CurrentShiftName
            dt.ProductionDate = CurrentProductionDate
            dt.AssetID = RecursoDatarow(0).Item("ID")
            dt.currenthour = CurrentMARSHour
            dt.TblProd = ProductionDataTable.Copy
            dt.reworkdatatable = ReworkDatatable.Copy

            If Specifichour >= 0 Then
                dt.currenthour = Specifichour
            End If
            If dt.ShowDialog() = Windows.Forms.DialogResult.OK Then
                'cargardatos()
                guardarreporte()
            End If

            dt.Dispose()
            dt = Nothing


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Timer1.Enabled = True
        End Try
    End Sub

    Sub NuevoEditarPlannedDowntime(Optional ByVal EsEditar As Boolean = False, Optional ByVal Specifichour As Integer = -1)
        If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Captura") Then
            MsgBox("No tiene permisos para esta opción" & vbCrLf & "Consulte al Administrador", vbExclamation, "Permisos")
            Exit Sub
        End If
        If EsEditar And GridPlannedDT.Rows.Count <= 0 Then Exit Sub
        If EsEditar Then
            If GridPlannedDT.CurrentRow.Cells(0).Value Is Nothing Then Exit Sub
            If String.IsNullOrEmpty(GridPlannedDT.CurrentRow.Cells(0).Value.ToString) Then Exit Sub
        End If

        Try
            Timer1.Enabled = False
            Dim tbltemp As New DataTable
            Dim TblPartsTemp As New DataTable
            Dim TblPartsHoursTemp As New DataTable
            tbltemp = ProductionDataTable.DefaultView.ToTable("Horas", True, "STARTTIME")
            tbltemp.Columns.Add("Hora12")

            TblPartsTemp = ProductionDataTable.DefaultView.ToTable("Partes", False, "PARTNUMBER", "STARTTIME")
            TblPartsHoursTemp = ProductionDataTable.DefaultView.ToTable("Partes", True, "STARTTIME", "PARTNUMBER")

            Dim Horafin As DateTime
            For i = 0 To tbltemp.DefaultView.Count - 1
                'tbltemp.Rows(i).Item(2) = tbltemp.DefaultView.Item(i).Item(0)
                Horafin = Convert.ToDateTime(tbltemp.DefaultView.Item(i).Item(0)).AddMinutes(60 - Convert.ToDateTime(tbltemp.DefaultView.Item(i).Item(0)).Minute)
                tbltemp.Rows(i).Item(1) = CType(GridTemp.Columns(i + 2).Tag(0), DateTime).ToString("hh:mm") & " - " & Horafin.ToString("hh:mm tt")
            Next

            Dim dt As New NewPlannedDowntime
            If EsEditar Then
                dt.ELID = GridPlannedDT.CurrentRow.Cells(0).Value
                dt.Editar = True
            End If
            'Dim horasdt As DataTable = ProductionDataTable.DefaultView.ToTable(True, "Hora")
            dt.tblhours = tbltemp
            dt.tblparts = TblPartsTemp
            dt.tblpartsHours = TblPartsHoursTemp
            'dt.CboHora.DataSource = horasdt.DefaultView
            'dt.CboHora.ValueMember = "Hora"
            'dt.CboHora.DisplayMember = "Hora"
            dt.ShiftName = CurrentShiftName
            dt.ProductionDate = CurrentProductionDate
            dt.AssetID = RecursoDatarow(0).Item("ID")
            dt.currenthour = CurrentMARSHour
            If Specifichour >= 0 Then
                dt.currenthour = Specifichour
            End If
            dt.DowntimeDatatable = DownTimeDatatable.Copy
            dt.PlannedDownTimeDatatable = PlannedDownTimeDatatable.Copy
            dt.TblProd = ProductionDataTable.Copy
            If dt.ShowDialog() = Windows.Forms.DialogResult.OK Then
                cargardatos()
                guardarreporte()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Timer1.Enabled = True
        End Try
    End Sub
#Region "Botones"
    Private Sub BtnNewDowntime_Click(sender As Object, e As EventArgs) Handles BtnNewDowntime.Click
        NuevoEditarDowntime(False)
    End Sub

    Private Sub BtnNewRework_Click(sender As Object, e As EventArgs) Handles BtnNewRework.Click
        NuevoEditarRetrabajo(False)
    End Sub

    Private Sub BtnNewPDT_Click(sender As Object, e As EventArgs) Handles BtnNewPDT.Click
        NuevoEditarPlannedDowntime(False)
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        Try
            Timer1.Stop()

            If GridTemp.Rows.Count > 0 Then CurrentSelectedrow = GridTemp.SelectedRows(0).Index
            For Each column As Telerik.WinControls.UI.GridViewCellInfo In GridTemp.SelectedRows(0).Cells
                If column.IsCurrent Then CurrentSelectedCell = column.ColumnInfo.Index
            Next

            cargardatos()

            GridTemp.SelectedRows(0).IsSelected = False
            If CurrentSelectedrow >= 0 Then
                GridTemp.Rows(CurrentSelectedrow).IsSelected = True
                GridTemp.Rows(CurrentSelectedrow).IsCurrent = True
                GridTemp.Rows(CurrentSelectedrow).Cells(CurrentSelectedCell).IsSelected = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Timer1.Start()
        End Try
    End Sub

    Private Sub BtnEditDowntime_Click(sender As Object, e As EventArgs) Handles BtnEditDowntime.Click
        NuevoEditarDowntime(True)
    End Sub

    Private Sub BtnEditRework_Click(sender As Object, e As EventArgs) Handles BtnEditRework.Click
        NuevoEditarRetrabajo(True)
    End Sub

    Private Sub BtnEditPDT_Click(sender As Object, e As EventArgs) Handles BtnEditPDT.Click
        NuevoEditarPlannedDowntime(True)
    End Sub

    Private Sub BtnDeleteDowntime_Click(sender As Object, e As EventArgs) Handles BtnDeleteDowntime.Click
        Try

            If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Captura") Then
                MsgBox("No tiene permisos para esta opción" & vbCrLf & "Consulte al Administrador", vbExclamation, "Permisos")
                Exit Sub
            End If

            If GridDownTime.Rows.Count <= 0 Then Exit Sub
            If MsgBox("Seguro que desea eliminar el Tiempo Muerto seleccionado?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Eliminar Tiempo Muerto") = MsgBoxResult.Yes Then
                SQLCon.DeleteDowntime(GridDownTime.CurrentRow.Cells(0).Value)
                If Not GridDownTime.CurrentRow.Cells("DT_Id").Value Is DBNull.Value Then
                    SQLCon.DeletePlannedDownTimeByRef(GridDownTime.CurrentRow.Cells("DT_Id").Value)
                    SQLCon.DeleteDownTimeByRef(GridDownTime.CurrentRow.Cells("DT_Id").Value)
                End If
                cargardatos()

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnDeleteRework_Click(sender As Object, e As EventArgs) Handles BtnDeleteRework.Click
        Try
            If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Captura") Then
                MsgBox("No tiene permisos para esta opción" & vbCrLf & "Consulte al Administrador", vbExclamation, "Permisos")
                Exit Sub
            End If
            If GridRework.Rows.Count <= 0 Then Exit Sub
            If MsgBox("Seguro que desea eliminar el Retrabajo seleccionado?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Eliminar Retrabajo") = MsgBoxResult.Yes Then
                SQLCon.DeleteRework(GridRework.CurrentRow.Cells(0).Value)
                cargardatos()

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnDeletePDT_Click(sender As Object, e As EventArgs) Handles BtnDeletePDT.Click
        Try
            If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Captura") Then
                MsgBox("No tiene permisos para esta opción" & vbCrLf & "Consulte al Administrador", vbExclamation, "Permisos")
                Exit Sub
            End If
            If GridPlannedDT.Rows.Count <= 0 Then Exit Sub
            If MsgBox("Seguro que desea eliminar el Paro planeado seleccionado?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Eliminar paro planeado") = MsgBoxResult.Yes Then
                SQLCon.DeletePlannedDownTime(GridPlannedDT.CurrentRow.Cells(0).Value)
                If Not GridPlannedDT.CurrentRow.Cells("DT_Id").Value Is DBNull.Value Then
                    SQLCon.DeleteDownTimeByRef(GridPlannedDT.CurrentRow.Cells("DT_Id").Value)
                End If
                cargardatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If Double.IsNaN(OEE) Then
            MsgBox("Valor de OEE es infinito" & vbCrLf & "No se puede generar el Reporte", MsgBoxStyle.Exclamation, "OEE infinito")
            Exit Sub
        End If
        guardarreporte()
    End Sub

    Private Sub BtnDetails_Click(sender As Object, e As EventArgs) Handles BtnDetails.Click
        Try
            Dim setval As Boolean = True
            If GridTemp.Columns("Start").IsVisible Then
                setval = False
            End If
            GridTemp.Columns("Start").IsVisible = setval
            GridTemp.Columns("End").IsVisible = setval
            GridTemp.Columns("Hours").IsVisible = setval
            GridTemp.Columns("PPT").IsVisible = setval
            GridTemp.Columns("OT").IsVisible = setval

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "Grids"

    Private Sub GridDownTime_CellEndEdit(sender As Object, e As GridViewCellEventArgs) Handles GridDownTime.CellEndEdit

    End Sub
    Private Sub GridDownTime_Click(sender As Object, e As EventArgs) Handles GridDownTime.Click
    End Sub
    Private Sub GridDownTime_CellDoubleClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles GridDownTime.CellDoubleClick
        NuevoEditarDowntime(True)
    End Sub
    Private Sub GridDownTime_GroupSummaryEvaluate(sender As Object, e As GroupSummaryEvaluationEventArgs) Handles GridDownTime.GroupSummaryEvaluate
        If e.SummaryItem.Name = "Hour" Then
            e.FormatString = String.Format("Hora: {0}", CType(e.Value, DateTime).ToString("hh:mm tt"))
        End If
    End Sub

    Private Sub GridRework_GroupSummaryEvaluate(sender As Object, e As GroupSummaryEvaluationEventArgs) Handles GridRework.GroupSummaryEvaluate
        If e.SummaryItem.Name = "Hour" Then
            e.FormatString = String.Format("Hora: {0}", CType(e.Value, DateTime).ToString("hh:mm tt"))
        End If
    End Sub

    Private Sub GridPlannedDT_GroupSummaryEvaluate(sender As Object, e As GroupSummaryEvaluationEventArgs) Handles GridPlannedDT.GroupSummaryEvaluate
        If e.SummaryItem.Name = "Hour" Then
            e.FormatString = String.Format("Hora: {0}", CType(e.Value, DateTime).ToString("hh:mm tt"))
        End If
    End Sub

    Private Sub GridRework_Click(sender As Object, e As EventArgs) Handles GridRework.Click
    End Sub

    Private Sub GridRework_CellDoubleClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles GridRework.CellDoubleClick
        NuevoEditarRetrabajo(True)
    End Sub

    Private Sub GridPlannedDT_Click(sender As Object, e As EventArgs) Handles GridPlannedDT.Click

    End Sub

    Private Sub GridPlannedDT_CellDoubleClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles GridPlannedDT.CellDoubleClick
        NuevoEditarPlannedDowntime(True)
    End Sub

    Private Sub GridTemp_Click(sender As Object, e As EventArgs) Handles GridTemp.Click

    End Sub
    Private Sub GridTemp_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles GridTemp.CellDoubleClick
        If Not e.Column.Tag Is Nothing Then
            Dim hr As String
            hr = CType(e.Column.Tag(0), DateTime).ToString("HH")
            If e.RowIndex = downtimerowindex Then
                RadPageView1.SelectedPage = PageDowntime
                NuevoEditarDowntime(False, CInt(hr))
            End If
            If e.RowIndex = reworkrowindex Then
                RadPageView1.SelectedPage = PageRework
                NuevoEditarRetrabajo(False, CInt(hr))
            End If
            If e.RowIndex = planneddowntimerowindex Then
                RadPageView1.SelectedPage = PagePlannedDT
                NuevoEditarPlannedDowntime(False, CInt(hr))
            End If
            If e.RowIndex = ajustesrowindex Then
                RadPageView1.SelectedPage = PageAjustes
                NuevoEditarAdjustment(False, CInt(hr))
            End If
        End If
    End Sub

    Private Sub GridTemp_CellFormatting(sender As Object, e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles GridTemp.CellFormatting
        Try
            e.CellElement.ToolTipText = e.CellElement.Text

            If gridpopulated = False Then Exit Sub

            If Not GridTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag Is Nothing Then
                e.CellElement.ToolTipText = (CInt(e.CellElement.Text) - GridTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag).ToString & " Ajuste (" & GridTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag & ")"
            End If

            Select Case e.Column.Name
                Case "Hours"
                    e.CellElement.ToolTipText = "Shift Hours"
                Case "PPT"
                    e.CellElement.ToolTipText = "Planned Production Time = (Shift Hours - Planned Downtime)"
                    'If (GridTemp.Rows(e.RowIndex).Cells("Hours").Value Is Nothing Or GridTemp.Rows(e.RowIndex).Cells("PlannedDowntime").Value Is Nothing) Then
                    '    e.CellElement.ToolTipText = "Planned Production Time = (Shift Hours - Planned Downtime)"
                    'Else
                    '    e.CellElement.ToolTipText = "Planned Production Time = (Shift Hours - Planned Downtime)" & vbCrLf & GridTemp.Rows(e.RowIndex).Cells("Hours").Value.ToString & " - " & GridTemp.Rows(e.RowIndex).Cells("PlannedDowntime").Value.ToString
                    'End If
                Case "OT"
                    e.CellElement.ToolTipText = "Operating Time = (Planned Production Time - Downtime)"
                    'If (GridTemp.Rows(e.RowIndex).Cells("PlannedDowntime").Value Is Nothing Or GridTemp.Rows(e.RowIndex).Cells("Downtime").Value Is Nothing) Then
                    '    e.CellElement.ToolTipText = "Operating Time = (Planned Production Time - Downtime)"
                    'Else
                    '    e.CellElement.ToolTipText = "Operating Time = (Planned Production Time - Downtime)" & vbCrLf & GridTemp.Rows(e.RowIndex).Cells("PPT").Value.ToString & " - " & GridTemp.Rows(e.RowIndex).Cells("Downtime").Value.ToString
                    'End If
                Case "Availability"
                    e.CellElement.ToolTipText = "Availability = Operating time/Planned Production time"
                Case "Performance"

                    e.CellElement.ToolTipText = "Performance = (Cycle time * Total Produced) / Operating time" '& vbCrLf & "Cycle time = 60/JPH  =  60 / " & GridTemp.Rows(e.RowIndex).Cells("JPH").Value.ToString & " = " & (60 / GridTemp.Rows(e.RowIndex).Cells("JPH").Value).ToString
                Case "Quality"

                    e.CellElement.ToolTipText = "Quality = (Total Produced - Total Rejected) / Total Produced"
                Case "OEE"
                    e.CellElement.ToolTipText = "OEE = Availability * Performance * Quality"



            End Select
        Catch ex As Exception

        End Try
    End Sub



#End Region

    'Dim f As New Formulas

    'Private Sub Label8_MouseEnter(sender As Object, e As EventArgs) Handles Label8.MouseEnter
    '    addformuladetails()
    '    f.Show()
    'End Sub

    'Private Sub Label8_MouseLeave(sender As Object, e As EventArgs) Handles Label8.MouseLeave
    '    f.Hide()
    'End Sub

    'Sub addformuladetails()
    '    Try
    '        f.LblShiftStart.Text = ShiftStartTime.ToString
    '        f.LblShiftEnd.Text = ShiftEndTime.ToString
    '        f.LblPlannedDowntime.Text = (TotalPlannedDowntime * 60).ToString
    '        f.LblUnplannedDowntime.Text = UnplannedDowntime.ToString
    '        f.LblTotalPartsProduced.Text = TotalPartsProduced.ToString
    '        f.LblJPH.Text = JPH.ToString
    '        f.LblIdealCycleTime.Text = CycleTime.ToString
    '        f.LblTotalPartsRejected.Text = TotalRejected.ToString

    '        f.LblShiftLength.Text = ShiftLength.ToString
    '        f.LblPlannedproductiontime.Text = PlannedProductionTime.ToString
    '        f.LblOperatingTime.Text = OperatingTime.ToString
    '        f.LblAvailability.Text = Availability.ToString

    '        f.LblPerformance.Text = Performance.ToString

    '        f.LblQuality.Text = Quality.ToString
    '        f.LblOEE.Text = OEE.ToString("F2")

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub


    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If Not Editar Then Exit Sub
        If MsgBox("Seguro que desea eliminar el Reporte Actual?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Eliminar Reporte") = MsgBoxResult.Yes Then
            Try
                SQLCon.DeleteEntireReport(ELID)
                deleted = True
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If

    End Sub

    Private Sub GridAdjustments_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles GridAdjustments.CellDoubleClick
        NuevoEditarAdjustment(True)
    End Sub

    Private Sub GridAdjustments_Click(sender As Object, e As EventArgs) Handles GridAdjustments.Click
    End Sub

    Private Sub RadButton3_Click(sender As Object, e As EventArgs) Handles RadButton3.Click
        NuevoEditarAdjustment(False)
    End Sub

    Private Sub RadButton1_Click_1(sender As Object, e As EventArgs) Handles RadButton1.Click
        Try
            If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Ajustes") Then
                MsgBox("No tiene permisos para esta opción" & vbCrLf & "Consulte al Administrador", vbExclamation, "Permisos")
                Exit Sub
            End If
            If GridAdjustments.Rows.Count <= 0 Then Exit Sub
            If MsgBox("Seguro que desea eliminar el Ajuste seleccionado?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Eliminar Ajuste") = MsgBoxResult.Yes Then
                SQLCon.DeleteAdjustment(GridAdjustments.CurrentRow.Cells(0).Value)
                cargardatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub RadButton2_Click(sender As Object, e As EventArgs) Handles RadButton2.Click
        NuevoEditarAdjustment(True)
    End Sub

    Private Sub RadButton4_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub RadButton4_Click_1(sender As Object, e As EventArgs) Handles RadButton4.Click
        If GridDownTime.CurrentRow Is Nothing Then Exit Sub
        If (GridDownTime.CurrentRow.Cells("DT_Id").Value Is DBNull.Value) Then Exit Sub
        If String.IsNullOrEmpty(GridDownTime.CurrentRow.Cells("DT_Id").Value) Then
            MsgBox("No se puede Dividir el registro seleccionado", MsgBoxStyle.Exclamation, "Dividir")
            Exit Sub
        End If
        Dim resp = InputBox("Especifique la Cantidad de Minutos" & vbCrLf & "Debe especificar un valor numérico", "Dividir Tiempo Muerto", "")
        If resp.Trim = "" Or Not IsNumeric(resp) Then
            MsgBox("La respuesta no es válida" & vbCrLf & "Debe especificar un valor numérico", MsgBoxStyle.Exclamation, "Dividir")
            Exit Sub
        End If
        If Convert.ToDecimal(resp) > GridDownTime.CurrentRow.Cells("minutes").Value Then
            MsgBox("Sobrepasa la cantidad permitida" & vbCrLf & "Debe especificar un valor Menor a " & GridDownTime.CurrentRow.Cells("minutes").Value.ToString, MsgBoxStyle.Exclamation, "Dividir")
            Exit Sub
        End If

        Try
            SQLCon.NewDowntimeSplit(GridDownTime.CurrentRow.Cells("ID").Value, resp)
            cargardatos()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
End Class