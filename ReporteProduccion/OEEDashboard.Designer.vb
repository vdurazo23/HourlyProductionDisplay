<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OEEDashboard
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.PanelGauge = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblResource = New System.Windows.Forms.Label()
        Me.LblProdTot = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblOEE = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblQuality = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblPerformance = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblAvailability = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblDowntime = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblPlannedDowntime = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Lblturno2 = New System.Windows.Forms.Label()
        Me.LblTurno = New System.Windows.Forms.Label()
        Me.lblfecha = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'PanelGauge
        '
        Me.PanelGauge.Location = New System.Drawing.Point(281, 54)
        Me.PanelGauge.Name = "PanelGauge"
        Me.PanelGauge.Size = New System.Drawing.Size(240, 240)
        Me.PanelGauge.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 24)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Resource:"
        '
        'LblResource
        '
        Me.LblResource.AutoSize = True
        Me.LblResource.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblResource.Location = New System.Drawing.Point(126, 12)
        Me.LblResource.Name = "LblResource"
        Me.LblResource.Size = New System.Drawing.Size(128, 24)
        Me.LblResource.TabIndex = 44
        Me.LblResource.Text = "LblResource"
        '
        'LblProdTot
        '
        Me.LblProdTot.AutoSize = True
        Me.LblProdTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProdTot.Location = New System.Drawing.Point(175, 87)
        Me.LblProdTot.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblProdTot.Name = "LblProdTot"
        Me.LblProdTot.Size = New System.Drawing.Size(39, 20)
        Me.LblProdTot.TabIndex = 54
        Me.LblProdTot.Text = "000"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 87)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 20)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Producción Total:"
        '
        'LblOEE
        '
        Me.LblOEE.AutoSize = True
        Me.LblOEE.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOEE.Location = New System.Drawing.Point(163, 249)
        Me.LblOEE.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblOEE.Name = "LblOEE"
        Me.LblOEE.Size = New System.Drawing.Size(94, 37)
        Me.LblOEE.TabIndex = 52
        Me.LblOEE.Text = "0.0%"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 249)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 37)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "OEE:"
        '
        'LblQuality
        '
        Me.LblQuality.AutoSize = True
        Me.LblQuality.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblQuality.Location = New System.Drawing.Point(175, 225)
        Me.LblQuality.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblQuality.Name = "LblQuality"
        Me.LblQuality.Size = New System.Drawing.Size(49, 20)
        Me.LblQuality.TabIndex = 50
        Me.LblQuality.Text = "0.0%"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 225)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 20)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "CALIDAD:"
        '
        'LblPerformance
        '
        Me.LblPerformance.AutoSize = True
        Me.LblPerformance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPerformance.Location = New System.Drawing.Point(175, 205)
        Me.LblPerformance.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPerformance.Name = "LblPerformance"
        Me.LblPerformance.Size = New System.Drawing.Size(49, 20)
        Me.LblPerformance.TabIndex = 48
        Me.LblPerformance.Text = "0.0%"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 205)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 20)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "EFICIENCIA:"
        '
        'LblAvailability
        '
        Me.LblAvailability.AutoSize = True
        Me.LblAvailability.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAvailability.Location = New System.Drawing.Point(175, 185)
        Me.LblAvailability.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAvailability.Name = "LblAvailability"
        Me.LblAvailability.Size = New System.Drawing.Size(49, 20)
        Me.LblAvailability.TabIndex = 46
        Me.LblAvailability.Text = "0.0%"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 185)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(159, 20)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "DISPONIBILIDAD:"
        '
        'LblDowntime
        '
        Me.LblDowntime.AutoSize = True
        Me.LblDowntime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDowntime.Location = New System.Drawing.Point(175, 107)
        Me.LblDowntime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDowntime.Name = "LblDowntime"
        Me.LblDowntime.Size = New System.Drawing.Size(39, 20)
        Me.LblDowntime.TabIndex = 56
        Me.LblDowntime.Text = "000"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 107)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 20)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Tiempo Muerto:"
        '
        'LblPlannedDowntime
        '
        Me.LblPlannedDowntime.AutoSize = True
        Me.LblPlannedDowntime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPlannedDowntime.Location = New System.Drawing.Point(175, 146)
        Me.LblPlannedDowntime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPlannedDowntime.Name = "LblPlannedDowntime"
        Me.LblPlannedDowntime.Size = New System.Drawing.Size(39, 20)
        Me.LblPlannedDowntime.TabIndex = 58
        Me.LblPlannedDowntime.Text = "000"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 146)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(168, 20)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "Unidades rechazadas:"
        '
        'Lblturno2
        '
        Me.Lblturno2.AutoSize = True
        Me.Lblturno2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblturno2.Location = New System.Drawing.Point(138, 56)
        Me.Lblturno2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lblturno2.Name = "Lblturno2"
        Me.Lblturno2.Size = New System.Drawing.Size(55, 20)
        Me.Lblturno2.TabIndex = 63
        Me.Lblturno2.Text = "Turno"
        '
        'LblTurno
        '
        Me.LblTurno.AutoSize = True
        Me.LblTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTurno.Location = New System.Drawing.Point(75, 56)
        Me.LblTurno.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTurno.Name = "LblTurno"
        Me.LblTurno.Size = New System.Drawing.Size(55, 20)
        Me.LblTurno.TabIndex = 62
        Me.LblTurno.Text = "Turno"
        '
        'lblfecha
        '
        Me.lblfecha.AutoSize = True
        Me.lblfecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfecha.Location = New System.Drawing.Point(75, 36)
        Me.lblfecha.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblfecha.Name = "lblfecha"
        Me.lblfecha.Size = New System.Drawing.Size(64, 20)
        Me.lblfecha.TabIndex = 61
        Me.lblfecha.Text = "Fecha:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 56)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 20)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Turno"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 36)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 20)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "Fecha:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(175, 127)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 20)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "000"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 127)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(119, 20)
        Me.Label12.TabIndex = 64
        Me.Label12.Text = "Tiempo Muerto:"
        '
        'OEEDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Lblturno2)
        Me.Controls.Add(Me.LblTurno)
        Me.Controls.Add(Me.lblfecha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.LblPlannedDowntime)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LblDowntime)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblProdTot)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblOEE)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblQuality)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LblPerformance)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblAvailability)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblResource)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PanelGauge)
        Me.Name = "OEEDashboard"
        Me.Size = New System.Drawing.Size(530, 300)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelGauge As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblResource As System.Windows.Forms.Label
    Friend WithEvents LblProdTot As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblOEE As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblQuality As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblPerformance As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblAvailability As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblDowntime As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblPlannedDowntime As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Lblturno2 As System.Windows.Forms.Label
    Friend WithEvents LblTurno As System.Windows.Forms.Label
    Friend WithEvents lblfecha As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label

End Class
