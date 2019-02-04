Public Class PartFeatures

    Private Sub StationsEquipment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargardatos()
    End Sub
    Sub cargardatos()
        Try
            Dim tblassets As DataTable
            Dim tblfeatues As DataTable
            tblassets = SQLCon.GetLineas
            tblfeatues = SQLCon.GetFeatures
            TreeView1.Nodes.Clear()
            For i = 0 To tblassets.DefaultView.Count - 1
                TreeView1.Nodes.Add(tblassets.DefaultView.Item(i).Item("Name"))
                TreeView1.Nodes(i).Tag = tblassets.DefaultView.Item(i).Item("ID")
                tblfeatues.DefaultView.RowFilter = "Asset_ID=" & tblassets.DefaultView.Item(i).Item("ID").ToString
                TreeView1.Nodes(i).ContextMenuStrip = ContextLineas
                For y = 0 To tblfeatues.DefaultView.Count - 1
                    TreeView1.Nodes(i).Nodes.Add(tblfeatues.DefaultView.Item(y).Item("Description"))
                    TreeView1.Nodes(i).Nodes(y).Tag = tblfeatues.DefaultView.Item(y).Item("ID")
                    TreeView1.Nodes(i).Nodes(y).ContextMenuStrip = ContextFeatures
                Next
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub NuevaOpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaOpToolStripMenuItem.Click
        Try
            'MsgBox(TreeView1.SelectedNode.Tag.ToString)
            Dim newid As Integer
            newid = SQLCon.NewFeature(TreeView1.SelectedNode.Tag, "Característica" & (TreeView1.SelectedNode.Nodes.Count + 1).ToString)
            TreeView1.SelectedNode.Nodes.Add("Característica" & (TreeView1.SelectedNode.Nodes.Count + 1).ToString)
            TreeView1.SelectedNode.Nodes(TreeView1.SelectedNode.Nodes.Count - 1).Tag = newid
            TreeView1.SelectedNode = TreeView1.SelectedNode.Nodes(TreeView1.SelectedNode.Nodes.Count - 1)
            TreeView1.SelectedNode.ContextMenuStrip = ContextFeatures
            TreeView1.SelectedNode.BeginEdit()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub TreeView1_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles TreeView1.AfterLabelEdit
        If String.IsNullOrEmpty(e.Label) Then Exit Sub
        If e.Label.Trim = "" Then
            e.CancelEdit = True
            Exit Sub
        End If

        Try
            Select Case e.Node.Level
                Case 0  'LINEA

                Case 1 ''OPERACION
                    SQLCon.EditFeature(e.Node.Tag, e.Label)
                
            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            e.CancelEdit = True
        End Try

    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub

    Private Sub TreeView1_BeforeLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles TreeView1.BeforeLabelEdit
        If e.Node.Level = 0 Then e.CancelEdit = True
    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            TreeView1.SelectedNode = e.Node
        End If
    End Sub

    Private Sub EliminarFeatureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarFeatureToolStripMenuItem.Click
        Try
            If MsgBox("Seguro que desea eliminar la característica " & TreeView1.SelectedNode.Text & "?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Eliminar operacion") = MsgBoxResult.Yes Then
                SQLCon.DeleteFeature(TreeView1.SelectedNode.Tag)
                Dim currpar As Integer
                currpar = TreeView1.SelectedNode.Parent.Index
                cargardatos()
                TreeView1.Nodes(currpar).ExpandAll()

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class