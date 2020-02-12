Imports System.Data.SqlClient

Public Class SQLCon
    Public Shared Cn As New SqlClient.SqlConnection("")
    Public Shared CnMARS As New SqlClient.SqlConnection("")
    Public Shared CnMPS As New SqlClient.SqlConnection("")
    Public Shared CnCMS As New Odbc.OdbcConnection("")

    Public Shared da As New SqlClient.SqlDataAdapter("", Cn)
    Public Shared damars As New SqlClient.SqlDataAdapter("", CnMARS)
    Public Shared dacms As New Odbc.OdbcDataAdapter("", CnCMS)

    Public Shared cmd As New SqlClient.SqlCommand("", Cn)
    Public Shared cmdMARS As New SqlClient.SqlCommand("", Cn)
    Public Shared cmdCMS As New Odbc.OdbcCommand("", CnCMS)

    Public Shared ds As New DataSet
#Region "ConnectionStrings"

    Shared Function constring() As String
        Return "Data Source=" & My.Settings.Server & ";Initial Catalog=" & My.Settings.BD & ";User Id=" & My.Settings.usuario & ";Password=" & My.Settings.contraseña & ";"
    End Function

    Shared Function constringMARS() As String
        Return "Data Source=" & My.Settings.MARSServer & ";Initial Catalog=" & My.Settings.MARSBD & ";User Id=" & My.Settings.MARSUsuario & ";Password=" & My.Settings.MARSContraseña & ";"
    End Function

    Shared Function constringMPS() As String
        Return "Data Source=" & My.Settings.MPSServer.Trim & ";workstation id=;Persist Security Info=True;User ID=" & My.Settings.MPSUsuario & ";password=" & My.Settings.MPSContraseña & ";initial catalog=" & My.Settings.MPSBD
    End Function

    Shared Function constringCMS() As String
        Return "DSN=" & My.Settings.dsnCMS.Trim & ";UID=" & My.Settings.uidCMS.Trim & ";PWD=" & My.Settings.pwdCMS
    End Function
#End Region

#Region "Connections"
    Shared Function Conexion() As SqlClient.SqlConnection
        Cn.ConnectionString = constring()
        Return Cn
    End Function

    Shared Function ConexionMARS() As SqlClient.SqlConnection
        CnMARS.ConnectionString = constringMARS()
        Return CnMARS
    End Function

    Shared Function ConexionMPS() As SqlClient.SqlConnection
        CnMPS.ConnectionString = constringMPS()
        Return CnMPS
    End Function

    Shared Function ConexionCMS() As Odbc.OdbcConnection
        CnCMS.ConnectionString = constringCMS()
        Return CnCMS
    End Function

#End Region

    Shared Function Login(ByVal Username As String, ByVal Password As String) As String
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()

            Dim ds As New DataSet
            Dim da As New SqlClient.SqlDataAdapter("", CnMPS)
            da.SelectCommand.CommandText = "select Id,usuario,password,activo,CB_CODIGO from dbo.usuarios where usuario=@usuario"
            da.SelectCommand.Parameters.Add("@usuario", SqlDbType.VarChar)
            da.SelectCommand.Parameters("@usuario").Value = Username

            da.Fill(ds, "Usuario")
            If ds.Tables("Usuario").DefaultView.Count <= 0 Then
                Return "No se encuentra el usuario " & Username
            Else

                If String.IsNullOrEmpty(ds.Tables("Usuario").DefaultView.Item(0).Item("Activo")) Then
                    Return "El usuario está inactivo" & vbCrLf & "Consulte al Administrador del Sistema"

                Else
                    If ds.Tables("Usuario").DefaultView.Item(0).Item("Password") = Password Then
                        My.Settings.UserId = ds.Tables("Usuario").DefaultView.Item(0).Item("Id").ToString
                        My.Settings.UserName = ds.Tables("Usuario").DefaultView.Item(0).Item("usuario")
                        My.Settings.CB_CODIGO = ds.Tables("Usuario").DefaultView.Item(0).Item("CB_CODIGO")
                        My.Settings.Save()
                        Return "OK"
                    Else
                        Return "Contraseña incorrecta"
                    End If
                End If

            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function getPermiso(ByVal Usuario As Integer, ByVal Sistema As String, Optional ByVal Modulo As String = "", Optional ByVal Accion As String = "") As Boolean
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            Dim permiso = False
            Dim sql As String
            Dim reader As SqlDataReader

            sql = "Select * from Permisos where Usuario = " & Usuario & " and Sistema = '" & Sistema & "'"
            If Not Modulo = "" Then sql += " and Modulo = '" & Modulo & "' "
            If Not Accion = "" Then sql += " and Accion = '" & Accion & "' "

            cmd.Connection = CnMPS
            cmd.CommandText = sql
            reader = cmd.ExecuteReader

            If reader.HasRows Then permiso = True
            CnMPS.Close()

            Return permiso

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function GetLineaByID(ByVal elid As Integer) As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()

            da.SelectCommand.CommandText = "select * from dbo.Asset where id=" & elid.ToString
            da.SelectCommand.Connection = Cn

            ds.Tables.Clear()
            da.Fill(ds, "Lineas")

            Cn.Close()

            Return ds.Tables("Lineas")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function GetLineas() As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()

            da.SelectCommand.CommandText = "select * from dbo.Asset"
            da.SelectCommand.Connection = Cn

            ds.Tables.Clear()
            da.Fill(ds, "Lineas")

            Cn.Close()

            Return ds.Tables("Lineas")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try

    End Function

    Shared Function GetPartFeatures(ByVal AssetID As Integer) As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select * from PartFeatures where Asset_ID=" & AssetID.ToString & " ORDER BY Description"
            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "features")
            Cn.Close()
            Return ds.Tables("features")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function GetReworkConcepts() As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select * from ReworkConcepts order by description"
            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "ReworkConcepts")
            Cn.Close()
            Return ds.Tables("ReworkConcepts")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function GetReworkCodes() As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select * from ReworkCodes order by Description"
            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "ReworkCodes")
            Cn.Close()
            Return ds.Tables("ReworkCodes")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function



    Shared Function EditAsset(ByVal ID As Integer, ByVal UseTheoretical As Boolean)
        Try

            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "UPDATE [dbo].[Asset]  SET UseTheoretical = @Theoretical where id=@ID"
            cmd.Connection = Cn
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@ID", SqlDbType.Int)
            cmd.Parameters.Add("@Theoretical", SqlDbType.Bit)
            
            cmd.Parameters("@ID").Value = ID
            cmd.Parameters("@Theoretical").Value = UseTheoretical
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function NewAsset(ByVal ID As Integer, ByVal Name As String, ByVal description As String, ByVal code As String, ByVal devicecode As String, ByVal departmentcode As String, ByVal resourcecode As String, ByVal subresourceid As String) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "INSERT INTO [dbo].[Asset] ([ID],[Name],[Description],[Code],[DeviceCode],[DepartmentCode],[ResourceCode] ,[SubResourceId]) VALUES " & _
            "(@ID,@Name,@Description,@Code,@DeviceCode,@DepartmentCode,@ResourceCode,@SubResourceId) "
            cmd.Connection = Cn
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@ID", SqlDbType.Int)
            cmd.Parameters.Add("@Name", SqlDbType.VarChar)
            cmd.Parameters.Add("@Description", SqlDbType.VarChar)
            cmd.Parameters.Add("@Code", SqlDbType.VarChar)
            cmd.Parameters.Add("@DeviceCode", SqlDbType.VarChar)
            cmd.Parameters.Add("@DepartmentCode", SqlDbType.VarChar)
            cmd.Parameters.Add("@ResourceCode", SqlDbType.VarChar)
            cmd.Parameters.Add("@SubResourceId", SqlDbType.Int)

            cmd.Parameters("@ID").Value = ID
            cmd.Parameters("@Name").Value = Name
            cmd.Parameters("@Description").Value = description
            cmd.Parameters("@Code").Value = code
            cmd.Parameters("@DeviceCode").Value = devicecode
            cmd.Parameters("@DepartmentCode").Value = departmentcode
            cmd.Parameters("@ResourceCode").Value = resourcecode
            cmd.Parameters("@SubResourceId").Value = subresourceid

            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function GetPlannedDTRC() As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select * from PlannedDTRC order by Description"
            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "PlannedDTRC")
            Cn.Close()
            Return ds.Tables("PlannedDTRC")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function GetConcepts() As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select * from Concepts order by Concept"
            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "Concepts")
            Cn.Close()
            Return ds.Tables("Concepts")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function GetFeatures() As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select * from partfeatures order by Asset_ID,Description"
            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "Features")
            Cn.Close()
            Return ds.Tables("Features")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function GetDowntimeCodes() As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select * from DowntimeCodes order by description"
            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "DowntimeCodes")
            Cn.Close()
            Return ds.Tables("DowntimeCodes")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function GetDowntimeCodesBis() As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select DTC.ID,DTC.Description,Department_ID,Concept_ID,C.Concept,D.Department from DowntimeCodes DTC inner join Concepts C on dtc.Concept_ID=C.ID inner join Departments D on c.Department_ID=D.ID order by description"
            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "DowntimeCodes")
            Cn.Close()
            Return ds.Tables("DowntimeCodes")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

#Region "Departments"
    Shared Function NewDepartment(ByVal Department As String) As Integer
        Try

            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "insert into Departments(Department) values(@Department) select @@IDENTITY"
            cmd.Connection = Cn
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Department", SqlDbType.VarChar)

            cmd.Parameters("@Department").Value = Department

            Dim resp As Integer
            resp = cmd.ExecuteScalar()
            Return resp

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function EditDepartment(ByVal ELID As Integer, ByVal Department As String) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "update Departments set Department = @Department where ID=" & ELID.ToString
            cmd.Connection = Cn
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Department", SqlDbType.VarChar)

            cmd.Parameters("@Department").Value = Department
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function DeleteDepartment(ByVal ELID As Integer) As Integer
        Try

            ''select count(*) from DowntimeCodes dtc inner join Concepts con on dtc.Concept_ID=con.ID inner join Downtime DT on dtc.ID = DT.DowntimeCode_ID where Concept_ID = 25
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()

            cmd.Connection = Cn
            cmd.Parameters.Clear()

            cmd.CommandText = "select count(*) from DowntimeCodes dtc inner join Concepts con on dtc.Concept_ID=con.ID inner join Departments dep on con.Department_ID=dep.ID inner join Downtime DT on dtc.ID = DT.DowntimeCode_ID where Department_ID = " & ELID.ToString

            If cmd.ExecuteScalar() > 0 Then
                Throw New Exception("No se puede eliminar el Departamento, Existen  uno o más Conceptos/códigos dentro del mismo que están siendo usados en un reporte.")
            End If

            cmd.CommandText = "DELETE FROM DownTimeCodes where Concept_ID IN (SELECT ID FROM CONCEPTS WHERE DEPARTMENT_ID=" & ELID.ToString & ")"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "DELETE FROM Concepts where Department_ID = " & ELID.ToString
            cmd.ExecuteNonQuery()

            cmd.CommandText = "DELETE FROM DEPARTMENTS WHERE ID=" & ELID.ToString

            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function getDepartments() As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select * from departments"
            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "departments")
            Cn.Close()
            Return ds.Tables("departments")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function
#End Region

