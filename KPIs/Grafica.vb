Imports System.Windows.Forms.DataVisualization.Charting

Public Class Grafica
    Public KpiName As String = "p"
    Public Mediblename As String = "p"
    Public Rule As String
    Public tabla As DataTable
    Public tipo As String
    Public max As Integer = 0



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadtestchart()
        Chart1.Series(2).CustomProperties = "PixelPointWidth = 10"
        maximo()

    End Sub

    Sub maximo()
        If max = 0 Then
            For Each po As DataPoint In Chart1.Series(2).Points
                If po.YValues(0) > max Then max = po.YValues(0)
            Next
            max = max * 2
        End If
        For a = 0 To Chart1.Series(0).Points.Count - 1
            Chart1.Series(0).Points(a).SetValueY(max)
        Next

    End Sub
    Sub loadtestchart()
        Chart1.Titles(0).Text = KpiName

        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()

        Chart1.Series(2).LegendText = Mediblename

        If tabla Is Nothing Then Exit Sub

        For Each ro As DataRow In tabla.Rows
            Try
                AddXYToChart(ro(3), ro(4), ro(5).ToString)
            Catch ex As Exception
                AddXYToChart(11.5, 9, "Ene")
            End Try
        Next

        Select Case tipo
            Case "<="
                Chart1.Series(0).Color = Color.FromArgb(255, 178, 178)
                Chart1.Series(1).Color = Color.FromArgb(178, 231, 202)

            Case ">="
                Chart1.Series(0).Color = Color.FromArgb(178, 231, 202)
                Chart1.Series(1).Color = Color.FromArgb(255, 178, 178)

            Case "="
                Chart1.Series(0).Color = Color.FromArgb(255, 178, 178)
                Chart1.Series(1).Color = Color.FromArgb(255, 178, 178)

            Case "<>"
                Chart1.Series(0).Color = Color.FromArgb(178, 231, 202)
                Chart1.Series(1).Color = Color.FromArgb(178, 231, 202)

            Case "<"

                Chart1.Series(0).Color = Color.FromArgb(255, 178, 178)
                Chart1.Series(1).Color = Color.FromArgb(178, 231, 202)

            Case ">"
                Chart1.Series(0).Color = Color.FromArgb(178, 231, 202)
                Chart1.Series(1).Color = Color.FromArgb(255, 178, 178)

            Case Else
                Chart1.Series(0).Color = Color.FromArgb(255, 178, 178)
                Chart1.Series(1).Color = Color.FromArgb(178, 231, 202)
        End Select





    End Sub

    Sub AddXYToChart(ByVal obj As Double, ByVal medible As Double, ByVal periodo As String)
        Dim Topofset As Double
        Topofset = obj * 1.5
        ''validar reglas de Rojo vs Verde fondos
        If Topofset > max Then max = Topofset
        Chart1.Series(0).Points.AddXY(periodo, Topofset)
        Chart1.Series(1).Points.AddXY(periodo, obj)
        ''validar reglas de Rojo vs Verde (barras)
        Chart1.Series(2).Points.AddXY(periodo, medible)

        ''Si el tipo de medible esl >=  > < <=  =
        'segun regla pintar el color del medible




        Select Case tipo
            Case "<="

                If medible <= obj Then
                    Chart1.Series(2).Points(Chart1.Series(2).Points.Count - 1).Color = Color.FromArgb(0, 0, 64)
                Else
                    Chart1.Series(2).Points(Chart1.Series(2).Points.Count - 1).Color = Color.Red
                End If

            Case ">="
                If medible >= obj Then
                    Chart1.Series(2).Points(Chart1.Series(2).Points.Count - 1).Color = Color.FromArgb(0, 0, 64)
                Else
                    Chart1.Series(2).Points(Chart1.Series(2).Points.Count - 1).Color = Color.Red
                End If

            Case "="

                If medible = obj Then
                    Chart1.Series(2).Points(Chart1.Series(2).Points.Count - 1).Color = Color.FromArgb(0, 0, 64)
                Else
                    Chart1.Series(2).Points(Chart1.Series(2).Points.Count - 1).Color = Color.Red
                End If
            Case "<>"

                If medible <> obj Then
                    Chart1.Series(2).Points(Chart1.Series(2).Points.Count - 1).Color = Color.FromArgb(0, 0, 64)
                Else
                    Chart1.Series(2).Points(Chart1.Series(2).Points.Count - 1).Color = Color.Red
                End If
            Case "<"

                If medible < obj Then
                    Chart1.Series(2).Points(Chart1.Series(2).Points.Count - 1).Color = Color.FromArgb(0, 0, 64)
                Else
                    Chart1.Series(2).Points(Chart1.Series(2).Points.Count - 1).Color = Color.Red
                End If

            Case ">"
                If medible > obj Then
                    Chart1.Series(2).Points(Chart1.Series(2).Points.Count - 1).Color = Color.FromArgb(0, 0, 64)
                Else
                    Chart1.Series(2).Points(Chart1.Series(2).Points.Count - 1).Color = Color.Red
                End If

            Case Else

                If medible <= obj Then
                    Chart1.Series(2).Points(Chart1.Series(2).Points.Count - 1).Color = Color.FromArgb(0, 0, 64)
                Else
                    Chart1.Series(2).Points(Chart1.Series(2).Points.Count - 1).Color = Color.Red
                End If
        End Select
        Chart1.Series(3).Points.AddXY(periodo, obj)
    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click

    End Sub
    Public boundslocation As New Point
    Private Sub Chart1_DoubleClick(sender As Object, e As EventArgs) Handles Chart1.DoubleClick
        RaiseEvent showchartbig()
        Dim vchrt As New ViewChart
        vchrt.Grafica1.tabla = Me.tabla
        vchrt.Grafica1.KpiName = Me.KpiName
        vchrt.Grafica1.Mediblename = Me.Mediblename
        vchrt.Grafica1.tipo = Me.tipo
        vchrt.Grafica1.loadtestchart()
        vchrt.Grafica1.maximo()
        vchrt.loaddata()
        'vchrt.Location = Me.Bounds.Location
        vchrt.Location = boundslocation
        vchrt.WindowState = FormWindowState.Maximized
        vchrt.StartPosition = FormStartPosition.Manual
        vchrt.ShowDialog()
        vchrt.Dispose()
        vchrt = Nothing
        RaiseEvent closedchartbig()
    End Sub

    Public Event showchartbig()
    Public Event closedchartbig()


    Private Sub Chart1_GetToolTipText(sender As Object, e As ToolTipEventArgs) Handles Chart1.GetToolTipText

        If (e.HitTestResult.ChartElementType = ChartElementType.DataPoint) Then
            If e.HitTestResult.Series.Name = Chart1.Series(0).Name Or e.HitTestResult.Series.Name = Chart1.Series(1).Name Then Exit Sub
            Dim i As Integer = e.HitTestResult.PointIndex
            Dim dp As DataPoint = e.HitTestResult.Series.Points(i)
            e.Text = String.Format("{0:F2}, {1:F2}", dp.AxisLabel, dp.YValues(0))
        End If
    End Sub
End Class
