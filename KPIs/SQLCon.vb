Imports System.Data.SqlClient

Public Class SQLCon
    Public Shared Cn As New SqlClient.SqlConnection("")
    Public Shared CnMARS As New SqlClient.SqlConnection("")
    Public Shared CnMPS As New SqlClient.SqlConnection("")

    Public Shared da As New SqlClient.SqlDataAdapter("", Cn)
    Public Shared damars As New SqlClient.SqlDataAdapter("", CnMARS)

    Public Shared cmd As New SqlClient.SqlCommand("", Cn)
    Public Shared cmdMARS As New SqlClient.SqlCommand("", Cn)

    Public Shared ds As New DataSet
#Region "ConnectionStrings"
    Shared Function constring() As String
        Return "Data Source=" & My.Settings.Server & ";Initial Catalog=" & My.Settings.BD & ";User Id=" & My.Settings.Usuario & ";Password=" & My.Settings.contraseña & ";"
    End Function
#End Region

#Region "Connections"
    Shared Function Conexion() As SqlClient.SqlConnection
        Cn.ConnectionString = constring()
        Return Cn
    End Function
#End Region

#Region "Catalogs"
    Shared Function GetPlants() As DataTable
        Try
            'comment
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select * from kpi.plants "
            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "Plants")
            Return ds.Tables("Plants")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function
    Shared Function GetPlantKPIS(ByVal plant As String) As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select Id,Name,Description,Target,Formula,Plant from kpi.kpi where plant = " & plant
            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "PlantKPIS")
            Return ds.Tables("PlantKPIS")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function
    Shared Function GetPlantKPISValues(ByVal kpid As String) As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "SELECT kpi.Name, kpiv.[Id],kpiv.[KPI],kpiv.[Target],kpiv.[Value],case kpiv.period " & _
            "when 'Yearly' then 'Y-' + cast(Year([Date]) as char(4)) " & _
            "when 'Monthly' then case Month([Date]) when 1 then 'Jan' when 2 then 'Feb' when 3 then 'Mar' when 4 then 'Apr' when 5 then 'May' when 6 then 'Jun' when 7 then 'Jul' when 8 then 'Aug' when 9 then 'Sep' when 10 then 'Oct' when 11 then 'Nov' when 12 then 'Dec' End " & _
            "when 'Weekly' then 'W' + DATENAME(week,[Date]) " & _
            "when 'Daily' then '4' " & _
            "else '5' End as PeriodName " & _
            ",kpiv.Period " & _
            ",case kpiv.period  " & _
            "when 'Yearly' then 1 " & _
            "when 'Monthly' then 2 " & _
            "when 'Weekly' then 3 " & _
            "when 'Daily' then 4 " & _
            " else 5 End as PeriodOrder " & _
            ",kpiv.[Date] " & _
            "FROM [kpi].[KpiValues] KpiV " & _
            "inner join kpi.kpi kpi on kpiv.KPI = kpi.id " & _
            "where kpi.Id = " & kpid & _
            "order by [Date],PeriodOrder "

            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "PlantKPISValues")
            Return ds.Tables("PlantKPISValues")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function
#End Region

#Region "INSERT UPDATE DELETE"
    Shared Function UpdateKPI(ByVal Id As String, ByVal Name As String, ByVal Description As String, ByVal Target As String, ByVal Formula As String) As Boolean
        Cn.ConnectionString = constring()
        If Cn.State = ConnectionState.Closed Then Cn.Open()
        Dim tra As SqlClient.SqlTransaction
        tra = Cn.BeginTransaction
        Try
            Dim cmd As New SqlClient.SqlCommand("", Cn, tra)

            cmd.CommandText = "Update kpi.Kpi set Name=@Name,Description=@Description,Target = @Target,Formula=@Formula where ID = @ID"
            cmd.Parameters.AddWithValue("@ID", Id)
            cmd.Parameters.AddWithValue("@Name", Name)
            cmd.Parameters.AddWithValue("@Description", Description)
            cmd.Parameters.AddWithValue("@Target", Target)
            cmd.Parameters.AddWithValue("@Formula", Formula)
            cmd.ExecuteNonQuery()
            tra.Commit()            
            Return True
        Catch ex As Exception
            tra.Rollback()
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function UpdateKPIValue(ByVal Id As String, ByVal Value As String, ByVal target As String) As Boolean
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            Dim cmd As New SqlClient.SqlCommand("", Cn)

            cmd.CommandText = "Update kpi.KpiValues set Target=@target,Value=@Value where ID = @ID"
            cmd.Parameters.AddWithValue("@target", target)
            cmd.Parameters.AddWithValue("@value", Value)
            cmd.Parameters.AddWithValue("@ID", Id)

            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function DeleteKPIValue(ByVal kpiid As String) As Boolean
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            Dim cmd As New SqlClient.SqlCommand("", Cn)
            cmd.CommandText = "Delete from kpi.KpiValues where ID = " & kpiid
            cmd.ExecuteScalar()
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function
    Shared Function InsertKPIValue(ByVal kpiid As String, ByVal period As String, ByVal periodvalue As String, ByVal Target As String, ByVal Value As String) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            Dim cmd As New SqlClient.SqlCommand("", Cn)
            Dim datetoinsert As String = ""
            Select Case period
                Case "Yearly"
                    datetoinsert = "01/01/" + periodvalue
                Case "Monthly"
                    Select Case periodvalue
                        Case "Jan"
                            datetoinsert = "01/01/" & Now.Date.Year.ToString
                        Case "Feb"
                            datetoinsert = "02/01/" & Now.Date.Year.ToString
                        Case "Mar"
                            datetoinsert = "03/01/" & Now.Date.Year.ToString
                        Case "Apr"
                            datetoinsert = "04/01/" & Now.Date.Year.ToString
                        Case "May"
                            datetoinsert = "05/01/" & Now.Date.Year.ToString
                        Case "Jun"
                            datetoinsert = "06/01/" & Now.Date.Year.ToString
                        Case "Jul"
                            datetoinsert = "07/01/" & Now.Date.Year.ToString
                        Case "Aug"
                            datetoinsert = "08/01/" & Now.Date.Year.ToString
                        Case "Sep"
                            datetoinsert = "09/01/" & Now.Date.Year.ToString
                        Case "Oct"
                            datetoinsert = "10/01/" & Now.Date.Year.ToString
                        Case "Nov"
                            datetoinsert = "11/01/" & Now.Date.Year.ToString
                        Case "Dec"
                            datetoinsert = "12/01/" & Now.Date.Year.ToString
                    End Select
            End Select
            If datetoinsert = "" Then Throw New Exception("Invalid Date Range ")

            cmd.CommandText = "Select count(*) from kpi.KpiValues where KPI = " & kpiid & " and Period = '" & period & "'  and Date = '" & datetoinsert & "'"
            Dim duplicados As String
            duplicados = cmd.ExecuteScalar

            If duplicados > 0 Then
                Return duplicados
            Else
                cmd.CommandText = "Insert into kpi.KpiValues(KPI,Target,Value,Period,Date) values (" & kpiid & "," & Target & "," & Value & ",'" & period & "','" & datetoinsert & "')"
                cmd.ExecuteNonQuery()
                Return 0
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function


#End Region

End Class
