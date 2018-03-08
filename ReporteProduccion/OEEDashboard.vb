Public Class OEEDashboard
    Dim GaugeIndicator As New AquaControls.AquaGauge

    Private _Resource As String
    Private _OEE As Double
    <System.ComponentModel.Description("Resource")> _
    Public Property Resource() As String
        Get
            Return _Resource
        End Get
        Set(ByVal value As String)
            _Resource = value
        End Set
    End Property



    Private Sub OEEDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LblResource.Text = _Resource
        GaugeIndicator.Font = New Font(Font.FontFamily, 14)
        GaugeIndicator.DialText = "OEE"
        GaugeIndicator.MaxValue = 100
        GaugeIndicator.MinValue = 0
        GaugeIndicator.NoOfDivisions = 10
        GaugeIndicator.NoOfSubDivisions = 5
        GaugeIndicator.RecommendedValue = 92.5
        GaugeIndicator.ThresholdPercent = 15
        GaugeIndicator.RecommendedValue2 = 40
        GaugeIndicator.ThresholdPercent2 = 80
        GaugeIndicator.RecommendedValue3 = 82.5
        GaugeIndicator.ThresholdPercent3 = 5
        PanelGauge.Controls.Add(GaugeIndicator)

        GaugeIndicator.Size = PanelGauge.Size
    End Sub
End Class
