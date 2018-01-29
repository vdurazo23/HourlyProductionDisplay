Public Class HSPR01_1

    Dim cn As New SqlClient.SqlConnection("Data Source=192.168.114.99\mars;workstation id=;Persist Security Info=True;User ID=dtu;password=dtu-igear;initial catalog=MARS")
    Dim ds As New DataSet
    Dim da As New SqlClient.SqlDataAdapter("", cn)
    Dim cmd As New SqlClient.SqlCommand("", cn)

    Public waterin_lo As Integer = 12
    Public waterin_hi As Integer = 25

    Public waterout_lo As Integer = 16
    Public waterout_hi As Integer = 40

    Public oventemp_lo As Integer = 930
    Public oventemp_hi As Integer = 960

    Public blanctempbefore_lo As Integer = 675
    Public blanctempbefore_hi As Integer = 950

    Public blanctempafter_lo As Integer = 50
    Public blanctempafter_hi As Integer = 250

    Private Sub HSPR01_1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1_Tick(sender, e)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Me.BackColor = Color.White
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim TABLE As String = "HSPR01"
            If My.Settings.HSPR01 Then TABLE = "HSPR01"
            If My.Settings.HSPR02 Then TABLE = "HSPR02"
            If My.Settings.HSPR03 Then TABLE = "HSPR03"


            da.SelectCommand.CommandText = "select top 20 * from hmo." & TABLE & "_HIST order by id desc"
            ds.Tables.Clear()
            da.Fill(ds, "HSPR01")
            'cmd.CommandText = "select datediff(second,fecha,getdate()) as segundos from [hmo].[HSPR01]"
            'If cmd.ExecuteScalar > 60 Then
            '    Me.BackColor = Color.Yellow
            'End If
            Try
                ChartWaterTempIn.Series(0).Points.Clear()
                ChartWaterTempIn.Series(1).Points.Clear()
                ChartWaterTempIn.Series(2).Points.Clear()
                ChartWaterTempIn.Series(3).Points.Clear()

                ChartWaterTempOut.Series(0).Points.Clear()
                ChartWaterTempOut.Series(1).Points.Clear()
                ChartWaterTempOut.Series(2).Points.Clear()
                ChartWaterTempOut.Series(3).Points.Clear()

                ChartOven1.Series(0).Points.Clear()
                ChartOven1.Series(1).Points.Clear()
                ChartOven1.Series(2).Points.Clear()
                ChartOven1.Series(3).Points.Clear()
                ChartOven1.Series(4).Points.Clear()

                ChartOven2.Series(0).Points.Clear()
                ChartOven2.Series(1).Points.Clear()
                ChartOven2.Series(2).Points.Clear()
                ChartOven2.Series(3).Points.Clear()
                ChartOven2.Series(4).Points.Clear()


                ChartBlankBefore.Series(0).Points.Clear()
                ChartBlankBefore.Series(1).Points.Clear()
                ChartBlankBefore.Series(2).Points.Clear()
                ChartBlankBefore.Series(3).Points.Clear()
                ChartBlankBefore.Series(4).Points.Clear()
                ChartBlankBefore.Series(5).Points.Clear()

                ChartBlankaFTER.Series(0).Points.Clear()
                ChartBlankaFTER.Series(1).Points.Clear()
                ChartBlankaFTER.Series(2).Points.Clear()
                ChartBlankaFTER.Series(3).Points.Clear()
                ChartBlankaFTER.Series(4).Points.Clear()
                ChartBlankaFTER.Series(5).Points.Clear()

                ChartWaterTempIn.Series(0).Points.AddXY(0, waterin_hi)
                ChartWaterTempIn.Series(1).Points.AddXY(0, waterin_lo)

                ChartWaterTempOut.Series(0).Points.AddXY(0, waterout_hi)
                ChartWaterTempOut.Series(1).Points.AddXY(0, waterout_lo)

                ChartOven1.Series(0).Points.AddXY(0, oventemp_hi)
                ChartOven1.Series(1).Points.AddXY(0, oventemp_lo)

                ChartOven2.Series(0).Points.AddXY(0, oventemp_hi)
                ChartOven2.Series(1).Points.AddXY(0, oventemp_lo)

                ChartBlankBefore.Series(0).Points.AddXY(0, blanctempbefore_hi)
                ChartBlankBefore.Series(1).Points.AddXY(0, blanctempbefore_lo)

                ChartBlankaFTER.Series(0).Points.AddXY(0, blanctempafter_hi)
                ChartBlankaFTER.Series(1).Points.AddXY(0, blanctempafter_lo)

                Dim num As Integer = 0
                For i = (ds.Tables("HSPR01").DefaultView.Count - 1) To 0 Step -1
                    ' ''WATER UPPER DIE (IN)
                    'PaintGauge("TempAguaUpperDieIN", LblWaterUperDieInTemp, NeedleWaterUperDieInTemp, BackWaterUperDieInTemp, waterin_lo, waterin_hi)
                    ' ''WATER UPPER DIE (OUT)
                    'PaintGauge("TempAguaUpperDieOUT", LblWaterUperDieOutTemp, NeedleWaterUperDieOutTemp, BackWaterUperDieOutTemp, waterout_lo, waterout_hi)
                    ' ''WATER LOWER DIE IN
                    'PaintGauge("TempAguaLowerDieIN", LblWaterlowerDieInTemp, NeedleWaterlowerDieInTemp, BackWaterlowerDieInTemp, waterin_lo, waterin_hi)
                    ' ''WATER LOWER DIE OUT
                    'PaintGauge("TempAguaLowerDieOUT", LblWaterlowerDieOutTemp, NeedleWaterlowerDieOutTemp, BackWaterlowerDieOutTemp, waterout_lo, waterout_hi)


                    ChartWaterTempIn.Series(0).Points.AddXY(num + 1, waterin_hi)
                    ChartWaterTempIn.Series(1).Points.AddXY(num + 1, waterin_lo)
                    ChartWaterTempIn.Series(2).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempAguaUpperDieIN"))
                    ChartWaterTempIn.Series(3).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempAguaLowerDieIN"))

                    ChartWaterTempOut.Series(0).Points.AddXY(num + 1, waterout_hi)
                    ChartWaterTempOut.Series(1).Points.AddXY(num + 1, waterout_lo)
                    ChartWaterTempOut.Series(2).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempAguaUpperDieOUT"))
                    ChartWaterTempOut.Series(3).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempAguaLowerDieOUT"))

                    ChartOven1.Series(0).Points.AddXY(num + 1, oventemp_hi)
                    ChartOven1.Series(1).Points.AddXY(num + 1, oventemp_lo)
                    ChartOven1.Series(2).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempOvenZone1"))
                    ChartOven1.Series(3).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempOvenZone2"))
                    ChartOven1.Series(4).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempOvenZone3"))

                    ChartOven2.Series(0).Points.AddXY(num + 1, oventemp_hi)
                    ChartOven2.Series(1).Points.AddXY(num + 1, oventemp_lo)
                    ChartOven2.Series(2).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempOven2Zone1"))
                    ChartOven2.Series(3).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempOven2Zone2"))
                    ChartOven2.Series(4).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempOven2Zone3"))


                    ChartBlankBefore.Series(0).Points.AddXY(num + 1, blanctempbefore_hi)
                    ChartBlankBefore.Series(1).Points.AddXY(num + 1, blanctempbefore_lo)
                    ChartBlankBefore.Series(2).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempBlankFrontLHtAntes"))
                    ChartBlankBefore.Series(3).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempBlankFrontRHtAntes"))
                    ChartBlankBefore.Series(4).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempBlankRearLHtAntes"))
                    ChartBlankBefore.Series(5).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempBlankRearRHtAntes"))

                    ' ''BLANK BEFORE FL
                    'PaintGauge("TempBlankFrontLHtAntes", LblTempBlankbeforeFL, NeedleTempBlankbeforeFL, BackTempBlankbeforeFL, blanctempbefore_lo, blanctempbefore_hi)
                    ' ''BLANK BEFORE FR
                    'PaintGauge("TempBlankFrontRHtAntes", LblTempBlankbeforeFR, NeedleTempBlankbeforeFR, BackTempBlankbeforeFR, blanctempbefore_lo, blanctempbefore_hi)
                    ' ''BLANK BEFOR RL
                    'PaintGauge("TempBlankRearLHtAntes", LblTempBlankbeforeRL, NeedleTempBlankbeforeRL, BackTempBlankbeforeRL, blanctempbefore_lo, blanctempbefore_hi)
                    ' ''BLANK BEFOR Rr    
                    'PaintGauge("TempBlankRearRHtAntes", LblTempBlankbeforeRR, NeedleTempBlankbeforeRR, BackTempBlankbeforeRR, blanctempbefore_lo, blanctempbefore_hi)

                    ChartBlankaFTER.Series(0).Points.AddXY(num + 1, blanctempafter_hi)
                    ChartBlankaFTER.Series(1).Points.AddXY(num + 1, blanctempafter_lo)
                    ChartBlankaFTER.Series(2).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempBlankFrontLHDespues"))
                    ChartBlankaFTER.Series(3).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempBlankFrontRHDespues"))
                    ChartBlankaFTER.Series(4).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempBlankRearLHDespues"))
                    ChartBlankaFTER.Series(5).Points.AddXY(num + 1, ds.Tables("HSPR01").DefaultView.Item(i).Item("TempBlankRearRHDespues"))
                    ' ''BLANK AFTER FL
                    'PaintGauge("TempBlankFrontLHDespues", LblTempBlankAfterFL, NeedleTempBlankAfterFL, BackTempBlankAfterFL, blanctempafter_lo, blanctempafter_hi)
                    ' ''BLANK AFTER FR
                    'PaintGauge("TempBlankFrontRHDespues", LblTempBlankAfterFR, NeedleTempBlankAfterFR, BackTempBlankAfterFR, blanctempafter_lo, blanctempafter_hi)
                    ' ''BLANK AFTER RL
                    'PaintGauge("TempBlankRearLHDespues", LblTempBlankAfterRL, NeedleTempBlankAfterRL, BackTempBlankAfterRL, blanctempafter_lo, blanctempafter_hi)
                    ' ''BLANK AFTER Rr    
                    'PaintGauge("TempBlankRearRHDespues", LblTempBlankAfterRR, NeedleTempBlankAfterRR, BackTempBlankAfterRR, blanctempafter_lo, blanctempafter_hi)
                    num += 1

                Next

                Try
                    If ds.Tables("HSPR01").DefaultView.Item(ds.Tables("HSPR01").DefaultView.Count - 1).Item("WaterFlowUpperIn") = 1 Then
                        LblWaterFlowUpperIn.Text = "Water Flow Upper: ON"
                        LblWaterFlowUpperIn.BackColor = Color.Lime
                    Else
                        LblWaterFlowUpperIn.Text = "Water Flow Upper: OFF"
                        LblWaterFlowUpperIn.BackColor = Color.Red
                    End If
                Catch ex As Exception
                End Try

                Try
                    If ds.Tables("HSPR01").DefaultView.Item(ds.Tables("HSPR01").DefaultView.Count - 1).Item("WaterFlowLowerIn") = 1 Then
                        LblWaterFlowLowerIn.Text = "Water Flow Lower: ON"
                        LblWaterFlowLowerIn.BackColor = Color.Lime
                    Else
                        LblWaterFlowLowerIn.Text = "Water Flow Lower: OFF"
                        LblWaterFlowLowerIn.BackColor = Color.Red
                    End If
                Catch ex As Exception
                End Try


                Try
                    If ds.Tables("HSPR01").DefaultView.Item(ds.Tables("HSPR01").DefaultView.Count - 1).Item("WaterFlowUpperOut") = 1 Then
                        LblWaterFlowUpperOut.Text = "Water Flow Upper: ON"
                        LblWaterFlowUpperOut.BackColor = Color.Lime
                    Else
                        LblWaterFlowUpperOut.Text = "Water Flow Upper: OFF"
                        LblWaterFlowUpperOut.BackColor = Color.Red
                    End If
                Catch ex As Exception
                End Try

                Try
                    If ds.Tables("HSPR01").DefaultView.Item(ds.Tables("HSPR01").DefaultView.Count - 1).Item("WaterFlowLowerOut") = 1 Then
                        LblWaterFlowLowerOut.Text = "Water Flow Lower: ON"
                        LblWaterFlowLowerOut.BackColor = Color.Lime
                    Else
                        LblWaterFlowLowerOut.Text = "Water Flow Lower: OFF"
                        LblWaterFlowLowerOut.BackColor = Color.Red
                    End If
                Catch ex As Exception
                End Try

                ChartWaterTempIn.Series(0).Points.AddXY(ds.Tables("HSPR01").DefaultView.Count + 1, waterin_hi)
                ChartWaterTempIn.Series(1).Points.AddXY(ds.Tables("HSPR01").DefaultView.Count + 1, waterin_lo)

                ChartWaterTempOut.Series(0).Points.AddXY(ds.Tables("HSPR01").DefaultView.Count + 1, waterout_hi)
                ChartWaterTempOut.Series(1).Points.AddXY(ds.Tables("HSPR01").DefaultView.Count + 1, waterout_lo)

                ChartOven1.Series(0).Points.AddXY(ds.Tables("HSPR01").DefaultView.Count + 1, oventemp_hi)
                ChartOven1.Series(1).Points.AddXY(ds.Tables("HSPR01").DefaultView.Count + 1, oventemp_lo)

                ChartOven2.Series(0).Points.AddXY(ds.Tables("HSPR01").DefaultView.Count + 1, oventemp_hi)
                ChartOven2.Series(1).Points.AddXY(ds.Tables("HSPR01").DefaultView.Count + 1, oventemp_lo)

                ChartBlankBefore.Series(0).Points.AddXY(ds.Tables("HSPR01").DefaultView.Count + 1, blanctempbefore_hi)
                ChartBlankBefore.Series(1).Points.AddXY(ds.Tables("HSPR01").DefaultView.Count + 1, blanctempbefore_lo)

                ChartBlankaFTER.Series(0).Points.AddXY(ds.Tables("HSPR01").DefaultView.Count + 1, blanctempafter_hi)
                ChartBlankaFTER.Series(1).Points.AddXY(ds.Tables("HSPR01").DefaultView.Count + 1, blanctempafter_lo)

                ChartOven1.ChartAreas(0).AxisY.Minimum = 900
                ChartOven1.ChartAreas(0).AxisY.Maximum = 1000

                Dim minov1_1, minov1_2, minov1_3 As Integer
                minov1_1 = ChartOven1.Series(2).Points.FindMinByValue().YValues(0)
                If minov1_1 < 900 Then ChartOven1.ChartAreas(0).AxisY.Minimum = minov1_1 - 10

                minov1_2 = ChartOven1.Series(3).Points.FindMinByValue().YValues(0)
                If minov1_2 < 900 And minov1_2 < minov1_1 Then ChartOven1.ChartAreas(0).AxisY.Minimum = minov1_2 - 10

                minov1_3 = ChartOven1.Series(4).Points.FindMinByValue().YValues(0)
                If minov1_3 < 900 And minov1_3 < minov1_2 Then ChartOven1.ChartAreas(0).AxisY.Minimum = minov1_3 - 10

                ChartOven2.ChartAreas(0).AxisY.Minimum = 900
                ChartOven2.ChartAreas(0).AxisY.Maximum = 1000

                Dim minov2_1, minov2_2, minov2_3 As Integer
                minov2_1 = ChartOven2.Series(2).Points.FindMinByValue().YValues(0)
                If minov2_1 < 900 Then ChartOven2.ChartAreas(0).AxisY.Minimum = minov2_1 - 10

                minov2_2 = ChartOven2.Series(3).Points.FindMinByValue().YValues(0)
                If minov2_2 < 900 And minov2_2 < minov2_1 Then ChartOven2.ChartAreas(0).AxisY.Minimum = minov2_2 - 10

                minov2_3 = ChartOven2.Series(4).Points.FindMinByValue().YValues(0)
                If minov2_3 < 900 And minov2_3 < minov2_2 Then ChartOven2.ChartAreas(0).AxisY.Minimum = minov2_3 - 10

                ChartBlankBefore.ChartAreas(0).AxisY.Minimum = 600
                ChartBlankBefore.ChartAreas(0).AxisY.Maximum = 1000




                ' ''oven1 zone1 
                'PaintGauge("TempOvenZone1", LblOven1Zone1, NeedleOven1Zone1, BackOven1Zone1, oventemp_lo, oventemp_hi)
                ' ''oven1 zone2
                'PaintGauge("TempOvenZone2", LblOven1Zone2, NeedleOven1Zone2, BackOven1Zone2, oventemp_lo, oventemp_hi)
                ' ''oven1 zone3 
                'PaintGauge("TempOvenZone3", LblOven1Zone3, NeedleOven1Zone3, BackOven1Zone3, oventemp_lo, oventemp_hi)

                ' ''oven2 zone1 
                'PaintGauge("TempOven2Zone1", LblOven2Zone1, NeedleOven2Zone1, BackOven2Zone1, oventemp_lo, oventemp_hi)
                ' ''oven2 zone2
                'PaintGauge("TempOven2Zone2", LblOven2Zone2, NeedleOven2Zone2, BackOven2Zone2, oventemp_lo, oventemp_hi)
                ' ''oven2 zone3 
                'PaintGauge("TempOven2Zone3", LblOven2Zone3, NeedleOven2Zone3, BackOven2Zone3, oventemp_lo, oventemp_hi)


                ' ''BLANK BEFORE FL
                'PaintGauge("TempBlankFrontLHtAntes", LblTempBlankbeforeFL, NeedleTempBlankbeforeFL, BackTempBlankbeforeFL, blanctempbefore_lo, blanctempbefore_hi)
                ' ''BLANK BEFORE FR
                'PaintGauge("TempBlankFrontRHtAntes", LblTempBlankbeforeFR, NeedleTempBlankbeforeFR, BackTempBlankbeforeFR, blanctempbefore_lo, blanctempbefore_hi)
                ' ''BLANK BEFOR RL
                'PaintGauge("TempBlankRearLHtAntes", LblTempBlankbeforeRL, NeedleTempBlankbeforeRL, BackTempBlankbeforeRL, blanctempbefore_lo, blanctempbefore_hi)
                ' ''BLANK BEFOR Rr    
                'PaintGauge("TempBlankRearRHtAntes", LblTempBlankbeforeRR, NeedleTempBlankbeforeRR, BackTempBlankbeforeRR, blanctempbefore_lo, blanctempbefore_hi)


                ' ''BLANK AFTER FL
                'PaintGauge("TempBlankFrontLHDespues", LblTempBlankAfterFL, NeedleTempBlankAfterFL, BackTempBlankAfterFL, blanctempafter_lo, blanctempafter_hi)
                ' ''BLANK AFTER FR
                'PaintGauge("TempBlankFrontRHDespues", LblTempBlankAfterFR, NeedleTempBlankAfterFR, BackTempBlankAfterFR, blanctempafter_lo, blanctempafter_hi)
                ' ''BLANK AFTER RL
                'PaintGauge("TempBlankRearLHDespues", LblTempBlankAfterRL, NeedleTempBlankAfterRL, BackTempBlankAfterRL, blanctempafter_lo, blanctempafter_hi)
                ' ''BLANK AFTER Rr    
                'PaintGauge("TempBlankRearRHDespues", LblTempBlankAfterRR, NeedleTempBlankAfterRR, BackTempBlankAfterRR, blanctempafter_lo, blanctempafter_hi)
            Catch ex As Exception
                Me.BackColor = Color.Gainsboro
            End Try
        Catch ex As Exception
            Me.BackColor = Color.Red
        End Try


    End Sub
End Class
