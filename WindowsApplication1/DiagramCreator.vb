Public Class DiagramCreator
    Private output As OutputControl
    Private inputs As New List(Of InputControl)
    Private columns(6) As List(Of GateControl) ' Columns start at zero on the right
    Private NumColumns As Integer = 0

    Private Const GateWidth As Integer = 100
    Private Const GateHeight As Integer = 70
    Private Const InputWidth As Integer = 45
    Private Const InputHeight As Integer = 40
    Private Const StartX As Integer = 50 ' X distance from left of the canvas
    Private Const StartY As Integer = 50 ' Y distance from top of the canvas
    Private Const MarginX As Integer = 75 ' X Distance between each gate
    Private Const MarginY As Integer = 50 ' Y Distance between input control

    ' We need to store the gates into columns so we can position
    ' them IN ORDER from left to right
    Private Sub AddToColumn(ByVal ColumnID As Integer, ByVal gate As GateControl)
        If ColumnID > 6 Then
            Throw New Exception("The graph you want to construct is too complex.")
        End If
        ' ColumnID is zero based but NumColumns isn't
        columns(ColumnID).Add(gate)
        NumColumns = Math.Max(NumColumns, ColumnID + 1)
    End Sub



    Public Sub Create(ByVal Exp As ExpressionBase)
        For I = 0 To 6
            columns(I) = New List(Of GateControl)
        Next

        Main.CanvasPanel.SuspendLayout()

        output = Main.AddOutputControl()
        CreateSub(Exp, CreateLinkFinish(output, LinkFinishType.Input1), 0)

        Position()

        Main.CanvasPanel.ResumeLayout()
    End Sub

    Private Sub CreateNot(ByRef nextlink As LinkFinish, ByVal Level As Integer)
        Dim notgate As GateControl
        notgate = Main.AddGateControl(Operators.ONOT)
        Main.CreateLink(notgate, nextlink)

        AddToColumn(Level, notgate)

        nextlink = CreateLinkFinish(notgate, LinkFinishType.Input1) ' Update this for the rest of the function
    End Sub

    Private Sub CreateSub(ByVal ExpBase As ExpressionBase, ByRef LinkTo As LinkFinish, ByVal Level As Integer)
        If Level > 6 Then
            Throw New Exception("The graph you want to construct is too complex.")
        End If

        ' nextlink starts as LinkTo but if we put a Not Gate in, nextlink will be that
        Dim nextlink As LinkFinish = LinkTo

        If IsExpression(ExpBase) Then

            Dim Exp As Expression = ExpBase

            ' Updated code: Notted now returns whether Op is NAND, NOR, XNOR
            'If Exp.Notted Then
            '    CreateNot(nextlink, Level)
            '    Level += 1
            'End If

            Dim gate As GateControl = Main.AddGateControl(Exp.Op)
            Main.CreateLink(gate, nextlink)

            AddToColumn(Level, gate)

            ' Recursion!
            CreateSub(Exp.Input1, CreateLinkFinish(gate, LinkFinishType.Input1), Level + 1)
            CreateSub(Exp.Input2, CreateLinkFinish(gate, LinkFinishType.Input2), Level + 1)

        ElseIf IsExpressionInput(ExpBase) Then

            Dim inputExp As ExpressionInput = ExpBase

            If inputExp.Notted Then
                CreateNot(nextlink, Level)
                Level += 1
            End If

            Dim inputcontrol As InputControl = Main.AddInputControl(inputExp.InputID)
            Main.CreateLink(inputcontrol, nextlink)

            inputs.Add(inputcontrol)

        ElseIf IsExpressionConstant(ExpBase) Then

            Dim inputExp As ExpressionConstant = ExpBase

            If inputExp.Notted Then
                CreateNot(nextlink, Level)
                Level += 1
            End If

            Dim inputcontrol As InputControl = Main.AddInputControl(0) ' 0 is unnamed
            inputcontrol.Value = inputExp.Value
            Main.CreateLink(inputcontrol, nextlink)

            inputs.Add(inputcontrol)

        End If
    End Sub

    Private Sub Position()

        ' Space out Input Controls 
        Dim InputIndex = 0
        For Each input As InputControl In inputs
            input.Location = New Point(StartX, StartY + InputIndex * (InputHeight + MarginY))
            InputIndex += 1
        Next


        ' Loop backwards (start from left)
        For I As Integer = NumColumns - 1 To 0 Step -1

            Dim columnFromLeft = NumColumns - 1 - I ' Starts from 0

            For Each gate As GateControl In columns(I)

                If gate.Type = Operators.ONOT Then

                    Dim in1 As Point = gate.Input1Control.OutputPos
                    Dim x = StartX + InputWidth + columnFromLeft * (GateWidth + MarginX) + MarginX
                    Dim y = in1.Y - GateHeight / 2
                    gate.Location = New Point(x, y)

                Else

                    Dim in1 As Point = gate.Input1Control.OutputPos
                    Dim in2 As Point = gate.Input2Control.OutputPos
                    Dim x = StartX + InputWidth + columnFromLeft * (GateWidth + MarginX) + MarginX
                    Dim y = (in1.Y + in2.Y) / 2 - GateHeight / 2
                    gate.Location = New Point(x, y)

                End If

            Next
        Next

        Dim oi As Point = output.Input1Control.OutputPos
        Dim ox = StartX + InputWidth + NumColumns * (GateWidth + MarginX) + MarginX
        Dim oy = oi.Y - InputHeight / 2
        output.Location = New Point(ox, oy)


    End Sub

End Class