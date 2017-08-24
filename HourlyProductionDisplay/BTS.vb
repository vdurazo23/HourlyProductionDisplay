Public Class BTS

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If (Me.UserControl11.Value > 0) Then
            Me.UserControl11.Value -= 1
            Me.UserControl11.Value += 1
        Else
            Me.Timer1.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.UserControl11.Value = 100
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()

        Chart1.Series(0).Points.AddXY("Total", 50)

        Chart1.Series(1).Points.AddXY("Total", 20)

        Chart1.ChartAreas(0).AxisX.Interval = 1
        Chart1.ChartAreas(0).AxisX.Maximum = 2

        Chart1.ChartAreas(0).AxisY.Interval = 10
        Chart1.ChartAreas(0).AxisY.Maximum = 100

        


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.UserControl11.Value = 80
    End Sub
End Class