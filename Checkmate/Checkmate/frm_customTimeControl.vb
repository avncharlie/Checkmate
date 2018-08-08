Public Class frm_customTimeControl
    ' if user is going back or continuing do not exit application
    Dim goingPreviousOrNextForm As Boolean

    ' holds the final customised total time and increment
    Dim finalTotalTime As Integer = 1
    Dim finalIncrement As Integer = 0

    ' update label and set goingPreviousForm flag
    Private Sub customTimeControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        updateLabel()
        goingPreviousOrNextForm = False
    End Sub

    ' update preview label
    Private Sub updateLabel()
        lbl_result.Text = finalTotalTime & " + " & finalIncrement
    End Sub

    ' update textbox and preview label value's when slider changed
    Private Sub tb_timePerSide_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_timePerSide.Scroll
        Dim value = tb_timePerSide.Value
        finalTotalTime = value
        tbox_totalTime.Text = value
        updateLabel()
    End Sub

    ' update textbox and preview label value's when slider changed
    Private Sub tb_increment_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_increment.Scroll
        Dim value = tb_increment.Value
        finalIncrement = value
        tbox_increment.Text = value
        updateLabel()
    End Sub

    ' update slider and preview label value's when textbox changed
    Private Sub tbox_totalTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbox_totalTime.TextChanged
        Dim value = tbox_totalTime.Text
        If IsNumeric(value) Then
            If value >= 1 And value <= 60 Then
                finalTotalTime = value
                tb_timePerSide.Value = value
                updateLabel()
            ElseIf value > 60 And value <= 1000 Then
                finalTotalTime = value
                tb_timePerSide.Value = 60
                updateLabel()
            End If
        End If
    End Sub

    ' update slider and preview label value's when textbox changed
    Private Sub tbox_increment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbox_increment.TextChanged
        Dim value = tbox_increment.Text
        If IsNumeric(value) Then
            If value >= 1 And value <= 60 Then
                finalIncrement = value
                tb_increment.Value = value
                updateLabel()
            ElseIf value > 60 And value <= 1000 Then
                finalIncrement = value
                tb_increment.Value = 60
                updateLabel()
            End If
        End If
    End Sub

    ' validate input of textboxes
    Private Sub tbox_validateKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbox_increment.KeyPress, tbox_totalTime.KeyPress
        Dim allowedChars As String = "0123456789"
        If allowedChars.IndexOf(e.KeyChar) = -1 And Char.IsControl(e.KeyChar) <> True Then
            e.Handled = True
        End If
    End Sub

    ' show time controls form and hide this form when back button pressed
    Private Sub btn_back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_back.Click
        goingPreviousOrNextForm = True
        frm_timeControls.Show()
        Me.Close()
    End Sub

    ' update time control data and close form
    Private Sub btn_continue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_continue.Click
        options.increment = finalIncrement
        options.totalTime = finalTotalTime
        goingPreviousOrNextForm = True
        Me.Close()
        frm_game.Show()
    End Sub

    ' close application when form closing
    Private Sub frm_customTimeControl_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not goingPreviousOrNextForm Then
            Application.Exit()
        End If
    End Sub
End Class