#Region "Concepts"
    Shared Function NewConcept(ByVal DepartmentID As Integer, ByVal Concept As String) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "insert into Concepts(Department_ID,Concept) values(@Department_ID,@Concept) select @@IDENTITY"
            cmd.Connection = Cn
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Department_ID", SqlDbType.Int)
            cmd.Parameters.Add("@Concept", SqlDbType.VarChar)

            cmd.Parameters("@Department_ID").Value = DepartmentID
            cmd.Parameters("@Concept").Value = Concept
            Dim resp As Integer
            resp = cmd.ExecuteScalar()
            Return resp

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function EditConcept(ByVal ELID As Integer, ByVal Concept As String) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "update concepts set Concept = @Concept where ID=" & ELID.ToString
            cmd.Connection = Cn
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Concept", SqlDbType.VarChar)

            cmd.Parameters("@Concept").Value = Concept
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function


    Shared Function DeleteConcept(ByVal ELID As Integer) As Integer
        Try

            ''select count(*) from DowntimeCodes dtc inner join Concepts con on dtc.Concept_ID=con.ID inner join Downtime DT on dtc.ID = DT.DowntimeCode_ID where Concept_ID = 25
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()

            cmd.Connection = Cn
            cmd.Parameters.Clear()

            cmd.CommandText = "select count(*) from DowntimeCodes dtc inner join Concepts con on dtc.Concept_ID=con.ID inner join Downtime DT on dtc.ID = DT.DowntimeCode_ID where Concept_ID = " & ELID.ToString

            If cmd.ExecuteScalar() > 0 Then
                Throw New Exception("No se puede eliminar el Concepto, Existen uno o mas códigos dentro del mismo que están siendo usados en un reporte.")
            End If

            cmd.CommandText = "DELETE FROM DownTimeCodes where Concept_ID= " & ELID.ToString
            cmd.ExecuteNonQuery()

            cmd.CommandText = "DELETE FROM Concepts where ID = " & ELID.ToString
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

#End Region

#Region "DOWNTIME CODIGOS"
    Shared Function NewDowntimeCode(ByVal Concept_ID As Integer, ByVal Description As String) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "insert into DowntimeCodes(Concept_ID,Description) values(@Concept_ID,@Description) select @@IDENTITY"
            cmd.Connection = Cn
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Concept_ID", SqlDbType.Int)
            cmd.Parameters.Add("@Description", SqlDbType.VarChar)

            cmd.Parameters("@Concept_ID").Value = Concept_ID
            cmd.Parameters("@Description").Value = Description
            Dim resp As Integer
            resp = cmd.ExecuteScalar()
            Return resp

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function EditDowntimeCode(ByVal ELID As Integer, ByVal Description As String) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "update DowntimeCodes set Description = @Description where ID=" & ELID.ToString
            cmd.Connection = Cn
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Description", SqlDbType.VarChar)

            cmd.Parameters("@Description").Value = Description
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function DeleteDowntimeCode(ByVal ELID As Integer) As Integer
        Try

            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "DELETE FROM DowntimeCodes where ID=" & ELID.ToString
            cmd.Connection = Cn
            cmd.Parameters.Clear()

            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function
#End Region

#Region "Features"
    Shared Function NewFeature(ByVal Asset_ID As Integer, ByVal Station As String) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "insert into PartFeatures(Asset_ID,Description) values(@Asset_ID,@Description) select @@IDENTITY"
            cmd.Connection = Cn
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Asset_ID", SqlDbType.Int)
            cmd.Parameters.Add("@Description", SqlDbType.VarChar)

            cmd.Parameters("@Asset_ID").Value = Asset_ID
            cmd.Parameters("@Description").Value = Station

            Dim resp As Integer
            resp = cmd.ExecuteScalar()
            Return resp
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function
    Shared Function EditFeature(ByVal FeatureId As Integer, ByVal Description As String) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "update PartFeatures set Description=@description where id=@id"
            cmd.Connection = Cn
            cmd.Parameters.Clear()

            cmd.Parameters.AddWithValue("@id", FeatureId)
            cmd.Parameters.AddWithValue("@description", Description)

            cmd.ExecuteNonQuery()
            Return 1

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function DeleteFeature(ByVal ID As Integer) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "delete from PartFeatures where id=@id"
            cmd.Connection = Cn
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@id", ID)
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function
#End Region

#Region "CMS Rates"
    Shared Function GetCMSTheoricalRate(ByVal partnumber As String, ByVal dept As String, ByVal resource As String) As Integer
        Try
            CnCMS.ConnectionString = constringCMS()
            If CnCMS.State = ConnectionState.Closed Then CnCMS.Open()

            Dim retval As Integer = 0
            cmdCMS.CommandText = "select AOFUTD from METHDR WHERE AOPART='" & partnumber & "' AND AODEPT='" & dept & "' AND AORESC='" & resource & "'"
            retval = cmdCMS.ExecuteScalar

            If retval > 0 Then Return retval

            cmdCMS.CommandText = "select ARFUTD from METHDA WHERE ARPART='" & partnumber & "' AND ARDEPT='" & dept & "' AND ARRESC='" & resource & "'"
            retval = cmdCMS.ExecuteScalar

            If retval > 0 Then
                Return retval
            Else
                Return -1
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnCMS.State = ConnectionState.Open Then CnCMS.Close()
        End Try
    End Function
#End Region

