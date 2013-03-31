Public Module ExpressionModule

    ' Base Class that is inherited by Expression, ExpressionInput and ExpressionConstant
    Public MustInherit Class ExpressionBase

        Private IsNotted As Boolean ' Private variable

        ' Voodoo ahead
        ' Notted is a Property which reads and modifies the private
        ' variable IsNotted. The property is overriable for Expression
        ' Properties are basically variables with getter and setter functions
        Public Overridable Property Notted() As Boolean
            Get
                Return IsNotted
            End Get
            Set(ByVal value As Boolean)
                IsNotted = value
            End Set
        End Property

        ' Note: This is slow because we're converting both to a string
        ' If I had time I might create a proper equality function
        ' This SHOULD work however. I can't think of a time where ToString()
        ' would equal but the Expression wouldn't..?

        Public Overridable Overloads Function Equals(ByVal text As String) As Boolean
            Return ToString() = text
        End Function

        Public Overridable Overloads Function Equals(ByVal Exp As ExpressionBase) As Boolean
            Return ToString() = Exp.ToString()
        End Function

        Public MustOverride Function Clone(Optional ByVal Deep As Boolean = False) As ExpressionBase
    End Class

    ' An expression that can be 0 or 1 and has a Notted boolean
    Public Class ExpressionConstant
        Inherits ExpressionBase

        Public Value As Boolean

        Public Sub New(ByVal Value As Boolean, ByVal Notted As Boolean)
            Me.Value = Value
            Me.Notted = Notted
        End Sub

        Public Overrides Function ToString() As String
            Dim ret As String = "0" ' "0" or "1"
            If Value = True Then
                ret = "1"
            End If
            If Notted Then
                ret &= "'"
            End If
            Return ret
        End Function

        Public Overrides Function Clone(Optional ByVal Deep As Boolean = False) As ExpressionBase
            Return New ExpressionConstant(Value, Notted)
        End Function


    End Class

    ' An expression that has a number from 1-6 meaning A-F
    ' It also has a Notted boolean
    Public Class ExpressionInput
        Inherits ExpressionBase

        Public InputID As Integer

        Public Sub New(ByVal InputID As Integer, ByVal Notted As Boolean)
            Me.InputID = InputID
            Me.Notted = Notted
        End Sub

        Public Overrides Function ToString() As String
            Dim ret As String = NumToLetter(InputID)
            If Notted Then
                ret &= "'"
            End If
            Return ret
        End Function

        Public Overrides Function Clone(Optional ByVal Deep As Boolean = False) As ExpressionBase
            Return New ExpressionInput(InputID, Notted)
        End Function
    End Class

    ' An expression with two sub-expressions, an Operator value and a Notted boolean
    Public Class Expression
        Inherits ExpressionBase

        Public Input1 As ExpressionBase
        Public Input2 As ExpressionBase
        Public Op As Operators

        ' Overrides the Notted property of ExpressionBase
        ' Notted will actually return whether OP is NAND as apposed to AND etc
        Public Overrides Property Notted() As Boolean
            Get
                Return Op = Operators.ONAND OrElse Op = Operators.ONOR OrElse Op = Operators.OXNOR
            End Get
            Set(ByVal value As Boolean)
                If IsNothing(Op) Then
                    Throw New Exception("Tried to NOT an expression with no operator")
                End If

                If value Then
                    ' If Notted then change ANDs to NANDS etc
                    If Op = Operators.OAND Then
                        Op = Operators.ONAND
                    ElseIf Op = Operators.OOR Then
                        Op = Operators.ONOR
                    ElseIf Op = Operators.OXOR Then
                        Op = Operators.OXNOR
                    End If
                Else
                    ' If ISNT Notted then changed NANDS to ANDS etc
                    If Op = Operators.ONAND Then
                        Op = Operators.OAND
                    ElseIf Op = Operators.ONOR Then
                        Op = Operators.OOR
                    ElseIf Op = Operators.OXNOR Then
                        Op = Operators.OXOR
                    End If
                End If
            End Set
        End Property

        Public Overrides Function ToString() As String
            Dim left As String = Input1.ToString()
            Dim right As String = Input2.ToString()

            Dim ret As String = "(" & left & NumToOp(Op) & right & ")"

            If Notted Then
                ret &= "'"
            End If

            Return ret
        End Function

        Public Overrides Function Clone(Optional ByVal Deep As Boolean = False) As ExpressionBase
            Dim NewExp As New Expression()
            NewExp.Op = Op
            ' Don't modify Notted, Notted is a Property
            If Deep Then
                NewExp.Input1 = Input1.Clone(True)
                NewExp.Input2 = Input2.Clone(True)
            Else
                NewExp.Input1 = Input1
                NewExp.Input2 = Input2
            End If
            Return NewExp
        End Function

    End Class



    ' Some helper functions


    Public Function IsExpression(ByVal exp As ExpressionBase)
        Return TypeOf exp Is Expression
    End Function
    Public Function IsExpressionInput(ByVal exp As ExpressionBase)
        Return TypeOf exp Is ExpressionInput
    End Function
    Public Function IsExpressionConstant(ByVal exp As ExpressionBase)
        Return TypeOf exp Is ExpressionConstant
    End Function

End Module
