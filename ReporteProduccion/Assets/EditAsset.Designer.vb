<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditAsset
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
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditAsset))
        Me.GridAssets = New Telerik.WinControls.UI.RadGridView()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.RadButton2 = New Telerik.WinControls.UI.RadButton()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.GridAssets, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridAssets.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridAssets
        '
        Me.GridAssets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAssets.Location = New System.Drawing.Point(13, 14)
        Me.GridAssets.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        '
        '
        '
        Me.GridAssets.MasterTemplate.AllowAddNewRow = False
        Me.GridAssets.MasterTemplate.AllowDeleteRow = False
        Me.GridAssets.MasterTemplate.AllowEditRow = False
        Me.GridAssets.MasterTemplate.EnableGrouping = False
        Me.GridAssets.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.GridAssets.Name = "GridAssets"
        Me.GridAssets.ReadOnly = True
        Me.GridAssets.Size = New System.Drawing.Size(836, 138)
        Me.GridAssets.TabIndex = 10
        Me.GridAssets.Text = "RadGridView1"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(375, 160)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(113, 17)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "Usar Rate Teórico"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'RadButton2
        '
        Me.RadButton2.ImageIndex = 1
        Me.RadButton2.ImageList = Me.ImageList1
        Me.RadButton2.Location = New System.Drawing.Point(436, 192)
        Me.RadButton2.Name = "RadButton2"
        Me.RadButton2.Size = New System.Drawing.Size(128, 59)
        Me.RadButton2.TabIndex = 13
        Me.RadButton2.Text = "Cancelar"
        Me.RadButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RadButton2.TextWrap = True
        '
        'RadButton1
        '
        Me.RadButton1.ImageIndex = 0
        Me.RadButton1.ImageList = Me.ImageList1
        Me.RadButton1.Location = New System.Drawing.Point(299, 192)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(128, 59)
        Me.RadButton1.TabIndex = 12
        Me.RadButton1.Text = "Guardar"
        Me.RadButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RadButton1.TextWrap = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Save.png")
        Me.ImageList1.Images.SetKeyName(1, "Delete.png")
        Me.ImageList1.Images.SetKeyName(2, "search_magnifying_glass_find-128.png")
        '
        'EditAsset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(862, 263)
        Me.Controls.Add(Me.RadButton2)
        Me.Controls.Add(Me.RadButton1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.GridAssets)
        Me.Name = "EditAsset"
        Me.Text = "EditAsset"
        CType(Me.GridAssets.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridAssets, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridAssets As Telerik.WinControls.UI.RadGridView
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents RadButton2 As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
