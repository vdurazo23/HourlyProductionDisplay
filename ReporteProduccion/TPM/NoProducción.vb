

Public Class NoProducción
    Dim data As New AppData
    Dim salir As Boolean = False
    Dim verh As VerificationForm
    Public nopfecha As Date
    Private Sub NoProducción_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim table = SQLCon.TPMrepTot(nopfecha, lbl_turno.Text, lbl_linea.Text)
            Dim table1 = table.Select("TPM_Result  is NULL or TPM_Result=0").CopyToDataTable
            table1 = table1.DefaultView.ToTable(True,"Asset","Station")
            If table.Rows.Count > 0 Then
                Dim Sel As New DataGridViewCheckBoxColumn
                Sel.HeaderText = "Seleccionar"
                Sel.Name = "Seleccionar"
                Sel.ReadOnly = False
                DataGridView1.Columns.Add(Sel)
                DataGridView1.DataSource = table1
                Dim status As New DataGridViewImageColumn
                status.HeaderText = "Status"
                status.Name = "Status"
                DataGridView1.Columns.Add(status)

                If lbl_fecha.Text <= DateTime.Today Then
                    For Each ro As DataGridViewRow In DataGridView1.Rows
                        ro.Cells("Status").Value = ImageList1.Images.Item(0)
                    Next
                Else
                    For Each ro As DataGridViewRow In DataGridView1.Rows
                        ro.Cells("Status").Value = ImageList1.Images.Item(5)
                    Next
                End If

                For Each col As DataGridViewColumn In DataGridView1.Columns
                    col.SortMode = False
                    If col.HeaderText = "Seleccionar" Then
                        col.ReadOnly = False
                    Else
                        col.ReadOnly = True
                    End If
                Next
            Else
                Me.DialogResult = DialogResult.Cancel
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Me.DialogResult = DialogResult.Cancel
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Try
            If salir = True Then Exit Sub
            If CType(sender, CheckBox).Checked = True Then
                For Each ro As DataGridViewRow In DataGridView1.Rows
                    ro.Cells("Seleccionar").Value = True
                Next
            Else
                For Each ro As DataGridViewRow In DataGridView1.Rows
                    ro.Cells("Seleccionar").Value = False
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try

            If DataGridView1.Columns(e.ColumnIndex).HeaderText = "Seleccionar" Then
                DataGridView1.Item(e.ColumnIndex + 1, e.RowIndex).Selected = True
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

    Function ValidaHuella(ByVal ctl As Control) As Boolean
        Try
            Dim cb_codigo_aprobacion As Integer = 0
            Dim supervisor_nombre As DataTable
            Dim usuario_correcto As Boolean = False
            Dim solicitud As DataRow()
            Dim huellas As DataTable = SQLCon.Huellas(My.Settings.CB_CODIGO)
            If huellas.Rows.Count > 0 Then
                Dim i As Integer
                Data = Nothing
                Data = New AppData
                For i = 0 To huellas.Rows.Count - 1
                    Dim arrpicture() As Byte
                    arrpicture = CType(huellas.Rows(i).Item("Huella"), Byte())
                    Dim ms As New IO.MemoryStream(arrpicture)
                    Dim template As New DPFP.Template(ms)
                    Data.Templates(huellas.Rows(i).Item("pos")) = template
                    Data.EnrolledFingersMask = huellas.Rows(i).Item("mask")
                    arrpicture = Nothing
                    ms = Nothing
                    template = Nothing
                Next
                verh = New VerificationForm(Data)
                Try
                    verh.escomedor = True
                    verh.Data = Data
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

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        Try
            If DataGridView1.Columns(e.ColumnIndex).HeaderText = "Seleccionar" Then
                DataGridView1.Item(e.ColumnIndex, e.RowIndex).ReadOnly = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim ids As New List(Of SQLCon.NOPRODUCCION)
            For Each ro As DataGridViewRow In DataGridView1.Rows

                If ro.Cells("Seleccionar").Value = True Then
                    Dim re As New SQLCon.NOPRODUCCION
                    re.Asset = ro.Cells("Asset").Value.ToString
                    re.Station = ro.Cells("Station").Value.ToString
                    re.Shift = lbl_turno.Text
                    re.Fecha = lbl_fecha.Text
                    ids.Add(re)
                End If
            Next
            If ids.Count > 0 Then
                Dim usuario_correcto As Boolean = ValidaHuella(CType(sender, Control))
                If usuario_correcto Then


                    Dim res = SQLCon.NoProduccionAprob(ids, My.Settings.CB_CODIGO)
                    If res = 1 Then
                        Me.DialogResult = DialogResult.OK
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
End Class