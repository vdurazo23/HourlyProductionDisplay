Public Class Reporte
    Dim RecursoDatarow() As DataRow
    Dim ProductionDataTable As DataTable
    Dim DownTimeDatatable As DataTable
    Dim PlannedDownTimeDatatable As DataTable
    Dim ReworkDatatable As DataTable

    Dim CurrentProductionDate As Date
    Dim CurrentShiftName As String

    Dim CurrentMARSHour As Integer

    Dim reworkrowindex As Integer
    Dim downtimerowindex As Integer
    Dim planneddowntimerowindex As Integer


    Dim TotalPRoducido As Integer
    Dim TotalDefectuosas As Integer
    Dim TotalTiempoMuerto As Double

    Dim TotaltiempoTurno As Double
    Dim TotalBreaks As Double
    Dim TotalTiempoProgramado As Double
    Dim TotalRetrabajo As Double


    Dim TotalTiempoDisponible As Double

    Dim JPH As Integer
    Dim CycleTime As Double

    Dim LstShiftTimes As List(Of DateTime)


    Private Sub Reporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        Try
            Dim sel As New SelectAsset
            If sel.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Show()
                RecursoDatarow = sel.returnRow
                Me.Text = RecursoDatarow(0).Item("Name").ToString
                cargardatos()
            Else
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

    Sub cargardatos()
        cargarproduccionmars()
        cargardowntime()
        cargarplannedDowntime()
        CargarRework()


        adddetails()

        Getdetails()
    End Sub

    Sub cargarproduccionmars()
        Try
            CurrentProductionDate = SQLCon.GetMARSProductionDate(RecursoDatarow(0).Item("ID"), RecursoDatarow(0).Item("SubResourceId"))
            CurrentShiftName = SQLCon.GetMARSProductionShiftName(RecursoDatarow(0).Item("ID"), RecursoDatarow(0).Item("SubResourceId"))

            LstShiftTimes = SQLCon.GetMARSDateTimes(RecursoDatarow(0).Item("ID"), CurrentShiftName)

            CurrentMARSHour = CInt(LstShiftTimes(2).ToString("HH"))

            ProductionDataTable = SQLCon.GetMARSProduction(RecursoDatarow(0).Item("ID"), RecursoDatarow(0).Item("SubResourceId"), CurrentProductionDate.ToString("MM/dd/yyyy"), CurrentShiftName)

            GridProduction.DataSource = Nothing
            GridProduction.DataSource = ProductionDataTable.DefaultView

            Dim horasdt As DataTable = ProductionDataTable.DefaultView.ToTable(True, "Hora")
            Dim partesdt As DataTable = ProductionDataTable.DefaultView.ToTable(True, "PartNumber", "RUNRATE")

            GridDetalle.Rows.Clear()

            For i = 0 To horasdt.DefaultView.Count - 1
                GridDetalle.Columns(i + 2).Tag = horasdt.DefaultView.Item(i).Item(0)
                GridDetalle.Columns(i + 2).HeaderText = Convert.ToDateTime(GridDetalle.Columns(i + 2).Tag.ToString & ":00").ToString("hh") & " - " & Convert.ToDateTime((CInt(GridDetalle.Columns(i + 2).Tag) + 1).ToString & ":00").ToString("hh tt")
            Next

            For i = 0 To partesdt.DefaultView.Count - 1
                GridDetalle.Rows.Add(partesdt.DefaultView.Item(i).Item(0).ToString, partesdt.DefaultView.Item(i).Item(1).ToString)
                JPH = partesdt.DefaultView.Item(i).Item(1)
            Next

            For i = 0 To GridDetalle.Rows.Count - 1
                For j = 2 To GridDetalle.Columns.Count - 1
                    If GridDetalle.Columns(j).HeaderText.StartsWith("H") Or GridDetalle.Columns(j).HeaderText.StartsWith("T") Then
                        If GridDetalle.Columns(j).HeaderText.StartsWith("H") Then GridDetalle.Columns(j).IsVisible = False
                    Else
                        GridDetalle.Columns(j).IsVisible = True
                        ProductionDataTable.DefaultView.RowFilter = "PartNumber='" & GridDetalle.Rows(i).Cells(0).Value.ToString & "' and Hora=" & GridDetalle.Columns(j).Tag.ToString
                        If ProductionDataTable.DefaultView.Count > 0 Then
                            GridDetalle.Rows(i).Cells(j).Value = ProductionDataTable.DefaultView.Item(0).Item("TOTAL")
                        End If
                    End If
                Next

                ProductionDataTable.DefaultView.RowFilter = ""
                GridDetalle.Rows(i).Cells(GridDetalle.Columns.Count - 1).Value = ProductionDataTable.Compute("Sum(Total)", "PartNumber='" & GridDetalle.Rows(i).Cells(0).Value.ToString & "'")
            Next

            ProductionDataTable.DefaultView.RowFilter = ""

            For I = 2 To GridDetalle.Columns.Count - 1
                GridDetalle.Columns(I).BestFit()
            Next

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Sub cargardowntime()
        Try

            DownTimeDatatable = SQLCon.GetDowntime(RecursoDatarow(0).Item("ID"), CurrentProductionDate, CurrentShiftName)
            GridDownTime.DataSource = Nothing
            GridDownTime.DataSource = DownTimeDatatable.DefaultView

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cargarplannedDowntime()
        Try
            PlannedDownTimeDatatable = SQLCon.GetPlannedDT(RecursoDatarow(0).Item("ID"), CurrentProductionDate, CurrentShiftName)
            GridPlannedDT.DataSource = Nothing
            GridPlannedDT.DataSource = PlannedDownTimeDatatable.DefaultView
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try    
    End Sub

    Private Sub CargarRework()
        Try
            ReworkDatatable = SQLCon.GetRework(RecursoDatarow(0).Item("ID"), CurrentProductionDate, CurrentShiftName)
            GridRework.DataSource = Nothing
            GridRework.DataSource = ReworkDatatable.DefaultView

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub adddetails()
        Try
            GridDetalle.Rows.Add("Unidades Rechazadas")
            reworkrowindex = GridDetalle.Rows.Count - 1
            GridDetalle.Rows.Add("Tiempo Muerto")
            downtimerowindex = GridDetalle.Rows.Count - 1
            GridDetalle.Rows.Add("Paro Planeado")
            planneddowntimerowindex = GridDetalle.Rows.Count - 1


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub Getdetails()
        Try
            For i = 2 To GridDetalle.Columns.Count - 1
                If GridDetalle.Columns(i).HeaderText.StartsWith("H") Or GridDetalle.Columns(i).HeaderText.StartsWith("T") Then
                Else
                    GridDetalle.Rows(reworkrowindex).Cells(i).Value = ReworkDatatable.Compute("Sum(Quantity)", "hour=" & GridDetalle.Columns(i).Tag.ToString)
                    GridDetalle.Rows(downtimerowindex).Cells(i).Value = DownTimeDatatable.Compute("Sum(Minutes)", "hour=" & GridDetalle.Columns(i).Tag.ToString)
                    GridDetalle.Rows(planneddowntimerowindex).Cells(i).Value = PlannedDownTimeDatatable.Compute("Sum(Minutes)", "hour=" & GridDetalle.Columns(i).Tag.ToString)

                End If
            Next

            GridDetalle.Rows(reworkrowindex).Cells("TOTAL").Value = ReworkDatatable.Compute("Sum(Quantity)", "")
            GridDetalle.Rows(downtimerowindex).Cells("TOTAL").Value = DownTimeDatatable.Compute("Sum(Minutes)", "")
            GridDetalle.Rows(planneddowntimerowindex).Cells("TOTAL").Value = PlannedDownTimeDatatable.Compute("Sum(Minutes)", "")



            TotalPRoducido = ProductionDataTable.Compute("Sum(TOTAL)", "")

            If DownTimeDatatable.DefaultView.Count > 0 Then
                TotalTiempoMuerto = DownTimeDatatable.Compute("Sum(Minutes)", "")
            Else
                TotalTiempoMuerto = 0
            End If

            CycleTime = 60 / JPH

            Dim ShiftStartTime As DateTime
            Dim ShiftEndTime As DateTime
            Dim currentTime As DateTime

            ShiftStartTime = Convert.ToDateTime(CurrentProductionDate.ToString("MM/dd/yyyy") & " " & LstShiftTimes(0).Hour & ":" & LstShiftTimes(0).Minute & ":" & LstShiftTimes(0).Second)
            ShiftEndTime = Convert.ToDateTime(CurrentProductionDate.ToString("MM/dd/yyyy") & " " & LstShiftTimes(1).Hour & ":" & LstShiftTimes(1).Minute & ":" & LstShiftTimes(1).Second)

            lblfecha.Text = CurrentProductionDate.ToString("MM/dd/yyyy")
            LblTurno.Text = CurrentShiftName

            Lblturno2.Text = LstShiftTimes(0).Hour & ":" & LstShiftTimes(0).Minute & ":" & LstShiftTimes(0).Second & " - " & LstShiftTimes(1).Hour & ":" & LstShiftTimes(1).Minute & ":" & LstShiftTimes(1).Second

            currentTime = LstShiftTimes(2)

            If PlannedDownTimeDatatable.DefaultView.Count > 0 Then
                TotalBreaks = PlannedDownTimeDatatable.Compute("sum(minutes)", "") 'ProductionDataTable.Compute("Sum(SEGUNDOSBREAK)", "")
            Else
                TotalBreaks = 0
            End If

            If ReworkDatatable.DefaultView.Count > 0 Then
                TotalRetrabajo = ReworkDatatable.Compute("sum(Quantity)", "")
            Else
                TotalRetrabajo = 0
            End If


            TotalBreaks = TotalBreaks / 60 '3600   'CONV A HORAS

            TotaltiempoTurno = (DateDiff(DateInterval.Second, ShiftStartTime, IIf(currentTime > ShiftEndTime, ShiftEndTime, currentTime))) / 3600


            TotalTiempoProgramado = TotaltiempoTurno - TotalBreaks

            TotalTiempoDisponible = TotalTiempoProgramado - (TotalTiempoMuerto / 60)


            LblTiempos.Text = "Turno: " & TotaltiempoTurno.ToString("f2") & " - Break(s): " & TotalBreaks.ToString("F2") & " - Tiempo Muerto: " & (TotalTiempoMuerto / 60).ToString("F2") & " = Tiempo Disponible: " & TotalTiempoDisponible.ToString("F2")

            Dim Disponibilidad As Double
            Disponibilidad = TotalTiempoDisponible / TotalTiempoProgramado

            LblDisponibilidad.Text = (Disponibilidad * 100).ToString("F2") & " %"

            Dim Eficiencia As Double

            Eficiencia = ((CycleTime * TotalPRoducido) / (TotalTiempoDisponible * 60))

            LblEficiencia.Text = (Eficiencia * 100).ToString("F2") & " %"

            Console.Write(Eficiencia.ToString)

            Dim Calidad As Double
            Calidad = (TotalPRoducido - TotalRetrabajo) / TotalPRoducido

            LblCalidad.Text = (Calidad * 100).ToString("F2") & " %"

            LblOEE.Text = ((Disponibilidad * Eficiencia * Calidad) * 100).ToString("F2") & " %"


            Console.Write(Calidad.ToString)



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            Dim tbltemp As New DataTable
            tbltemp = ProductionDataTable.DefaultView.ToTable("Horas", True, "HORA", "PartNumber")
            tbltemp.Columns.Add("Hora12")


            For i = 0 To tbltemp.DefaultView.Count - 1
                tbltemp.Rows(i).Item(2) = Convert.ToDateTime(tbltemp.Rows(i).Item(0).ToString & ":00").ToString("hh") & " - " & Convert.ToDateTime((tbltemp.Rows(i).Item(0) + 1).ToString & ":00").ToString("hh tt")
            Next


            Dim dt As New NewDowntime

            'Dim horasdt As DataTable = ProductionDataTable.DefaultView.ToTable(True, "Hora")

            dt.tblhours = tbltemp

            'dt.CboHora.DataSource = horasdt.DefaultView
            'dt.CboHora.ValueMember = "Hora"
            'dt.CboHora.DisplayMember = "Hora"

            dt.ShiftName = CurrentShiftName
            dt.ProductionDate = CurrentProductionDate

            dt.AssetID = RecursoDatarow(0).Item("ID")

            dt.ShowDialog()

            cargardatos()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim tbltemp As New DataTable
            tbltemp = ProductionDataTable.DefaultView.ToTable("Horas", True, "HORA", "PartNumber")
            tbltemp.Columns.Add("Hora12")

            For i = 0 To tbltemp.DefaultView.Count - 1
                tbltemp.Rows(i).Item(2) = Convert.ToDateTime(tbltemp.Rows(i).Item(0).ToString & ":00").ToString("hh") & " - " & Convert.ToDateTime((tbltemp.Rows(i).Item(0) + 1).ToString & ":00").ToString("hh tt")
            Next

            Dim dt As New NewRework
            dt.tblhours = tbltemp
            dt.ShiftName = CurrentShiftName          
            dt.ProductionDate = CurrentProductionDate
            dt.AssetID = RecursoDatarow(0).Item("ID")
            dt.currenthour = CurrentMARSHour
            dt.ShowDialog()
            cargardatos()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        cargardatos()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try

            Dim tbltemp As New DataTable
            tbltemp = ProductionDataTable.DefaultView.ToTable("Horas", True, "HORA", "PartNumber")
            tbltemp.Columns.Add("Hora12")


            For i = 0 To tbltemp.DefaultView.Count - 1
                tbltemp.Rows(i).Item(2) = Convert.ToDateTime(tbltemp.Rows(i).Item(0).ToString & ":00").ToString("hh") & " - " & Convert.ToDateTime((tbltemp.Rows(i).Item(0) + 1).ToString & ":00").ToString("hh tt")
            Next


            Dim dt As New NewPlannedDowntime


            'Dim horasdt As DataTable = ProductionDataTable.DefaultView.ToTable(True, "Hora")

            dt.tblhours = tbltemp

            'dt.CboHora.DataSource = horasdt.DefaultView
            'dt.CboHora.ValueMember = "Hora"
            'dt.CboHora.DisplayMember = "Hora"

            dt.ShiftName = CurrentShiftName
            dt.ProductionDate = CurrentProductionDate

            dt.AssetID = RecursoDatarow(0).Item("ID")

            dt.ShowDialog()

            cargardatos()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

  

    Private Sub Lblturno2_Click(sender As Object, e As EventArgs) Handles Lblturno2.Click

    End Sub
    Private Sub LblTurno_Click(sender As Object, e As EventArgs) Handles LblTurno.Click

    End Sub
    Private Sub lblfecha_Click(sender As Object, e As EventArgs) Handles lblfecha.Click

    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class