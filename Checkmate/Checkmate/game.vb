Public Class game
    ' the TimeSpan data type automatically spills the minutes over to the hours if the amount of minutes is over 60
    Dim timeLeftWhite As New TimeSpan(0, options.totalTime, 0)
    Dim timeLeftBlack As New TimeSpan(0, options.totalTime, 0)
    Dim increment As New TimeSpan(0, 0, options.increment)

    ' interval is a set time of 100
    Dim interval As TimeSpan = TimeSpan.FromMilliseconds(100)
    Dim whiteTimer As New Timer With {.Interval = 100}
    Dim blackTimer As New Timer With {.Interval = 100}

    Private Sub game_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        addTestMoves()
        initTimers()
        updateWhiteTimerLabel()
        updateBlackTimerLabel()
    End Sub

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

    ' testing
    Private Sub addTestMoves()
        lv_moves.Items.Add(New ListViewItem({" ", "e4", "e5"}))
        lv_moves.Items.Add(New ListViewItem({" ", "Nf3", "Nc6"}))
        lv_moves.Items.Add(New ListViewItem({" ", "Bb5"}))
    End Sub
End Class