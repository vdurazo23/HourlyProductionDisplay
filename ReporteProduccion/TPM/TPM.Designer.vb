<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TPM
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.BtnNuevoTPM = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.BtnDown = New System.Windows.Forms.Button()
        Me.BtnUp = New System.Windows.Forms.Button()
        Me.BtnEliminarElemento = New System.Windows.Forms.Button()
        Me.BtnNuevoElemento = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.BtnEditarTPM = New System.Windows.Forms.Button()
        Me.BtnEliminarTPM = New System.Windows.Forms.Button()
        Me.BtnEditarElemento = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnNuevoTPM
        '
        Me.BtnNuevoTPM.Enabled = False
        Me.BtnNuevoTPM.Location = New System.Drawing.Point(7, 5)
        Me.BtnNuevoTPM.Name = "BtnNuevoTPM"
        Me.BtnNuevoTPM.Size = New System.Drawing.Size(99, 46)
        Me.BtnNuevoTPM.TabIndex = 2
        Me.BtnNuevoTPM.Text = "Nuevo TPM"
        Me.BtnNuevoTPM.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoScroll = True
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Enabled = False
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(7, 371)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 261.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1001, 261)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(7, 57)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(428, 308)
        Me.ListBox1.TabIndex = 4
        '
        'BtnDown
        '
        Me.BtnDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnDown.Enabled = False
        Me.BtnDown.Image = Global.ReporteProduccion.My.Resources.Resources.icons8_abajo_48__1_
        Me.BtnDown.Location = New System.Drawing.Point(954, 113)
        Me.BtnDown.Name = "BtnDown"
        Me.BtnDown.Size = New System.Drawing.Size(54, 50)
        Me.BtnDown.TabIndex = 9
        Me.BtnDown.UseVisualStyleBackColor = True
        '
        'BtnUp
        '
        Me.BtnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnUp.Enabled = False
        Me.BtnUp.Image = Global.ReporteProduccion.My.Resources.Resources.icons8_arriba_48__2_
        Me.BtnUp.Location = New System.Drawing.Point(954, 57)
        Me.BtnUp.Name = "BtnUp"
        Me.BtnUp.Size = New System.Drawing.Size(54, 50)
        Me.BtnUp.TabIndex = 8
        Me.BtnUp.UseVisualStyleBackColor = True
        '
        'BtnEliminarElemento
        '
        Me.BtnEliminarElemento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnEliminarElemento.Enabled = False
        Me.BtnEliminarElemento.Location = New System.Drawing.Point(676, 1)
        Me.BtnEliminarElemento.Name = "BtnEliminarElemento"
        Me.BtnEliminarElemento.Size = New System.Drawing.Size(113, 50)
        Me.BtnEliminarElemento.TabIndex = 7
        Me.BtnEliminarElemento.Text = "Eliminar elemento"
        Me.BtnEliminarElemento.UseVisualStyleBackColor = True
        '
        'BtnNuevoElemento
        '
        Me.BtnNuevoElemento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnNuevoElemento.Enabled = False
        Me.BtnNuevoElemento.Location = New System.Drawing.Point(441, 1)
        Me.BtnNuevoElemento.Name = "BtnNuevoElemento"
        Me.BtnNuevoElemento.Size = New System.Drawing.Size(109, 50)
        Me.BtnNuevoElemento.TabIndex = 6
        Me.BtnNuevoElemento.Text = "Nuevo elemento"
        Me.BtnNuevoElemento.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.BtnNuevoElemento.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.Location = New System.Drawing.Point(441, 57)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(507, 308)
        Me.ListView1.TabIndex = 10
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'BtnEditarTPM
        '
        Me.BtnEditarTPM.Enabled = False
        Me.BtnEditarTPM.Location = New System.Drawing.Point(112, 5)
        Me.BtnEditarTPM.Name = "BtnEditarTPM"
        Me.BtnEditarTPM.Size = New System.Drawing.Size(105, 46)
        Me.BtnEditarTPM.TabIndex = 11
        Me.BtnEditarTPM.Text = "Editar TPM"
        Me.BtnEditarTPM.UseVisualStyleBackColor = True
        '
        'BtnEliminarTPM
        '
        Me.BtnEliminarTPM.Enabled = False
        Me.BtnEliminarTPM.Location = New System.Drawing.Point(223, 5)
        Me.BtnEliminarTPM.Name = "BtnEliminarTPM"
        Me.BtnEliminarTPM.Size = New System.Drawing.Size(97, 46)
        Me.BtnEliminarTPM.TabIndex = 12
        Me.BtnEliminarTPM.Text = "Eliminar TPM"
        Me.BtnEliminarTPM.UseVisualStyleBackColor = True
        '
        'BtnEditarElemento
        '
        Me.BtnEditarElemento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnEditarElemento.Enabled = False
        Me.BtnEditarElemento.Location = New System.Drawing.Point(556, 1)
        Me.BtnEditarElemento.Name = "BtnEditarElemento"
        Me.BtnEditarElemento.Size = New System.Drawing.Size(114, 50)
        Me.BtnEditarElemento.TabIndex = 13
        Me.BtnEditarElemento.Text = "Editar elemento"
        Me.BtnEditarElemento.UseVisualStyleBackColor = True
        '
        'TPM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 644)
        Me.Controls.Add(Me.BtnEditarElemento)
        Me.Controls.Add(Me.BtnEliminarTPM)
        Me.Controls.Add(Me.BtnEditarTPM)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.BtnDown)
        Me.Controls.Add(Me.BtnUp)
        Me.Controls.Add(Me.BtnEliminarElemento)
        Me.Controls.Add(Me.BtnNuevoElemento)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.BtnNuevoTPM)
        Me.Name = "TPM"
        Me.Text = "TPM"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnNuevoTPM As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents BtnNuevoElemento As Button
    Friend WithEvents BtnEliminarElemento As Button
    Friend WithEvents BtnUp As Button
    Friend WithEvents BtnDown As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents BtnEditarTPM As Button
    Friend WithEvents BtnEliminarTPM As Button
    Friend WithEvents BtnEditarElemento As Button
End Class
