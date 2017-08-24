Public Class HSPR01
    Dim cn As New SqlClient.SqlConnection("Data Source=192.168.114.99\mars;workstation id=;Persist Security Info=True;User ID=dtu;password=dtu-igear;initial catalog=MARS")
    Dim ds As New DataSet
    Dim da As New SqlClient.SqlDataAdapter("", cn)
    Dim cmd As New SqlClient.SqlCommand("", cn)

    Public waterin_lo As Integer = 10
    Public waterin_hi As Integer = 18

    Public waterout_lo As Integer = 35
    Public waterout_hi As Integer = 65

    Public oventemp_lo As Integer = 930
    Public oventemp_hi As Integer = 960

    Public blanctempbefore_lo As Integer = 635
    Public blanctempbefore_hi As Integer = 665

    Public blanctempafter_lo As Integer = 185
    Public blanctempafter_hi As Integer = 215



    Private Sub HSPR01_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To RadRadialGauge2.Items.Count - 1
            If TypeOf (RadRadialGauge2.Items(i)) Is Telerik.WinControls.UI.Gauges.RadialGaugeArc Then

            End If
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Me.BackColor = Color.White
            If cn.State = ConnectionState.Closed Then cn.Open()
            da.SelectCommand.CommandText = "select * from hmo.HSPR01"
            ds.Tables.Clear()
            da.Fill(ds, "HSPR01")
            cmd.CommandText = "select datediff(second,fecha,getdate()) as segundos from [hmo].[HSPR01]"
            If cmd.ExecuteScalar > 60 Then
                Me.BackColor = Color.Yellow
            End If
            Try
                ''WATER UPPER DIE (IN)
                PaintGauge("TempAguaUpperDieIN", LblWaterUperDieInTemp, NeedleWaterUperDieInTemp, BackWaterUperDieInTemp, waterin_lo, waterin_hi)
                ''WATER UPPER DIE (OUT)
                PaintGauge("TempAguaUpperDieOUT", LblWaterUperDieOutTemp, NeedleWaterUperDieOutTemp, BackWaterUperDieOutTemp, waterout_lo, waterout_hi)
                ''WATER LOWER DIE IN
                PaintGauge("TempAguaLowerDieIN", LblWaterlowerDieInTemp, NeedleWaterlowerDieInTemp, BackWaterlowerDieInTemp, waterin_lo, waterin_hi)
                ''WATER LOWER DIE OUT
                PaintGauge("TempAguaLowerDieOUT", LblWaterlowerDieOutTemp, NeedleWaterlowerDieOutTemp, BackWaterlowerDieOutTemp, waterout_lo, waterout_hi)

                ''oven1 zone1 
                PaintGauge("TempOvenZone1", LblOven1Zone1, NeedleOven1Zone1, BackOven1Zone1, oventemp_lo, oventemp_hi)
                ''oven1 zone2
                PaintGauge("TempOvenZone2", LblOven1Zone2, NeedleOven1Zone2, BackOven1Zone2, oventemp_lo, oventemp_hi)
                ''oven1 zone3 
                PaintGauge("TempOvenZone3", LblOven1Zone3, NeedleOven1Zone3, BackOven1Zone3, oventemp_lo, oventemp_hi)

                ''oven2 zone1 
                PaintGauge("TempOven2Zone1", LblOven2Zone1, NeedleOven2Zone1, BackOven2Zone1, oventemp_lo, oventemp_hi)
                ''oven2 zone2
                PaintGauge("TempOven2Zone2", LblOven2Zone2, NeedleOven2Zone2, BackOven2Zone2, oventemp_lo, oventemp_hi)
                ''oven2 zone3 
                PaintGauge("TempOven2Zone3", LblOven2Zone3, NeedleOven2Zone3, BackOven2Zone3, oventemp_lo, oventemp_hi)


                ''BLANK BEFORE FL
                PaintGauge("TempBlankFrontLHtAntes", LblTempBlankbeforeFL, NeedleTempBlankbeforeFL, BackTempBlankbeforeFL, blanctempbefore_lo, blanctempbefore_hi)
                ''BLANK BEFORE FR
                PaintGauge("TempBlankFrontRHtAntes", LblTempBlankbeforeFR, NeedleTempBlankbeforeFR, BackTempBlankbeforeFR, blanctempbefore_lo, blanctempbefore_hi)
                ''BLANK BEFOR RL
                PaintGauge("TempBlankRearLHtAntes", LblTempBlankbeforeRL, NeedleTempBlankbeforeRL, BackTempBlankbeforeRL, blanctempbefore_lo, blanctempbefore_hi)
                ''BLANK BEFOR Rr    
                PaintGauge("TempBlankRearRHtAntes", LblTempBlankbeforeRR, NeedleTempBlankbeforeRR, BackTempBlankbeforeRR, blanctempbefore_lo, blanctempbefore_hi)


                ''BLANK AFTER FL
                PaintGauge("TempBlankFrontLHDespues", LblTempBlankAfterFL, NeedleTempBlankAfterFL, BackTempBlankAfterFL, blanctempafter_lo, blanctempafter_hi)
                ''BLANK AFTER FR
                PaintGauge("TempBlankFrontRHDespues", LblTempBlankAfterFR, NeedleTempBlankAfterFR, BackTempBlankAfterFR, blanctempafter_lo, blanctempafter_hi)
                ''BLANK AFTER RL
                PaintGauge("TempBlankRearLHDespues", LblTempBlankAfterRL, NeedleTempBlankAfterRL, BackTempBlankAfterRL, blanctempafter_lo, blanctempafter_hi)
                ''BLANK AFTER Rr    
                PaintGauge("TempBlankRearRHDespues", LblTempBlankAfterRR, NeedleTempBlankAfterRR, BackTempBlankAfterRR, blanctempafter_lo, blanctempafter_hi)
            Catch ex As Exception
                Me.BackColor = Color.Gainsboro
            End Try
        Catch ex As Exception
            Me.BackColor = Color.Red
        End Try

        

    End Sub

    Sub PaintGauge(ByVal Campo As String, ByRef Lbl As Telerik.WinControls.UI.Gauges.RadialGaugeSingleLabel, _
                   ByRef Needle As Telerik.WinControls.UI.Gauges.RadialGaugeNeedle, _
                   ByRef Back As Telerik.WinControls.UI.Gauges.RadialGaugeBackground, _
                   ByVal lo As Integer, ByVal hi As Integer)


        Lbl.LabelText = ds.Tables("HSPR01").DefaultView.Item(0).Item(Campo).ToString
        Needle.Value = ds.Tables("HSPR01").DefaultView.Item(0).Item(Campo)
        If Needle.Value < lo Or Needle.Value > hi Then
            Back.BackColor2 = Color.Red
        Else
            Back.BackColor2 = Color.Lime
        End If

    End Sub
End Class