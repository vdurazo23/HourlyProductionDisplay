<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerificationForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BtnIntentos = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.LblPrompt = New System.Windows.Forms.Label()
        Me.VerificationControl = New DPFP.Gui.Verification.VerificationControl()
        Me.SuspendLayout()
        '
        'BtnIntentos
        '
        Me.BtnIntentos.Location = New System.Drawing.Point(4, 69)
        Me.BtnIntentos.Name = "BtnIntentos"
        Me.BtnIntentos.Size = New System.Drawing.Size(476, 47)
        Me.BtnIntentos.TabIndex = 21
        Me.BtnIntentos.Text = "Intentos"
        Me.BtnIntentos.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(158, 132)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(160, 36)
        Me.BtnCancelar.TabIndex = 20
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'LblPrompt
        '
        Me.LblPrompt.AutoSize = True
        Me.LblPrompt.Location = New System.Drawing.Point(67, 29)
        Me.LblPrompt.Name = "LblPrompt"
        Me.LblPrompt.Size = New System.Drawing.Size(399, 13)
        Me.LblPrompt.TabIndex = 19
        Me.LblPrompt.Text = "Para verificar su identidad, toque el lector de huellas con cualquier dedo regist" & _
    "rado."
        '
        'VerificationControl
        '
        Me.VerificationControl.Active = True
        Me.VerificationControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.VerificationControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.VerificationControl.Location = New System.Drawing.Point(13, 13)
        Me.VerificationControl.Margin = New System.Windows.Forms.Padding(4)
        Me.VerificationControl.Name = "VerificationControl"
        Me.VerificationControl.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000"
        Me.VerificationControl.Size = New System.Drawing.Size(48, 50)
        Me.VerificationControl.TabIndex = 18
        '
        'VerificationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 174)
        Me.Controls.Add(Me.BtnIntentos)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.LblPrompt)
        Me.Controls.Add(Me.VerificationControl)
        Me.Name = "VerificationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VerificationForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnIntentos As Button
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents LblPrompt As Label
    Friend WithEvents VerificationControl As DPFP.Gui.Verification.VerificationControl
End Class
