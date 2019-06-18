Imports System.Data.SqlClient
Imports Transitions
Public Class Presentacion

    Dim midataset As New DataSet
    Dim adapter As SqlDataAdapter
    Dim controles As New List(Of Grafica)
    Dim posicion As Integer = 0
    Dim panel_actual = 0
    Dim ani As Boolean = False
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Location = New Point(0, 0)
        Panel1.Size = Me.Bounds.Size
        Panel2.Location = New Point(0, 0)
        Panel2.Size = Me.Bounds.Size
        Panel2.Left = Me.Bounds.Size.Width
        CargarDatos()
        CrearControles()
        If midataset.Tables("Ubicaciones").Rows.Count > 1 Then
            CargarPanel1()
            Panel1.BringToFront()
            panel_actual = 1
            Timer1.Interval = 14000
            Timer1.Enabled = False
            Timer1.Start()
            ani = True
        Else
            CargarPanel1()
            Panel1.BringToFront()
            Panel2.BringToFront()
            Panel1.BringToFront()
            panel_actual = 1
        End If

    End Sub
    Sub CargarDatos()
        Dim sqlcon = ("data source=10.251.10.21; initial catalog=MARS; user id=sa; password=martinrea;Connection Timeout=10")
        Using cn As SqlConnection = New SqlConnection(sqlcon)

            adapter = New SqlDataAdapter("select distinct p.ID, p.Plant from kpi.Plants p inner join (select distinct l.PLant from kpi.Kpi l inner join kpi.KpiValues kv on l.id = kv.KPI) k on p.ID = k.Plant", cn)
            adapter.Fill(midataset, "Ubicaciones")

            adapter = New SqlDataAdapter("SELECT kpi.Name, kpiv.[Id],kpiv.[KPI],kpiv.[Target],kpiv.[Value]" &
      " ,case kpiv.period" &
       " when 'Yearly' then 'Y-' + cast(Year([Date]) as char(4))" &
       " when 'Monthly' then case Month([Date]) when 1 then 'Jan' when 2 then 'Feb' when 3 then 'Mar' when 4 then 'Apr' when 5 then 'May' when 6 then 'Jun' when 7 then 'Jul' when 8 then 'Aug' when 9 then 'Sep' when 10 then 'Oct' when 11 then 'Nov' when 12 then 'Dec' End" &
       " when 'Weekly' then 'W' + DATENAME(week,[Date])" &
       " when 'Daily' then '4'" &
       " else '5' End as PeriodName" &
      " ,kpiv.Period" &
      " ,case kpiv.period" &
       " when 'Yearly' then 1" &
       " when 'Monthly' then 2" &
       " when 'Weekly' then 3" &
      " when 'Daily' then 4" &
      " else 5 End as PeriodOrder" &
       " ,kpiv.[Date]" &
       " , P.Id as Plant_id, P.Plant,kpi.Formula,kpi.Description" &
  " FROM [kpi].[KpiValues] KpiV" &
  " inner join kpi.kpi kpi on kpiv.KPI = kpi.id " &
  " INNER JOIN KPI.Plants P ON KPI.Plant = P.ID " &
  " order by kpi.id,[Date],PeriodOrder", cn)
            adapter.Fill(midataset, "Datos")

        End Using
    End Sub
    Sub CrearControles()

        For Each ropl As DataRow In midataset.Tables("Ubicaciones").Rows
            midataset.Tables("DAtos").DefaultView.RowFilter = "Plant_id = " & ropl(0)
            Dim KPI_dt As DataTable = midataset.Tables("Datos").DefaultView.ToTable(True, "Name", "KPI", "Formula", "Description")
            For Each ro_kpi As DataRow In KPI_dt.Rows
                midataset.Tables("Datos").DefaultView.RowFilter = " Plant_id = " & ropl(0) & " and KPI = " & ro_kpi(1)
                Dim gra As New Grafica
                gra.KpiName = ro_kpi(0).ToString
                gra.Mediblename = ro_kpi(3).ToString
                gra.tipo = ro_kpi("Formula").ToString
                gra.Tag = ropl(0).ToString
                gra.boundslocation = Me.Bounds.Location
                gra.tabla = midataset.Tables("Datos").DefaultView.ToTable
                AddHandler gra.showchartbig, AddressOf showChartinbig
                AddHandler gra.closedchartbig, AddressOf closedchartbig
                controles.Add(gra)
            Next
            midataset.Tables("Datos").DefaultView.RowFilter = ""
        Next
    End Sub
    Dim wastimerenabled As Boolean
    Sub showChartinbig()
        If Timer1.Enabled Then
            wastimerenabled = True
            Timer1.Enabled = False
        End If
    End Sub

    Sub closedchartbig()
        If wastimerenabled Then Timer1.Enabled = True
    End Sub

    Sub CargarPanel1()
        TableLayoutPanel1.Controls.Clear()
        TableLayoutPanel1.Refresh()
        Label1.Text = midataset.Tables("Ubicaciones").Rows(posicion).Item(1).ToString
        Dim ctrl = controles.FindAll(Function(c) c.Tag = midataset.Tables("Ubicaciones").Rows(posicion).Item(0))
        For Each gr As Grafica In ctrl
            TableLayoutPanel1.Controls.Add(gr)
        Next
        If posicion = midataset.Tables("Ubicaciones").Rows.Count - 1 Then
            posicion = 0
        Else
            posicion = posicion + 1
        End If
    End Sub
    Sub CargarPanel2()
        TableLayoutPanel2.Controls.Clear()
        TableLayoutPanel2.Refresh()
        Label2.Text = midataset.Tables("Ubicaciones").Rows(posicion).Item(1).ToString
        Dim ctrl = controles.FindAll(Function(c) c.Tag = midataset.Tables("Ubicaciones").Rows(posicion).Item(0))
        For Each gr As Grafica In ctrl
            TableLayoutPanel2.Controls.Add(gr)
        Next
        If posicion = midataset.Tables("ubicaciones").Rows.Count - 1 Then
            posicion = 0
        Else
            posicion = posicion + 1
        End If
    End Sub

    Dim WithEvents t As New Transition(New TransitionType_EaseInEaseOut(1000))
    Dim WithEvents t2 As New Transition(New TransitionType_EaseInEaseOut(1000))
    Dim animando As Boolean = False

    Sub animar(Optional ByVal reverse As Boolean = False)
        animando = True
        If panel_actual = 1 Then
            CargarPanel2()
            'Salir panel uno, entrar panel dos
            Panel2.Location = New Point(IIf(reverse, -Panel2.Width, Panel2.Width), 0)
            t = New Transition(New TransitionType_EaseInEaseOut(1000))
            t.add(Panel1, "Left", IIf(reverse, Panel1.Width, -Panel1.Width))
            t.run()
            t2 = New Transition(New TransitionType_EaseInEaseOut(1000))
            t2.add(Panel2, "Left", 0)
            t2.run()
            panel_actual = 2

        Else
            CargarPanel1()
            Panel1.Location = New Point(IIf(reverse, -Panel1.Width, Panel1.Width), 0)
            t = New Transition(New TransitionType_EaseInEaseOut(1000))
            t.add(Panel2, "Left", IIf(reverse, Panel1.Width, -Panel1.Width))
            t.run()
            t2 = New Transition(New TransitionType_EaseInEaseOut(1000))
            t2.add(Panel1, "Left", 0)
            t2.run()
            panel_actual = 1

        End If

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        animar()
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Escape Then
            Me.DialogResult = DialogResult.Abort
            Me.Close()
        End If
        If ani = False Then Exit Function
        If keyData = Keys.P Or keyData = Keys.Pause Then
            Console.WriteLine("")
            If Timer1.Enabled = True Then
                Timer1.Enabled = False
                PictureBox1.Visible = True
                PictureBox1.BringToFront()
            Else

                Timer1.Enabled = True
                PictureBox1.Visible = False
            End If
        End If
        If keyData = Keys.Left Then
            If animando Then Exit Function
            If ani = False Then Exit Function
            If PictureBox1.Visible = True Then
                animar(True)
            Else
                Timer1.Stop()
                animar(True)
                Timer1.Start()
            End If


        End If
        If keyData = Keys.Right Then
            If animando Then Exit Function
            If ani = False Then Exit Function
            If PictureBox1.Visible = True Then
                animar()
            Else
                Timer1.Stop()
                animar()
                Timer1.Start()
            End If


        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub t_TransitionCompletedEvent(sender As Object, e As Transition.Args) Handles t.TransitionCompletedEvent
        animando = False
    End Sub

    Private Sub t2_TransitionCompletedEvent(sender As Object, e As Transition.Args) Handles t2.TransitionCompletedEvent
        animando = False
    End Sub
End Class
