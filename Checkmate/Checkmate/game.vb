Public Class game

    Dim history As String = ""

    ' the TimeSpan data type automatically spills the minutes over to the hours if the amount of minutes is over 60
    Dim timeLeftWhite As New TimeSpan(0, options.totalTime, 0)
    Dim timeLeftBlack As New TimeSpan(0, options.totalTime, 0)
    Dim increment As New TimeSpan(0, 0, options.increment)

    ' interval is a set time of 100
    Dim interval As TimeSpan = TimeSpan.FromMilliseconds(100)
    Dim whiteTimer As New Timer With {.Interval = 100}
    Dim blackTimer As New Timer With {.Interval = 100}

    Dim chessboard(7, 7) As Char

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

    ' display board stub
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

    ' fill in board starting position
    Private Sub fillBoardStartingPosition()
        Dim startingBoard = Checkmate.My.Resources.txt_chessboardStartingPosition
        Dim index = 0
        For y = 0 To 7
            For x = 0 To 7
                chessboard(x, y) = startingBoard(index)
                index = index + 1
            Next
        Next
    End Sub

    ' get algebraic coordinates
    Private Function chessCoordinatesFromXY(ByVal x As Integer, ByVal y As Integer) As String
        chessCoordinatesFromXY = Chr(x + 97) & y + 1
    End Function

    Private Sub updateHistory(ByVal move As String)
        If history.Length = 0 Then
            history = move
        Else
            history = history & "," & move
        End If
    End Sub

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
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        makeHistory(TextBox12.Text, TextBox11.Text, TextBox8.Text, TextBox7.Text, 3)
    End Sub

    Private Function makeHistory(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, Optional ByVal special As Integer = 0, Optional ByVal promotion As Char = "Q", Optional ByVal updateHistoryAndVisuals As Boolean = True)
        Dim coordinatesDestination = chessCoordinatesFromXY(x2, y2)
        Dim fileOfMovingPiece = Chr(x1 + 97)
        Dim movingPiece = makeUpper(chessboard(x1, y1))
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

        End Select

        If updateHistoryAndVisuals Then
            updateHistory(move)
            updateHistoryListView()
        End If

        makeHistory = move
    End Function

    Private Sub movePiece(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
        makeHistory(x1, y1, x2, y2)
        chessboard(x2, y2) = chessboard(x1, y1)
        chessboard(x1, y1) = " "
    End Sub

    Private Sub game_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initTimers()
        updateWhiteTimerLabel()
        updateBlackTimerLabel()

        updateHistoryListView()

        fillBoardStartingPosition()
        displayBoard()
    End Sub

    ' coordinate conversion test
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Label1.Text = chessCoordinatesFromXY(TextBox10.Text, TextBox9.Text)
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

    ' make char upper if lowercase
    Private Function makeUpper(ByVal c As Char) As Char
        If Asc(c) > 97 Then
            makeUpper = Chr(Asc(c) - 32)
        Else
            makeUpper = c
        End If
    End Function

    ' initialise timers (give them handler functions)
    Private Sub initTimers()
        AddHandler whiteTimer.Tick, AddressOf whiteTimer_tick
        AddHandler blackTimer.Tick, AddressOf blackTimer_tick
    End Sub

    ' visually update white timer
    Private Sub updateWhiteTimerLabel()
        lbl_whiteTimeCounter.Text = timeToString(timeLeftWhite)
    End Sub

    ' visually update black timer
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