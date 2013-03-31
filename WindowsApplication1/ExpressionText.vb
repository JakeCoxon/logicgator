Public Class ExpressionText

    ' Take a step back and see how amazing this code is.

    Private Function Precedence(ByVal c As Char) As Integer
        If c = "'" Then
            Return 0                        ' NOTs have the highest precedence
        ElseIf c = "." Then
            Return 1                        ' ANDs are the next highest
        ElseIf c = "+" Or c = "@" Then
            Return 2                        ' ORs and XORs are the same
        End If
    End Function

    Private Function IsAlphabet(ByVal c As Char) As Boolean
        Dim a = UCase(c)
        Return a >= "A" And a <= "F"  ' Only A-F please
    End Function

    Private Function IsNumber(ByVal c As Char) As Boolean
        Return c = "0" Or c = "1" ' "0" or "1"
    End Function

    Private Function IsAlphaNumber(ByVal c As Char)
        Return IsAlphabet(c) OrElse IsNumber(c)
    End Function

    Private Function IsValidOperator(ByVal c As Char) As Boolean
        Return c = "." Or c = "+" Or c = "@"
    End Function

    ' This is Polish not polish
    Private Function Polish(ByVal Str As String) As List(Of Char)
        ' Convert the string into Reverse Polish Notation
        ' By using Dijsktra's Shunting-yard algorithm
        ' http://en.wikipedia.org/wiki/Reverse_Polish_notation
        ' http://en.wikipedia.org/wiki/Shunting_yard_algorithm

        ' So (A+B)'.C turns into AB+'C.
        ' This is much easier to parse into an Expression structure

        Dim output As New List(Of Char)
        Dim stack As New Stack(Of Char)

        ' This has to be a string because chars can't be empty or something
        Dim PrevChar As String = ""

        For Each LoopChar As Char In Str

            If LoopChar = " " Or LoopChar = vbTab Then

                ' Spaces and tabs.. just ignore
                ' (This means go to the next iteration of the loop
                ' and DOESN'T set PrevChar to a space)
                Continue For

            ElseIf IsAlphabet(LoopChar) Or IsNumber(LoopChar) Then

                ' Alphabets and Numbers can only come at the beginning or after an operator or open bracket
                If Not (PrevChar = "" Or IsValidOperator(PrevChar) Or PrevChar = "(") Then
                    Throw New Exception("Unexpected '" & LoopChar & "'")
                End If

                output.Add(UCase(LoopChar))

            ElseIf IsValidOperator(LoopChar) Or LoopChar = "'" Then

                ' Operators can only come after end bracket or alphabet or NOTs
                If LoopChar <> "'" And Not (IsAlphaNumber(PrevChar) Or PrevChar = ")" Or PrevChar = "'") Then
                    Throw New Exception("Unexpected '" & LoopChar & "'")
                End If

                ' But NOTs can only come after end brackets or alphabet or NOT char
                If LoopChar = "'" And Not (IsAlphaNumber(PrevChar) Or PrevChar = ")" Or PrevChar = "'") Then
                    Throw New Exception("Unexpected NOT character (')")
                End If

                While stack.Count > 0 AndAlso stack.Peek() <> "(" AndAlso Precedence(stack.Peek()) <= Precedence(LoopChar)
                    output.Add(stack.Pop())
                End While
                stack.Push(LoopChar)

            ElseIf LoopChar = "(" Then

                ' Open brackets can only come at the beginning, after another open bracket
                ' or after an operator (not a NOT though)
                If Not (PrevChar = "" Or PrevChar = "(" Or IsValidOperator(PrevChar)) Then
                    Throw New Exception("Unexpected '" & LoopChar & "'")
                End If

                stack.Push(LoopChar)

            ElseIf LoopChar = ")" Then

                ' Close brackets can only come after alphabet or NOT or end bracket
                If Not (IsAlphaNumber(PrevChar) Or PrevChar = "'" Or PrevChar = ")") Then
                    Throw New Exception("Unexpected '" & LoopChar & "'")
                End If


                ' Stack should be like (+.)
                Do Until stack.Peek() = "("
                    output.Add(stack.Pop())
                    If stack.Count = 0 Then
                        Throw New Exception("Unmatched ')'")
                    End If
                Loop
                stack.Pop() ' Remove the (

            Else

                Throw New Exception("Unexpected '" & LoopChar & "'")

            End If

            PrevChar = LoopChar
        Next

        While stack.Count > 0
            If stack.Peek() = "(" Then
                Throw New Exception("Unmatched '('")
            End If
            output.Add(stack.Pop())
        End While

        Return output
    End Function


    Private Function MakeExpression(ByVal input As List(Of Char)) As ExpressionBase

        Dim stack As New Stack(Of ExpressionBase)

        ' Create an expression using the stack
        ' Basically what happens is the stack is filled up with letters
        ' and numbers, and the operators come along a replace them

        ' So the input is in Reverse Polish Notation: AB+'C.
        ' Looping from left to right:
        ' A is pushed onto the stack
        ' B is pushed onto the stack
        ' The + means pop 2 values from the stack and push an Expression(val1 OR val2)
        '   Now there is only 1 value on the stack
        ' The ' means pop 1 value from the stack and push an Expression(NOT val)
        '   There is still 1 value on the stack
        ' C is pushed onto the stack
        '   Two values now
        ' The . means pop 2 values from the stack and push an Expression(val1 AND val2)
        '   Now there is 1 value and this is our expression

        For Each LoopChar As Char In input

            If IsAlphabet(LoopChar) Then

                ' Create an ExpressionInput and push into the stack
                Dim inputexp As New ExpressionInput(LetterToNumber(LoopChar), False)
                stack.Push(inputexp)

            ElseIf IsNumber(LoopChar) Then

                Dim value = False
                If LoopChar = "1" Then
                    value = True
                End If

                ' Create an ExpressionConstant (0 or 1) and push
                Dim inputexp As New ExpressionConstant(value, False)
                stack.Push(inputexp)

            ElseIf LoopChar = "." Or LoopChar = "+" Or LoopChar = "@" Then

                ' This should probably not happen because we already syntax check
                ' But just to be sure..
                If stack.Count < 2 Then
                    Throw New Exception("Stack is too small (Expected 2 operands)")
                End If

                Dim B As ExpressionBase = stack.Pop()
                Dim A As ExpressionBase = stack.Pop()

                Dim Exp As Expression = New Expression()
                Exp.Input1 = A
                Exp.Input2 = B

                If LoopChar = "." Then
                    Exp.Op = Operators.OAND
                ElseIf LoopChar = "+" Then
                    Exp.Op = Operators.OOR
                ElseIf LoopChar = "@" Then
                    Exp.Op = Operators.OXOR
                End If

                stack.Push(Exp)

            ElseIf LoopChar = "'" Then

                If stack.Count < 1 Then
                    Throw New Exception("Stack is too small (Expected 1 operand)")
                End If

                Dim A As ExpressionBase = stack.Peek() ' This should be a reference??
                A.Notted = Not A.Notted

            End If

        Next

        If stack.Count = 0 Then
            Throw New Exception("Nothing was inputted")
        ElseIf stack.Count > 1 Then
            Throw New Exception("Expected 1 item on stack. Got " & stack.Count)
        End If

        Return stack.Pop()

    End Function




    Private Sub InsertCharacter(ByRef c As Char)
        TextBox1.SelectedText = c
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOK.Click

        Dim Str As String = TextBox1.Text

        ' Internally use characters that I can actually type
        Str = Str.Replace("·", ".")
        Str = Str.Replace("⊕", "@")

        Dim Exp As ExpressionBase
        Try
            Dim output As List(Of Char) = Polish(Str)
            Exp = MakeExpression(output)
        Catch ex As Exception
            ErrorLabel.Text = ex.Message
            Return
        End Try

        ExpressionWindow.ReceiveExpression(Exp)
        DialogResult = Windows.Forms.DialogResult.OK

    End Sub



    Private Sub ButtonLetter_Click(ByVal sender As Button, ByVal e As System.EventArgs) _
    Handles ButtonA.Click, ButtonB.Click, ButtonC.Click, ButtonD.Click, ButtonE.Click, ButtonF.Click, _
    Button0.Click, Button1.Click
        InsertCharacter(sender.Text)
        TextBox1.Focus()
    End Sub

    Private Sub ButtonAND_Click(ByVal sender As Button, ByVal e As System.EventArgs) Handles ButtonAND.Click
        InsertCharacter("·")
        TextBox1.Focus()
    End Sub
    Private Sub ButtonOR_Click(ByVal sender As Button, ByVal e As System.EventArgs) Handles ButtonOR.Click
        InsertCharacter("+")
        TextBox1.Focus()
    End Sub
    Private Sub ButtonXOR_Click(ByVal sender As Button, ByVal e As System.EventArgs) Handles ButtonXOR.Click
        InsertCharacter("⊕")
        TextBox1.Focus()
    End Sub
    Private Sub ButtonNOT_Click(ByVal sender As Button, ByVal e As System.EventArgs) Handles ButtonNOT.Click
        Dim newtext = TextBox1.SelectedText
        If newtext.Length > 1 Then
            If Not (newtext.StartsWith("(") And newtext.EndsWith(")")) Then
                newtext = "(" & newtext & ")"
            End If
        End If
        TextBox1.SelectedText = newtext & "'"
        TextBox1.Focus()
    End Sub

    Private Sub ButtonDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDel.Click
        If TextBox1.SelectedText.Length > 0 Then
            TextBox1.SelectedText = ""
        Else
            Dim left As String
            Dim right As String
            If TextBox1.SelectionStart = 0 Then
                Return
            End If
            left = TextBox1.Text.Substring(0, TextBox1.SelectionStart - 1)
            right = TextBox1.Text.Substring(TextBox1.SelectionStart)
            TextBox1.Text = left & right
            TextBox1.SelectionStart = left.Length
        End If
        TextBox1.Focus()
    End Sub

    Private Sub ButtonBracket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBracket.Click
        Dim s = TextBox1.SelectionStart
        Dim newtext = "(" & TextBox1.SelectedText & ")"
        TextBox1.SelectedText = newtext
        If newtext.Length > 2 Then ' Nothing was selected
            TextBox1.SelectionStart = s + newtext.Length
        Else
            TextBox1.SelectionStart = s + 1
        End If
        TextBox1.Focus()
    End Sub

    Private Sub ExpressionText_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Focus()
        TextBox1.SelectionStart = TextBox1.Text.Length
        ErrorLabel.Text = ""
    End Sub
End Class
