﻿Public Class SelectResource
    Public dt As DataTable
    Private Sub SelectResource_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DataGridView1.DataSource = dt.DefaultView
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub
End Class