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

    Private Sub game_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' initialise game
        newGame = chess.initGame(My.Resources.txt_chessboardStartingPosition, 1, 100, 10)
        AddHandler newGame.whiteTime.timer.Tick, Sub() chess.clockTick(newGame.whiteTime, AddressOf newGamewhiteTimeDisplay)
        AddHandler newGame.blackTime.timer.Tick, Sub() chess.clockTick(newGame.blackTime, AddressOf newGameblackTimeDisplay)

        ' display board
        'newGame.board(0, 4) = "P"
        'newGame.board(1, 4) = "p"
        'displayGame(newGame)
        'chess.validMoves(newGame, {0, 4})
    End Sub

    ' update white time label from newGame (called on timer tick)
    Sub newGamewhiteTimeDisplay()
        displayWhiteTime(newGame.whiteTime.timeLeft)
    End Sub

    ' update black time label from newGame (called on timer tick)
    Sub newGameblackTimeDisplay()
        displayBlackTime(newGame.blackTime.timeLeft)
    End Sub

    ' display game
    Private Sub displayGame(ByVal game As chess.Game)
        displayBoard(game.board)
        displayHistory(game.history)
        displayBlackTime(game.blackTime.timeLeft)
        displayWhiteTime(game.whiteTime.timeLeft)
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

    ' test move
    Private Sub testMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim move As Move
        move.gameState = newGame
        move.startCoords = {TextBox4.Text, TextBox3.Text}
        move.destinationCoords = {TextBox6.Text, TextBox5.Text}
        move.moveKeys = {0}
        move.promotion = ""

        newGame = chess.doMove(move)
        displayGame(newGame)
    End Sub

    ' takeback move
    Private Sub btn_takeBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_takeBack.Click
        newGame = chess.takebackMove(newGame)
        displayGame(newGame)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim move As Move
        move.gameState = newGame
        move.startCoords = {7, 1}
        move.destinationCoords = {7, 3}
        move.moveKeys = {0}
        move.promotion = ""
        newGame = chess.doMove(move)

        Dim move2 As Move
        move2.gameState = newGame
        move2.startCoords = {2, 6}
        move2.destinationCoords = {2, 4}
        move2.moveKeys = {0}
        move2.promotion = ""
        newGame = chess.doMove(move2)

        Dim move3 As Move
        move3.gameState = newGame
        move3.startCoords = {5, 1}
        move3.destinationCoords = {5, 3}
        move3.moveKeys = {0}
        move3.promotion = ""
        newGame = chess.doMove(move3)

        Dim move4 As Move
        move4.gameState = newGame
        move4.startCoords = {2, 4}
        move4.destinationCoords = {2, 3}
        move4.moveKeys = {0}
        move4.promotion = ""
        newGame = chess.doMove(move4)

        Dim move5 As Move
        move5.gameState = newGame
        move5.startCoords = {1, 1}
        move5.destinationCoords = {1, 3}
        move5.moveKeys = {0}
        move5.promotion = ""
        newGame = chess.doMove(move5)

        Dim move6 As Move
        move6.gameState = newGame
        move6.startCoords = {2, 3}
        move6.destinationCoords = {1, 2}
        move6.moveKeys = {2}
        move6.promotion = ""
        newGame = chess.doMove(move6)

        newGame.board(4, 4) = "q"
        newGame.board(4, 1) = " "

        newGame.board(7, 3) = "R"
        newGame.board(5, 3) = " "

        displayGame(newGame)

        chess.validMoves(newGame, {7, 3})
    End Sub
End Class