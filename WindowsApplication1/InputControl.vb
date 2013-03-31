Public Class InputControl
    Inherits DragControl

    ' Input Control
    ' Uses GateType as InputID
    ' If InputID = 0 then it is known to be "Not Named" and so it displays
    ' 0 or 1 on its output. If it is Named then it will display its letter
    ' instead.

    Public IsNamed As Boolean = False
    Private m_Value As Boolean = False

    ' Properties

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

    ' Functions

    Public Sub Toggle()
        If IsNamed Then
            ' If input is named, update all the named inputs
            ' This will update this control aswell
            Main.ToggleInput(Type)
        Else
            ' Otherwise just toggle the value
            Value = Not Value
        End If
    End Sub

    Public Sub New(ByVal InputID As Integer, Optional ByVal InitialValue As Boolean = False)
        'InitializeComponent()

        If InputID > 0 Then
            Me.IsNamed = True
        End If

        Me.m_Type = InputID
        Me.Value = InitialValue

        Me.Width = 40
        Me.Height = 40
    End Sub

End Class
