Public Class InputsWindow

    Private Function GetImage(ByVal Value As Boolean) As System.Drawing.Bitmap
        If Value Then
            Return My.Resources.accept
        Else
            Return My.Resources.delete
        End If
    End Function

    Public Sub UpdateValues()
        Button1.Image = GetImage(Main.globalValues(0))
        Button2.Image = GetImage(Main.globalValues(1))
        Button3.Image = GetImage(Main.globalValues(2))
        Button4.Image = GetImage(Main.globalValues(3))
        Button5.Image = GetImage(Main.globalValues(4))
        Button6.Image = GetImage(Main.globalValues(5))
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Main.ToggleInput(1)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Main.ToggleInput(2)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Main.ToggleInput(3)
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Main.ToggleInput(4)
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Main.ToggleInput(5)
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Main.ToggleInput(6)
    End Sub

    Private Sub InputsWindow_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UpdateValues()
    End Sub
End Class