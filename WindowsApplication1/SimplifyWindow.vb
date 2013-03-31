Public Class SimplifyWindow

    Private CurrentExp As ExpressionBase

    Public Sub SetExpression(ByVal Exp As ExpressionBase)
        CurrentExp = Exp
        StartText = Exp.ToString()
        ConsoleText = ""
        UpdatePreview()
    End Sub

    Delegate Function RecurseFunc(ByVal Exp As ExpressionBase) As ExpressionBase

    Private Function Recursive(ByRef ExpBase As ExpressionBase, ByVal func As RecurseFunc) As ExpressionBase
        ' Huge recurse function
        ' Return Nothing to leave unchanged

        ' Run the function for this ExpressionBase object
        Dim result As ExpressionBase = func.Invoke(ExpBase)

        ' If the function returned a value then we want to update this up the tree
        If Not IsNothing(result) Then
            AddConsoleText("Replaced " & ExpBase.ToString() & " with " & result.ToString())
            ' So return it
            Return result
        End If

        ' If the ExpressionBase object is an Expression (A+B)
        ' then we want to recurse down to both sides
        If IsExpression(ExpBase) Then
            Dim Exp As Expression = ExpBase

            ' First run Recursive to the left half
            Dim result1 As ExpressionBase = Recursive(Exp.Input1, func)
            If Not IsNothing(result1) Then
                ' If it succeeds, append the value to the Expression and return
                Exp.Input1 = result1
                Return Exp
            End If

            ' Only continue here if the left half didn't succeed
            ' because we only want to simplify ONE thing at a time.

            ' Do the same to the second half
            Dim result2 As ExpressionBase = Recursive(Exp.Input2, func)
            If Not IsNothing(result2) Then
                Exp.Input2 = result2
                Return Exp
            End If

            ' Return Nothing if nothing was modified
            Return Nothing
        End If

        Return Nothing
    End Function

    ' Call simplify to start the recursion
    Private Sub Simplify(ByRef Exp As ExpressionBase, ByVal func As RecurseFunc)
        Dim result As ExpressionBase = Recursive(Exp, func)
        If Not IsNothing(result) Then
            CurrentExp = result
            UpdatePreview()
        End If
    End Sub



    ' Simplification functions

    ' Note: It is important that the functions return a NEW object
    ' rather than a reference to an old one with modified members
    ' This is because the Recursive function calls ToString() on the
    ' OLD object
    ' To do this for Expression use Exp.Clone() to create a shallow copy
    ' of the Expression
    ' If the function modifies any inputs of an Expression they MUST ALSO
    ' be copied


    ' DeMorgan's Law of (X.Y)'  ->  X'+Y'
    Private Function DeMorgan1(ByVal ExpBase As ExpressionBase) As ExpressionBase
        If Not IsExpression(ExpBase) Then
            Return Nothing
        End If

        Dim OldExp As Expression = ExpBase

        If OldExp.Op = Operators.ONAND And Not OldExp.Input1.Notted And Not OldExp.Input2.Notted Then

            Dim NewExp As New Expression()
            NewExp.Op = Operators.OOR
            NewExp.Input1 = OldExp.Input1.Clone()
            NewExp.Input1.Notted = True
            NewExp.Input2 = OldExp.Input2.Clone()
            NewExp.Input2.Notted = True

            Return NewExp
        End If

        Return Nothing
    End Function

    ' DeMorgan's Law of (X+Y)'  ->  X'.Y'
    Private Function DeMorgan2(ByVal ExpBase As ExpressionBase) As ExpressionBase
        If Not IsExpression(ExpBase) Then
            Return Nothing
        End If

        Dim OldExp As Expression = ExpBase

        If OldExp.Op = Operators.ONOR And Not OldExp.Input1.Notted And Not OldExp.Input2.Notted Then

            Dim NewExp As New Expression()
            NewExp.Op = Operators.OAND
            NewExp.Input1 = OldExp.Input1.Clone()
            NewExp.Input1.Notted = True
            NewExp.Input2 = OldExp.Input2.Clone()
            NewExp.Input2.Notted = True

            Return NewExp
        End If

        Return Nothing
    End Function

    ' DeMorgan's Law of X'.Y'  ->  (X+Y)' 
    Private Function DeMorgan3(ByVal ExpBase As ExpressionBase) As ExpressionBase
        If Not IsExpression(ExpBase) Then
            Return Nothing
        End If

        Dim OldExp As Expression = ExpBase

        If OldExp.Op = Operators.OAND And OldExp.Input1.Notted And OldExp.Input2.Notted Then

            Dim NewExp As New Expression()
            NewExp.Op = Operators.ONOR
            NewExp.Input1 = OldExp.Input1.Clone()
            NewExp.Input1.Notted = False
            NewExp.Input2 = OldExp.Input2.Clone()
            NewExp.Input2.Notted = False

            Return NewExp
        End If

        Return Nothing
    End Function

    ' DeMorgan's Law of X'+Y'  ->  (X.Y)' 
    Private Function DeMorgan4(ByVal ExpBase As ExpressionBase) As ExpressionBase
        If Not IsExpression(ExpBase) Then
            Return Nothing
        End If

        Dim OldExp As Expression = ExpBase

        If OldExp.Op = Operators.OOR And OldExp.Input1.Notted And OldExp.Input2.Notted Then

            Dim NewExp As New Expression()
            NewExp.Op = Operators.ONAND
            NewExp.Input1 = OldExp.Input1.Clone()
            NewExp.Input1.Notted = False
            NewExp.Input2 = OldExp.Input2.Clone()
            NewExp.Input2.Notted = False

            Return NewExp
        End If

        Return Nothing
    End Function

    ' DeMorgan's Law of (X'.Y')'  ->  X+Y 
    Private Function DeMorgan5(ByVal ExpBase As ExpressionBase) As ExpressionBase
        If Not IsExpression(ExpBase) Then
            Return Nothing
        End If

        Dim OldExp As Expression = ExpBase

        If OldExp.Op = Operators.ONAND And OldExp.Input1.Notted And OldExp.Input2.Notted Then

            Dim NewExp As New Expression()
            NewExp.Op = Operators.OOR
            NewExp.Input1 = OldExp.Input1.Clone()
            NewExp.Input1.Notted = False
            NewExp.Input2 = OldExp.Input2.Clone()
            NewExp.Input2.Notted = False

            Return NewExp
        End If

        Return Nothing
    End Function

    ' DeMorgan's Law of (X'+Y')'  ->  X.Y 
    Private Function DeMorgan6(ByVal ExpBase As ExpressionBase) As ExpressionBase
        If Not IsExpression(ExpBase) Then
            Return Nothing
        End If

        Dim OldExp As Expression = ExpBase

        If OldExp.Op = Operators.ONOR And OldExp.Input1.Notted And OldExp.Input2.Notted Then

            Dim NewExp As New Expression()
            NewExp.Op = Operators.OAND
            NewExp.Input1 = OldExp.Input1.Clone()
            NewExp.Input1.Notted = False
            NewExp.Input2 = OldExp.Input2.Clone()
            NewExp.Input2.Notted = False

            Return NewExp
        End If

        Return Nothing
    End Function


    ' 0'  ->  1
    Private Function Simplify1(ByVal ExpBase As ExpressionBase) As ExpressionBase
        If Not IsExpressionConstant(ExpBase) Then
            Return Nothing
        End If

        Dim Input As ExpressionConstant = ExpBase

        If Input.Value = False And Input.Notted Then
            Return New ExpressionConstant(1, False)
        End If

        Return Nothing
    End Function

    ' 1'  ->  0
    Private Function Simplify2(ByVal ExpBase As ExpressionBase) As ExpressionBase
        If Not IsExpressionConstant(ExpBase) Then
            Return Nothing
        End If

        Dim Input As ExpressionConstant = ExpBase

        If Input.Value = True And Input.Notted Then
            Return New ExpressionConstant(0, False)
        End If

        Return Nothing
    End Function

    ' X+0  ->  X
    ' (X+0)'  ->  X'
    Private Function Simplify3(ByVal ExpBase As ExpressionBase) As ExpressionBase
        ' This function takes an Expression and returns whatever X is
        If Not IsExpression(ExpBase) Then
            Return Nothing
        End If

        Dim Exp As Expression = ExpBase

        If Not (Exp.Op = Operators.OOR Or Exp.Op = Operators.ONOR) Then
            ' Expression isn't OR or NOR so it doesn't concern us
            Return Nothing
        End If

        Dim IsNotted As Boolean = Exp.Notted

        ' Note: Refer to shallow copy note above
        Dim NewExp As ExpressionBase

        ' Is Input1 is an InputNumber and equals to "0"
        If Exp.Input1.Equals("0") Then
            ' The left side is a zero so use the right side
            NewExp = Exp.Input2.Clone()
        ElseIf Exp.Input2.Equals("0") Then
            ' The right side is zero so use the left side
            NewExp = Exp.Input1.Clone()
        Else
            ' Neither are zero so quit
            Return Nothing
        End If

        ' NOT the Expression if needed
        If IsNotted Then
            NewExp.Notted = Not NewExp.Notted
        End If

        Return NewExp
    End Function

    ' X+1  ->  1
    ' (X+1)'  ->  0
    Private Function Simplify4(ByVal ExpBase As ExpressionBase) As ExpressionBase
        ' This function takes an Expression and returns an ExpressionConstant(1)
        ' We don't actually care what X is
        If Not IsExpression(ExpBase) Then
            ' Not interesting in non-expressions
            Return Nothing
        End If

        Dim Exp As Expression = ExpBase

        If Not (Exp.Op = Operators.OOR Or Exp.Op = Operators.ONOR) Then
            ' Expression isn't OR or NOR so it doesn't concern us
            Return Nothing
        End If

        ' IsNotted = true means Op = NOR
        Dim IsNotted As Boolean = Exp.Notted

        If Exp.Input1.Equals("1") OrElse Exp.Input2.Equals("1") Then
            ' Left or right is ExpressionConstant(1) so we're definitely going
            ' to return something

            ' If IsNotted then we want to return 1' but we will simplify this quickly to 0
            If IsNotted Then
                Return New ExpressionConstant(0, False)
            Else
                Return New ExpressionConstant(1, False)
            End If

        End If

        Return Nothing

    End Function

    ' X.0  ->  1
    ' (X.0)'  ->  0
    Private Function Simplify5(ByVal ExpBase As ExpressionBase) As ExpressionBase
        ' This function takes an Expression and returns an ExpressionConstant(0)
        ' We don't actually care what X is
        ' (This is similar to Simplify4)
        If Not IsExpression(ExpBase) Then
            ' Not interesting in non-expressions
            Return Nothing
        End If

        Dim Exp As Expression = ExpBase

        If Not (Exp.Op = Operators.OAND Or Exp.Op = Operators.ONAND) Then
            ' Expression isn't AND or NAND so it doesn't concern us
            Return Nothing
        End If

        Dim IsNotted As Boolean = Exp.Notted

        If Exp.Input1.Equals("0") OrElse Exp.Input2.Equals("0") Then

            ' If IsNotted then we want to return 0' but we will simplify this quickly to 1
            If IsNotted Then
                Return New ExpressionConstant(1, False)
            Else
                Return New ExpressionConstant(0, False)
            End If

        End If

        Return Nothing
    End Function

    ' X.1  ->  X
    ' (X.1)'  ->  X'
    Private Function Simplify6(ByVal ExpBase As ExpressionBase) As ExpressionBase
        ' This function takes an Expression and returns whatever X is
        ' (This is similar to Simplify3)
        If Not IsExpression(ExpBase) Then
            Return Nothing
        End If

        Dim Exp As Expression = ExpBase

        If Not (Exp.Op = Operators.OAND Or Exp.Op = Operators.ONAND) Then
            ' Expression isn't AND or NAND so it doesn't concern us
            Return Nothing
        End If

        Dim IsNotted As Boolean = Exp.Notted

        ' Note: Refer to shallow copy note above
        Dim NewExp As ExpressionBase

        ' Is Input1 is an InputNumber and equals to "0"
        If Exp.Input1.Equals("1") Then
            ' The left side is a one so use the right side
            NewExp = Exp.Input2.Clone()
        ElseIf Exp.Input2.Equals("1") Then
            ' The right side is one so use the left side
            NewExp = Exp.Input1.Clone()
        Else
            ' Neither are one so quit
            Return Nothing
        End If

        ' NOT the Expression if needed
        If IsNotted Then
            NewExp.Notted = Not NewExp.Notted
        End If

        Return NewExp
    End Function

    ' X+X  ->  X
    ' (X+X)'  ->  X'
    Private Function Simplify7(ByVal ExpBase As ExpressionBase) As ExpressionBase
        If Not IsExpression(ExpBase) Then
            Return Nothing
        End If

        Dim Exp As Expression = ExpBase

        If Not (Exp.Op = Operators.OOR Or Exp.Op = Operators.ONOR) Then
            ' Expression isn't OR or NOR so it doesn't concern us
            Return Nothing
        End If

        Dim IsNotted As Boolean = Exp.Notted

        If Exp.Input1.Equals(Exp.Input2) Then
            ' The two sides are identical
            Dim NewExp As ExpressionBase = Exp.Input1.Clone()
            If IsNotted Then
                NewExp.Notted = Not NewExp.Notted
            End If

            Return NewExp
        End If

        Return Nothing
    End Function

    ' X.X  ->  X
    ' (X.X)'  ->  X'
    Private Function Simplify8(ByVal ExpBase As ExpressionBase) As ExpressionBase
        If Not IsExpression(ExpBase) Then
            Return Nothing
        End If

        Dim Exp As Expression = ExpBase

        If Not (Exp.Op = Operators.OAND Or Exp.Op = Operators.ONAND) Then
            ' Expression isn't AND or NAND so it doesn't concern us
            Return Nothing
        End If

        Dim IsNotted As Boolean = Exp.Notted

        If Exp.Input1.Equals(Exp.Input2) Then
            ' The two sides are identical
            Dim NewExp As ExpressionBase = Exp.Input1.Clone()
            If IsNotted Then
                NewExp.Notted = Not NewExp.Notted
            End If

            Return NewExp
        End If

        Return Nothing
    End Function







    ' Interface
    ' --------------------------------------------------------------------------

    Private StartText As String = ""
    Private ConsoleText As String = ""

    Private Sub AddConsoleText(ByVal text As String)
        ConsoleText &= vbNewLine & text
    End Sub

    Private Sub UpdatePreview()
        Dim Preview As String = CurrentExp.ToString()

        OutputLabel.Text = Preview

        ConsoleBox.Text = "Started with " & StartText & ConsoleText & vbNewLine & "Ended with " & Preview
        ConsoleBox.SelectionStart = ConsoleBox.TextLength
        ConsoleBox.ScrollToCaret()
    End Sub


    Private Sub SimplifyWindow_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' This should be filled out by whatever opens the window
        'OutputLabel.Text = ""
    End Sub





    Private Sub ButtonDM1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDM1.Click
        Simplify(CurrentExp, AddressOf DeMorgan1)
    End Sub

    Private Sub ButtonDM2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDM2.Click
        Simplify(CurrentExp, AddressOf DeMorgan2)
    End Sub

    Private Sub ButtonDM3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDM3.Click
        Simplify(CurrentExp, AddressOf DeMorgan3)
    End Sub

    Private Sub ButtonDM4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDM4.Click
        Simplify(CurrentExp, AddressOf DeMorgan4)
    End Sub

    Private Sub ButtonDM5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDM5.Click
        Simplify(CurrentExp, AddressOf DeMorgan5)
    End Sub

    Private Sub ButtonDM6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDM6.Click
        Simplify(CurrentExp, AddressOf DeMorgan6)
    End Sub


    Private Sub ButtonS1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonS1.Click
        Simplify(CurrentExp, AddressOf Simplify1)
    End Sub

    Private Sub ButtonS2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonS2.Click
        Simplify(CurrentExp, AddressOf Simplify2)
    End Sub

    Private Sub ButtonS3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonS3.Click
        Simplify(CurrentExp, AddressOf Simplify3)
    End Sub

    Private Sub ButtonS4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonS4.Click
        Simplify(CurrentExp, AddressOf Simplify4)
    End Sub

    Private Sub ButtonS5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonS5.Click
        Simplify(CurrentExp, AddressOf Simplify5)
    End Sub

    Private Sub ButtonS6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonS6.Click
        Simplify(CurrentExp, AddressOf Simplify6)
    End Sub

    Private Sub ButtonS7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonS7.Click
        Simplify(CurrentExp, AddressOf Simplify7)
    End Sub

    Private Sub ButtonS8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonS8.Click
        Simplify(CurrentExp, AddressOf Simplify8)
    End Sub



    Private Sub ButtonOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click
        ExpressionWindow.ReceiveExpression(CurrentExp)
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class