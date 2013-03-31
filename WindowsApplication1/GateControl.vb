
Public Class GateControl
    Inherits DragControl

    ' Welcome to the GateControl
    ' See DragControl.vb for details

    Private m_Value As Boolean = False

    ' Properties


    Public Overrides ReadOnly Property Input1Pos() As Point
        Get
            ' NOT Gate so input1 is center
            If Type = Operators.ONOT Then
                Return MyBase.Input1Pos
            Else
                Return New Point(Left - 10, Top + 15)
            End If
        End Get
    End Property
    Public Overrides ReadOnly Property Input2Pos() As Point
        Get
            ' There isn't an inpu2 for not gates but do this anyway
            If Type = Operators.ONOT Then
                Return MyBase.Input1Pos
            Else
                Return New Point(Left - 10, Top + Height - 15)
            End If
        End Get
    End Property

    Public Overrides ReadOnly Property HasInput1() As Boolean
        Get
            Return True
        End Get
    End Property
    Public Overrides ReadOnly Property HasInput2() As Boolean
        Get
            If Type = Operators.ONOT Then
                Return False
            End If
            Return True
        End Get
    End Property
    Public Overrides ReadOnly Property HasOutput() As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Property Value() As Boolean
        Get
            Return m_Value
        End Get
        Set(ByVal value As Boolean)
            m_Value = value
        End Set
    End Property

    ' Private Functions

    Private Function CalculateGateValue(ByVal A As Boolean, ByVal B As Boolean, ByVal Type As Operators) As Boolean
        ' Do the calculation
        If Type = Operators.OAND Then
            Return A And B
        ElseIf Type = Operators.OOR Then
            Return A Or B
        ElseIf Type = Operators.ONAND Then
            Return Not (A And B)
        ElseIf Type = Operators.ONOR Then
            Return Not (A Or B)
        ElseIf Type = Operators.OXOR Then
            Return (A Xor B)
        ElseIf Type = Operators.OXNOR Then
            Return Not (A Xor B)
        End If
    End Function

    ' Public Functions

    Public Sub UpdateOutput()
        If Type = Operators.ONOT Then
            Value = Not Input1
        Else

            Dim A As Boolean = Input1
            Dim B As Boolean = Input2
            Value = CalculateGateValue(A, B, Type)

        End If
    End Sub

    Public Sub New(ByVal GateType As Operators)
        'InitializeComponent()

        ' Set the type
        Me.m_Type = GateType
        ' Set the size
        Me.Width = 100
        Me.Height = 70
    End Sub

End Class
