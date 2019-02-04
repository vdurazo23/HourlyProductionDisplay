Public Class DepartmentsConcepts

    Private Sub DepartmentsConcepts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargardatos()
    End Sub

    Sub cargardatos()
        Try
            Dim TblDepartments As DataTable
            Dim TblConcepts As DataTable
            Dim TblCodes As DataTable
            TblDepartments = SQLCon.getDepartments

            TblConcepts = SQLCon.GetConcepts
            TblCodes = SQLCon.GetDowntimeCodes

            TreeView1.Nodes.Clear()

            For i = 0 To TblDepartments.DefaultView.Count - 1
                TreeView1.Nodes.Add(TblDepartments.DefaultView.Item(i).Item("Department"))
                TreeView1.Nodes(i).Tag = TblDepartments.DefaultView.Item(i).Item("ID")
                TblConcepts.DefaultView.RowFilter = "Department_ID=" & TblDepartments.DefaultView.Item(i).Item("ID").ToString
                TreeView1.Nodes(i).ContextMenuStrip = ContextDepartments
                For y = 0 To TblConcepts.DefaultView.Count - 1
                    TreeView1.Nodes(i).Nodes.Add(TblConcepts.DefaultView.Item(y).Item("Concept"))
                    TreeView1.Nodes(i).Nodes(y).Tag = TblConcepts.DefaultView.Item(y).Item("ID")
                    TblCodes.DefaultView.RowFilter = "Concept_ID=" & TblConcepts.DefaultView.Item(y).Item("ID")
                    TreeView1.Nodes(i).Nodes(y).ContextMenuStrip = ContextConcepts
                    For z = 0 To TblCodes.DefaultView.Count - 1
                        TreeView1.Nodes(i).Nodes(y).Nodes.Add(TblCodes.DefaultView.Item(z).Item("Description"))
                        TreeView1.Nodes(i).Nodes(y).Nodes(z).Tag = TblCodes.DefaultView.Item(z).Item("ID")
                        TreeView1.Nodes(i).Nodes(y).Nodes(z).ContextMenuStrip = ContextCodes
                    Next
                Next
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Departamentos", "Editar") Then
            TreeView1.LabelEdit = False
        End If
    End Sub

    Private Sub TreeView1_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles TreeView1.AfterLabelEdit
        If String.IsNullOrEmpty(e.Label) Then Exit Sub
        If e.Label.Trim = "" Then
            e.CancelEdit = True
            Exit Sub
        End If

        Try
            Select Case e.Node.Level
                Case 0  'DEPARTAMENTO
                    SQLCon.EditDepartment(e.Node.Tag, e.Label)
                Case 1 ''CONCEPTO
                    SQLCon.EditConcept(e.Node.Tag, e.Label)
                Case 2 ''DOWNTIME CODE
                    SQLCon.EditDowntimeCode(e.Node.Tag, e.Label)
            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            e.CancelEdit = True
        End Try

    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
    End Sub

    Private Sub TreeView1_BeforeLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles TreeView1.BeforeLabelEdit
        'If e.Node.Level = 0 Then e.CancelEdit = True
    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            TreeView1.SelectedNode = e.Node
        End If
    End Sub

    Private Sub RadButton1_Click(sender As Object, e As EventArgs) Handles RadButton1.Click
        Try
            If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Departamentos", "Nuevo") Then
                MsgBox("No tiene permisos para esta opción" & vbCrLf & "Consulte al Administrador del Sistema", MsgBoxStyle.Exclamation, "Permisos")
                Exit Sub
            End If
            Dim depname As String
            depname = InputBox("Departamento:", "Nuevo Departamento", "")
            If depname.Trim = "" Then Exit Sub
            SQLCon.NewDepartment(depname)
            cargardatos()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Esnuevoelnodo As Boolean = False
    Private Sub NuevaOpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaOpToolStripMenuItem.Click
        Try
            'MsgBox(TreeView1.SelectedNode.Tag.ToString)
            If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Departamentos", "Nuevo") Then
                MsgBox("No tiene permisos para esta opción" & vbCrLf & "Consulte al Administrador del Sistema", MsgBoxStyle.Exclamation, "Permisos")
                Exit Sub
            End If
            Dim newid As Integer
            newid = SQLCon.NewConcept(TreeView1.SelectedNode.Tag, "Concepto" & (TreeView1.SelectedNode.Nodes.Count + 1).ToString)
            TreeView1.SelectedNode.Nodes.Add("Concepto" & (TreeView1.SelectedNode.Nodes.Count + 1).ToString)
            TreeView1.SelectedNode.Nodes(TreeView1.SelectedNode.Nodes.Count - 1).Tag = newid
            TreeView1.SelectedNode = TreeView1.SelectedNode.Nodes(TreeView1.SelectedNode.Nodes.Count - 1)
            TreeView1.SelectedNode.ContextMenuStrip = ContextConcepts
            Esnuevoelnodo = True
            If TreeView1.LabelEdit Then TreeView1.SelectedNode.BeginEdit()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            If Not SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "Departamentos", "Nuevo") Then
                MsgBox("No tiene permisos para esta opción" & vbCrLf & "Consulte al Administrador del Sistema", MsgBoxStyle.Exclamation, "Permisos")
                Exit Sub
            End If
            'MsgBox(TreeView1.SelectedNode.Tag.ToString)
            Dim newid As Integer
            newid = SQLCon.NewDowntimeCode(TreeView1.SelectedNode.Tag, "Código" & (TreeView1.SelectedNode.Nodes.Count + 1).ToString)
            TreeView1.SelectedNode.Nodes.Add("Código" & (TreeView1.SelectedNode.Nodes.Count + 1).ToString)
            TreeView1.SelectedNode.Nodes(TreeView1.SelectedNode.Nodes.Count - 1).Tag = newid
            TreeView1.SelectedNode = TreeView1.SelectedNode.Nodes(TreeView1.SelectedNode.Nodes.Count - 1)
            TreeView1.SelectedNode.ContextMenuStrip = ContextCodes
            Esnuevoelnodo = True
            If TreeView1.LabelEdit Then TreeView1.SelectedNode.BeginEdit()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Try
            If MsgBox("Seguro que desea eliminar el Código: " & TreeView1.SelectedNode.Text & " ? ", MsgBoxStyle.Question + vbYesNoCancel, "Eliminar") = MsgBoxResult.Yes Then
                SQLCon.DeleteDowntimeCode(TreeView1.SelectedNode.Tag)
                TreeView1.SelectedNode.Remove()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Try
            If MsgBox("Seguro que desea eliminar el Concepto: " & TreeView1.SelectedNode.Text & " ? ", MsgBoxStyle.Question + vbYesNoCancel, "Eliminar") = MsgBoxResult.Yes Then
                SQLCon.DeleteConcept(TreeView1.SelectedNode.Tag)
                TreeView1.SelectedNode.Remove()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub EliminarDepartamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarDepartamentoToolStripMenuItem.Click
        Try
            If MsgBox("Seguro que desea eliminar el Departamento: " & TreeView1.SelectedNode.Text & " ? ", MsgBoxStyle.Question + vbYesNoCancel, "Eliminar") = MsgBoxResult.Yes Then
                SQLCon.DeleteDepartment(TreeView1.SelectedNode.Tag)
                TreeView1.SelectedNode.Remove()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class