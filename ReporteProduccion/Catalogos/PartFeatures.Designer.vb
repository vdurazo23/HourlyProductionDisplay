<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PartFeatures
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
        Me.EliminarFeatureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextFeatures = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextLineas.SuspendLayout()
        Me.ContextFeatures.SuspendLayout()
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
        Me.ContextLineas.Size = New System.Drawing.Size(183, 26)
        '
        'NuevaOpToolStripMenuItem
        '
        Me.NuevaOpToolStripMenuItem.Image = Global.ReporteProduccion.My.Resources.Resources._1386307661_new_file
        Me.NuevaOpToolStripMenuItem.Name = "NuevaOpToolStripMenuItem"
        Me.NuevaOpToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.NuevaOpToolStripMenuItem.Text = "Nueva Característica"
        '
        'EliminarFeatureToolStripMenuItem
        '
        Me.EliminarFeatureToolStripMenuItem.Image = Global.ReporteProduccion.My.Resources.Resources.Symbol_Delete
        Me.EliminarFeatureToolStripMenuItem.Name = "EliminarFeatureToolStripMenuItem"
        Me.EliminarFeatureToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.EliminarFeatureToolStripMenuItem.Text = "Eliminar Característica"
        '
        'ContextFeatures
        '
        Me.ContextFeatures.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminarFeatureToolStripMenuItem})
        Me.ContextFeatures.Name = "ContextOperaciones"
        Me.ContextFeatures.Size = New System.Drawing.Size(192, 48)
        '
        'PartFeatures
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(647, 430)
        Me.Controls.Add(Me.TreeView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PartFeatures"
        Me.Text = "StationsEquipment"
        Me.ContextLineas.ResumeLayout(False)
        Me.ContextFeatures.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ContextLineas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevaOpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarFeatureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextFeatures As System.Windows.Forms.ContextMenuStrip
End Class
