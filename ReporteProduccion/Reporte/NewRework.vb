Public Class NewRework
    Public AssetID As Integer
    Public ProductionDate As Date
    Public ShiftName As String

    Dim TblConcepts As DataTable
    Dim TblCodes As DataTable

    Public currenthour As Integer

    Public tblhours As DataTable
    Public tblparts As DataTable
    Public tblpartsHours As DataTable

    Public ELID As Integer
    Public Editar As Boolean
    Dim FormatoFecha As String
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

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        Try
            If Editar Then
                SQLCon.EditRework(ELID, Convert.ToDateTime(CboHora.SelectedValue).ToString("MM/dd/yyyy HH:mm:ss"), Cbocodigo.SelectedValue, CboFeatures.SelectedValue, NumericUpDown1.Value, txtcomments.Text, CboParte.SelectedValue.ToString)
                MsgBox("Registro de Retrabajo Modificado exitosamente", MsgBoxStyle.Information, "Nuevo Tiempo Muerto")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                SQLCon.NewRework(AssetID, ProductionDate.ToString("MM/dd/yyyy"), ShiftName, Convert.ToDateTime(CboHora.SelectedValue).ToString("MM/dd/yyyy HH:mm:ss"), Cbocodigo.SelectedValue, CboFeatures.SelectedValue, NumericUpDown1.Value, txtcomments.Text, CboParte.SelectedValue.ToString)
                MsgBox("Registro de Retrabajo Generado exitosamente", MsgBoxStyle.Information, "Nuevo Tiempo Muerto")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
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
            If CboHora.ValueMember = "" Then Exit Sub

            tblpartsHours.DefaultView.RowFilter = "STARTTIME='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'"

            If tblpartsHours.DefaultView.Count > 1 Then
                tblparts.DefaultView.RowFilter = "STARTTIME='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'"
                CboParte.DataSource = tblparts.DefaultView
                CboParte.ValueMember = "PARTNUMBER"
                CboParte.DisplayMember = "PARTNUMBER"
                CboParte.Enabled = True
            Else

                CboParte.SelectedValue = tblpartsHours.DefaultView.Item(0).Item("PARTNUMBER").ToString

                CboParte.Enabled = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class