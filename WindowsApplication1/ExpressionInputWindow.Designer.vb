<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExpressionInputWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExpressionInputWindow))
        Me.InputCombo1 = New System.Windows.Forms.ComboBox
        Me.InputCombo2 = New System.Windows.Forms.ComboBox
        Me.OpCombo1 = New System.Windows.Forms.ListBox
        Me.OpCombo2 = New System.Windows.Forms.ListBox
        Me.InputCombo3 = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.NotBox1 = New System.Windows.Forms.CheckBox
        Me.NotBox2 = New System.Windows.Forms.CheckBox
        Me.NotBox3 = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Preview = New System.Windows.Forms.Label
        Me.SuperNotLine1 = New System.Windows.Forms.Label
        Me.SuperNotLine2 = New System.Windows.Forms.Label
        Me.NotLine2 = New System.Windows.Forms.Label
        Me.NotLine3 = New System.Windows.Forms.Label
        Me.NotLine1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'InputCombo1
        '
        Me.InputCombo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.InputCombo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputCombo1.FormattingEnabled = True
        Me.InputCombo1.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F"})
        Me.InputCombo1.Location = New System.Drawing.Point(9, 54)
        Me.InputCombo1.Name = "InputCombo1"
        Me.InputCombo1.Size = New System.Drawing.Size(84, 32)
        Me.InputCombo1.TabIndex = 0
        '
        'InputCombo2
        '
        Me.InputCombo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.InputCombo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputCombo2.FormattingEnabled = True
        Me.InputCombo2.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F"})
        Me.InputCombo2.Location = New System.Drawing.Point(17, 50)
        Me.InputCombo2.Name = "InputCombo2"
        Me.InputCombo2.Size = New System.Drawing.Size(84, 32)
        Me.InputCombo2.TabIndex = 1
        '
        'OpCombo1
        '
        Me.OpCombo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpCombo1.FormattingEnabled = True
        Me.OpCombo1.ItemHeight = 31
        Me.OpCombo1.Items.AddRange(New Object() {"AND", "OR", "XOR", "NAND", "NOR", "XNOR"})
        Me.OpCombo1.Location = New System.Drawing.Point(99, 54)
        Me.OpCombo1.Name = "OpCombo1"
        Me.OpCombo1.Size = New System.Drawing.Size(91, 190)
        Me.OpCombo1.TabIndex = 2
        '
        'OpCombo2
        '
        Me.OpCombo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpCombo2.FormattingEnabled = True
        Me.OpCombo2.ItemHeight = 31
        Me.OpCombo2.Items.AddRange(New Object() {"AND", "OR", "XOR", "NAND", "NOR", "XNOR"})
        Me.OpCombo2.Location = New System.Drawing.Point(107, 50)
        Me.OpCombo2.Name = "OpCombo2"
        Me.OpCombo2.Size = New System.Drawing.Size(91, 190)
        Me.OpCombo2.TabIndex = 2
        '
        'InputCombo3
        '
        Me.InputCombo3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.InputCombo3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputCombo3.FormattingEnabled = True
        Me.InputCombo3.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F"})
        Me.InputCombo3.Location = New System.Drawing.Point(204, 50)
        Me.InputCombo3.Name = "InputCombo3"
        Me.InputCombo3.Size = New System.Drawing.Size(84, 32)
        Me.InputCombo3.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(324, 334)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 21)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(417, 334)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(86, 21)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'NotBox1
        '
        Me.NotBox1.AutoSize = True
        Me.NotBox1.Location = New System.Drawing.Point(9, 31)
        Me.NotBox1.Name = "NotBox1"
        Me.NotBox1.Size = New System.Drawing.Size(49, 17)
        Me.NotBox1.TabIndex = 5
        Me.NotBox1.Text = "NOT"
        Me.NotBox1.UseVisualStyleBackColor = True
        '
        'NotBox2
        '
        Me.NotBox2.AutoSize = True
        Me.NotBox2.Location = New System.Drawing.Point(17, 27)
        Me.NotBox2.Name = "NotBox2"
        Me.NotBox2.Size = New System.Drawing.Size(49, 17)
        Me.NotBox2.TabIndex = 6
        Me.NotBox2.Text = "NOT"
        Me.NotBox2.UseVisualStyleBackColor = True
        '
        'NotBox3
        '
        Me.NotBox3.AutoSize = True
        Me.NotBox3.Location = New System.Drawing.Point(204, 27)
        Me.NotBox3.Name = "NotBox3"
        Me.NotBox3.Size = New System.Drawing.Size(49, 17)
        Me.NotBox3.TabIndex = 7
        Me.NotBox3.Text = "NOT"
        Me.NotBox3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OpCombo2)
        Me.GroupBox1.Controls.Add(Me.InputCombo2)
        Me.GroupBox1.Controls.Add(Me.NotBox3)
        Me.GroupBox1.Controls.Add(Me.InputCombo3)
        Me.GroupBox1.Controls.Add(Me.NotBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(196, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(307, 266)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'Preview
        '
        Me.Preview.AutoSize = True
        Me.Preview.Font = New System.Drawing.Font("Consolas", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Preview.Location = New System.Drawing.Point(27, 311)
        Me.Preview.Name = "Preview"
        Me.Preview.Size = New System.Drawing.Size(191, 34)
        Me.Preview.TabIndex = 10
        Me.Preview.Text = "A · (B + C)"
        '
        'SuperNotLine1
        '
        Me.SuperNotLine1.AutoSize = True
        Me.SuperNotLine1.BackColor = System.Drawing.Color.Transparent
        Me.SuperNotLine1.Font = New System.Drawing.Font("Consolas", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperNotLine1.Location = New System.Drawing.Point(24, 268)
        Me.SuperNotLine1.Name = "SuperNotLine1"
        Me.SuperNotLine1.Size = New System.Drawing.Size(191, 34)
        Me.SuperNotLine1.TabIndex = 10
        Me.SuperNotLine1.Text = "___________"
        '
        'SuperNotLine2
        '
        Me.SuperNotLine2.AutoSize = True
        Me.SuperNotLine2.BackColor = System.Drawing.Color.Transparent
        Me.SuperNotLine2.Font = New System.Drawing.Font("Consolas", 21.75!, System.Drawing.FontStyle.Bold)
        Me.SuperNotLine2.Location = New System.Drawing.Point(99, 276)
        Me.SuperNotLine2.Name = "SuperNotLine2"
        Me.SuperNotLine2.Size = New System.Drawing.Size(111, 34)
        Me.SuperNotLine2.TabIndex = 10
        Me.SuperNotLine2.Text = "______"
        '
        'NotLine2
        '
        Me.NotLine2.AutoSize = True
        Me.NotLine2.BackColor = System.Drawing.Color.Transparent
        Me.NotLine2.Font = New System.Drawing.Font("Consolas", 21.75!, System.Drawing.FontStyle.Bold)
        Me.NotLine2.Location = New System.Drawing.Point(107, 282)
        Me.NotLine2.Name = "NotLine2"
        Me.NotLine2.Size = New System.Drawing.Size(31, 34)
        Me.NotLine2.TabIndex = 10
        Me.NotLine2.Text = "_"
        '
        'NotLine3
        '
        Me.NotLine3.AutoSize = True
        Me.NotLine3.BackColor = System.Drawing.Color.Transparent
        Me.NotLine3.Font = New System.Drawing.Font("Consolas", 21.75!, System.Drawing.FontStyle.Bold)
        Me.NotLine3.Location = New System.Drawing.Point(173, 282)
        Me.NotLine3.Name = "NotLine3"
        Me.NotLine3.Size = New System.Drawing.Size(31, 34)
        Me.NotLine3.TabIndex = 11
        Me.NotLine3.Text = "_"
        '
        'NotLine1
        '
        Me.NotLine1.AutoSize = True
        Me.NotLine1.BackColor = System.Drawing.Color.Transparent
        Me.NotLine1.Font = New System.Drawing.Font("Consolas", 21.75!, System.Drawing.FontStyle.Bold)
        Me.NotLine1.Location = New System.Drawing.Point(27, 282)
        Me.NotLine1.Name = "NotLine1"
        Me.NotLine1.Size = New System.Drawing.Size(31, 34)
        Me.NotLine1.TabIndex = 11
        Me.NotLine1.Text = "_"
        '
        'ExpressionInputWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 363)
        Me.Controls.Add(Me.SuperNotLine1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.NotBox1)
        Me.Controls.Add(Me.OpCombo1)
        Me.Controls.Add(Me.InputCombo1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.SuperNotLine2)
        Me.Controls.Add(Me.NotLine2)
        Me.Controls.Add(Me.NotLine1)
        Me.Controls.Add(Me.NotLine3)
        Me.Controls.Add(Me.Preview)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ExpressionInputWindow"
        Me.Text = "Simple Expression Input"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents InputCombo1 As System.Windows.Forms.ComboBox
    Friend WithEvents InputCombo2 As System.Windows.Forms.ComboBox
    Friend WithEvents OpCombo1 As System.Windows.Forms.ListBox
    Friend WithEvents OpCombo2 As System.Windows.Forms.ListBox
    Friend WithEvents InputCombo3 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents NotBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents NotBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents NotBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Preview As System.Windows.Forms.Label
    Friend WithEvents SuperNotLine1 As System.Windows.Forms.Label
    Friend WithEvents SuperNotLine2 As System.Windows.Forms.Label
    Friend WithEvents NotLine2 As System.Windows.Forms.Label
    Friend WithEvents NotLine3 As System.Windows.Forms.Label
    Friend WithEvents NotLine1 As System.Windows.Forms.Label

End Class
