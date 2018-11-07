Public Class Assets
    Dim tblassets As DataTable
    Private Sub Assets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargardatos()
    End Sub
    Sub cargardatos()
        Try
            GridAssets.DataSource = Nothing
            tblassets = Nothing
            tblassets = SQLCon.GetLineas

            Dim primarykey(0) As DataColumn
            primarykey(0) = tblassets.Columns("ID")
            tblassets.PrimaryKey = primarykey

            GridAssets.DataSource = tblassets.DefaultView
            For i = 0 To GridAssets.Columns.Count - 1
                GridAssets.Columns(i).BestFit()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Recursos", "Nuevo") Then
            MsgBox("No tiene permisos para esta opción" & vbCrLf & "Consulte al Administrador del Sistema", MsgBoxStyle.Exclamation, "Permisos")
            Exit Sub
        End If
        Dim sr As New Get_MARS_Assets

        Try
            If sr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If sr.RadGridView1.Rows.Count <= 0 Then Exit Sub
                If tblassets.Rows.Contains(sr.RadGridView1.CurrentRow.Cells(0).Value.ToString) Then
                    MsgBox("El Recurso seleccionado ya se encuentra en la colección", MsgBoxStyle.Exclamation, "Recurso Duplicado")
                Else
                    SQLCon.NewAsset(sr.RadGridView1.CurrentRow.Cells(0).Value, sr.RadGridView1.CurrentRow.Cells(1).Value, sr.RadGridView1.CurrentRow.Cells(2).Value, sr.RadGridView1.CurrentRow.Cells(3).Value, sr.RadGridView1.CurrentRow.Cells(4).Value, sr.RadGridView1.CurrentRow.Cells(5).Value, sr.RadGridView1.CurrentRow.Cells(6).Value, sr.RadGridView1.CurrentRow.Cells(7).Value)
                    cargardatos()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            sr.Dispose()
            sr = Nothing
        End Try

    End Sub

    Private Sub RadButton3_Click(sender As Object, e As EventArgs) Handles RadButton3.Click
        If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Recursos", "Eliminar") Then
            MsgBox("No tiene permisos para esta opción" & vbCrLf & "Consulte al Administrador del Sistema", MsgBoxStyle.Exclamation, "Permisos")
            Exit Sub
        End If
    End Sub
End Class