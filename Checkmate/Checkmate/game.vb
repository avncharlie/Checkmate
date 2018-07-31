Public Class game

    ' display board
    ' ############################################################### update move indicator ###############################################################
    'Private Sub updateMoveIndicator()
    '    If turn Then
    '        lbl_moveIndicator.Text = "White to move"
    '    Else
    '        lbl_moveIndicator.Text = "Black to move"
    '    End If
    'End Sub


    '  _  _ ___ ___ _____ ___  _____   __
    ' | || |_ _/ __|_   _/ _ \| _ \ \ / /
    ' | __ || |\__ \ | || (_) |   /\ V / 
    ' |_||_|___|___/ |_| \___/|_|_\ |_|  

    '  update history visually 
    'Private Sub updateHistoryVisually(ByVal history As Char())
    '    lv_moves.Items.Clear()

    '    Dim index = 0
    '    For x = 0 To history.Length - 1
    '        index = index + 1
    '        If index Mod 2 = 0 Then
    '            lv_moves.Items.Add(New ListViewItem({" ", history(x - 1), history(x)}))
    '        End If
    '    Next
    '    If history.Length Mod 2 <> 0 Then
    '        For a = 1 To history.Length Mod 2
    '            lv_moves.Items.Add(New ListViewItem({" ", history(history.Length - a)}))
    '        Next
    '    End If
    'End Sub


    '  ___  ___   _   ___ ___    __  __   _   _  _ ___ ___ _   _ _      _ _____ ___ ___  _  _ 
    ' | _ )/ _ \ /_\ | _ \   \  |  \/  | /_\ | \| |_ _| _ \ | | | |    /_\_   _|_ _/ _ \| \| |
    ' | _ \ (_) / _ \|   / |) | | |\/| |/ _ \| .` || ||  _/ |_| | |__ / _ \| |  | | (_) | .` |
    ' |___/\___/_/ \_\_|_\___/  |_|  |_/_/ \_\_|\_|___|_|  \___/|____/_/ \_\_| |___\___/|_|\_|

    ' move piece in chessboard, update history, store previous chessboard position in previousChessboards
    'Private Sub movePiece(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
    '    ' make history
    '    makeHistory(x1, y1, x2, y2)

    '    ' actually do move
    '    chessboard(x2, y2) = chessboard(x1, y1)
    '    chessboard(x1, y1) = " "

    '    ' update previousChessboards
    '    previousChessboards = previousChessboards & "," & currentBoardAsString()
    'End Sub

    ' rollback history string
    'Private Sub rollbackHistoryString()
    '    Dim historyArray = history.Split(",")
    '    history = String.Join(",", historyArray.Take(historyArray.Length() - 1))
    'End Sub

    '' rollback board position
    'Private Sub rollbackBoardPosition()
    '    Dim previousChessboardsArray = previousChessboards.Split(",")
    '    previousChessboards = String.Join(",", previousChessboardsArray.Take(previousChessboardsArray.Length() - 1))

    '    previousChessboardsArray = previousChessboards.Split(",")
    '    fillChessboardFromString(previousChessboardsArray(previousChessboardsArray.Length - 1))
    'End Sub

    '' take back previous move
    'Private Sub takeBackPreviousMove()
    '    ' checking that there is at least one previous board position
    '    If previousChessboards.Contains(",") Then
    '        rollbackHistoryString()
    '        rollbackBoardPosition()

    '        updateHistoryVisually()

    '        switchSide(False)
    '    End If
    'End Sub

    '' flip board with delay
    'Private Sub flipBoardWithDelay()
    '    displayBoard(chessboard, Not turn)

    '    ' makes sure delay is same for both sides
    '    movePauseTimer.Stop()
    '    movePauseTimer.Start()

    '    ignoreMoveTimer = False
    'End Sub

    Dim newGame As chess.Game

    ' switch side delay
    ' notice that 3 fold repetition and 50 move rule are not implemented
    ' visuals
    ' load history

    ' test all moves
    ' en passant included
    ' taking a piece on a pawn promotion

    ' pawn promotion!!

    Private Sub game_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' initialise game

        If options.loadGame Then
            newGame = chess.loadGame(options.loadGamePath)
            MsgBox("u ready")
            ' set up timers
            If newGame.boardHistory.Length > 1 Then
                If newGame.whiteToMove Then
                    enableClock(newGame.whiteTime, True)
                    enableClock(newGame.blackTime, False)
                Else
                    enableClock(newGame.whiteTime, False)
                    enableClock(newGame.blackTime, True)
                End If
            Else
                enableClock(newGame.whiteTime, False)
                enableClock(newGame.blackTime, False)
            End If
        Else
            newGame = chess.initGame(My.Resources.txt_chessboardStartingPosition, 1, 100, 10)
        End If

        AddHandler newGame.whiteTime.timer.Tick, Sub() chess.clockTick(newGame.whiteTime, AddressOf newGamewhiteTimeDisplay, AddressOf endGame, True)
        AddHandler newGame.blackTime.timer.Tick, Sub() chess.clockTick(newGame.blackTime, AddressOf newGameblackTimeDisplay, AddressOf endGame, False)
        displayGame(newGame)
    End Sub

    ' update white time label from newGame (called on timer tick)
    Sub newGamewhiteTimeDisplay()
        displayWhiteTime(newGame.whiteTime.timeLeft)
    End Sub

    ' update black time label from newGame (called on timer tick)
    Sub newGameblackTimeDisplay()
        displayBlackTime(newGame.blackTime.timeLeft)
    End Sub

    Sub displayMoveIndicator(ByVal whiteToMove As Boolean)
        If whiteToMove Then
            lbl_moveIndicator.Text = "White to move"
        Else
            lbl_moveIndicator.Text = "Black to move"
        End If
    End Sub

    ' display game
    Private Sub displayGame(ByVal game As chess.Game)
        displayBoard(game.board, game.whiteToMove)
        displayHistory(game.history)
        displayBlackTime(game.blackTime.timeLeft)
        displayWhiteTime(game.whiteTime.timeLeft)
        displayMoveIndicator(game.whiteToMove)
    End Sub

    ' display white time
    Sub displayWhiteTime(ByVal time As TimeSpan)
        lbl_whiteTimeCounter.Text = chess.timespanToString(time)
    End Sub

    ' display black time
    Sub displayBlackTime(ByVal time As TimeSpan)
        lbl_blackTimeCounter.Text = chess.timespanToString(time)
    End Sub

    ' display board
    Private Sub displayBoard(ByVal b As Char(,), Optional ByVal whiteSideOrientation As Boolean = True)
        lb_visualStub.Items.Clear()
        Dim foo As String = ""
        For y = 0 To 7
            foo = ""
            For x = 0 To 7
                If whiteSideOrientation Then
                    foo = foo & " " & b(x, 7 - y)
                Else
                    foo = foo & " " & b(x, y)
                End If
            Next
            lb_visualStub.Items.Add(foo)
        Next
    End Sub

    ' display history
    Private Sub displayHistory(ByVal history As String())
        lv_moves.Items.Clear()

        Dim index = 0
        For x = 0 To history.Length - 1
            index = index + 1
            If index Mod 2 = 0 Then
                lv_moves.Items.Add(New ListViewItem({" ", history(x - 1), history(x)}))
            End If
        Next
        If history.Length Mod 2 <> 0 Then
            For a = 1 To history.Length Mod 2
                lv_moves.Items.Add(New ListViewItem({" ", history(history.Length - a)}))
            Next
        End If
    End Sub

    ' takeback move
    Private Sub btn_takeBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_takeBack.Click
        newGame = chess.takebackMove(newGame)
        displayGame(newGame)
    End Sub

    ' end game
    Private Sub endGame(ByVal whiteWin As Boolean, ByVal gameStatus As Integer)
        Dim winner As String
        Dim loser As String
        If whiteWin Then
            winner = "White"
            loser = "Black"
        Else
            winner = "Black"
            loser = "White"
        End If

        Select Case gameStatus
            Case 1
                MsgBox(winner & " wins by checkmate!")
            Case 2
                MsgBox("Draw by stalemate")
            Case 3
                MsgBox("Draw from insufficient material")
            Case 4
                MsgBox(winner & " wins on time!")
            Case 5
                MsgBox(loser & " resigns")
        End Select
    End Sub

    ' test move
    Private Sub testMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim startCoords() As Integer = {TextBox4.Text, TextBox3.Text}
        Dim destCoords() As Integer = {TextBox6.Text, TextBox5.Text}

        Dim move As Move
        move.gameState = newGame
        move.startCoords = startCoords
        move.destinationCoords = destCoords
        move.moveKeys = chess.getMoveKeys(startCoords, destCoords, newGame)
        ' check for pawn promotion
        move.promotion = ""

        newGame = chess.doMove(move)
        newGame = chess.switchSideGame(newGame)
        displayGame(newGame)
    End Sub

    Private Sub displayValidMoves(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim coords() As Integer
        coords = {TextBox1.Text, TextBox2.Text}

        Dim moveDict As New Dictionary(Of Integer(), Integer())
        moveDict = chess.validMoves(newGame, coords)

        Dim s As String
        s = ""
        For Each keyValuePair In moveDict
            s = s & keyValuePair.Key(0) & " " & keyValuePair.Key(1) & ", "
        Next
        Label1.Text = s
    End Sub


    Private Sub saveGame()
        ' save current states of clocks
        Dim blackTimerEnabled As Boolean
        Dim whiteTimerEnabled As Boolean
        blackTimerEnabled = newGame.blackTime.timer.Enabled
        whiteTimerEnabled = newGame.whiteTime.timer.Enabled

        ' pause both clocks while saving file
        enableClock(newGame.blackTime, False)
        enableClock(newGame.whiteTime, False)

        Dim saveFileDialog = New SaveFileDialog()
        saveFileDialog.Filter = ".checkmate (*.checkmate)|*.checkmate"
        saveFileDialog.Title = "Save game"
        saveFileDialog.ShowDialog()

        If saveFileDialog.FileName <> "" Then
            chess.saveGame(newGame, saveFileDialog.FileName, False)
        End If

        ' resume clocks
        enableClock(newGame.blackTime, blackTimerEnabled)
        enableClock(newGame.whiteTime, whiteTimerEnabled)
    End Sub

    Private Sub game_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.S And e.Modifiers = Keys.Control Then
            saveGame()
        End If
    End Sub

    Private Sub tsmi_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_save.Click
        saveGame()
    End Sub
End Class