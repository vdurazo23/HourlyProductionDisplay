﻿Public Class SelPant
    Public Seleccion As Integer = 0
    Private Sub SelPant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckBox1.Checked = My.Settings.RememberScreen
        cargarscreens()        
    End Sub
    Dim x, y As Integer
    Sub cargarscreens()
        Try
            x = 0
            y = 0
            Panel1.Visible = True
            Dim cuentacontroles As Integer = 0
            Dim howmuch As Integer
            Dim disponible As Integer = (ClientSize.Width)
            howmuch = Math.Floor((ClientSize.Width) / (215))
            Dim i As Integer
            Panel1.Controls.Clear()
            Panel1.Location = New Point(0, 0)
            Panel1.Size = New Size(0, 0)
            For i = 0 To Screen.AllScreens.Count - 1
                Dim ctrl As New Button
                ctrl.Font = Button1.Font
                ctrl.Size = New Point(215, 130)
                ctrl.Location = New Point(x, y)
                ctrl.UseVisualStyleBackColor = False
                ctrl.Text = i.ToString '& vbCrLf & Screen.AllScreens(i).DeviceName
                ctrl.Tag = i
                ctrl.Font = Button1.Font
                ctrl.ForeColor = Button1.ForeColor
                ctrl.Image = Button1.Image

                AddHandler ctrl.Click, AddressOf ButtonClick_Screen


                Panel1.Controls.Add(ctrl)
                cuentacontroles += 1
                centerpan(Panel1)
                x = x + ctrl.Width
                If cuentacontroles = howmuch Then
                    y = y + ctrl.Height
                    x = 0
                    cuentacontroles = 0
                End If
                ctrl = Nothing

            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonClick_Screen(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Seleccion = sender.tag
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Sub centerpan(ByRef ELPANEL As Object)
        Try

            Dim anchopant As Integer = My.Computer.Screen.WorkingArea.Width
            Dim altopant As Integer = My.Computer.Screen.WorkingArea.Height

            'Dim panloc As New Point(anchopant - (Panel1.Width / 2), altopant - (Panel1.Height / 2))
            ELPANEL.Location = New Point((ClientSize.Width - ELPANEL.Width) / 2, (ClientSize.Height - ELPANEL.Height) / 2)
            If ELPANEL.Location.X < 0 Or ELPANEL.Location.Y < 24 Then
                ELPANEL.Location = New Point((ClientSize.Width - ELPANEL.Width) \ 2, 26)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For i = 0 To Screen.AllScreens.Count - 1
            Dim SId As New ScreenIdent
            SId.StartPosition = FormStartPosition.Manual
            SId.Location = Screen.AllScreens(i).Bounds.Location
            SId.Label1.Text = i.ToString
            SId.Show()
        Next
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        My.Settings.RememberScreen = CheckBox1.Checked
        My.Settings.Save()
    End Sub

End Class