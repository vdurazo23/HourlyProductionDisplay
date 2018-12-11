<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscarCodigo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.GridProduction = New Telerik.WinControls.UI.RadGridView()
        Me.txtcomments = New System.Windows.Forms.TextBox()
        CType(Me.GridProduction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridProduction.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridProduction
        '
        Me.GridProduction.Location = New System.Drawing.Point(13, 64)
        Me.GridProduction.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        '
        '
        '
        Me.GridProduction.MasterTemplate.AllowAddNewRow = False
        Me.GridProduction.MasterTemplate.AllowDeleteRow = False
        Me.GridProduction.MasterTemplate.AllowEditRow = False
        Me.GridProduction.MasterTemplate.EnableGrouping = False
        Me.GridProduction.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.GridProduction.Name = "GridProduction"
        Me.GridProduction.ReadOnly = True
        Me.GridProduction.Size = New System.Drawing.Size(798, 386)
        Me.GridProduction.TabIndex = 1
        Me.GridProduction.Text = "RadGridView1"
        Me.GridProduction.Visible = False
        '
        'txtcomments
        '
        Me.txtcomments.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcomments.Location = New System.Drawing.Point(13, 30)
        Me.txtcomments.Name = "txtcomments"
        Me.txtcomments.Size = New System.Drawing.Size(798, 26)
        Me.txtcomments.TabIndex = 0
        '
        'BuscarCodigo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(815, 464)
        Me.Controls.Add(Me.txtcomments)
        Me.Controls.Add(Me.GridProduction)
        Me.KeyPreview = True
        Me.Name = "BuscarCodigo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BuscarCodigo"
        CType(Me.GridProduction.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridProduction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridProduction As Telerik.WinControls.UI.RadGridView
    Friend WithEvents txtcomments As System.Windows.Forms.TextBox
End Class
