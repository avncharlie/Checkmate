Public Class frm_timeControls
    ' if set, do not close application on form close
    Dim closeAppOnFormClose As Boolean

    ' form closes on pressing escape
    Private Sub timeControls_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    ' opens time control info form
    Private Sub link_howDoesThisWork_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles link_howDoesThisWork.LinkClicked
        frm_timeControlInfo.Show()
    End Sub

    ' opens custom time control button form
    Private Sub btn_custom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_custom.Click
        closeAppOnFormClose = False
        frm_customTimeControl.Show()
        Me.Close()
    End Sub

    ' handles all time control button clicks, opens main form
    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_1.Click, btn_2.Click, btn_3.Click, btn_4.Click, btn_5.Click, btn_6.Click, btn_7.Click, btn_8.Click
        Dim name = CType(sender, Button).Name
        Dim totalTime As Integer
        Dim increment As Integer

        Select Case name
            Case "btn_1"
                totalTime = 1
                increment = 0
            Case "btn_2"
                totalTime = 2
                increment = 1
            Case "btn_3"
                totalTime = 3
                increment = 0
            Case "btn_4"
                totalTime = 3
                increment = 5
            Case "btn_5"
                totalTime = 5
                increment = 0
            Case "btn_6"
                totalTime = 5
                increment = 5
            Case "btn_7"
                totalTime = 10
                increment = 0
            Case "btn_8"
                totalTime = 15
                increment = 15
        End Select

        options.totalTime = totalTime
        options.increment = increment

        closeAppOnFormClose = False

        Me.Close()
        frm_game.Show()
    End Sub

    ' closes current form, goes back to mainMenu
    Private Sub btn_back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_back.Click
        closeAppOnFormClose = False
        frm_mainMenu.Show()
        Me.Close()
    End Sub

    ' close application when form closing
    Private Sub frm_timeControls_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If closeAppOnFormClose Then
            Application.Exit()
        End If
    End Sub

    ' set flag
    Private Sub frm_timeControls_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        closeAppOnFormClose = True
    End Sub
End Class