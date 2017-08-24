Public Class PrintSample

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        e.Graphics.FillRectangle(Brushes.Gainsboro, 180, 160, 600, 50)
        e.Graphics.DrawRectangle(Pens.Black, 180, 160, 600, 50)
        e.Graphics.DrawString(Label1.Text, Label1.Font, Brushes.Black, 200, 160)
        e.Graphics.DrawImage(PictureBox1.Image, 200, 300, 600, 400)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintSample_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DirectCast(PrintPreviewDialog1, Form).WindowState = FormWindowState.Maximized
        PrintDocument1.DefaultPageSettings.Landscape = True
    End Sub

End Class