#Region "TPM´s"

    'Select
    Shared Function TPMreq() As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.CommandText = "Select * from tpm.TPM"
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "TPM")
            CnMPS.Close()
            Return ds.Tables("TPM")


        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function
    Shared Function TPMRelEsts() As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.CommandText = "Select * from [tpm].[Tpm_Station]"
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "TPMrel")
            CnMPS.Close()
            Return ds.Tables("TPMrel")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try


    End Function
    Shared Function TPMelements() As DataTable

        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()

            da.SelectCommand.CommandText = "Select * from tpm.TPM_Detalle order by TPM_ID,Orden"
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Elements")
            CnMPS.Close()
            Return ds.Tables("Elements")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function TPMStations()
        Try

            CnCMS.ConnectionString = constringCMS()
            If CnCMS.State = ConnectionState.Closed Then CnCMS.Open()
            dacms.SelectCommand.CommandText = "select * from ABC.CONFIG_ABC WHERE ASSET <>''"
            dacms.SelectCommand.Connection = CnCMS
            ds.Tables.Clear()
            dacms.Fill(ds, "Stations")
            CnCMS.Close()
            Return ds.Tables("Stations")
        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally
            If CnCMS.State = ConnectionState.Open Then CnCMS.Close()
        End Try

    End Function
    Shared Function TPMelementTag(ByVal TPM_ID As Integer, ByVal texto As String, ByVal orden As Integer) As Integer

        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandText = "Select ID from [tpm].[TPM_DETALLE] where TPM_ID = @tpm_id and Text = @text and Orden = @orden"
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@tpm_id", SqlDbType.Int)
            cmd.Parameters.Add("@text", SqlDbType.VarChar)
            cmd.Parameters.Add("@orden", SqlDbType.Int)
            cmd.Parameters("@tpm_id").Value = TPM_ID
            cmd.Parameters("@text").Value = texto
            cmd.Parameters("@orden").Value = orden
            Dim a As Integer
            a = cmd.ExecuteScalar
            Return a

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()

        End Try
    End Function
    Shared Function TPM_RESULT(ByVal TPM_ID As Integer, ByVal TPMDETALLE As Boolean, Optional ByVal detalle As Integer = 0) As Integer
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@TPMID", SqlDbType.Int)
            cmd.Parameters("@TPMID").Value = TPM_ID
            If TPMDETALLE Then
                cmd.CommandText = "Select * from [tpm].[TPM_Result_Detalle] where TPM_ID = @TPMID and TPM_Detalle_ID = @detalle"
                cmd.Parameters.Add("@detalle", SqlDbType.Int)
                cmd.Parameters("@detalle").Value = detalle
            Else
                cmd.CommandText = "Select * from [tpm].[TPM_Result] where TPM_ID = @TPMID"
            End If
            Return cmd.ExecuteScalar()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function TPM_ELEMENT_RESULT(ByVal ElementId As Integer) As Integer
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@element_id", SqlDbType.Int)
            cmd.Parameters("@element_id").Value = ElementId
            cmd.CommandText = "Select id from [tpm].[Tpm_Result_Detalle] where TPM_Detalle_ID = @element_id"
            Return cmd.ExecuteScalar()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    'INSERT
    Shared Function TPMAddRelStation(ByVal TPM_ID As Integer, ByVal Asset As String, ByVal Station As String)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandText = "INSERT INTO [tpm].[Tpm_Station] (TPM_ID,Asset,Station) VALUES (@id_tpm,@Asset,@Station) "
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@id_tpm", SqlDbType.Int)
            cmd.Parameters.Add("@Asset", SqlDbType.VarChar)
            cmd.Parameters.Add("@Station", SqlDbType.VarChar)

            cmd.Parameters("@id_tpm").Value = TPM_ID
            cmd.Parameters("@Asset").Value = Asset
            cmd.Parameters("@Station").Value = Station

            cmd.ExecuteNonQuery()
            Return 1

        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally

            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function
    Shared Function AddTPMelements(ByVal TPM_ID As Integer, ByVal Orden As Integer, ByVal text As String, ByVal Color As String) As Integer
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandText = "INSERT INTO [tpm].[TPM_Detalle] ([TPM_ID],[Orden],[Text],Color) VALUES(@id,@orden,@text,@color)"
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@id", TPM_ID)
            cmd.Parameters.AddWithValue("@orden", Orden)
            cmd.Parameters.AddWithValue("@text", text)
            cmd.Parameters.AddWithValue("@color", Color)

            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function
    Shared Function AddTPM(ByVal name As String) As Integer
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandText = "INSERT INTO [tpm].[TPM] (Name) VALUES(@Name)"
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Name", SqlDbType.VarChar)
            cmd.Parameters("@Name").Value = name
            cmd.ExecuteNonQuery()
            Return 1


        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    'UPDATE
    Shared Function TPMelementUpdate(ByVal tpm_id As Integer, ByVal Orden As Integer, ByVal id As Integer) As Integer
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandText = "UPDATE [tpm].[TPM_Detalle] SET Orden = @Orden where  TPM_ID = @tpm_id and ID = @id"
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@id", SqlDbType.Int)
            cmd.Parameters.Add("@Orden", SqlDbType.Int)
            cmd.Parameters.Add("@tpm_id", SqlDbType.Int)
            cmd.Parameters("@tpm_id").Value = tpm_id
            cmd.Parameters("@Orden").Value = Orden
            cmd.Parameters("@id").Value = id
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try

    End Function
    Shared Function EditTPMelements(ByVal tpm_id As Integer, ByVal texto As String, ByVal Orden As Integer, ByVal id As Integer, ByVal Color As String) As Integer
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandText = "Update [tpm].[TPM_Detalle] SET Text = @texto,Color=@Color where TPM_ID = @tpm_id and ID = @id "
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()

            cmd.Parameters.AddWithValue("@id", id)
            cmd.Parameters.AddWithValue("@tpm_id", tpm_id)
            cmd.Parameters.AddWithValue("@texto", texto)
            cmd.Parameters.AddWithValue("@Color", Color)

            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function TPMEdit(ByVal tpm_id As Integer, ByVal text As String) As Integer
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.Connection = CnMPS
            cmd.CommandText = "UPDATE [tpm].[TPM] SET Name = @text where ID = @id"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@id", SqlDbType.Int)
            cmd.Parameters.Add("@text", SqlDbType.VarChar)
            cmd.Parameters("@id").Value = tpm_id
            cmd.Parameters("@text").Value = text
            cmd.ExecuteNonQuery()

            Return 1

        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Public Structure ElementsOrder
        Dim id As Integer
        Dim orden As Integer
    End Structure
    Shared Function EditOrderElements(ByVal tpm_id As Integer, ByVal elements As List(Of ElementsOrder)) As Integer
        Dim tra As SqlClient.SqlTransaction
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            tra = CnMPS.BeginTransaction()
            cmd.Connection = CnMPS
            cmd.CommandText = "UPDATE [tpm].[TPM_Detalle] SET Orden = @orden where  TPM_ID = @tpm_id and ID = @id"
            cmd.Parameters.Clear()
            cmd.Transaction = tra
            cmd.Parameters.Add("@tpm_id", SqlDbType.Int)
            cmd.Parameters.Add("@orden", SqlDbType.Int)
            cmd.Parameters.Add("@id", SqlDbType.Int)
            cmd.Parameters("@tpm_id").Value = tpm_id
            For Each a As ElementsOrder In elements
                cmd.Parameters("@id").Value = a.id
                cmd.Parameters("@orden").Value = a.orden
                cmd.ExecuteNonQuery()
            Next
            tra.Commit()
            Return 1
        Catch ex As Exception
            tra.Rollback()
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
            cmd.Transaction = Nothing
        End Try
    End Function

    'DELETE
    Shared Function RemoveTPMelement(ByVal TPM_ID As Integer, ByVal Orden As Integer, ByVal id As Integer) As Integer
        Dim tra As SqlClient.SqlTransaction
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            tra = CnMPS.BeginTransaction()
            cmd.CommandText = "DELETE FROM [tpm].[TPM_Detalle] where TPM_ID = @tpm_id and Orden = @orden and Id = @id "
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.Transaction = tra
            cmd.Parameters.Add("@tpm_id", SqlDbType.Int)
            cmd.Parameters.Add("@orden", SqlDbType.Int)
            cmd.Parameters.Add("@id", SqlDbType.Int)
            cmd.Parameters("@tpm_id").Value = TPM_ID
            cmd.Parameters("@orden").Value = Orden
            cmd.Parameters("@id").Value = id
            cmd.ExecuteNonQuery()
            cmd.CommandText = "DELETE FROM [tpm].[TPM_Result_Detalle] where TPM_ID = @tpm_id and TPM_Detalle_ID = @id"
            cmd.ExecuteNonQuery()
            tra.Commit()
            Return 1
        Catch ex As Exception
            tra.Rollback()
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
            cmd.Transaction = Nothing
        End Try

    End Function
    Shared Function TPMRemoveRelStation(ByVal TPM_ID As Integer, ByVal Asset As String, ByVal Station As String)

        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandText = "DELETE FROM  [tpm].[Tpm_Station] where TPM_ID = @id_tpm and Asset = @Asset and Station = @Station "
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@id_tpm", SqlDbType.Int)
            cmd.Parameters.Add("@Asset", SqlDbType.VarChar)
            cmd.Parameters.Add("@Station", SqlDbType.VarChar)
            cmd.Parameters("@id_tpm").Value = TPM_ID
            cmd.Parameters("@Asset").Value = Asset
            cmd.Parameters("@Station").Value = Station

            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function
    Shared Function DeleteTPM(ByVal TPM_ID As Integer) As Integer
        Dim tra As SqlClient.SqlTransaction
        Try

            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            tra = CnMPS.BeginTransaction()

            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@TPM_ID", SqlDbType.Int)
            cmd.Parameters("@TPM_ID").Value = TPM_ID
            cmd.Transaction = tra
            cmd.CommandText = "Delete from [tpm].[TPM_Detalle] where TPM_ID = @TPM_ID"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Delete from [tpm].[TPM_Result] where TPM_ID = @TPM_ID"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Delete from [tpm].[TPM_Result_Detalle] where TPM_ID = @TPM_ID"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Delete from [tpm].[Tpm_Station] where TPM_ID = @TPM_ID"
            cmd.ExecuteNonQuery()
            cmd.CommandText = "Delete from [tpm].[TPM] where ID = @TPM_ID"
            cmd.ExecuteNonQuery()

            tra.Commit()
            Return 1


        Catch ex As Exception
            tra.Rollback()
            Throw New Exception(ex.Message)

        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
            cmd.Transaction = Nothing
        End Try

    End Function

    Shared Function TPMcategories() As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()

            da.SelectCommand.CommandText = "Select * from [tpm].[TPM_Categorias]"
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Categories")
            CnMPS.Close()
            Return ds.Tables("Categories")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function TPMcategoriesInsert(ByVal Categoria As String)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()

            cmd.CommandText = "Insert into [Tpm].[TPM_Categorias](Categoria,Simbolo,ColorName)VALUES(@cat,1,'Black')"
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()


            cmd.Parameters.Add("@cat", SqlDbType.VarChar)
            cmd.Parameters("@cat").Value = Categoria


            cmd.ExecuteNonQuery()
            CnMPS.Close()
            Return 1

        Catch ex As Exception
            Return 0
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function TPMcategoriesUpdate(ByVal id As Integer, ByVal Categoria As String, ByVal Simbolo As Integer, ByVal ColorName As String)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandText = "UPDATE [tpm].[TPM_Categorias] SET Categoria = @Categoria, Simbolo = @Simbolo, ColorName = @Color where ID = @id"
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@Categoria", SqlDbType.VarChar)
            cmd.Parameters.Add("@Simbolo", SqlDbType.Int)
            cmd.Parameters.Add("@Color", SqlDbType.VarChar)
            cmd.Parameters.Add("@id", SqlDbType.Int)

            cmd.Parameters("@Categoria").Value = Categoria
            cmd.Parameters("@Simbolo").Value = Simbolo
            cmd.Parameters("@Color").Value = ColorName
            cmd.Parameters("@id").Value = id

            cmd.ExecuteNonQuery()
            CnMPS.Close()

            Return 1
        Catch ex As Exception
            Return 0
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function TPMCategoriesCount(ByVal id As Integer) As Integer
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandText = "select count(*) From [tpm].[TPM_Elementos] where Categoria_ID = " & id.ToString
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
           
            Dim retval As Integer
            retval = cmd.ExecuteScalar()
            Return retval
        Catch ex As Exception            
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function TPMcategoriesDelete(ByVal id As Integer)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandText = "Delete From [tpm].[TPM_Categorias] where ID = @id"
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@id", SqlDbType.Int)
            cmd.Parameters("@id").Value = id
            cmd.ExecuteNonQuery()          
            Return 1
        Catch ex As Exception           
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function TPMdefects() As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.CommandText = "Select * from tpm.TPM_Defectos"
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Defects")            
            Return ds.Tables("Defects")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function TPMdefectsInsert(ByVal Defecto As String)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()

            cmd.CommandText = "Insert into [tpm].[TPM_Defectos]([Defecto])VALUES(" &
                "@Defecto); select @@IDENTITY"
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@Defecto", SqlDbType.VarChar)
            cmd.Parameters("@Defecto").Value = Defecto
            Dim re As Integer = 0
            re = cmd.ExecuteScalar()
            Return re
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function TPMdefectsUpdate(ByVal id As Integer, ByVal Defecto As String)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandText = "Update [tpm].[TPM_Defectos] SET Defecto = @Defecto where id = @ID"
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@Defecto", SqlDbType.VarChar)
            cmd.Parameters("@Defecto").Value = Defecto
            cmd.Parameters.Add("@ID", SqlDbType.VarChar)
            cmd.Parameters("@ID").Value = id

            cmd.ExecuteNonQuery()
            Return 1
            CnMPS.Close()
        Catch ex As Exception
            Return 0
            Throw New Exception(ex.Message)
        Finally

            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()

        End Try
    End Function

    Shared Function TPMdefectsDeleteCount(ByVal id As Integer) As Integer
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandText = "select count(*) from tpm.TPM_Result_Defectos where defectoid=" & id.ToString
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            Return cmd.ExecuteScalar            
        Catch ex As Exception

            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function TPMdefectsDelete(ByVal id As Integer)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandText = "Delete From [TPM].[TPM_Defectos] where id = @id"
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@id", SqlDbType.VarChar)
            cmd.Parameters("@id").Value = id

            cmd.ExecuteNonQuery()         
            Return 1
        Catch ex As Exception
            Return 0
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function TPMdef_rel() As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()

            da.SelectCommand.CommandText = "Select * from [tpm].[TPM_Elementos]   order by Asset,Station,Categoria_ID,Elemento"
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Relations")
            CnMPS.Close()
            Return ds.Tables("Relations")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function TPMdef_rel_Insert(ByVal Categoria_ID As Integer, ByVal Asset As String, ByVal Station As String, ByVal elemento As String)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandText = "Insert into [tpm].[TPM_Elementos](Categoria_ID,Asset,Station,Elemento)VALUES(@cat,@Asset,@Station,@Element); select @@IDENTITY"
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@cat", SqlDbType.Int)
            cmd.Parameters.Add("@Asset", SqlDbType.VarChar)
            cmd.Parameters.Add("@Station", SqlDbType.VarChar)
            cmd.Parameters.Add("@Element", SqlDbType.VarChar)

            cmd.Parameters("@cat").Value = Categoria_ID
            cmd.Parameters("@Asset").Value = Asset
            cmd.Parameters("@Station").Value = Station
            cmd.Parameters("@Element").Value = elemento


            Dim re = cmd.ExecuteScalar()
            CnMPS.Close()
            Return re
        Catch ex As Exception
            Return 0
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function TPMdef_rel_Update(ByVal ID As Integer, ByVal elemento As String)
        Try

            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandText = "Update [tpm].[TPM_Elementos] set Elemento = @Element where id = @id"
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@id", SqlDbType.Int)
            cmd.Parameters.Add("@Element", SqlDbType.VarChar)

            cmd.Parameters("@id").Value = ID
            cmd.Parameters("@Element").Value = elemento


            cmd.ExecuteNonQuery()

            CnMPS.Close()
            Return 1
        Catch ex As Exception
            Return 0
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function TPMdef_rel_Delete(ByVal id As Integer)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandText = "Delete from [tpm].[TPM_Elementos] where id = @id"
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@id", SqlDbType.VarChar)
            cmd.Parameters("@id").Value = id

            cmd.ExecuteNonQuery()
            CnMPS.Close()
            Return 1
        Catch ex As Exception
            Return 0
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function TPMcat_rel_delete(ByVal cat_id As Integer, ByVal asset As String, ByVal station As String)
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            cmd.CommandText = "Delete from [tpm].[TPM_Elementos] where Categoria_ID = @cat_id and Asset = @asset and Station = @stat"
            cmd.Connection = CnMPS
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@cat_id", SqlDbType.Int)
            cmd.Parameters.Add("@asset", SqlDbType.VarChar)
            cmd.Parameters.Add("@stat", SqlDbType.VarChar)
            cmd.Parameters("@cat_id").Value = cat_id
            cmd.Parameters("@asset").Value = asset
            cmd.Parameters("@stat").Value = station

            cmd.ExecuteNonQuery()
            Return 1
            CnMPS.Close()

        Catch ex As Exception
            Return 0
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function Huellas(ByVal cb_codigo As String) As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Parameters.Clear()
            da.SelectCommand.Parameters.Add("@CB_CODIGO", SqlDbType.VarChar)
            da.SelectCommand.Parameters("@CB_CODIGO").Value = cb_codigo
            da.SelectCommand.CommandText = "Select * from [dbo].[COMEDOR_HUELLAS] where CB_CODIGO= @CB_CODIGO"
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Huellas")
            CnMPS.Close()
            Return ds.Tables("Huellas")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function TPMrepTot(ByVal fecha As Date, ByVal turno As Integer, ByVal linea As String) As DataTable
        Try
            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            da.SelectCommand.Parameters.Clear()
            'da.SelectCommand.CommandText = "select r.id,s.Asset,s.Station,TPM_Result,CB_CODIGO,r.CB_CODIGO_Aprueba,r.Aprueba_datetime FROM [MaRs].[tpm].[Tpm_Station] s left join mars.tpm.TPM_Result  r  on s.Asset = r.Asset  and s.Station = r.Station AND date = @fecha and Shift = @turno Where s.Asset = @asset"
            da.SelectCommand.CommandText = "select r.id,s.Asset,s.Station,case when TPM_Result is null and @fecha <= getdate() then 0 when TPM_Result is null and @fecha > getdate() then 5 else TPM_Result end as TPM_Result,CB_CODIGO,r.CB_CODIGO_Aprueba,r.Aprueba_datetime FROM [MaRs].[tpm].[Tpm_Station] s left join mars.tpm.TPM_Result  r  on s.Asset = r.Asset  and s.Station = r.Station AND date = @fecha and Shift = @turno Where s.Asset = @asset"
            'da.SelectCommand.Parameters.Add("@fecha", SqlDbType.Date)
            da.SelectCommand.Parameters.Add("@turno", SqlDbType.Int)
            da.SelectCommand.Parameters.Add("@asset", SqlDbType.VarChar)

            'da.SelectCommand.Parameters("@fecha").Value = fecha
            da.SelectCommand.Parameters.AddWithValue("@fecha", fecha)
            da.SelectCommand.Parameters("@turno").Value = turno
            da.SelectCommand.Parameters("@asset").Value = linea
            da.SelectCommand.Connection = CnMPS
            ds.Tables.Clear()
            da.Fill(ds, "Stations_comp")
            CnMPS.Close()
            Return ds.Tables("Stations_comp")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
        End Try
    End Function

    Shared Function Aprob_tpm(ByVal id As List(Of Integer), ByVal cb_codigo As String)
        Dim tra As SqlClient.SqlTransaction
        Try

            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            tra = CnMPS.BeginTransaction()

            cmd.Connection = CnMPS
            cmd.Parameters.Clear()
            cmd.Transaction = tra
            cmd.Parameters.Add("@CB_CODIGO", SqlDbType.Int)
            cmd.Parameters("@CB_CODIGO").Value = cb_codigo
            cmd.Parameters.Add("@ID", SqlDbType.Int)
            For Each i As Integer In id

                cmd.Parameters("@ID").Value = i
                cmd.CommandText = "UPDATE [tpm].[TPM_Result] SET CB_CODIGO_Aprueba = @CB_CODIGO, Aprueba_datetime = GETDATE() where ID = @ID"
                cmd.ExecuteNonQuery()
            Next



            tra.Commit()
            Return 1


        Catch ex As Exception
            tra.Rollback()
            Throw New Exception(ex.Message)

        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
            cmd.Transaction = Nothing
        End Try
    End Function

    Shared Function NoProduccionAprob(ByVal id As List(Of NOPRODUCCION), ByVal cb_codigo As String)
        Dim tra As SqlClient.SqlTransaction
        Try

            CnMPS.ConnectionString = constringMPS()
            If CnMPS.State = ConnectionState.Closed Then CnMPS.Open()
            tra = CnMPS.BeginTransaction()

            cmd.Connection = CnMPS

            cmd.Transaction = tra

            For Each i As NOPRODUCCION In id

                cmd.Parameters.Clear()
                cmd.Parameters.Add("@ASSET", SqlDbType.VarChar)
                cmd.Parameters("@ASSET").Value = i.Asset
                cmd.Parameters.Add("@STATION", SqlDbType.VarChar)
                cmd.Parameters("@STATION").Value = i.Station
                cmd.CommandText = "Select TPM_ID from tpm.Tpm_Station where Asset = @ASSET AND Station = @STATION"
                Dim tpm_id = cmd.ExecuteScalar

                cmd.Parameters.Add("@CB_CODIGO", SqlDbType.Int)
                cmd.Parameters.Add("@SHIFT", SqlDbType.Int)
                cmd.Parameters.Add("@DATE", SqlDbType.Date)
                cmd.Parameters.Add("@TPMID", SqlDbType.Int)
                cmd.Parameters("@CB_CODIGO").Value = cb_codigo
                cmd.Parameters("@SHIFT").Value = i.Shift
                cmd.Parameters("@DATE").Value = i.Fecha
                cmd.Parameters("@TPMID").Value = tpm_id

                cmd.CommandText = "INSERT INTO [tpm].[TPM_Result] (Date,Time,TPM_ID,Asset,Station,Shift,TPM_Result,CB_CODIGO_Aprueba,Aprueba_datetime) VALUES(@DATE,@DATE,@TPMID,@ASSET,@Station,@SHIFT,4,@CB_CODIGO,GETDATE()); select @@IDENTITY"
                Dim re = cmd.ExecuteScalar()
                da.SelectCommand.Parameters.Clear()
                da.SelectCommand.Parameters.Add("@TPMID", SqlDbType.Int)
                da.SelectCommand.Parameters("@TPMID").Value = tpm_id
                da.SelectCommand.CommandText = "Select id from [tpm].[TPM_Detalle] where TPM_ID = @TPMID order by Orden"
                da.SelectCommand.Connection = CnMPS
                da.SelectCommand.Transaction = tra
                ds.Tables.Clear()
                da.Fill(ds, "elements")


                For Each ro As DataRow In ds.Tables("elements").Rows
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("@Result", SqlDbType.Int)
                    cmd.Parameters("@Result").Value = re
                    cmd.Parameters.Add("@date", SqlDbType.Date)
                    cmd.Parameters.Add("@tpm_detalle", SqlDbType.Int)
                    cmd.Parameters.Add("@Asset", SqlDbType.VarChar)
                    cmd.Parameters.Add("@Station", SqlDbType.VarChar)
                    cmd.Parameters.Add("@Shift", SqlDbType.VarChar)
                    cmd.Parameters.Add("@CB_CODIGO", SqlDbType.Int)
                    cmd.Parameters.AddWithValue("@tpm_id", tpm_id)
                    cmd.Parameters("@date").Value = i.Fecha
                    cmd.Parameters("@tpm_detalle").Value = ro.Item(0).ToString
                    cmd.Parameters("@Asset").Value = i.Asset
                    cmd.Parameters("@Station").Value = i.Station
                    cmd.Parameters("@Shift").Value = i.Shift
                    cmd.Parameters("@CB_CODIGO").Value = cb_codigo
                    cmd.CommandText = "INSERT INTO tpm.[TPM_Result_Detalle] (Result_ID,Date,Time,TPM_ID,TPM_Detalle_ID, Asset,Station,Shift,Result,TPM_Result,CB_CODIGO)VALUES(@Result,@date,@date,@tpm_id,@tpm_detalle,@Asset,@Station,@Shift,4,4,@CB_CODIGO) "
                    cmd.ExecuteNonQuery()
                Next
            Next



            tra.Commit()
            Return 1


        Catch ex As Exception
            tra.Rollback()
            Throw New Exception(ex.Message)

        Finally
            If CnMPS.State = ConnectionState.Open Then CnMPS.Close()
            cmd.Transaction = Nothing
        End Try
    End Function

    Public Structure NOPRODUCCION
        Dim Asset As String
        Dim Station As String
        Dim Shift As Integer
        Dim Fecha As Date
    End Structure
