Public Class Main
    Dim ppt As New Presentacion

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadplants()

        If My.Settings.ShowStartup Then
            If Screen.AllScreens.Count > 1 Then
                Me.Hide()
                If My.Settings.RememberScreen And My.Settings.ScreenNumber <= Screen.AllScreens.Count - 1 Then
                    startpresentation(My.Settings.ScreenNumber)
                Else
                    Dim panttoshow As Integer
                    Dim sp As New SelPant
                    If sp.ShowDialog = DialogResult.OK Then
                        panttoshow = sp.Seleccion
                        If My.Settings.RememberScreen Then
                            My.Settings.ScreenNumber = panttoshow
                            My.Settings.Save()
                        End If
                        startpresentation(panttoshow)
                    Else
                        Me.Show()
                        Exit Sub
                    End If
                End If
            Else
                startpresentation(0)
            End If
        End If
    End Sub

    Private Sub RadPageKPIS_Paint(sender As Object, e As PaintEventArgs) Handles RadPageKPIS.Paint

    End Sub

    Sub loadplants()
        Try
            Dim dt As DataTable
            dt = SQLCon.GetPlants
            CboPlant.DataSource = dt.DefaultView
            CboPlant.ValueMember = "ID"
            CboPlant.DisplayMember = "Plant"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CboPlant_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPlant.SelectedIndexChanged       
        Try
            If CboPlant.ValueMember = "" Then Exit Sub
            If CboPlant.SelectedValue Is Nothing Then Exit Sub
            If CboPlant.SelectedValue <= 0 Then Exit Sub
            Dim dtkpis As DataTable
            dtkpis = SQLCon.GetPlantKPIS(CboPlant.SelectedValue.ToString)
            GridKPIS.DataSource = dtkpis.DefaultView
            GridKPIS.Columns("ID").Visible = False
            GridKPIS.Columns("Plant").Visible = False

            For Each col As DataGridViewColumn In GridKPIS.Columns
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            GridKPIS.ColumnHeadersDefaultCellStyle = GridKPIS.DefaultCellStyle
            'Dim btn1 As New DataGridViewComboBoxColumn()
            'btn1.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox

            'btn1.HeaderText = "Formula"
            'btn1.Name = "Formula2"

            ''btn1.Items.Add(">=")
            ''btn1.Items.Add("<=")
            ''btn1.Items.Add("=")
            ''btn1.Items.Add(">")
            ''btn1.Items.Add("<")

            'GridKPIS.Columns.Add(btn1)
            'For Each row As DataGridViewRow In GridKPIS.Rows
            '    row.Cells("Formula2").Value = row.Cells("Formula").Value
            'Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub GridKPIS_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridKPIS.CurrentCellChanged
        Try
            If GridKPIS.CurrentRow Is Nothing Then
                Console.Write("not")
                GridDatos.Columns.Clear()
                GridDatos.Rows.Clear()
                GroupAddData.Visible = False
                Exit Sub

            End If
            GroupAddData.Visible = True
            Dim kpiid As String = GridKPIS.Rows(GridKPIS.CurrentRow.Index).Cells(0).Value.ToString
            If Not String.IsNullOrEmpty(kpiid) Then
                loadkpivalues(kpiid)
            End If
        Catch ex As Exception
            Console.Write(ex.Message)
        End Try
    End Sub

    Dim loadingkpivalues As Boolean
    Sub loadkpivalues(ByVal kpiid As String)
        Try
            loadingkpivalues = True
            Dim dtkpivalues As DataTable
            dtkpivalues = SQLCon.GetPlantKPISValues(kpiid)

            Grafica1.KpiName = GridKPIS.CurrentRow.Cells("Name").Value.ToString
            Grafica1.Mediblename = GridKPIS.CurrentRow.Cells("Description").Value.ToString
            Grafica1.tabla = Nothing
            Grafica1.tipo = GridKPIS.CurrentRow.Cells("Formula").Value.ToString
            Grafica1.tabla = dtkpivalues
            Grafica1.loadtestchart()
            Grafica1.max = 0
            Grafica1.maximo()



            'GridDatos.DataSource = kpivalues.DefaultView
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

            TxtTarget.Value = GridKPIS.Rows(GridKPIS.CurrentRow.Index).Cells("Target").Value


            For Each c As DataGridViewColumn In GridDatos.Columns
                c.SortMode = DataGridViewColumnSortMode.NotSortable
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            loadingkpivalues = False
        End Try
    End Sub

    Private Sub GridKPIS_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GridKPIS.RowEnter
       
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPeriod.SelectedIndexChanged
        Select Case CboPeriod.SelectedIndex
            Case 0
                ''Yearly
                CboPeriodText.Items.Clear()
                CboPeriodText.Items.Add(Now.Year.ToString)
                CboPeriodText.Items.Add(Now.Year - 1.ToString)
                CboPeriodText.Items.Add(Now.Year - 2.ToString)
                CboPeriodText.Items.Add(Now.Year - 3.ToString)
                CboPeriodText.Items.Add(Now.Year - 4.ToString)
                CboPeriodText.Items.Add(Now.Year - 5.ToString)
                CboPeriodText.Items.Add(Now.Year - 6.ToString)
                CboPeriodText.Items.Add(Now.Year - 7.ToString)
                CboPeriodText.Items.Add(Now.Year - 8.ToString)
                CboPeriodText.Items.Add(Now.Year - 9.ToString)
                CboPeriodText.SelectedIndex = 0
            Case 1
                ''Monthly
                CboPeriodText.Items.Clear()
                CboPeriodText.Items.Add("Jan")
                CboPeriodText.Items.Add("Feb")
                CboPeriodText.Items.Add("Mar")
                CboPeriodText.Items.Add("Apr")
                CboPeriodText.Items.Add("May")
                CboPeriodText.Items.Add("Jun")
                CboPeriodText.Items.Add("Jul")
                CboPeriodText.Items.Add("Aug")
                CboPeriodText.Items.Add("Sep")
                CboPeriodText.Items.Add("Oct")
                CboPeriodText.Items.Add("Nov")
                CboPeriodText.Items.Add("Dec")

                Dim currmont As Integer = Now.Month
                CboPeriodText.SelectedIndex = currmont - 1

            Case 2
                ''Weekly

        End Select
    End Sub

    Private Sub GridDatos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridDatos.CellContentClick
    End Sub

    Private Sub GridDatos_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles GridDatos.CellValidated
    End Sub

    Private Sub GridDatos_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GridDatos.CellValidating
        If loadingkpivalues Then Exit Sub
        If GridDatos.Rows(e.RowIndex).IsNewRow Then Exit Sub
        If GridDatos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString = "" Then Exit Sub
        If e.ColumnIndex = 1 Then Exit Sub
        GridDatos.Rows(e.RowIndex).ErrorText = ""
        If Not IsNumeric(e.FormattedValue) Then
            e.Cancel = True
            GridDatos.Rows(e.RowIndex).ErrorText = "the value must be a number"
        End If
    End Sub

    Private Sub GridDatos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles GridDatos.CellValueChanged
        If loadingkpivalues Then Exit Sub
        'Me.Text = "Update Kpi " & GridDatos.Rows(0).Cells(0).Value.ToString & "  Value" & GridDatos.Rows(0).Cells(e.ColumnIndex).Value.ToString & " Target:" & GridDatos.Rows(1).Cells(e.ColumnIndex).Value.ToString
        Try
            SQLCon.UpdateKPIValue(GridDatos.Columns(e.ColumnIndex).Tag.ToString, GridDatos.Rows(0).Cells(e.ColumnIndex).Value.ToString, GridDatos.Rows(1).Cells(e.ColumnIndex).Value.ToString)
            Dim kpiid As String = GridKPIS.Rows(GridKPIS.CurrentRow.Index).Cells(0).Value.ToString
            If Not String.IsNullOrEmpty(kpiid) Then
                loadkpivalues(kpiid)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub GridKPIS_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GridKPIS.CellValidating

    End Sub
    Private Sub GridKPIS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridKPIS.CellContentClick

    End Sub
    Private Sub GridKPIS_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles GridKPIS.CellValueChanged
        Try
            If GridKPIS.CurrentRow Is Nothing Then Exit Sub
            SQLCon.UpdateKPI(GridKPIS.Rows(GridKPIS.CurrentRow.Index).Cells("Id").Value.ToString, GridKPIS.Rows(GridKPIS.CurrentRow.Index).Cells("Name").Value.ToString, GridKPIS.Rows(GridKPIS.CurrentRow.Index).Cells("Description").Value.ToString, GridKPIS.Rows(GridKPIS.CurrentRow.Index).Cells("Target").Value.ToString, GridKPIS.Rows(GridKPIS.CurrentRow.Index).Cells("Formula").Value.ToString)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If SQLCon.InsertKPIValue(GridKPIS.CurrentRow.Cells(0).Value.ToString, CboPeriod.Text, CboPeriodText.Text, TxtTarget.Value.ToString, TxtValue.Value.ToString) > 0 Then
                MsgBox("Duplicated value entry", MsgBoxStyle.Critical, "Duplicated")
            Else
                loadkpivalues(GridKPIS.CurrentRow.Cells(0).Value.ToString)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'MsgBox(Screen.AllScreens.Count.ToString)
        If Screen.AllScreens.Count > 1 Then
            If My.Settings.RememberScreen And My.Settings.ScreenNumber <= Screen.AllScreens.Count - 1 Then
                startpresentation(My.Settings.ScreenNumber)
            Else
                Dim panttoshow As Integer
                Dim sp As New SelPant
                If sp.ShowDialog = DialogResult.OK Then
                    panttoshow = sp.Seleccion
                    If My.Settings.RememberScreen Then
                        My.Settings.ScreenNumber = panttoshow
                        My.Settings.Save()
                    End If
                    startpresentation(panttoshow)
                Else
                    Exit Sub
                End If
            End If
        Else
            startpresentation(0)
        End If
    End Sub

    Sub startpresentation(ByVal screenNo As Integer)
        ppt = New Presentacion
        ppt.Location = Screen.AllScreens(screenNo).Bounds.Location
        ppt.WindowState = FormWindowState.Maximized
        ppt.StartPosition = FormStartPosition.Manual
        Me.Hide()
        ppt.ShowDialog()
        ppt.Dispose()
        ppt = Nothing
        Me.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cfg As New Config
        cfg.ShowDialog()
        cfg.Dispose()
        cfg = Nothing
    End Sub

    Private Sub GridDatos_KeyUp(sender As Object, e As KeyEventArgs) Handles GridDatos.KeyUp
        If e.KeyCode = Keys.Delete Then
            If GridDatos.CurrentCell.ColumnIndex = 1 Then Exit Sub
            If MsgBox("Are yoy sure ?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "Delete KpiValue " & GridDatos.Columns(GridDatos.CurrentCell.ColumnIndex).HeaderText) = MsgBoxResult.Yes Then
                SQLCon.DeleteKPIValue(GridDatos.Columns(GridDatos.CurrentCell.ColumnIndex).Tag.ToString)
                Dim kpiid As String = GridKPIS.Rows(GridKPIS.CurrentRow.Index).Cells(0).Value.ToString
                If Not String.IsNullOrEmpty(kpiid) Then
                    loadkpivalues(kpiid)
                End If
            End If
        End If
    End Sub
    Dim Cbo As ComboBox
    Private Sub GridKPIS_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles GridKPIS.EditingControlShowing
        If GridKPIS.CurrentCell.ColumnIndex = 4 Then
            Cbo = TryCast(e.Control, ComboBox)

        End If
    End Sub

   
End Class
