Public Class mainMenu
    Private Sub mainMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pb_mainScreen.Image = Image.FromFile(resources.mainScreenChessboardPath)
    End Sub

    Private Sub btn_newTimedGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newTimedGame.Click
        timeControls.Show()
        Me.Hide()
    End Sub

    Private Sub mainMenu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub btn_newGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newGame.Click
        options.loadGame = False
        Me.Hide()
        game.Show()
    End Sub

    Public Sub loadGame()
        Dim chooseFileDialog As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String

        chooseFileDialog.Title = "Select Checkmate file"
        chooseFileDialog.Filter = "Checkmate files (*.checkmate)|*.checkmate"
        chooseFileDialog.FilterIndex = 2
        chooseFileDialog.RestoreDirectory = True
        chooseFileDialog.Multiselect = False


        If chooseFileDialog.ShowDialog() = DialogResult.OK Then
            strFileName = chooseFileDialog.FileName
            If Not chess.isValidChessFile(strFileName) Then
                MsgBox("This is not a valid Checkmate file (it could not be processed)")
            Else
                options.loadGame = True
                options.loadGamePath = strFileName
                Me.Hide()
                game.Show()
            End If
        End If
    End Sub

    Private Sub btn_loadGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadGame.Click
        loadGame()
    End Sub
End Class