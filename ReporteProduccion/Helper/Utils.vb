Public Class Utils
    Shared Function GetAvailabilityColor(ByVal Availability As Double) As Color
        Dim colortoreturn As Color = Color.Transparent
        If Availability < 0.85 Then colortoreturn = Color.Red
        If Availability >= 0.85 And Availability < 0.9 Then colortoreturn = Color.Yellow
        If Availability >= 0.9 Then colortoreturn = Color.Lime
        Return colortoreturn
    End Function

    Shared Function GetPerformanceColor(ByVal Performance As Double) As Color
        Dim ColorReturn As Color = Color.Transparent
        If Performance < 0.9 Then ColorReturn = Color.Red
        If Performance >= 0.9 And Performance < 0.95 Then ColorReturn = Color.Yellow
        If Performance >= 0.95 Then ColorReturn = Color.Lime
        Return ColorReturn
    End Function

    Shared Function GetQualityColor(ByVal Quality As Double) As Color
        Dim ColorReturn As Color = Color.Transparent
        If Quality < 0.94 Then ColorReturn = Color.Red
        If Quality >= 0.94 And Quality < 0.99 Then ColorReturn = Color.Yellow
        If Quality >= 0.99 Then ColorReturn = Color.Lime
        Return ColorReturn
    End Function

    Shared Function GetOEEColor(ByVal OEE As Double) As Color
        Dim ColorReturn As Color = Color.Transparent
        If OEE < 0.8 Then ColorReturn = Color.Red
        If OEE >= 0.8 And OEE < 0.85 Then ColorReturn = Color.Yellow
        If OEE >= 0.85 Then ColorReturn = Color.Lime
        Return ColorReturn
    End Function
End Class
