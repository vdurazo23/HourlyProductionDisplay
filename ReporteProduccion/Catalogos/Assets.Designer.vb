<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Assets
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Assets))
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.RadButton3 = New Telerik.WinControls.UI.RadButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GridAssets = New Telerik.WinControls.UI.RadGridView()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.GridAssets, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridAssets.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadButton1
        '
        Me.RadButton1.ImageIndex = 0
        Me.RadButton1.ImageList = Me.ImageList1
        Me.RadButton1.Location = New System.Drawing.Point(3, 3)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(131, 50)
        Me.RadButton1.TabIndex = 6
        Me.RadButton1.Text = "Agregar Recurso (MARS)"
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
        'RadButton3
        '
        Me.RadButton3.ImageIndex = 2
        Me.RadButton3.ImageList = Me.ImageList1
        Me.RadButton3.Location = New System.Drawing.Point(150, 3)
        Me.RadButton3.Name = "RadButton3"
        Me.RadButton3.Size = New System.Drawing.Size(131, 50)
        Me.RadButton3.TabIndex = 7
        Me.RadButton3.Text = "Eliminar Recurso"
        Me.RadButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RadButton3.TextWrap = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.RadButton1)
        Me.Panel1.Controls.Add(Me.RadButton3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(929, 55)
        Me.Panel1.TabIndex = 8
        '
        'GridAssets
        '
        Me.GridAssets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridAssets.Location = New System.Drawing.Point(0, 55)
        Me.GridAssets.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        '
        '
        '
        Me.GridAssets.MasterTemplate.AllowAddNewRow = False
        Me.GridAssets.MasterTemplate.AllowDeleteRow = False
        Me.GridAssets.MasterTemplate.AllowEditRow = False
        Me.GridAssets.MasterTemplate.EnableGrouping = False
        Me.GridAssets.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.GridAssets.Name = "GridAssets"
        Me.GridAssets.ReadOnly = True
        Me.GridAssets.Size = New System.Drawing.Size(929, 424)
        Me.GridAssets.TabIndex = 9
        Me.GridAssets.Text = "RadGridView1"
        '
        'Assets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(929, 479)
        Me.Controls.Add(Me.GridAssets)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Assets"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recursos"
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.GridAssets.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridAssets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents RadButton3 As Telerik.WinControls.UI.RadButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GridAssets As Telerik.WinControls.UI.RadGridView
End Class
