<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExpressionWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExpressionWindow))
        Me.OutputLabel = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button15 = New System.Windows.Forms.Button
        Me.Button14 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'OutputLabel
        '
        Me.OutputLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputLabel.Location = New System.Drawing.Point(12, 88)
        Me.OutputLabel.Name = "OutputLabel"
        Me.OutputLabel.Size = New System.Drawing.Size(407, 33)
        Me.OutputLabel.TabIndex = 0
        Me.OutputLabel.Text = "(A·B)"
        '
        'Button3
        '
        Me.Button3.Image = Global.LogicGator.My.Resources.Resources.arrow_left
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(12, 135)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(406, 27)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Create a diagram from this expression"
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Button2.Image = Global.LogicGator.My.Resources.Resources.arrow_right
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(12, 45)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(200, 27)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Load expression from diagram"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Button15.Image = Global.LogicGator.My.Resources.Resources.asterisk_yellow
        Me.Button15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button15.Location = New System.Drawing.Point(218, 45)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(200, 27)
        Me.Button15.TabIndex = 3
        Me.Button15.Text = "Simplification..."
        Me.Button15.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Button14.Image = Global.LogicGator.My.Resources.Resources.pencil
        Me.Button14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button14.Location = New System.Drawing.Point(218, 12)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(200, 27)
        Me.Button14.TabIndex = 2
        Me.Button14.Text = "New/edit expression..."
        Me.Button14.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Button1.Image = Global.LogicGator.My.Resources.Resources.application_form_edit
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(200, 27)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Input simple expression..."
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ExpressionWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 176)
        Me.Controls.Add(Me.OutputLabel)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ExpressionWindow"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Expression Window"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OutputLabel As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
End Class
