Public Class mainMenu
    Private Sub mainMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pb_mainScreen.Image = Checkmate.My.Resources.pic_mainScreenChessboard
    End Sub

    Private Sub btn_newTimedGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newTimedGame.Click
        timeControls.Show()
        Me.Hide()
    End Sub

    Private Sub mainMenu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub btn_newGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newGame.Click
        Me.Hide()
        game.Show()
    End Sub

    Private Sub btn_loadGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadGame.Click
        Dim chooseFileDialog As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String

        chooseFileDialog.Title = "Select Checkmate file"
        'chooseFileDialog.InitialDirectory = "C:\"
        chooseFileDialog.Filter = "Checkmate files (*.checkmate)|*.checkmate"
        chooseFileDialog.FilterIndex = 2
        chooseFileDialog.RestoreDirectory = True
        chooseFileDialog.Multiselect = False


        If chooseFileDialog.ShowDialog() = DialogResult.OK Then
            strFileName = chooseFileDialog.FileName
            If Not chess.isValidCheckmateFile(strFileName) Then
                MsgBox("This is not a valid Checkmate file (it could not be processed)")
            Else
                options.loadGame = True
                options.loadGamePath = strFileName
                Me.Hide()
                game.Show()
            End If
        End If
    End Sub
End Class