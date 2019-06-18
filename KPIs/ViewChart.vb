Public Class ViewChart
    Dim dtkpivalues As DataTable
    Private Sub ViewChart_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub ViewChart_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub ViewChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub loaddata()
        Try
            'GridDatos.DataSource = kpivalues.DefaultView
            dtkpivalues = Me.Grafica1.tabla
            GridDatos.Columns.Clear()
            GridDatos.Columns.Add("ID", "ID")
            GridDatos.Columns.Add("Indicator", "")
            GridDatos.Rows.Add("", "Value")
            GridDatos.Rows.Add("", "Target")
            GridDatos.Columns(0).ReadOnly = True
            GridDatos.Columns(0).Visible = False
            GridDatos.Columns(1).ReadOnly = True
            For i = 0 To dtkpivalues.DefaultView.Count - 1
                GridDatos.Columns.Add(i.ToString, dtkpivalues.DefaultView.Item(i).Item("PeriodName"))
                GridDatos.Rows(0).Cells(0).Value = dtkpivalues.DefaultView.Item(i).Item("ID")
                GridDatos.Rows(1).Cells(0).Value = dtkpivalues.DefaultView.Item(i).Item("ID")
                GridDatos.Columns(GridDatos.Columns.Count - 1).Tag = dtkpivalues.DefaultView.Item(i).Item("ID")
                GridDatos.Rows(0).Cells(i + 2).Value = dtkpivalues.DefaultView.Item(i).Item("Value").ToString
                GridDatos.Rows(1).Cells(i + 2).Value = dtkpivalues.DefaultView.Item(i).Item("Target").ToString
            Next
            For Each c As DataGridViewColumn In GridDatos.Columns
                c.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error load data")
        End Try
    End Sub

    Private Sub PicClose_Click(sender As Object, e As EventArgs) Handles PicClose.Click
        Me.Close()

    End Sub
End Class