#End Region
   

#Region "Stations"

    Shared Function NewStation(ByVal Asset_ID As Integer, ByVal Station As String) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "insert into Stations(Asset_ID,station) values(@Asset_ID,@Station) select @@IDENTITY"
            cmd.Connection = Cn
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Asset_ID", SqlDbType.Int)
            cmd.Parameters.Add("@Station", SqlDbType.VarChar)

            cmd.Parameters("@Asset_ID").Value = Asset_ID
            cmd.Parameters("@Station").Value = Station

            Dim resp As Integer
            resp = cmd.ExecuteScalar()
            Return resp

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function EditStation(ByVal StationId As Integer, ByVal station As String) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "update Stations set station=@station where id=" & StationId
            cmd.Connection = Cn
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@station", SqlDbType.VarChar)
            cmd.Parameters("@station").Value = station

            cmd.ExecuteNonQuery()
            Return 1

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function DeleteStation(ByVal ID As Integer) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "delete from stations where id=" & ID.ToString
            cmd.Connection = Cn
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function getStations(Optional ByVal Assetid As String = "") As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()

            If Assetid = "" Then
                da.SelectCommand.CommandText = "select * from stations"
            Else
                da.SelectCommand.CommandText = "select * from stations where asset_id=" & Assetid
            End If

            da.SelectCommand.Connection = Cn

            ds.Tables.Clear()
            da.Fill(ds, "stations")

            Cn.Close()

            Return ds.Tables("stations")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try

    End Function

#End Region

#Region "Equipment"

    Shared Function NewEquipment(ByVal stationid As Integer, ByVal equipment As String) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "insert into equipment(station,equipment) values(@station,@equipment) select @@IDENTITY"
            cmd.Connection = Cn
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@station", SqlDbType.Int)
            cmd.Parameters.Add("@equipment", SqlDbType.VarChar)

            cmd.Parameters("@station").Value = stationid
            cmd.Parameters("@equipment").Value = equipment

            Dim resp As Integer
            resp = cmd.ExecuteScalar()
            Return resp

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function EditEquipment(ByVal equipmentid As Integer, ByVal equipment As String) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "update equipment set equipment=@equipment where id=" & equipmentid
            cmd.Connection = Cn
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@equipment", SqlDbType.VarChar)
            cmd.Parameters("@equipment").Value = equipment

            cmd.ExecuteNonQuery()
            Return 1

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function DeleteEquipment(ByVal ID As Integer) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "delete from Equipment where id=@id"
            cmd.Connection = Cn
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@id", ID)

            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function getequipment(Optional ByVal Assetid As String = "") As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            If Assetid = "" Then
                da.SelectCommand.CommandText = "select E.* from [dbo].[Equipment] E inner join Stations s on S.ID=e.station"
            Else
                da.SelectCommand.CommandText = "select E.* from [dbo].[Equipment] E inner join Stations s on S.ID=e.station where s.asset_ID=" & Assetid
            End If

            da.SelectCommand.Connection = Cn

            ds.Tables.Clear()
            da.Fill(ds, "Equipment")

            Cn.Close()

            Return ds.Tables("Equipment")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

#End Region

