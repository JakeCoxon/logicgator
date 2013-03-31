<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SimplifyWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SimplifyWindow))
        Me.ButtonS1 = New System.Windows.Forms.Button
        Me.ButtonS2 = New System.Windows.Forms.Button
        Me.ButtonS3 = New System.Windows.Forms.Button
        Me.ButtonS4 = New System.Windows.Forms.Button
        Me.OutputLabel = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ButtonS5 = New System.Windows.Forms.Button
        Me.ButtonS7 = New System.Windows.Forms.Button
        Me.ButtonS8 = New System.Windows.Forms.Button
        Me.ButtonS6 = New System.Windows.Forms.Button
        Me.ConsoleBox = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ButtonDM5 = New System.Windows.Forms.Button
        Me.ButtonDM3 = New System.Windows.Forms.Button
        Me.ButtonDM6 = New System.Windows.Forms.Button
        Me.ButtonDM4 = New System.Windows.Forms.Button
        Me.ButtonDM1 = New System.Windows.Forms.Button
        Me.ButtonDM2 = New System.Windows.Forms.Button
        Me.ButtonOK = New System.Windows.Forms.Button
        Me.ButtonCancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonS1
        '
        Me.ButtonS1.Location = New System.Drawing.Point(6, 19)
        Me.ButtonS1.Name = "ButtonS1"
        Me.ButtonS1.Size = New System.Drawing.Size(57, 29)
        Me.ButtonS1.TabIndex = 10
        Me.ButtonS1.Text = "0'"
        Me.ButtonS1.UseVisualStyleBackColor = True
        '
        'ButtonS2
        '
        Me.ButtonS2.Location = New System.Drawing.Point(69, 19)
        Me.ButtonS2.Name = "ButtonS2"
        Me.ButtonS2.Size = New System.Drawing.Size(57, 29)
        Me.ButtonS2.TabIndex = 11
        Me.ButtonS2.Text = "1'"
        Me.ButtonS2.UseVisualStyleBackColor = True
        '
        'ButtonS3
        '
        Me.ButtonS3.Location = New System.Drawing.Point(6, 54)
        Me.ButtonS3.Name = "ButtonS3"
        Me.ButtonS3.Size = New System.Drawing.Size(57, 29)
        Me.ButtonS3.TabIndex = 12
        Me.ButtonS3.Text = "X+0"
        Me.ButtonS3.UseVisualStyleBackColor = True
        '
        'ButtonS4
        '
        Me.ButtonS4.Location = New System.Drawing.Point(69, 54)
        Me.ButtonS4.Name = "ButtonS4"
        Me.ButtonS4.Size = New System.Drawing.Size(57, 29)
        Me.ButtonS4.TabIndex = 13
        Me.ButtonS4.Text = "X+1"
        Me.ButtonS4.UseVisualStyleBackColor = True
        '
        'OutputLabel
        '
        Me.OutputLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputLabel.Location = New System.Drawing.Point(12, 24)
        Me.OutputLabel.Name = "OutputLabel"
        Me.OutputLabel.Size = New System.Drawing.Size(579, 32)
        Me.OutputLabel.TabIndex = 14
        Me.OutputLabel.Text = "(A·B)"
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox1.Controls.Add(Me.ButtonS5)
        Me.GroupBox1.Controls.Add(Me.ButtonS3)
        Me.GroupBox1.Controls.Add(Me.ButtonS7)
        Me.GroupBox1.Controls.Add(Me.ButtonS8)
        Me.GroupBox1.Controls.Add(Me.ButtonS4)
        Me.GroupBox1.Controls.Add(Me.ButtonS6)
        Me.GroupBox1.Controls.Add(Me.ButtonS1)
        Me.GroupBox1.Controls.Add(Me.ButtonS2)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(132, 172)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Basic Simplification"
        '
        'ButtonS5
        '
        Me.ButtonS5.Location = New System.Drawing.Point(6, 89)
        Me.ButtonS5.Name = "ButtonS5"
        Me.ButtonS5.Size = New System.Drawing.Size(57, 29)
        Me.ButtonS5.TabIndex = 12
        Me.ButtonS5.Text = "X·0"
        Me.ButtonS5.UseVisualStyleBackColor = True
        '
        'ButtonS7
        '
        Me.ButtonS7.Location = New System.Drawing.Point(6, 124)
        Me.ButtonS7.Name = "ButtonS7"
        Me.ButtonS7.Size = New System.Drawing.Size(57, 29)
        Me.ButtonS7.TabIndex = 10
        Me.ButtonS7.Text = "X+X"
        Me.ButtonS7.UseVisualStyleBackColor = True
        '
        'ButtonS8
        '
        Me.ButtonS8.Location = New System.Drawing.Point(69, 124)
        Me.ButtonS8.Name = "ButtonS8"
        Me.ButtonS8.Size = New System.Drawing.Size(57, 29)
        Me.ButtonS8.TabIndex = 11
        Me.ButtonS8.Text = "X·X"
        Me.ButtonS8.UseVisualStyleBackColor = True
        '
        'ButtonS6
        '
        Me.ButtonS6.Location = New System.Drawing.Point(69, 89)
        Me.ButtonS6.Name = "ButtonS6"
        Me.ButtonS6.Size = New System.Drawing.Size(57, 29)
        Me.ButtonS6.TabIndex = 13
        Me.ButtonS6.Text = "X·1"
        Me.ButtonS6.UseVisualStyleBackColor = True
        '
        'ConsoleBox
        '
        Me.ConsoleBox.BackColor = System.Drawing.Color.White
        Me.ConsoleBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConsoleBox.Location = New System.Drawing.Point(315, 71)
        Me.ConsoleBox.Multiline = True
        Me.ConsoleBox.Name = "ConsoleBox"
        Me.ConsoleBox.ReadOnly = True
        Me.ConsoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ConsoleBox.Size = New System.Drawing.Size(276, 173)
        Me.ConsoleBox.TabIndex = 16
        '
        'GroupBox2
        '
        Me.GroupBox2.AutoSize = True
        Me.GroupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox2.Controls.Add(Me.ButtonDM5)
        Me.GroupBox2.Controls.Add(Me.ButtonDM3)
        Me.GroupBox2.Controls.Add(Me.ButtonDM6)
        Me.GroupBox2.Controls.Add(Me.ButtonDM4)
        Me.GroupBox2.Controls.Add(Me.ButtonDM1)
        Me.GroupBox2.Controls.Add(Me.ButtonDM2)
        Me.GroupBox2.Location = New System.Drawing.Point(164, 71)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(132, 137)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "De Morgan's Laws"
        '
        'ButtonDM5
        '
        Me.ButtonDM5.Location = New System.Drawing.Point(6, 89)
        Me.ButtonDM5.Name = "ButtonDM5"
        Me.ButtonDM5.Size = New System.Drawing.Size(57, 29)
        Me.ButtonDM5.TabIndex = 14
        Me.ButtonDM5.Text = "(X'·Y')'"
        Me.ButtonDM5.UseVisualStyleBackColor = True
        '
        'ButtonDM3
        '
        Me.ButtonDM3.Location = New System.Drawing.Point(6, 54)
        Me.ButtonDM3.Name = "ButtonDM3"
        Me.ButtonDM3.Size = New System.Drawing.Size(57, 29)
        Me.ButtonDM3.TabIndex = 12
        Me.ButtonDM3.Text = "X'·Y'"
        Me.ButtonDM3.UseVisualStyleBackColor = True
        '
        'ButtonDM6
        '
        Me.ButtonDM6.Location = New System.Drawing.Point(69, 89)
        Me.ButtonDM6.Name = "ButtonDM6"
        Me.ButtonDM6.Size = New System.Drawing.Size(57, 29)
        Me.ButtonDM6.TabIndex = 15
        Me.ButtonDM6.Text = "(X'+Y')'"
        Me.ButtonDM6.UseVisualStyleBackColor = True
        '
        'ButtonDM4
        '
        Me.ButtonDM4.Location = New System.Drawing.Point(69, 54)
        Me.ButtonDM4.Name = "ButtonDM4"
        Me.ButtonDM4.Size = New System.Drawing.Size(57, 29)
        Me.ButtonDM4.TabIndex = 13
        Me.ButtonDM4.Text = "X'+Y'"
        Me.ButtonDM4.UseVisualStyleBackColor = True
        '
        'ButtonDM1
        '
        Me.ButtonDM1.Location = New System.Drawing.Point(6, 19)
        Me.ButtonDM1.Name = "ButtonDM1"
        Me.ButtonDM1.Size = New System.Drawing.Size(57, 29)
        Me.ButtonDM1.TabIndex = 10
        Me.ButtonDM1.Text = "(X·Y)'"
        Me.ButtonDM1.UseVisualStyleBackColor = True
        '
        'ButtonDM2
        '
        Me.ButtonDM2.Location = New System.Drawing.Point(69, 19)
        Me.ButtonDM2.Name = "ButtonDM2"
        Me.ButtonDM2.Size = New System.Drawing.Size(57, 29)
        Me.ButtonDM2.TabIndex = 11
        Me.ButtonDM2.Text = "(X+Y)'"
        Me.ButtonDM2.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(413, 250)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(86, 21)
        Me.ButtonOK.TabIndex = 17
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(505, 250)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(86, 21)
        Me.ButtonCancel.TabIndex = 18
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 254)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(350, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "To simplify part of an expression, choose a button that looks like that part"
        '
        'SimplifyWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(603, 280)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ConsoleBox)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.OutputLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SimplifyWindow"
        Me.Text = "Simplification Window"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonS1 As System.Windows.Forms.Button
    Friend WithEvents ButtonS2 As System.Windows.Forms.Button
    Friend WithEvents ButtonS3 As System.Windows.Forms.Button
    Friend WithEvents ButtonS4 As System.Windows.Forms.Button
    Friend WithEvents OutputLabel As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ConsoleBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonDM3 As System.Windows.Forms.Button
    Friend WithEvents ButtonDM4 As System.Windows.Forms.Button
    Friend WithEvents ButtonDM1 As System.Windows.Forms.Button
    Friend WithEvents ButtonDM2 As System.Windows.Forms.Button
    Friend WithEvents ButtonS5 As System.Windows.Forms.Button
    Friend WithEvents ButtonS6 As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonS7 As System.Windows.Forms.Button
    Friend WithEvents ButtonS8 As System.Windows.Forms.Button
    Friend WithEvents ButtonDM5 As System.Windows.Forms.Button
    Friend WithEvents ButtonDM6 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
