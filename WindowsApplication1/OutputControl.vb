Public Class OutputControl
    Inherits DragControl

    ' Output Control
    ' See DragControl.vb for details

    Private m_Value As Boolean = False

    ' Properties


    Public Overrides ReadOnly Property HasInput1() As Boolean
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

    Public Sub UpdateOutput()
        Value = Input1
    End Sub

    Public Sub New()
        'InitializeComponent()

        ' Initiate Value to false so it colours the background etc
        Me.Value = False
        Me.Size = New Size(40, 40)
    End Sub
End Class
