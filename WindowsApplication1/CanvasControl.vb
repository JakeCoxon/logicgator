
Public Class CanvasControl : Inherits PictureBox

    ' Drawing Control

    ' WARNING: GDI objects aren't garbage collected

    ' Keep a list of controls to draw
    Public DragControls As New List(Of DragControl)

    ' Some constants
    Private ReadOnly DefaultPen As New Pen(Color.Black, 2)
    Private ReadOnly OnPen As New Pen(Color.Green, 2)
    Private ReadOnly OffPen As New Pen(Color.Red, 2)
    Private ReadOnly OnPen2 As New Pen(Color.Green, 3)
    Private ReadOnly OffPen2 As New Pen(Color.Red, 3)

    ' Relative mouse position
    Private mousePos As New Point()

    ' Currently dragging what?
    Private currentDrag As DragControl
    ' And how much across are we dragging from?
    Private dragOffset As Point

    ' What is currently under the mouse?
    Private hoverControl As DragControl
    ' There's a linker under the mouse you say?
    Private hoverLinker As LinkFinishType = LinkFinishType.None


    Private graphics As Graphics

    Private InputFont As New Font("verdana", 20, FontStyle.Regular, GraphicsUnit.Pixel)
    Private CenterString As StringFormat

    Sub DrawLink(ByVal pen As Pen, ByVal p1 As Point, ByVal p2 As Point)
        ' Draw a link between two points

        ' p1 should always be the output linker
        ' p2 should always be the input linker
        Dim w As Integer = Math.Abs(p2.X - p1.X)
        Dim h As Integer = Math.Abs(p2.Y - p1.Y)
        With graphics

            ' Depending how far behind the first control the second one is
            If p2.X > p1.X + 40 Then

                ' Draw a line right, down, right
                .DrawLine(pen, New Point(p1.X, p1.Y), New Point((p2.X + p1.X) / 2, p1.Y))
                .DrawLine(pen, New Point(p2.X, p2.Y), New Point((p2.X + p1.X) / 2, p2.Y))
                .DrawLine(pen, New Point((p2.X + p1.X) / 2, p1.Y), New Point((p2.X + p1.X) / 2, p2.Y))

            Else

                ' Draw a line right, down, left, down, left, down, right
                ' Ha skills
                .DrawLine(pen, New Point(p1.X, p1.Y), New Point(p1.X + 20, p1.Y))
                .DrawLine(pen, New Point(p1.X + 20, p1.Y), New Point(p1.X + 20, (p2.Y + p1.Y) / 2))
                .DrawLine(pen, New Point(p1.X + 20, (p2.Y + p1.Y) / 2), New Point(p2.X - 20, (p2.Y + p1.Y) / 2))
                .DrawLine(pen, New Point(p2.X - 20, (p2.Y + p1.Y) / 2), New Point(p2.X - 20, p2.Y))
                .DrawLine(pen, New Point(p2.X - 20, p2.Y), New Point(p2.X, p2.Y))

            End If

        End With
    End Sub

    Private Sub DrawConnectors(ByVal control As DragControl)


        Dim dotsize As New Size(8, 8)

        ' If the user is selecting a second link type,
        ' check what type the first link was so we can compare it
        ' to the inputs below. If a user can click on this second link
        ' it will go red. (Inputs can't connect to inputs for example)
        Dim type As LinkFinishType = LinkFinishType.None
        If Exists(Main.mouseLink.Start) Then
            type = LinkFinishType.Output
        ElseIf Exists(Main.mouseLink.Finish) Then
            type = Main.mouseLink.Finish.Type
        End If

        If control.HasInput1 Then
            ' Input1 stick and dot

            Dim brush As Brush = Brushes.Black

            ' canClick is true if nothing is selected yet OR an output is 
            ' selected and nothing is attached yet
            Dim canClick As Boolean = (type = LinkFinishType.None Or (type = LinkFinishType.Output AndAlso Not Exists(control.Input1Control)))

            If canClick AndAlso control.Equals(hoverControl) AndAlso hoverLinker = LinkFinishType.Input1 Then
                brush = Brushes.Red
            End If

            Dim in1pos As Point = control.Input1Pos
            Dim in1pen As Pen = DefaultPen
            If Exists(control.Input1Control) Then
                in1pen = IIf(control.Input1, OnPen2, OffPen2)
            End If
            graphics.DrawLine(in1pen, in1pos, in1pos + New Point(20, 0))
            graphics.FillEllipse(brush, New Rectangle(in1pos - New Point(4, 4), dotsize))
        End If

        If control.HasInput2 Then
            ' Input2 stick and dot

            Dim brush As Brush = Brushes.Black

            ' canClick is true if nothing is selected yet OR an output is 
            ' selected and nothing is attached yet
            Dim canClick As Boolean = (type = LinkFinishType.None Or (type = LinkFinishType.Output AndAlso Not Exists(control.Input2Control)))

            If canClick AndAlso control.Equals(hoverControl) AndAlso hoverLinker = LinkFinishType.Input2 Then
                brush = Brushes.Red
            End If

            Dim in2pos As Point = control.Input2Pos
            Dim in2pen As Pen = DefaultPen
            If Exists(control.Input2Control) Then
                in2pen = IIf(control.Input2, OnPen2, OffPen2)
            End If
            graphics.DrawLine(in2pen, in2pos, in2pos + New Point(20, 0))
            graphics.FillEllipse(brush, New Rectangle(in2pos - New Point(4, 4), dotsize))

        End If

        If control.HasOutput Then
            ' Output stick and dot

            Dim brush As Brush = Brushes.Black

            Dim canClick As Boolean = (type <> LinkFinishType.Output)
            If canClick AndAlso control.Equals(hoverControl) AndAlso hoverLinker = LinkFinishType.Output Then
                brush = Brushes.Red
            End If

            Dim outpos As Point = control.OutputPos
            Dim outpen As Pen = IIf(control.Value, OnPen2, OffPen2)
            'Dim outpen As Pen = DefaultPen
            graphics.DrawLine(outpen, outpos, outpos - New Point(20, 0))
            graphics.FillEllipse(brush, New Rectangle(outpos - New Point(4, 4), dotsize))
        End If
    End Sub


    Private Sub DrawInputControl(ByVal control As InputControl)
        Dim img As Image = IIf(control.Value, My.Resources.controlon, My.Resources.controloff)

        graphics.DrawImage(img, control.Left, control.Top, 40, 40)

        Dim text As String
        If control.IsNamed Then
            text = GlobalFunctions.NumToLetter(control.Type)
        Else
            text = IIf(control.Value, "1", "0")
        End If


        graphics.DrawString(text, InputFont, Brushes.Black, control.Left + control.Width / 2, control.Top + control.Height / 2, CenterString)
    End Sub

    Private Sub DrawGateControl(ByVal control As GateControl)

        ' Default, just in case
        Dim img As Image = My.Resources.symbol_AND
        If control.Type = Operators.OAND Then
            img = My.Resources.symbol_AND
        ElseIf control.Type = Operators.OOR Then
            img = My.Resources.symbol_OR
        ElseIf control.Type = Operators.OXOR Then
            img = My.Resources.symbol_XOR
        ElseIf control.Type = Operators.ONAND Then
            img = My.Resources.symbol_NAND
        ElseIf control.Type = Operators.ONOR Then
            img = My.Resources.symbol_NOR
        ElseIf control.Type = Operators.OXNOR Then
            img = My.Resources.symbol_XNOR
        ElseIf control.Type = Operators.ONOT Then
            img = My.Resources.symbol_NOT
        End If

        graphics.DrawImage(img, control.Left, control.Top, 100, 70)
    End Sub


    Private Sub DrawOutputControl(ByVal control As OutputControl)
        Dim img As Image = IIf(control.Value, My.Resources.controlon, My.Resources.controloff)

        graphics.DrawImage(img, control.Left, control.Top, 40, 40)

        Dim text = IIf(control.Value, "1", "0")

        graphics.DrawString(text, InputFont, Brushes.Black, control.Left + control.Width / 2, control.Top + control.Height / 2, CenterString)

    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        graphics = e.Graphics

        graphics.Clear(Color.White)

        graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.None

        ' Mouse Link

        If Not IsNothing(Main.mouseLink.Start) Then

            Dim startpos As Point = Main.mouseLink.Start.OutputPos

            ' Snap to nearest input is there is one and only if the input
            ' doesn't already have something attatched to it
            Dim endpos As Point = mousePos
            If Exists(hoverControl) Then
                If hoverLinker = LinkFinishType.Input1 AndAlso Not Exists(hoverControl.Input1Control) Then
                    endpos = hoverControl.Input1Pos
                ElseIf hoverLinker = LinkFinishType.Input2 AndAlso Not Exists(hoverControl.Input2Control) Then
                    endpos = hoverControl.Input2Pos
                End If
            End If

            DrawLink(DefaultPen, startpos, endpos)

        ElseIf Not IsNothing(Main.mouseLink.Finish) Then

            Dim l As LinkFinish = Main.mouseLink.Finish

            ' Snap to nearest output if there is one
            Dim startpos As Point = mousePos
            If Exists(hoverControl) Then
                If hoverLinker = LinkFinishType.Output Then
                    startpos = hoverControl.OutputPos
                End If
            End If

            If l.Type = LinkFinishType.Input1 Then

                DrawLink(DefaultPen, startpos, l.Control.Input1Pos)

            ElseIf l.Type = LinkFinishType.Input2 Then

                DrawLink(DefaultPen, startpos, l.Control.Input2Pos)

            End If

        End If

        For Each control As DragControl In DragControls

            If control.HasOutput Then

                Dim pen As Pen = IIf(control.Value, OnPen, OffPen)
                For Each l As LinkFinish In control.Outputs

                    If l.Type = LinkFinishType.Input1 Then
                        DrawLink(pen, control.OutputPos, l.Control.Input1Pos)

                    ElseIf l.Type = LinkFinishType.Input2 Then
                        DrawLink(pen, control.OutputPos, l.Control.Input2Pos)

                    End If

                Next
            End If

        Next

        For Each control As DragControl In DragControls

            DrawConnectors(control)

            If IsInputControl(control) Then
                DrawInputControl(control)
            ElseIf IsGateControl(control) Then
                DrawGateControl(control)
            ElseIf IsOutputControl(control) Then
                DrawOutputControl(control)
            End If
        Next



    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.SetStyle(ControlStyles.UserMouse, True)


        CenterString = New StringFormat()
        CenterString.Alignment = StringAlignment.Center
        CenterString.LineAlignment = StringAlignment.Center

    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        CenterString.Dispose()
        InputFont.Dispose()
        DefaultPen.Dispose()
        OnPen.Dispose()
        OffPen.Dispose()
        OnPen2.Dispose()
        OffPen2.Dispose()
    End Sub



    Private Sub CanvasControl_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

        CanvasControl_MouseMove(sender, e)

        If e.Button = Windows.Forms.MouseButtons.Right Then
            ' Right Click

            If Exists(hoverControl) And hoverLinker = LinkFinishType.None Then
                Main.Control_RightClick(hoverControl)
            End If

        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            ' Left Click

            If Exists(hoverControl) Then
                If hoverLinker = LinkFinishType.None Then
                    ' Mouse Down on a control

                    currentDrag = hoverControl
                    dragOffset = New Point(mousePos.X - hoverControl.Left, mousePos.Y - hoverControl.Top)

                    ' Bring to the front
                    DragControls.Remove(hoverControl)
                    DragControls.Add(hoverControl)

                Else
                    ' Mouse Down on a linker dot

                    Main.Connector_Click(hoverControl, hoverLinker)
                End If
            Else
                Main.Connector_ClickEmpty()
            End If

        End If
    End Sub

    Private Sub CanvasControl_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' Toggle the input control if we're currently hovering over one

            If Exists(hoverControl) AndAlso hoverLinker = LinkFinishType.None Then

                If IsInputControl(hoverControl) Then
                    Dim input As InputControl = hoverControl
                    input.Toggle()
                End If

            End If
        End If

    End Sub


    Private Sub CanvasControl_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        currentDrag = Nothing
    End Sub

    Private Sub CanvasControl_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        ' Update this variable every time the mouse moves
        mousePos = e.Location

        If Exists(currentDrag) Then
            currentDrag.Location = mousePos - dragOffset

            ' Clamp positions to the inside of the CanvasControl
            currentDrag.Left = Math.Max(Math.Min(currentDrag.Left, Me.Width - currentDrag.Width), 0)
            currentDrag.Top = Math.Max(Math.Min(currentDrag.Top, Me.Height - currentDrag.Height), 0)

        End If

        '

        ' A 10 pixel radius around the dot to click on
        Const HoverDistanceSquared As Single = 10 * 10

        ' 
        Dim minDist As Single = 0
        Dim nearestControl As DragControl = Nothing
        Dim nearestInput As LinkFinishType = LinkFinishType.None

        ' This loop basically checks each control starting from the top-most
        ' to see which (if any) input dot is closest to the mouse
        ' If none is close (less than HoverDistance) but there is a control
        ' under the mouse, this is the hoverControl and is used for dragging.

        For Each control As DragControl In New ReverseIterator(DragControls)

            ' If nearestControl already exists then the loop has already
            ' said the user is hovering over a 'dot' that's higher up than
            ' this control
            If Not Exists(nearestControl) Then

                Dim rect As Rectangle = New Rectangle(control.Location, control.Size)
                If rect.Contains(mousePos) Then
                    nearestControl = control
                    nearestInput = LinkFinishType.None
                    Exit For
                End If

            End If

            ' Connectors should only be considered if they actually exist on the
            ' control. (input gates don't have a Input1 or Input2 for example)

            If control.HasInput1 Then

                ' Find the position of Input1
                Dim inpt1 As Point = control.Input1Pos
                ' Calculate the distance squared between the mouse and inpt1
                Dim d1 As Single = DistanceSquared(mousePos, inpt1)

                ' This is nearest only if the distance is less than any previously calculated
                ' distances
                If d1 < HoverDistanceSquared AndAlso (d1 < minDist Or IsNothing(nearestControl)) Then
                    minDist = d1
                    nearestControl = control
                    nearestInput = LinkFinishType.Input1
                End If

            End If

            ' Repeat for Input2 connector
            If control.HasInput2 Then

                Dim inpt2 As Point = control.Input2Pos
                Dim d2 As Single = DistanceSquared(mousePos, inpt2)

                If d2 < HoverDistanceSquared AndAlso (d2 < minDist Or IsNothing(nearestControl)) Then
                    minDist = d2
                    nearestControl = control
                    nearestInput = LinkFinishType.Input2
                End If

            End If

            ' Repeat for output connector
            If control.HasOutput Then

                Dim outpt As Point = control.OutputPos
                Dim d3 As Single = DistanceSquared(mousePos, outpt)
                If d3 < HoverDistanceSquared AndAlso (d3 < minDist Or IsNothing(nearestControl)) Then
                    minDist = d3
                    nearestControl = control
                    nearestInput = LinkFinishType.Output
                End If

            End If
        Next

        ' We now have the nearest connector and the hovered control
        ' Update the Canvas variables to reflect this, for use in other
        ' procedures
        hoverControl = nearestControl
        hoverLinker = nearestInput

        ' Invalidate the Canvas so it will be redrawn
        Me.Invalidate()
    End Sub

End Class
