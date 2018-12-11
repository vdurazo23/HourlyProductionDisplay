<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StationsEquipment
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
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ContextLineas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevaOpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextStations = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarOperacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextEquipments = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextLineas.SuspendLayout()
        Me.ContextStations.SuspendLayout()
        Me.ContextEquipments.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.LabelEdit = True
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(647, 430)
        Me.TreeView1.TabIndex = 1
        '
        'ContextLineas
        '
        Me.ContextLineas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaOpToolStripMenuItem})
        Me.ContextLineas.Name = "ContextOperaciones"
        Me.ContextLineas.Size = New System.Drawing.Size(167, 26)
        '
        'NuevaOpToolStripMenuItem
        '
        Me.NuevaOpToolStripMenuItem.Image = Global.ReporteProduccion.My.Resources.Resources._1386307661_new_file
        Me.NuevaOpToolStripMenuItem.Name = "NuevaOpToolStripMenuItem"
        Me.NuevaOpToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.NuevaOpToolStripMenuItem.Text = "Nueva Operación"
        '
        'ContextStations
        '
        Me.ContextStations.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.EliminarOperacionToolStripMenuItem})
        Me.ContextStations.Name = "ContextOperaciones"
        Me.ContextStations.Size = New System.Drawing.Size(176, 48)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.ReporteProduccion.My.Resources.Resources._1386307661_new_file
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(175, 22)
        Me.ToolStripMenuItem1.Text = "Nuevo Equipo"
        '
        'EliminarOperacionToolStripMenuItem
        '
        Me.EliminarOperacionToolStripMenuItem.Image = Global.ReporteProduccion.My.Resources.Resources.Symbol_Delete
        Me.EliminarOperacionToolStripMenuItem.Name = "EliminarOperacionToolStripMenuItem"
        Me.EliminarOperacionToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.EliminarOperacionToolStripMenuItem.Text = "Eliminar Operacion"
        '
        'ContextEquipments
        '
        Me.ContextEquipments.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3})
        Me.ContextEquipments.Name = "ContextOperaciones"
        Me.ContextEquipments.Size = New System.Drawing.Size(158, 26)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Image = Global.ReporteProduccion.My.Resources.Resources.Symbol_Delete
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(157, 22)
        Me.ToolStripMenuItem3.Text = "Eliminar Equipo"
        '
        'StationsEquipment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(647, 430)
        Me.Controls.Add(Me.TreeView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "StationsEquipment"
        Me.Text = "StationsEquipment"
        Me.ContextLineas.ResumeLayout(False)
        Me.ContextStations.ResumeLayout(False)
        Me.ContextEquipments.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ContextLineas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevaOpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextStations As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarOperacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextEquipments As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
End Class
