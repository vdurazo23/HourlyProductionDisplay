<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.RadPageView1 = New Telerik.WinControls.UI.RadPageView()
        Me.RadPageKPIS = New Telerik.WinControls.UI.RadPageViewPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupAddData = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CboPeriodText = New System.Windows.Forms.ComboBox()
        Me.CboPeriod = New System.Windows.Forms.ComboBox()
        Me.TxtTarget = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtValue = New System.Windows.Forms.NumericUpDown()
        Me.GridDatos = New System.Windows.Forms.DataGridView()
        Me.GridKPIS = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CboPlant = New System.Windows.Forms.ComboBox()
        Me.Grafica1 = New KPIs.Grafica()
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageView1.SuspendLayout()
        Me.RadPageKPIS.SuspendLayout()
        Me.GroupAddData.SuspendLayout()
        CType(Me.TxtTarget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridKPIS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadPageView1
        '
        Me.RadPageView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.RadPageView1.Controls.Add(Me.RadPageKPIS)
        Me.RadPageView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadPageView1.Location = New System.Drawing.Point(0, 0)
        Me.RadPageView1.Name = "RadPageView1"
        Me.RadPageView1.PageBackColor = System.Drawing.Color.White
        Me.RadPageView1.SelectedPage = Me.RadPageKPIS
        Me.RadPageView1.Size = New System.Drawing.Size(1008, 730)
        Me.RadPageView1.TabIndex = 8
        Me.RadPageView1.ViewMode = Telerik.WinControls.UI.PageViewMode.Backstage
        CType(Me.RadPageView1.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.StripViewItemContainer).MinSize = New System.Drawing.Size(100, 0)
        '
        'RadPageKPIS
        '
        Me.RadPageKPIS.AutoScroll = True
        Me.RadPageKPIS.BackColor = System.Drawing.Color.White
        Me.RadPageKPIS.Controls.Add(Me.Label6)
        Me.RadPageKPIS.Controls.Add(Me.Label2)
        Me.RadPageKPIS.Controls.Add(Me.Button3)
        Me.RadPageKPIS.Controls.Add(Me.Button2)
        Me.RadPageKPIS.Controls.Add(Me.GroupAddData)
        Me.RadPageKPIS.Controls.Add(Me.GridDatos)
        Me.RadPageKPIS.Controls.Add(Me.GridKPIS)
        Me.RadPageKPIS.Controls.Add(Me.Label1)
        Me.RadPageKPIS.Controls.Add(Me.CboPlant)
        Me.RadPageKPIS.Controls.Add(Me.Grafica1)
        Me.RadPageKPIS.ItemSize = New System.Drawing.SizeF(37.0!, 45.0!)
        Me.RadPageKPIS.Location = New System.Drawing.Point(105, 4)
        Me.RadPageKPIS.Name = "RadPageKPIS"
        Me.RadPageKPIS.Size = New System.Drawing.Size(899, 722)
        Me.RadPageKPIS.Text = "KPIs"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 210)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Values"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "KPIS"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(738, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(81, 51)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "Configure"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(522, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(201, 51)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Start Presentation"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupAddData
        '
        Me.GroupAddData.Controls.Add(Me.Button1)
        Me.GroupAddData.Controls.Add(Me.Label3)
        Me.GroupAddData.Controls.Add(Me.CboPeriodText)
        Me.GroupAddData.Controls.Add(Me.CboPeriod)
        Me.GroupAddData.Controls.Add(Me.TxtTarget)
        Me.GroupAddData.Controls.Add(Me.Label4)
        Me.GroupAddData.Controls.Add(Me.Label5)
        Me.GroupAddData.Controls.Add(Me.TxtValue)
        Me.GroupAddData.Location = New System.Drawing.Point(3, 317)
        Me.GroupAddData.Name = "GroupAddData"
        Me.GroupAddData.Size = New System.Drawing.Size(813, 79)
        Me.GroupAddData.TabIndex = 11
        Me.GroupAddData.TabStop = False
        Me.GroupAddData.Text = "Add Data"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(689, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 49)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Add"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Period"
        '
        'CboPeriodText
        '
        Me.CboPeriodText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPeriodText.FormattingEnabled = True
        Me.CboPeriodText.Location = New System.Drawing.Point(225, 24)
        Me.CboPeriodText.Name = "CboPeriodText"
        Me.CboPeriodText.Size = New System.Drawing.Size(230, 21)
        Me.CboPeriodText.TabIndex = 10
        '
        'CboPeriod
        '
        Me.CboPeriod.FormattingEnabled = True
        Me.CboPeriod.Items.AddRange(New Object() {"Yearly", "Monthly"})
        Me.CboPeriod.Location = New System.Drawing.Point(64, 24)
        Me.CboPeriod.Name = "CboPeriod"
        Me.CboPeriod.Size = New System.Drawing.Size(121, 21)
        Me.CboPeriod.TabIndex = 4
        '
        'TxtTarget
        '
        Me.TxtTarget.DecimalPlaces = 2
        Me.TxtTarget.Location = New System.Drawing.Point(563, 47)
        Me.TxtTarget.Name = "TxtTarget"
        Me.TxtTarget.Size = New System.Drawing.Size(120, 20)
        Me.TxtTarget.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(494, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Value"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(494, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Target"
        '
        'TxtValue
        '
        Me.TxtValue.DecimalPlaces = 2
        Me.TxtValue.Location = New System.Drawing.Point(563, 21)
        Me.TxtValue.Name = "TxtValue"
        Me.TxtValue.Size = New System.Drawing.Size(120, 20)
        Me.TxtValue.TabIndex = 7
        '
        'GridDatos
        '
        Me.GridDatos.AllowUserToAddRows = False
        Me.GridDatos.AllowUserToDeleteRows = False
        Me.GridDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GridDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridDatos.Location = New System.Drawing.Point(3, 226)
        Me.GridDatos.Name = "GridDatos"
        Me.GridDatos.Size = New System.Drawing.Size(813, 85)
        Me.GridDatos.TabIndex = 3
        '
        'GridKPIS
        '
        Me.GridKPIS.AllowUserToAddRows = False
        Me.GridKPIS.AllowUserToDeleteRows = False
        Me.GridKPIS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GridKPIS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridKPIS.Location = New System.Drawing.Point(6, 60)
        Me.GridKPIS.Name = "GridKPIS"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridKPIS.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GridKPIS.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridKPIS.Size = New System.Drawing.Size(813, 147)
        Me.GridKPIS.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(3, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Plant"
        '
        'CboPlant
        '
        Me.CboPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPlant.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.CboPlant.FormattingEnabled = True
        Me.CboPlant.Location = New System.Drawing.Point(54, 8)
        Me.CboPlant.Name = "CboPlant"
        Me.CboPlant.Size = New System.Drawing.Size(275, 29)
        Me.CboPlant.TabIndex = 0
        '
        'Grafica1
        '
        Me.Grafica1.Location = New System.Drawing.Point(3, 402)
        Me.Grafica1.Name = "Grafica1"
        Me.Grafica1.Size = New System.Drawing.Size(517, 316)
        Me.Grafica1.TabIndex = 14
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.RadPageView1)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KPIs"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageView1.ResumeLayout(False)
        Me.RadPageKPIS.ResumeLayout(False)
        Me.RadPageKPIS.PerformLayout()
        Me.GroupAddData.ResumeLayout(False)
        Me.GroupAddData.PerformLayout()
        CType(Me.TxtTarget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridKPIS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RadPageView1 As Telerik.WinControls.UI.RadPageView
    Friend WithEvents RadPageKPIS As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboPlant As System.Windows.Forms.ComboBox
    Friend WithEvents GridKPIS As System.Windows.Forms.DataGridView
    Friend WithEvents GridDatos As System.Windows.Forms.DataGridView
    Friend WithEvents TxtTarget As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CboPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents CboPeriodText As System.Windows.Forms.ComboBox
    Friend WithEvents GroupAddData As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Grafica1 As KPIs.Grafica
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
