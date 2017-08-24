<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDisplay
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series7 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series8 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDisplay))
        Me.LblShifTarget = New System.Windows.Forms.Label()
        Me.LblCurrentActual = New System.Windows.Forms.Label()
        Me.LblCurrentTarget = New System.Windows.Forms.Label()
        Me.LblAverage = New System.Windows.Forms.Label()
        Me.LblFechaHora = New System.Windows.Forms.Label()
        Me.LblChangeOverBlue = New System.Windows.Forms.Label()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TimerDatos = New System.Windows.Forms.Timer(Me.components)
        Me.TimerChange = New System.Windows.Forms.Timer(Me.components)
        Me.TimerSlides = New System.Windows.Forms.Timer(Me.components)
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TimerFontSize = New System.Windows.Forms.Timer(Me.components)
        Me.LblFontIncrement = New System.Windows.Forms.Label()
        Me.LblPart = New System.Windows.Forms.Label()
        Me.RadialGaugeArc4 = New Telerik.WinControls.UI.Gauges.RadialGaugeArc()
        Me.RadialGaugeArc5 = New Telerik.WinControls.UI.Gauges.RadialGaugeArc()
        Me.RadialGaugeArc6 = New Telerik.WinControls.UI.Gauges.RadialGaugeArc()
        Me.RadialGaugeTicks2 = New Telerik.WinControls.UI.Gauges.RadialGaugeTicks()
        Me.RadialGaugeLabels2 = New Telerik.WinControls.UI.Gauges.RadialGaugeLabels()
        Me.RadialGaugeNeedle2 = New Telerik.WinControls.UI.Gauges.RadialGaugeNeedle()
        Me.RadialGaugeTicks3 = New Telerik.WinControls.UI.Gauges.RadialGaugeTicks()
        Me.RadialGaugeSingleLabel1 = New Telerik.WinControls.UI.Gauges.RadialGaugeSingleLabel()
        Me.LblEfficiency = New System.Windows.Forms.Label()
        Me.RadRadialGauge2 = New Telerik.WinControls.UI.Gauges.RadRadialGauge()
        Me.LblResource = New System.Windows.Forms.Label()
        Me.LblCurrentActualValue = New System.Windows.Forms.Label()
        Me.Picpause = New System.Windows.Forms.PictureBox()
        Me.PicSlide2 = New System.Windows.Forms.PictureBox()
        Me.PicSlide1 = New System.Windows.Forms.PictureBox()
        Me.LblShiftDelta = New System.Windows.Forms.Label()
        Me.LblShiftDeltaValue = New System.Windows.Forms.Label()
        Me.PanelPrensas = New System.Windows.Forms.Panel()
        Me.LblSPMActual = New System.Windows.Forms.Label()
        Me.Lblsetupactual = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblSetupTarget = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblSPMTarget = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LBLERROR = New System.Windows.Forms.Label()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadRadialGauge2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadRadialGauge2.SuspendLayout()
        CType(Me.Picpause, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicSlide2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicSlide1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelPrensas.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblShifTarget
        '
        Me.LblShifTarget.AutoSize = True
        Me.LblShifTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShifTarget.Location = New System.Drawing.Point(0, 79)
        Me.LblShifTarget.Name = "LblShifTarget"
        Me.LblShifTarget.Size = New System.Drawing.Size(366, 44)
        Me.LblShifTarget.TabIndex = 228
        Me.LblShifTarget.Text = "Shift current target:"
        Me.LblShifTarget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCurrentActual
        '
        Me.LblCurrentActual.AutoSize = True
        Me.LblCurrentActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurrentActual.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblCurrentActual.Location = New System.Drawing.Point(0, 130)
        Me.LblCurrentActual.Name = "LblCurrentActual"
        Me.LblCurrentActual.Size = New System.Drawing.Size(370, 44)
        Me.LblCurrentActual.TabIndex = 229
        Me.LblCurrentActual.Text = "Shift current actual:"
        Me.LblCurrentActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCurrentTarget
        '
        Me.LblCurrentTarget.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblCurrentTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurrentTarget.Location = New System.Drawing.Point(0, 178)
        Me.LblCurrentTarget.Name = "LblCurrentTarget"
        Me.LblCurrentTarget.Size = New System.Drawing.Size(1503, 51)
        Me.LblCurrentTarget.TabIndex = 234
        Me.LblCurrentTarget.Text = "Current Hourly Target: "
        Me.LblCurrentTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblAverage
        '
        Me.LblAverage.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblAverage.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAverage.Location = New System.Drawing.Point(0, 127)
        Me.LblAverage.Name = "LblAverage"
        Me.LblAverage.Size = New System.Drawing.Size(1503, 51)
        Me.LblAverage.TabIndex = 233
        Me.LblAverage.Text = "Average:"
        Me.LblAverage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblAverage.Visible = False
        '
        'LblFechaHora
        '
        Me.LblFechaHora.AutoSize = True
        Me.LblFechaHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFechaHora.Location = New System.Drawing.Point(0, 9)
        Me.LblFechaHora.Name = "LblFechaHora"
        Me.LblFechaHora.Size = New System.Drawing.Size(175, 36)
        Me.LblFechaHora.TabIndex = 230
        Me.LblFechaHora.Text = "Date / Time"
        Me.LblFechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblChangeOverBlue
        '
        Me.LblChangeOverBlue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblChangeOverBlue.AutoSize = True
        Me.LblChangeOverBlue.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChangeOverBlue.ForeColor = System.Drawing.Color.Blue
        Me.LblChangeOverBlue.Location = New System.Drawing.Point(1216, 690)
        Me.LblChangeOverBlue.Name = "LblChangeOverBlue"
        Me.LblChangeOverBlue.Size = New System.Drawing.Size(283, 29)
        Me.LblChangeOverBlue.TabIndex = 227
        Me.LblChangeOverBlue.Text = "Blue Text = Change Over"
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.BackColor = System.Drawing.Color.Gainsboro
        ChartArea1.Area3DStyle.Enable3D = True
        ChartArea1.Area3DStyle.Inclination = 15
        ChartArea1.Area3DStyle.IsClustered = True
        ChartArea1.Area3DStyle.PointDepth = 8
        ChartArea1.Area3DStyle.WallWidth = 3
        ChartArea1.AxisX.Interval = 1.0R
        ChartArea1.AxisX.IntervalOffset = 1.0R
        ChartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.LabelStyle.Angle = -48
        ChartArea1.AxisX.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisX.MajorGrid.Enabled = False
        ChartArea1.AxisX.MajorGrid.Interval = 0.0R
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray
        ChartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot
        ChartArea1.AxisX.Title = "Part"
        ChartArea1.AxisX.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[True]
        ChartArea1.AxisX2.Interval = 1.0R
        ChartArea1.AxisX2.IntervalOffset = 1.0R
        ChartArea1.AxisX2.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days
        ChartArea1.AxisX2.IsLabelAutoFit = False
        ChartArea1.AxisX2.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisX2.MajorGrid.Enabled = False
        ChartArea1.AxisX2.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisY.IsLabelAutoFit = False
        ChartArea1.AxisY.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisY.MajorGrid.Enabled = False
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray
        ChartArea1.AxisY.Title = "PCS / HR"
        ChartArea1.AxisY.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisY2.IsLabelAutoFit = False
        ChartArea1.AxisY2.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        ChartArea1.BackColor = System.Drawing.Color.DarkGray
        ChartArea1.BackSecondaryColor = System.Drawing.Color.Black
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Location = New System.Drawing.Point(0, 205)
        Me.Chart1.Name = "Chart1"
        Series1.BorderWidth = 2
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Color = System.Drawing.Color.Blue
        Series1.CustomProperties = "LabelStyle=Top"
        Series1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Italic)
        Series1.IsValueShownAsLabel = True
        Series1.LegendText = "Target"
        Series1.Name = "Series5"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn
        Series2.Color = System.Drawing.Color.Lime
        Series2.CustomProperties = "LabelStyle=Center"
        Series2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold)
        Series2.IsValueShownAsLabel = True
        Series2.IsVisibleInLegend = False
        Series2.LegendText = "Production"
        Series2.Name = "C Shift"
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn
        Series3.Color = System.Drawing.Color.GreenYellow
        Series3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Italic)
        Series3.IsValueShownAsLabel = True
        Series3.IsVisibleInLegend = False
        Series3.Name = "Series3"
        Series4.ChartArea = "ChartArea1"
        Series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine
        Series4.Color = System.Drawing.Color.Blue
        Series4.Name = "Series4"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Series.Add(Series3)
        Me.Chart1.Series.Add(Series4)
        Me.Chart1.Size = New System.Drawing.Size(1500, 554)
        Me.Chart1.TabIndex = 226
        Me.Chart1.Text = "Chart1"
        '
        'TimerDatos
        '
        Me.TimerDatos.Enabled = True
        Me.TimerDatos.Interval = 3000
        '
        'TimerChange
        '
        Me.TimerChange.Enabled = True
        Me.TimerChange.Interval = 16000
        '
        'TimerSlides
        '
        Me.TimerSlides.Interval = 16000
        '
        'Chart2
        '
        Me.Chart2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart2.BackColor = System.Drawing.Color.Gainsboro
        ChartArea2.Area3DStyle.Enable3D = True
        ChartArea2.Area3DStyle.Inclination = 15
        ChartArea2.Area3DStyle.IsClustered = True
        ChartArea2.Area3DStyle.PointDepth = 8
        ChartArea2.Area3DStyle.WallWidth = 3
        ChartArea2.AxisX.Interval = 1.0R
        ChartArea2.AxisX.IntervalOffset = 1.0R
        ChartArea2.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days
        ChartArea2.AxisX.IsLabelAutoFit = False
        ChartArea2.AxisX.LabelStyle.Angle = -48
        ChartArea2.AxisX.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        ChartArea2.AxisX.MajorGrid.Enabled = False
        ChartArea2.AxisX.MajorGrid.Interval = 0.0R
        ChartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray
        ChartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.DimGray
        ChartArea2.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot
        ChartArea2.AxisX.Title = "Part"
        ChartArea2.AxisX.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        ChartArea2.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[True]
        ChartArea2.AxisX2.Interval = 1.0R
        ChartArea2.AxisX2.IntervalOffset = 1.0R
        ChartArea2.AxisX2.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days
        ChartArea2.AxisX2.IsLabelAutoFit = False
        ChartArea2.AxisX2.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        ChartArea2.AxisX2.MajorGrid.Enabled = False
        ChartArea2.AxisX2.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        ChartArea2.AxisY.IsLabelAutoFit = False
        ChartArea2.AxisY.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        ChartArea2.AxisY.MajorGrid.Enabled = False
        ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray
        ChartArea2.AxisY.Title = "PCS / HR"
        ChartArea2.AxisY.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        ChartArea2.AxisY2.IsLabelAutoFit = False
        ChartArea2.AxisY2.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        ChartArea2.BackColor = System.Drawing.Color.DarkGray
        ChartArea2.BackSecondaryColor = System.Drawing.Color.Black
        ChartArea2.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Me.Chart2.Location = New System.Drawing.Point(889, 294)
        Me.Chart2.Name = "Chart2"
        Series5.BorderWidth = 2
        Series5.ChartArea = "ChartArea1"
        Series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series5.Color = System.Drawing.Color.Blue
        Series5.CustomProperties = "LabelStyle=Top"
        Series5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Italic)
        Series5.IsValueShownAsLabel = True
        Series5.LegendText = "Target"
        Series5.Name = "Series5"
        Series6.ChartArea = "ChartArea1"
        Series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn
        Series6.Color = System.Drawing.Color.Lime
        Series6.CustomProperties = "LabelStyle=Center"
        Series6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold)
        Series6.IsValueShownAsLabel = True
        Series6.IsVisibleInLegend = False
        Series6.LegendText = "Production"
        Series6.Name = "C Shift"
        Series7.ChartArea = "ChartArea1"
        Series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn
        Series7.Color = System.Drawing.Color.GreenYellow
        Series7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Italic)
        Series7.IsValueShownAsLabel = True
        Series7.IsVisibleInLegend = False
        Series7.Name = "Series3"
        Series8.ChartArea = "ChartArea1"
        Series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine
        Series8.Color = System.Drawing.Color.Blue
        Series8.Name = "Series4"
        Me.Chart2.Series.Add(Series5)
        Me.Chart2.Series.Add(Series6)
        Me.Chart2.Series.Add(Series7)
        Me.Chart2.Series.Add(Series8)
        Me.Chart2.Size = New System.Drawing.Size(574, 337)
        Me.Chart2.TabIndex = 240
        Me.Chart2.Text = "Chart2"
        '
        'TimerFontSize
        '
        Me.TimerFontSize.Interval = 1500
        '
        'LblFontIncrement
        '
        Me.LblFontIncrement.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblFontIncrement.AutoSize = True
        Me.LblFontIncrement.Font = New System.Drawing.Font("Microsoft Sans Serif", 120.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFontIncrement.Location = New System.Drawing.Point(668, 302)
        Me.LblFontIncrement.Name = "LblFontIncrement"
        Me.LblFontIncrement.Size = New System.Drawing.Size(166, 181)
        Me.LblFontIncrement.TabIndex = 241
        Me.LblFontIncrement.Text = "0"
        Me.LblFontIncrement.Visible = False
        '
        'LblPart
        '
        Me.LblPart.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPart.Location = New System.Drawing.Point(0, 76)
        Me.LblPart.Name = "LblPart"
        Me.LblPart.Size = New System.Drawing.Size(1503, 51)
        Me.LblPart.TabIndex = 232
        Me.LblPart.Text = "PART: "
        Me.LblPart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RadialGaugeArc4
        '
        Me.RadialGaugeArc4.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadialGaugeArc4.AngleTransform = 0.0!
        Me.RadialGaugeArc4.BackColor = System.Drawing.Color.Red
        Me.RadialGaugeArc4.BackColor2 = System.Drawing.Color.Brown
        Me.RadialGaugeArc4.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RadialGaugeArc4.FlipText = False
        Me.RadialGaugeArc4.Margin = New System.Windows.Forms.Padding(0)
        Me.RadialGaugeArc4.Name = "RadialGaugeArc4"
        Me.RadialGaugeArc4.Padding = New System.Windows.Forms.Padding(0)
        Me.RadialGaugeArc4.RangeEnd = 97.0R
        Me.RadialGaugeArc4.RightToLeft = False
        Me.RadialGaugeArc4.Text = Nothing
        Me.RadialGaugeArc4.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadialGaugeArc4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RadialGaugeArc4.TextWrap = False
        Me.RadialGaugeArc4.Width = 6.0R
        '
        'RadialGaugeArc5
        '
        Me.RadialGaugeArc5.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadialGaugeArc5.AngleTransform = 0.0!
        Me.RadialGaugeArc5.BackColor = System.Drawing.Color.Lime
        Me.RadialGaugeArc5.BackColor2 = System.Drawing.Color.Lime
        Me.RadialGaugeArc5.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RadialGaugeArc5.FlipText = False
        Me.RadialGaugeArc5.Margin = New System.Windows.Forms.Padding(0)
        Me.RadialGaugeArc5.Name = "RadialGaugeArc5"
        Me.RadialGaugeArc5.Padding = New System.Windows.Forms.Padding(0)
        Me.RadialGaugeArc5.RangeEnd = 115.0R
        Me.RadialGaugeArc5.RangeStart = 100.0R
        Me.RadialGaugeArc5.RightToLeft = False
        Me.RadialGaugeArc5.Text = Nothing
        Me.RadialGaugeArc5.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadialGaugeArc5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RadialGaugeArc5.TextWrap = False
        Me.RadialGaugeArc5.Width = 6.0R
        '
        'RadialGaugeArc6
        '
        Me.RadialGaugeArc6.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadialGaugeArc6.AngleTransform = 0.0!
        Me.RadialGaugeArc6.BackColor = System.Drawing.Color.Yellow
        Me.RadialGaugeArc6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(88, Byte), Integer))
        Me.RadialGaugeArc6.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RadialGaugeArc6.FlipText = False
        Me.RadialGaugeArc6.Margin = New System.Windows.Forms.Padding(0)
        Me.RadialGaugeArc6.Name = "RadialGaugeArc6"
        Me.RadialGaugeArc6.Padding = New System.Windows.Forms.Padding(0)
        Me.RadialGaugeArc6.RangeEnd = 97.0R
        Me.RadialGaugeArc6.RangeStart = 100.0R
        Me.RadialGaugeArc6.RightToLeft = False
        Me.RadialGaugeArc6.Text = Nothing
        Me.RadialGaugeArc6.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadialGaugeArc6.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RadialGaugeArc6.TextWrap = False
        Me.RadialGaugeArc6.Width = 6.0R
        '
        'RadialGaugeTicks2
        '
        Me.RadialGaugeTicks2.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadialGaugeTicks2.AngleTransform = 0.0!
        Me.RadialGaugeTicks2.BackColor = System.Drawing.Color.White
        Me.RadialGaugeTicks2.BackColor2 = System.Drawing.Color.White
        Me.RadialGaugeTicks2.BackColor3 = System.Drawing.Color.White
        Me.RadialGaugeTicks2.BorderBottomColor = System.Drawing.Color.White
        Me.RadialGaugeTicks2.BorderColor = System.Drawing.Color.White
        Me.RadialGaugeTicks2.BorderColor2 = System.Drawing.Color.White
        Me.RadialGaugeTicks2.BorderColor3 = System.Drawing.Color.White
        Me.RadialGaugeTicks2.BorderColor4 = System.Drawing.Color.White
        Me.RadialGaugeTicks2.BorderInnerColor2 = System.Drawing.Color.White
        Me.RadialGaugeTicks2.BorderInnerColor3 = System.Drawing.Color.White
        Me.RadialGaugeTicks2.BorderInnerColor4 = System.Drawing.Color.White
        Me.RadialGaugeTicks2.BorderLeftColor = System.Drawing.Color.White
        Me.RadialGaugeTicks2.BorderRightColor = System.Drawing.Color.White
        Me.RadialGaugeTicks2.BorderTopColor = System.Drawing.Color.White
        Me.RadialGaugeTicks2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RadialGaugeTicks2.DrawText = False
        Me.RadialGaugeTicks2.FlipText = False
        Me.RadialGaugeTicks2.ForeColor = System.Drawing.Color.White
        Me.RadialGaugeTicks2.HorizontalLineColor = System.Drawing.Color.White
        Me.RadialGaugeTicks2.Margin = New System.Windows.Forms.Padding(0)
        Me.RadialGaugeTicks2.Name = "RadialGaugeTicks2"
        Me.RadialGaugeTicks2.Padding = New System.Windows.Forms.Padding(0)
        Me.RadialGaugeTicks2.RightToLeft = False
        Me.RadialGaugeTicks2.Text = Nothing
        Me.RadialGaugeTicks2.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadialGaugeTicks2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RadialGaugeTicks2.TextWrap = False
        Me.RadialGaugeTicks2.TickColor = System.Drawing.Color.Black
        Me.RadialGaugeTicks2.TicksCount = 24
        Me.RadialGaugeTicks2.TicksLenghtPercentage = 5.0!
        Me.RadialGaugeTicks2.TickThickness = 1.0!
        '
        'RadialGaugeLabels2
        '
        Me.RadialGaugeLabels2.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadialGaugeLabels2.AngleTransform = 0.0!
        Me.RadialGaugeLabels2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RadialGaugeLabels2.DrawText = False
        Me.RadialGaugeLabels2.FlipText = False
        Me.RadialGaugeLabels2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadialGaugeLabels2.ForeColor = System.Drawing.Color.Black
        Me.RadialGaugeLabels2.LabelFontSize = 5.0!
        Me.RadialGaugeLabels2.LabelRadiusPercentage = 68.0!
        Me.RadialGaugeLabels2.LabelsCount = 12
        Me.RadialGaugeLabels2.Margin = New System.Windows.Forms.Padding(0)
        Me.RadialGaugeLabels2.Name = "RadialGaugeLabels2"
        Me.RadialGaugeLabels2.Padding = New System.Windows.Forms.Padding(0)
        Me.RadialGaugeLabels2.RightToLeft = False
        Me.RadialGaugeLabels2.Text = Nothing
        Me.RadialGaugeLabels2.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadialGaugeLabels2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RadialGaugeLabels2.TextWrap = False
        '
        'RadialGaugeNeedle2
        '
        Me.RadialGaugeNeedle2.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadialGaugeNeedle2.AngleTransform = 0.0!
        Me.RadialGaugeNeedle2.BackColor = System.Drawing.Color.Black
        Me.RadialGaugeNeedle2.BackColor2 = System.Drawing.Color.Black
        Me.RadialGaugeNeedle2.BackColor3 = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer))
        Me.RadialGaugeNeedle2.BackLenghtPercentage = 0.0R
        Me.RadialGaugeNeedle2.BorderBottomWidth = 1.0!
        Me.RadialGaugeNeedle2.BorderBoxStyle = Telerik.WinControls.BorderBoxStyle.OuterInnerBorders
        Me.RadialGaugeNeedle2.BorderColor = System.Drawing.Color.Black
        Me.RadialGaugeNeedle2.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.RadialGaugeNeedle2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RadialGaugeNeedle2.FlipText = False
        Me.RadialGaugeNeedle2.InnerPointRadiusPercentage = 0.0R
        Me.RadialGaugeNeedle2.LenghtPercentage = 70.0R
        Me.RadialGaugeNeedle2.Margin = New System.Windows.Forms.Padding(0)
        Me.RadialGaugeNeedle2.Name = "RadialGaugeNeedle2"
        Me.RadialGaugeNeedle2.Padding = New System.Windows.Forms.Padding(0)
        Me.RadialGaugeNeedle2.PointRadiusPercentage = 7.0R
        Me.RadialGaugeNeedle2.RightToLeft = False
        Me.RadialGaugeNeedle2.Text = Nothing
        Me.RadialGaugeNeedle2.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadialGaugeNeedle2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RadialGaugeNeedle2.TextWrap = False
        Me.RadialGaugeNeedle2.Thickness = 2.0R
        Me.RadialGaugeNeedle2.Value = 99.11!
        '
        'RadialGaugeTicks3
        '
        Me.RadialGaugeTicks3.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadialGaugeTicks3.AngleTransform = 0.0!
        Me.RadialGaugeTicks3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RadialGaugeTicks3.FlipText = False
        Me.RadialGaugeTicks3.Margin = New System.Windows.Forms.Padding(0)
        Me.RadialGaugeTicks3.Name = "RadialGaugeTicks3"
        Me.RadialGaugeTicks3.Padding = New System.Windows.Forms.Padding(0)
        Me.RadialGaugeTicks3.RightToLeft = False
        Me.RadialGaugeTicks3.Text = "RadialGaugeTicks2"
        Me.RadialGaugeTicks3.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadialGaugeTicks3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RadialGaugeTicks3.TextWrap = False
        Me.RadialGaugeTicks3.TickColor = System.Drawing.Color.Black
        Me.RadialGaugeTicks3.TickEndIndexVisibleRange = 16.0!
        Me.RadialGaugeTicks3.TicksCount = 12
        Me.RadialGaugeTicks3.TickStartIndexVisibleRange = 0.0!
        '
        'RadialGaugeSingleLabel1
        '
        Me.RadialGaugeSingleLabel1.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadialGaugeSingleLabel1.AngleTransform = 0.0!
        Me.RadialGaugeSingleLabel1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RadialGaugeSingleLabel1.FlipText = False
        Me.RadialGaugeSingleLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadialGaugeSingleLabel1.ForeColor = System.Drawing.Color.Black
        Me.RadialGaugeSingleLabel1.LabelText = "00.00%"
        Me.RadialGaugeSingleLabel1.LocationPercentage = New System.Drawing.SizeF(0.0!, 0.8!)
        Me.RadialGaugeSingleLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.RadialGaugeSingleLabel1.Name = "RadialGaugeSingleLabel1"
        Me.RadialGaugeSingleLabel1.Padding = New System.Windows.Forms.Padding(0)
        Me.RadialGaugeSingleLabel1.RightToLeft = False
        Me.RadialGaugeSingleLabel1.Text = "RadialGaugeSingleLabel1"
        Me.RadialGaugeSingleLabel1.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadialGaugeSingleLabel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault
        Me.RadialGaugeSingleLabel1.TextWrap = False
        '
        'LblEfficiency
        '
        Me.LblEfficiency.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblEfficiency.AutoSize = True
        Me.LblEfficiency.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEfficiency.Location = New System.Drawing.Point(118, 224)
        Me.LblEfficiency.Name = "LblEfficiency"
        Me.LblEfficiency.Size = New System.Drawing.Size(92, 24)
        Me.LblEfficiency.TabIndex = 0
        Me.LblEfficiency.Text = "To Target"
        '
        'RadRadialGauge2
        '
        Me.RadRadialGauge2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadRadialGauge2.BackColor = System.Drawing.Color.Transparent
        Me.RadRadialGauge2.CausesValidation = False
        Me.RadRadialGauge2.Controls.Add(Me.LblEfficiency)
        Me.RadRadialGauge2.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadialGaugeArc4, Me.RadialGaugeArc5, Me.RadialGaugeArc6, Me.RadialGaugeTicks2, Me.RadialGaugeLabels2, Me.RadialGaugeNeedle2, Me.RadialGaugeTicks3, Me.RadialGaugeSingleLabel1})
        Me.RadRadialGauge2.Location = New System.Drawing.Point(1198, -12)
        Me.RadRadialGauge2.Name = "RadRadialGauge2"
        Me.RadRadialGauge2.RangeEnd = 120.0R
        Me.RadRadialGauge2.Size = New System.Drawing.Size(320, 254)
        Me.RadRadialGauge2.StartAngle = 130.0R
        Me.RadRadialGauge2.SweepAngle = 280.0R
        Me.RadRadialGauge2.TabIndex = 235
        Me.RadRadialGauge2.Text = "radRadialGauge1"
        Me.RadRadialGauge2.Value = 0.0!
        '
        'LblResource
        '
        Me.LblResource.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblResource.Font = New System.Drawing.Font("Microsoft Sans Serif", 38.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblResource.Location = New System.Drawing.Point(0, 0)
        Me.LblResource.Name = "LblResource"
        Me.LblResource.Size = New System.Drawing.Size(1503, 76)
        Me.LblResource.TabIndex = 231
        Me.LblResource.Text = "RESOURCE:"
        Me.LblResource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblCurrentActualValue
        '
        Me.LblCurrentActualValue.AutoSize = True
        Me.LblCurrentActualValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurrentActualValue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblCurrentActualValue.Location = New System.Drawing.Point(360, 130)
        Me.LblCurrentActualValue.Name = "LblCurrentActualValue"
        Me.LblCurrentActualValue.Size = New System.Drawing.Size(42, 44)
        Me.LblCurrentActualValue.TabIndex = 242
        Me.LblCurrentActualValue.Text = "0"
        Me.LblCurrentActualValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Picpause
        '
        Me.Picpause.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Picpause.Image = Global.HourlyProductionDisplay.My.Resources.Resources._1476829650_067_Pause
        Me.Picpause.Location = New System.Drawing.Point(1092, 9)
        Me.Picpause.Name = "Picpause"
        Me.Picpause.Size = New System.Drawing.Size(100, 50)
        Me.Picpause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Picpause.TabIndex = 239
        Me.Picpause.TabStop = False
        Me.Picpause.Visible = False
        '
        'PicSlide2
        '
        Me.PicSlide2.Image = Global.HourlyProductionDisplay.My.Resources.Resources._1346947401_image_add
        Me.PicSlide2.Location = New System.Drawing.Point(210, 593)
        Me.PicSlide2.Name = "PicSlide2"
        Me.PicSlide2.Size = New System.Drawing.Size(181, 156)
        Me.PicSlide2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicSlide2.TabIndex = 238
        Me.PicSlide2.TabStop = False
        '
        'PicSlide1
        '
        Me.PicSlide1.Image = Global.HourlyProductionDisplay.My.Resources.Resources._1346947401_image_add
        Me.PicSlide1.Location = New System.Drawing.Point(19, 593)
        Me.PicSlide1.Name = "PicSlide1"
        Me.PicSlide1.Size = New System.Drawing.Size(185, 156)
        Me.PicSlide1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicSlide1.TabIndex = 237
        Me.PicSlide1.TabStop = False
        '
        'LblShiftDelta
        '
        Me.LblShiftDelta.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShiftDelta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblShiftDelta.Location = New System.Drawing.Point(2, 181)
        Me.LblShiftDelta.Name = "LblShiftDelta"
        Me.LblShiftDelta.Size = New System.Drawing.Size(368, 44)
        Me.LblShiftDelta.TabIndex = 243
        Me.LblShiftDelta.Text = "Delta:"
        Me.LblShiftDelta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblShiftDeltaValue
        '
        Me.LblShiftDeltaValue.AutoSize = True
        Me.LblShiftDeltaValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShiftDeltaValue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblShiftDeltaValue.Location = New System.Drawing.Point(360, 181)
        Me.LblShiftDeltaValue.Name = "LblShiftDeltaValue"
        Me.LblShiftDeltaValue.Size = New System.Drawing.Size(42, 44)
        Me.LblShiftDeltaValue.TabIndex = 244
        Me.LblShiftDeltaValue.Text = "0"
        Me.LblShiftDeltaValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelPrensas
        '
        Me.PanelPrensas.Controls.Add(Me.LblSPMActual)
        Me.PanelPrensas.Controls.Add(Me.Lblsetupactual)
        Me.PanelPrensas.Controls.Add(Me.Label5)
        Me.PanelPrensas.Controls.Add(Me.LblSetupTarget)
        Me.PanelPrensas.Controls.Add(Me.Label4)
        Me.PanelPrensas.Controls.Add(Me.Label2)
        Me.PanelPrensas.Controls.Add(Me.LblSPMTarget)
        Me.PanelPrensas.Controls.Add(Me.Label1)
        Me.PanelPrensas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelPrensas.Location = New System.Drawing.Point(0, 722)
        Me.PanelPrensas.Name = "PanelPrensas"
        Me.PanelPrensas.Size = New System.Drawing.Size(1503, 63)
        Me.PanelPrensas.TabIndex = 245
        '
        'LblSPMActual
        '
        Me.LblSPMActual.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblSPMActual.AutoSize = True
        Me.LblSPMActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSPMActual.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblSPMActual.Location = New System.Drawing.Point(587, 0)
        Me.LblSPMActual.Name = "LblSPMActual"
        Me.LblSPMActual.Size = New System.Drawing.Size(64, 44)
        Me.LblSPMActual.TabIndex = 245
        Me.LblSPMActual.Text = "00"
        Me.LblSPMActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lblsetupactual
        '
        Me.Lblsetupactual.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Lblsetupactual.AutoSize = True
        Me.Lblsetupactual.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblsetupactual.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lblsetupactual.Location = New System.Drawing.Point(1321, 0)
        Me.Lblsetupactual.Name = "Lblsetupactual"
        Me.Lblsetupactual.Size = New System.Drawing.Size(120, 44)
        Me.Lblsetupactual.TabIndex = 249
        Me.Lblsetupactual.Text = "00:00"
        Me.Lblsetupactual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1063, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(253, 44)
        Me.Label5.TabIndex = 248
        Me.Label5.Text = "Actual setup:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblSetupTarget
        '
        Me.LblSetupTarget.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblSetupTarget.AutoSize = True
        Me.LblSetupTarget.BackColor = System.Drawing.Color.Lime
        Me.LblSetupTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSetupTarget.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblSetupTarget.Location = New System.Drawing.Point(936, 0)
        Me.LblSetupTarget.Name = "LblSetupTarget"
        Me.LblSetupTarget.Size = New System.Drawing.Size(120, 44)
        Me.LblSetupTarget.TabIndex = 247
        Me.LblSetupTarget.Text = "00:00"
        Me.LblSetupTarget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(675, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(257, 44)
        Me.Label4.TabIndex = 246
        Me.Label4.Text = "Target setup:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(357, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(240, 44)
        Me.Label2.TabIndex = 244
        Me.Label2.Text = "SPM Actual:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblSPMTarget
        '
        Me.LblSPMTarget.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LblSPMTarget.AutoSize = True
        Me.LblSPMTarget.BackColor = System.Drawing.Color.Lime
        Me.LblSPMTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSPMTarget.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblSPMTarget.Location = New System.Drawing.Point(265, 0)
        Me.LblSPMTarget.Name = "LblSPMTarget"
        Me.LblSPMTarget.Size = New System.Drawing.Size(64, 44)
        Me.LblSPMTarget.TabIndex = 243
        Me.LblSPMTarget.Text = "00"
        Me.LblSPMTarget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 44)
        Me.Label1.TabIndex = 229
        Me.Label1.Text = "SPM target:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBLERROR
        '
        Me.LBLERROR.Location = New System.Drawing.Point(4, 302)
        Me.LBLERROR.Name = "LBLERROR"
        Me.LBLERROR.Size = New System.Drawing.Size(136, 29)
        Me.LBLERROR.TabIndex = 246
        Me.LBLERROR.Text = "Label3"
        Me.LBLERROR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LBLERROR.Visible = False
        '
        'FormDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1503, 785)
        Me.Controls.Add(Me.LBLERROR)
        Me.Controls.Add(Me.PanelPrensas)
        Me.Controls.Add(Me.LblFechaHora)
        Me.Controls.Add(Me.LblShiftDeltaValue)
        Me.Controls.Add(Me.LblShiftDelta)
        Me.Controls.Add(Me.LblCurrentActualValue)
        Me.Controls.Add(Me.LblCurrentActual)
        Me.Controls.Add(Me.LblFontIncrement)
        Me.Controls.Add(Me.LblChangeOverBlue)
        Me.Controls.Add(Me.Chart2)
        Me.Controls.Add(Me.Picpause)
        Me.Controls.Add(Me.PicSlide2)
        Me.Controls.Add(Me.PicSlide1)
        Me.Controls.Add(Me.RadRadialGauge2)
        Me.Controls.Add(Me.LblShifTarget)
        Me.Controls.Add(Me.LblCurrentTarget)
        Me.Controls.Add(Me.LblAverage)
        Me.Controls.Add(Me.LblPart)
        Me.Controls.Add(Me.LblResource)
        Me.Controls.Add(Me.Chart1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FormDisplay"
        Me.Text = "Hourly Production Display"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadRadialGauge2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadRadialGauge2.ResumeLayout(False)
        Me.RadRadialGauge2.PerformLayout()
        CType(Me.Picpause, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicSlide2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicSlide1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelPrensas.ResumeLayout(False)
        Me.PanelPrensas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblShifTarget As System.Windows.Forms.Label
    Friend WithEvents LblCurrentActual As System.Windows.Forms.Label
    Friend WithEvents LblCurrentTarget As System.Windows.Forms.Label
    Friend WithEvents LblAverage As System.Windows.Forms.Label
    Friend WithEvents LblFechaHora As System.Windows.Forms.Label
    Friend WithEvents LblChangeOverBlue As System.Windows.Forms.Label
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents TimerDatos As System.Windows.Forms.Timer
    Friend WithEvents TimerChange As System.Windows.Forms.Timer
    Friend WithEvents TimerSlides As System.Windows.Forms.Timer
    Friend WithEvents PicSlide1 As System.Windows.Forms.PictureBox
    Friend WithEvents PicSlide2 As System.Windows.Forms.PictureBox
    Friend WithEvents Picpause As System.Windows.Forms.PictureBox
    Friend WithEvents Chart2 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents TimerFontSize As System.Windows.Forms.Timer
    Friend WithEvents LblFontIncrement As System.Windows.Forms.Label
    Friend WithEvents LblPart As System.Windows.Forms.Label
    Friend WithEvents RadialGaugeArc4 As Telerik.WinControls.UI.Gauges.RadialGaugeArc
    Friend WithEvents RadialGaugeArc5 As Telerik.WinControls.UI.Gauges.RadialGaugeArc
    Friend WithEvents RadialGaugeArc6 As Telerik.WinControls.UI.Gauges.RadialGaugeArc
    Friend WithEvents RadialGaugeTicks2 As Telerik.WinControls.UI.Gauges.RadialGaugeTicks
    Friend WithEvents RadialGaugeLabels2 As Telerik.WinControls.UI.Gauges.RadialGaugeLabels
    Friend WithEvents RadialGaugeNeedle2 As Telerik.WinControls.UI.Gauges.RadialGaugeNeedle
    Friend WithEvents RadialGaugeTicks3 As Telerik.WinControls.UI.Gauges.RadialGaugeTicks
    Friend WithEvents RadialGaugeSingleLabel1 As Telerik.WinControls.UI.Gauges.RadialGaugeSingleLabel
    Friend WithEvents LblEfficiency As System.Windows.Forms.Label
    Friend WithEvents RadRadialGauge2 As Telerik.WinControls.UI.Gauges.RadRadialGauge
    Friend WithEvents LblResource As System.Windows.Forms.Label
    Friend WithEvents LblCurrentActualValue As System.Windows.Forms.Label
    Friend WithEvents LblShiftDelta As System.Windows.Forms.Label
    Friend WithEvents LblShiftDeltaValue As System.Windows.Forms.Label
    Friend WithEvents PanelPrensas As System.Windows.Forms.Panel
    Friend WithEvents Lblsetupactual As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblSetupTarget As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblSPMActual As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblSPMTarget As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LBLERROR As System.Windows.Forms.Label

End Class
