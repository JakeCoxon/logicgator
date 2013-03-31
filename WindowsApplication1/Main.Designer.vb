<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.FileMenu = New System.Windows.Forms.ToolStripDropDownButton
        Me.NewButton = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenButton = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveButton = New System.Windows.Forms.ToolStripMenuItem
        Me.ExpressionManagerButton = New System.Windows.Forms.ToolStripButton
        Me.InputsButton = New System.Windows.Forms.ToolStripButton
        Me.AboutButton = New System.Windows.Forms.ToolStripButton
        Me.Toolbar1 = New System.Windows.Forms.FlowLayoutPanel
        Me.CanvasPanel = New System.Windows.Forms.Panel
        Me.UpdateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.DrawTimer = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DragControlContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GateNameButton = New System.Windows.Forms.ToolStripMenuItem
        Me.ValueButton = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteButton = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1.SuspendLayout()
        Me.DragControlContext.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.ExpressionManagerButton, Me.InputsButton, Me.AboutButton})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(779, 23)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewButton, Me.OpenButton, Me.SaveButton})
        Me.FileMenu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(38, 19)
        Me.FileMenu.Text = "File"
        '
        'NewButton
        '
        Me.NewButton.Name = "NewButton"
        Me.NewButton.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewButton.Size = New System.Drawing.Size(163, 22)
        Me.NewButton.Text = "New"
        '
        'OpenButton
        '
        Me.OpenButton.Name = "OpenButton"
        Me.OpenButton.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenButton.Size = New System.Drawing.Size(163, 22)
        Me.OpenButton.Text = "Open..."
        '
        'SaveButton
        '
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveButton.Size = New System.Drawing.Size(163, 22)
        Me.SaveButton.Text = "Save As..."
        '
        'ExpressionManagerButton
        '
        Me.ExpressionManagerButton.Image = Global.LogicGator.My.Resources.Resources.wand
        Me.ExpressionManagerButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExpressionManagerButton.Name = "ExpressionManagerButton"
        Me.ExpressionManagerButton.Size = New System.Drawing.Size(132, 20)
        Me.ExpressionManagerButton.Text = "Expression Manager"
        '
        'InputsButton
        '
        Me.InputsButton.Image = Global.LogicGator.My.Resources.Resources.lightbulb
        Me.InputsButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.InputsButton.Name = "InputsButton"
        Me.InputsButton.Size = New System.Drawing.Size(60, 20)
        Me.InputsButton.Text = "Inputs"
        '
        'AboutButton
        '
        Me.AboutButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.Size = New System.Drawing.Size(44, 19)
        Me.AboutButton.Text = "About"
        '
        'Toolbar1
        '
        Me.Toolbar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Toolbar1.AutoScroll = True
        Me.Toolbar1.Location = New System.Drawing.Point(0, 25)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(779, 72)
        Me.Toolbar1.TabIndex = 2
        Me.Toolbar1.WrapContents = False
        '
        'CanvasPanel
        '
        Me.CanvasPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CanvasPanel.AutoScroll = True
        Me.CanvasPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CanvasPanel.BackColor = System.Drawing.Color.Silver
        Me.CanvasPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CanvasPanel.Location = New System.Drawing.Point(0, 103)
        Me.CanvasPanel.Name = "CanvasPanel"
        Me.CanvasPanel.Size = New System.Drawing.Size(779, 422)
        Me.CanvasPanel.TabIndex = 3
        '
        'UpdateTimer
        '
        Me.UpdateTimer.Enabled = True
        '
        'DrawTimer
        '
        Me.DrawTimer.Enabled = True
        Me.DrawTimer.Interval = 10
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.DefaultExt = "lgf"
        Me.OpenFileDialog.Filter = "LogicGator Files|*.lgf"
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.DefaultExt = "lgf"
        Me.SaveFileDialog.Filter = "LogicGator Files|*.lgf"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.OpenToolStripMenuItem1, Me.SaveToolStripMenuItem})
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(38, 19)
        Me.ToolStripButton1.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OpenToolStripMenuItem.Text = "New"
        '
        'OpenToolStripMenuItem1
        '
        Me.OpenToolStripMenuItem1.Name = "OpenToolStripMenuItem1"
        Me.OpenToolStripMenuItem1.Size = New System.Drawing.Size(103, 22)
        Me.OpenToolStripMenuItem1.Text = "Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'DragControlContext
        '
        Me.DragControlContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GateNameButton, Me.ValueButton, Me.DeleteButton})
        Me.DragControlContext.Name = "DragControlContext"
        Me.DragControlContext.Size = New System.Drawing.Size(128, 70)
        '
        'GateNameButton
        '
        Me.GateNameButton.BackColor = System.Drawing.Color.LightGray
        Me.GateNameButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.GateNameButton.ForeColor = System.Drawing.Color.Black
        Me.GateNameButton.Name = "GateNameButton"
        Me.GateNameButton.Size = New System.Drawing.Size(127, 22)
        Me.GateNameButton.Text = "Gate Type"
        '
        'ValueButton
        '
        Me.ValueButton.BackColor = System.Drawing.Color.LightGray
        Me.ValueButton.ForeColor = System.Drawing.Color.Black
        Me.ValueButton.Name = "ValueButton"
        Me.ValueButton.Size = New System.Drawing.Size(127, 22)
        Me.ValueButton.Text = "Value"
        '
        'DeleteButton
        '
        Me.DeleteButton.Image = Global.LogicGator.My.Resources.Resources.delete
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(127, 22)
        Me.DeleteButton.Text = "Delete"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 525)
        Me.Controls.Add(Me.CanvasPanel)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "Logic Gator"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.DragControlContext.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Toolbar1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents CanvasPanel As System.Windows.Forms.Panel
    Friend WithEvents UpdateTimer As System.Windows.Forms.Timer
    Friend WithEvents DrawTimer As System.Windows.Forms.Timer
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents NewButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExpressionManagerButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AboutButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents InputsButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DragControlContext As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GateNameButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ValueButton As System.Windows.Forms.ToolStripMenuItem
End Class
