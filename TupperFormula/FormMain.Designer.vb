<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Me.TextBoxNumber = New System.Windows.Forms.TextBox()
        Me.CheckBoxInvertColors = New System.Windows.Forms.CheckBox()
        Me.CheckBoxFlipXY = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'TextBoxNumber
        '
        Me.TextBoxNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxNumber.Location = New System.Drawing.Point(12, 12)
        Me.TextBoxNumber.Name = "TextBoxNumber"
        Me.TextBoxNumber.Size = New System.Drawing.Size(715, 23)
        Me.TextBoxNumber.TabIndex = 0
        Me.TextBoxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CheckBoxInvertColors
        '
        Me.CheckBoxInvertColors.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxInvertColors.AutoSize = True
        Me.CheckBoxInvertColors.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxInvertColors.Location = New System.Drawing.Point(733, 14)
        Me.CheckBoxInvertColors.Name = "CheckBoxInvertColors"
        Me.CheckBoxInvertColors.Size = New System.Drawing.Size(93, 19)
        Me.CheckBoxInvertColors.TabIndex = 1
        Me.CheckBoxInvertColors.Text = "Invert Colors"
        Me.CheckBoxInvertColors.UseVisualStyleBackColor = False
        '
        'CheckBoxFlipXY
        '
        Me.CheckBoxFlipXY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxFlipXY.AutoSize = True
        Me.CheckBoxFlipXY.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxFlipXY.Location = New System.Drawing.Point(832, 14)
        Me.CheckBoxFlipXY.Name = "CheckBoxFlipXY"
        Me.CheckBoxFlipXY.Size = New System.Drawing.Size(59, 19)
        Me.CheckBoxFlipXY.TabIndex = 2
        Me.CheckBoxFlipXY.Text = "FlipXY"
        Me.CheckBoxFlipXY.UseVisualStyleBackColor = False
        '
        'FormMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(903, 337)
        Me.Controls.Add(Me.CheckBoxFlipXY)
        Me.Controls.Add(Me.CheckBoxInvertColors)
        Me.Controls.Add(Me.TextBoxNumber)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Tupper's Self-Referential Formula"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBoxNumber As TextBox
    Friend WithEvents CheckBoxInvertColors As CheckBox
    Friend WithEvents CheckBoxFlipXY As CheckBox
End Class
