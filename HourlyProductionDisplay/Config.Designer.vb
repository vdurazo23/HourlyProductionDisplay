<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Config
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtMARSBd = New System.Windows.Forms.TextBox()
        Me.TxtMARSPwd = New System.Windows.Forms.TextBox()
        Me.TxtMARSUser = New System.Windows.Forms.TextBox()
        Me.TxtMarsServer = New System.Windows.Forms.TextBox()
        Me.BtnTest = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.ListResources = New System.Windows.Forms.ListView()
        Me.ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NameCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Description = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Code = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DeviceCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DepartmentCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ResourceCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SubResourceID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ListFiles = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GridBreaks = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TxtPwdCMS = New System.Windows.Forms.TextBox()
        Me.TxtUserCMS = New System.Windows.Forms.TextBox()
        Me.TxtDSN = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ChkShowAvg = New System.Windows.Forms.CheckBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.PanelHSPR = New System.Windows.Forms.Panel()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.PanelHSPR.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtMARSBd)
        Me.GroupBox1.Controls.Add(Me.TxtMARSPwd)
        Me.GroupBox1.Controls.Add(Me.TxtMARSUser)
        Me.GroupBox1.Controls.Add(Me.TxtMarsServer)
        Me.GroupBox1.Controls.Add(Me.BtnTest)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(114, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(283, 175)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MARS Connection"
        '
        'TxtMARSBd
        '
        Me.TxtMARSBd.Location = New System.Drawing.Point(68, 99)
        Me.TxtMARSBd.Name = "TxtMARSBd"
        Me.TxtMARSBd.Size = New System.Drawing.Size(201, 20)
        Me.TxtMARSBd.TabIndex = 8
        '
        'TxtMARSPwd
        '
        Me.TxtMARSPwd.Location = New System.Drawing.Point(68, 73)
        Me.TxtMARSPwd.Name = "TxtMARSPwd"
        Me.TxtMARSPwd.Size = New System.Drawing.Size(201, 20)
        Me.TxtMARSPwd.TabIndex = 7
        Me.TxtMARSPwd.UseSystemPasswordChar = True
        '
        'TxtMARSUser
        '
        Me.TxtMARSUser.Location = New System.Drawing.Point(68, 47)
        Me.TxtMARSUser.Name = "TxtMARSUser"
        Me.TxtMARSUser.Size = New System.Drawing.Size(201, 20)
        Me.TxtMARSUser.TabIndex = 6
        '
        'TxtMarsServer
        '
        Me.TxtMarsServer.Location = New System.Drawing.Point(68, 21)
        Me.TxtMarsServer.Name = "TxtMarsServer"
        Me.TxtMarsServer.Size = New System.Drawing.Size(201, 20)
        Me.TxtMarsServer.TabIndex = 5
        '
        'BtnTest
        '
        Me.BtnTest.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnTest.Location = New System.Drawing.Point(68, 125)
        Me.BtnTest.Name = "BtnTest"
        Me.BtnTest.Size = New System.Drawing.Size(201, 40)
        Me.BtnTest.TabIndex = 4
        Me.BtnTest.Text = "Connection Test"
        Me.BtnTest.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(6, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Database:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(6, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Password:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(6, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Login:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(6, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server:"
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnCancel.Location = New System.Drawing.Point(395, 508)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(128, 52)
        Me.BtnCancel.TabIndex = 8
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnSave.Location = New System.Drawing.Point(261, 508)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(128, 52)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'ListResources
        '
        Me.ListResources.AllowDrop = True
        Me.ListResources.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListResources.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ID, Me.NameCol, Me.Description, Me.Code, Me.DeviceCode, Me.DepartmentCode, Me.ResourceCode, Me.SubResourceID})
        Me.ListResources.FullRowSelect = True
        Me.ListResources.Location = New System.Drawing.Point(6, 36)
        Me.ListResources.Name = "ListResources"
        Me.ListResources.Size = New System.Drawing.Size(757, 221)
        Me.ListResources.TabIndex = 9
        Me.ListResources.UseCompatibleStateImageBehavior = False
        Me.ListResources.View = System.Windows.Forms.View.Details
        '
        'ID
        '
        Me.ID.Text = "ID"
        Me.ID.Width = 46
        '
        'NameCol
        '
        Me.NameCol.Text = "Name"
        Me.NameCol.Width = 113
        '
        'Description
        '
        Me.Description.Text = "Description"
        Me.Description.Width = 146
        '
        'Code
        '
        Me.Code.Text = "Code"
        '
        'DeviceCode
        '
        Me.DeviceCode.Text = "DeviceCode"
        Me.DeviceCode.Width = 96
        '
        'DepartmentCode
        '
        Me.DepartmentCode.Text = "DepartmentCode"
        Me.DepartmentCode.Width = 101
        '
        'ResourceCode
        '
        Me.ResourceCode.Text = "ResourceCode"
        Me.ResourceCode.Width = 84
        '
        'SubResourceID
        '
        Me.SubResourceID.Text = "SubResourceID"
        Me.SubResourceID.Width = 92
        '
        'Button1
        '
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(6, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(161, 27)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Add Sub Resource (MARS) +"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(5, 219)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(774, 283)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button5)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.ListResources)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(766, 257)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Sub resources"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button5.Location = New System.Drawing.Point(173, 6)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(161, 27)
        Me.Button5.TabIndex = 11
        Me.Button5.Text = "Add Sub Resource (CMS) +"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.ListFiles)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(766, 257)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Slides"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2.Location = New System.Drawing.Point(6, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 27)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Add  Slide +"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ListFiles
        '
        Me.ListFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7})
        Me.ListFiles.Location = New System.Drawing.Point(6, 35)
        Me.ListFiles.Name = "ListFiles"
        Me.ListFiles.Size = New System.Drawing.Size(757, 221)
        Me.ListFiles.TabIndex = 11
        Me.ListFiles.UseCompatibleStateImageBehavior = False
        Me.ListFiles.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Filename"
        Me.ColumnHeader7.Width = 708
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button4)
        Me.TabPage3.Controls.Add(Me.GridBreaks)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(766, 257)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Breaks"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4.Location = New System.Drawing.Point(5, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(122, 27)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "Add Break"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GridBreaks
        '
        Me.GridBreaks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridBreaks.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.GridBreaks.Location = New System.Drawing.Point(5, 33)
        Me.GridBreaks.Name = "GridBreaks"
        Me.GridBreaks.Size = New System.Drawing.Size(757, 221)
        Me.GridBreaks.TabIndex = 11
        Me.GridBreaks.UseCompatibleStateImageBehavior = False
        Me.GridBreaks.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 52
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "ResourceCode"
        Me.ColumnHeader2.Width = 123
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Start"
        Me.ColumnHeader3.Width = 118
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "End"
        Me.ColumnHeader4.Width = 96
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Comments"
        Me.ColumnHeader5.Width = 204
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(439, 195)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 213
        Me.Label5.Text = "Seconds."
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(368, 193)
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(65, 20)
        Me.NumericUpDown1.TabIndex = 212
        Me.NumericUpDown1.Value = New Decimal(New Integer() {16, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(294, 195)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 214
        Me.Label6.Text = "Rotate every"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.TxtPwdCMS)
        Me.GroupBox2.Controls.Add(Me.TxtUserCMS)
        Me.GroupBox2.Controls.Add(Me.TxtDSN)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(403, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(267, 175)
        Me.GroupBox2.TabIndex = 225
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CMS Connection"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(52, 125)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(202, 40)
        Me.Button3.TabIndex = 225
        Me.Button3.Text = "Connection Test"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TxtPwdCMS
        '
        Me.TxtPwdCMS.Location = New System.Drawing.Point(52, 86)
        Me.TxtPwdCMS.Name = "TxtPwdCMS"
        Me.TxtPwdCMS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPwdCMS.Size = New System.Drawing.Size(202, 20)
        Me.TxtPwdCMS.TabIndex = 5
        '
        'TxtUserCMS
        '
        Me.TxtUserCMS.Location = New System.Drawing.Point(52, 60)
        Me.TxtUserCMS.Name = "TxtUserCMS"
        Me.TxtUserCMS.Size = New System.Drawing.Size(202, 20)
        Me.TxtUserCMS.TabIndex = 4
        '
        'TxtDSN
        '
        Me.TxtDSN.Location = New System.Drawing.Point(52, 34)
        Me.TxtDSN.Name = "TxtDSN"
        Me.TxtDSN.Size = New System.Drawing.Size(202, 20)
        Me.TxtDSN.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Pwd:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "User:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "D S N"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(68, 17)
        Me.CheckBox1.TabIndex = 226
        Me.CheckBox1.Text = "HSPR01"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ChkShowAvg
        '
        Me.ChkShowAvg.AutoSize = True
        Me.ChkShowAvg.Location = New System.Drawing.Point(121, 190)
        Me.ChkShowAvg.Name = "ChkShowAvg"
        Me.ChkShowAvg.Size = New System.Drawing.Size(96, 17)
        Me.ChkShowAvg.TabIndex = 227
        Me.ChkShowAvg.Text = "Show Average"
        Me.ChkShowAvg.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button6.Location = New System.Drawing.Point(15, 504)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(161, 27)
        Me.Button6.TabIndex = 228
        Me.Button6.Text = "Translations"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'PanelHSPR
        '
        Me.PanelHSPR.Controls.Add(Me.CheckBox3)
        Me.PanelHSPR.Controls.Add(Me.CheckBox2)
        Me.PanelHSPR.Controls.Add(Me.CheckBox1)
        Me.PanelHSPR.Location = New System.Drawing.Point(589, 190)
        Me.PanelHSPR.Name = "PanelHSPR"
        Me.PanelHSPR.Size = New System.Drawing.Size(183, 48)
        Me.PanelHSPR.TabIndex = 229
        Me.PanelHSPR.Visible = False
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(88, 3)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(68, 17)
        Me.CheckBox3.TabIndex = 228
        Me.CheckBox3.Text = "HSPR03"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(3, 26)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(68, 17)
        Me.CheckBox2.TabIndex = 227
        Me.CheckBox2.Text = "HSPR02"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.PanelHSPR)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.ChkShowAvg)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Config"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuration Version {0}.{1} Build {2} Rev. {3}"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.PanelHSPR.ResumeLayout(False)
        Me.PanelHSPR.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtMARSBd As System.Windows.Forms.TextBox
    Friend WithEvents TxtMARSPwd As System.Windows.Forms.TextBox
    Friend WithEvents TxtMARSUser As System.Windows.Forms.TextBox
    Friend WithEvents TxtMarsServer As System.Windows.Forms.TextBox
    Friend WithEvents BtnTest As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents ListResources As System.Windows.Forms.ListView
    Friend WithEvents ID As System.Windows.Forms.ColumnHeader
    Friend WithEvents NameCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents Description As System.Windows.Forms.ColumnHeader
    Friend WithEvents Code As System.Windows.Forms.ColumnHeader
    Friend WithEvents DeviceCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents DepartmentCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents ResourceCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ListFiles As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TxtPwdCMS As System.Windows.Forms.TextBox
    Friend WithEvents TxtUserCMS As System.Windows.Forms.TextBox
    Friend WithEvents TxtDSN As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GridBreaks As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents SubResourceID As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkShowAvg As System.Windows.Forms.CheckBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents PanelHSPR As System.Windows.Forms.Panel
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
End Class
