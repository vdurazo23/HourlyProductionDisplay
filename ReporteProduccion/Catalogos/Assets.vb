Public Class Assets
    Dim tblassets As DataTable
    Private Sub Assets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargardatos()
    End Sub
    Sub cargardatos()
        Try
            ''comment
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
                    Dim subresourceid As Integer
                    If (Not String.IsNullOrEmpty(sr.RadGridView1.CurrentRow.Cells(7).Value.ToString)) Then
                        subresourceid = sr.RadGridView1.CurrentRow.Cells(7).Value
                    End If
                    SQLCon.NewAsset(sr.RadGridView1.CurrentRow.Cells(0).Value, sr.RadGridView1.CurrentRow.Cells(1).Value, sr.RadGridView1.CurrentRow.Cells(2).Value.ToString, sr.RadGridView1.CurrentRow.Cells(3).Value.ToString, sr.RadGridView1.CurrentRow.Cells(4).Value.ToString, sr.RadGridView1.CurrentRow.Cells(5).Value.ToString, sr.RadGridView1.CurrentRow.Cells(6).Value.ToString, subresourceid)
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
        If MsgBox("Seguro que desea eliminar el Recurso seleccionado?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Eliminar Recurso") = MsgBoxResult.Yes Then
            SQLCon.DeleteResource(GridAssets.CurrentRow.Cells(0).Value)
            cargardatos()
        End If
    End Sub

    Private Sub BtnEditResource_Click(sender As Object, e As EventArgs) Handles BtnEditResource.Click
        Dim edas As New EditAsset
        edas.elid = GridAssets.CurrentRow.Cells(0).Value
        edas.StartPosition = FormStartPosition.CenterScreen
        If edas.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cargardatos()
        End If
    End Sub
End Class