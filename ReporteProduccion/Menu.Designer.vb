<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu))
        Me.CboResource = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CboTurno = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RadPageView1 = New Telerik.WinControls.UI.RadPageView()
        Me.RadPageCaptura = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.RadPageViewPage2 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CboTurno2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.RadPageAssets = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadPageStations = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadPageDepartments = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadPageCharacteristics = New Telerik.WinControls.UI.RadPageViewPage()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LblUsername = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DonutShape1 = New Telerik.WinControls.Tests.DonutShape()
        Me.MediaShape1 = New Telerik.WinControls.Tests.MediaShape()
        Me.RadPageTPM = New Telerik.WinControls.UI.RadPageViewPage()
        Me.GroupBox1.SuspendLayout()
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageView1.SuspendLayout()
        Me.RadPageCaptura.SuspendLayout()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CboResource
        '
        Me.CboResource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboResource.FormattingEnabled = True
        resources.ApplyResources(Me.CboResource, "CboResource")
        Me.CboResource.Name = "CboResource"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'DateTimePicker1
        '
        resources.ApplyResources(Me.DateTimePicker1, "DateTimePicker1")
        Me.DateTimePicker1.Name = "DateTimePicker1"
        '
        'CheckBox1
        '
        resources.ApplyResources(Me.CheckBox1, "CheckBox1")
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CboTurno)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'CboTurno
        '
        Me.CboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTurno.FormattingEnabled = True
        resources.ApplyResources(Me.CboTurno, "CboTurno")
        Me.CboTurno.Name = "CboTurno"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'RadPageView1
        '
        resources.ApplyResources(Me.RadPageView1, "RadPageView1")
        Me.RadPageView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.RadPageView1.Controls.Add(Me.RadPageCaptura)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage2)
        Me.RadPageView1.Controls.Add(Me.RadPageAssets)
        Me.RadPageView1.Controls.Add(Me.RadPageStations)
        Me.RadPageView1.Controls.Add(Me.RadPageDepartments)
        Me.RadPageView1.Controls.Add(Me.RadPageCharacteristics)
        Me.RadPageView1.Controls.Add(Me.RadPageTPM)
        Me.RadPageView1.ImageList = Me.ImageList1
        Me.RadPageView1.Name = "RadPageView1"
        Me.RadPageView1.PageBackColor = System.Drawing.Color.White
        Me.RadPageView1.SelectedPage = Me.RadPageCaptura
        Me.RadPageView1.ViewMode = Telerik.WinControls.UI.PageViewMode.Backstage
        '
        'RadPageCaptura
        '
        resources.ApplyResources(Me.RadPageCaptura, "RadPageCaptura")
        Me.RadPageCaptura.BackColor = System.Drawing.Color.White
        Me.RadPageCaptura.Controls.Add(Me.RadButton1)
        Me.RadPageCaptura.Controls.Add(Me.Label1)
        Me.RadPageCaptura.Controls.Add(Me.GroupBox1)
        Me.RadPageCaptura.Controls.Add(Me.CheckBox1)
        Me.RadPageCaptura.Controls.Add(Me.CboResource)
        Me.RadPageCaptura.ItemSize = New System.Drawing.SizeF(225.0!, 45.0!)
        Me.RadPageCaptura.Name = "RadPageCaptura"
        '
        'RadButton1
        '
        resources.ApplyResources(Me.RadButton1, "RadButton1")
        Me.RadButton1.ImageList = Me.ImageList1
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.TextWrap = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1443760137_preferences-system-time.png")
        '
        'RadPageViewPage2
        '
        Me.RadPageViewPage2.Controls.Add(Me.GroupBox2)
        Me.RadPageViewPage2.Controls.Add(Me.CheckBox2)
        Me.RadPageViewPage2.ItemSize = New System.Drawing.SizeF(225.0!, 45.0!)
        resources.ApplyResources(Me.RadPageViewPage2, "RadPageViewPage2")
        Me.RadPageViewPage2.Name = "RadPageViewPage2"
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Controls.Add(Me.CboTurno2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'CboTurno2
        '
        Me.CboTurno2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTurno2.FormattingEnabled = True
        resources.ApplyResources(Me.CboTurno2, "CboTurno2")
        Me.CboTurno2.Name = "CboTurno2"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'DateTimePicker2
        '
        resources.ApplyResources(Me.DateTimePicker2, "DateTimePicker2")
        Me.DateTimePicker2.Name = "DateTimePicker2"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'CheckBox2
        '
        resources.ApplyResources(Me.CheckBox2, "CheckBox2")
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'RadPageAssets
        '
        resources.ApplyResources(Me.RadPageAssets, "RadPageAssets")
        Me.RadPageAssets.ItemSize = New System.Drawing.SizeF(225.0!, 45.0!)
        Me.RadPageAssets.Name = "RadPageAssets"
        '
        'RadPageStations
        '
        resources.ApplyResources(Me.RadPageStations, "RadPageStations")
        Me.RadPageStations.ItemSize = New System.Drawing.SizeF(225.0!, 45.0!)
        Me.RadPageStations.Name = "RadPageStations"
        '
        'RadPageDepartments
        '
        Me.RadPageDepartments.ItemSize = New System.Drawing.SizeF(225.0!, 45.0!)
        resources.ApplyResources(Me.RadPageDepartments, "RadPageDepartments")
        Me.RadPageDepartments.Name = "RadPageDepartments"
        '
        'RadPageCharacteristics
        '
        Me.RadPageCharacteristics.ItemSize = New System.Drawing.SizeF(225.0!, 45.0!)
        resources.ApplyResources(Me.RadPageCharacteristics, "RadPageCharacteristics")
        Me.RadPageCharacteristics.Name = "RadPageCharacteristics"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.LblUsername})
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.Name = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        resources.ApplyResources(Me.ToolStripStatusLabel1, "ToolStripStatusLabel1")
        '
        'LblUsername
        '
        Me.LblUsername.Name = "LblUsername"
        resources.ApplyResources(Me.LblUsername, "LblUsername")
        '
        'RadPageTPM
        '
        Me.RadPageTPM.ItemSize = New System.Drawing.SizeF(225.0!, 45.0!)
        resources.ApplyResources(Me.RadPageTPM, "RadPageTPM")
        Me.RadPageTPM.Name = "RadPageTPM"
        '
        'Menu
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.RadPageView1)
        Me.IsMdiContainer = True
        Me.Name = "Menu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageView1.ResumeLayout(False)
        Me.RadPageCaptura.ResumeLayout(False)
        Me.RadPageCaptura.PerformLayout()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage2.ResumeLayout(False)
        Me.RadPageViewPage2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CboResource As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CboTurno As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RadPageView1 As Telerik.WinControls.UI.RadPageView
    Friend WithEvents RadPageCaptura As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadPageAssets As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadPageStations As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadPageDepartments As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadPageViewPage2 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CboTurno2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents RadPageCharacteristics As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LblUsername As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DonutShape1 As Telerik.WinControls.Tests.DonutShape
    Friend WithEvents MediaShape1 As Telerik.WinControls.Tests.MediaShape
    Friend WithEvents RadPageTPM As Telerik.WinControls.UI.RadPageViewPage

End Class
