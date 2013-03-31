

Public Class ExpressionInputWindow

    Private SuperNot As Boolean
    Private Exp As New Expression()

    Private Sub ExpressionInput_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        InputCombo1.SelectedIndex = 0
        InputCombo2.SelectedIndex = 1
        InputCombo3.SelectedIndex = 2

        OpCombo1.SelectedIndex = 0
        OpCombo2.SelectedIndex = 0

        NotBox1.Checked = False
        NotBox2.Checked = False
        NotBox3.Checked = False
    End Sub

    Private Sub SuperPreview()

        Dim SuperNot As Boolean
        SuperNot = False

        Dim Exp2 As New Expression()

        Dim Input1 = New ExpressionInput(InputCombo1.SelectedIndex + 1, NotBox1.Checked)
        Dim Input2 = New ExpressionInput(InputCombo2.SelectedIndex + 1, NotBox2.Checked)
        Dim Input3 = New ExpressionInput(InputCombo3.SelectedIndex + 1, NotBox3.Checked)

        ' Construct expressions

        ' Input1 + (Input2 . Input3)

        Exp2.Input1 = Input2
        Exp2.Input2 = Input3
        Exp2.Op = OpCombo2.SelectedIndex

        Exp.Input1 = Input1
        Exp.Input2 = Exp2
        Exp.Op = OpCombo1.SelectedIndex
        


        ' Preview

        Preview.Text = NumToLetter(Input1.InputID) & " " & NumToOp(Exp.Op) & " (" & NumToLetter(Input2.InputID) & " " & NumToOp(Exp2.Op) & " " & NumToLetter(Input3.InputID) & ")"

        ' Hide/Show lines
        If Exp.Op >= 3 Then
            SuperNotLine1.Visible = True
        Else
            SuperNotLine1.Visible = False
        End If

        If Exp2.Op >= 3 Then
            SuperNotLine2.Visible = True
        Else
            SuperNotLine2.Visible = False
        End If

        NotLine1.Visible = Input1.Notted
        NotLine2.Visible = Input2.Notted
        NotLine3.Visible = Input3.Notted
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DialogResult = Windows.Forms.DialogResult.OK
        ExpressionWindow.ReceiveExpression(Exp)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Something(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    InputCombo1.SelectedValueChanged, InputCombo2.SelectedValueChanged, InputCombo3.SelectedValueChanged, _
    NotBox1.CheckedChanged, NotBox2.CheckedChanged, NotBox3.CheckedChanged, _
    OpCombo1.SelectedIndexChanged, OpCombo2.SelectedIndexChanged
        SuperPreview()
    End Sub


End Class
