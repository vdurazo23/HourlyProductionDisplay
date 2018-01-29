Imports System.Xml
Public Class Translations

    Private Sub Translations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim xlread As XmlTextReader
        Try

            If IO.File.Exists(Application.StartupPath & "\Language.xml") Then
                xlread = New XmlTextReader(Application.StartupPath & "\Language.xml")
                While xlread.Read()
                    xlread.MoveToElement()
                    If xlread.Name = "Resource" Then TxtResource.Text = xlread.ReadString
                    If xlread.Name = "Part" Then TxtPart.Text = xlread.ReadString
                    If xlread.Name = "Average" Then TxtAverage.Text = xlread.ReadString
                    If xlread.Name = "CurrentHourlytarget" Then TxtHourlyTarget.Text = xlread.ReadString
                    If xlread.Name = "Shiftcurrenttarget" Then TxtShiftTarget.Text = xlread.ReadString
                    If xlread.Name = "Shiftcurrentactual" Then TxtShiftActual.Text = xlread.ReadString
                    If xlread.Name = "Delta" Then TxtDelta.Text = xlread.ReadString
                    If xlread.Name = "Totarget" Then TxtToTarget.Text = xlread.ReadString
                    If xlread.Name = "PCS_HR" Then TxtPcsHr.Text = xlread.ReadString
                    If xlread.Name = "Bluetext" Then TxtBluetext.Text = xlread.ReadString


                    'writer.WriteElementString("Part", TxtPart.Text)
                    'writer.WriteElementString("Average", TxtAverage.Text)
                    'writer.WriteElementString("CurrentHourlytarget", TxtHourlyTarget.Text)
                    'writer.WriteElementString("Shiftcurrenttarget", TxtShiftTarget.Text)
                    'writer.WriteElementString("Shiftcurrentactual", TxtShiftActual.Text)
                    'writer.WriteElementString("Delta", TxtDelta.Text)
                    'writer.WriteElementString("Totarget", TxtToTarget.Text)
                    'writer.WriteElementString("PCS_HR", TxtPcsHr.Text)
                    'writer.WriteElementString("Bluetext", TxtBluetext.Text)

                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Try
                xlread.Close()
            Catch ex As Exception
            End Try
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim writer As XmlWriter
        Try

            writer = XmlWriter.Create(Application.StartupPath & "\Language.xml")
            writer.WriteStartDocument()

            writer.WriteStartElement("Settings")

            writer.WriteElementString("Resource", TxtResource.Text)
            writer.WriteElementString("Part", TxtPart.Text)
            writer.WriteElementString("Average", TxtAverage.Text)
            writer.WriteElementString("CurrentHourlytarget", TxtHourlyTarget.Text)
            writer.WriteElementString("Shiftcurrenttarget", TxtShiftTarget.Text)
            writer.WriteElementString("Shiftcurrentactual", TxtShiftActual.Text)
            writer.WriteElementString("Delta", TxtDelta.Text)
            writer.WriteElementString("Totarget", TxtToTarget.Text)
            writer.WriteElementString("PCS_HR", TxtPcsHr.Text)
            writer.WriteElementString("Bluetext", TxtBluetext.Text)
            writer.WriteEndElement()

            writer.WriteEndDocument()

            writer.Flush()
            writer.Close()

            Me.DialogResult = Windows.Forms.DialogResult.OK


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            Try
                writer.Flush()
                writer.Close()
            Catch ex As Exception
            End Try
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class