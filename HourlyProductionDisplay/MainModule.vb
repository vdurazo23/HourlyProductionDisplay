Imports System.Globalization

Module MainModule
    Public Sub main()
        Try

            ' If My.Settings.UPGRADEREQUIRED Then
            My.MySettings.Default.Upgrade()
            My.MySettings.Default.UPGRADEREQUIRED = False
            My.MySettings.Default.Save()
            'End If

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
                    showspl(panttoshow)

                    Dim Fr As New FormDisplay
                    Fr.Location = Screen.AllScreens(panttoshow).Bounds.Location
                    Fr.WindowState = FormWindowState.Maximized
                    Fr.StartPosition = FormStartPosition.Manual
                    Application.Run(Fr)
                Else
                    Application.Exit()
                End If
            Else
                showspl()
                Dim Fr As New FormDisplay
                Fr.WindowState = FormWindowState.Maximized
                Application.Run(Fr)
            End If
        Catch ex As Exception
            MsgBox("Initializing Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Sub showspl(Optional ByVal panttoshow As Integer = 0)
        Dim spl As New SplashScreen1

        Dim centerscr As New Point(0, 0)
        centerscr.X = Screen.AllScreens(panttoshow).Bounds.Location.X + (Screen.AllScreens(panttoshow).Bounds.Size.Width / 2 - (spl.Size.Width / 2))
        centerscr.Y = Screen.AllScreens(panttoshow).Bounds.Location.Y + (Screen.AllScreens(panttoshow).Bounds.Size.Height / 2 - (spl.Size.Height / 2))


        spl.Location = centerscr
        spl.StartPosition = FormStartPosition.Manual
        spl.ShowDialog()
    End Sub
    Function GetCommandLineArgs() As String()
        ' Declare variables.
        Dim separators As String = " "
        Dim commands As String = Microsoft.VisualBasic.Command()
        Dim args() As String = commands.Split(separators.ToCharArray)
        Return args
    End Function

End Module
