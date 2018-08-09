Public Class frm_game
    ' holds the game currently open
    Dim currentGame As chess.Game

    ' holds current move to be executed
    Dim currentMove As chess.Move

    ' boolean state flags
    Dim isGameNew As Boolean
    Dim startGameDialogShowing As Boolean
    Dim pawnPromotionDialogUp As Boolean
    Dim gameIsOver As Boolean
    Dim optionsDialogUp As Boolean

    ' holds player name
    Dim whitePlayerName As String
    Dim blackPlayerName As String

    ' piece selection
    Dim pieceSelected As Boolean
    Dim selectedPieceCoords() As Integer

    ' switch side delay
    Dim switchSideDelayTimer As Timer
    Dim switchSideFlag As Boolean

    ' holds chessclock enabled states every time the game is paused so they can be restored
    Dim timerStates() As Boolean

    ' checks if the user wants to navigate to the main menu
    Dim goingToMainMenu As Boolean

#Region "Start game"
    ' game load function - initialises or loads game and sets all flag values
    Private Sub game_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' hide end game panel
        p_endGame.Visible = False

        ' either load or initialise game to currentGame
        If options.loadGame Then
            ' load game from file
            currentGame = chess.loadGame(options.loadGamePath, False)
            Me.Text = checkmateFilePathToFile(options.loadGamePath)
            isGameNew = False
            lbl_startGameDialog.Text = "Continue game?"
            loadNames(options.loadGamePath, whitePlayerName, blackPlayerName)
        Else
            ' initialise new game
            currentGame = chess.initGame(resources.stringboardStartingPosition, options.totalTime, options.interval, options.increment)
            isGameNew = True
            p_enterNames.Visible = True
            p_enterNames.BringToFront()
        End If

        ' initialise timers
        AddHandler currentGame.whiteTime.timer.Tick, Sub() chess.clockTick(currentGame.whiteTime, AddressOf newGamewhiteTimeDisplay, AddressOf endGame, True)
        AddHandler currentGame.blackTime.timer.Tick, Sub() chess.clockTick(currentGame.blackTime, AddressOf newGameblackTimeDisplay, AddressOf endGame, False)

        ' display game
        displayGame(currentGame)

        ' iniitialise switch side delay
        switchSideDelayTimer = New Timer With {.Interval = options.switchSideDelay}
        AddHandler switchSideDelayTimer.Tick, AddressOf switchSideEndMove

        ' initalise boolean flags
        pieceSelected = False
        switchSideFlag = False
        startGameDialogShowing = True
        optionsDialogUp = False
        goingToMainMenu = False

        ' initialise timerStates
        timerStates = {False, False}
    End Sub

    ' load names from file
    Private Sub loadNames(ByVal filePath As String, ByRef whiteName As String, ByRef blackName As String)
        Dim temp As String

        ' open file (assumes filePath is valid)
        FileSystem.FileOpen(1, filePath, OpenMode.Input)

        ' skip past all game data
        temp = FileSystem.LineInput(1)
        temp = FileSystem.LineInput(1)
        temp = FileSystem.LineInput(1)
        temp = FileSystem.LineInput(1)
        temp = FileSystem.LineInput(1)

        ' read names
        whiteName = FileSystem.LineInput(1)
        blackName = FileSystem.LineInput(1)

        ' close file
        FileSystem.FileClose(1)
    End Sub

    ' confirm start game
    Private Sub btn_startGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_startGame.Click
        startGameDialogShowing = False
        p_startGame.Visible = False

        Dim gameStatus As Integer
        If currentGame.whiteToMove Then
            gameStatus = chess.gameStatus(currentGame, True)
        Else
            gameStatus = chess.gameStatus(currentGame, False)
        End If

        If gameStatus <> 0 Then
            endGame(Not currentGame.whiteToMove, gameStatus)
        Else
            If isGameNew Then
                chess.enableClock(currentGame.whiteTime, True)
            Else
                If currentGame.whiteToMove Then
                    enableClock(currentGame.whiteTime, True)
                    enableClock(currentGame.blackTime, False)
                Else
                    enableClock(currentGame.whiteTime, False)
                    enableClock(currentGame.blackTime, True)
                End If
            End If
        End If
    End Sub

    ' given a file name, returns just the filename without the file extension (used for displaying file name in window bar)
    Private Function checkmateFilePathToFile(ByVal path As String) As String
        Dim fileNameArray() As String
        fileNameArray = path.Split("\")

        Dim fileName As String
        fileName = fileNameArray(fileNameArray.Length - 1).Split(".")(0)

        checkmateFilePathToFile = fileName
    End Function

    ' set player names
    Private Sub btn_confirmPlayerName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirmPlayerName.Click
        whitePlayerName = tb_whitePlayerName.Text
        blackPlayerName = tb_blackPlayerName.Text
        p_enterNames.Visible = False
    End Sub
#End Region

#Region "Do move / takeback move"
    ' handled by the switchSideDelayTimer, used to give a delay before switching sides after placed
    ' this sub handles the second half of doing a move:
    '    - checks the game status and ends game if over
    '    - switches the timers and reenables them (they are paused while the side is switching)
    '    - adds increment to timers
    Private Sub switchSideEndMove()
        ' this flag is turned on when the sub needs to be called, as it is continually called by a timer
        ' the flag is switched off once it finishes executing
        If switchSideFlag Then
            ' reenable timers
            currentGame.whiteTime.timer.Enabled = timerStates(0)
            currentGame.blackTime.timer.Enabled = timerStates(1)

            ' switch game sides (switch timers and board orientation)
            currentGame = chess.switchSide(currentGame)

            Dim whiteCurrentTurn As Boolean
            whiteCurrentTurn = currentGame.whiteToMove

            ' checking game status
            Dim gameStatus As Integer
            If whiteCurrentTurn Then
                gameStatus = chess.gameStatus(currentGame, True)
            Else
                gameStatus = chess.gameStatus(currentGame, False)
            End If

            ' either continue playing or end game
            If gameStatus = 0 Then
                ' if normal, just add timer increment
                If whiteCurrentTurn Then
                    chess.clockAddIncrement(currentGame.whiteTime)
                Else
                    chess.clockAddIncrement(currentGame.blackTime)
                End If
            Else
                endGame(Not whiteCurrentTurn, gameStatus)
            End If

            displayGame(currentGame)
            switchSideFlag = False
        End If
    End Sub

    ' check if move in moveDict (used when selecting piece to make sure it is valid)
    Private Function moveInMoveDict(ByVal pieceToCheckCoords As Integer(), ByVal moveDict As Dictionary(Of Integer(), Integer())) As Boolean
        Dim inMoveDict As Boolean
        inMoveDict = False

        For Each keyValuePair In moveDict
            If keyValuePair.Key(0) = pieceToCheckCoords(0) And keyValuePair.Key(1) = pieceToCheckCoords(1) Then
                inMoveDict = True
            End If
        Next

        moveInMoveDict = inMoveDict
    End Function

    ' this sub handles all clicks on the chessboard
    ' first it checks if the game has started and is not over, then uses mouseCoordstoChessCoords to get a coordinate value of the click
    ' then, if a piece is already selected (checks through pieceSelected flag), it checks if the move clicked is valid, and then executes it
    '    - if the move is a pawn promotion, it displays the pawn promotion dialog and doesn't do anything else. The buttons on the pawn promotion
    '      dialog then handle the rest of the move. This is as the move structure is global and all functions can access it.
    '    - otherwise, it does the move and doesn't switch sides and sets the switchSideFlag to be true. Then the switchSideDelay function handles
    '      the rest of the move.
    ' if a piece is not selected, it selects the piece and displays all valid moves
    Private Sub pb_chessboard_Click(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles pb_chessboard.Click
        ' if game hasn't started or isn't over
        If Not startGameDialogShowing And Not gameIsOver And Not optionsDialogUp Then
            Dim coords() As Integer
            ' retrieve chessboard coord value from mouse coords
            coords = mouseCoordstoChessCoords({e.Location.X, e.Location.Y}, currentGame.whiteToMove)

            Dim selectPiece As Boolean
            selectPiece = True

            Dim validMoves As Dictionary(Of Integer(), Integer())

            ' used for pawn promotion dialog
            Dim knight As Char
            Dim bishop As Char
            Dim queen As Char
            Dim rook As Char
            knight = "N"
            bishop = "B"
            queen = "Q"
            rook = "R"
            If Char.IsUpper(currentGame.board(coords(0), coords(1))) Then
                knight = "n"
                bishop = "b"
                queen = "q"
                rook = "r"
            End If

            ' close pawn promotion dialog if it hasn't been clicked
            If pawnPromotionDialogUp Then
                pawnPromotionDialogUp = False
                p_choosePawnPromotionPiece.Visible = False
            End If

            ' if piece has been selected
            If pieceSelected Then
                ' and a valid move clicked
                If moveInMoveDict(coords, chess.validMoves(currentGame, selectedPieceCoords)) Then
                    ' deselects piece
                    selectPiece = False

                    ' creates all of move except for promotion 
                    currentMove.gameState = currentGame
                    currentMove.startCoords = selectedPieceCoords
                    currentMove.destinationCoords = coords
                    currentMove.moveKeys = chess.getMoveKeys(selectedPieceCoords, coords, currentGame)

                    ' if move is pawn promotion set up pawn promotion dialog and don't do anything else
                    If currentMove.moveKeys.Contains(3) Then
                        ' pauses clocks while sides switch
                        timerStates = {currentGame.whiteTime.timer.Enabled, currentGame.blackTime.timer.Enabled}
                        enableClock(currentGame.whiteTime, False)
                        enableClock(currentGame.blackTime, False)

                        p_choosePawnPromotionPiece.Visible = True

                        pawnPromotionDialogUp = True

                        ' choose piece to display based on style
                        pb_pawnPromotionKnight.Image = Image.FromFile(resources.chessPiecesFilePath(knight, options.pieceStyle))
                        pb_pawnPromotionBishop.Image = Image.FromFile(resources.chessPiecesFilePath(bishop, options.pieceStyle))
                        pb_pawnPromotionRook.Image = Image.FromFile(resources.chessPiecesFilePath(rook, options.pieceStyle))
                        pb_pawnPromotionQueen.Image = Image.FromFile(resources.chessPiecesFilePath(queen, options.pieceStyle))
                    Else
                        ' play sound
                        My.Computer.Audio.Play(resources.chessSoundsFilePath(1))

                        currentMove.promotion = ""

                        currentGame = chess.doMove(currentMove)

                        If options.boardSwitchingEnabled Then
                            ' pauses clocks while sides switch
                            timerStates = {currentGame.whiteTime.timer.Enabled, currentGame.blackTime.timer.Enabled}
                            enableClock(currentGame.whiteTime, False)
                            enableClock(currentGame.blackTime, False)

                            displayGame(currentGame, False)
                            switchSideDelayTimer.Enabled = False
                            switchSideFlag = True
                            switchSideDelayTimer.Enabled = True
                        Else
                            ' switch game sides (switch timers and board orientation)
                            currentGame = chess.switchSide(currentGame)

                            Dim whiteCurrentTurn As Boolean
                            whiteCurrentTurn = currentGame.whiteToMove

                            ' checking game status
                            Dim gameStatus As Integer
                            If whiteCurrentTurn Then
                                gameStatus = chess.gameStatus(currentGame, True)
                            Else
                                gameStatus = chess.gameStatus(currentGame, False)
                            End If

                            ' either continue playing or end game
                            If gameStatus = 0 Then
                                ' if normal, just add timer increment
                                If whiteCurrentTurn Then
                                    chess.clockAddIncrement(currentGame.whiteTime)
                                Else
                                    chess.clockAddIncrement(currentGame.blackTime)
                                End If
                            Else
                                endGame(Not whiteCurrentTurn, gameStatus)
                            End If

                            displayGame(currentGame)
                        End If

                    End If
                End If
            End If

            If Not selectedPieceCoords Is Nothing Then
                ' deselect piece if selected again
                If coords(0) = selectedPieceCoords(0) And coords(1) = selectedPieceCoords(1) And pieceSelected Then
                    selectPiece = False
                    pieceSelected = False
                    If options.boardSwitchingEnabled Then
                        displayBoard(currentGame.board, currentGame.whiteToMove, options.pieceStyle)
                    Else
                        displayBoard(currentGame.board, True, options.pieceStyle)
                    End If
                End If
            End If

            If selectPiece Then
                validMoves = chess.validMoves(currentGame, coords)
                If options.boardSwitchingEnabled Then
                    displayBoard(currentGame.board, currentGame.whiteToMove, options.pieceStyle, validMoves, coords, options.moveHighlightStyle)
                Else
                    displayBoard(currentGame.board, True, options.pieceStyle, validMoves, coords, options.moveHighlightStyle)
                End If

                If Not validMoves.Count = 0 Then
                    pieceSelected = True
                    selectedPieceCoords = coords
                End If
            End If
        End If
    End Sub

    ' given coordinates of mouse click on chessboards, returns corresponding coordinates on board
    Private Function mouseCoordstoChessCoords(ByVal mouseCoords As Integer(), ByVal whiteToMove As Boolean) As Integer()
        Dim chessboardWidth As Integer
        Dim chessboardHeight As Integer
        chessboardWidth = pb_chessboard.Width / 8
        chessboardHeight = pb_chessboard.Height / 8

        Dim x = (mouseCoords(0) - (mouseCoords(0) Mod chessboardWidth)) / chessboardWidth
        Dim y = 7 - ((mouseCoords(1) - (mouseCoords(1) Mod chessboardHeight)) / chessboardHeight)
        If Not whiteToMove And boardSwitchingEnabled Then
            y = (mouseCoords(1) - (mouseCoords(1) Mod chessboardHeight)) / chessboardHeight
        End If

        mouseCoordstoChessCoords = {x, y}
    End Function

    ' handles pawn promotion
    Private Sub pb_pawnPromotionClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_pawnPromotionKnight.Click, pb_pawnPromotionBishop.Click, pb_pawnPromotionRook.Click, pb_pawnPromotionQueen.Click
        ' play sound
        My.Computer.Audio.Play(resources.chessSoundsFilePath(1))

        ' restore timers
        currentGame.whiteTime.timer.Enabled = timerStates(0)
        currentGame.blackTime.timer.Enabled = timerStates(1)

        ' hide panel
        p_choosePawnPromotionPiece.Visible = False

        Dim promotion As Char
        Select Case CType(sender, PictureBox).Name
            Case "pb_pawnPromotionKnight"
                promotion = "n"
            Case "pb_pawnPromotionBishop"
                promotion = "b"
            Case "pb_pawnPromotionRook"
                promotion = "r"
            Case Else
                promotion = "q"
        End Select

        If currentGame.whiteToMove Then
            promotion = Char.ToUpper(promotion)
        End If

        currentMove.promotion = promotion
        currentGame = chess.doMove(currentMove)
        displayGame(currentGame, False)

        pawnPromotionDialogUp = False

        switchSideDelayTimer.Enabled = False
        switchSideFlag = True
        switchSideDelayTimer.Enabled = True
    End Sub

    ' takeback move
    Private Sub btn_takeBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_takeBack.Click
        If Not startGameDialogShowing And Not gameIsOver And Not pawnPromotionDialogUp And Not optionsDialogUp Then
            currentGame = chess.takebackMove(currentGame)
            displayGame(currentGame)
        End If
    End Sub
#End Region

#Region "Resizing"
    ' called when resizing window, this sub calls resizeAndCenter while resizing
    ' as pb_chessboard.SizeMode = StretchImage, this prevents rerendering while resizing
    Private Sub game_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        resizeAndCenter()
    End Sub

    ' called when resizing finished, this sub rerenders the board
    Private Sub game_ResizeEnd(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ResizeEnd
        resizeAndCenter()
        pieceSelected = False
        displayBoard(currentGame.board, currentGame.whiteToMove)
    End Sub
#End Region

#Region "Graphics"
    ' display game (wrapper functions that calls all other display functions)
    Private Sub displayGame(ByVal game As chess.Game, Optional ByVal switchSide As Boolean = True)
        resizeAndCenter()
        If options.boardSwitchingEnabled Then
            If switchSide Then
                displayBoard(game.board, game.whiteToMove, options.pieceStyle)
            Else
                displayBoard(game.board, Not game.whiteToMove, options.pieceStyle)
            End If
        Else
            displayBoard(game.board, True, options.pieceStyle)
        End If


        displayHistory(game.history)
        displayBlackTime(game.blackTime.timeLeft)
        displayWhiteTime(game.whiteTime.timeLeft)
        displayMoveIndicator(game.whiteToMove)
    End Sub

    ' displays move indicator
    Sub displayMoveIndicator(ByVal whiteToMove As Boolean)
        If whiteToMove Then
            lbl_moveIndicator.Text = "White to move"
        Else
            lbl_moveIndicator.Text = "Black to move"
        End If
    End Sub

    ' display white time
    Sub displayWhiteTime(ByVal time As TimeSpan)
        lbl_whiteTimeCounter.Text = chess.timespanToString(time)
    End Sub

    ' display black time
    Sub displayBlackTime(ByVal time As TimeSpan)
        lbl_blackTimeCounter.Text = chess.timespanToString(time)
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

    ' display board (wrapper for renderBoard that sets the rendered output to the chessboard picturebox's image)
    Private Sub displayBoard(ByVal board As Char(,), ByVal whiteToMove As Boolean, Optional ByVal pieceStyle As Integer = 0, Optional ByVal validMoves As Dictionary(Of Integer(), Integer()) = Nothing, Optional ByVal validMoveStartCoords As Integer() = Nothing, Optional ByVal indicatorStyle As Integer = 0)
        Dim renderedChessboard As Bitmap
        renderedChessboard = renderBoard(currentGame.board, {pb_chessboard.Width, pb_chessboard.Height}, whiteToMove, pieceStyle, indicatorStyle, validMoves, validMoveStartCoords, options.chessboardDarkSquareHex, options.chessboardLightSquareHex, options.validMoveIndicatorHex, options.validDotCaptureIndicatorHex, options.validSquareCaptureIndicatorHex, options.kingInCheckHex, options.selectedPieceHex)
        pb_chessboard.Image = renderedChessboard
    End Sub

    ' update white time label from newGame (called on timer tick)
    Sub newGamewhiteTimeDisplay()
        displayWhiteTime(currentGame.whiteTime.timeLeft)
    End Sub

    ' update black time label from newGame (called on timer tick)
    Sub newGameblackTimeDisplay()
        displayBlackTime(currentGame.blackTime.timeLeft)
    End Sub

    ' dynamically resize all elements on the chessboard
    ' this includes the actual chessboard and the start game dialog, game is over dialog and pawn promotion dialog
    Private Sub resizeAndCenter()
        ' find largest dimension (width or height) and size chessboard to a square in that size
        If p_chessboardContainer.Parent.Size.Height > p_chessboardContainer.Parent.Size.Width Then
            p_chessboardContainer.Height = p_chessboardContainer.Parent.Size.Width
            p_chessboardContainer.Width = p_chessboardContainer.Parent.Size.Width
        Else
            p_chessboardContainer.Height = p_chessboardContainer.Parent.Size.Height
            p_chessboardContainer.Width = p_chessboardContainer.Parent.Size.Height
        End If

        ' center chessboard
        p_chessboardContainer.Top = p_chessboardContainer.Parent.Height / 2 - p_chessboardContainer.Height / 2
        p_chessboardContainer.Left = p_chessboardContainer.Parent.Width / 2 - p_chessboardContainer.Width / 2

        ' center start game dialog
        p_startGame.Top = p_startGame.Parent.Height / 4 '- p_startGame.Height / 2
        p_startGame.Left = p_startGame.Parent.Width / 2 - p_startGame.Width / 2

        ' center end game dialog
        p_endGame.Top = p_endGame.Parent.Height / 4
        p_endGame.Left = p_endGame.Parent.Width / 2 - p_endGame.Width / 2

        ' center pawn promotion dialog
        p_choosePawnPromotionPiece.Top = p_choosePawnPromotionPiece.Parent.Height / 4
        p_choosePawnPromotionPiece.Left = p_choosePawnPromotionPiece.Parent.Width / 2 - p_choosePawnPromotionPiece.Width / 2

        ' center enter name dialog
        p_enterNames.Top = p_enterNames.Parent.Height / 4
        p_enterNames.Left = p_enterNames.Parent.Width / 2 - p_enterNames.Width / 2
    End Sub

    ' renders the board as a bitmap
    ' parameters are:
    '   - board
    '   - sizeCoords (resolution for output in {x, y} format
    '   - whiteToMove (decides orientation of board)
    '   - pieceStyle (decides what style the piece is going to be rendered, will be passed to resources.chessPiecesFilePath)
    '   - OPTIONAL MOVE HIGHLIGHTING PARAMETERS
    '       - validMoves (moveDict with valid moves to highlight)
    '       - validMoveStartCoords (currently selected piece)
    '       - indicatorStyle (indicator style of valid pieces (0 - dots, 1 - squares))
    ' hex colors for colors used are taken from options.vb
    Public Function renderBoard(ByVal board As Char(,), ByVal sizeCoords As Integer(), ByVal whiteToMove As Boolean, Optional ByVal pieceStyle As Integer = 0, Optional ByVal indicatorStyle As Integer = 0, _
                                Optional ByVal validMoves As Dictionary(Of Integer(), Integer()) = Nothing, Optional ByVal validMoveStartCoords As Integer() = Nothing, _
                                Optional ByVal chessboardDarkSquareHex As String = "#54727C", _
                                Optional ByVal chessboardLightSquareHex As String = "#FFFFFF", _
                                Optional ByVal validMoveIndicatorHex As String = "#BFADD8E6", _
                                Optional ByVal validDotCaptureIndicatorHex As String = "#E6D14B4B", _
                                Optional ByVal validSquareCaptureIndicatorHex As String = "#E6E6ADAD", _
                                Optional ByVal kingInCheckHex As String = "#E6D14B4B", _
                                Optional ByVal selectedPieceHex As String = "#BF98FB98") As Bitmap

        Dim highlightValidMoves As Boolean
        highlightValidMoves = Not validMoves Is Nothing

        Dim chessboard_bmp As Bitmap
        chessboard_bmp = New Bitmap(sizeCoords(0), sizeCoords(1))

        Dim chessboard_graphics As Graphics
        chessboard_graphics = Graphics.FromImage(chessboard_bmp)
        chessboard_graphics.Clear(Color.White)

        Dim squareWidth As Integer
        Dim squareHeight As Integer
        Dim moveIndicatorSquareWidth As Integer
        Dim moveIndicatorSquareHeight As Integer

        Dim squareXCoord As Integer
        Dim squareYCoord As Integer
        Dim moveIndicatorSquareXCoord As Integer
        Dim moveIndicatorSquareYCoord As Integer

        Dim whiteSquareOnTopLeft As Boolean
        whiteSquareOnTopLeft = True

        Dim currentSquare As Rectangle
        Dim validMoveIndicator As Rectangle

        For x = 0 To 7
            squareWidth = sizeCoords(0) / 8
            squareHeight = sizeCoords(1) / 8
            moveIndicatorSquareWidth = squareWidth
            moveIndicatorSquareHeight = squareHeight

            If indicatorStyle = 0 Then
                moveIndicatorSquareWidth = squareWidth / 4
                moveIndicatorSquareHeight = squareHeight / 4
            End If

            squareXCoord = x * squareWidth
            moveIndicatorSquareXCoord = squareXCoord

            If indicatorStyle = 0 Then
                moveIndicatorSquareXCoord = squareXCoord + (squareWidth / 2) - (moveIndicatorSquareWidth / 2)
            End If

            For y = 0 To 7
                squareYCoord = (7 - y) * squareHeight
                If Not whiteToMove Then
                    squareYCoord = y * squareHeight
                End If
                moveIndicatorSquareYCoord = squareYCoord

                If indicatorStyle = 0 Then
                    moveIndicatorSquareYCoord = squareYCoord + (squareHeight / 2) - (moveIndicatorSquareHeight / 2)
                End If

                currentSquare = New Rectangle(New Point(squareXCoord, squareYCoord), New Size(squareWidth, squareHeight))
                validMoveIndicator = New Rectangle(New Point(moveIndicatorSquareXCoord, moveIndicatorSquareYCoord), New Size(moveIndicatorSquareWidth, moveIndicatorSquareHeight))

                ' draw chessboard squares
                If Not whiteSquareOnTopLeft Then
                    ' dark squares
                    chessboard_graphics.FillRectangle(New SolidBrush(ColorTranslator.FromHtml(chessboardDarkSquareHex)), currentSquare)
                Else
                    ' light squares
                    chessboard_graphics.FillRectangle(New SolidBrush(ColorTranslator.FromHtml(chessboardLightSquareHex)), currentSquare)
                End If

                Dim drawMoveOverPiece As Boolean
                drawMoveOverPiece = False

                ' if square is valid move highlight according to style
                If highlightValidMoves Then
                    For Each keyValuePair In validMoves
                        If keyValuePair.Key(0) = x And keyValuePair.Key(1) = y Then
                            If board(x, y) = " " And Not keyValuePair.Value.Contains(2) Then
                                ' valid move indicator (not captures)
                                If indicatorStyle = 0 Then
                                    chessboard_graphics.FillEllipse(New SolidBrush(ColorTranslator.FromHtml(validMoveIndicatorHex)), validMoveIndicator)
                                Else
                                    chessboard_graphics.FillRectangle(New SolidBrush(ColorTranslator.FromHtml(validMoveIndicatorHex)), validMoveIndicator)
                                End If
                            Else
                                ' current valid move is taking piece
                                If indicatorStyle = 0 Then
                                    drawMoveOverPiece = True
                                Else
                                    chessboard_graphics.FillRectangle(New SolidBrush(ColorTranslator.FromHtml(validSquareCaptureIndicatorHex)), validMoveIndicator)
                                End If
                            End If
                        End If
                    Next

                    ' if square is selected square then highlight
                    If x = validMoveStartCoords(0) And y = validMoveStartCoords(1) Then
                        chessboard_graphics.FillRectangle(New SolidBrush(ColorTranslator.FromHtml(selectedPieceHex)), currentSquare)
                    End If
                End If

                ' ignore null error (this happens when saving options from the main menu. the settings still get saved)
                Try
                    ' if king in check indicate
                    If Char.ToUpper(board(x, y)) = "K" And chess.isPieceBeingAttacked(chess.findCoordsOfPieceOnBoard(board(x, y), board), board) Then
                        Dim divisor = 4
                        Dim pointTriangleArray1() As Point
                        Dim pointTriangleArray2() As Point
                        Dim pointTriangleArray3() As Point
                        Dim pointTriangleArray4() As Point

                        pointTriangleArray1 = {New Point(squareXCoord, squareYCoord), New Point(squareXCoord, squareYCoord + squareHeight / divisor), New Point(squareXCoord + squareHeight / divisor, squareYCoord)}
                        pointTriangleArray2 = {New Point((squareXCoord + squareWidth) - squareWidth / divisor, squareYCoord), New Point(squareXCoord + squareWidth, squareYCoord), New Point(squareXCoord + squareHeight, squareYCoord + (squareHeight / divisor))}
                        pointTriangleArray3 = {New Point(squareXCoord, squareYCoord + squareHeight), New Point(squareXCoord, (squareYCoord + squareHeight) - squareHeight / divisor), New Point(squareXCoord + squareHeight / divisor, squareYCoord + squareHeight)}
                        pointTriangleArray4 = {New Point((squareXCoord + squareWidth) - squareWidth / divisor, squareYCoord + squareHeight), New Point(squareXCoord + squareWidth, squareYCoord + squareHeight), New Point(squareXCoord + squareWidth, (squareYCoord + squareHeight) - (squareHeight / divisor))}

                        chessboard_graphics.FillPolygon(New SolidBrush(ColorTranslator.FromHtml(kingInCheckHex)), pointTriangleArray1)
                        chessboard_graphics.FillPolygon(New SolidBrush(ColorTranslator.FromHtml(kingInCheckHex)), pointTriangleArray2)
                        chessboard_graphics.FillPolygon(New SolidBrush(ColorTranslator.FromHtml(kingInCheckHex)), pointTriangleArray3)
                        chessboard_graphics.FillPolygon(New SolidBrush(ColorTranslator.FromHtml(kingInCheckHex)), pointTriangleArray4)
                    End If

                    ' draw image and dot over if indicator style is dots
                    chessboard_graphics.DrawImage(Image.FromFile(resources.chessPiecesFilePath(board(x, y), pieceStyle)), currentSquare)
                    If drawMoveOverPiece Then
                        chessboard_graphics.FillEllipse(New SolidBrush(ColorTranslator.FromHtml(validDotCaptureIndicatorHex)), validMoveIndicator)
                    End If
                Catch ex As Exception

                End Try


                whiteSquareOnTopLeft = Not whiteSquareOnTopLeft
            Next
            whiteSquareOnTopLeft = Not whiteSquareOnTopLeft
        Next

        renderBoard = chessboard_bmp
    End Function
#End Region

#Region "Save game"
    ' save game
    Private Sub saveGame()
        ' save current states of clocks
        Dim blackTimerEnabled As Boolean
        Dim whiteTimerEnabled As Boolean
        blackTimerEnabled = currentGame.blackTime.timer.Enabled
        whiteTimerEnabled = currentGame.whiteTime.timer.Enabled

        ' pause both clocks while saving file
        enableClock(currentGame.blackTime, False)
        enableClock(currentGame.whiteTime, False)

        Dim saveFileDialog = New SaveFileDialog()
        saveFileDialog.Filter = ".checkmate (*.checkmate)|*.checkmate"
        saveFileDialog.Title = "Save game"
        saveFileDialog.ShowDialog()

        If saveFileDialog.FileName <> "" Then
            chess.saveGame(currentGame, saveFileDialog.FileName, True, "")

            ' save names to file
            My.Computer.FileSystem.WriteAllText(saveFileDialog.FileName, whitePlayerName & vbCrLf & blackPlayerName, True)
        End If

        ' update titlebar
        Me.Text = checkmateFilePathToFile(saveFileDialog.FileName)

        ' resume clocks
        enableClock(currentGame.blackTime, blackTimerEnabled)
        enableClock(currentGame.whiteTime, whiteTimerEnabled)
    End Sub

    ' ctrl-s to save game
    Private Sub game_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.S And e.Modifiers = Keys.Control Then
            saveGame()
        End If
    End Sub
#End Region

#Region "End game"
    ' end game
    Private Sub endGame(ByVal whiteWin As Boolean, ByVal gameStatus As Integer)
        enableClock(currentGame.whiteTime, False)
        enableClock(currentGame.blackTime, False)

        Dim message As String

        Dim writeToHighscores As Boolean
        writeToHighscores = False


        Dim winningName As String
        Dim losingName As String

        If whiteWin Then
            winningName = whitePlayerName
            losingName = blackPlayerName
        Else
            winningName = blackPlayerName
            losingName = whitePlayerName
        End If

        Dim highscoreString As String
        highscoreString = whitePlayerName & " vs " & blackPlayerName & ": "

        Select Case gameStatus
            Case 1
                message = winningName & " wins by checkmate!"
                highscoreString = highscoreString + winningName + " won by checkmate"
                writeToHighscores = True
            Case 2
                message = "Draw by stalemate"
            Case 3
                message = "Draw from insufficient material"
            Case 4
                message = winningName & " wins on time!"
                highscoreString = highscoreString + winningName + " won on time"
                writeToHighscores = True
            Case Else
                message = losingName & " resigns, " & winningName & " wins!"
        End Select

        If writeToHighscores Then
            Dim timeLeft As String
            timeLeft = ""

            If whiteWin Then
                If currentGame.whiteTime.totalTime = New TimeSpan(0, 0, 0) Then
                    timeLeft = currentGame.whiteTime.timeLeft.TotalSeconds
                Else
                    timeLeft = (currentGame.whiteTime.totalTime - currentGame.whiteTime.timeLeft).TotalSeconds
                    If timeLeft < 0 Then
                        timeLeft = 0 - timeLeft
                    End If
                End If
            Else
                If currentGame.blackTime.totalTime = New TimeSpan(0, 0, 0) Then
                    timeLeft = currentGame.blackTime.timeLeft.TotalSeconds
                Else
                    timeLeft = (currentGame.blackTime.totalTime - currentGame.blackTime.timeLeft).TotalSeconds
                    If timeLeft < 0 Then
                        timeLeft = 0 - timeLeft
                    End If
                End If
            End If

            My.Computer.FileSystem.WriteAllText(resources.highscoreFile, highscoreString & " in " & timeLeft & " seconds!" & vbCrLf, True)
        End If

        gameIsOver = True

        resizeAndCenter()

        p_endGame.Visible = True

        btn_endGameMainMenu.BringToFront()
        btn_endGameDialogClose.BringToFront()

        lbl_endGameDialog.Text = message
    End Sub

    ' resign
    Private Sub btn_resign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_resign.Click
        If Not startGameDialogShowing And Not gameIsOver Then
            endGame(Not currentGame.whiteToMove, 5)
        End If
    End Sub

    ' close end game dialog
    Private Sub btn_endGameNotifyClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_endGameDialogClose.Click
        p_endGame.Visible = False
    End Sub

    ' return to main menu from end game dialog
    Private Sub btn_endGameMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_endGameMainMenu.Click
        goingToMainMenu = True
        frm_mainMenu.Show()
        Me.Close()
    End Sub

    ' close application when form closing (if user not going to main menu)
    Private Sub frm_game_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not goingToMainMenu Then
            Application.Exit()
        End If
    End Sub
#End Region

#Region "Menu items"
    ' save game
    Private Sub tsmi_saveGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_saveGame.Click
        saveGame()
    End Sub

    ' exit game
    Private Sub tsmi_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_exit.Click
        Application.Exit()
    End Sub

    ' takeback move
    Private Sub tsmi_takeBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_takeBack.Click
        If Not startGameDialogShowing And Not gameIsOver And Not pawnPromotionDialogUp And Not optionsDialogUp Then
            currentGame = chess.takebackMove(currentGame)
            displayGame(currentGame)
        End If
    End Sub

    ' resign
    Private Sub tsmi_resign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_resign.Click
        If Not startGameDialogShowing And Not gameIsOver And Not optionsDialogUp Then
            endGame(Not currentGame.whiteToMove, 5)
        End If
    End Sub

    ' go to main menu
    Private Sub tsmi_mainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_mainMenu.Click
        goingToMainMenu = True
        Me.Close()
        frm_mainMenu.Show()
    End Sub

    ' change piece style
    Private Sub tsmi_pieceStyle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_pieceStyle1.Click, tsmi_pieceStyle2.Click, tsmi_pieceStyle3.Click, tsmi_pieceStyle4.Click, tsmi_pieceStyle5.Click
        tsmi_pieceStyle1.Checked = False
        tsmi_pieceStyle2.Checked = False
        tsmi_pieceStyle3.Checked = False
        tsmi_pieceStyle4.Checked = False
        tsmi_pieceStyle5.Checked = False
        Select Case CType(sender, ToolStripMenuItem).Name
            Case "tsmi_pieceStyle1"
                options.pieceStyle = 0
                tsmi_pieceStyle1.Checked = True
            Case "tsmi_pieceStyle2"
                options.pieceStyle = 1
                tsmi_pieceStyle2.Checked = True
            Case "tsmi_pieceStyle3"
                options.pieceStyle = 2
                tsmi_pieceStyle3.Checked = True
            Case "tsmi_pieceStyle4"
                options.pieceStyle = 3
                tsmi_pieceStyle4.Checked = True
            Case Else
                options.pieceStyle = 4
                tsmi_pieceStyle5.Checked = True
        End Select
        pieceSelected = False
        displayGame(currentGame)
    End Sub

    ' change highlight style to dots
    Private Sub tsmi_dots_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_dots.Click
        tsmi_dots.Checked = True
        tsmi_squares.Checked = False
        options.moveHighlightStyle = 0
        displayGame(currentGame)
        pieceSelected = False
    End Sub

    ' change highlight style to squares
    Private Sub tsmi_squares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_squares.Click
        tsmi_dots.Checked = False
        tsmi_squares.Checked = True
        options.moveHighlightStyle = 1
        displayGame(currentGame)
        pieceSelected = False
    End Sub

    ' show about screen
    Private Sub tsmi_about_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_about.Click
        frm_about.Show()
    End Sub

    ' open options
    Private Sub tsmi_optionsFromFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_optionsFromFile.Click
        openOptions()
    End Sub

    ' open options
    Private Sub tsmi_optionsFromGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_optionsFromGame.Click
        openOptions()
    End Sub

    ' open options
    Private Sub tsmi_optionsFromView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmi_optionsFromView.Click
        openOptions()
    End Sub
#End Region

#Region "Options"
    ' open game options and pause game
    Private Sub openOptions()
        ' set opened from mainmenu to be false
        options.optionsOpenedFromMainMenu = False

        ' save timer states
        timerStates(0) = currentGame.whiteTime.timer.Enabled
        timerStates(1) = currentGame.blackTime.timer.Enabled

        ' pause timers
        enableClock(currentGame.whiteTime, False)
        enableClock(currentGame.blackTime, False)

        optionsDialogUp = True

        frm_gameOptions.Show()
    End Sub

    ' close options and continue game
    Public Sub closeOptions()
        If boardSwitchingEnabled Then
            displayBoard(currentGame.board, currentGame.whiteToMove, options.pieceStyle)
        Else
            displayBoard(currentGame.board, True, options.pieceStyle)
        End If

        optionsDialogUp = False

        ' restore timer states
        currentGame.whiteTime.timer.Enabled = timerStates(0)
        currentGame.blackTime.timer.Enabled = timerStates(1)

        If switchSideDelayTimer.Interval <> options.switchSideDelay Then
            ' change timer interval value
            switchSideDelayTimer.Interval = options.switchSideDelay
        End If
    End Sub

    ' options through button
    Private Sub btn_options_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_options.Click
        openOptions()
    End Sub
#End Region


End Class