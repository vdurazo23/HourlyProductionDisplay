Imports OpenHardwareMonitor
Imports OpenHardwareMonitor.Hardware

Public Class Form1   
    Dim comp As New Computer()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comp.Open()
        comp.GPUEnabled = True
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick               
        Dim gpu = comp.Hardware.Where(Function(h) h.HardwareType = HardwareType.GpuAti).FirstOrDefault
        Dim gpu2 = comp.Hardware.Where(Function(h) h.HardwareType = HardwareType.GpuNvidia).FirstOrDefault
        If Not gpu Is Nothing Then
            gpu.Update()
            Label1.Text = gpu.Sensors(1).Value
        End If
        If Not gpu2 Is Nothing Then
            gpu2.Update()
            Label2.Text = gpu2.Sensors(1).Value
        End If
    End Sub
End Class
