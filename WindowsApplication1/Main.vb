Public Class Main
    ' Jake Made This

    ' This is my project. Every variable has the word expression,
    ' input or control in it.

    Public mouseLink As New Link()

    Public InputsList As New List(Of InputControl)
    Public GatesList As New List(Of GateControl)
    Public OutputsList As New List(Of OutputControl)

    ' Input values A-F
    Public globalValues(6) As Boolean ' 6 values, A-F

    ' Have we got unsaved changes?
    Public UnsavedChanges As Boolean = False

    ' Every time we create a control they stack down
    Private createdPosition As Integer = 0

    ' The canvas is the main window where stuff is dragged around and
    ' linked up.
    Private Canvas As CanvasControl

    ' What control are we right-clicking?
    Private RightClickMenuFor As DragControl

    ' Public Subs ---------------------------------------------

    Public Sub ToggleInput(ByVal InputID As Integer)
        ' Called from a named input's click handler or Inputs Window

        Dim Value As Boolean = Not globalValues(InputID - 1)
        ' InputID starts at 1
        globalValues(InputID - 1) = Value

        For Each input As InputControl In InputsList
            If input.Type = InputID Then
                input.Value = Value
            End If
        Next

        InputsWindow.UpdateValues()
    End Sub


    Public Sub Connector_Click(ByVal control As DragControl, ByVal LinkerType As LinkFinishType)
        ' Called from CanvasControl

        ' If both link.Start and link.Finish is nothing then that
        ' means we're not selecting anything yet
        If IsNothing(mouseLink.Start) And IsNothing(mouseLink.Finish.Control) Then
            ' Secondly, if sender is an input linker and can't have more links
            ' the we should remove the link
            If LinkerType = LinkFinishType.Input1 AndAlso Not IsNothing(control.Input1Control) Then
                mouseLink.Start = control.Input1Control
                control.DeleteInput1()
                Return
            ElseIf LinkerType = LinkFinishType.Input2 AndAlso Not IsNothing(control.Input2Control) Then
                mouseLink.Start = control.Input2Control
                control.DeleteInput2()
                Return
            End If
        End If

        If IsNothing(mouseLink.Start) AndAlso LinkerType = LinkFinishType.Output Then
            mouseLink.Start = control

        ElseIf IsNothing(mouseLink.Finish.Control) Then

            If LinkerType = LinkFinishType.Input1 And IsNothing(control.Input1Control) Then
                mouseLink.Finish = CreateLinkFinish(control, LinkFinishType.Input1)

            ElseIf LinkerType = LinkFinishType.Input2 And IsNothing(control.Input2Control) Then
                mouseLink.Finish = CreateLinkFinish(control, LinkFinishType.Input2)

            End If
        End If

        ' If mouseLink's Start and Finish variables are set then it means
        ' the user has clicked two linkers and we need to join them up.
        If Exists(mouseLink.Start) And Exists(mouseLink.Finish.Control) Then
            CreateLink(mouseLink.Start, mouseLink.Finish)

            mouseLink.Start = Nothing
            mouseLink.Finish = Nothing

        End If

    End Sub

    Public Sub Control_RightClick(ByVal control As DragControl)
        ' Called from CanvasControl

        RightClickMenuFor = control
        Dim scrollpos As New Point(CanvasPanel.HorizontalScroll.Value, CanvasPanel.VerticalScroll.Value)
        ' control position - scrollpos + height
        Dim pos As Point = control.Location - scrollpos + New Point(0, control.Height)
        DragControlContext.Show(CanvasPanel, pos)

    End Sub


    Public Sub Connector_ClickEmpty()
        ' Called from Canvas
        ' If clicked on the CanvasPanel (the white bit), clear both values
        mouseLink.Start = Nothing
        mouseLink.Finish = Nothing
    End Sub


    Public Function CreateNew() As Boolean
        ' Asks to save, and then clears the canvas
        ' Returns true if the canvas was cleared

        If UnsavedChanges Then
            Dim result As MsgBoxResult = MsgBox("Continuing will clear any unsaved changes" & vbNewLine & "Do you want to save first?", MsgBoxStyle.YesNoCancel)
            If result = MsgBoxResult.Cancel Then
                Return False
            ElseIf result = MsgBoxResult.Yes Then
                SaveDialog()
            ElseIf result = MsgBoxResult.No Then
                ' continue
            End If
        End If

        Clear()

        Return True

    End Function

    Public Sub CreateGraphFromExpression(ByRef Exp As ExpressionBase)

        ' Remove everything
        If Not CreateNew() Then
            Exit Sub
        End If

        Dim creator As New DiagramCreator
        Try
            creator.Create(Exp)
        Catch ex As Exception
            ' Something went wrong!
            ' Remove all the controls
            Clear()
            ' Apologize
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Public Sub CreateLink(ByVal Start As DragControl, ByVal Finish As LinkFinish)

        ' Create a link between output and input

        If Finish.Type = LinkFinishType.Input1 Then
            Finish.Control.Input1Control = Start
            Start.Outputs.Add(Finish)
        ElseIf Finish.Type = LinkFinishType.Input2 Then
            Finish.Control.Input2Control = Start
            Start.Outputs.Add(Finish)
        End If


        ' Something has changed..
        UnsavedChanges = True

    End Sub

    Public Function AddInputControl(ByVal InputID As Integer) As InputControl
        ' Create an InputControl and put it in the CanvasPanel
        ' InputID should be between 0 and 6 (Corresponding to A-F)
        ' 1 Means the input isn't named and will display 0 or 1 instead
        If InputID < 0 Or InputID > 6 Then
            Return Nothing
        End If


        Dim input As InputControl = New InputControl(InputID)
        'CanvasPanel.Controls.Add(input)
        Canvas.DragControls.Add(input)

        ' Add it to the global list
        InputsList.Add(input)

        ' Set this value to the global value if the control is named
        If input.IsNamed Then
            input.Value = globalValues(InputID - 1)
        End If

        ' Something has changed..
        UnsavedChanges = True

        Return input
    End Function
    Public Function AddGateControl(ByVal GateType As Integer) As GateControl
        ' Create a GateControl and put it in the CanvasPanel
        ' GateType should be between 0 and 6 (AND OR XOR NAND NOR XNOR NOT)
        If GateType < 0 Or GateType > 6 Then
            Return Nothing
        End If

        Dim gate As GateControl = New GateControl(GateType)
        'CanvasPanel.Controls.Add(gate)
        Canvas.DragControls.Add(gate)

        ' Add it to the global list
        GatesList.Add(gate)

        ' Something has changed..
        UnsavedChanges = True

        Return gate
    End Function
    Public Function AddOutputControl() As OutputControl
        ' Adds an output control to the canvas and returns it

        Dim out As OutputControl = New OutputControl()
        'CanvasPanel.Controls.Add(out)
        Canvas.DragControls.Add(out)

        ' Add it to the global list
        OutputsList.Add(out)

        ' Something has changed..
        UnsavedChanges = True

        Return out
    End Function


    ' Private Subs -----------------------------------------------


    ' Toolbar stuff -----------------
    ' These are sub procedures that are called from the toolbar

    Private Sub ToolbarInputClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Button = sender
        Dim InputID As Integer = btn.TabIndex

        Dim control As InputControl = AddInputControl(InputID)
        PositionControl(control)
    End Sub

    Private Sub ToolbarOpClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Button = sender
        Dim ID As Integer = btn.TabIndex - 7

        Dim control As GateControl = AddGateControl(ID)
        PositionControl(control)
    End Sub

    Private Sub ToolbarOutputClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Button = sender

        Dim control As OutputControl = AddOutputControl()
        PositionControl(control)
    End Sub


    ' -------------------------------




    Private Sub PositionControl(ByVal control As DragControl)

        ' If the CanvasPanel has been scrolled a bit, then the control should
        ' be positioned relative to this so we can always see it when it has
        ' been created
        Dim scroll As New Point(CanvasPanel.HorizontalScroll.Value, CanvasPanel.VerticalScroll.Value)

        control.Location = scroll + New Point(20 + createdPosition * 20, 20 + createdPosition * 20)

        ' Increase the createdPosition by one and cycle it round after 5
        createdPosition += 1
        If createdPosition > 5 Then
            createdPosition = 0
        End If
    End Sub


    Private Sub Clear()

        ' This just clears everything on the canvas
        While InputsList.Count > 0
            DeleteControl(InputsList.Item(0))
        End While
        While GatesList.Count > 0
            DeleteControl(GatesList.Item(0))
        End While
        While OutputsList.Count > 0
            DeleteControl(OutputsList.Item(0))
        End While

        ' Scroll up
        CanvasPanel.AutoScrollPosition = New Point(0, 0)

        UnsavedChanges = False
        createdPosition = 0
    End Sub

    Private Sub DeleteControl(ByVal control As DragControl)
        ' Deletes a control from the canvas, all it's links

        ' If the mouse link is the control we're about to delete
        ' then clear the values of it
        If Not IsNothing(mouseLink.Start) Then
            If control.Equals(mouseLink.Start) Then
                mouseLink.Start = Nothing
            End If
        End If

        ' Same for finish link
        If Not IsNothing(mouseLink.Finish) Then
            If control.Equals(mouseLink.Finish.Control) Then
                mouseLink.Finish = Nothing
            End If
        End If




        ' GateControls and OutputControls have InputA
        If control.HasInput1 Then
            control.DeleteInput1()
        End If

        ' GateControls have InputB
        If control.HasInput2 Then
            control.DeleteInput2()
        End If

        ' GateControls and OutputControls have Output
        If control.HasOutput Then
            control.DeleteAllOutputs()
        End If

        ' Remove the gate from the respective list
        If IsInputControl(control) Then
            InputsList.Remove(control)
        ElseIf IsGateControl(control) Then
            GatesList.Remove(control)
        ElseIf IsOutputControl(control) Then
            OutputsList.Remove(control)
        End If

        ' Remove the gate from the screen
        Canvas.DragControls.Remove(control)

        ' Something has changed..
        UnsavedChanges = True
    End Sub


    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Main Load

        Me.KeyPreview = True

        ' Firstly create a Canvas object and put it into the CanvasPanel
        ' This is a panel or 'layer' which has its own draw function
        ' and is responsible for drawing links dynamically
        Canvas = New CanvasControl()
        CanvasPanel.Controls.Add(Canvas)
        Canvas.BringToFront()
        Canvas.Location = New Point(0, 0)
        Canvas.Size = New Size(2048, 1024)
        Canvas.Invalidate()

        ' Next we need to add buttons to the toolbar
        ' This is done in code rather than design view for ease.
        ' (Make sure TabIndex is incremented for each button)

        Dim Index As Integer = 0

        Dim inputbtn As Button = New Button()

        inputbtn.Text = "Constant Input"
        inputbtn.TabIndex = Index
        inputbtn.Width = 60
        inputbtn.Height = 49
        Toolbar1.Controls.Add(inputbtn)

        AddHandler inputbtn.Click, AddressOf ToolbarInputClick
        Index += 1

        ' Use an empty label as a spacer
        Dim label2 As Label = New Label()
        Toolbar1.Controls.Add(label2)
        label2.Width = 10

        ' Append 5 input buttons into the toolbar
        ' These buttons spawn InputControls
        For I As Integer = 0 To 5
            Dim btn As Button = New Button()

            btn.Text = NumToLetter(I + 1)
            btn.TabIndex = Index
            btn.Width = 30
            btn.Height = 49
            Toolbar1.Controls.Add(btn)

            AddHandler btn.Click, AddressOf ToolbarInputClick

            Index += 1
        Next

        ' Use an empty label as a gap
        Dim label As Label = New Label()
        Toolbar1.Controls.Add(label)
        label.Width = 10

        ' Append 6 operator buttons to the toolbar
        ' These spawn GateControls
        For I As Integer = 0 To 6
            Dim btn As Button = New Button()

            btn.Text = NumToOpText(I)
            btn.TabIndex = Index
            btn.Width = 49
            btn.Height = 49
            Toolbar1.Controls.Add(btn)

            AddHandler btn.Click, AddressOf ToolbarOpClick
            Index += 1
        Next

        ' Use an empty label as a gap
        Dim label3 As Label = New Label()
        Toolbar1.Controls.Add(label3)
        label3.Width = 10


        ' This last button is the output button which spawns an OutputControl
        Dim obtn As Button = New Button()
        obtn.Text = "Output"
        obtn.TabIndex = 13
        obtn.Width = 50
        obtn.Height = 49
        Toolbar1.Controls.Add(obtn)

        AddHandler obtn.Click, AddressOf ToolbarOutputClick

    End Sub


    Private Sub UpdateTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateTimer.Tick
        ' This is the UpdateTimer which is run every 100 miliseconds
        ' It loops through each GateControl/OutputControl and calls the update function

        ' There is a problem with this model. Each gate is updated only once per frame.
        ' So that means if a gate's output is required by another gate that is updated
        ' AFTER the first gate, there will be a 1 frame delay (100ms) where the output
        ' value is dirty. For example: In theory ((A AND 1) XOR A) will never be 1 but 
        ' if the AND gate is created after the XOR gate, you will notice that the output
        ' will be 1 for 100ms

        ' If I had more time I would implement some kind of isDirty variable but I'm not
        ' sure how that'd work

        For Each gate As GateControl In GatesList
            gate.UpdateOutput()
        Next

        For Each output As OutputControl In OutputsList
            output.UpdateOutput()
        Next
    End Sub

    Private Sub DrawTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrawTimer.Tick
        ' This is the DrawTimer, this is run many more times than the update timer
        ' It 'Invalidates' the Canvas which then calls the paint function
        ' The paint function then draws all the links.
        Canvas.Invalidate()
    End Sub





    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewButton.Click
        CreateNew()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpressionManagerButton.Click
        If ExpressionWindow.Visible Then
            ExpressionWindow.Hide()
        Else
            ExpressionWindow.Show(Me)
        End If
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputsButton.Click
        If InputsWindow.Visible Then
            InputsWindow.Hide()
        Else
            InputsWindow.Show(Me)
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutButton.Click
        If AboutWindow.Visible Then
            AboutWindow.Hide()
        Else
            AboutWindow.ShowDialog(Me)
        End If
    End Sub

    Private Sub SaveToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        SaveDialog()
    End Sub

    Private Sub OpenToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenButton.Click
        OpenFileDialog.FileName = ""
        Dim result As DialogResult = OpenFileDialog.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            SaveLoad.Load(OpenFileDialog)
        End If
    End Sub

    Private Sub SaveDialog()
        SaveFileDialog.FileName = ""
        Dim result As DialogResult = SaveFileDialog.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            SaveLoad.Save(SaveFileDialog)
            UnsavedChanges = False
        End If
    End Sub



    ' Context menu things


    Private Sub DeleteButton_Click(ByVal sender As ToolStripMenuItem, ByVal e As System.EventArgs) Handles DeleteButton.Click
        DeleteControl(RightClickMenuFor)
    End Sub

    Private Sub ValueButton_Click(ByVal sender As ToolStripMenuItem, ByVal e As System.EventArgs) Handles ValueButton.Click
        Dim control As DragControl = RightClickMenuFor

        If IsInputControl(control) Then
            control.Value = Not control.Value
        End If
    End Sub

    Private Sub DragControlContext_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DragControlContext.Opening
        Dim control As DragControl = RightClickMenuFor

        If IsInputControl(control) Then
            Dim input As InputControl = control
            If input.IsNamed Then
                GateNameButton.Text = "Variable Input"
            Else
                GateNameButton.Text = "Constant Input"
            End If
        ElseIf IsGateControl(control) Then
            GateNameButton.Text = "Gate Type: " & NumToOpText(control.Type)
        ElseIf IsOutputControl(control) Then
            GateNameButton.Text = "Output"
        End If

        If control.Value Then
            ValueButton.Text = "Value: On"
        Else
            ValueButton.Text = "Value: Off"
        End If
    End Sub


End Class