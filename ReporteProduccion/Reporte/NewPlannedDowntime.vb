Public Class NewPlannedDowntime
    Public AssetID As Integer
    Public ProductionDate As Date
    Public ShiftName As String

    Dim TblConcepts As DataTable
    Dim TblConcepts2 As DataTable

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

    Private Sub NewPlannedDowntime_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

            TblConcepts = SQLCon.GetPlannedDTRC()
            TblConcepts2 = SQLCon.GetPlannedDTRC()


            CboConcepto.DataSource = TblConcepts.DefaultView

            CboConcepto.ValueMember = "ID"
            CboConcepto.DisplayMember = "Description"
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
                Me.Text = "Editar Paro Planeado " & ELID.ToString

                Dim tbltmp As DataTable
                tbltmp = SQLCon.GetPlannedDownTimeByID(ELID)

                For i = 0 To CboHora.Items.Count - 1
                    If CboHora.Items(i)(0) = tbltmp.DefaultView.Item(0).Item("Hour") Then
                        CboHora.SelectedIndex = i
                        Exit For
                    End If
                Next

                CboConcepto.SelectedValue = tbltmp.DefaultView.Item(0).Item("PlannedDTRC_ID")
                CboParte.SelectedValue = tbltmp.DefaultView.Item(0).Item("PartNumber")
                NumericUpDown1.Value = tbltmp.DefaultView.Item(0).Item("Minutes")
                CurrentMinsValue = tbltmp.DefaultView.Item(0).Item("Minutes")
                txtcomments.Text = tbltmp.DefaultView.Item(0).Item("Comments")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
       
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadButton2_Click(sender As Object, e As EventArgs) Handles RadButton2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        Try
            If NumericUpDown1.Value <= 0 Then Exit Sub
            TblProd.DefaultView.RowFilter = "STARTTIME='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'  AND PARTNUMBER='" & CboParte.SelectedValue.ToString & "'"
            getminutosdisponibles()

            ErrorProvider1.Clear()
            If (TotalMins + NumericUpDown1.Value) > MinDisp Then
                ErrorProvider1.SetError(NumericUpDown1, "Sobrepasa la cantidad de minutos permitidos en la hora (" & (MinDisp - TotalMins).ToString & ")" & vbCrLf & "Para el Número de parte Actual")
                Exit Sub
            End If

            If CboConcepto.Text = "OTROS" And txtcomments.Text = "" Then
                ErrorProvider1.SetError(txtcomments, "Requerido!.")
                Exit Sub
            End If

            If Editar Then
                SQLCon.EditPlannedDowntime(ELID, Convert.ToDateTime(CboHora.SelectedValue).ToString("MM/dd/yyyy HH:mm:ss"), CboConcepto.SelectedValue, NumericUpDown1.Value, txtcomments.Text, CboParte.SelectedValue.ToString)
                MsgBox("Registro de paro planeado Modificado exitosamente", MsgBoxStyle.Information, "Editar paro planeado")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                SQLCon.NewPlannedDowntime(AssetID, ProductionDate.ToString("MM/dd/yyyy"), ShiftName, Convert.ToDateTime(CboHora.SelectedValue).ToString("MM/dd/yyyy HH:mm:ss"), CboConcepto.SelectedValue, NumericUpDown1.Value, txtcomments.Text, CboParte.SelectedValue.ToString)
                MsgBox("Registro de paro planeado Generado exitosamente", MsgBoxStyle.Information, "Nuevo paro planeado")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CboConcepto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboConcepto.SelectedIndexChanged

        Try

            TblConcepts2.DefaultView.RowFilter = "id=" & CboConcepto.SelectedValue.ToString

            NumericUpDown1.Value = TblConcepts2.DefaultView.Item(0).Item("DefaultValue")
            NumericUpDown1.Maximum = TblConcepts2.DefaultView.Item(0).Item("Max")
        Catch ex As Exception
        Finally
            TblConcepts2.DefaultView.RowFilter = ""
        End Try
    End Sub

    Private Sub CboHora_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboHora.SelectedIndexChanged

    End Sub

    Private Sub CboHora_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboHora.SelectedValueChanged
        Try
            TotalMins = 0
            If CboHora.ValueMember = "" Then Exit Sub
            tblpartsHours.DefaultView.RowFilter = "STARTTIME='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'"
            CboParte.DataSource = tblpartsHours.DefaultView
            TblProd.DefaultView.RowFilter = "STARTTIME='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'  AND PARTNUMBER='" & CboParte.SelectedValue.ToString & "'"

            'getminutosdisponibles()
            'If CboHora.ValueMember = "" Then Exit Sub

            'tblpartsHours.DefaultView.RowFilter = "STARTTIME='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'"
            'TotalMins = 0
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
            '    tblparts.DefaultView.RowFilter = "STARTTIME='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'"
            '    CboParte.DataSource = tblparts.DefaultView
            '    CboParte.ValueMember = "PARTNUMBER"
            '    CboParte.DisplayMember = "PARTNUMBER"
            '    CboParte.Enabled = True
            'Else

            '    CboParte.SelectedValue = tblpartsHours.DefaultView.Item(0).Item("PARTNUMBER").ToString

            '    CboParte.Enabled = False
            'End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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

                PlannedDownTimeDatatable.DefaultView.RowFilter = "hour='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "' and partnumber='" & CboParte.SelectedValue & "'"
                If Editar Then
                    PlannedDownTimeDatatable.DefaultView.RowFilter = PlannedDownTimeDatatable.DefaultView.RowFilter & " And ID<>" & ELID.ToString
                End If

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

End Class