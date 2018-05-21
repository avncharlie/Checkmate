Public Class mainMenu

    Private Sub mainMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pb_mainScreen.Image = Image.FromFile(My.Application.Info.DirectoryPath & "/Resources/mainScreen.png")
    End Sub

    Private Sub btn_newGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newTimedGame.Click
        timeControls.Show()
        Me.Hide()
    End Sub
End Class