#Region "MARS"
    Shared Function GetMARSAssets() As DataTable
        Try
            CnMARS.ConnectionString = constringMARS()
            If CnMARS.State = ConnectionState.Closed Then CnMARS.Open()
            'damars.SelectCommand.CommandText = "Select A.ID,A.Name,A.Description,A.Code,A.DeviceCode,A.DepartmentCode,A.ResourceCode,SR.SubResourceOffset_ID as SubResourceID from pro.ResourceStatus RS inner join dbo.Asset A on RS.Asset_ID=A.ID inner join ref.SubResource SR on SR.Asset_ID=A.ID"
            damars.SelectCommand.CommandText = "Select A.ID,A.Name,A.Description,A.Code,A.DeviceCode,A.DepartmentCode,A.ResourceCode,SR.SubResourceOffset_ID as SubResourceID from dbo.Asset A left outer join pro.ResourceStatus RS  on RS.Asset_ID=A.ID  left outer join ref.SubResource SR on SR.Asset_ID=A.ID"
            damars.SelectCommand.Connection = CnMARS
            ds.Tables.Clear()
            damars.Fill(ds, "Assets")
            Return ds.Tables("Assets")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMARS.State = ConnectionState.Open Then CnMARS.Close()

        End Try
    End Function

    Shared Function GetMARSShifts(ByVal assetid As Integer, ByVal PRODUCTIONDATE As Date) As DataTable
        Try
            CnMARS.ConnectionString = constringMARS()
            If CnMARS.State = ConnectionState.Closed Then CnMARS.Open()
            damars.SelectCommand.CommandText = "SELECT  sd.ID as ShiftID,* FROM ref.Shift s inner join ref.ShiftDetail sd on s.ID=sd.Shift_ID where s.ID = (SELECT [ref].[f_GetShiftID] (" & assetid & ",'" & PRODUCTIONDATE.ToString("MM/dd/yyyy") & "'))"
            ds.Tables.Clear()
            damars.Fill(ds, "Shifts")
            Return ds.Tables("Shifts")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMARS.State = ConnectionState.Open Then CnMARS.Close()
        End Try
    End Function

    Shared Function GetMARSProductionDate(ByVal AssetID As String, ByVal SubresourceID As String) As Date
        Try
            CnMARS.ConnectionString = constringMARS()
            If CnMARS.State = ConnectionState.Closed Then CnMARS.Open()
            cmdMARS.CommandText = "Select ProductionDate from pro.ResourceStatus where Asset_ID=" & AssetID
            cmdMARS.Connection = CnMARS
            Dim CurrDate As Date
            CurrDate = cmdMARS.ExecuteScalar
            Return CurrDate
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMARS.State = ConnectionState.Open Then CnMARS.Close()
        End Try
    End Function

    Shared Function GetMARSDateTimes(ByVal asset As Integer, ByVal Shift As String, ByVal PRODUCTIONDATE As Date) As List(Of DateTime)
        Try
            CnMARS.ConnectionString = constringMARS()
            If CnMARS.State = ConnectionState.Closed Then CnMARS.Open()
            cmdMARS.CommandText = "Select getdate()"
            cmdMARS.Connection = CnMARS
            Dim CurrDate As Date
            CurrDate = cmdMARS.ExecuteScalar

            damars.SelectCommand.CommandText = "SELECT  sd.ID as ShiftID,* FROM ref.Shift s inner join ref.ShiftDetail sd on s.ID=sd.Shift_ID where s.ID = (SELECT [ref].[f_GetShiftID] (" & asset.ToString & ",'" & PRODUCTIONDATE.ToString("MM/dd/yyyy") & "')) and sd.name='" & Shift & "'"
            ds.Tables.Clear()
            damars.Fill(ds, "Shifts")

            Dim lst As New List(Of DateTime)
            lst.Add(ds.Tables("Shifts").DefaultView.Item(0).Item("StartTime"))
            lst.Add(ds.Tables("Shifts").DefaultView.Item(0).Item("EndTime"))
            lst.Add(CurrDate)

            Return lst

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMARS.State = ConnectionState.Open Then CnMARS.Close()
        End Try
    End Function

    Shared Function GetMARSProductionShiftName(ByVal AssetID As String, ByVal SubresourceID As String) As String
        Try
            CnMARS.ConnectionString = constringMARS()
            If CnMARS.State = ConnectionState.Closed Then CnMARS.Open()

            Dim CurrShiftName As String = ""

            cmdMARS.CommandText = "Select ProductionShiftName from pro.ResourceStatus where Asset_ID=" & AssetID
            cmdMARS.Connection = CnMARS

            CurrShiftName = cmdMARS.ExecuteScalar

            Return CurrShiftName
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMARS.State = ConnectionState.Open Then CnMARS.Close()
        End Try
    End Function

    Shared Function GetMARSDowntime(ByVal AssetID As String, ByVal SubresourceID As String, ByVal shiftendtime As String, Optional ByVal EspecificDate As String = "", Optional ByVal EspecificShift As String = "") As DataTable
        Try
            CnMARS.ConnectionString = constringMARS()
            If CnMARS.State = ConnectionState.Closed Then CnMARS.Open()
            cmdMARS.CommandText = "Select ProductionShift from pro.ResourceStatus where Asset_ID=" & AssetID
            'cmdMARS.CommandText = "Select case when ProductionShift is null then ProductionDate else ProductionShift End as ProductionShiftDate from pro.ResourceStatus where Asset_ID=" & AssetID
            cmdMARS.Connection = CnMARS
            Dim CurrDate As Date
            CurrDate = cmdMARS.ExecuteScalar
            Dim CurrShiftName As String = ""
            cmdMARS.CommandText = "Select ProductionShiftName from pro.ResourceStatus where Asset_ID=" & AssetID
            CurrShiftName = cmdMARS.ExecuteScalar
            damars.SelectCommand.CommandText = "exec [hmo].[getdowntime] " & AssetID & ",'" & IIf(EspecificShift <> "", EspecificShift, CurrShiftName) & "','" & IIf(EspecificDate <> "", EspecificDate, CurrDate.ToString("MM/dd/yyyy")) & "' "  ''where CURRENTTARGET>0"
            ds.Tables.Clear()
            damars.Fill(ds, "Downtime")
            CnMARS.Close()
            Return ds.Tables("Downtime")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMARS.State = ConnectionState.Open Then CnMARS.Close()
        End Try
    End Function

    Shared Function GetMARSProduction(ByVal AssetID As String, ByVal SubresourceID As String, ByVal shiftendtime As String, Optional ByVal EspecificDate As String = "", Optional ByVal EspecificShift As String = "") As DataTable
        Try
            CnMARS.ConnectionString = constringMARS()
            If CnMARS.State = ConnectionState.Closed Then CnMARS.Open()
            cmdMARS.CommandText = "Select ProductionShift from pro.ResourceStatus where Asset_ID=" & AssetID
            'cmdMARS.CommandText = "Select case when ProductionShift is null then ProductionDate else ProductionShift End as ProductionShiftDate from pro.ResourceStatus where Asset_ID=" & AssetID
            cmdMARS.Connection = CnMARS
            Dim CurrDate As Date
            CurrDate = cmdMARS.ExecuteScalar
            Dim CurrShiftName As String = ""
            cmdMARS.CommandText = "Select ProductionShiftName from pro.ResourceStatus where Asset_ID=" & AssetID
            CurrShiftName = cmdMARS.ExecuteScalar
            damars.SelectCommand.CommandText = "SELECT * FROM [hmo].[GetHourlyProdTableReport] (" & AssetID & ",'" & IIf(EspecificShift <> "", EspecificShift, CurrShiftName) & "','" & IIf(EspecificDate <> "", EspecificDate, CurrDate.ToString("MM/dd/yyyy")) & "'," & SubresourceID & ") where starttime<'" & shiftendtime & "' "  ''where CURRENTTARGET>0"
            If Debugger.IsAttached Then
                If 1 = 0 Then
                    damars.SelectCommand.CommandText = "SELECT * FROM [hmo].[GetHourlyProdTableReport] (" & AssetID & ",'" & IIf(EspecificShift <> "", EspecificShift, CurrShiftName) & "','" & IIf(EspecificDate <> "", EspecificDate, CurrDate.ToString("MM/dd/yyyy")) & "'," & SubresourceID & ") where starttime<'" & shiftendtime & "' AND TOTAL>=0"  ''where CURRENTTARGET>0"
                End If
            End If
            ds.Tables.Clear()
            damars.Fill(ds, "Production")
            CnMARS.Close()
            Return ds.Tables("Production")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If CnMARS.State = ConnectionState.Open Then CnMARS.Close()
        End Try
    End Function
#End Region

#Region "Downtime"

    

    Shared Function NewDowntime(ByVal Asset As Integer, ByVal productiondate As String, ByVal shift As String, ByVal Hour As String, ByVal equipment As String, ByVal downtimecode As Integer, ByVal minutes As Double, ByVal comments As String, ByRef PartNumber As String, Optional ByVal StartTime As String = "", Optional ByVal EndTime As String = "", Optional ByVal DT_ID As Integer = -1) As Integer
        Try
            If String.IsNullOrEmpty(productiondate) Or String.IsNullOrEmpty(shift) Or String.IsNullOrEmpty(Hour) Or String.IsNullOrEmpty(equipment) Or minutes <= 0 Then
                Throw New Exception("Data Validation not passed")
            End If

            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()

            cmd.CommandText = "insert into downtime(Asset_ID,productiondate,shift,hour,equipment,downtimecode_id,minutes,comments,PartNumber,StartTime,EndTime,DT_Id)values(@Asset_ID,@date,@shift,@hour,@equipment,@downtimecode,@minutes,@comments,@PartNumber,@StartTime,@EndTime,@DT_Id) select @@IDENTITY"
            cmd.Connection = Cn

            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Asset_ID", SqlDbType.Int)
            cmd.Parameters.Add("@date", SqlDbType.VarChar)
            cmd.Parameters.Add("@shift", SqlDbType.VarChar)
            cmd.Parameters.Add("@hour", SqlDbType.VarChar)
            cmd.Parameters.Add("@equipment", SqlDbType.Int)
            cmd.Parameters.Add("@downtimecode", SqlDbType.Int)
            cmd.Parameters.Add("@minutes", SqlDbType.Float)
            cmd.Parameters.Add("@comments", SqlDbType.Text)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar)
            cmd.Parameters.Add("@StartTime", SqlDbType.VarChar)
            cmd.Parameters.Add("@EndTime", SqlDbType.VarChar)
            cmd.Parameters.Add("@DT_Id", SqlDbType.Int)

            cmd.Parameters("@Asset_ID").Value = Asset
            cmd.Parameters("@date").Value = productiondate
            cmd.Parameters("@shift").Value = shift
            cmd.Parameters("@hour").Value = Hour
            cmd.Parameters("@equipment").Value = equipment
            cmd.Parameters("@downtimecode").Value = downtimecode
            cmd.Parameters("@minutes").Value = minutes
            cmd.Parameters("@comments").Value = comments
            cmd.Parameters("@PartNumber").Value = PartNumber
            cmd.Parameters("@StartTime").Value = StartTime
            cmd.Parameters("@EndTime").Value = EndTime
            cmd.Parameters("@DT_Id").Value = DT_ID

            If equipment < 0 Then cmd.Parameters("@equipment").Value = DBNull.Value
            If downtimecode < 0 Then cmd.Parameters("@downtimecode").Value = DBNull.Value
            If DT_ID < 0 Then cmd.Parameters("@DT_Id").Value = DBNull.Value

            Dim retval As Integer
            retval = CInt(cmd.ExecuteScalar)

            cmd.Parameters.Clear()

            Return retval

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function NewDowntimeSplit(ByVal Original_ID As Integer, ByVal minutes As Double) As Integer
        Dim trn As SqlClient.SqlTransaction
        Try

            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            trn = Cn.BeginTransaction

            cmd.CommandText = "update downtime set Minutes=Minutes - @Minutes where ID = @ID"
            cmd.Connection = Cn
            cmd.Transaction = trn

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Minutes", minutes)
            cmd.Parameters.AddWithValue("@ID", Original_ID)


            cmd.ExecuteNonQuery()

            cmd.CommandText = "insert into downtime(Asset_ID,productiondate,shift,hour,minutes,PartNumber,StartTime,EndTime,DT_Id) " & _
                " select Asset_ID,productiondate,shift,hour,minutes,PartNumber,StartTime,EndTime,DT_Id from downtime where ID=@ID " & _
                " select @@IDENTITY"

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@ID", Original_ID)

            Dim retval As Integer
            retval = CInt(cmd.ExecuteScalar)

            cmd.CommandText = "update downtime set minutes=@Minutes where ID=@ID"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Minutes", minutes)
            cmd.Parameters.AddWithValue("@ID", retval)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            trn.Commit()
            Return retval
        Catch ex As Exception
            trn.Rollback()
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
            cmd.Transaction = Nothing
        End Try
    End Function

    Shared Function EditDowntime(ByVal ELID As Integer, ByVal Hour As String, ByVal equipment As String, ByVal downtimecode As Integer, ByVal minutes As Double, ByVal comments As String, ByVal PartNumber As String) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()

            cmd.CommandText = "Update downtime set hour=@hour,equipment=@equipment ,downtimecode_id=@downtimecode ,minutes=@minutes,comments=@comments,PartNumber=@PartNumber Where ID=" & ELID.ToString
            cmd.Connection = Cn
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@hour", SqlDbType.VarChar)
            cmd.Parameters.Add("@equipment", SqlDbType.Int)
            cmd.Parameters.Add("@downtimecode", SqlDbType.Int)
            cmd.Parameters.Add("@minutes", SqlDbType.Float)
            cmd.Parameters.Add("@comments", SqlDbType.Text)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar)


            cmd.Parameters("@hour").Value = Hour
            cmd.Parameters("@equipment").Value = equipment
            cmd.Parameters("@downtimecode").Value = downtimecode
            cmd.Parameters("@minutes").Value = minutes
            cmd.Parameters("@comments").Value = comments
            cmd.Parameters("@PartNumber").Value = PartNumber

            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function DeleteDowntime(ByVal ID As Integer) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "delete from Downtime where id=" & ID.ToString
            cmd.Connection = Cn
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function GetDowntime(ByVal asset_ID As Integer, ByVal productiondate As Date, ByVal shift As String) As DataTable
        Try
            'comment
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            'da.SelectCommand.CommandText = "SELECT DT.ID,DT.Asset_ID,dt.ProductionDate,DT.Shift,Dt.Hour,Dt.PartNumber,s.Station,E.Equipment,D.Department,C.Concept,dtc.Description,DT.Minutes,dt.Comments from Downtime DT inner join Equipment E on DT.Equipment = e.ID inner join Stations S on e.Station =s.ID inner join DowntimeCodes DTC on DT.DowntimeCode_ID = DTC.ID inner join Concepts C on DTC.Concept_ID = C.ID inner join Departments D on c.Department_ID = D.ID  " & _
            '"where DT.asset_ID = " & asset_ID.ToString & " and DT.productiondate='" & productiondate.ToString("MM/dd/yyyy") & "' and DT.Shift = '" & shift & "' order by dt.Hour,dt.ID"

            da.SelectCommand.CommandText = "SELECT DT.ID,DT.Asset_ID,dt.ProductionDate,DT.Shift,Dt.Hour,Dt.PartNumber,s.Station,E.Equipment,ISNULL(D.Department,'') AS Department,C.Concept,dtc.Description,DT.Minutes,dt.Comments,dt.DT_Id from Downtime DT left outer join Equipment E on DT.Equipment = e.ID left outer join Stations S on e.Station =s.ID left outer join DowntimeCodes DTC on DT.DowntimeCode_ID = DTC.ID left outer join Concepts C on DTC.Concept_ID = C.ID left outer join Departments D on c.Department_ID = D.ID  " & _
            "where DT.asset_ID = " & asset_ID.ToString & " and DT.productiondate='" & productiondate.ToString("MM/dd/yyyy") & "' and DT.Shift = '" & shift & "' order by dt.Hour,dt.ID"

            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "Downtime")

            Return ds.Tables("Downtime")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try

    End Function

    Shared Function GetDownTimeBYID(ByVal id As Integer) As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select Dt.*,st.ID as station,con.ID as concept,dep.ID as department from Downtime Dt left outer join Equipment eq on dt.Equipment = eq.id left outer join Stations st on eq.Station = st.id left outer join DowntimeCodes DTC on dt.DowntimeCode_ID=DTC.ID left outer join Concepts Con on dtc.Concept_ID=con.ID left outer join Departments dep on Con.Department_ID = dep.ID  where DT.ID=" & id.ToString
            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "downtime")
            Cn.Close()
            Return ds.Tables("downtime")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

