Public Class customTimeControl

    Private Sub customTimeControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        updateVisuals()
    End Sub

    Private Sub customTimeControl_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        timeControls.Show()
    End Sub

    Private Sub tb_timePerSide_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_timePerSide.Scroll, tb_increment.Scroll
        updateVisuals()
    End Sub

    Private Sub updateVisuals()
        updateVisualsFromTrackbar()
        tbox_totalTime.Text = tb_timePerSide.Value
        tbox_increment.Text = tb_increment.Value
    End Sub

    Private Sub updateVisualsFromTrackbar()
        lbl_result.Text = tb_timePerSide.Value & " + " & tb_increment.Value
    End Sub

    Private Sub updateVisualsFromTextboxes()
        Dim totalTime = tbox_totalTime.Text
        Dim increment = tbox_increment.Text
        If Not IsNumeric(totalTime) Then
            totalTime = tb_timePerSide.Value
        End If
        If Not IsNumeric(increment) Then
            increment = tb_increment.Value
        End If
        lbl_result.Text = totalTime & " + " & increment
    End Sub

    Private Sub tbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbox_totalTime.TextChanged, tbox_increment.TextChanged
        Dim tboxValue = sender.Text
        If IsNumeric(tboxValue) Then
            If tboxValue >= 1 And tboxValue <= 60 Then
                If CType(sender, TextBox).Name = "tbox_increment" Then
                    tb_increment.Value = tboxValue
                Else
                    tb_timePerSide.Value = tboxValue
                End If
                updateVisualsFromTrackbar()
            ElseIf tboxValue >= 60 And tboxValue <= 1000 Then
                If CType(sender, TextBox).Name = "tbox_increment" Then
                    tb_increment.Value = 60
                Else
                    tb_timePerSide.Value = 60
                End If
                updateVisualsFromTextboxes()
            End If
        End If
    End Sub

    Private Sub btn_back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_back.Click
        timeControls.Show()
        Me.Close()
    End Sub
End Class