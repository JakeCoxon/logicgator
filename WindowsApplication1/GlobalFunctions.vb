Public Module GlobalFunctions
    Public Const MIDDLEDOT As Char = "·" ' Chr(183)

    Enum Operators
        OAND
        OOR
        OXOR
        ONAND
        ONOR
        OXNOR
        ONOT
    End Enum

    ' Structure for specifying links
    Public Structure Link
        ' Start will be the output of a control
        ' (So, with two controls side by side, it would be the left one)
        Public Start As DragControl
        ' Finish will represent the input of a control
        ' (The right side)
        Public Finish As LinkFinish ' A gate's input
    End Structure

    ' Structure for representing the Finish of a link.
    ' This is needed because we need to refer to either the first input or second
    ' So we store the control and an Enum.
    Public Structure LinkFinish
        Public Control As DragControl
        Public Type As LinkFinishType
    End Structure

    ' A small function for creating a LinkFinish structure in one line
    Public Function CreateLinkFinish(ByVal Control As DragControl, ByVal Type As LinkFinishType) As LinkFinish
        Dim finish As LinkFinish
        finish.Control = Control
        finish.Type = Type
        Return finish
    End Function

    ' Enum for representing the input (or output) of a control
    Enum LinkFinishType
        None   ' Spare 0
        Input1
        Input2
        Output
    End Enum



    Public Function NumToLetter(ByVal Num As Integer)
        ' 1 is A, 2 is B, etc
        NumToLetter = Chr(Num + 64)
    End Function

    Public Function LetterToNumber(ByVal c As Char)
        LetterToNumber = Asc(c) - 64
    End Function

    ' Converts a number to an operator symbol.
    Public Function NumToOp(ByVal Num As Integer) As Char
        ' NAND, NOR, XNORs have the same symbol as AND, OR, XOR
        ' 0, 3 = ·
        ' 1, 4 = +
        ' 2, 5 = ⊕
        If Num >= 3 Then
            Num = Num - 3
        End If

        If Num = 0 Then
            Return "·"
        ElseIf Num = 1 Then
            Return "+"
        ElseIf Num = 2 Then
            Return "⊕"
        End If

        Return ""
    End Function

    Private OpTexts() As String = {"AND", "OR", "XOR", "NAND", "NOR", "XNOR", "NOT"}

    ' Convert operator to a string
    Public Function NumToOpText(ByVal Op As Operators)
        ' Op is actually an integer
        Return OpTexts(Op)
    End Function

    ' Is this operator an NOT type?
    Public Function OperatorHasNot(ByVal Op As Operators) As Boolean
        ' Returns true if Num is NAND, NOR, XNOR or NOT
        Return Op = Operators.ONAND Or Op = Operators.ONOR Or Op = Operators.OXNOR Or Op = Operators.ONOT
    End Function

    ' Quick functions for TypeOfs
    Public Function IsInputControl(ByVal control As DragControl) As Boolean
        Return TypeOf control Is InputControl
    End Function
    Public Function IsGateControl(ByVal control As DragControl) As Boolean
        Return TypeOf control Is GateControl
    End Function
    Public Function IsOutputControl(ByVal control As DragControl) As Boolean
        Return TypeOf control Is OutputControl
    End Function

    ''' <summary>
    ''' Returns true if a an object is not Nothing
    ''' </summary>
    Public Function Exists(ByVal obj As Object) As Boolean
        Return Not IsNothing(obj)
    End Function

    ' Returns the distance squared between two points
    ' This is useful because if we're comparing distances, we don't have to
    ' square root each side of the inequality
    Public Function DistanceSquared(ByVal Point1 As Point, ByVal Point2 As Point) As Single
        Dim DY = Point2.Y - Point1.Y
        Dim DX = Point2.X - Point1.X
        Return DY * DY + DX * DX
    End Function




    ' Visual Basic doesn't have a reverse enumerator so I had to make my own
    Public Class ReverseEnumerator
        Implements IEnumerator

        ' Keep a private reference to the list
        Private m_List As IList
        ' Current position of the iterator
        Private counter As Integer

        Public Sub New(ByVal list As IList)
            m_List = list
            ' Initially at the end of the list
            counter = list.Count
        End Sub

        ' Returns current position of the list
        ' ReadOnly
        Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
            Get
                Return m_List(counter)
            End Get
        End Property

        ' Moves to the next position of the list
        ' In our case, it gets smaller
        Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
            If counter <= 0 Then
                Return False
            End If
            counter -= 1
            Return True
        End Function

        ' Returns to the end of the list
        Public Sub Reset() Implements System.Collections.IEnumerator.Reset
            counter = m_List.Count
        End Sub
    End Class

    ' Reverse Iterator container class, this is so we can use the iterator
    ' in a for loop:
    '   For Each item in New ReverseIterator(list)
    Public Class ReverseIterator
        Implements IEnumerable

        Private m_Enumerator As ReverseEnumerator
        Sub New(ByVal list As IList)
            m_Enumerator = New ReverseEnumerator(list)
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return m_Enumerator
        End Function
    End Class


End Module
