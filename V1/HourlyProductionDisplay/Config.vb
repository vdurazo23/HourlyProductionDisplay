Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Public Class Config

    Private Sub Config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TxtMarsServer.Text = My.Settings.MARSServer
            TxtMARSUser.Text = My.Settings.MARSUser

            TxtMARSPwd.Text = Decrypt(My.Settings.MARSPwd)
            TxtMARSBd.Text = My.Settings.MARSBD

            TxtDSN.Text = My.Settings.DSN
            TxtUserCMS.Text = My.Settings.CMSUser
            TxtPwdCMS.Text = My.Settings.CMSPwd

            NumericUpDown1.Value = My.Settings.Timer

            If Not My.Settings.RESOURCES Is Nothing Then
                For i = 0 To My.Settings.RESOURCES.Rows.Count - 1
                    ListResources.Items.Add(My.Settings.RESOURCES.Rows(i).Item("ID").ToString)
                    ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(My.Settings.RESOURCES.Rows(i).Item("Name").ToString)
                    ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(My.Settings.RESOURCES.Rows(i).Item("Description").ToString)
                    ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(My.Settings.RESOURCES.Rows(i).Item("Code").ToString)
                    ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(My.Settings.RESOURCES.Rows(i).Item("DeviceCode").ToString)
                    ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(My.Settings.RESOURCES.Rows(i).Item("DepartmentCode").ToString)
                    ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(My.Settings.RESOURCES.Rows(i).Item("ResourceCode").ToString)
                    Try
                        ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(My.Settings.RESOURCES.Rows(i).Item("SubResourceID").ToString)
                    Catch ex As Exception
                        ListResources.Items(ListResources.Items.Count - 1).SubItems.Add("")
                    End Try
                Next
            End If

            If Not My.Settings.SLIDES Is Nothing Then
                For i = 0 To My.Settings.SLIDES.Rows.Count - 1
                    ListFiles.Items.Add(My.Settings.SLIDES.DefaultView.Item(i).Item(0).ToString)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Public Function Encrypt(ByVal plainText As String) As String
        Try
            Dim passPhrase As String = "MREADOWNTIME123"
            Dim saltValue As String = "vdurazo23"
            Dim hashAlgorithm As String = "SHA1"

            Dim passwordIterations As Integer = 2
            Dim initVector As String = "@1B2c3D4e5F6g7H8"
            Dim keySize As Integer = 256

            Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
            Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)

            Dim plainTextBytes As Byte() = Encoding.UTF8.GetBytes(plainText)


            Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)

            Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)
            Dim symmetricKey As New RijndaelManaged()

            symmetricKey.Mode = CipherMode.CBC

            Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)

            Dim memoryStream As New MemoryStream()
            Dim cryptoStream As New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)

            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
            cryptoStream.FlushFinalBlock()
            Dim cipherTextBytes As Byte() = memoryStream.ToArray()
            memoryStream.Close()
            cryptoStream.Close()
            Dim cipherText As String = Convert.ToBase64String(cipherTextBytes)
            Return cipherText
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function
    Public Function Decrypt(ByVal cipherText As String) As String
        Try
            Dim passPhrase As String = "MREADOWNTIME123"
            Dim saltValue As String = "vdurazo23"
            Dim hashAlgorithm As String = "SHA1"

            Dim passwordIterations As Integer = 2
            Dim initVector As String = "@1B2c3D4e5F6g7H8"
            Dim keySize As Integer = 256
            ' Convert strings defining encryption key characteristics into byte
            ' arrays. Let us assume that strings only contain ASCII codes.
            ' If strings include Unicode characters, use Unicode, UTF7, or UTF8
            ' encoding.
            Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
            Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)

            ' Convert our ciphertext into a byte array.
            Dim cipherTextBytes As Byte() = Convert.FromBase64String(cipherText)

            ' First, we must create a password, from which the key will be 
            ' derived. This password will be generated from the specified 
            ' passphrase and salt value. The password will be created using
            ' the specified hash algorithm. Password creation can be done in
            ' several iterations.
            Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)

            ' Use the password to generate pseudo-random bytes for the encryption
            ' key. Specify the size of the key in bytes (instead of bits).
            Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)

            ' Create uninitialized Rijndael encryption object.
            Dim symmetricKey As New RijndaelManaged()

            ' It is reasonable to set encryption mode to Cipher Block Chaining
            ' (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC

            ' Generate decryptor from the existing key bytes and initialization 
            ' vector. Key size will be defined based on the number of the key 
            ' bytes.
            Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)

            ' Define memory stream which will be used to hold encrypted data.
            Dim memoryStream As New MemoryStream(cipherTextBytes)

            ' Define cryptographic stream (always use Read mode for encryption).
            Dim cryptoStream As New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)

            ' Since at this point we don't know what the size of decrypted data
            ' will be, allocate the buffer long enough to hold ciphertext;
            ' plaintext is never longer than ciphertext.
            Dim plainTextBytes As Byte() = New Byte(cipherTextBytes.Length - 1) {}

            ' Start decrypting.
            Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)

            ' Close both streams.
            memoryStream.Close()
            cryptoStream.Close()

            ' Convert decrypted data into a string. 
            ' Let us assume that the original plaintext string was UTF8-encoded.
            Dim plainText As String = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)

            ' Return decrypted string.   
            Return plainText
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub BtnTest_Click(sender As Object, e As EventArgs) Handles BtnTest.Click
        Dim cn As New SqlClient.SqlConnection("Data Source=" & TxtMarsServer.Text.Trim & ";workstation id=;Persist Security Info=True;User ID=" & TxtMARSUser.Text & ";password=" & TxtMARSPwd.Text & ";initial catalog=" & TxtMARSBd.Text)
        Try
            cn.Open()
            MsgBox("Successfully connected" & vbCrLf & cn.DataSource.ToString & vbCrLf & cn.Database.ToString, MsgBoxStyle.Information, "Conexión")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Dispose()
            cn = Nothing
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim cn As New SqlClient.SqlConnection("Data Source=" & TxtMarsServer.Text.Trim & ";workstation id=;Persist Security Info=True;User ID=" & TxtMARSUser.Text & ";password=" & TxtMARSPwd.Text & ";initial catalog=" & TxtMARSBd.Text)
        Try
            cn.Open()
            My.Settings.MARSServer = TxtMarsServer.Text
            My.Settings.MARSUser = TxtMARSUser.Text
            My.Settings.MARSPwd = Encrypt(TxtMARSPwd.Text)
            My.Settings.MARSBD = TxtMARSBd.Text

            Dim Dt As New DataTable
            Dt.TableName = "RESOURCES"
            Dt.Columns.Add("ID")
            Dt.Columns.Add("Name")
            Dt.Columns.Add("Description")
            Dt.Columns.Add("Code")
            Dt.Columns.Add("DeviceCode")
            Dt.Columns.Add("DepartmentCode")
            Dt.Columns.Add("ResourceCode")
            Dt.Columns.Add("SubResourceID")

            For i = 0 To ListResources.Items.Count - 1
                Dim R As DataRow = Dt.NewRow
                R("ID") = ListResources.Items(i).Text
                R("Name") = ListResources.Items(i).SubItems(1).Text
                R("Description") = ListResources.Items(i).SubItems(2).Text
                R("Code") = ListResources.Items(i).SubItems(3).Text
                R("DeviceCode") = ListResources.Items(i).SubItems(4).Text
                R("DepartmentCode") = ListResources.Items(i).SubItems(5).Text
                R("ResourceCode") = ListResources.Items(i).SubItems(6).Text
                R("SubResourceID") = ListResources.Items(i).SubItems(7).Text
                Dt.Rows.Add(R)
            Next

            If My.Settings.RESOURCES Is Nothing Then
                My.Settings.RESOURCES = Dt
            Else
                My.Settings.RESOURCES.Rows.Clear()
                My.Settings.RESOURCES = Dt
            End If


            Dim DtSlides As New DataTable
            DtSlides.TableName = "SLIDES"
            DtSlides.Columns.Add("Filename")

            For i = 0 To ListFiles.Items.Count - 1
                Dim r2 As DataRow = DtSlides.NewRow
                r2("filename") = ListFiles.Items(i).Text
                DtSlides.Rows.Add(r2)
            Next

            If My.Settings.SLIDES Is Nothing Then
                My.Settings.SLIDES = DtSlides
            Else
                My.Settings.SLIDES.Rows.Clear()
                My.Settings.SLIDES = DtSlides
            End If

            My.Settings.DSN = TxtDSN.Text
            My.Settings.CMSUser = TxtUserCMS.Text
            My.Settings.CMSPwd = TxtPwdCMS.Text

            My.Settings.Timer = NumericUpDown1.Value

            My.Settings.Save()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            cn.Dispose()
            cn = Nothing
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cn As New SqlClient.SqlConnection("Data Source=" & TxtMarsServer.Text.Trim & ";workstation id=;Persist Security Info=True;User ID=" & TxtMARSUser.Text & ";password=" & TxtMARSPwd.Text & ";initial catalog=" & TxtMARSBd.Text)
        Try
            cn.Open()
            Dim ds As New DataSet
            Dim da As New SqlClient.SqlDataAdapter("Select A.ID,A.Name,A.Description,A.Code,A.DeviceCode,A.DepartmentCode,A.ResourceCode,SR.SubResourceOffset_ID as SubResourceID from pro.ResourceStatus RS inner join dbo.Asset A on RS.Asset_ID=A.ID inner join ref.SubResource SR on SR.Asset_ID=A.ID", cn)
            da.Fill(ds, "Resources")
            Dim frmsel As New SelectResource
            frmsel.dt = ds.Tables("Resources")
            If frmsel.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If frmsel.DataGridView1.CurrentRow.Index >= 0 Then
                    ListResources.Items.Add(frmsel.DataGridView1.CurrentRow.Cells(0).Value.ToString)
                    ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(frmsel.DataGridView1.CurrentRow.Cells(1).Value.ToString)
                    ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(frmsel.DataGridView1.CurrentRow.Cells(2).Value.ToString)
                    ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(frmsel.DataGridView1.CurrentRow.Cells(3).Value.ToString)
                    ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(frmsel.DataGridView1.CurrentRow.Cells(4).Value.ToString)
                    ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(frmsel.DataGridView1.CurrentRow.Cells(5).Value.ToString)
                    ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(frmsel.DataGridView1.CurrentRow.Cells(6).Value.ToString)
                    ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(frmsel.DataGridView1.CurrentRow.Cells(7).Value.ToString)
                End If
            End If

            frmsel.Dispose()
            frmsel = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            cn.Close()
            cn.Dispose()
            cn = Nothing
        End Try
    End Sub

    Private Sub ListResources_KeyUp(sender As Object, e As KeyEventArgs) Handles ListResources.KeyUp
        If ListResources.SelectedIndices.Count = 0 Then Exit Sub
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Are you sure ?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "Remove") = MsgBoxResult.Yes Then
                ListResources.Items.RemoveAt(ListResources.SelectedIndices(0))
            End If
        End If
    End Sub

    Private Sub ListResources_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListResources.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            OpenFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                ListFiles.Items.Add(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim Con As New Odbc.OdbcConnection("DSN=" & TxtDSN.Text & ";UID=" & TxtUserCMS.Text & ";PWD=" & TxtPwdCMS.Text)
            Con.Open()
            MsgBox("Successfully connected" & vbCrLf & Con.DataSource.ToString & vbCrLf & Con.Database.ToString, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "CMS")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ListFiles_KeyUp(sender As Object, e As KeyEventArgs) Handles ListFiles.KeyUp
        If ListFiles.SelectedIndices.Count = 0 Then Exit Sub
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Are you sure ?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "Remove") = MsgBoxResult.Yes Then
                ListFiles.Items.RemoveAt(ListFiles.SelectedIndices(0))
            End If
        End If
    End Sub

    Private Sub ListFiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListFiles.SelectedIndexChanged

    End Sub
End Class