#End Region

#Region "Adjustments"
    Shared Function NewAdjustment(ByVal Asset As Integer, ByVal productiondate As String, ByVal shift As String, ByVal Hour As String, ByVal Quantity As Integer, ByVal comments As String, ByRef PartNumber As String) As Integer
        Try
            If String.IsNullOrEmpty(productiondate) Or String.IsNullOrEmpty(shift) Or String.IsNullOrEmpty(Hour) Or Quantity = 0 Then
                Throw New Exception("Data Validation not passed")
            End If

            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()

            cmd.CommandText = "insert into Adjustments(Asset_ID,productiondate,shift,hour,Quantity,comments,PartNumber)values(@Asset_ID,@date,@shift,@hour,@quantity,@comments,@PartNumber) select @@IDENTITY"
            cmd.Connection = Cn

            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Asset_ID", SqlDbType.Int)
            cmd.Parameters.Add("@date", SqlDbType.VarChar)
            cmd.Parameters.Add("@shift", SqlDbType.VarChar)
            cmd.Parameters.Add("@hour", SqlDbType.VarChar)
            cmd.Parameters.Add("@quantity", SqlDbType.Float)
            cmd.Parameters.Add("@comments", SqlDbType.Text)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar)

            cmd.Parameters("@Asset_ID").Value = Asset
            cmd.Parameters("@date").Value = productiondate
            cmd.Parameters("@shift").Value = shift
            cmd.Parameters("@hour").Value = Hour
            cmd.Parameters("@quantity").Value = Quantity
            cmd.Parameters("@comments").Value = comments
            cmd.Parameters("@PartNumber").Value = PartNumber

            Dim retval As Integer
            retval = CInt(cmd.ExecuteScalar)

            cmd.Parameters.Clear()

            Return retval

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function EditAdjustment(ByVal ELID As Integer, ByVal Hour As String, ByVal Quantity As Integer, ByVal comments As String, ByVal PartNumber As String) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()

            cmd.CommandText = "Update Adjustments set hour=@hour,Quantity=@quantity,comments=@comments,PartNumber=@PartNumber Where ID=" & ELID.ToString
            cmd.Connection = Cn
            cmd.Parameters.Clear()

            cmd.Parameters.Add("@hour", SqlDbType.VarChar)
            cmd.Parameters.Add("@quantity", SqlDbType.Float)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar)
            cmd.Parameters.Add("@comments", SqlDbType.Text)


            cmd.Parameters("@hour").Value = Hour
            cmd.Parameters("@quantity").Value = Quantity
            cmd.Parameters("@PartNumber").Value = PartNumber
            cmd.Parameters("@comments").Value = comments


            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()

            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function DeleteAdjustment(ByVal ID As Integer) As Integer
        Try
            ''mms
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "delete from Adjustments where id=" & ID.ToString
            cmd.Connection = Cn
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function
    Shared Function DeleteResource(ByVal ID As Integer) As Integer
        Try
            ''mms
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "delete from Asset where id=" & ID.ToString
            cmd.Connection = Cn
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function
    Shared Function GetAdjustments(ByVal asset_ID As Integer, ByVal productiondate As Date, ByVal shift As String) As DataTable
        Try
            'comment
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select * from Adjustments " & _
            "where asset_ID = " & asset_ID.ToString & " and productiondate='" & productiondate.ToString("MM/dd/yyyy") & "' and Shift = '" & shift & "' order by Hour,ID"

            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "Downtime")

            Return ds.Tables("Downtime")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function GetAdjustmentBYID(ByVal id As Integer) As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select * from Adjustments where ID=" & id.ToString
            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "Adjustment")
            Cn.Close()
            Return ds.Tables("Adjustment")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

#End Region

#Region "Rework"
    Shared Function NewRework(ByVal Asset As Integer, ByVal productiondate As String, ByVal shift As String, ByVal Hour As String, ByVal ReasonCode As Integer, ByVal Feature As Integer, ByVal quantity As Double, ByVal comments As String, ByVal PartNumber As String, ByVal scrap As Boolean) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "insert into Rework(Asset_ID,productiondate,shift,hour,ReworkCode,Feature,Quantity,Comments,PartNumber,scrap)values(@Asset_ID,@date,@shift,@hour,@ReworkCode,@feature,@minutes,@comments,@PartNumber,@Scrap) select @@IDENTITY"
            cmd.Connection = Cn

            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Asset_ID", SqlDbType.Int)
            cmd.Parameters.Add("@date", SqlDbType.VarChar)
            cmd.Parameters.Add("@shift", SqlDbType.VarChar)
            cmd.Parameters.Add("@hour", SqlDbType.VarChar)
            cmd.Parameters.Add("@ReworkCode", SqlDbType.Int)
            cmd.Parameters.Add("@feature", SqlDbType.Int)
            cmd.Parameters.Add("@minutes", SqlDbType.Float)
            cmd.Parameters.Add("@comments", SqlDbType.Text)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar)
            cmd.Parameters.Add("@Scrap", SqlDbType.Bit)

            cmd.Parameters("@Asset_ID").Value = Asset
            cmd.Parameters("@date").Value = productiondate
            cmd.Parameters("@shift").Value = shift
            cmd.Parameters("@hour").Value = Hour
            cmd.Parameters("@ReworkCode").Value = ReasonCode
            cmd.Parameters("@feature").Value = Feature
            cmd.Parameters("@minutes").Value = quantity
            cmd.Parameters("@comments").Value = comments
            cmd.Parameters("@PartNumber").Value = PartNumber
            cmd.Parameters("@Scrap").Value = scrap

            Dim retval As Integer
            retval = CInt(cmd.ExecuteScalar)

            cmd.Parameters.Clear()

            Return retval

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function EditRework(ByVal ID As Integer, ByVal Hour As String, ByVal ReasonCode As Integer, ByVal Feature As Integer, ByVal quantity As Double, ByVal comments As String, ByVal PartNumber As String, ByVal scrap As Boolean) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "Update Rework set hour = @hour,ReworkCode =@ReworkCode ,Feature = @feature,Quantity = @minutes,Comments =@comments,PartNumber=@PartNumber,Scrap=@Scrap  where ID=" & ID.ToString
            cmd.Connection = Cn

            cmd.Parameters.Clear()

            cmd.Parameters.Add("@hour", SqlDbType.VarChar)
            cmd.Parameters.Add("@ReworkCode", SqlDbType.Int)
            cmd.Parameters.Add("@feature", SqlDbType.Int)
            cmd.Parameters.Add("@minutes", SqlDbType.Float)
            cmd.Parameters.Add("@comments", SqlDbType.Text)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar)
            cmd.Parameters.Add("@Scrap", SqlDbType.Bit)


            cmd.Parameters("@hour").Value = Hour
            cmd.Parameters("@ReworkCode").Value = ReasonCode
            cmd.Parameters("@feature").Value = Feature
            cmd.Parameters("@minutes").Value = quantity
            cmd.Parameters("@comments").Value = comments
            cmd.Parameters("@PartNumber").Value = PartNumber
            cmd.Parameters("@Scrap").Value = scrap

            Dim retval As Integer
            retval = CInt(cmd.ExecuteScalar)

            cmd.Parameters.Clear()

            Return retval

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function DeleteRework(ByVal ID As Integer) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "delete from Rework where id=" & ID.ToString
            cmd.Connection = Cn
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function GetRework(ByVal asset_ID As Integer, ByVal productiondate As Date, ByVal shift As String) As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select R.ID,R.Asset_ID,R.ProductionDate,R.Shift,R.Hour,R.PartNumber,RWC.Description as Concept,RC.Description as Code,PF.Description as Feature,R.Quantity,r.scrap,r.Comments from rework R inner join Reworkcodes RC on R.ReworkCode=RC.ID inner join ReworkConcepts RWC on RC.ReworkConcept_ID=RWC.ID inner join PartFeatures PF on R.Feature=PF.ID " & _
            "where R.asset_ID = " & asset_ID.ToString & " and R.productiondate='" & productiondate.ToString("MM/dd/yyyy") & "' and R.Shift = '" & shift & "'"
            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "rework")

            Return ds.Tables("rework")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function GetReworkByID(ByVal elid As Integer) As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select r.*,RCS.ID as Concept from Rework R inner join ReworkCodes RC on r.ReworkCode=rc.ID inner join ReworkConcepts RCS on RC.ReworkConcept_ID =  RCS.ID Where R.id=" & elid.ToString
            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "rework")
            Return ds.Tables("rework")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function




