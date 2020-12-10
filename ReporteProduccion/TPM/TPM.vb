Imports TPM_REG.SQLCon
Public Class TPM
    Dim midataset As New DataSet
    Dim iniciando As Boolean = True
    Public addelement As String = ""
    Dim s As DataTable
    Dim TPM_elementos As DataTable
    Dim activeInsert As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TableLayoutPanel1.Visible = False
        cargardatos()
        cargardatos2()
        For Each tree As TreeView In TableLayoutPanel1.Controls
            tree.ShowNodeToolTips = True
            tree.ExpandAll()
        Next
        ListBox1.SetSelected(0, False)
        '  CType(TableLayoutPanel1.Controls(0), TreeView).Nodes(0).Nodes(0).Checked = True
        iniciando = False
        'activaopciones()



        '''PRUEBA
        ''' 
        'Dim TL As New TableLayoutPanel
        'TL.ColumnStyles.Clear()
        'TL.RowStyles.Clear()
        'TL.Size = New Size(400, 200)

        'Dim L As New Label
        'L.Text = "1.- asd KLASD FJKLAS FJKLASDFJKL ASDFJLK ASF JKL SFAJL SFDAJL ASFLJKÑASFJLK ASALKSDJFKASDJFKLASD FJKLASDJF KLSADJFKLSADJFKASLD f asdf asdf asdf asd fasdf asdf dasf asdf asdf asdf adsf asdf asdf asd  fsLabel1 asd fasf asf asdf asdf asdf asdf asdf adsf asdf asdf asdf asdf asdf asdf asdfasd fasdf asd fasdf a sdf asdf das fasdf asdfads  adf asdf asdf asdf dasf adsf asd fads fasdf adsf das  fdasf asd fa"""
        'L.AutoSize = True

        'Dim L1 As New Label
        'L1.Text = "2.- asdf asdf asdf asdf asd fasdf asdf dasf asdf asdf asdf adsf asdf asdf asd  fsLabel1 asd fasf asf asdf asdf asdf asdf asdf adsf asdf asdf asdf asdf asdf asdf asdfasd fasdf asd fasdf a sdf asdf das fasdf asdfads  adf asdf asdf asdf dasf adsf asd fads fasdf adsf das  fdasf asd fa"""
        'L1.AutoSize = True

        'TL.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 400))
        'TL.RowStyles.Add(New System.Windows.Forms.RowStyle(SizeType.Absolute, 50))
        'TL.RowStyles.Add(New System.Windows.Forms.RowStyle(SizeType.Absolute, 50))
        'TL.Controls.Add(L, 0, 0)
        'TL.Controls.Add(L1, 0, 1)

        'TL.Size = New Size(400, L1.Height + L.Height)
        'TL.RowStyles(0).SizeType = SizeType.AutoSize
        'TL.RowStyles(1).SizeType = SizeType.AutoSize


        'Me.Controls.Add(TL)
        'TL.Location = New Point(100, 100)
        'TL.BringToFront()

    End Sub





    Public Sub activaopciones()
        Try
            'BtnNuevoTPM.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Nuevo")
            'BtnNuevoElemento.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Nuevo")

            'BtnEditarTPM.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Editar")
            'BtnEditarElemento.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Editar")
            'BtnUp.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Editar")
            'BtnDown.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Editar")

            'TableLayoutPanel1.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Editar")

            'BtnEliminarTPM.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Eliminar")
            'BtnEliminarElemento.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Eliminar")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Sub cargardatos()
        s = SQLCon.TPMreq()
        Dim ss As DataTable = s.DefaultView.ToTable(False, "Id", "Name")
        ss.TableName = "TPMreq"
        midataset.Tables.Add(ss)
        ListBox1.DataSource = midataset.Tables("TPMreq")
        ListBox1.ValueMember = "ID"
        ListBox1.DisplayMember = "Name"
        's = SQLCon.TPMelements
        'TPM_elementos = s.DefaultView.ToTable()
        'TPM_elementos.TableName = "Elements"
        'midataset.Tables.Add(TPM_elementos)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If iniciando Then Exit Sub
        If CType(sender, ListBox).SelectedIndex = -1 Then Exit Sub
        RelTPMStations()
        searchStations(sender.selectedValue)
        If midataset.Tables("Elements") IsNot Nothing Then
            midataset.Tables.Remove("Elements")
        End If
        s = SQLCon.TPMelements
        TPM_elementos = s.DefaultView.ToTable()
        TPM_elementos.TableName = "Elements"
        midataset.Tables.Add(TPM_elementos)
        TableLayoutPanel1.Visible = True

        ListView1.Items.Clear()
        midataset.Tables("Elements").DefaultView.RowFilter = "TPM_ID=" & sender.SelectedValue
        Dim tpm_elements As DataTable = midataset.Tables("ELements").DefaultView.ToTable()
        'midataset.Tables("Elements").DefaultView.FindRows(Function(t))
        tpm_elements.DefaultView.Sort = "Orden"
        For Each ro As DataRow In tpm_elements.Rows
            ListView1.Items.Add(ro("Text"))
            ListView1.Items(ListView1.Items.Count - 1).Tag = ro("ID")
            ListView1.Items(ListView1.Items.Count - 1).BackColor = Color.FromName(ro("Color"))
        Next

    End Sub

    Sub cargardatos2()
        Dim s As DataTable = SQLCon.TPMStations
        Dim c = s.DefaultView.ToTable(True, "ASSET")
        TableLayoutPanel1.Controls.Clear()
        TableLayoutPanel1.ColumnStyles.Clear()
        TableLayoutPanel1.ColumnCount = 0
        For a = 0 To c.Rows.Count - 1
            TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 250))
            TableLayoutPanel1.ColumnCount = a + 1
            Dim tr As New TreeView
            tr.Name = c.Rows(a).Item(0).trim
            'tr.Width = 250
            'tr.Height = TableLayoutPanel1.Height - 20
            tr.Dock = DockStyle.Fill
            tr.CheckBoxes = True
            Dim e As New TreeNode
            e.Name = c.Rows(a).Item(0).trim
            e.Tag = "Asset"
            e.Text = e.Name.Trim
            Dim cc = s.DefaultView.ToTable(True, "Asset", "Station")
            Dim fil = cc.Select("ASSET ='" & e.Name & "'")
            For t = 0 To fil.Count - 1
                Dim ee As New TreeNode
                ee.Name = fil(t).Item(1).ToString
                ' ee.Tag = 0
                ee.Text = ee.Name.Trim

                e.Nodes.Add(ee)
            Next
            tr.Nodes.Add(e)
            AddHandler tr.BeforeCheck, AddressOf select_ch
            TableLayoutPanel1.Controls.Add(tr, a, 0)
            tr.ExpandAll()
        Next
        RelTPMStations()
        For Each tree As TreeView In TableLayoutPanel1.Controls
            tree.ShowNodeToolTips = True
            tree.ExpandAll()
        Next
    End Sub

    Private Sub RelTPMStations()
        Dim rela As DataTable = SQLCon.TPMRelEsts()
        For Each ro As DataRow In rela.Rows
            For Each tree As TreeView In TableLayoutPanel1.Controls

                If ro(2).ToString = tree.Name.ToString Then
                    For Each nod As TreeNode In tree.Nodes(0).Nodes
                        Console.WriteLine("")
                        If ro(3).ToString = nod.Text Then
                            nod.Tag = ro(1)
                            Dim a = midataset.Tables("TPMreq").Select("ID = " & ro(1))
                            nod.ToolTipText = a(0).Item(1)
                        End If
                    Next
                    Exit For
                End If

            Next

        Next
    End Sub

    Private Sub select_ch(sender As Object, e As TreeViewCancelEventArgs)

        If ListBox1.SelectedIndex = -1 Then e.Cancel = True
        If e.Node.Tag IsNot Nothing Then
            If e.Node.Tag.ToString = "Asset" Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        If activeInsert = False Then Exit Sub
        If e.Node.Tag IsNot Nothing Then
            If e.Node.Tag <> 0 Then
                If ListBox1.SelectedValue.ToString <> e.Node.Tag Then
                    e.Cancel = True
                    MsgBox("TPM´s assigned ", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If e.Node.Checked = False Then
                    'agregar
                    e.Node.Tag = ListBox1.SelectedValue
                    e.Node.ToolTipText = ListBox1.SelectedItem.row.ItemArray(1)
                    Dim re As Integer = SQLCon.TPMAddRelStation(ListBox1.SelectedValue, e.Node.Parent.Text, e.Node.Text)
                Else
                    'eliminar
                    Dim re As Integer = SQLCon.TPMRemoveRelStation(e.Node.Tag, e.Node.Parent.Text, e.Node.Text)
                    e.Node.Tag = 0
                    e.Node.ToolTipText = Nothing

                End If
            Else
                Dim re As Integer = SQLCon.TPMAddRelStation(ListBox1.SelectedValue, e.Node.Parent.Text, e.Node.Text)
                e.Node.Tag = ListBox1.SelectedValue
                e.Node.ToolTipText = ListBox1.SelectedItem.row.itemArray(1)
            End If
        Else
            If e.Node.Checked = True Then
                'eliminar
                Dim re As Integer = SQLCon.TPMRemoveRelStation(e.Node.Tag, e.Node.Parent.Text, e.Node.Text)
                e.Node.Tag = 0
                e.Node.ToolTipText = Nothing
            Else
                'agregar
                'Dim re As Integer = SQLCon.TPMAddRelStation(ListBox1.SelectedValue,)

                e.Node.Tag = ListBox1.SelectedValue
                e.Node.ToolTipText = ListBox1.SelectedItem.Row.ItemArray(1)
                Dim re As Integer = SQLCon.TPMAddRelStation(ListBox1.SelectedValue, e.Node.Parent.Text, e.Node.Text)
            End If
        End If
    End Sub

    Private Sub BtnNuevoTPM_Click(sender As Object, e As EventArgs) Handles BtnNuevoTPM.Click
        Try
            Dim n As New Add_element

            n.CboClas.Visible = False
            n.LblClas.Visible = False
            If n.ShowDialog = DialogResult.OK Then
                addelement = n.texto
                n.Dispose()
                n = Nothing
                Dim res = SQLCon.AddTPM(addelement)
                If res = 1 Then
                    refresh(True)
                End If

            Else
                addelement = ""
                n.Dispose()
                n = Nothing
                iniciando = False
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub refresh(ByVal todo As Boolean)
        Try
            iniciando = True
            ListView1.Items.Clear()
            ListBox1.DataSource = Nothing
            TableLayoutPanel1.Visible = False
            midataset.Tables.Clear()
            cargardatos()
            If todo Then
                cargardatos2()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            iniciando = False
        End Try
    End Sub
    Private Sub BtnUp_Click(sender As Object, e As EventArgs) Handles BtnUp.Click
        If ListView1.Items.Count = 0 Then Exit Sub
        If ListView1.SelectedIndices.Count <= 0 Then Exit Sub
        Dim indice = ListView1.SelectedIndices.Item(0)
        If indice = 0 Or indice = -1 Then Exit Sub
        Dim cajon As ListViewItem
        cajon = ListView1.Items(indice)
        Dim insertitem As ListViewItem
        insertitem = cajon.Clone()
        ListView1.Items.Insert(indice - 1, insertitem)
        ListView1.Items.Remove(cajon)
        ListView1.Select()
        ListView1.Items(indice - 1).Selected = True
        Dim rev = SQLCon.TPMelementUpdate(ListBox1.SelectedValue, indice, ListView1.Items(indice - 1).Tag)
        rev = SQLCon.TPMelementUpdate(ListBox1.SelectedValue, indice + 1, ListView1.Items(indice).Tag)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles BtnDown.Click
        If ListView1.Items.Count = 0 Then Exit Sub
        If ListView1.SelectedIndices.Count <= 0 Then Exit Sub

        Dim indice = ListView1.SelectedIndices.Item(0)
        If indice = ListView1.Items.Count - 1 Then Exit Sub
        Dim cajon As ListViewItem
        cajon = ListView1.Items(indice)
        Dim insertitem As ListViewItem
        insertitem = cajon.Clone()
        ListView1.Items.Insert(indice + 2, insertitem)
        ListView1.Items.Remove(cajon)
        ListView1.Select()
        ListView1.Items(indice + 1).Selected = True
        Dim rev = SQLCon.TPMelementUpdate(ListBox1.SelectedValue, indice + 1, ListView1.Items(indice).Tag)
        rev = SQLCon.TPMelementUpdate(ListBox1.SelectedValue, indice + 2, ListView1.Items(indice + 1).Tag)
    End Sub

    Private Sub BtnNuevoElemento_Click(sender As Object, e As EventArgs) Handles BtnNuevoElemento.Click
        Try
            If ListBox1.Items.Count = 0 Then Exit Sub
            Dim add As New Add_element
            add.ShowColor = True
            If add.ShowDialog() = DialogResult.OK Then
                addelement = add.texto
                Dim re = SQLCon.AddTPMelements(ListBox1.SelectedValue, ListView1.Items.Count + 1, addelement, add.CboClas.Text)
                If re = 1 Then
                    ListView1.Items.Add(addelement)
                    ListView1.Items(ListView1.Items.Count - 1).Tag = SQLCon.TPMelementTag(ListBox1.SelectedValue, addelement, ListView1.Items.Count)
                    ListView1.Items(ListView1.Items.Count - 1).BackColor = Color.FromName(add.CboClas.Text)
                End If
                add.Dispose()
                add = Nothing
            Else
                addelement = ""
                add.Dispose()
                add = Nothing
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnEliminarElemento_Click(sender As Object, e As EventArgs) Handles BtnEliminarElemento.Click
        Try

            If ListView1.Items.Count = 0 Or ListBox1.SelectedIndex = -1 Then Exit Sub
            Dim indice As Integer = ListView1.SelectedIndices.Item(0)
            If indice = -1 Then Exit Sub

            Dim check As Integer = SQLCon.TPM_ELEMENT_RESULT(ListView1.Items(indice).Tag)
            If check > 0 Then
                MsgBox("Este elemento contiene uno o varios registros" & vbCrLf & "No se puede eliminar?", MsgBoxStyle.Exclamation, "Eliminar")
                Exit Sub
            End If


            Dim re = SQLCon.RemoveTPMelement(ListBox1.SelectedValue, indice + 1, ListView1.Items(indice).Tag)
            If indice + 1 = ListView1.Items.Count Then
                Dim c As ListViewItem
                c = ListView1.Items(indice)
                ListView1.Items.Remove(c)
            Else
                Dim c As ListViewItem
                c = ListView1.Items(indice)
                ListView1.Items.Remove(c)
                Dim cd As New List(Of SQLCon.ElementsOrder)
                For a = indice To ListView1.Items.Count - 1
                    Dim s As SQLCon.ElementsOrder
                    s.id = ListView1.Items(a).Tag
                    s.orden = a + 1
                    cd.Add(s)
                Next
                Dim res As Integer = SQLCon.EditOrderElements(ListBox1.SelectedValue, cd)
            End If
            If indice > ListView1.Items.Count - 1 Then
                ListView1.Select()
                ListView1.Items(ListView1.Items.Count - 1).Selected = True
            Else
                ListView1.Select()
                ListView1.Items(indice).Selected = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub searchStations(ByVal tpm_id As Integer)
        activeInsert = False
        For Each tree As TreeView In TableLayoutPanel1.Controls
            For Each nod As TreeNode In tree.Nodes(0).Nodes
                If nod.Tag = tpm_id.ToString Then
                    If nod.Checked = False Then nod.Checked = True : nod.BackColor = Color.Transparent : nod.ForeColor = Color.Black
                Else
                    If nod.Checked = True Then nod.Checked = False
                    If nod.ToolTipText <> "" Then nod.BackColor = Color.LightGray : nod.ForeColor = Color.Gray Else nod.BackColor = Color.Transparent : nod.ForeColor = Color.Black

                End If
            Next
        Next
        activeInsert = True
    End Sub

    Private Sub BtnEditarElemento_Click(sender As Object, e As EventArgs) Handles BtnEditarElemento.Click
        Try
            If ListBox1.Items.Count = 0 Then Exit Sub
            If ListView1.SelectedIndices.Count = 0 Then Exit Sub
            Dim indice As Integer = ListView1.SelectedIndices.Item(0)
            If indice = -1 Then Exit Sub

            Dim add As New Add_element
            add.ShowColor = True
            add.TextBox1.Text = ListView1.Items(indice).Text
            add.CboClas.Text = ListView1.Items(indice).BackColor.Name
            add.Button1.Text = "Update"
            add.Text = "Update"
            add.Label1.Text = "Text"
            If add.ShowDialog() = DialogResult.OK Then
                Dim new_text = add.texto
                'If new_text = ListView1.Items(indice).Text Then Exit Sub         
                Dim re = SQLCon.EditTPMelements(ListBox1.SelectedValue, new_text, ListView1.SelectedIndices(0) + 1, ListView1.SelectedItems(0).Tag, add.CboClas.Text)
                If re = 1 Then
                    ListView1.Items(indice).Text = new_text
                    ListView1.Items(indice).BackColor = Color.FromName(add.CboClas.Text)
                End If
                add.Dispose()
                add = Nothing
            Else

                add.Dispose()
                add = Nothing
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnEliminarTPM_Click(sender As Object, e As EventArgs) Handles BtnEliminarTPM.Click
        Try
            Dim a As New DialogResult
            a = MsgBox("Está seguro que desea eliminar el TPM Seleccionado", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Eliminar")
            If a = DialogResult.Yes Then
                Dim re As Integer = SQLCon.TPM_RESULT(ListBox1.SelectedValue, False)
                If re > 0 Then
                    a = MsgBox("El TPM Seleccionado, contiene uno o varios registros " & vbCrLf & "¿Está seguro que desea eliminarlo?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical, "Seguro eliminar?")
                    If a = DialogResult.Yes Then
                        Dim check As Integer = SQLCon.DeleteTPM(ListBox1.SelectedValue)
                    Else
                        Exit Sub
                    End If

                Else
                    Dim check As Integer = SQLCon.DeleteTPM(ListBox1.SelectedValue)
                End If
            Else
                Exit Sub
            End If
            refresh(True)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnEditarTPM_Click(sender As Object, e As EventArgs) Handles BtnEditarTPM.Click
        Try
            If ListBox1.SelectedIndex < 0 Then Exit Sub
            Dim add As New Add_element
            add.TextBox1.Text = ListBox1.SelectedItem.Row.ItemArray(1).ToString
            add.Button1.Text = "Update"
            add.Text = "Update element"
            add.Label1.Text = "Name:"
            add.CboClas.Visible = False
            add.LblClas.Visible = False
            If add.ShowDialog() = DialogResult.OK Then
                Dim new_text = add.texto
                If new_text = ListBox1.SelectedItem.Row.ItemArray(1).ToString Then Exit Sub
                add.Dispose()
                add = Nothing
                Dim re = SQLCon.TPMEdit(ListBox1.SelectedValue, new_text)
                If re = 1 Then
                    Dim indice = ListBox1.SelectedIndex
                    refresh(False)
                    RelTPMStations()
                    ListBox1.SetSelected(indice, True)
                End If
            Else

                add.Dispose()
                add = Nothing
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    '**********NUEVO CODIGO
    Dim cargado As Boolean = False
    Dim last_index As Integer = -2


    Friend WithEvents cd As New ColourDialog

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            Select Case CType(sender, TabControl).SelectedIndex

                Case 0

                Case 1
                    If cargado = False Then
                        cargar_tablas()
                        Cat_ayuda_visual()
                        Tree_view_lineas()

                        cargado = True
                    End If
                    For i = 0 To DataGridView1.Columns.Count - 1
                        DataGridView1.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Next
                Case 2
                    'Cargar categorias
                    Cargar_categorias()

                    'Cargar defectos
                    Cargar_defectos()

            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    'Tab control 1
    Sub cargar_tablas()
        Try
            s = SQLCon.TPMStations
            Dim ss As DataTable = s.DefaultView.ToTable
            If midataset.Tables("Stations") IsNot Nothing Then
                midataset.Tables.Remove("Stations")
            End If
            ss.TableName = "Stations"
            midataset.Tables.Add(ss)
            'midataset.Tables("Stations").DefaultView.RowFilter = "TARGET IS NOT NULL"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Tree_view_lineas()
        Try



            TV_rel_lc.Nodes.Clear()

            Dim c = midataset.Tables("Stations").DefaultView.ToTable(True, "ASSET")
            For Each ro As DataRow In c.Rows
                If ro.ItemArray(0).ToString.Trim <> "" Then
                    TV_rel_lc.Nodes.Add(ro.ItemArray(0).ToString.Trim)
                End If
            Next

            Dim cc = midataset.Tables("Stations").DefaultView.ToTable(True, "ASSET", "Station")
            For Each ro As DataRow In cc.Rows
                If ro.ItemArray(0).ToString.Trim <> "" Then
                    For Each it As TreeNode In TV_rel_lc.Nodes
                        If ro.ItemArray(0).ToString.Trim = it.Text.ToString Then
                            it.Nodes.Add(ro.ItemArray(1).ToString.Trim)
                            it.Nodes(it.Nodes.Count - 1).ContextMenuStrip = Categorias
                        End If
                    Next
                End If
            Next

            s = SQLCon.TPMdef_rel
            Dim filter_s = s.DefaultView.ToTable(True, "Categoria_ID", "Asset", "Station")
            For Each ro As DataRow In filter_s.Rows
                For Each it As TreeNode In TV_rel_lc.Nodes
                    If ro.ItemArray(1).ToString.Trim = it.Text.ToString Then
                        For Each itt As TreeNode In it.Nodes
                            If ro.ItemArray(2).ToString.Trim = itt.Text.ToString.Trim Then
                                itt.Nodes.Add(ro.ItemArray(0).ToString.Trim & " - " & DataGridView1.Rows(ro.ItemArray(0).ToString - 1).Cells(1).Value.ToString)
                                itt.Nodes(itt.Nodes.Count - 1).Tag = ro.ItemArray(0).ToString.Trim
                                itt.Nodes(itt.Nodes.Count - 1).ContextMenuStrip = Elemento
                                Dim filter_ss = s.Select("Categoria_ID = '" & ro.ItemArray(0).ToString & "' AND Asset= '" & ro.ItemArray(1).ToString & "' AND Station = '" & ro.ItemArray(2).ToString & "'")
                                If filter_ss.Count > 0 Then
                                    For i = 0 To filter_ss.Count - 1
                                        itt.Nodes(itt.Nodes.Count - 1).Nodes.Add(filter_ss(i).ItemArray(4).ToString)
                                        itt.Nodes(itt.Nodes.Count - 1).Nodes(itt.Nodes(itt.Nodes.Count - 1).Nodes.Count - 1).Tag = filter_ss(i).ItemArray(0)
                                        itt.Nodes(itt.Nodes.Count - 1).Nodes(itt.Nodes(itt.Nodes.Count - 1).Nodes.Count - 1).ContextMenuStrip = ContextMenuStrip1
                                    Next
                                End If
                                Exit For
                            End If

                        Next
                        Exit For
                    End If
                Next

            Next
            '    TV_rel_lc.ContextMenuStrip = Categorias
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub Cat_ayuda_visual()
        Try
            s = SQLCon.TPMcategories
            Dim ss As DataTable = s.DefaultView.ToTable
            If midataset.Tables("Categorias") IsNot Nothing Then
                midataset.Tables.Remove("Categorias")
            End If
            ss.TableName = "Categorias"
            midataset.Tables.Add(ss)
            DataGridView1.DataSource = Nothing
            DataGridView1.Columns.Clear()
            DataGridView1.DataSource = midataset.Tables("Categorias")
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(4).Visible = False
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Dim r As New DataGridViewTextBoxColumn
            r.Name = "Simbolo"

            r.HeaderText = "Símbolo"
            DataGridView1.Columns.Add(r)
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub



    'Tab control 2
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_color.Click

        cd.Location = New Point(Me.Width \ 2, Me.Height \ 2)
        cd.StartPosition = FormStartPosition.CenterScreen
        cd.Show()

    End Sub



    Private Sub cd_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cd.MouseDown

        lbl_vp.ForeColor = cd.SelectedColor

    End Sub

    Private Sub Add_category_click(sender As Object, e As EventArgs) Handles Add_category.Click
        Try
            Dim add As New Add_element
            Dim agregar_pendiente As String
            If add.ShowDialog = DialogResult.OK Then
                agregar_pendiente = add.texto
                add.Dispose()
                add = Nothing
                Dim re = SQLCon.TPMcategoriesInsert(agregar_pendiente)
                If re > 0 Then
                    Cargar_categorias()
                End If
            Else
                agregar_pendiente = ""
                add.Dispose()
                add = Nothing
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Add_defect_Click(sender As Object, e As EventArgs) Handles Add_defect.Click
        Try
            Dim add As New Add_element
            Dim agregar_defecto As String
            If add.ShowDialog = DialogResult.OK Then
                agregar_defecto = add.texto
                add.Dispose()
                add = Nothing
                Dim res = SQLCon.TPMdefectsInsert(agregar_defecto)
                If res > 0 Then
                    Dim re As New ListViewItem
                    re.Text = agregar_defecto
                    re.Tag = res
                    lv_defectos.Items.Add(re)
                Else
                    MsgBox("No se ha efectuado el cambio", MsgBoxStyle.Critical)
                End If
            Else
                agregar_defecto = ""
                add.Dispose()
                add = Nothing
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Delete_category_click(sender As Object, e As EventArgs) Handles btn_delete_cat.Click
        Try
            Dim id As Integer = dtg_categoria.CurrentRow.Cells(0).Value
            Dim re As DialogResult
            re = MsgBox("Seguro que desea eliminar esta categoría? ", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Eliminar Categoría")
            If re = DialogResult.Yes Then

                Dim cnt = SQLCon.TPMCategoriesCount(id)
                If cnt > 0 Then
                    MsgBox("La categoría seleccionada contiene varios elementos" & vbCrLf & "En una o varias operaciones" & vbCrLf & "elimine todos sus elementos ", MsgBoxStyle.Exclamation, "Eliminar categoría")
                    Exit Sub
                End If

                Dim res = SQLCon.TPMcategoriesDelete(id)
                If res > 0 Then
                    Cargar_categorias()
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Delete_defect_Click(sender As Object, e As EventArgs) Handles Delete_defect.Click
        Try
            If lv_defectos.SelectedItems.Count < 1 Then
                MsgBox("Seleccione un elemento de la lista", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Seguro que desea eliminar este defecto? ", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Eliminar Defecto") <> MsgBoxResult.Yes Then Exit Sub


            Dim id As Integer = lv_defectos.SelectedItems(0).Tag

            Dim cnt = SQLCon.TPMdefectsDeleteCount(id)
            If cnt > 0 Then
                MsgBox("El defecto seleccionado aparece en varios TPM realizados" & vbCrLf & "En una o varias operaciones" & vbCrLf & "No se puede eliminar ", MsgBoxStyle.Exclamation, "Eliminar categoría")
                Exit Sub
            End If

            Dim re = SQLCon.TPMdefectsDelete(id)
            If re > 0 Then
                lv_defectos.SelectedItems(0).Remove()
            Else
                MsgBox("El defecto no fue eliminado")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Edit_defect_Click(sender As Object, e As EventArgs) Handles Edit_defect.Click
        Try
            If lv_defectos.SelectedItems.Count < 1 Then
                MsgBox("Seleccione un elemento de la lista", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim id As Integer = lv_defectos.SelectedItems(0).Tag
            Dim agregar_defecto As String
            Dim add As New Add_element
            add.TextBox1.Text = lv_defectos.SelectedItems(0).Text
            add.Button1.Text = "Update"
            add.Text = "Update"
            add.Label1.Text = "Text"
            If add.ShowDialog() = DialogResult.OK Then
                Dim new_text = add.texto
                If new_text = lv_defectos.SelectedItems(0).Text Then Exit Sub
                add.Dispose()
                add = Nothing
                Dim re = SQLCon.TPMdefectsUpdate(id, new_text)
                If re > 0 Then
                    lv_defectos.SelectedItems(0).Text = new_text
                Else
                    MsgBox("Cambio no realizado", MsgBoxStyle.Critical)
                End If
            Else
                add.Dispose()
                add = Nothing
                Exit Sub

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_simbolo.SelectedIndexChanged
        Try
            If sender.SelectedIndex <> -1 Then
                lbl_vp.Text = CType(sender, ComboBox).Text
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Sub Cargar_categorias()
        Try
            s = SQLCon.TPMcategories
            Dim ss As DataTable = s.DefaultView.ToTable
            If midataset.Tables("Categorias") IsNot Nothing Then
                midataset.Tables.Remove("Categorias")
            End If
            ss.TableName = "Categorias"
            midataset.Tables.Add(ss)
            dtg_categoria.DataSource = Nothing
            dtg_categoria.DataSource = midataset.Tables("Categorias")
            If TV_rel_lc.Nodes.Count > 0 Then Tree_view_lineas()
            Cat_ayuda_visual()
            groupbox_false()
            GroupBox2.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub Cargar_defectos()
        Try
            s = SQLCon.TPMdefects
            Dim sss As DataTable = s.DefaultView.ToTable
            If midataset.Tables("Defectos") IsNot Nothing Then
                midataset.Tables.Remove("Defectos")
            End If
            sss.TableName = "Defectos"
            midataset.Tables.Add(sss)
            lv_defectos.Items.Clear()
            For Each it As DataRow In midataset.Tables("Defectos").Rows
                Dim et As New ListViewItem
                et.Text = it.Item(1).ToString
                et.Tag = it.Item(0).ToString
                ' et.SubItems.Add(it.Item(1).ToString)
                '    et.Tag = it.Item(0).ToString
                '  et.Text = it.Item(1).ToString
                lv_defectos.Items.Add(et)
            Next


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub groupbox_false()
        Try
            last_index = -2
            Txt_categoria.Text = ""
            cmb_simbolo.SelectedIndex = -1
            lbl_vp.ForeColor = Drawing.Color.Black
            GroupBox1.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub groupbox_true()
        Try
            GroupBox1.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_categoria.CellDoubleClick
        Try
            If e.RowIndex < 0 Then
                Exit Sub
            End If
            Console.WriteLine("")
            If e.RowIndex = last_index Then Exit Sub

            last_index = e.RowIndex

            'Cargar datos 
            Txt_categoria.Text = CType(sender, DataGridView).CurrentRow.Cells(1).Value.ToString
            cmb_simbolo.SelectedIndex = CType(sender, DataGridView).CurrentRow.Cells(2).Value - 1
            lbl_vp.ForeColor = Drawing.Color.FromName(CType(sender, DataGridView).CurrentRow.Cells("ColorName").Value.ToString)

            GroupBox2.Enabled = False
            groupbox_true()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel_cat.Click
        Try
            groupbox_false()
            GroupBox2.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_update_cat.Click
        Try
            Dim id As Integer = dtg_categoria.CurrentRow.Cells(0).Value
            Dim re = SQLCon.TPMcategoriesUpdate(id, Txt_categoria.Text, cmb_simbolo.SelectedIndex + 1, lbl_vp.ForeColor.Name.ToString)
            If re > 0 Then
                Cargar_categorias()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        Try
            If e.ColumnIndex = 5 Then
                Select Case DataGridView1.Rows(e.RowIndex).Cells(2).Value
                    Case 0

                    Case 1
                        DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "○"

                    Case 2
                        DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "□"
                    Case Else

                End Select
                e.CellStyle.ForeColor = Color.FromName(DataGridView1.Rows(e.RowIndex).Cells("ColorName").Value)
                e.CellStyle.Font = New Font("Microsoft Sans Serif", 25, FontStyle.Bold)
                Console.WriteLine("")
            End If




        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Dim myselectednode
    Private Sub ampos_MouseDown(sender As Object, e As MouseEventArgs) Handles TV_rel_lc.MouseDown
        myselectednode = TV_rel_lc.GetNodeAt(e.X, e.Y)
    End Sub
    Private Sub EditarToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click, EditarToolStripMenuItem2.Click, EliminarElementoToolStripMenuItem.Click
        Try

            Select Case sender.Text
                Case "Agregar elemento"
                    Try
                        Dim add As New Add_element
                        Dim agregar_defecto As String
                        If add.ShowDialog = DialogResult.OK Then
                            agregar_defecto = add.texto
                            add.Dispose()
                            add = Nothing

                            Dim cat_id = CType(myselectednode, TreeNode).Tag
                            Dim asset = CType(myselectednode, TreeNode).Parent.Parent.Text
                            Dim station = CType(myselectednode, TreeNode).Parent.Text

                            Dim res = SQLCon.TPMdef_rel_Insert(cat_id, asset, station, agregar_defecto)

                            If res > 0 Then
                                CType(myselectednode, TreeNode).Nodes.Add(agregar_defecto)
                                CType(myselectednode, TreeNode).Nodes(CType(myselectednode, TreeNode).Nodes.Count - 1).Tag = res
                                CType(myselectednode, TreeNode).Nodes(CType(myselectednode, TreeNode).Nodes.Count - 1).ContextMenuStrip = ContextMenuStrip1
                            Else
                                MsgBox("No se ha efectuado el cambio", MsgBoxStyle.Critical)
                            End If
                        Else
                            agregar_defecto = ""
                            add.Dispose()
                            add = Nothing
                            Exit Sub
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try

                Case "Editar elemento"
                    Dim id = myselectednode.tag
                    Dim add As New Add_element
                    add.TextBox1.Text = myselectednode.Text.ToString
                    add.Button1.Text = "Update"
                    add.Text = "Update"
                    add.Label1.Text = "Text"
                    If add.ShowDialog() = DialogResult.OK Then
                        Dim new_text = add.texto
                        If new_text = myselectednode.Text Then Exit Sub
                        add.Dispose()
                        add = Nothing

                        Dim re = SQLCon.TPMdef_rel_Update(myselectednode.tag, new_text)
                        If re > 0 Then
                            myselectednode.Text = new_text
                        Else
                            MsgBox("Cambio no realizado", MsgBoxStyle.Critical)
                        End If
                    Else
                        add.Dispose()
                        add = Nothing
                        Exit Sub

                    End If


                Case "Eliminar elemento"
                    Dim id = myselectednode.tag
                    If MsgBox("Seguro que desea eliminar el elemento seleccionado", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim re = SQLCon.TPMdef_rel_Delete(id)
                        If re > 0 Then
                            CType(myselectednode, TreeNode).Remove()
                        Else
                            MsgBox("No se pudo eliminar el nodo")
                        End If
                    End If

            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Agregar_categorias_Click(sender As Object, e As EventArgs) Handles Agregar_categorias.Click, EditarToolStripMenuItem.Click
        Try
            Console.WriteLine("")

            Select Case sender.text
                Case "Agregar categoria"
                    Dim r As New Add_category
                    If r.ShowDialog = DialogResult.OK Then
                        Console.Write("")
                        Dim categoria = r.ComboBox1.SelectedValue
                        Dim categoria_text = r.ComboBox1.Text
                        Dim station = CType(myselectednode, TreeNode).Text
                        Dim asset = CType(myselectednode, TreeNode).Parent.Text
                        Dim element = r.TextBox1.Text.Trim
                        Dim re = SQLCon.TPMdef_rel_Insert(categoria, asset, station, element)
                        If re > 0 Then
                            Dim agregado As Boolean = False
                            For Each node As TreeNode In CType(myselectednode, TreeNode).Nodes
                                If categoria = node.Tag Then
                                    node.Nodes.Add(element)
                                    node.Nodes(CType(node, TreeNode).Nodes.Count - 1).Tag = re
                                    node.Nodes(CType(node, TreeNode).Nodes.Count - 1).ContextMenuStrip = ContextMenuStrip1
                                    agregado = True
                                    Exit For
                                ElseIf categoria < node.Tag Then
                                    CType(myselectednode, TreeNode).Nodes.Insert(categoria - 1, categoria.ToString + " - " + categoria_text)
                                    CType(myselectednode, TreeNode).Nodes.Item(categoria - 1).Tag = categoria
                                    CType(myselectednode, TreeNode).Nodes.Item(categoria - 1).ContextMenuStrip = Elemento
                                    CType(CType(myselectednode, TreeNode).Nodes.Item(categoria - 1), TreeNode).Nodes.Add(element)
                                    CType(CType(myselectednode, TreeNode).Nodes.Item(categoria - 1), TreeNode).LastNode.Tag = re
                                    CType(CType(myselectednode, TreeNode).Nodes.Item(categoria - 1), TreeNode).LastNode.ContextMenuStrip = ContextMenuStrip1
                                    agregado = True
                                    Exit For
                                End If
                            Next
                            If agregado = False Then
                                CType(myselectednode, TreeNode).Nodes.Insert(categoria - 1, categoria.ToString + " - " + categoria_text)
                                CType(myselectednode, TreeNode).Nodes.Item(categoria - 1).Tag = categoria
                                CType(myselectednode, TreeNode).Nodes.Item(categoria - 1).ContextMenuStrip = Elemento
                                CType(CType(myselectednode, TreeNode).Nodes.Item(categoria - 1), TreeNode).Nodes.Add(element)
                                CType(CType(myselectednode, TreeNode).Nodes.Item(categoria - 1), TreeNode).LastNode.Tag = re
                                CType(CType(myselectednode, TreeNode).Nodes.Item(categoria - 1), TreeNode).LastNode.ContextMenuStrip = ContextMenuStrip1
                            End If
                            'Tree_view_lineas()
                        End If
                    Else

                    End If

                Case "Eliminar categoria"
                    If MsgBox("Seguro que desea eliminar la relación entre la operación y la categoria con los elementos relacionados?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        Dim re = SQLCon.TPMcat_rel_delete(CType(myselectednode, TreeNode).Tag, CType(myselectednode, TreeNode).Parent.Parent.Text, CType(myselectednode, TreeNode).Parent.Text)
                        If re > 0 Then
                            CType(myselectednode, TreeNode).Remove()
                        End If

                    End If

            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


End Class
