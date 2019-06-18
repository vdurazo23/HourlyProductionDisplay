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
            BtnNuevoTPM.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Nuevo")
            BtnNuevoElemento.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Nuevo")

            BtnEditarTPM.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Editar")
            BtnEditarElemento.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Editar")
            BtnUp.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Editar")
            BtnDown.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Editar")

            TableLayoutPanel1.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Editar")

            BtnEliminarTPM.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Eliminar")
            BtnEliminarElemento.Enabled = SQLCon.getPermiso(My.Settings.UserId, "Reporte Producción", "TPM", "Eliminar")

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnNuevoTPM.Click
        Try
            Dim n As New Add_element
            n.ComboBox1.Visible = False
            n.Label2.Visible = False
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
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles BtnUp.Click
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BtnNuevoElemento.Click
        Try
            If ListBox1.Items.Count = 0 Then Exit Sub
            Dim add As New Add_element
            If add.ShowDialog() = DialogResult.OK Then
                addelement = add.texto
                add.Dispose()
                add = Nothing
                Dim re = SQLCon.AddTPMelements(ListBox1.SelectedValue, ListView1.Items.Count + 1, addelement, add.ComboBox1.Text)
                If re = 1 Then
                    ListView1.Items.Add(addelement)
                    ListView1.Items(ListView1.Items.Count - 1).Tag = SQLCon.TPMelementTag(ListBox1.SelectedValue, addelement, ListView1.Items.Count)
                    ListView1.Items(ListView1.Items.Count - 1).BackColor = Color.FromName(add.ComboBox1.Text)
                End If
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles BtnEliminarElemento.Click
        Try

            If ListView1.Items.Count = 0 Or ListBox1.SelectedIndex = -1 Then Exit Sub
            Dim indice As Integer = ListView1.SelectedIndices.Item(0)
            If indice = -1 Then Exit Sub

            Dim check As Integer = SQLCon.TPM_ELEMENT_RESULT(ListView1.Items(indice).Tag)
            If check > 0 Then
                Dim a As DialogResult
                a = MsgBox("This element has a record. Do you really want to delete?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical)
                If a <> DialogResult.Yes Then
                    Exit Sub
                End If
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

    Private Sub Edit_element_Click(sender As Object, e As EventArgs) Handles BtnEditarElemento.Click
        Try
            If ListBox1.Items.Count = 0 Then Exit Sub
            If ListView1.SelectedIndices.Count = 0 Then Exit Sub
            Dim indice As Integer = ListView1.SelectedIndices.Item(0)
            If indice = -1 Then Exit Sub

            Dim add As New Add_element
            add.TextBox1.Text = ListView1.Items(indice).Text
            add.ComboBox1.Text = ListView1.Items(indice).BackColor.Name
            add.Button1.Text = "Update"
            add.Text = "Update"
            add.Label1.Text = "Text"
            If add.ShowDialog() = DialogResult.OK Then
                Dim new_text = add.texto
                'If new_text = ListView1.Items(indice).Text Then Exit Sub         
                Dim re = SQLCon.EditTPMelements(ListBox1.SelectedValue, new_text, ListView1.SelectedIndices(0) + 1, ListView1.SelectedItems(0).Tag, add.ComboBox1.Text)
                If re = 1 Then
                    ListView1.Items(indice).Text = new_text
                    ListView1.Items(indice).BackColor = Color.FromName(add.ComboBox1.Text)
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

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles BtnEliminarTPM.Click
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles BtnEditarTPM.Click
        Try
            If ListBox1.SelectedIndex < 0 Then Exit Sub
            Dim add As New Add_element
            add.TextBox1.Text = ListBox1.SelectedItem.Row.ItemArray(1).ToString
            add.Button1.Text = "Update"
            add.Text = "Update element"
            add.Label1.Text = "Name:"
            add.ComboBox1.Visible = False
            add.Label2.Visible = False
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
End Class
