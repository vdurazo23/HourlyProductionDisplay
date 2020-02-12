Imports Microsoft.Reporting.WinForms

Public Class TPMReporte
    Dim data As New AppData
    Dim salir As Boolean = False
    Dim verh As VerificationForm
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim seg = (TimeOfDay.Hour * 60 * 60) + (TimeOfDay.Minute * 60)
        If seg < 50400 And seg > 23400 Then
            ComboBox1.SelectedIndex = 0
        ElseIf seg < 77400 Then
            ComboBox1.SelectedIndex = 1
        Else
            ComboBox1.SelectedIndex = 2
        End If
        cargar_linea()
        cargar_data()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim ids As New List(Of Integer)
            For Each ro As DataGridViewRow In DataGridView1.Rows
                If ro.Cells("Seleccionar").ReadOnly = False Then
                    If ro.Cells("Seleccionar").Value = True Then
                        ids.Add(ro.Cells("id").Value)
                    End If
                End If
            Next
            If ids.Count > 0 Then
                Dim usuario_correcto As Boolean = ValidaHuella(CType(sender, Control))
                If usuario_correcto Then


                    Dim res = SQLCon.Aprob_tpm(ids, My.Settings.CB_CODIGO)
                    If res = 1 Then
                        cargar_data()
                    Else
                        MsgBox("No se ha completado la acción", MsgBoxStyle.Critical, "Error")
                    End If
                Else
                    MsgBox("Error al reconocer la huella", MsgBoxStyle.Critical)
                End If



            Else
                MsgBox("No ha seleccionado registros para aprobar", MsgBoxStyle.Critical, "Error")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting

        Try



            If DataGridView1.Columns(e.ColumnIndex).HeaderText = "Status" Then
                'If lbl_fecha.Text <= Date.Today Then
                If Not String.IsNullOrEmpty(DataGridView1.Item("TPM_Result", e.RowIndex).Value.ToString) Then
                    e.Value = ImageList1.Images.Item(DataGridView1.Item("TPM_Result", e.RowIndex).Value)
                Else
                    e.Value = ImageList1.Images.Item(0)
                End If
                'Else
                '    e.Value = ImageList1.Images.Item(5)
                'End If
            End If





            If DataGridView1.Columns(e.ColumnIndex).HeaderText = "Reporte" Then
                If String.IsNullOrEmpty(DataGridView1.Item("Id", e.RowIndex).Value.ToString) Then
                    e.Value = Nothing
                Else
                    e.Value = "VER"
                End If

            End If




            If DataGridView1.Columns(e.ColumnIndex).HeaderText = "Aprobado" Then
                If Not String.IsNullOrEmpty(DataGridView1.Item("CB_CODIGO_Aprueba", e.RowIndex).Value.ToString) Then
                    e.Value = ImageList1.Images.Item(1)
                Else
                    e.Value = ImageList1.Images.Item(0)
                End If
            End If




            If DataGridView1.Columns(e.ColumnIndex).HeaderText = "Seleccionar" Then
                If Not String.IsNullOrEmpty(DataGridView1.Item("TPM_Result", e.RowIndex).Value.ToString) Then
                    If Not String.IsNullOrEmpty(DataGridView1.Item("CB_CODIGO_Aprueba", e.RowIndex).Value.ToString) Then
                        e.Value = True
                        DataGridView1.Item(e.ColumnIndex, e.RowIndex).ReadOnly = True
                        e.CellStyle.BackColor = Color.LightGray

                    ElseIf DataGridView1.Item("TPM_Result", e.RowIndex).Value = 1 Then
                        DataGridView1.Item(e.ColumnIndex, e.RowIndex).ReadOnly = False
                    ElseIf CType(DataGridView1.Item("Reporte", e.RowIndex), DataGridViewLinkCell).LinkVisited = True Then
                        DataGridView1.Item(e.ColumnIndex, e.RowIndex).ReadOnly = False
                    Else
                        DataGridView1.Item(e.ColumnIndex, e.RowIndex).ReadOnly = True
                    End If
                Else
                    e.Value = False
                    DataGridView1.Item(e.ColumnIndex, e.RowIndex).ReadOnly = True

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
        End Try

    End Sub

    Sub cargar_data()
        Try
            CheckBox1.Checked = False
            Dim table = SQLCon.TPMrepTot(DateTimePicker1.Value.Date, ComboBox1.SelectedItem, ComboBox2.SelectedValue)
            If table.Rows.Count > 0 Then
                lbl_fecha.Text = DateTimePicker1.Value.GetDateTimeFormats.ToList(10)
                lbl_fecha.Tag = DateTimePicker1.Value.Date
                '  lbl_linea.Text = ComboBox2.SelectedValue
                lbl_turno.Text = ComboBox1.SelectedItem
                DataGridView1.DataSource = Nothing
                DataGridView1.Columns.Clear()
                DataGridView1.Rows.Clear()
                Dim check_columns As New DataGridViewCheckBoxColumn
                check_columns.HeaderText = "Seleccionar"
                check_columns.Name = "Seleccionar"

                Dim check_column As New DataGridViewImageColumn
                check_column.HeaderText = "Aprobado"
                check_column.Name = "Aprobado"

                Dim Indicador As New DataGridViewImageColumn
                Indicador.HeaderText = "Status"
                Indicador.Name = "Status"
                Dim Reporte As New DataGridViewLinkColumn
                Reporte.HeaderText = "Reporte"
                Reporte.Name = "Reporte"


                DataGridView1.DataSource = table
                DataGridView1.Columns.Add(Indicador)
                DataGridView1.Columns.Add(check_column)
                DataGridView1.Columns.Add(Reporte)
                DataGridView1.Columns.Add(check_columns)


                DataGridView1.Columns("id").Visible = False
                DataGridView1.Columns("TPM_Result").Visible = False
                DataGridView1.Columns("CB_CODIGO").Visible = False
                DataGridView1.Columns("CB_CODIGO_Aprueba").Visible = False
                DataGridView1.Columns("Aprueba_datetime").Visible = False
                For Each col As DataGridViewColumn In DataGridView1.Columns
                    col.SortMode = False
                    If col.HeaderText = "Seleccionar" Then
                        col.ReadOnly = False
                    Else
                        col.ReadOnly = True
                    End If
                Next
                DataGridView1.Columns("Seleccionar").DisplayIndex = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Sub cargar_linea()
        Try
            Dim lineas = SQLCon.TPMRelEsts()
            Dim lineas_filter = lineas.DefaultView.ToTable(True, "Asset")
            ComboBox2.DataSource = Nothing
            ComboBox2.DataSource = lineas_filter
            ComboBox2.ValueMember = "Asset"
            ComboBox2.DisplayMember = "Asset"
            Console.WriteLine("")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cargar_data()
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            If DataGridView1.Columns(e.ColumnIndex).HeaderText = "Reporte" Then
                Dim r As New Reporte
                Dim parametrose As New List(Of ReportParameter)

                Dim id = New ReportParameter("id", DataGridView1.Item("Id", e.RowIndex).Value.ToString)
                parametrose.Add(id)
                r.parametro = parametrose
                r.path = "/TPM/TPM_Especifico"
                r.ShowDialog()
                DataGridView1.Item("Seleccionar", e.RowIndex).ReadOnly = False
            End If
            If DataGridView1.Columns(e.ColumnIndex).HeaderText = "Seleccionar" Then
                If DataGridView1.Item(e.ColumnIndex, e.RowIndex).ReadOnly = True Then Exit Sub


                Console.WriteLine()
                DataGridView1.Item(e.ColumnIndex - 1, e.RowIndex).Selected = True
                salir = True
                If CType(DataGridView1.Item(e.ColumnIndex, e.RowIndex), DataGridViewCheckBoxCell).Value = False Then
                    CheckBox1.Checked = False
                End If

                salir = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Try
            If salir = True Then Exit Sub

            If CType(sender, CheckBox).Checked = True Then
                For Each ro As DataGridViewRow In DataGridView1.Rows
                    If ro.Cells("Seleccionar").ReadOnly = False Then
                        If Not String.IsNullOrEmpty(ro.Cells("TPM_Result").Value.ToString) Then
                            If ro.Cells("TPM_Result").Value = 1 Then
                                ro.Cells("Seleccionar").Value = True
                            ElseIf ro.Cells("TPM_Result").Value = 2 And CType(ro.Cells("Reporte"), DataGridViewLinkCell).LinkVisited = True Then
                                ro.Cells("Seleccionar").Value = True
                            End If
                        End If
                    End If


                Next
            Else
                For Each ro As DataGridViewRow In DataGridView1.Rows
                    If ro.Cells("Seleccionar").ReadOnly = False Then
                        ro.Cells("Seleccionar").Value = False
                    End If
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Function ValidaHuella(ByVal ctl As Control) As Boolean
        Try
            Dim cb_codigo_aprobacion As Integer = 0
            Dim supervisor_nombre As DataTable
            Dim usuario_correcto As Boolean = False
            Dim solicitud As DataRow()
            Dim huellas As DataTable = SQLCon.Huellas(My.Settings.CB_CODIGO)
            If huellas.Rows.Count > 0 Then
                Dim i As Integer
                data = Nothing
                data = New AppData
                For i = 0 To huellas.Rows.Count - 1
                    Dim arrpicture() As Byte
                    arrpicture = CType(huellas.Rows(i).Item("Huella"), Byte())
                    Dim ms As New IO.MemoryStream(arrpicture)
                    Dim template As New DPFP.Template(ms)
                    data.Templates(huellas.Rows(i).Item("pos")) = template
                    data.EnrolledFingersMask = huellas.Rows(i).Item("mask")
                    arrpicture = Nothing
                    ms = Nothing
                    template = Nothing
                Next
                verh = New VerificationForm(data)
                Try
                    verh.escomedor = True
                    verh.Data = data
                    verh.StartPosition = FormStartPosition.CenterScreen
                    verh.ShowDialog()
                    If verh.DialogResult = 1 Then
                        Return True
                    Else
                        Return False
                    End If
                Catch ex As Exception

                End Try
            Else
                Return False
                MsgBox("No hay huellas registradas para este usuario", MsgBoxStyle.Critical)
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If DataGridView1.Rows.Count > 0 Then

                Dim nopo As New NoProducción
                nopo.lbl_linea.Text = DataGridView1.Item("Asset", 0).Value
                nopo.nopfecha = lbl_fecha.Tag
                nopo.lbl_fecha.Text = lbl_fecha.Text
                nopo.lbl_turno.Text = lbl_turno.Text

                If nopo.ShowDialog = DialogResult.OK Then

                    cargar_data()

                Else


                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
        End Try
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Try
            If DataGridView1.Columns(e.ColumnIndex).HeaderText = "Seleccionar" Then

                If DataGridView1.Item(e.ColumnIndex, e.RowIndex).ReadOnly = True Then
                    If Not String.IsNullOrEmpty(DataGridView1.Item("TPM_Result", e.RowIndex).Value.ToString) Then
                        If DataGridView1.Item("TPM_Result", e.RowIndex).Value = 2 Then
                            MsgBox("Antes de aprobar debe de revisar el reporte", MsgBoxStyle.Exclamation, "Error")
                        ElseIf DataGridView1.Item("TPM_Result", e.RowIndex).Value = 0 Then
                            MsgBox("No se Ha realizado el TPM" & vbCrLf & "No se puede aprobar", MsgBoxStyle.Exclamation)
                        Else
                            MsgBox("Este registro ya esta aprobado", MsgBoxStyle.Exclamation)
                        End If
                    Else
                        MsgBox("No hay registro para aprobar", MsgBoxStyle.Critical, "Error")
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim r As New Reporte
            Dim parametrose As New List(Of ReportParameter)
            parametrose.Add(New ReportParameter("Month", DateTimePicker1.Value.Month.ToString))
            parametrose.Add(New ReportParameter("Year", DateTimePicker1.Value.Year.ToString))
            parametrose.Add(New ReportParameter("Shift", ComboBox1.Text))
            r.parametro = parametrose
            r.path = "/TPM/TPM_Mensual_Reporte_General"
            r.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
