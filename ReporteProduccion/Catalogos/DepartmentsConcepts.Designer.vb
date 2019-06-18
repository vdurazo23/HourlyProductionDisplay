<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DepartmentsConcepts
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DepartmentsConcepts))
        Me.ContextDepartments = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevaOpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarDepartamentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ContextConcepts = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextCodes = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextDepartments.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextConcepts.SuspendLayout()
        Me.ContextCodes.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextDepartments
        '
        Me.ContextDepartments.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaOpToolStripMenuItem, Me.EliminarDepartamentoToolStripMenuItem})
        Me.ContextDepartments.Name = "ContextOperaciones"
        Me.ContextDepartments.Size = New System.Drawing.Size(197, 70)
        '
        'NuevaOpToolStripMenuItem
        '
        Me.NuevaOpToolStripMenuItem.Image = Global.ReporteProduccion.My.Resources.Resources._1386307661_new_file
        Me.NuevaOpToolStripMenuItem.Name = "NuevaOpToolStripMenuItem"
        Me.NuevaOpToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.NuevaOpToolStripMenuItem.Text = "Nuevo Concepto"
        '
        'EliminarDepartamentoToolStripMenuItem
        '
        Me.EliminarDepartamentoToolStripMenuItem.Image = Global.ReporteProduccion.My.Resources.Resources.Symbol_Delete
        Me.EliminarDepartamentoToolStripMenuItem.Name = "EliminarDepartamentoToolStripMenuItem"
        Me.EliminarDepartamentoToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.EliminarDepartamentoToolStripMenuItem.Text = "Eliminar Departamento"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.RadButton1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(840, 55)
        Me.Panel1.TabIndex = 9
        '
        'RadButton1
        '
        Me.RadButton1.ImageIndex = 0
        Me.RadButton1.ImageList = Me.ImageList1
        Me.RadButton1.Location = New System.Drawing.Point(3, 3)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(131, 50)
        Me.RadButton1.TabIndex = 6
        Me.RadButton1.Text = "Nuevo Departamento"
        Me.RadButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RadButton1.TextWrap = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1386307661_new-file.png")
        Me.ImageList1.Images.SetKeyName(1, "Edit.png")
        Me.ImageList1.Images.SetKeyName(2, "Symbol-Delete.png")
        Me.ImageList1.Images.SetKeyName(3, "1378857715_quick_restart.png")
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.LabelEdit = True
        Me.TreeView1.Location = New System.Drawing.Point(0, 55)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(840, 526)
        Me.TreeView1.TabIndex = 11
        '
        'ContextConcepts
        '
        Me.ContextConcepts.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.ContextConcepts.Name = "ContextOperaciones"
        Me.ContextConcepts.Size = New System.Drawing.Size(173, 48)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.ReporteProduccion.My.Resources.Resources._1386307661_new_file
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(172, 22)
        Me.ToolStripMenuItem1.Text = "Nuevo Código"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = Global.ReporteProduccion.My.Resources.Resources.Symbol_Delete
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(172, 22)
        Me.ToolStripMenuItem2.Text = "Eliminar Concepto"
        '
        'ContextCodes
        '
        Me.ContextCodes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem4})
        Me.ContextCodes.Name = "ContextOperaciones"
        Me.ContextCodes.Size = New System.Drawing.Size(160, 26)
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Image = Global.ReporteProduccion.My.Resources.Resources.Symbol_Delete
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(159, 22)
        Me.ToolStripMenuItem4.Text = "Eliminar Codigo"
        '
        'DepartmentsConcepts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(840, 581)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "DepartmentsConcepts"
        Me.Text = "DepartmentsConcepts"
        Me.ContextDepartments.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextConcepts.ResumeLayout(False)
        Me.ContextCodes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextDepartments As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevaOpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents EliminarDepartamentoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ContextConcepts As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextCodes As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
