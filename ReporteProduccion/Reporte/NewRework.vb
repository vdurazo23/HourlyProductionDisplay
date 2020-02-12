Public Class NewRework
    Public AssetID As Integer
    Public ProductionDate As Date
    Public ShiftName As String

    Dim TblConcepts As DataTable
    Dim TblCodes As DataTable

    Public currenthour As Integer

    Public tblhours As DataTable
    Public reworkdatatable As DataTable
    Public tblparts As DataTable
    Public tblpartsHours As DataTable
    Public TblProd As DataTable

    Public ELID As Integer
    Public Editar As Boolean
    Dim FormatoFecha As String

    Dim TotalPiezas As Integer
    Dim totalPiezasRet As Integer

    Private Sub NewRework_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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


            TblConcepts = SQLCon.GetReworkConcepts
            TblCodes = SQLCon.GetReworkCodes

            Cbocodigo.DataSource = TblCodes.DefaultView
            Cbocodigo.ValueMember = "ID"
            Cbocodigo.DisplayMember = "Description"

            CboConcepto.DataSource = TblConcepts.DefaultView
            CboConcepto.ValueMember = "ID"
            CboConcepto.DisplayMember = "Description"


            CboFeatures.DataSource = SQLCon.GetPartFeatures(AssetID)
            CboFeatures.ValueMember = "ID"
            CboFeatures.DisplayMember = "Description"

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

                Me.Text = "Editar Rechazo " & ELID.ToString

                Dim tbltmp As DataTable
                tbltmp = SQLCon.GetReworkByID(ELID)

                For i = 0 To CboHora.Items.Count - 1
                    If CboHora.Items(i)(0) = tbltmp.DefaultView.Item(0).Item("Hour") Then
                        CboHora.SelectedIndex = i
                        Exit For
                    End If
                Next

                CboConcepto.SelectedValue = tbltmp.DefaultView.Item(0).Item("Concept")
                Cbocodigo.SelectedValue = tbltmp.DefaultView.Item(0).Item("ReworkCode")
                CboFeatures.SelectedValue = tbltmp.DefaultView.Item(0).Item("feature")
                NumericUpDown1.Value = tbltmp.DefaultView.Item(0).Item("Quantity")
                txtcomments.Text = tbltmp.DefaultView.Item(0).Item("Comments")
            Else
                ''cuando es nuevo seleccionar concepto preferido
                If My.Settings.PrefConcepto > 0 Then
                    CboConcepto.SelectedValue = My.Settings.PrefConcepto
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CboConcepto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboConcepto.SelectedIndexChanged
        If CboConcepto.ValueMember.Trim = "" Then Exit Sub
        Try
            TblCodes.DefaultView.RowFilter = "ReworkConcept_ID=" & CboConcepto.SelectedValue.ToString
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub
    Function validar() As Boolean
        ErrorProvider1.Clear()
        If CboHora.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(CboHora, "Requerido!")
            Return False
        End If

        If CboParte.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(CboParte, "Requerido!")
            Return False
        End If

        If Cbocodigo.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(Cbocodigo, "Requerido!")
            Return False
        End If

        If CboConcepto.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(CboConcepto, "Requerido!")
            Return False
        End If

        If CboFeatures.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(CboFeatures, "Requerido!")
            Return False
        End If
        Return True

    End Function
    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        If Not validar() Then Exit Sub
        Try
            If NumericUpDown1.Value <= 0 Then Exit Sub
            TblProd.DefaultView.RowFilter = "STARTTIME='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'  AND PARTNUMBER='" & CboParte.SelectedValue.ToString & "'"
            getminutosdisponibles()

            If (NumericUpDown1.Value + totalPiezasRet) > TotalPiezas Then
                ErrorProvider1.Clear()
                ErrorProvider1.SetError(NumericUpDown1, "Sobrepasa la cantidad de piezas en la hora (" & (TotalPiezas).ToString & ")" & vbCrLf & "Para el Número de parte Actual")
                Exit Sub
            End If
            If Editar Then
                SQLCon.EditRework(ELID, Convert.ToDateTime(CboHora.SelectedValue).ToString("MM/dd/yyyy HH:mm:ss"), Cbocodigo.SelectedValue, CboFeatures.SelectedValue, NumericUpDown1.Value, txtcomments.Text, CboParte.SelectedValue.ToString, CheckScrap.Checked)
                MsgBox("Registro de Retrabajo Modificado exitosamente", MsgBoxStyle.Information, "Editar Rechazo")
                Me.DialogResult = Windows.Forms.DialogResult.OK               
            Else
                SQLCon.NewRework(AssetID, ProductionDate.ToString("MM/dd/yyyy"), ShiftName, Convert.ToDateTime(CboHora.SelectedValue).ToString("MM/dd/yyyy HH:mm:ss"), Cbocodigo.SelectedValue, CboFeatures.SelectedValue, NumericUpDown1.Value, txtcomments.Text, CboParte.SelectedValue.ToString, CheckScrap.Checked)
                MsgBox("Registro de Retrabajo Generado exitosamente", MsgBoxStyle.Information, "Nuevo Rechazo")
                Me.DialogResult = Windows.Forms.DialogResult.OK               
            End If

            My.Settings.PrefConcepto = CboConcepto.SelectedValue
            My.Settings.Save()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub RadButton2_Click(sender As Object, e As EventArgs) Handles RadButton2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub CboHora_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboHora.SelectedIndexChanged

    End Sub

    Private Sub CboHora_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboHora.SelectedValueChanged
        Try
            TotalPiezas = 0
            If CboHora.ValueMember = "" Then Exit Sub
            tblpartsHours.DefaultView.RowFilter = "STARTTIME='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'"
            CboParte.DataSource = tblpartsHours.DefaultView
            TblProd.DefaultView.RowFilter = "STARTTIME='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'  AND PARTNUMBER='" & CboParte.SelectedValue.ToString & "'"

            'getminutosdisponibles()
            'If CboHora.ValueMember = "" Then Exit Sub

            'tblpartsHours.DefaultView.RowFilter = "STARTTIME='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'"

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
            TotalPiezas = 0
            totalPiezasRet = 0
            Dim INICIO, FIN As DateTime
            For I = 0 To TblProd.DefaultView.Count - 1
                'If (TblProd.DefaultView.Item(I).Item("OPENEDDATE") > CType(CboHora.SelectedValue, DateTime)) Then
                '    INICIO = TblProd.DefaultView.Item(I).Item("OPENEDDATE")
                'Else
                '    INICIO = CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss")
                'End If

                'If CType(TblProd.DefaultView.Item(I).Item("CLOSEDDATE"), DateTime).Hour = CType(CboHora.SelectedValue, DateTime).Hour Then
                '    FIN = CType(TblProd.DefaultView.Item(I).Item("CLOSEDDATE"), DateTime)
                'Else
                '    FIN = CType(CboHora.SelectedValue, DateTime).AddHours(1)
                'End If

                TotalPiezas = TblProd.Compute("Sum(TOTAL)", "HORA='" & CType(CboHora.SelectedValue, DateTime).Hour.ToString & "' AND PARTNUMBER='" & CboParte.SelectedValue.ToString & "'")

                reworkdatatable.DefaultView.RowFilter = "hour='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "' and partnumber='" & CboParte.SelectedValue & "'"
                If Editar Then
                    reworkdatatable.DefaultView.RowFilter = reworkdatatable.DefaultView.RowFilter & " And ID<>" & ELID.ToString
                End If

                If reworkdatatable.DefaultView.Count > 0 Then
                    totalPiezasRet = reworkdatatable.Compute("Sum(Quantity)", "hour='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "' and partnumber='" & CboParte.SelectedValue & "' " & IIf(Editar, " And ID<> " & ELID, ""))
                End If
               
            Next



        Catch ex As Exception
            Console.Write(ex.Message)
        End Try
    End Sub
End Class