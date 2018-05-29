Public Class game

    '  ___ ___ _____ _   _ ___ 
    ' / __| __|_   _| | | | _ \
    ' \__ \ _|  | | | |_| |  _/
    ' |___/___| |_|  \___/|_|  

    ' move history and previous chessboards
    Dim history As String = ""
    Dim previousChessboards As String = Checkmate.My.Resources.txt_chessboardStartingPosition

    ' the TimeSpan data type automatically spills the minutes over to the hours if the amount of minutes is over 60
    Dim timeLeftWhite As New TimeSpan(0, options.totalTime, 0)
    Dim timeLeftBlack As New TimeSpan(0, options.totalTime, 0)
    Dim increment As New TimeSpan(0, 0, options.increment)

    ' interval is a set time of 100
    Dim interval As TimeSpan = TimeSpan.FromMilliseconds(100)
    Dim whiteTimer As New Timer With {.Interval = 100}
    Dim blackTimer As New Timer With {.Interval = 100}

    Dim chessboard(7, 7) As Char

    '  __  __   _   ___ _  _ 
    ' |  \/  | /_\ |_ _| \| |
    ' | |\/| |/ _ \ | || .` |
    ' |_|  |_/_/ \_\___|_|\_|

    ' game load function (main)
    Private Sub game_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setupClocks()
        updateHistoryListView()
        fillChessboardFromString(Checkmate.My.Resources.txt_chessboardStartingPosition)
        displayBoard()
    End Sub


    '  _  _ ___ _    ___ ___ ___  ___ 
    ' | || | __| |  | _ \ __| _ \/ __|
    ' | __ | _|| |__|  _/ _||   /\__ \
    ' |_||_|___|____|_| |___|_|_\|___/

    ' display board
    Private Sub displayBoard()
        lb_visualStub.Items.Clear()
        Dim foo As String = ""
        For y = 0 To 7
            foo = ""
            For x = 0 To 7
                foo = foo & " " & chessboard(x, 7 - y)
            Next
            lb_visualStub.Items.Add(foo)
        Next
    End Sub

    ' fill in board from string position
    Private Sub fillChessboardFromString(ByVal board As String)
        Dim index = 0
        For y = 0 To 7
            For x = 0 To 7
                chessboard(x, y) = board(index)
                index = index + 1
            Next
        Next
    End Sub

    ' get current board as a string
    Private Function currentBoardAsString() As String
        Dim s As String = ""
        For y = 0 To 7
            For x = 0 To 7
                s = s + chessboard(x, y)
            Next
        Next
        currentBoardAsString = s
    End Function

    ' get algebraic coordinates
    Private Function algebraicNotationFromCoordinates(ByVal x As Integer, ByVal y As Integer) As String
        algebraicNotationFromCoordinates = Chr(x + 97) & y + 1
    End Function

    ' make char uppercase
    Private Function makeCharUpper(ByVal c As Char) As Char
        If Asc(c) > 97 Then
            makeCharUpper = Chr(Asc(c) - 32)
        Else
            makeCharUpper = c
        End If
    End Function


    '  _  _ ___ ___ _____ ___  _____   __
    ' | || |_ _/ __|_   _/ _ \| _ \ \ / /
    ' | __ || |\__ \ | || (_) |   /\ V / 
    ' |_||_|___|___/ |_| \___/|_|_\ |_|  

    ' update history visually
    Private Sub updateHistoryListView()
        lv_moves.Items.Clear()
        Dim historyArray() As String = history.Split(",")

        Dim index = 0
        For x = 0 To historyArray.Length - 1
            index = index + 1
            If index Mod 2 = 0 Then
                lv_moves.Items.Add(New ListViewItem({" ", historyArray(x - 1), historyArray(x)}))
            End If
        Next
        If historyArray.Length Mod 2 <> 0 Then
            For a = 1 To historyArray.Length Mod 2
                lv_moves.Items.Add(New ListViewItem({" ", historyArray(historyArray.Length - a)}))
            Next
        End If
    End Sub

    ' update history internally
    Private Sub updateHistoryString(ByVal move As String)
        If history.Length = 0 Then
            history = move
        Else
            history = history & "," & move
        End If
    End Sub

    ' update history visually and internally taking into consideration all possible moves
    Private Function makeHistory(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, Optional ByVal special As Integer = 0, Optional ByVal promotion As Char = "Q", Optional ByVal updateHistoryAndVisuals As Boolean = True)
        ' makeHistory special parameter:
        ' special is specified if it a special move. Key is:
        ' 0 - none (default)
        ' 1 - capture
        ' 2 - en passant capture
        ' 3 - pawn promotion
        '   if piece not specified in optional 'promotion' parameter, queen is default
        ' 4 - kingside castling
        ' 5 - queenside castling
        ' 6 - check
        ' 7 - checkmate
        ' 8 - win for white
        ' 9 - win for black
        ' 10 - draw
        ' 11 - blank move
        Dim coordinatesDestination = algebraicNotationFromCoordinates(x2, y2)
        Dim fileOfMovingPiece = Chr(x1 + 97)
        Dim movingPiece = makeCharUpper(chessboard(x1, y1))
        Dim move = coordinatesDestination

        ' every move that is not a special move
        If movingPiece <> "P" Then
            move = movingPiece & coordinatesDestination
        End If

        ' take care of special moves
        Select Case special
            Case 1
                ' capture
                If movingPiece <> "P" Then
                    move = movingPiece & "x" & coordinatesDestination
                Else
                    move = fileOfMovingPiece & "x" & coordinatesDestination
                End If

            Case 2
                ' en passant capture (normal pawn capture plus "e.p.")
                move = makeHistory(x1, y1, x2, y2, 1, "Q", False) & " e.p."

            Case 3
                ' pawn promotion
                move = coordinatesDestination & "=" & promotion

            Case 4
                ' kingside castling
                move = "0-0"

            Case 5
                ' queenside castling
                move = "0-0-0"

            Case 6
                ' check
                move = move + "+"

            Case 7
                ' checkmate
                move = move + "#"

            Case 8
                ' white wins
                move = "1 - 0"

            Case 9
                ' black wins
                move = "0 - 1"

            Case 10
                ' draw
                move = "draw"

            Case 11
                'blank move
                move = ""

        End Select

        If updateHistoryAndVisuals Then
            updateHistoryString(move)
            updateHistoryListView()
        End If

        makeHistory = move
    End Function


    '  ___  ___   _   ___ ___    __  __   _   _  _ ___ ___ _   _ _      _ _____ ___ ___  _  _ 
    ' | _ )/ _ \ /_\ | _ \   \  |  \/  | /_\ | \| |_ _| _ \ | | | |    /_\_   _|_ _/ _ \| \| |
    ' | _ \ (_) / _ \|   / |) | | |\/| |/ _ \| .` || ||  _/ |_| | |__ / _ \| |  | | (_) | .` |
    ' |___/\___/_/ \_\_|_\___/  |_|  |_/_/ \_\_|\_|___|_|  \___/|____/_/ \_\_| |___\___/|_|\_|

    ' move piece in chessboard, update history, store previous chessboard position in previousChessboards
    Private Sub movePiece(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
        ' make history
        makeHistory(x1, y1, x2, y2)

        ' actually do move
        chessboard(x2, y2) = chessboard(x1, y1)
        chessboard(x1, y1) = " "

        ' update previousChessboards
        previousChessboards = previousChessboards & "," & currentBoardAsString()
    End Sub

    ' rollback history string
    Private Sub rollbackHistoryString()
        Dim historyArray = history.Split(",")
        history = String.Join(",", historyArray.Take(historyArray.Length() - 1))
    End Sub

    ' rollback board position
    Private Sub rollbackBoardPosition()
        Dim previousChessboardsArray = previousChessboards.Split(",")
        previousChessboards = String.Join(",", previousChessboardsArray.Take(previousChessboardsArray.Length() - 1))

        previousChessboardsArray = previousChessboards.Split(",")
        fillChessboardFromString(previousChessboardsArray(previousChessboardsArray.Length - 1))
    End Sub

    ' take back previous move
    Private Sub takeBackPreviousMove()
        ' checking that there is at least one previous board position
        If previousChessboards.Contains(",") Then
            rollbackHistoryString()
            rollbackBoardPosition()

            updateHistoryListView()
            displayBoard()
        End If
    End Sub


    '  _____ ___ ___ _____ ___ 
    ' |_   _| __/ __|_   _/ __|
    '   | | | _|\__ \ | | \__ \
    '   |_| |___|___/ |_| |___/

    ' takeback previous move test
    Private Sub btn_takeBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_takeBack.Click
        takeBackPreviousMove()
    End Sub

    ' piece at coordinate test
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label2.Text = chessboard(TextBox1.Text, TextBox2.Text)
    End Sub

    ' move piece test
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        movePiece(TextBox4.Text, TextBox3.Text, TextBox6.Text, TextBox5.Text)
        displayBoard()
    End Sub


    '   ___ _    ___   ___ _  _____ 
    '  / __| |  / _ \ / __| |/ / __|
    ' | (__| |_| (_) | (__| ' <\__ \
    '  \___|____\___/ \___|_|\_\___/

    ' setup clocks
    Private Sub setupClocks()
        initTimers()
        updateWhiteTimerLabel()
        updateBlackTimerLabel()
    End Sub

    ' initialise timers (give them handler functions)
    Private Sub initTimers()
        AddHandler whiteTimer.Tick, AddressOf whiteTimer_tick
        AddHandler blackTimer.Tick, AddressOf blackTimer_tick
    End Sub

    ' update white time remaining on tick and update label
    Private Sub whiteTimer_tick(ByVal sender As Object, ByVal e As EventArgs)
        timeLeftWhite = timeLeftWhite.Subtract(interval)
        updateWhiteTimerLabel()
    End Sub

    ' update black time remaining on tick and update label
    Private Sub blackTimer_tick(ByVal sender As Object, ByVal e As EventArgs)
        timeLeftBlack = timeLeftBlack.Subtract(interval)
        updateBlackTimerLabel()
    End Sub

    ' update white timer label
    Private Sub updateWhiteTimerLabel()
        lbl_whiteTimeCounter.Text = timeToString(timeLeftWhite)
    End Sub

    ' update black timer label
    Private Sub updateBlackTimerLabel()
        lbl_blackTimeCounter.Text = timeToString(timeLeftBlack)
    End Sub

    ' remove trailing zeroes from integers
    Private Function removeTrailingZeroes(ByVal num As Integer) As String
        If num <> 0 Then
            Dim temp As String = num.ToString
            temp = temp.TrimEnd(New String({"0"}))
            removeTrailingZeroes = temp
        Else
            removeTrailingZeroes = num
        End If
    End Function

    ' convert TimeSpan to string, takes care of all possible time ranges
    Private Function timeToString(ByVal time As TimeSpan) As String
        If time.TotalHours >= 1 Then
            timeToString = String.Format("{0:00}:{1:00}:{2:00}", time.TotalHours, time.Minutes, time.Seconds)
        ElseIf time.Minutes >= 1 Then
            timeToString = String.Format("{0:00}:{1:00}:{2:00}", time.Minutes, time.Seconds, removeTrailingZeroes(time.Milliseconds))
        Else
            timeToString = String.Format("{0:00}:{1:00}", time.Seconds, removeTrailingZeroes(time.Milliseconds))
        End If
    End Function

    ' pause or continue white timer
    Private Sub pauseWhiteTimer(ByVal flag As Boolean)
        whiteTimer.Enabled = Not flag
    End Sub

    ' pause or continue black timer
    Private Sub pauseBlackTimer(ByVal flag As Boolean)
        blackTimer.Enabled = Not flag
    End Sub

    ' add increment to black timer
    Private Sub addBlackIncrement()
        timeLeftBlack = timeLeftBlack.Add(increment)
        updateBlackTimerLabel()
    End Sub

    ' add increment to white timer
    Private Sub addWhiteIncrement()
        timeLeftWhite = timeLeftWhite.Add(increment)
        updateWhiteTimerLabel()
    End Sub

    ' pause black timer, add increment
    Private Sub whiteMoveChangeClocks()
        pauseBlackTimer(True)
        addWhiteIncrement()
        pauseWhiteTimer(False)
    End Sub

    ' pause white timer, add increment
    Private Sub blackMoveChangeClocks()
        pauseWhiteTimer(True)
        addBlackIncrement()
        pauseBlackTimer(False)
    End Sub

End Class