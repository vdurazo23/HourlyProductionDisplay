Public Class StationsEquipment

    Private Sub StationsEquipment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargardatos()
    End Sub
    Sub cargardatos()
        Try
            Dim tblassets As DataTable
            Dim TblStations As DataTable
            Dim tblequipment As DataTable
            tblassets = SQLCon.GetLineas
            TblStations = SQLCon.getStations
            tblequipment = SQLCon.getequipment

            TreeView1.Nodes.Clear()


            For i = 0 To tblassets.DefaultView.Count - 1
                TreeView1.Nodes.Add(tblassets.DefaultView.Item(i).Item("Name"))
                TreeView1.Nodes(i).Tag = tblassets.DefaultView.Item(i).Item("ID")
                TblStations.DefaultView.RowFilter = "Asset_ID=" & tblassets.DefaultView.Item(i).Item("ID").ToString
                TreeView1.Nodes(i).ContextMenuStrip = ContextLineas

                For y = 0 To TblStations.DefaultView.Count - 1
                    TreeView1.Nodes(i).Nodes.Add(TblStations.DefaultView.Item(y).Item("station"))
                    TreeView1.Nodes(i).Nodes(y).Tag = TblStations.DefaultView.Item(y).Item("ID")
                    tblequipment.DefaultView.RowFilter = "Station=" & TblStations.DefaultView.Item(y).Item("ID")
                    TreeView1.Nodes(i).Nodes(y).ContextMenuStrip = ContextStations
                    For z = 0 To tblequipment.DefaultView.Count - 1
                        TreeView1.Nodes(i).Nodes(y).Nodes.Add(tblequipment.DefaultView.Item(z).Item("equipment"))
                        TreeView1.Nodes(i).Nodes(y).Nodes(z).Tag = tblequipment.DefaultView.Item(z).Item("ID")
                        TreeView1.Nodes(i).Nodes(y).Nodes(z).ContextMenuStrip = ContextEquipments
                    Next
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
            newid = SQLCon.NewStation(TreeView1.SelectedNode.Tag, "Station" & (TreeView1.SelectedNode.Nodes.Count + 1).ToString)
            TreeView1.SelectedNode.Nodes.Add("Station" & (TreeView1.SelectedNode.Nodes.Count + 1).ToString)
            TreeView1.SelectedNode.Nodes(TreeView1.SelectedNode.Nodes.Count - 1).Tag = newid
            TreeView1.SelectedNode = TreeView1.SelectedNode.Nodes(TreeView1.SelectedNode.Nodes.Count - 1)
            TreeView1.SelectedNode.ContextMenuStrip = ContextStations
            TreeView1.SelectedNode.BeginEdit()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub TreeView1_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles TreeView1.AfterLabelEdit
        If e.Label Is Nothing Then Exit Sub
        If e.Label.Trim = "" Then
            e.CancelEdit = True
            Exit Sub
        End If

        Try
            Select Case e.Node.Level
                Case 0  'LINEA

                Case 1 ''OPERACION
                    SQLCon.EditStation(e.Node.Tag, e.Label)
                Case 2 'EQUIPO
                    SQLCon.EditEquipment(e.Node.Tag, e.Label)
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

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            'MsgBox(TreeView1.SelectedNode.Tag.ToString)
            Dim newid As Integer
            newid = SQLCon.NewEquipment(TreeView1.SelectedNode.Tag, "Equipment" & (TreeView1.SelectedNode.Nodes.Count + 1).ToString)
            TreeView1.SelectedNode.Nodes.Add("Equipment" & (TreeView1.SelectedNode.Nodes.Count + 1).ToString)
            TreeView1.SelectedNode.Nodes(TreeView1.SelectedNode.Nodes.Count - 1).Tag = newid
            TreeView1.SelectedNode = TreeView1.SelectedNode.Nodes(TreeView1.SelectedNode.Nodes.Count - 1)
            TreeView1.SelectedNode.ContextMenuStrip = ContextEquipments
            TreeView1.SelectedNode.BeginEdit()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Try
            If MsgBox("Seguro que desea eliminar el equipo " & TreeView1.SelectedNode.Text & "?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Eliminar equipo") = MsgBoxResult.Yes Then
                
                SQLCon.DeleteEquipment(TreeView1.SelectedNode.Tag)

                Dim currpar As Integer
                currpar = TreeView1.SelectedNode.Parent.Parent.Index
                cargardatos()
                TreeView1.Nodes(currpar).ExpandAll()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub EliminarOperacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarOperacionToolStripMenuItem.Click
        Try
            If MsgBox("Seguro que desea eliminar la operación " & TreeView1.SelectedNode.Text & "?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Eliminar operacion") = MsgBoxResult.Yes Then
                SQLCon.DeleteStation(TreeView1.SelectedNode.Tag)

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