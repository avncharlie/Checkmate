Public Class gameOptions
    Dim formJustLoadedFlagIntervalTbox As Boolean = True
    Dim formJustLoadedFlagSwitchSideTbox As Boolean = True

    ' retrieve current settings
    Dim interval As Integer = options.interval
    Dim pieceStyle As Integer = options.pieceStyle
    Dim switchSideDelay As Integer = options.switchSideDelay
    Dim boardSwitchingEnabled As Boolean = options.boardSwitchingEnabled
    Dim moveHighlightStyle As Integer = options.moveHighlightStyle

    Dim chessboardDarkSquares As String = options.chessboardDarkSquareHex
    Dim chessboardLightSquares As String = options.chessboardLightSquareHex
    Dim validMoveIndicator As String = options.validMoveIndicatorHex
    Dim validDotCaptureIndicator As String = options.validDotCaptureIndicatorHex
    Dim validSquareCaptureIndicatorHex As String = options.validSquareCaptureIndicatorHex

    ' ENABLE OPTIONS FROM MENU BAR!!!!!
    ' DISABLE BOARD SWITCHING

    ' load function - displays current settings
    Private Sub gameOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' init interval values
        tbox_interval.Text = interval
        tb_interval.Value = interval

        ' init switch side delay values
        tbox_switchSideDelay.Text = switchSideDelay
        tb_switchSideDelay.Value = switchSideDelay

        ' init piece combobox
        cb_pieceStyle.SelectedItem = pieceStyleNumAsString(pieceStyle)

        ' init board switching enabled and disable switch side delay if needed
        cb_boardSwitchEnabled.Checked = boardSwitchingEnabled
        disableSwitchSideDelay(Not boardSwitchingEnabled)

        ' init moveHighlightStyle
        If moveHighlightStyle = 0 Then
            cb_moveHighlightStyle.SelectedItem = "dots"
        Else
            cb_moveHighlightStyle.SelectedItem = "squares"
        End If

        ' update board preview
        updateBoardPreview()

        ' init color previews
        lbl_darkboardPreview.BackColor = ColorTranslator.FromHtml(chessboardDarkSquares)
        lbl_lightboardPreview.BackColor = ColorTranslator.FromHtml(chessboardLightSquares)
        lbl_validMoveIndicatorPreview.BackColor = ColorTranslator.FromHtml(validMoveIndicator)
        lbl_dotCapturePreview.BackColor = ColorTranslator.FromHtml(validDotCaptureIndicator)
    End Sub

    ' interval scroll
    Private Sub tb_interval_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_interval.Scroll
        ' round to 5
        tb_interval.Value = tb_interval.Value - (tb_interval.Value Mod 5)

        Dim value = tb_interval.Value
        interval = value
        tbox_interval.Text = value
    End Sub

    ' interval textbox
    Private Sub tbox_interval_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbox_interval.TextChanged
        If Not formJustLoadedFlagIntervalTbox Then
            Dim value = tbox_interval.Text
            If IsNumeric(value) Then
                If value >= 10 And value <= 1000 Then
                    interval = value
                    tb_interval.Value = value
                Else
                    If value > 1000 Then
                        interval = 1000
                        tb_interval.Value = 1000
                    Else
                        interval = 10
                        tb_interval.Value = 10
                    End If
                End If
            End If
        Else
            formJustLoadedFlagIntervalTbox = False
        End If
    End Sub

    ' switch side delay scroll
    Private Sub tb_switchSideDelay_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_switchSideDelay.Scroll
        ' round to 10
        tb_switchSideDelay.Value = tb_switchSideDelay.Value - (tb_switchSideDelay.Value Mod 10)

        Dim value = tb_switchSideDelay.Value
        switchSideDelay = value
        tbox_switchSideDelay.Text = value
    End Sub

    ' switch side delay textbox
    Private Sub tbox_switchSideDelay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbox_switchSideDelay.TextChanged
        If Not formJustLoadedFlagSwitchSideTbox Then
            Dim value = tbox_switchSideDelay.Text
            If IsNumeric(value) Then
                If value >= 10 And value <= 2000 Then
                    interval = value
                    tb_switchSideDelay.Value = value
                Else
                    If value > 2000 Then
                        interval = 2000
                        tb_switchSideDelay.Value = 2000
                    Else
                        interval = 10
                        tb_switchSideDelay.Value = 10
                    End If
                End If
            End If
        Else
            formJustLoadedFlagSwitchSideTbox = False
        End If
    End Sub

    ' restore defaults from resources.vb
    Private Sub btn_restoreDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_restoreDefault.Click
        tbox_interval.Text = resources.defaultInterval
        tb_interval.Value = resources.defaultInterval
        interval = resources.defaultInterval
    End Sub

    ' go from piece style to number
    Private Function pieceStyleNumAsString(ByVal style As Integer) As String
        Dim pieceStyleAsString As String
        Select Case style
            Case 0
                pieceStyleAsString = "alpha"
            Case 1
                pieceStyleAsString = "cburnett"
            Case 2
                pieceStyleAsString = "cheq"
            Case 3
                pieceStyleAsString = "leipzig"
            Case Else
                pieceStyleAsString = "merida"
        End Select
        pieceStyleNumAsString = pieceStyleAsString
    End Function

    ' go from number to piece style
    Private Function pieceStyleStringAsInt(ByVal styleString As String) As Integer
        Dim pieceAsInt As String
        Select Case styleString
            Case "alpha"
                pieceAsInt = 0
            Case "cburnett"
                pieceAsInt = 1
            Case "cheq"
                pieceAsInt = 2
            Case "leipzig"
                pieceAsInt = 3
            Case Else
                pieceAsInt = 4
        End Select
        pieceStyleStringAsInt = pieceAsInt
    End Function

    ' update pieceStyle and update board preview
    Private Sub cb_pieceStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_pieceStyle.SelectedIndexChanged
        pieceStyle = pieceStyleStringAsInt(cb_pieceStyle.SelectedItem)
        updateBoardPreview()
    End Sub

    ' validate textboxe input
    Private Sub tbox_validateKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbox_interval.KeyPress, tbox_switchSideDelay.KeyPress
        Dim allowedChars As String = "0123456789"
        If allowedChars.IndexOf(e.KeyChar) = -1 And Char.IsControl(e.KeyChar) <> True Then
            e.Handled = True
        End If
    End Sub

    ' enable or disable switch side delay options (used when cb_boardSwitchEnabled is changed)
    Private Sub disableSwitchSideDelay(ByVal disable As Boolean)
        tb_switchSideDelay.Enabled = Not disable
        tbox_switchSideDelay.Enabled = Not disable
    End Sub

    ' enable/disable board switching (if disabled, disable switch side delay options)
    Private Sub cb_boardSwitchEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_boardSwitchEnabled.CheckedChanged
        boardSwitchingEnabled = cb_boardSwitchEnabled.Checked

        ' disable switch side delay options
        disableSwitchSideDelay(Not cb_boardSwitchEnabled.Checked)
    End Sub

    ' update chessboard preview
    Private Sub updateBoardPreview()
        ' set up an example game
        Dim exampleGame As chess.Game

        Dim exampleBoard(,) As Char
        exampleBoard = chess.boardFromString(resources.stringboardStartingPosition)
        exampleBoard(3, 0) = " "
        exampleBoard(4, 4) = "Q"
        exampleBoard(4, 6) = " "

        exampleGame.board = exampleBoard
        exampleGame.whiteToMove = True

        ' get valid moves for queen
        Dim validMoves As Dictionary(Of Integer(), Integer())
        validMoves = chess.validMoves(exampleGame, {4, 4}, True)

        pb_boardPreview.Image = game.renderBoard(exampleGame.board, {pb_boardPreview.Width, pb_boardPreview.Height}, exampleGame.whiteToMove, pieceStyle, moveHighlightStyle, validMoves, {4, 4}, chessboardDarkSquares, chessboardLightSquares, validMoveIndicator, validDotCaptureIndicator)
    End Sub

    ' update move highlight style and refresh board preview
    Private Sub cb_moveHighlightStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_moveHighlightStyle.SelectedIndexChanged
        If cb_moveHighlightStyle.SelectedItem = "dots" Then
            moveHighlightStyle = 0
        Else
            moveHighlightStyle = 1
        End If
        updateBoardPreview()
    End Sub

    ' convert vb color object to hex string
    Private Function vbColorToHex(ByVal vbColor As Color) As String
        vbColorToHex = String.Format("#{0:X2}{1:X2}{2:X2}", vbColor.R, vbColor.G, vbColor.B)
    End Function

    ' update dark board square colour and preview
    Private Sub btn_darkSquares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_darkSquares.Click
        If cd_colorPicker.ShowDialog() <> System.Windows.Forms.DialogResult.Cancel Then
            lbl_darkboardPreview.BackColor = cd_colorPicker.Color
            chessboardDarkSquares = vbColorToHex(cd_colorPicker.Color)
            updateBoardPreview()
        End If
    End Sub

    ' update light board colour and preview
    Private Sub btn_lightSquares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_lightSquares.Click
        If cd_colorPicker.ShowDialog() <> System.Windows.Forms.DialogResult.Cancel Then
            lbl_lightboardPreview.BackColor = cd_colorPicker.Color
            chessboardLightSquares = vbColorToHex(cd_colorPicker.Color)
            updateBoardPreview()
        End If
    End Sub

    ' update valid move indicator colour and preview
    Private Sub btn_moveIndicator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_moveIndicator.Click
        If cd_colorPicker.ShowDialog() <> System.Windows.Forms.DialogResult.Cancel Then
            lbl_validMoveIndicatorPreview.BackColor = cd_colorPicker.Color
            validMoveIndicator = vbColorToHex(cd_colorPicker.Color)
            updateBoardPreview()
        End If
    End Sub

    ' update dot capture indicator colour and preview
    Private Sub btn_dotCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_dotCapture.Click
        If cd_colorPicker.ShowDialog() <> System.Windows.Forms.DialogResult.Cancel Then
            lbl_dotCapturePreview.BackColor = cd_colorPicker.Color
            validDotCaptureIndicator = vbColorToHex(cd_colorPicker.Color)
            updateBoardPreview()
        End If
    End Sub
End Class