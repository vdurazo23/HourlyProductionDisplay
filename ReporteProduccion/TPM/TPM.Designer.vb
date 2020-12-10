<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TPM
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BtnNuevoTPM = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.BtnDown = New System.Windows.Forms.Button()
        Me.BtnUp = New System.Windows.Forms.Button()
        Me.BtnEliminarElemento = New System.Windows.Forms.Button()
        Me.BtnNuevoElemento = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.BtnEditarTPM = New System.Windows.Forms.Button()
        Me.BtnEliminarTPM = New System.Windows.Forms.Button()
        Me.BtnEditarElemento = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TV_rel_lc = New System.Windows.Forms.TreeView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_cat = New System.Windows.Forms.Label()
        Me.lv_defectos = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lbl_def = New System.Windows.Forms.Label()
        Me.dtg_categoria = New System.Windows.Forms.DataGridView()
        Me.Add_category = New System.Windows.Forms.Button()
        Me.Edit_defect = New System.Windows.Forms.Button()
        Me.Delete_defect = New System.Windows.Forms.Button()
        Me.Add_defect = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_cancel_cat = New System.Windows.Forms.Button()
        Me.Txt_categoria = New System.Windows.Forms.TextBox()
        Me.btn_delete_cat = New System.Windows.Forms.Button()
        Me.lbl_txt_cat = New System.Windows.Forms.Label()
        Me.btn_update_cat = New System.Windows.Forms.Button()
        Me.cmb_simbolo = New System.Windows.Forms.ComboBox()
        Me.lbl_vp = New System.Windows.Forms.Label()
        Me.btn_color = New System.Windows.Forms.Button()
        Me.lbl_sim = New System.Windows.Forms.Label()
        Me.lbl_vp_0 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarElementoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Elemento = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Categorias = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Agregar_categorias = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtg_categoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Elemento.SuspendLayout()
        Me.Categorias.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnNuevoTPM
        '
        Me.BtnNuevoTPM.Location = New System.Drawing.Point(6, 6)
        Me.BtnNuevoTPM.Name = "BtnNuevoTPM"
        Me.BtnNuevoTPM.Size = New System.Drawing.Size(99, 46)
        Me.BtnNuevoTPM.TabIndex = 2
        Me.BtnNuevoTPM.Text = "Nuevo TPM"
        Me.BtnNuevoTPM.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoScroll = True
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 372)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(998, 240)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(6, 58)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(428, 308)
        Me.ListBox1.TabIndex = 4
        '
        'BtnDown
        '
        Me.BtnDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnDown.Enabled = False
        Me.BtnDown.Image = Global.ReporteProduccion.My.Resources.Resources.icons8_abajo_48__1_
        Me.BtnDown.Location = New System.Drawing.Point(1439, 114)
        Me.BtnDown.Name = "BtnDown"
        Me.BtnDown.Size = New System.Drawing.Size(54, 50)
        Me.BtnDown.TabIndex = 9
        Me.BtnDown.UseVisualStyleBackColor = True
        '
        'BtnUp
        '
        Me.BtnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnUp.Enabled = False
        Me.BtnUp.Image = Global.ReporteProduccion.My.Resources.Resources.icons8_arriba_48__2_
        Me.BtnUp.Location = New System.Drawing.Point(1439, 58)
        Me.BtnUp.Name = "BtnUp"
        Me.BtnUp.Size = New System.Drawing.Size(54, 50)
        Me.BtnUp.TabIndex = 8
        Me.BtnUp.UseVisualStyleBackColor = True
        '
        'BtnEliminarElemento
        '
        Me.BtnEliminarElemento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnEliminarElemento.Location = New System.Drawing.Point(675, 2)
        Me.BtnEliminarElemento.Name = "BtnEliminarElemento"
        Me.BtnEliminarElemento.Size = New System.Drawing.Size(113, 50)
        Me.BtnEliminarElemento.TabIndex = 7
        Me.BtnEliminarElemento.Text = "Eliminar elemento"
        Me.BtnEliminarElemento.UseVisualStyleBackColor = True
        '
        'BtnNuevoElemento
        '
        Me.BtnNuevoElemento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNuevoElemento.Location = New System.Drawing.Point(440, 2)
        Me.BtnNuevoElemento.Name = "BtnNuevoElemento"
        Me.BtnNuevoElemento.Size = New System.Drawing.Size(109, 50)
        Me.BtnNuevoElemento.TabIndex = 6
        Me.BtnNuevoElemento.Text = "Nuevo elemento"
        Me.BtnNuevoElemento.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.BtnNuevoElemento.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(440, 58)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(564, 308)
        Me.ListView1.TabIndex = 10
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'BtnEditarTPM
        '
        Me.BtnEditarTPM.Location = New System.Drawing.Point(111, 6)
        Me.BtnEditarTPM.Name = "BtnEditarTPM"
        Me.BtnEditarTPM.Size = New System.Drawing.Size(105, 46)
        Me.BtnEditarTPM.TabIndex = 11
        Me.BtnEditarTPM.Text = "Editar TPM"
        Me.BtnEditarTPM.UseVisualStyleBackColor = True
        '
        'BtnEliminarTPM
        '
        Me.BtnEliminarTPM.Location = New System.Drawing.Point(222, 6)
        Me.BtnEliminarTPM.Name = "BtnEliminarTPM"
        Me.BtnEliminarTPM.Size = New System.Drawing.Size(97, 46)
        Me.BtnEliminarTPM.TabIndex = 12
        Me.BtnEliminarTPM.Text = "Eliminar TPM"
        Me.BtnEliminarTPM.UseVisualStyleBackColor = True
        '
        'BtnEditarElemento
        '
        Me.BtnEditarElemento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnEditarElemento.Location = New System.Drawing.Point(555, 2)
        Me.BtnEditarElemento.Name = "BtnEditarElemento"
        Me.BtnEditarElemento.Size = New System.Drawing.Size(114, 50)
        Me.BtnEditarElemento.TabIndex = 13
        Me.BtnEditarElemento.Text = "Editar elemento"
        Me.BtnEditarElemento.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1020, 644)
        Me.TabControl1.TabIndex = 14
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.Controls.Add(Me.BtnNuevoTPM)
        Me.TabPage1.Controls.Add(Me.BtnEditarElemento)
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage1.Controls.Add(Me.BtnEliminarTPM)
        Me.TabPage1.Controls.Add(Me.ListBox1)
        Me.TabPage1.Controls.Add(Me.BtnEditarTPM)
        Me.TabPage1.Controls.Add(Me.BtnNuevoElemento)
        Me.TabPage1.Controls.Add(Me.ListView1)
        Me.TabPage1.Controls.Add(Me.BtnEliminarElemento)
        Me.TabPage1.Controls.Add(Me.BtnDown)
        Me.TabPage1.Controls.Add(Me.BtnUp)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1012, 618)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TPM"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.AutoScroll = True
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Controls.Add(Me.TV_rel_lc)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1012, 618)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Elementos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.Location = New System.Drawing.Point(525, 6)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Size = New System.Drawing.Size(479, 416)
        Me.DataGridView1.TabIndex = 3
        '
        'TV_rel_lc
        '
        Me.TV_rel_lc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TV_rel_lc.Location = New System.Drawing.Point(3, 6)
        Me.TV_rel_lc.Name = "TV_rel_lc"
        Me.TV_rel_lc.Size = New System.Drawing.Size(516, 604)
        Me.TV_rel_lc.TabIndex = 2
        '
        'TabPage3
        '
        Me.TabPage3.AutoScroll = True
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1012, 618)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Categorías y defectos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_cat)
        Me.GroupBox2.Controls.Add(Me.lv_defectos)
        Me.GroupBox2.Controls.Add(Me.lbl_def)
        Me.GroupBox2.Controls.Add(Me.dtg_categoria)
        Me.GroupBox2.Controls.Add(Me.Add_category)
        Me.GroupBox2.Controls.Add(Me.Edit_defect)
        Me.GroupBox2.Controls.Add(Me.Delete_defect)
        Me.GroupBox2.Controls.Add(Me.Add_defect)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(997, 374)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        '
        'lbl_cat
        '
        Me.lbl_cat.AutoSize = True
        Me.lbl_cat.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.lbl_cat.Location = New System.Drawing.Point(6, 16)
        Me.lbl_cat.Name = "lbl_cat"
        Me.lbl_cat.Size = New System.Drawing.Size(107, 25)
        Me.lbl_cat.TabIndex = 8
        Me.lbl_cat.Text = "Categorias"
        '
        'lv_defectos
        '
        Me.lv_defectos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5})
        Me.lv_defectos.HideSelection = False
        Me.lv_defectos.Location = New System.Drawing.Point(660, 44)
        Me.lv_defectos.MultiSelect = False
        Me.lv_defectos.Name = "lv_defectos"
        Me.lv_defectos.Size = New System.Drawing.Size(217, 318)
        Me.lv_defectos.TabIndex = 9
        Me.lv_defectos.UseCompatibleStateImageBehavior = False
        Me.lv_defectos.View = System.Windows.Forms.View.List
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Defecto"
        Me.ColumnHeader5.Width = 212
        '
        'lbl_def
        '
        Me.lbl_def.AutoSize = True
        Me.lbl_def.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_def.Location = New System.Drawing.Point(655, 16)
        Me.lbl_def.Name = "lbl_def"
        Me.lbl_def.Size = New System.Drawing.Size(97, 25)
        Me.lbl_def.TabIndex = 10
        Me.lbl_def.Text = "Defectos"
        '
        'dtg_categoria
        '
        Me.dtg_categoria.AllowUserToAddRows = False
        Me.dtg_categoria.AllowUserToDeleteRows = False
        Me.dtg_categoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_categoria.Location = New System.Drawing.Point(11, 44)
        Me.dtg_categoria.Name = "dtg_categoria"
        Me.dtg_categoria.ReadOnly = True
        Me.dtg_categoria.Size = New System.Drawing.Size(591, 318)
        Me.dtg_categoria.TabIndex = 16
        '
        'Add_category
        '
        Me.Add_category.Location = New System.Drawing.Point(608, 44)
        Me.Add_category.Name = "Add_category"
        Me.Add_category.Size = New System.Drawing.Size(41, 39)
        Me.Add_category.TabIndex = 11
        Me.Add_category.Text = "+"
        Me.Add_category.UseVisualStyleBackColor = True
        '
        'Edit_defect
        '
        Me.Edit_defect.Location = New System.Drawing.Point(883, 134)
        Me.Edit_defect.Name = "Edit_defect"
        Me.Edit_defect.Size = New System.Drawing.Size(41, 39)
        Me.Edit_defect.TabIndex = 15
        Me.Edit_defect.Text = "/-/-/-"
        Me.Edit_defect.UseVisualStyleBackColor = True
        '
        'Delete_defect
        '
        Me.Delete_defect.Location = New System.Drawing.Point(883, 89)
        Me.Delete_defect.Name = "Delete_defect"
        Me.Delete_defect.Size = New System.Drawing.Size(41, 39)
        Me.Delete_defect.TabIndex = 14
        Me.Delete_defect.Text = "-"
        Me.Delete_defect.UseVisualStyleBackColor = True
        '
        'Add_defect
        '
        Me.Add_defect.Location = New System.Drawing.Point(883, 44)
        Me.Add_defect.Name = "Add_defect"
        Me.Add_defect.Size = New System.Drawing.Size(41, 39)
        Me.Add_defect.TabIndex = 13
        Me.Add_defect.Text = "+"
        Me.Add_defect.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_cancel_cat)
        Me.GroupBox1.Controls.Add(Me.Txt_categoria)
        Me.GroupBox1.Controls.Add(Me.btn_delete_cat)
        Me.GroupBox1.Controls.Add(Me.lbl_txt_cat)
        Me.GroupBox1.Controls.Add(Me.btn_update_cat)
        Me.GroupBox1.Controls.Add(Me.cmb_simbolo)
        Me.GroupBox1.Controls.Add(Me.lbl_vp)
        Me.GroupBox1.Controls.Add(Me.btn_color)
        Me.GroupBox1.Controls.Add(Me.lbl_sim)
        Me.GroupBox1.Controls.Add(Me.lbl_vp_0)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 386)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(602, 117)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'btn_cancel_cat
        '
        Me.btn_cancel_cat.Location = New System.Drawing.Point(528, 80)
        Me.btn_cancel_cat.Name = "btn_cancel_cat"
        Me.btn_cancel_cat.Size = New System.Drawing.Size(68, 24)
        Me.btn_cancel_cat.TabIndex = 20
        Me.btn_cancel_cat.Text = "Cancelar"
        Me.btn_cancel_cat.UseVisualStyleBackColor = True
        '
        'Txt_categoria
        '
        Me.Txt_categoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Txt_categoria.Location = New System.Drawing.Point(18, 58)
        Me.Txt_categoria.Name = "Txt_categoria"
        Me.Txt_categoria.Size = New System.Drawing.Size(264, 26)
        Me.Txt_categoria.TabIndex = 17
        '
        'btn_delete_cat
        '
        Me.btn_delete_cat.Location = New System.Drawing.Point(528, 55)
        Me.btn_delete_cat.Name = "btn_delete_cat"
        Me.btn_delete_cat.Size = New System.Drawing.Size(68, 21)
        Me.btn_delete_cat.TabIndex = 12
        Me.btn_delete_cat.Text = "Eliminar"
        Me.btn_delete_cat.UseVisualStyleBackColor = True
        '
        'lbl_txt_cat
        '
        Me.lbl_txt_cat.AutoSize = True
        Me.lbl_txt_cat.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.lbl_txt_cat.Location = New System.Drawing.Point(13, 25)
        Me.lbl_txt_cat.Name = "lbl_txt_cat"
        Me.lbl_txt_cat.Size = New System.Drawing.Size(62, 25)
        Me.lbl_txt_cat.TabIndex = 18
        Me.lbl_txt_cat.Text = "Texto"
        '
        'btn_update_cat
        '
        Me.btn_update_cat.Location = New System.Drawing.Point(528, 25)
        Me.btn_update_cat.Name = "btn_update_cat"
        Me.btn_update_cat.Size = New System.Drawing.Size(68, 24)
        Me.btn_update_cat.TabIndex = 19
        Me.btn_update_cat.Text = "Modificar"
        Me.btn_update_cat.UseVisualStyleBackColor = True
        '
        'cmb_simbolo
        '
        Me.cmb_simbolo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_simbolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.cmb_simbolo.FormattingEnabled = True
        Me.cmb_simbolo.Items.AddRange(New Object() {"○", "□"})
        Me.cmb_simbolo.Location = New System.Drawing.Point(288, 58)
        Me.cmb_simbolo.Name = "cmb_simbolo"
        Me.cmb_simbolo.Size = New System.Drawing.Size(59, 46)
        Me.cmb_simbolo.TabIndex = 4
        '
        'lbl_vp
        '
        Me.lbl_vp.AutoSize = True
        Me.lbl_vp.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.0!)
        Me.lbl_vp.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lbl_vp.Location = New System.Drawing.Point(443, 33)
        Me.lbl_vp.Name = "lbl_vp"
        Me.lbl_vp.Size = New System.Drawing.Size(57, 54)
        Me.lbl_vp.TabIndex = 0
        Me.lbl_vp.Text = "○"
        '
        'btn_color
        '
        Me.btn_color.Location = New System.Drawing.Point(353, 58)
        Me.btn_color.Name = "btn_color"
        Me.btn_color.Size = New System.Drawing.Size(61, 46)
        Me.btn_color.TabIndex = 3
        Me.btn_color.Text = "Color"
        Me.btn_color.UseVisualStyleBackColor = True
        '
        'lbl_sim
        '
        Me.lbl_sim.AutoSize = True
        Me.lbl_sim.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.lbl_sim.Location = New System.Drawing.Point(283, 25)
        Me.lbl_sim.Name = "lbl_sim"
        Me.lbl_sim.Size = New System.Drawing.Size(83, 25)
        Me.lbl_sim.TabIndex = 6
        Me.lbl_sim.Text = "Símbolo"
        '
        'lbl_vp_0
        '
        Me.lbl_vp_0.AutoSize = True
        Me.lbl_vp_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lbl_vp_0.Location = New System.Drawing.Point(432, 17)
        Me.lbl_vp_0.Name = "lbl_vp_0"
        Me.lbl_vp_0.Size = New System.Drawing.Size(82, 17)
        Me.lbl_vp_0.TabIndex = 7
        Me.lbl_vp_0.Text = "Vista previa"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarToolStripMenuItem2, Me.EliminarElementoToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(171, 48)
        '
        'EditarToolStripMenuItem2
        '
        Me.EditarToolStripMenuItem2.Name = "EditarToolStripMenuItem2"
        Me.EditarToolStripMenuItem2.Size = New System.Drawing.Size(170, 22)
        Me.EditarToolStripMenuItem2.Text = "Editar elemento"
        '
        'EliminarElementoToolStripMenuItem
        '
        Me.EliminarElementoToolStripMenuItem.Name = "EliminarElementoToolStripMenuItem"
        Me.EliminarElementoToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.EliminarElementoToolStripMenuItem.Text = "Eliminar elemento"
        '
        'Elemento
        '
        Me.Elemento.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.EditarToolStripMenuItem})
        Me.Elemento.Name = "Elemento"
        Me.Elemento.Size = New System.Drawing.Size(170, 48)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(169, 22)
        Me.ToolStripMenuItem1.Text = "Agregar elemento"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.EditarToolStripMenuItem.Text = "Eliminar categoria"
        '
        'Categorias
        '
        Me.Categorias.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Agregar_categorias})
        Me.Categorias.Name = "Categorias"
        Me.Categorias.Size = New System.Drawing.Size(181, 48)
        '
        'Agregar_categorias
        '
        Me.Agregar_categorias.Name = "Agregar_categorias"
        Me.Agregar_categorias.Size = New System.Drawing.Size(180, 22)
        Me.Agregar_categorias.Text = "Agregar categoria"
        '
        'TPM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 644)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "TPM"
        Me.Text = "TPM"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtg_categoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Elemento.ResumeLayout(False)
        Me.Categorias.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnNuevoTPM As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents BtnNuevoElemento As Button
    Friend WithEvents BtnEliminarElemento As Button
    Friend WithEvents BtnUp As Button
    Friend WithEvents BtnDown As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents BtnEditarTPM As Button
    Friend WithEvents BtnEliminarTPM As Button
    Friend WithEvents BtnEditarElemento As Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TV_rel_lc As System.Windows.Forms.TreeView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_cat As System.Windows.Forms.Label
    Friend WithEvents lv_defectos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbl_def As System.Windows.Forms.Label
    Friend WithEvents dtg_categoria As System.Windows.Forms.DataGridView
    Friend WithEvents Add_category As System.Windows.Forms.Button
    Friend WithEvents Edit_defect As System.Windows.Forms.Button
    Friend WithEvents Delete_defect As System.Windows.Forms.Button
    Friend WithEvents Add_defect As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cancel_cat As System.Windows.Forms.Button
    Friend WithEvents Txt_categoria As System.Windows.Forms.TextBox
    Friend WithEvents btn_delete_cat As System.Windows.Forms.Button
    Friend WithEvents lbl_txt_cat As System.Windows.Forms.Label
    Friend WithEvents btn_update_cat As System.Windows.Forms.Button
    Friend WithEvents cmb_simbolo As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_vp As System.Windows.Forms.Label
    Friend WithEvents btn_color As System.Windows.Forms.Button
    Friend WithEvents lbl_sim As System.Windows.Forms.Label
    Friend WithEvents lbl_vp_0 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditarToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarElementoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Elemento As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Categorias As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Agregar_categorias As System.Windows.Forms.ToolStripMenuItem
End Class
