Public Class AboutWindow

    Private Sub LinkLabel1_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://famfamfam.com/lab/icons/silk/")
    End Sub

    ' This isn't anything to do with my project...
    ' Just ignore it

    Private lemonade As New List(Of Button)

    Private arrayOfRandomIntegers() As Integer = {38, 38, 40, 40, 37, 39, 37, 39, 66, 65, 13}
    Private complicated As Integer = 0

    Private Sub abracadabra()
        Dim butterfly As Button = New Button()
        butterfly.Image = My.Resources.accept
        Me.Controls.Add(butterfly)
        butterfly.Size = New Size(24, 24)
        lemonade.Add(butterfly)
        butterfly.BringToFront()
        Timer1.Enabled = True
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef pow As System.Windows.Forms.Message, ByVal cotton As System.Windows.Forms.Keys) As Boolean
        If complicated < 11 AndAlso cotton <> arrayOfRandomIntegers(complicated) Then
            complicated = 0
        End If
        If complicated < 11 AndAlso cotton = arrayOfRandomIntegers(complicated) Then
            complicated += 1
            If complicated > 10 Then
                abracadabra()
                complicated = 0
            End If
            Return True
        End If
    End Function


    Private Sub commenceMagic(ByVal zop As Object, ByVal eep As Object) Handles Timer1.Tick
        Me.SuspendLayout()
        Dim dinosaurs As Double = Environment.TickCount / 1000
        Dim howManyLemonadesDoYouWant As Integer = lemonade.Count
        Dim indoors As Integer = 0
        Dim helicopter As Double = (Math.Sin(dinosaurs * (Math.PI * 2)) / 2 + 0.5) * 50 + 10
        For Each applepie As Control In lemonade
            Dim robots As Double = (indoors * Math.PI * 2) / howManyLemonadesDoYouWant + dinosaurs / 2 * (Math.PI * 2)
            applepie.Left = CDbl((Me.ClientSize.Width - applepie.Width) / 2) + Math.Cos(robots) * helicopter
            applepie.Top = CDbl((Me.ClientSize.Height - applepie.Height) / 2) + Math.Sin(robots) * helicopter
            indoors += 1
        Next
        Me.ResumeLayout()
    End Sub
End Class