Public Class NewAdjustment
    Public AssetID As Integer
    Dim tblequipment As DataTable
    Dim TblCodes As DataTable
    Dim TblConcepts As DataTable



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


    

    Private Sub NewDowntime_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

                Me.Text = "Editar Ajuste " & ELID.ToString

                Dim tbltmp As DataTable
                tbltmp = SQLCon.GetAdjustmentBYID(ELID)

                For i = 0 To CboHora.Items.Count - 1
                    If CboHora.Items(i)(0) = tbltmp.DefaultView.Item(0).Item("Hour") Then
                        CboHora.SelectedIndex = i
                        Exit For
                    End If
                Next

               
                CboParte.SelectedValue = tbltmp.DefaultView.Item(0).Item("PartNumber")
                txtcomments.Text = tbltmp.DefaultView.Item(0).Item("Comments")
                NumericUpDown1.Value = tbltmp.DefaultView.Item(0).Item("Quantity")

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        Try
            If NumericUpDown1.Value = 0 Then Exit Sub

            TblProd.DefaultView.RowFilter = "STARTTIME='" & CType(CboHora.SelectedValue, DateTime).ToString(FormatoFecha & " HH:mm:ss") & "'  AND PARTNUMBER='" & CboParte.SelectedValue.ToString & "'"
                                 
            If Editar Then
                SQLCon.EditAdjustment(ELID, Convert.ToDateTime(CboHora.SelectedValue).ToString("MM/dd/yyyy HH:mm:ss"), NumericUpDown1.Value, txtcomments.Text, CboParte.SelectedValue.ToString)
                MsgBox("Registro de Ajuste Modificado exitosamente", MsgBoxStyle.Information, "Editar Tiempo Muerto")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                SQLCon.NewAdjustment(AssetID, ProductionDate.ToString("MM/dd/yyyy"), ShiftName, Convert.ToDateTime(CboHora.SelectedValue).ToString("MM/dd/yyyy HH:mm:ss"), NumericUpDown1.Value, txtcomments.Text, CboParte.SelectedValue.ToString)
                MsgBox("Registro de Ajuste Generado exitosamente", MsgBoxStyle.Information, "Nuevo Tiempo Muerto")
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If

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
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


End Class