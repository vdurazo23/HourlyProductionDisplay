Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Public Class Config

    Private Sub Config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Text = System.String.Format(Me.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        Catch ex As Exception

        End Try
        Try
            TxtMarsServer.Text = My.Settings.MARSServer
            TxtMARSUser.Text = My.Settings.MARSUser

            TxtMARSPwd.Text = Decrypt(My.Settings.MARSPwd)
            TxtMARSBd.Text = My.Settings.MARSBD

            TxtDSN.Text = My.Settings.DSN
            TxtUserCMS.Text = My.Settings.CMSUser
            TxtPwdCMS.Text = My.Settings.CMSPwd

            NumericUpDown1.Value = My.Settings.Timer

            If My.Settings.MARSServer = "192.168.114.99\mars" Then
                CheckBox1.Visible = True
                CheckBox1.Checked = My.Settings.HSPR01
            Else
                CheckBox1.Visible = False
                CheckBox1.Checked = False
            End If

            ChkShowAvg.Checked = My.Settings.SHOWAVG

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
            If My.Settings.MARSServer = "192.168.114.99\mars" Then
                CheckBox1.Visible = True
            End If
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

            If My.Settings.MARSServer = "192.168.114.99\mars" Then
                My.Settings.HSPR01 = CheckBox1.Checked
            Else
                My.Settings.HSPR01 = False
            End If

            My.Settings.SHOWAVG = ChkShowAvg.Checked

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

                    Dim textnew, textlist As String
                    textnew = frmsel.DataGridView1.CurrentRow.Cells(0).Value.ToString.Trim & "," & _
                            frmsel.DataGridView1.CurrentRow.Cells(1).Value.ToString.Trim & "," & _
                            frmsel.DataGridView1.CurrentRow.Cells(3).Value.ToString.Trim & "," & _
                            frmsel.DataGridView1.CurrentRow.Cells(4).Value.ToString.Trim & "," & _
                            frmsel.DataGridView1.CurrentRow.Cells(5).Value.ToString.Trim & "," & _
                            frmsel.DataGridView1.CurrentRow.Cells(6).Value.ToString.Trim & "," & _
                            frmsel.DataGridView1.CurrentRow.Cells(7).Value.ToString.Trim

                    For i = 0 To ListResources.Items.Count - 1

                        textlist = ListResources.Items(i).Text.Trim & "," & _
                        ListResources.Items(i).SubItems(1).Text.Trim & "," & _
                        ListResources.Items(i).SubItems(3).Text.Trim & "," & _
                        ListResources.Items(i).SubItems(4).Text.Trim & "," & _
                        ListResources.Items(i).SubItems(5).Text.Trim & "," & _
                        ListResources.Items(i).SubItems(6).Text.Trim & "," & _
                        ListResources.Items(i).SubItems(7).Text.Trim & ""

                        If textnew.ToUpper = textlist.ToUpper Then
                            If MsgBox("Duplicated value " & vbCrLf & "Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "Duplicated") <> MsgBoxResult.Yes Then
                                Exit Sub
                            Else
                                Exit For
                            End If
                        End If

                    Next


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

    Private Sub ListResources_DoubleClick(sender As Object, e As EventArgs) Handles ListResources.DoubleClick
        Try
            If ListResources.SelectedIndices.Count = 0 Then Exit Sub
            If ListResources.Items(ListResources.SelectedItems(0).Index).Text = "-1" Then
                Dim ad As New SubResourceCMS
                ad.TxtName.Text = ListResources.Items(ListResources.SelectedItems(0).Index).SubItems(1).Text
                ad.TxtDesc.Text = ListResources.Items(ListResources.SelectedItems(0).Index).SubItems(2).Text
                ad.TxtDevice.Text = ListResources.Items(ListResources.SelectedItems(0).Index).SubItems(4).Text
                ad.TxtDepartment.Text = ListResources.Items(ListResources.SelectedItems(0).Index).SubItems(5).Text
                ad.TxtResource.Text = ListResources.Items(ListResources.SelectedItems(0).Index).SubItems(6).Text
                If ad.ShowDialog = Windows.Forms.DialogResult.OK Then

                    ListResources.Items(ListResources.SelectedItems(0).Index).SubItems(1).Text = ad.TxtName.Text
                    ListResources.Items(ListResources.SelectedItems(0).Index).SubItems(2).Text = ad.TxtDesc.Text

                    ListResources.Items(ListResources.SelectedItems(0).Index).SubItems(3).Text = ad.TxtName.Text

                    ListResources.Items(ListResources.SelectedItems(0).Index).SubItems(4).Text = ad.TxtDevice.Text
                    ListResources.Items(ListResources.SelectedItems(0).Index).SubItems(5).Text = ad.TxtDepartment.Text
                    ListResources.Items(ListResources.SelectedItems(0).Index).SubItems(6).Text = ad.TxtResource.Text

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListResources_DragDrop(sender As Object, e As DragEventArgs) Handles ListResources.DragDrop
        'Return if the items are not selected in the ListView control.
        If ListResources.SelectedItems.Count = 0 Then Return
        'Returns the location of the mouse pointer in the ListView control.
        Dim p As Point = ListResources.PointToClient(New Point(e.X, e.Y))
        'Obtain the item that is located at the specified location of the mouse pointer.
        Dim dragToItem As ListViewItem = ListResources.GetItemAt(p.X, p.Y)
        If dragToItem Is Nothing Then Return
        'Obtain the index of the item at the mouse pointer.
        Dim dragIndex As Integer = dragToItem.Index
        Dim i As Integer
        Dim sel(ListResources.SelectedItems.Count) As ListViewItem
        For i = 0 To ListResources.SelectedItems.Count - 1
            sel(i) = ListResources.SelectedItems.Item(i)
        Next
        For i = 0 To ListResources.SelectedItems.Count - 1
            'Obtain the ListViewItem to be dragged to the target location.
            Dim dragItem As ListViewItem = sel(i)
            Dim itemIndex As Integer = dragIndex
            If itemIndex = dragItem.Index Then Return
            If dragItem.Index < itemIndex Then
                itemIndex = itemIndex + 1
            Else
                itemIndex = dragIndex + i
            End If
            'Insert the item in the specified location.
            Dim insertitem As ListViewItem = dragItem.Clone
            ListResources.Items.Insert(itemIndex, insertitem)
            'Removes the item from the initial location while 
            'the item is moved to the new location.
            ListResources.Items.Remove(dragItem)
        Next
    End Sub

    Private Sub ListResources_DragEnter(sender As Object, e As DragEventArgs) Handles ListResources.DragEnter
        Dim i As Integer
        For i = 0 To e.Data.GetFormats().Length - 1
            If e.Data.GetFormats()(i).Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection") Then
                'The data from the drag source is moved to the target.
                e.Effect = DragDropEffects.Move
            End If
        Next
    End Sub

    Private Sub ListResources_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles ListResources.ItemDrag
        ListResources.DoDragDrop(ListResources.SelectedItems, DragDropEffects.Move)
    End Sub

    Private Sub ListResources_KeyUp(sender As Object, e As KeyEventArgs) Handles ListResources.KeyUp
        If ListResources.SelectedIndices.Count = 0 Then Exit Sub
        If e.KeyCode = Keys.Delete Then
            If MsgBox("Are you sure ?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "Remove") = MsgBoxResult.Yes Then
                'For i = 0 To ListResources.SelectedIndices.Count - 1
                '    ListResources.Items.RemoveAt(ListResources.SelectedIndices(i))
                'Next
                For Each i As ListViewItem In ListResources.SelectedItems
                    ListResources.Items.Remove(i)
                Next
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim frmsel As New SubResourceCMS

        If frmsel.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim textnew, textlist As String
            textnew = "-1," & _
                    frmsel.TxtName.Text.Trim & "," & _
                    frmsel.TxtName.Text.Trim & "," & _
                    frmsel.TxtDevice.Text.Trim & "," & _
                    frmsel.TxtDepartment.Text.Trim & "," & _
                    frmsel.TxtResource.Text.Trim & ",1"

            For i = 0 To ListResources.Items.Count - 1

                textlist = ListResources.Items(i).Text.Trim & "," & _
                ListResources.Items(i).SubItems(1).Text.Trim & "," & _
                ListResources.Items(i).SubItems(3).Text.Trim & "," & _
                ListResources.Items(i).SubItems(4).Text.Trim & "," & _
                ListResources.Items(i).SubItems(5).Text.Trim & "," & _
                ListResources.Items(i).SubItems(6).Text.Trim & "," & _
                ListResources.Items(i).SubItems(7).Text.Trim & ""

                If textnew.ToUpper = textlist.ToUpper Then
                    If MsgBox("Duplicated value " & vbCrLf & "Are you sure?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "Duplicated") <> MsgBoxResult.Yes Then
                        Exit Sub
                    Else
                        Exit For
                    End If
                End If

            Next

            ListResources.Items.Add(-1)
            ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(frmsel.TxtName.Text)
            ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(frmsel.TxtDesc.Text)
            ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(frmsel.TxtName.Text)
            ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(frmsel.TxtDevice.Text)
            ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(frmsel.TxtDepartment.Text)
            ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(frmsel.TxtResource.Text)
            ListResources.Items(ListResources.Items.Count - 1).SubItems.Add(1)
        End If

        frmsel.Dispose()
        frmsel = Nothing
    End Sub
End Class