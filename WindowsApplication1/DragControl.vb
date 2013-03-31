Public MustInherit Class DragControl

    ' Drag Control
    ' This is the class that InputControl, GateControl and OutputControl
    ' all inherit from.
    ' It cannot be used on its own and it is not actually a Control type
    ' it is only used internally. DragControl's are drawn in Canvas

    ' When saving, each control is given a unique ID so links can be given
    ' to it.
    Public SaveID As Integer

    ' GateControls use Type to show which gate it is.
    ' InputControls use GateType as the input number: Constant,A,B,C,D,E or F
    ' OutputControls don't use it at all
    ' It is read only so it will not change after the control has been created
    ' Read it by the property GateType
    Friend m_Type As Integer

    ' Every DragControl has these members but only some will make use of them
    Protected m_Outputs As New List(Of LinkFinish)
    Protected m_Input1 As DragControl
    Protected m_Input2 As DragControl

    ' Generate dimensions things
    ' These behave like regular controls' Location and Size but I must
    ' implement them myself

    Private m_Location As New Point()
    Private m_Size As New Size()

    Public Property Left() As Integer
        Get
            Return m_Location.X
        End Get
        Set(ByVal value As Integer)
            m_Location.X = value
        End Set
    End Property

    Public Property Top() As Integer
        Get
            Return m_Location.Y()
        End Get
        Set(ByVal value As Integer)
            m_Location.Y = value
        End Set
    End Property

    Public Property Width() As Integer
        Get
            Return m_Size.Width
        End Get
        Set(ByVal value As Integer)
            m_Size.Width = value
        End Set
    End Property

    Public Property Height() As Integer
        Get
            Return m_Size.Height
        End Get
        Set(ByVal value As Integer)
            m_Size.Height = value
        End Set
    End Property

    Public Property Location() As Point
        Get
            Return m_Location
        End Get
        Set(ByVal value As Point)
            m_Location.X = value.X
            m_Location.Y = value.Y
        End Set
    End Property
    Public Property Size() As Size
        Get
            Return m_Size
        End Get
        Set(ByVal value As Size)
            m_Size.Width = value.Width
            m_Size.Height = value.Height
        End Set
    End Property

    ' Input1 Properties and Functions

    ' HasInput1 gets overridden by an OutputControl for example, to show that
    ' it does have an input1
    ' InputControl's don't have an input1
    Public Overridable ReadOnly Property HasInput1() As Boolean
        Get
            Return False
        End Get
    End Property

    ' Returns the position of the Input1, this is where the little dot is
    ' drawn and it is where the links join to
    Public Overridable ReadOnly Property Input1Pos() As Point
        Get
            Return New Point(Left - 10, Top + Height / 2)
        End Get
    End Property

    ' Returns the value of the control connected to Input1 as a boolean
    Public ReadOnly Property Input1() As Boolean
        Get
            If Not HasInput1 OrElse IsNothing(m_Input1) Then
                Return False
            Else
                Return m_Input1.Value
            End If
        End Get
    End Property

    ' Gets or sets the control connected to Input1.
    Public Property Input1Control() As DragControl
        Get
            Return m_Input1
        End Get
        Set(ByVal value As DragControl)
            If Not HasInput1 Then
                Throw New Exception("This control doesn't have an input1")
            End If
            m_Input1 = value
        End Set
    End Property

    ' Deletes the control connected to Input1 and the removes it from the 
    ' output list of that control
    Public Sub DeleteInput1()
        If Not IsNothing(m_Input1) Then
            Dim otherControl As DragControl = m_Input1
            otherControl.DeleteOutput(Me, LinkFinishType.Input1)
            m_Input1 = Nothing
        End If
    End Sub


    ' Input2 Properties and Functions

    ' These properties are the same as for Input1
    Public Overridable ReadOnly Property HasInput2() As Boolean
        Get
            Return False
        End Get
    End Property

    ' Returns the position of the Input1, this is where the little dot is
    ' drawn and it is where the links join to
    Public Overridable ReadOnly Property Input2Pos() As Point
        Get
            Return New Point(Left - 10, Top + Height / 2)
        End Get
    End Property

    ' These properties are the same as for Input1
    Public ReadOnly Property Input2() As Boolean
        Get
            If Not HasInput2 OrElse IsNothing(m_Input2) Then
                Return False
            Else
                Return m_Input2.Value
            End If
        End Get
    End Property

    ' These properties are the same as for Input1
    Public Property Input2Control() As DragControl
        Get
            Return m_Input2
        End Get
        Set(ByVal value As DragControl)
            If Not HasInput2 Then
                Throw New Exception("This control doesn't have an input2")
            End If
            m_Input2 = value
        End Set
    End Property

    ' These functions are the same as for Input1
    Public Sub DeleteInput2()
        If Not IsNothing(m_Input2) Then
            Dim otherControl As DragControl = m_Input2
            otherControl.DeleteOutput(Me, LinkFinishType.Input2)
            m_Input2 = Nothing
        End If
    End Sub

    ' Output Properties and Functions

    ' Overidden, similar to to Input1 and Input2
    Public Overridable ReadOnly Property HasOutput() As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overridable ReadOnly Property OutputPos() As Point
        Get
            Return New Point(Left + Width + 10, Top + Height / 2)
        End Get
    End Property

    ' Returns the list of Outputs
    Public ReadOnly Property Outputs() As List(Of LinkFinish)
        Get
            If HasOutput Then
                Return m_Outputs
            End If
            Return Nothing
        End Get
    End Property

    Public Sub DeleteOutput(ByVal control As DragControl, ByVal type As LinkFinishType)

        ' Lists contain a member RemoveAll that will remove any items that
        ' satisfy the function given to it.
        ' What you see below is an anonymous function passed as the first
        ' argument of RemoveAll
        ' So basically it deletes any link from m_Outputs that is control
        ' and has type of 'type'
        m_Outputs.RemoveAll(Function(l As LinkFinish) _
            control.Equals(l.Control) AndAlso l.Type = type _
        )

    End Sub

    ' Deletes all links to outputs and removes itself from their inputs
    Public Sub DeleteAllOutputs()
        For Each l As LinkFinish In m_Outputs
            If l.Type = LinkFinishType.Input1 Then
                l.Control.m_Input1 = Nothing
            ElseIf l.Type = LinkFinishType.Input2 Then
                l.Control.m_Input2 = Nothing
            End If
        Next
        m_Outputs.Clear()
    End Sub

    ' Readonly type
    Public ReadOnly Property Type() As Integer
        Get
            Return m_Type
        End Get
    End Property

    ' They all have a Value property, by default it does nothing but
    ' the controls each override the property
    Public Overridable Property Value() As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property
End Class