#End Region

#Region "PlannedDowntime"

    Shared Function NewPlannedDowntime(ByVal Asset As Integer, ByVal productiondate As String, ByVal shift As String, ByVal Hour As String, ByVal ReasonCode As Integer, ByVal minutes As Double, ByVal comments As String, ByVal PartNumber As String, Optional ByVal dtid As Integer = 0) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "insert into PlannedDT(Asset_ID,productiondate,shift,hour,PlannedDTRC_ID,minutes,comments,PartNumber,DT_Id)values(@Asset_ID,@date,@shift,@hour,@PlannedDTRC,@minutes,@comments,@PartNumber,@dtid) select @@IDENTITY"
            cmd.Connection = Cn

            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Asset_ID", SqlDbType.Int)
            cmd.Parameters.Add("@date", SqlDbType.VarChar)
            cmd.Parameters.Add("@shift", SqlDbType.VarChar)
            cmd.Parameters.Add("@hour", SqlDbType.VarChar)
            cmd.Parameters.Add("@PlannedDTRC", SqlDbType.Int)
            cmd.Parameters.Add("@minutes", SqlDbType.Float)
            cmd.Parameters.Add("@comments", SqlDbType.Text)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar)
            cmd.Parameters.Add("@dtid", SqlDbType.Int)

            cmd.Parameters("@Asset_ID").Value = Asset
            cmd.Parameters("@date").Value = productiondate
            cmd.Parameters("@shift").Value = shift
            cmd.Parameters("@hour").Value = Hour
            cmd.Parameters("@PlannedDTRC").Value = ReasonCode
            cmd.Parameters("@minutes").Value = minutes
            cmd.Parameters("@comments").Value = comments
            cmd.Parameters("@PartNumber").Value = PartNumber
            cmd.Parameters("@dtid").Value = IIf(dtid <> 0, dtid, DBNull.Value)

            Dim retval As Integer
            retval = CInt(cmd.ExecuteScalar)

            cmd.Parameters.Clear()

            Return retval

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function EditPlannedDowntime(ByVal ELID As Integer, ByVal Hour As String, ByVal ReasonCode As Integer, ByVal minutes As Double, ByVal comments As String, ByVal PartNumber As String) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "Update PlannedDT set hour= @hour,PlannedDTRC_ID =@PlannedDTRC ,minutes = @minutes,comments =@comments, PartNumber=@PartNumber   Where ID= " & ELID.ToString
            cmd.Connection = Cn

            cmd.Parameters.Clear()

            cmd.Parameters.Add("@hour", SqlDbType.VarChar)
            cmd.Parameters.Add("@PlannedDTRC", SqlDbType.Int)
            cmd.Parameters.Add("@minutes", SqlDbType.Float)
            cmd.Parameters.Add("@comments", SqlDbType.Text)
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar)

            cmd.Parameters("@hour").Value = Hour
            cmd.Parameters("@PlannedDTRC").Value = ReasonCode
            cmd.Parameters("@minutes").Value = minutes
            cmd.Parameters("@comments").Value = comments
            cmd.Parameters("@PartNumber").Value = PartNumber

            Dim retval As Integer
            retval = CInt(cmd.ExecuteScalar)
            cmd.Parameters.Clear()
            Return retval

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function DeletePlannedDownTime(ByVal ID As Integer) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "delete from PlannedDT where id=" & ID.ToString
            cmd.Connection = Cn
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function
    Shared Function DeleteDownTimeByRef(ByVal RefID As Integer) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "delete from Downtime where DT_Id=" & RefID.ToString
            cmd.Connection = Cn
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function
    Shared Function DeletePlannedDownTimeByRef(ByVal RefID As Integer) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "delete from PlannedDT where DT_Id=" & RefID.ToString
            cmd.Connection = Cn
            cmd.ExecuteNonQuery()
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function GetPlannedDT(ByVal asset_ID As Integer, ByVal productiondate As Date, ByVal shift As String) As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select pdt.ID,pdt.Asset_ID,pdt.ProductionDate,pdt.Shift,pdt.Hour,pdt.PartNumber,rc.Description,pdt.minutes,pdt.comments,pdt.DT_Id from planneddt pdt inner join planneddtrc rc on pdt.planneddtrc_id=rc.id " & _
            "where pdt.asset_ID = " & asset_ID.ToString & " and pdt.productiondate='" & productiondate.ToString("MM/dd/yyyy") & "' and shift = '" & shift & "'"

            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "planneddowntime")
            Cn.Close()
            Return ds.Tables("planneddowntime")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function GetPlannedDownTimeByID(ByVal ID As Integer) As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            ''da.SelectCommand.CommandText = "select Dt.*,st.ID as station,con.ID as concept,dep.ID as department from Downtime Dt left outer join Equipment eq on dt.Equipment = eq.id left outer join Stations st on eq.Station = st.id left outer join DowntimeCodes DTC on dt.DowntimeCode_ID=DTC.ID left outer join Concepts Con on dtc.Concept_ID=con.ID left outer join Departments dep on Con.Department_ID = dep.ID  where DT.ID=" & id.ToString
            da.SelectCommand.CommandText = "select * from PlannedDT where ID=" & ID.ToString
            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "downtime")
            Cn.Close()
            Return ds.Tables("downtime")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

#End Region

