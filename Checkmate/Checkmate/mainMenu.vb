Public Class mainMenu
    Private Sub mainMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pb_mainScreen.Image = Checkmate.My.Resources.pic_mainScreenChessboard
    End Sub

    Private Sub btn_newGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newTimedGame.Click
        timeControls.Show()
        Me.Hide()
    End Sub

    Private Sub mainMenu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub btn_newGame_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newGame.Click
        Me.Hide()
        game.Show()
    End Sub
End Class