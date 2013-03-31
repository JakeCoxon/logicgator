Public Class ExpressionWindow

    Private CurrentExp As ExpressionBase
    Private loadCount As Integer = 0

    ' -- For generating Expressions ------------------------------------

    Private Function GenerateSubExpression(ByVal control As DragControl, Optional ByVal Level As Integer = 0) As ExpressionBase

        ' Level is only used to check how deep the expression goes
        ' 16 is pretty arbitary
        If Level > 16 Then
            Throw New Exception("Too large. Perhaps an infinite loop?")
        End If

        Dim IsNotted As Boolean = False

        ' This is great. Keeps looping through each NOT gates
        ' So if the graph looks like AND->NOT->NOT->NOT then it will
        ' toggle IsNotted 3 times

        While TypeOf (control) Is GateControl
            Dim gate As GateControl = control
            If gate.Type <> Operators.ONOT Then
                Exit While
            End If

            IsNotted = Not IsNotted

            control = gate.Input1Control
        End While

        ' If the control is a Gate

        If TypeOf (control) Is GateControl Then

            Dim gate As GateControl = control

            ' The while loop a few lines above should have checked for NOT gates
            ' but this is here anyway
            If gate.Type = Operators.ONOT Then
                Throw New Exception("This shouldn't happen")
            Else
                ' Other gates have two inputs
                If IsNothing(gate.Input1Control) Or IsNothing(gate.Input2Control) Then
                    Throw New Exception("Expression leads to a dead end")
                End If
            End If

            Dim Exp As New Expression()
            Exp.Op = gate.Type

            ' Our local IsNotted value might be true so we need to NOT the IsNotted value of the expression
            ' Because Exp.Notted might already be true
            ' I hope that makes sense
            If IsNotted Then
                Exp.Notted = Not Exp.Notted
            End If

            ' Generate a sub expression for each half of the expression
            Exp.Input1 = GenerateSubExpression(gate.Input1Control, Level + 1)
            Exp.Input2 = GenerateSubExpression(gate.Input2Control, Level + 1)
            Return Exp

        ElseIf TypeOf (control) Is InputControl Then

            Dim input As InputControl = control

            If input.IsNamed Then
                ' If the input is named, create an ExpressionInput structure for this
                Dim expinput As ExpressionInput = New ExpressionInput(input.Type, IsNotted)
                Return expinput
            Else
                ' Otherwise, its just a 0 or 1 and use ExpressionConstant
                Dim expinput As ExpressionConstant = New ExpressionConstant(input.Value, IsNotted)
                Return expinput
            End If

        End If
        Return Nothing

    End Function

    Public Function GenerateExpression() As ExpressionBase

        Dim output As OutputControl = Nothing

        loadCount = 0

        If Main.OutputsList.Count > 1 Then
            Throw New Exception("Unfortunately I cannot generate an expression with more than one output control")
        ElseIf Main.OutputsList.Count = 0 Then
            Throw New Exception("There needs to be one output control to generate an expression")
        End If

        output = Main.OutputsList.Item(0)

        ' Output should be linked to something
        If IsNothing(output.Input1Control) Then
            Throw New Exception("Expression leads to a dead end")
        End If

        ' Start with the first control linked to the OutputControl
        Dim nextcontrol = output.Input1Control

        Dim Exp = GenerateSubExpression(nextcontrol)

        Return Exp

    End Function

    ' -----------------------------------------------

    ' Other windows should call this with the new expression after they clicked OK
    Public Sub ReceiveExpression(ByRef Exp As ExpressionBase)
        CurrentExp = Exp
        UpdatePreview()
    End Sub

    Private Sub UpdatePreview()
        OutputLabel.Text = CurrentExp.ToString()
    End Sub

    
    ' Input Expression
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim result As DialogResult = ExpressionInputWindow.ShowDialog(Me)
    End Sub

    ' Edit Expression
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If IsNothing(CurrentExp) Then
            ExpressionText.TextBox1.Text = ""
        Else
            ExpressionText.TextBox1.Text = CurrentExp.ToString()
        End If
        Dim result As DialogResult = ExpressionText.ShowDialog(Me)
    End Sub


    ' Load Expression from Gates
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            CurrentExp = GenerateExpression()
            UpdatePreview()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    ' Simplification
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        If IsNothing(CurrentExp) Then
            MsgBox("There is no expression loaded", MsgBoxStyle.Critical)
            Return
        End If
        SimplifyWindow.SetExpression(CurrentExp.Clone(True))
        Dim result As DialogResult = SimplifyWindow.ShowDialog(Me)
    End Sub

    ' Create Gates from Expression
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If IsNothing(CurrentExp) Then
            MsgBox("There is no expression loaded", MsgBoxStyle.Critical)
            Return
        End If
        Main.CreateGraphFromExpression(CurrentExp)
    End Sub

    Private Sub ExpressionWindow_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        OutputLabel.Text = ""
    End Sub

    
End Class