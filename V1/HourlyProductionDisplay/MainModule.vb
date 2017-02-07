Imports System.Globalization

Module MainModule
    Public Sub main()
        Try
            Dim SPECIFICPANT As Integer = -1

            Dim str() As String
            str = GetCommandLineArgs()
            If (UBound(str) >= 0) Then
                If str(0) = "c" Or str(0) = "C" Or My.Settings.MARSServer = "" Then
                    Dim conf As New Config
                    conf.ShowDialog()
                    conf.Dispose()
                    conf = Nothing
                End If

                If IsNumeric(str(0)) Then
                    ''HAY QUE MOSTRARLO EN UNA PANTALLA EN ESPECÍFICO
                    SPECIFICPANT = str(0)
                End If

            End If

            If Screen.AllScreens.Count > 1 Then

                Dim panttoshow As Integer

                If SPECIFICPANT >= 0 Then
                    panttoshow = SPECIFICPANT
                    GoTo startshowingfromparameter
                End If

                Dim sp As New SelPant
                If sp.ShowDialog = DialogResult.OK Then
                    panttoshow = sp.Seleccion

startshowingfromparameter:

                    Dim Fr As New FormDisplay
                    Fr.Location = Screen.AllScreens(panttoshow).Bounds.Location
                    Fr.WindowState = FormWindowState.Maximized
                    Fr.StartPosition = FormStartPosition.Manual
                    Application.Run(Fr)
                Else
                    Application.Exit()
                End If
            Else
                Dim Fr As New FormDisplay
                Fr.WindowState = FormWindowState.Maximized
                Application.Run(Fr)
            End If
        Catch ex As Exception
            MsgBox("Initializing Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Function GetCommandLineArgs() As String()
        ' Declare variables.
        Dim separators As String = " "
        Dim commands As String = Microsoft.VisualBasic.Command()
        Dim args() As String = commands.Split(separators.ToCharArray)
        Return args
    End Function
End Module
