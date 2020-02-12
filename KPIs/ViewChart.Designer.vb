<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewChart
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
        Me.Grafica1 = New KPIs.Grafica()
        Me.GridDatos = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PicClose = New System.Windows.Forms.PictureBox()
        CType(Me.GridDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grafica1
        '
        Me.Grafica1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Grafica1.Location = New System.Drawing.Point(10, 10)
        Me.Grafica1.Name = "Grafica1"
        Me.Grafica1.Size = New System.Drawing.Size(776, 485)
        Me.Grafica1.TabIndex = 0
        '
        'GridDatos
        '
        Me.GridDatos.AllowUserToAddRows = False
        Me.GridDatos.AllowUserToDeleteRows = False
        Me.GridDatos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GridDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GridDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridDatos.Location = New System.Drawing.Point(10, 501)
        Me.GridDatos.Name = "GridDatos"
        Me.GridDatos.ReadOnly = True
        Me.GridDatos.Size = New System.Drawing.Size(776, 85)
        Me.GridDatos.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.PicClose)
        Me.Panel1.Controls.Add(Me.Grafica1)
        Me.Panel1.Controls.Add(Me.GridDatos)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 600)
        Me.Panel1.TabIndex = 5
        '
        'PicClose
        '
        Me.PicClose.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PicClose.BackColor = System.Drawing.Color.White
        Me.PicClose.Image = Global.KPIs.My.Resources.Resources.Close_Box_Red
        Me.PicClose.Location = New System.Drawing.Point(749, 10)
        Me.PicClose.Name = "PicClose"
        Me.PicClose.Size = New System.Drawing.Size(37, 42)
        Me.PicClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicClose.TabIndex = 5
        Me.PicClose.TabStop = False
        '
        'ViewChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Magenta
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "ViewChart"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ViewChart"
        Me.TransparencyKey = System.Drawing.Color.Magenta
        CType(Me.GridDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PicClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grafica1 As KPIs.Grafica
    Friend WithEvents GridDatos As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PicClose As System.Windows.Forms.PictureBox
End Class
