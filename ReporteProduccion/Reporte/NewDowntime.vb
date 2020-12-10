Public Class NewDowntime
    Public AssetID As Integer
    Dim tblequipment As DataTable
    Dim TblCodes As DataTable
    Dim TblConcepts As DataTable

    Dim TblPlanConcepts As DataTable
    Dim TblPlanConcepts2 As DataTable

    Public ProductionDate As Date
    Public ShiftName As String

    Public tblhours As DataTable
    Public tblparts As DataTable
    Public tblpartsHours As DataTable

    Public currenthour As Integer
    Public ELID As Integer
    Public Editar As Boolean
    Dim FormatoFecha As String

    Public DowntimeDatatable As DataTable
    Public PlannedDownTimeDatatable As DataTable
    Public TblProd As DataTable

    Dim TotalMins As Integer
    Dim MinDisp As Integer
    Dim CurrentMinsValue As Integer

    Dim DtTotalMinutes As Decimal = 0

    Private Sub NewDowntime_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F1 Then
            Dim b As New BuscarCodigo
            If b.ShowDialog = Windows.Forms.DialogResult.OK Then
                If Not b.GridProduction.CurrentRow Is Nothing Then
                    Cbodepartment.SelectedValue = b.GridProduction.CurrentRow.Cells("Department_ID").Value
                    CboConcepto.SelectedValue = b.GridProduction.CurrentRow.Cells("Concept_ID").Value
                    cbocode.SelectedValue = b.GridProduction.CurrentRow.Cells("ID").Value
                End If
            End If
            b.Dispose()
            b = Nothing
        End If
    End Sub

    Private Sub NewDowntime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''aaa
        Try
            ''CORREGIR EL DESASTRE DE MARS
            Dim currpart As String = ""
            Dim OpenedDate As DateTime

            For I = 0 To TblProd.DefaultView.Count - 1
                If TblProd.DefaultView.Item(I).Item("PARTNUMBER") <> currpart Then
                    currpart = TblProd.DefaultView.Item(I).Item("PARTNUMBER")

                    OpenedDate = CType(TblProd.DefaultView.Item(I).Item("OPENEDDATE"), DateTime).ToString(FormatoFecha & " HH:mm:ss.fff")
                    If I = 0 Then OpenedDate = CType(TblProd.DefaultView.Item(I).Item("STARTTIME"), DateTime).ToString(FormatoFecha & " HH:mm:ss.fff")

                    ''Corregir openeddate de mars si está mal
                    If I > 0 Then
                        If OpenedDate <> CType(TblProd.DefaultView.Item(I - 1).Item("CLOSEDDATE"), DateTime) Then
                            TblProd.DefaultView.Item(I).Item("OPENEDDATE") = TblProd.DefaultView.Item(I - 1).Item("CLOSEDDATE")
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
        End Try


        FormatoFecha = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
        cargardatos()
        
    End Sub
    Sub cargardatos()
        Try
            CboParte.DataSource = tblparts.DefaultView
            CboParte.ValueMember = "PARTNUMBER"
            CboParte.DisplayMember = "PARTNUMBER"

            CboHora.DataSource = tblhours.DefaultView
            CboHora.ValueMember = "STARTTIME"
            CboHora.DisplayMember = "Hora12"

            tblequipment = SQLCon.getequipment(AssetID)
            CboEquipment.DataSource = tblequipment
            CboEquipment.ValueMember = "ID"
            CboEquipment.DisplayMember = "Equipment"

            CboStation.DataSource = SQLCon.getStations(AssetID).DefaultView
            CboStation.ValueMember = "ID"
            CboStation.DisplayMember = "Station"

            TblCodes = SQLCon.GetDowntimeCodes
            cbocode.DataSource = TblCodes.DefaultView
            cbocode.ValueMember = "ID"
            cbocode.DisplayMember = "Description"

            TblConcepts = SQLCon.GetConcepts()
            CboConcepto.DataSource = TblConcepts.DefaultView
            CboConcepto.ValueMember = "ID"
            CboConcepto.DisplayMember = "Concept"

            Cbodepartment.DataSource = SQLCon.getDepartments
            Cbodepartment.ValueMember = "ID"
            Cbodepartment.DisplayMember = "Department"


            TblPlanConcepts = SQLCon.GetPlannedDTRC()
            TblPlanConcepts2 = SQLCon.GetPlannedDTRC()

            CboPlanConcepto.DataSource = TblPlanConcepts.DefaultView
            CboPlanConcepto.ValueMember = "ID"
            CboPlanConcepto.DisplayMember = "Description"

            Try
                For i = 0 To CboHora.Items.Count - 1
                    If CboHora.Items(i)(0).Hour = currenthour Then
                        CboHora.SelectedIndex = i
                        Exit For
                    End If
                Next
            Catch ex As Exception
                Console.Write(ex.Message)
            End Try

            If Editar Then

                Me.Text = "Editar Tiempo Muerto " & ELID.ToString

                Dim tbltmp As DataTable
                tbltmp = SQLCon.GetDownTimeBYID(ELID)

                For i = 0 To CboHora.Items.Count - 1
                    If CboHora.Items(i)(0) = tbltmp.DefaultView.Item(0).Item("Hour") Then
                        CboHora.SelectedIndex = i
                        Exit For
                    End If
                Next

                If Not IsDBNull(tbltmp.DefaultView.Item(0).Item("station")) Then CboStation.SelectedValue = tbltmp.DefaultView.Item(0).Item("station")
                If Not IsDBNull(tbltmp.DefaultView.Item(0).Item("Equipment")) Then CboEquipment.SelectedValue = tbltmp.DefaultView.Item(0).Item("Equipment")
                If Not IsDBNull(tbltmp.DefaultView.Item(0).Item("department")) Then Cbodepartment.SelectedValue = tbltmp.DefaultView.Item(0).Item("department")
                If Not IsDBNull(tbltmp.DefaultView.Item(0).Item("concept")) Then CboConcepto.SelectedValue = tbltmp.DefaultView.Item(0).Item("concept")
                If Not IsDBNull(tbltmp.DefaultView.Item(0).Item("DowntimeCode_ID")) Then cbocode.SelectedValue = tbltmp.DefaultView.Item(0).Item("DowntimeCode_ID")

                If tblpartsHours.DefaultView.ToTable.Select("PARTNUMBER='" & tbltmp.DefaultView.Item(0).Item("PartNumber").ToString & "'").Length = 0 Then
                    '' LA PARTE NO ESTÁ INCLUIDA HAY QUE AGREGARLA
                    If tbltmp.DefaultView.Item(0).Item("DT_Id") > 0 Then
                        tblpartsHours.DefaultView.RowFilter = tblpartsHours.DefaultView.RowFilter & " OR PARTNUMBER='" & tbltmp.DefaultView.Item(0).Item("PartNumber").ToString & "'"
                    End If
                End If



                CboParte.SelectedValue = tbltmp.DefaultView.Item(0).Item("PartNumber").ToString
                If Not IsDBNull(tbltmp.DefaultView.Item(0).Item("DT_Id")) Then
                    If tbltmp.DefaultView.Item(0).Item("DT_Id") > 0 Then
                        'CboHora.Enabled = False
                        CboParte.Enabled = False
                    End If
                End If

                
                txtcomments.Text = tbltmp.DefaultView.Item(0).Item("Comments").ToString
                NumericUpDown1.Value = Math.Round(tbltmp.DefaultView.Item(0).Item("Minutes"), 2)
                DtTotalMinutes = Math.Round(tbltmp.DefaultView.Item(0).Item("Minutes"), 2)
                CurrentMinsValue = tbltmp.DefaultView.Item(0).Item("Minutes")

                If IsDBNull(tbltmp.DefaultView.Item(0).Item("department")) Then
                    If My.Settings.PrefDepartment > 0 Then
                        Cbodepartment.SelectedValue = My.Settings.PrefDepartment
                    End If
                End If

                If Not IsDBNull(tbltmp.DefaultView.Item(0).Item("DT_Id")) Then
                    ''Significa que es automático
                    NumericUpDown1.Minimum = 0
                    ChkPlaneado.Enabled = True


                    NumericUpDown1.Enabled = False
                    LblReferencia.Text = tbltmp.DefaultView.Item(0).Item("DT_Id").ToString()
                    LblReferencia.Visible = True

                    LblStartEndtimes.Text = CType(tbltmp.DefaultView.Item(0).Item("StartTime"), DateTime).ToString("MM/dd/yyyy HH:mm:ss") & "  -  " & CType(tbltmp.DefaultView.Item(0).Item("EndTime"), DateTime).ToString("MM/dd/yyyy HH:mm:ss")
                    LblStartEndtimes.Visible = True
                Else
                    LblReferencia.Text = ""
                End If
            Else
                ''Cuando es nuevo
                If My.Settings.PrefDepartment > 0 Then
                    Cbodepartment.SelectedValue = My.Settings.PrefDepartment
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocode.SelectedIndexChanged

    End Sub
    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub CboStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboStation.SelectedIndexChanged
        If CboStation.ValueMember = "" Then Exit Sub
        Try

            tblequipment.DefaultView.RowFilter = "Station = " & CboStation.SelectedValue.ToString

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub Cbodepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbodepartment.SelectedIndexChanged
        If Cbodepartment.ValueMember = "" Then Exit Sub
        Try
            TblConcepts.DefaultView.RowFilter = "Department_ID=" & Cbodepartment.SelectedValue.ToString
            CboConcepto_SelectedIndexChanged(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub CboConcepto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboConcepto.SelectedIndexChanged
        If CboConcepto.ValueMember = "" Then Exit Sub
        Try
            TblCodes.DefaultView.RowFilter = "Concept_ID=" & CboConcepto.SelectedValue.ToString
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        Try
            If NumericUpDown1.Value <= 0 And LblReferencia.Text = "" Then Exit Sub

            If CboStation.SelectedValue Is Nothing Then
                ErrorProvider1.Clear()
                ErrorProvider1.SetError(CboStation, "Requerido!")
                Exit Sub
            End If

            If CboEquipment.SelectedValue Is Nothing Then
                ErrorProvider1.Clear()
                ErrorProvider1.SetError(CboEquipment, "Requerido!")
                Exit Sub
            End If

            If Cbodepartment.SelectedValue Is Nothing Then
                ErrorProvider1.Clear()
                ErrorProvider1.SetError(Cbodepartment, "Requerido!")
                Exit Sub
            End If
            If CboConcepto.SelectedValue Is Nothing Then
                ErrorProvider1.Clear()
                ErrorProvider1.SetError(CboConcepto, "Requerido!")
                Exit Sub
            End If
            If cbocode.SelectedValue Is Nothing Then
                ErrorProvider1.Clear()
                ErrorProvider1.SetError(cbocode, "Requerido!")
                Exit Sub
            End If



            TblProd.DefaultView.RowFilter = "STARTTIME='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'  AND PARTNUMBER='" & CboParte.SelectedValue.ToString & "'"
            getminutosdisponibles()

            If (TotalMins + NumericUpDown1.Value) > MinDisp And LblReferencia.Text.Trim = "" Then
                ErrorProvider1.Clear()
                ErrorProvider1.SetError(NumericUpDown1, "Sobrepasa la cantidad de minutos permitidos en la hora (" & (MinDisp - TotalMins).ToString & ")" & vbCrLf & "Para el Número de parte Actual")
                Exit Sub
            End If

            If ChkPlaneado.Checked And NumericUpDown2.Value = 0 Then
                ErrorProvider1.Clear()
                ErrorProvider1.SetError(NumericUpDown2, "Debe especificar un valor mayor a cero")
                Exit Sub
            End If

            'If TotalMins + (NumericUpDown1.Value - CurrentMinsValue) > (MinDisp - TotalMins) Then
            '    ErrorProvider1.Clear()
            '    ErrorProvider1.SetError(NumericUpDown1, "Sobrepasa la cantidad de minutos permitidos en la hora (" & (MinDisp - TotalMins).ToString & ")" & vbCrLf & "Para el Número de parte Actual")
            '    Exit Sub
            'End If
            If Editar Then
                If ChkPlaneado.Checked Then
                    ''Hay que dividirlo en un PDT y un DT
                    If NumericUpDown1.Value = 0 Then
                        ''Hay que quitar este Tiempo muerto y solo dejar el Planndt
                        SQLCon.DeleteDowntime(ELID)
                        SQLCon.NewPlannedDowntime(AssetID, ProductionDate.ToString("MM/dd/yyyy"), ShiftName, Convert.ToDateTime(CboHora.SelectedValue).ToString("MM/dd/yyyy HH:mm:ss"), CboPlanConcepto.SelectedValue, NumericUpDown2.Value, txtcomments2.Text, CboParte.SelectedValue.ToString, CInt(LblReferencia.Text))
                    Else
                        ''Hay que agregar el PDT y modificar el DT
                        SQLCon.EditDowntime(ELID, Convert.ToDateTime(CboHora.SelectedValue).ToString("MM/dd/yyyy HH:mm:ss"), CboEquipment.SelectedValue, cbocode.SelectedValue, NumericUpDown1.Value, txtcomments.Text, CboParte.SelectedValue.ToString)
                        SQLCon.NewPlannedDowntime(AssetID, ProductionDate.ToString("MM/dd/yyyy"), ShiftName, Convert.ToDateTime(CboHora.SelectedValue).ToString("MM/dd/yyyy HH:mm:ss"), CboPlanConcepto.SelectedValue, NumericUpDown2.Value, txtcomments2.Text, CboParte.SelectedValue.ToString, CInt(LblReferencia.Text))
                    End If

                Else
                    '' Solo Actualizar el DT
                    SQLCon.EditDowntime(ELID, Convert.ToDateTime(CboHora.SelectedValue).ToString("MM/dd/yyyy HH:mm:ss"), CboEquipment.SelectedValue, cbocode.SelectedValue, NumericUpDown1.Value, txtcomments.Text, CboParte.SelectedValue.ToString)
                End If

                MsgBox("Registro de Tiempo muerto Modificado exitosamente", MsgBoxStyle.Information, "Editar Tiempo Muerto")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                SQLCon.NewDowntime(AssetID, ProductionDate.ToString("MM/dd/yyyy"), ShiftName, Convert.ToDateTime(CboHora.SelectedValue).ToString("MM/dd/yyyy HH:mm:ss"), CboEquipment.SelectedValue, cbocode.SelectedValue, NumericUpDown1.Value, txtcomments.Text, CboParte.SelectedValue.ToString)
                MsgBox("Registro de Tiempo muerto Generado exitosamente", MsgBoxStyle.Information, "Nuevo Tiempo Muerto")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If

            My.Settings.PrefDepartment = Cbodepartment.SelectedValue
            My.Settings.Save()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub RadButton2_Click(sender As Object, e As EventArgs) Handles RadButton2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub CboHora_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboHora.SelectedValueChanged
        Try
            TotalMins = 0
            If CboHora.ValueMember = "" Then Exit Sub
            tblpartsHours.DefaultView.RowFilter = "STARTTIME='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'"
            CboParte.DataSource = tblpartsHours.DefaultView
            TblProd.DefaultView.RowFilter = "STARTTIME='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'  AND PARTNUMBER='" & CboParte.SelectedValue.ToString & "'"

            'getminutosdisponibles()

            ' ''Limite de minutos
            'Try

            '    DowntimeDatatable.DefaultView.RowFilter = "hour='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'"
            '    PlannedDownTimeDatatable.DefaultView.RowFilter = "hour='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'"

            '    If DowntimeDatatable.DefaultView.Count > 0 Then
            '        TotalMins = DowntimeDatatable.Compute("Sum(Minutes)", "hour='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'")
            '    End If
            '    If PlannedDownTimeDatatable.DefaultView.Count > 0 Then
            '        TotalMins = TotalMins + PlannedDownTimeDatatable.Compute("Sum(Minutes)", "hour='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'")
            '    End If

            'Catch ex As Exception
            '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error en [Max/Min] Minutos")
            'End Try

            'If tblpartsHours.DefaultView.Count > 1 Then
            '    CboParte.DataSource = Nothing
            '    tblparts.DefaultView.RowFilter = "STARTTIME='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'"
            '    CboParte.DataSource = tblparts.DefaultView
            '    CboParte.ValueMember = "PARTNUMBER"
            '    CboParte.DisplayMember = "PARTNUMBER"
            '    CboParte.Enabled = True
            'Else
            '    CboParte.DataSource = Nothing
            '    CboParte.DataSource = tblparts.DefaultView
            '    CboParte.SelectedValue = tblpartsHours.DefaultView.Item(0).Item("PARTNUMBER").ToString
            '    CboParte.Enabled = False
            'End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CboHora_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboHora.SelectedIndexChanged

    End Sub

    Private Sub RadButton3_Click_1(sender As Object, e As EventArgs) Handles RadButton3.Click
        Dim b As New BuscarCodigo
        If b.ShowDialog = Windows.Forms.DialogResult.OK Then
            If Not b.GridProduction.CurrentRow Is Nothing Then
                Cbodepartment.SelectedValue = b.GridProduction.CurrentRow.Cells("Department_ID").Value
                CboConcepto.SelectedValue = b.GridProduction.CurrentRow.Cells("Concept_ID").Value
                cbocode.SelectedValue = b.GridProduction.CurrentRow.Cells("ID").Value
            End If
        End If
        b.Dispose()
        b = Nothing
    End Sub

    Private Sub CboParte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboParte.SelectedIndexChanged

    End Sub


    Private Sub CboParte_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboParte.SelectedValueChanged
        Try
            'TblProd.DefaultView.RowFilter = "STARTTIME='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'  AND PARTNUMBER='" & CboParte.SelectedValue.ToString & "'"
            'getminutosdisponibles()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub getminutosdisponibles()
        Try
            MinDisp = 0
            TotalMins = 0
            Dim INICIO, FIN As DateTime
            For I = 0 To TblProd.DefaultView.Count - 1
                If (TblProd.DefaultView.Item(I).Item("OPENEDDATE") > CType(CboHora.SelectedValue, DateTime)) Then
                    INICIO = TblProd.DefaultView.Item(I).Item("OPENEDDATE")
                Else
                    INICIO = CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss")
                End If

                If IsDBNull(TblProd.DefaultView.Item(I).Item("CLOSEDDATE")) Then
                    FIN = CType(CboHora.SelectedValue, DateTime).AddHours(1)
                Else
                    If CType(TblProd.DefaultView.Item(I).Item("CLOSEDDATE"), DateTime).Hour = CType(CboHora.SelectedValue, DateTime).Hour Then
                        FIN = CType(TblProd.DefaultView.Item(I).Item("CLOSEDDATE"), DateTime)
                    Else
                        FIN = CType(CboHora.SelectedValue, DateTime).AddHours(1)
                    End If
                End If


                MinDisp = MinDisp + Math.Round((DateDiff(DateInterval.Second, INICIO, FIN) / 60))

                DowntimeDatatable.DefaultView.RowFilter = "hour='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "' and partnumber='" & CboParte.SelectedValue & "'"
                If Editar Then
                    DowntimeDatatable.DefaultView.RowFilter = DowntimeDatatable.DefaultView.RowFilter & " And ID<>" & ELID.ToString
                End If


                PlannedDownTimeDatatable.DefaultView.RowFilter = "hour='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "' and partnumber='" & CboParte.SelectedValue & "'"

                If DowntimeDatatable.DefaultView.Count > 0 Then
                    TotalMins = DowntimeDatatable.Compute("Sum(Minutes)", "hour='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "' and partnumber='" & CboParte.SelectedValue & "' " & IIf(Editar, " And ID<> " & ELID, ""))
                End If
                If PlannedDownTimeDatatable.DefaultView.Count > 0 Then
                    TotalMins = TotalMins + PlannedDownTimeDatatable.Compute("Sum(Minutes)", "hour='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "' and partnumber='" & CboParte.SelectedValue & "' " & IIf(Editar, " And ID<> " & ELID, ""))
                End If
            Next

        Catch ex As Exception
            Console.Write(ex.Message)
        End Try
    End Sub

    Private Sub ChkPlaneado_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPlaneado.CheckedChanged
        NumericUpDown2.Maximum = DtTotalMinutes
        GroupBox1.Enabled = ChkPlaneado.Checked
        If ChkPlaneado.Checked = False Then NumericUpDown2.Value = 0
    End Sub

    Private Sub CboPlanConcepts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPlanConcepto.SelectedIndexChanged
        Try
            TblPlanConcepts2.DefaultView.RowFilter = "id=" & CboPlanConcepto.SelectedValue.ToString
            NumericUpDown2.Maximum = TblPlanConcepts2.DefaultView.Item(0).Item("Max")
        Catch ex As Exception
            Console.Write(ex.Message)
        Finally
            TblPlanConcepts2.DefaultView.RowFilter = ""
        End Try
    End Sub
    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        NumericUpDown1.Value = DtTotalMinutes - NumericUpDown2.Value
    End Sub
End Class