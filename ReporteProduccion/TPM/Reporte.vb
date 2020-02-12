Imports Microsoft.Reporting.WinForms

Public Class Reporte
    Public path As String
    Public parametro As List(Of ReportParameter)

    Private Sub Reporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ReportViewer1.ShowParameterPrompts = False
            '   Dim id = New ReportParameter("id", 33)
            '   Dim HeaderParams As ReportParameter() = {id}
            ReportViewer1.ProcessingMode = ProcessingMode.Remote
            ReportViewer1.ServerReport.ReportServerUrl = New Uri("http://mars/ReportServer_SQLMARS")
            ReportViewer1.ServerReport.ReportPath = path '' "/TPM/TPM_Especifico"    /TPM/TPM_Mensual_Reporte_General
            For Each p As ReportParameter In parametro
                ReportViewer1.ServerReport.SetParameters(p)
            Next
            Me.ReportViewer1.RefreshReport()
            ReportViewer1.ShowParameterPrompts = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

End Class