#Region "Report"

    Shared Function NewReport(ByVal Asset As Integer, ByVal productiondate As Date, ByVal shift As String, ByVal TotalProduced As Integer, ByVal Availability As Double, ByVal Eficiency As Double, ByVal Quality As Double, ByVal OEE As Double, ByVal JPH As Integer, ByVal Hours As Double, ByVal PlannedProductionTime As Double, ByVal OperatingTime As Double, ByVal shiftstarttime As DateTime, ByVal shiftendtime As DateTime, ByVal Downtime As Double, ByVal planneddowntime As Double, ByVal rejectedparts As Integer) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()

            cmd.CommandText = "insert into Report(Asset_ID,productiondate,shift,TotalProduced,Availability,Eficiency,Quality,OEE,JPH,Hours,PlannedProductionTime,OperatingTime,shiftstarttime,shiftendtime,Downtime,PlannedDowntime,TotalRejected,Usuario) " & _
            "values(@Asset_ID,@productiondate,@shift,@TotalProduced,@Availability,@Eficiency,@Quality,@OEE,@JPH,@Hours,@PlannedProductionTime,@OperatingTime,@shiftstarttime,@shiftendtime,@Downtime,@PlannedDowntime,@TotalRejected,@Usuario) select @@IDENTITY"
            cmd.Connection = Cn

            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Asset_ID", SqlDbType.Int)
            cmd.Parameters.Add("@productiondate", SqlDbType.Date)
            cmd.Parameters.Add("@shift", SqlDbType.VarChar)
            cmd.Parameters.Add("@TotalProduced", SqlDbType.Int)
            cmd.Parameters.Add("@Availability", SqlDbType.Float)
            cmd.Parameters.Add("@Eficiency", SqlDbType.Float)
            cmd.Parameters.Add("@Quality", SqlDbType.Float)
            cmd.Parameters.Add("@OEE", SqlDbType.Float)
            cmd.Parameters.Add("@JPH", SqlDbType.Int)
            cmd.Parameters.Add("@Hours", SqlDbType.Float)
            cmd.Parameters.Add("@PlannedProductionTime", SqlDbType.Float)
            cmd.Parameters.Add("@OperatingTime", SqlDbType.Float)
            cmd.Parameters.Add("@shiftstarttime", SqlDbType.DateTime)
            cmd.Parameters.Add("@shiftendtime", SqlDbType.DateTime)
            cmd.Parameters.Add("@Downtime", SqlDbType.Float)
            cmd.Parameters.Add("@PlannedDowntime", SqlDbType.Float)
            cmd.Parameters.Add("@TotalRejected", SqlDbType.Int)
            cmd.Parameters.Add("@Usuario", SqlDbType.Int)

            cmd.Parameters("@Asset_ID").Value = Asset
            cmd.Parameters("@productiondate").Value = productiondate
            cmd.Parameters("@shift").Value = shift
            cmd.Parameters("@TotalProduced").Value = TotalProduced
            cmd.Parameters("@Availability").Value = Availability
            cmd.Parameters("@Eficiency").Value = Eficiency
            cmd.Parameters("@Quality").Value = Quality
            cmd.Parameters("@OEE").Value = OEE
            cmd.Parameters("@JPH").Value = JPH
            cmd.Parameters("@Hours").Value = Hours
            cmd.Parameters("@PlannedProductionTime").Value = PlannedProductionTime
            cmd.Parameters("@OperatingTime").Value = OperatingTime
            cmd.Parameters("@shiftstarttime").Value = shiftstarttime
            cmd.Parameters("@shiftendtime").Value = shiftendtime
            cmd.Parameters("@Downtime").Value = Downtime
            cmd.Parameters("@PlannedDowntime").Value = planneddowntime
            cmd.Parameters("@TotalRejected").Value = rejectedparts
            cmd.Parameters("@Usuario").Value = My.Settings.UserId

            Dim retval As Integer
            retval = CInt(cmd.ExecuteScalar)
            cmd.Parameters.Clear()
            Return retval
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function SaveReportDetails(ByVal ReportID As Integer, ByVal part As String, ByVal jph As Integer, ByVal H1 As Integer, ByVal H2 As Integer, ByVal H3 As Integer, ByVal H4 As Integer, ByVal H5 As Integer, ByVal H6 As Integer, ByVal H7 As Integer, ByVal H8 As Integer, ByVal H9 As Integer, ByVal H10 As Integer, ByVal H11 As Integer, ByVal H12 As Integer, ByVal H13 As Integer, ByVal H14 As Integer, ByVal Total As Integer, ByVal start As String, ByVal [End] As String, ByVal Hours As Double, ByVal PPT As Double, ByVal OT As Double, ByVal Downtime As Double, ByVal PlannedDowntime As Double, ByVal Rejected As Double, ByVal Availability As Double, ByVal Performance As Double, ByVal Quality As Double, ByVal OEE As Double)

        Try

            If Double.IsNaN(Quality) Then Quality = 0
            If Double.IsNaN(OEE) Then OEE = 0


            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.Connection = Cn
            cmd.Parameters.Clear()

            cmd.CommandText = "insert into reportdetail(ReportID,Part,JPH,H1,H2,H3,H4,H5,H6,H7,H8,H9,H10,H11,H12,H13,H14,TOTAL,Start,[End],Hours,PPT,OT,Downtime,PlannedDowntime,Rejected,Availability,Performance,Quality,OEE) VALUES" & _
            "(@ReportID,@Part,@JPH,@H1,@H2,@H3,@H4,@H5,@H6,@H7,@H8,@H9,@H10,@H11,@H12,@H13,@H14,@TOTAL,@Start,@End,@Hours,@PPT,@OT,@Downtime,@PlannedDowntime,@Rejected,@Availability,@Performance,@Quality,@OEE)"

            cmd.Parameters.Add("@ReportID", SqlDbType.Int)
            cmd.Parameters.Add("@Part", SqlDbType.VarChar)
            cmd.Parameters.Add("@JPH", SqlDbType.Int)
            cmd.Parameters.Add("@H1", SqlDbType.Int)
            cmd.Parameters.Add("@H2", SqlDbType.Int)
            cmd.Parameters.Add("@H3", SqlDbType.Int)
            cmd.Parameters.Add("@H4", SqlDbType.Int)
            cmd.Parameters.Add("@H5", SqlDbType.Int)
            cmd.Parameters.Add("@H6", SqlDbType.Int)
            cmd.Parameters.Add("@H7", SqlDbType.Int)
            cmd.Parameters.Add("@H8", SqlDbType.Int)
            cmd.Parameters.Add("@H9", SqlDbType.Int)
            cmd.Parameters.Add("@H10", SqlDbType.Int)
            cmd.Parameters.Add("@H11", SqlDbType.Int)
            cmd.Parameters.Add("@H12", SqlDbType.Int)
            cmd.Parameters.Add("@H13", SqlDbType.Int)
            cmd.Parameters.Add("@H14", SqlDbType.Int)
            cmd.Parameters.Add("@TOTAL", SqlDbType.Int)
            cmd.Parameters.Add("@Start", SqlDbType.VarChar)
            cmd.Parameters.Add("@End", SqlDbType.VarChar)
            cmd.Parameters.Add("@Hours", SqlDbType.Float)
            cmd.Parameters.Add("@PPT", SqlDbType.Float)
            cmd.Parameters.Add("@OT", SqlDbType.Float)
            cmd.Parameters.Add("@Downtime", SqlDbType.Float)
            cmd.Parameters.Add("@PlannedDowntime", SqlDbType.Float)
            cmd.Parameters.Add("@Rejected", SqlDbType.Float)
            cmd.Parameters.Add("@Availability", SqlDbType.Float)
            cmd.Parameters.Add("@Performance", SqlDbType.Float)
            cmd.Parameters.Add("@Quality", SqlDbType.Float)
            cmd.Parameters.Add("@OEE", SqlDbType.Float)


            cmd.Parameters("@ReportID").Value = ReportID
            cmd.Parameters("@Part").Value = part
            cmd.Parameters("@JPH").Value = jph
            cmd.Parameters("@H1").Value = H1
            cmd.Parameters("@H2").Value = H2
            cmd.Parameters("@H3").Value = H3
            cmd.Parameters("@H4").Value = H4
            cmd.Parameters("@H5").Value = H5
            cmd.Parameters("@H6").Value = H6
            cmd.Parameters("@H7").Value = H7
            cmd.Parameters("@H8").Value = H8
            cmd.Parameters("@H9").Value = H9
            cmd.Parameters("@H10").Value = H10
            cmd.Parameters("@H11").Value = H11
            cmd.Parameters("@H12").Value = H12
            cmd.Parameters("@H13").Value = H13
            cmd.Parameters("@H14").Value = H14
            cmd.Parameters("@TOTAL").Value = Total
            cmd.Parameters("@Start").Value = start
            cmd.Parameters("@End").Value = [End]
            cmd.Parameters("@Hours").Value = Hours
            cmd.Parameters("@PPT").Value = PPT
            cmd.Parameters("@OT").Value = OT
            cmd.Parameters("@Downtime").Value = Downtime
            cmd.Parameters("@PlannedDowntime").Value = PlannedDowntime
            cmd.Parameters("@Rejected").Value = Rejected
            cmd.Parameters("@Availability").Value = Availability
            cmd.Parameters("@Performance").Value = Performance
            cmd.Parameters("@Quality").Value = Quality
            cmd.Parameters("@OEE").Value = OEE

            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()


            Return 1
        Catch ex As Exception

            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function EditReport(ByVal ELID As Integer, ByVal TotalProduced As Integer, ByVal Availability As Double, ByVal Eficiency As Double, ByVal Quality As Double, ByVal OEE As Double, ByVal JPH As Integer, ByVal Hours As Double, ByVal PlannedProductionTime As Double, ByVal OperatingTime As Double, ByVal shiftstarttime As DateTime, ByVal shiftendtime As DateTime, ByVal Downtime As Double, ByVal planneddowntime As Double, ByVal rejectedparts As Integer) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()

            cmd.CommandText = "Update Report set TotalProduced = @TotalProduced,Availability =@Availability,Eficiency =@Eficiency,Quality =@Quality,OEE =@OEE, " & _
            "JPH =@JPH,Hours=@Hours,PlannedProductionTime =@PlannedProductionTime,Operatingtime=@OperatingTime,shiftstarttime =@shiftstarttime,shiftendtime =@shiftendtime,Downtime=@Downtime,PlannedDowntime=@PlannedDowntime,TotalRejected=@TotalRejected, UsuarioUM = @UsuarioUM,FechaUM = getdate() Where ID = " & ELID.ToString

            cmd.Connection = Cn

            cmd.Parameters.Clear()

            cmd.Parameters.Add("@TotalProduced", SqlDbType.Int)
            cmd.Parameters.Add("@Availability", SqlDbType.Float)
            cmd.Parameters.Add("@Eficiency", SqlDbType.Float)
            cmd.Parameters.Add("@Quality", SqlDbType.Float)
            cmd.Parameters.Add("@OEE", SqlDbType.Float)
            cmd.Parameters.Add("@JPH", SqlDbType.Int)
            cmd.Parameters.Add("@Hours", SqlDbType.Float)
            cmd.Parameters.Add("@PlannedProductionTime", SqlDbType.Float)
            cmd.Parameters.Add("@OperatingTime", SqlDbType.Float)
            cmd.Parameters.Add("@shiftstarttime", SqlDbType.DateTime)
            cmd.Parameters.Add("@shiftendtime", SqlDbType.DateTime)
            cmd.Parameters.Add("@Downtime", SqlDbType.Float)
            cmd.Parameters.Add("@PlannedDowntime", SqlDbType.Float)
            cmd.Parameters.Add("@TotalRejected", SqlDbType.Int)
            cmd.Parameters.Add("@UsuarioUM", SqlDbType.Int)

            cmd.Parameters("@TotalProduced").Value = TotalProduced
            cmd.Parameters("@Availability").Value = Availability
            cmd.Parameters("@Eficiency").Value = Eficiency
            cmd.Parameters("@Quality").Value = Quality
            cmd.Parameters("@OEE").Value = OEE
            cmd.Parameters("@JPH").Value = JPH
            cmd.Parameters("@Hours").Value = Hours
            cmd.Parameters("@PlannedProductionTime").Value = PlannedProductionTime
            cmd.Parameters("@OperatingTime").Value = OperatingTime
            cmd.Parameters("@shiftstarttime").Value = shiftstarttime
            cmd.Parameters("@shiftendtime").Value = shiftendtime
            cmd.Parameters("@Downtime").Value = Downtime
            cmd.Parameters("@PlannedDowntime").Value = planneddowntime
            cmd.Parameters("@TotalRejected").Value = rejectedparts
            cmd.Parameters("@UsuarioUM").Value = My.Settings.UserId

            Dim retval As Integer
            retval = CInt(cmd.ExecuteScalar)
            cmd.Parameters.Clear()
            Return retval
        Catch ex As Exception
            Throw New Exception("Edit Report " & ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function
    Shared Function DeleteEntireReport(ByVal ELID As Integer) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()

            Dim Assetid As Integer
            Dim PrdDate As Date

            cmd.Connection = Cn
            cmd.Parameters.Clear()

            cmd.CommandText = "SELECT Asset_ID FROM Report where ID = " & ELID.ToString
            Assetid = cmd.ExecuteScalar

            cmd.CommandText = "SELECT ProductionDate FROM Report where ID = " & ELID.ToString
            PrdDate = cmd.ExecuteScalar

            cmd.CommandText = "DELETE FROM Downtime where Asset_ID=" & Assetid.ToString & " AND ProductionDate='" & PrdDate.ToString("MM/dd/yyyy") & "'"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "DELETE FROM PlannedDT where Asset_ID=" & Assetid.ToString & " AND ProductionDate='" & PrdDate.ToString("MM/dd/yyyy") & "'"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "DELETE FROM Rework where Asset_ID=" & Assetid.ToString & " AND ProductionDate='" & PrdDate.ToString("MM/dd/yyyy") & "'"
            cmd.ExecuteNonQuery()


            cmd.CommandText = "DELETE FROM  Report where ID=" & ELID.ToString

            cmd.ExecuteNonQuery()

            cmd.CommandText = "DELETE FROM ReportDetail WHERE ReportID=" & ELID.ToString
            cmd.ExecuteNonQuery()

            Cn.Close()

            'DeleteReportDetails(ELID)
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function
    Shared Function DeleteReport(ByVal ELID As Integer) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()

            Dim Assetid As Integer
            Dim PrdDate As String

            cmd.Connection = Cn
            cmd.Parameters.Clear()

            'cmd.CommandText = "SELECT Asset_ID FROM Report where ID = " & ELID.ToString
            'Assetid = cmd.ExecuteScalar

            'cmd.CommandText = "SELECT ProductionDate FROM Report where ID = " & ELID.ToString
            'PrdDate = cmd.ExecuteScalar

            'cmd.CommandText = "DELETE FROM Downtime where Asset_ID=" & Assetid.ToString & " AND ProductionDate='" & Format(PrdDate, "MM/dd/yyyy") & "'"
            'cmd.ExecuteNonQuery()

            'cmd.CommandText = "DELETE FROM PlannedDT where Asset_ID=" & Assetid.ToString & " AND ProductionDate='" & Format(PrdDate, "MM/dd/yyyy") & "'"
            'cmd.ExecuteNonQuery()

            'cmd.CommandText = "DELETE FROM Rework where Asset_ID=" & Assetid.ToString & " AND ProductionDate='" & Format(PrdDate, "MM/dd/yyyy") & "'"
            'cmd.ExecuteNonQuery()


            cmd.CommandText = "DELETE FROM  Report where ID=" & ELID.ToString

            cmd.ExecuteNonQuery()

            cmd.CommandText = "DELETE FROM ReportDetail WHERE ReportID=" & ELID.ToString
            cmd.ExecuteNonQuery()

            Cn.Close()

            'DeleteReportDetails(ELID)
            Return 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function DeleteReportDetails(ByVal ReportID As Integer) As Boolean
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()


            cmd.CommandText = "delete from ReportDetail where ReportID=" & ReportID.ToString
            cmd.Connection = Cn
            cmd.Parameters.Clear()

            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
            Return False
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function GetReportID(ByVal asset_ID As Integer, ByVal productiondate As Date, ByVal shift As String) As Integer
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            cmd.CommandText = "select ID from Report where asset_ID = " & asset_ID.ToString & " and productiondate='" & productiondate.ToString("MM/dd/yyyy") & "' and Shift = '" & shift & "'"
            cmd.Connection = Cn
            cmd.Parameters.Clear()
            Dim retval As Integer
            retval = cmd.ExecuteScalar


            Return retval

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function

    Shared Function GetReportDetails(ByVal ElId As Integer) As DataTable
        Try
            Cn.ConnectionString = constring()
            If Cn.State = ConnectionState.Closed Then Cn.Open()
            da.SelectCommand.CommandText = "select * from ReportDetail where ReportID = " & ElId.ToString
            da.SelectCommand.Connection = Cn
            ds.Tables.Clear()
            da.Fill(ds, "ReportDetail")
            Cn.Close()
            Return ds.Tables("ReportDetail")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Cn.State = ConnectionState.Open Then Cn.Close()
        End Try
    End Function
#End Region

End Class

