<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewRework
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewRework))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtcomments = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CboConcepto = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cbocodigo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CboHora = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CboFeatures = New System.Windows.Forms.ComboBox()
        Me.RadButton2 = New Telerik.WinControls.UI.RadButton()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CboParte = New System.Windows.Forms.ComboBox()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(239, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 20)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "(Piezas)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 226)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 20)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Comentarios:"
        '
        'txtcomments
        '
        Me.txtcomments.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcomments.Location = New System.Drawing.Point(131, 223)
        Me.txtcomments.Multiline = True
        Me.txtcomments.Name = "txtcomments"
        Me.txtcomments.Size = New System.Drawing.Size(398, 66)
        Me.txtcomments.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Cantidad"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!)
        Me.NumericUpDown1.Location = New System.Drawing.Point(131, 176)
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(85, 41)
        Me.NumericUpDown1.TabIndex = 5
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 20)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Concepto"
        '
        'CboConcepto
        '
        Me.CboConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboConcepto.FormattingEnabled = True
        Me.CboConcepto.Location = New System.Drawing.Point(131, 74)
        Me.CboConcepto.Name = "CboConcepto"
        Me.CboConcepto.Size = New System.Drawing.Size(398, 28)
        Me.CboConcepto.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 20)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Código"
        '
        'Cbocodigo
        '
        Me.Cbocodigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbocodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbocodigo.FormattingEnabled = True
        Me.Cbocodigo.Location = New System.Drawing.Point(131, 108)
        Me.Cbocodigo.Name = "Cbocodigo"
        Me.Cbocodigo.Size = New System.Drawing.Size(398, 28)
        Me.Cbocodigo.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 20)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Hora"
        '
        'CboHora
        '
        Me.CboHora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboHora.FormattingEnabled = True
        Me.CboHora.Location = New System.Drawing.Point(131, 6)
        Me.CboHora.Name = "CboHora"
        Me.CboHora.Size = New System.Drawing.Size(150, 28)
        Me.CboHora.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 20)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "Cordon"
        '
        'CboFeatures
        '
        Me.CboFeatures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFeatures.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboFeatures.FormattingEnabled = True
        Me.CboFeatures.Location = New System.Drawing.Point(131, 142)
        Me.CboFeatures.Name = "CboFeatures"
        Me.CboFeatures.Size = New System.Drawing.Size(398, 28)
        Me.CboFeatures.TabIndex = 4
        '
        'RadButton2
        '
        Me.RadButton2.ImageIndex = 1
        Me.RadButton2.ImageList = Me.ImageList1
        Me.RadButton2.Location = New System.Drawing.Point(279, 295)
        Me.RadButton2.Name = "RadButton2"
        Me.RadButton2.Size = New System.Drawing.Size(128, 59)
        Me.RadButton2.TabIndex = 8
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
        '
        'RadButton1
        '
        Me.RadButton1.ImageIndex = 0
        Me.RadButton1.ImageList = Me.ImageList1
        Me.RadButton1.Location = New System.Drawing.Point(142, 295)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(128, 59)
        Me.RadButton1.TabIndex = 7
        Me.RadButton1.Text = "Guardar"
        Me.RadButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RadButton1.TextWrap = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 20)
        Me.Label10.TabIndex = 43
        Me.Label10.Text = "Parte"
        '
        'CboParte
        '
        Me.CboParte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboParte.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboParte.FormattingEnabled = True
        Me.CboParte.Location = New System.Drawing.Point(131, 40)
        Me.CboParte.Name = "CboParte"
        Me.CboParte.Size = New System.Drawing.Size(365, 28)
        Me.CboParte.TabIndex = 1
        '
        'NewRework
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(548, 365)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.CboParte)
        Me.Controls.Add(Me.RadButton2)
        Me.Controls.Add(Me.RadButton1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CboFeatures)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CboHora)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cbocodigo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtcomments)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CboConcepto)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NewRework"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Rechazo"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtcomments As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CboConcepto As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cbocodigo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CboHora As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CboFeatures As System.Windows.Forms.ComboBox
    Friend WithEvents RadButton2 As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CboParte As System.Windows.Forms.ComboBox
End Class
