<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewDowntime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewDowntime))
        Me.CboHora = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CboStation = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CboEquipment = New System.Windows.Forms.ComboBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cbodepartment = New System.Windows.Forms.ComboBox()
        Me.txtcomments = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbocode = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CboConcepto = New System.Windows.Forms.ComboBox()
        Me.RadButton2 = New Telerik.WinControls.UI.RadButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CboParte = New System.Windows.Forms.ComboBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.RadButton3 = New Telerik.WinControls.UI.RadButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LblReferencia = New System.Windows.Forms.Label()
        Me.LblStartEndtimes = New System.Windows.Forms.Label()
        Me.ChkPlaneado = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblReferencia2 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtcomments2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CboPlanConcepto = New System.Windows.Forms.ComboBox()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CboHora
        '
        Me.CboHora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboHora.FormattingEnabled = True
        Me.CboHora.Location = New System.Drawing.Point(133, 17)
        Me.CboHora.Name = "CboHora"
        Me.CboHora.Size = New System.Drawing.Size(277, 28)
        Me.CboHora.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Hora"
        '
        'CboStation
        '
        Me.CboStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboStation.FormattingEnabled = True
        Me.CboStation.Location = New System.Drawing.Point(133, 85)
        Me.CboStation.Name = "CboStation"
        Me.CboStation.Size = New System.Drawing.Size(277, 28)
        Me.CboStation.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Operacion"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(416, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Equipo"
        '
        'CboEquipment
        '
        Me.CboEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEquipment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEquipment.FormattingEnabled = True
        Me.CboEquipment.Location = New System.Drawing.Point(507, 85)
        Me.CboEquipment.Name = "CboEquipment"
        Me.CboEquipment.Size = New System.Drawing.Size(277, 28)
        Me.CboEquipment.TabIndex = 3
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.DecimalPlaces = 2
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!)
        Me.NumericUpDown1.Location = New System.Drawing.Point(133, 187)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(120, 41)
        Me.NumericUpDown1.TabIndex = 7
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Tiempo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(259, 208)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "(Minutos)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Departamento"
        '
        'Cbodepartment
        '
        Me.Cbodepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbodepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbodepartment.FormattingEnabled = True
        Me.Cbodepartment.Location = New System.Drawing.Point(133, 119)
        Me.Cbodepartment.Name = "Cbodepartment"
        Me.Cbodepartment.Size = New System.Drawing.Size(276, 28)
        Me.Cbodepartment.TabIndex = 4
        '
        'txtcomments
        '
        Me.txtcomments.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcomments.Location = New System.Drawing.Point(133, 234)
        Me.txtcomments.Multiline = True
        Me.txtcomments.Name = "txtcomments"
        Me.txtcomments.Size = New System.Drawing.Size(650, 66)
        Me.txtcomments.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 237)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Comentarios:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 156)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 20)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Código"
        '
        'cbocode
        '
        Me.cbocode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbocode.FormattingEnabled = True
        Me.cbocode.Location = New System.Drawing.Point(133, 153)
        Me.cbocode.Name = "cbocode"
        Me.cbocode.Size = New System.Drawing.Size(651, 28)
        Me.cbocode.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(416, 122)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 20)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Concepto:"
        '
        'CboConcepto
        '
        Me.CboConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboConcepto.FormattingEnabled = True
        Me.CboConcepto.Location = New System.Drawing.Point(507, 122)
        Me.CboConcepto.Name = "CboConcepto"
        Me.CboConcepto.Size = New System.Drawing.Size(276, 28)
        Me.CboConcepto.TabIndex = 5
        '
        'RadButton2
        '
        Me.RadButton2.ImageIndex = 1
        Me.RadButton2.ImageList = Me.ImageList1
        Me.RadButton2.Location = New System.Drawing.Point(422, 491)
        Me.RadButton2.Name = "RadButton2"
        Me.RadButton2.Size = New System.Drawing.Size(128, 59)
        Me.RadButton2.TabIndex = 10
        Me.RadButton2.Text = "Cancelar"
        Me.RadButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RadButton2.TextWrap = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Save.png")
        Me.ImageList1.Images.SetKeyName(1, "Delete.png")
        Me.ImageList1.Images.SetKeyName(2, "search_magnifying_glass_find-128.png")
        '
        'RadButton1
        '
        Me.RadButton1.ImageIndex = 0
        Me.RadButton1.ImageList = Me.ImageList1
        Me.RadButton1.Location = New System.Drawing.Point(285, 491)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(128, 59)
        Me.RadButton1.TabIndex = 9
        Me.RadButton1.Text = "Guardar"
        Me.RadButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RadButton1.TextWrap = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 20)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Parte"
        '
        'CboParte
        '
        Me.CboParte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboParte.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboParte.FormattingEnabled = True
        Me.CboParte.Location = New System.Drawing.Point(133, 51)
        Me.CboParte.Name = "CboParte"
        Me.CboParte.Size = New System.Drawing.Size(365, 28)
        Me.CboParte.TabIndex = 1
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'RadButton3
        '
        Me.RadButton3.Image = Global.ReporteProduccion.My.Resources.Resources.if_find_712
        Me.RadButton3.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadButton3.Location = New System.Drawing.Point(790, 153)
        Me.RadButton3.Name = "RadButton3"
        Me.RadButton3.Size = New System.Drawing.Size(32, 28)
        Me.RadButton3.TabIndex = 23
        Me.RadButton3.TextWrap = True
        Me.ToolTip1.SetToolTip(Me.RadButton3, "Buscar (F1)")
        '
        'LblReferencia
        '
        Me.LblReferencia.AutoSize = True
        Me.LblReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferencia.Location = New System.Drawing.Point(374, 184)
        Me.LblReferencia.Name = "LblReferencia"
        Me.LblReferencia.Size = New System.Drawing.Size(87, 20)
        Me.LblReferencia.TabIndex = 24
        Me.LblReferencia.Text = "Referencia"
        Me.LblReferencia.Visible = False
        '
        'LblStartEndtimes
        '
        Me.LblStartEndtimes.AutoSize = True
        Me.LblStartEndtimes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStartEndtimes.Location = New System.Drawing.Point(374, 208)
        Me.LblStartEndtimes.Name = "LblStartEndtimes"
        Me.LblStartEndtimes.Size = New System.Drawing.Size(124, 20)
        Me.LblStartEndtimes.TabIndex = 25
        Me.LblStartEndtimes.Text = "Start - End Time"
        Me.LblStartEndtimes.Visible = False
        '
        'ChkPlaneado
        '
        Me.ChkPlaneado.AutoSize = True
        Me.ChkPlaneado.Enabled = False
        Me.ChkPlaneado.Location = New System.Drawing.Point(142, 306)
        Me.ChkPlaneado.Name = "ChkPlaneado"
        Me.ChkPlaneado.Size = New System.Drawing.Size(71, 17)
        Me.ChkPlaneado.TabIndex = 26
        Me.ChkPlaneado.Text = "Planeado"
        Me.ChkPlaneado.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblReferencia2)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtcomments2)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.CboPlanConcepto)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(133, 306)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(650, 179)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'LblReferencia2
        '
        Me.LblReferencia2.AutoSize = True
        Me.LblReferencia2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferencia2.Location = New System.Drawing.Point(413, 70)
        Me.LblReferencia2.Name = "LblReferencia2"
        Me.LblReferencia2.Size = New System.Drawing.Size(87, 20)
        Me.LblReferencia2.TabIndex = 32
        Me.LblReferencia2.Text = "Referencia"
        Me.LblReferencia2.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(46, 117)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(103, 20)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "Comentarios:"
        '
        'txtcomments2
        '
        Me.txtcomments2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcomments2.Location = New System.Drawing.Point(190, 104)
        Me.txtcomments2.Multiline = True
        Me.txtcomments2.Name = "txtcomments2"
        Me.txtcomments2.Size = New System.Drawing.Size(398, 66)
        Me.txtcomments2.TabIndex = 30
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(332, 70)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 20)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "(Minutos)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(46, 70)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 20)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Tiempo"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.DecimalPlaces = 2
        Me.NumericUpDown2.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!)
        Me.NumericUpDown2.Location = New System.Drawing.Point(190, 57)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(120, 41)
        Me.NumericUpDown2.TabIndex = 26
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(46, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 20)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Concepto"
        '
        'CboPlanConcepto
        '
        Me.CboPlanConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPlanConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboPlanConcepto.FormattingEnabled = True
        Me.CboPlanConcepto.Location = New System.Drawing.Point(190, 23)
        Me.CboPlanConcepto.Name = "CboPlanConcepto"
        Me.CboPlanConcepto.Size = New System.Drawing.Size(398, 28)
        Me.CboPlanConcepto.TabIndex = 25
        '
        'NewDowntime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(834, 562)
        Me.Controls.Add(Me.ChkPlaneado)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblStartEndtimes)
        Me.Controls.Add(Me.LblReferencia)
        Me.Controls.Add(Me.RadButton3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.CboParte)
        Me.Controls.Add(Me.RadButton2)
        Me.Controls.Add(Me.RadButton1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.CboConcepto)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbocode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtcomments)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Cbodepartment)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CboEquipment)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CboStation)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CboHora)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "NewDowntime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Tiempo Muerto"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CboHora As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboStation As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CboEquipment As System.Windows.Forms.ComboBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cbodepartment As System.Windows.Forms.ComboBox
    Friend WithEvents txtcomments As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbocode As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CboConcepto As System.Windows.Forms.ComboBox
    Friend WithEvents RadButton2 As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CboParte As System.Windows.Forms.ComboBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents RadButton3 As Telerik.WinControls.UI.RadButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents LblStartEndtimes As System.Windows.Forms.Label
    Friend WithEvents LblReferencia As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkPlaneado As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CboPlanConcepto As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtcomments2 As System.Windows.Forms.TextBox
    Friend WithEvents LblReferencia2 As System.Windows.Forms.Label
End Class
