Public Class frm_mainMenu
    ' load settings
    Private Sub mainMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pb_mainScreen.Image = Image.FromFile(resources.mainScreenChessboardPath)
        loadSettingsFromFile(resources.settingsFile)
        btn_options.Image = Image.FromFile(resources.settingsCogPath).GetThumbnailImage(30, 30, Nothing, IntPtr.Zero)
    End Sub

    ' new timed game
    Private Sub btn_newTimedGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newTimedGame.Click
        frm_timeControls.Show()
        Me.Hide()
    End Sub

    ' esc closes main menu
    Private Sub mainMenu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    ' new non-timed game
    Private Sub btn_newGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newGame.Click
        options.loadGame = False
        Me.Hide()
        frm_game.Show()
    End Sub

    ' load game from file
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
                frm_game.Show()
            End If
        End If
    End Sub

    ' load game
    Private Sub btn_loadGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_loadGame.Click
        loadGame()
    End Sub

    ' load settings from file
    Private Sub loadSettingsFromFile(ByVal filePath As String)
        Dim boardSwitchingEnabled As Integer

        ' open file (assumes filePath is valid)
        FileSystem.FileOpen(1, filePath, OpenMode.Input)

        ' collect data from file
        options.interval = FileSystem.LineInput(1)
        options.pieceStyle = FileSystem.LineInput(1)
        options.switchSideDelay = FileSystem.LineInput(1)
        boardSwitchingEnabled = FileSystem.LineInput(1)
        If boardSwitchingEnabled = 1 Then
            options.boardSwitchingEnabled = True
        Else
            options.boardSwitchingEnabled = False
        End If
        options.moveHighlightStyle = FileSystem.LineInput(1)
        options.chessboardDarkSquareHex = FileSystem.LineInput(1)
        options.chessboardLightSquareHex = FileSystem.LineInput(1)
        options.validMoveIndicatorHex = FileSystem.LineInput(1)
        options.validDotCaptureIndicatorHex = FileSystem.LineInput(1)
        options.validSquareCaptureIndicatorHex = FileSystem.LineInput(1)
        options.kingInCheckHex = FileSystem.LineInput(1)
        options.selectedPieceHex = FileSystem.LineInput(1)

        ' close file
        FileSystem.FileClose(1)
    End Sub

    ' show options
    Private Sub btn_options_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_options.Click
        options.optionsOpenedFromMainMenu = True
        frm_gameOptions.Show()
    End Sub

    ' show history
    Private Sub btn_history_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_highScores.Click
        frm_highScores.Show()
    End Sub
End Class