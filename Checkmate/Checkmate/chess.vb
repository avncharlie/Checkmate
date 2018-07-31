Module chess

    ' data type definitions of terms used:
    '   - board: 2d char array of pieces
    '   - string board: char of length 64 holding all pieces on board
    '   - coords: 2 item integer array in form of [x, y]
    '   - SAN (Standard Algebraic Notation): char of length 2 in the form [file, rank] showing coordinates on board
    '   - SANMove: char of variable length that holds a valid chess move in valid SAN notation
    '   - history: an array of SANMoves
    '   - boardHistory: an array of string boards, containing previous board positions
    '   - moveKey: a key identifying types of moves as follows:
    '      0 - normal move
    '      1 - capture
    '      2 - en passant capture
    '      3 - pawn promotion
    '      4 - kingside castling
    '      5 - queenside castling
    '      6 - check
    '      7 - checkmate
    '   - moveDict: a dictionary with the form (coords, <array of moveKeys>), used to show possible moves 
    '   - line
    '   - gameStatus
    '      0 - normal
    '      1 - checkmate
    '      2 - stalemate
    '      3 - insufficient material
    '      4 - win on time
    '      5 - resignation

    '   explain basics of how algorithms work (insufficient material especially)
    '   timer delay when opening new game


    ' functions todo:
    '   save game to file
    '   load game from file


    Public Structure ChessClock
        Public totalTime As TimeSpan
        Public timeLeft As TimeSpan
        Public interval As TimeSpan
        Public increment As TimeSpan
        Public timer As Timer
    End Structure

    Public Structure Game
        Public board As Char(,)
        Public history As String()
        Public boardHistory As String()
        Public whiteTime As ChessClock
        Public blackTime As ChessClock
        Public whiteToMove As Boolean
    End Structure

    Public Structure Move
        Public gameState As Game
        Public startCoords As Integer()
        Public destinationCoords As Integer()
        Public moveKeys As Integer()
        Public promotion As Char
    End Structure

    ' line 1: boardhistory (stringboards seperated by commas)
    ' line 2: history (SANMoves seperated by commas)
    ' line 3: whiteToMove (0 is False, 1 is True)
    ' line 4: whiteTime (totalTime, timeleft, interval, increment)
    ' line 5: blacktime (totalTime, timeleft, interval, increment)

    ' given a path, creates or overwrites a file on the path
    Private Sub createOrOverwriteFile(ByVal filePath As String)
        Dim file As System.IO.FileStream
        file = System.IO.File.Create(filePath)
        file.Close()
    End Sub

    ' given a chessclock, returns a string representation of it EXPLAIN
    Private Function chessClockToString(ByVal clock As ChessClock) As String
        Dim totalTimeTicks As String
        Dim timeLeftTicks As String
        Dim intervalTicks As String
        Dim incrementTicks As String

        totalTimeTicks = clock.totalTime.Ticks
        timeLeftTicks = clock.timeLeft.Ticks
        intervalTicks = clock.interval.Ticks
        incrementTicks = clock.increment.Ticks

        Dim chessClockString As String
        chessClockString = totalTimeTicks & "," & timeLeftTicks & "," & intervalTicks & "," & incrementTicks

        chessClockToString = chessClockString
    End Function

    ' given a chessclock string, return a chessclock
    Private Function stringToChessClock(ByVal s As String) As ChessClock
        ' split into string for easy manipulation
        Dim timeArray() As String
        timeArray = s.Split(",")

        Dim clock As ChessClock
        clock.totalTime = TimeSpan.FromTicks(timeArray(0))
        clock.timeLeft = TimeSpan.FromTicks(timeArray(1))
        clock.interval = TimeSpan.FromTicks(timeArray(2))
        clock.increment = TimeSpan.FromTicks(timeArray(3))
        clock.timer = New Timer With {.Interval = clock.interval.TotalMilliseconds}

        stringToChessClock = clock
    End Function

    ' load game from file (returns game object, timers need to be initialised, for more info see documentation on initGame)
    Public Function loadGame(ByVal filePath As String, Optional ByVal setUpTimers As Boolean = True) As Game
        ' initialise vars that store data from file
        Dim boardHistoryString As String
        Dim historyString As String
        Dim whiteToMoveChar As Char
        Dim whiteTimeString As String
        Dim blackTimeString As String

        ' open file (assumes filePath is valid)
        FileSystem.FileOpen(1, filePath, OpenMode.Input)

        ' collect raw data from file
        boardHistoryString = FileSystem.LineInput(1)
        historyString = FileSystem.LineInput(1)
        whiteToMoveChar = FileSystem.LineInput(1)
        whiteTimeString = FileSystem.LineInput(1)
        blackTimeString = FileSystem.LineInput(1)

        ' close file
        FileSystem.FileClose(1)

        ' parse data and put into new game
        Dim newGame As Game
        newGame.boardHistory = boardHistoryString.Split(",")
        newGame.board = boardFromString(newGame.boardHistory(newGame.boardHistory.Length - 1))
        newGame.history = historyString.Split(",")
        If whiteToMoveChar = "1" Then
            newGame.whiteToMove = True
        Else
            newGame.whiteToMove = False
        End If
        newGame.whiteTime = stringToChessClock(whiteTimeString)
        newGame.blackTime = stringToChessClock(blackTimeString)

        ' set correct timer running
        If setUpTimers Then
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
        End If

        loadGame = newGame
    End Function

    ' validates checkmate file (returns true if valid, false if not)
    Public Function isValidCheckmateFile(ByVal filePath As String) As Boolean
        Dim isValidFile As Boolean
        Try
            loadGame(filePath)
            isValidFile = True
        Catch ex As Exception
            isValidFile = False
        End Try
        FileSystem.FileClose()
        isValidCheckmateFile = isValidFile
    End Function

    ' writes game to file, given file path (creates file if not there and adds .checkmate extension)
    Public Sub saveGame(ByVal game As Game, ByVal filePath As String, Optional ByVal addCheckmateExtension As Boolean = True)
        ' create file if it doesn't exist, overwrite it if it does
        If addCheckmateExtension Then
            filePath = filePath & ".checkmate"
        End If

        createOrOverwriteFile(filePath)

        ' collect data about game to be written 
        Dim boardHistoryString As String
        Dim historyString As String
        Dim whiteToMoveChar As Char
        Dim whiteTimeString As String
        Dim blackTimeString As String

        boardHistoryString = String.Join(",", game.boardHistory)
        historyString = String.Join(",", game.history)
        If game.whiteToMove Then
            whiteToMoveChar = "1"
        Else
            whiteToMoveChar = "0"
        End If
        whiteTimeString = chessClockToString(game.whiteTime)
        blackTimeString = chessClockToString(game.blackTime)

        ' write data to file
        Dim fileWriter As New System.IO.StreamWriter(filePath)

        fileWriter.WriteLine(boardHistoryString)
        fileWriter.WriteLine(historyString)
        fileWriter.WriteLine(whiteToMoveChar)
        fileWriter.WriteLine(whiteTimeString)
        fileWriter.WriteLine(blackTimeString)

        ' close file
        fileWriter.Close()
    End Sub

    ' returns a board made from a string board
    Public Function boardFromString(ByVal s As String) As Char(,)

        Dim board(7, 7) As Char
        Dim index = 0
        For y = 0 To 7
            For x = 0 To 7
                board(x, y) = s(index)
                index = index + 1
            Next
        Next
        boardFromString = board
    End Function

    ' returns a string board made from a board
    Public Function boardAsString(ByVal b As Char(,)) As String

        Dim s As String = ""
        For y = 0 To 7
            For x = 0 To 7
                s = s + b(x, y)
            Next
        Next
        boardAsString = s
    End Function

    ' returns a SAN made from coords
    Public Function coordstoSAN(ByVal coords As Integer()) As String
        coordstoSAN = Chr(coords(0) + 97) & coords(1) + 1
    End Function

    ' given a valid start coords and dest coords and a game, return an int array with matching moveKeys
    Public Function getMoveKeys(ByVal startCoords As Integer(), ByVal destCoords As Integer(), ByVal game As Game) As Integer()
        Dim moveDict As New Dictionary(Of Integer(), Integer())
        moveDict = chess.validMoves(game, startCoords)
        Dim moveKeys() As Integer
        moveKeys = {}
        For Each keyValuePair In moveDict
            If keyValuePair.Key(0) = destCoords(0) And keyValuePair.Key(1) = destCoords(1) Then
                moveKeys = keyValuePair.Value
            End If
        Next
        getMoveKeys = moveKeys
    End Function

    ' given a game and a side to check, returns true if checkmate, false if else
    Public Function isCheckmate(ByVal game As Game, ByVal checkWhiteSide As Boolean) As Boolean
        ' check if king is in check first
        ' get all valid move for side to check (into a line)
        ' go through all moves and check whether any result in the king not in check

        Dim isKingInCheckmate As Boolean
        isKingInCheckmate = True

        Dim kingChar As Char
        If checkWhiteSide Then
            kingChar = "K"
        Else
            kingChar = "k"
        End If

        Dim square As Char
        Dim squareIsUpper As Boolean

        Dim line(,) As Integer
        line = initLine()

        Dim moveDict As New Dictionary(Of Integer(), Integer())
        moveDict = initMoveDict()

        ' if king in check currently
        If isPieceBeingAttacked(findCoordsOfPieceOnBoard(kingChar, game.board), game.board) Then
            ' add all pieces from side to check to line
            For x = 0 To 7
                For y = 0 To 7
                    square = game.board(x, y)
                    squareIsUpper = Char.IsUpper(square)
                    If square <> " " Then
                        If checkWhiteSide Then
                            If squareIsUpper Then
                                line = addToLine(line, {x, y})
                            End If
                        Else
                            If Not squareIsUpper Then
                                line = addToLine(line, {x, y})
                            End If
                        End If
                    End If
                Next
            Next

            ' go through line and do all valid moves for piece
            Dim tempPieceCoords() As Integer
            Dim tempPiece As Char
            Dim tempBoard(,) As Char
            Dim kingCoords() As Integer

            Dim move As Move
            move.gameState = game

            If checkWhiteSide Then
                move.promotion = "Q"
            Else
                move.promotion = "q"
            End If

            For row = 0 To line.GetLength(0) - 1
                tempPiece = game.board(line(row, 0), line(row, 1))
                tempPieceCoords = {line(row, 0), line(row, 1)}
                moveDict = validMoves(game, tempPieceCoords, True)

                For Each keyValuePair In moveDict
                    move.startCoords = tempPieceCoords
                    move.destinationCoords = keyValuePair.Key
                    move.moveKeys = keyValuePair.Value

                    tempBoard = moveOnBoard(move)

                    If checkWhiteSide Then
                        kingCoords = findCoordsOfPieceOnBoard("K", tempBoard)
                    Else
                        kingCoords = findCoordsOfPieceOnBoard("k", tempBoard)
                    End If

                    If Not isPieceBeingAttacked(kingCoords, tempBoard) Then
                        isKingInCheckmate = False
                    End If
                Next
            Next

        Else
            isKingInCheckmate = False
        End If

        isCheckmate = isKingInCheckmate
    End Function

    ' given a game and a side to check, returns true if stalemate
    Public Function isStalemate(ByVal game As Game, ByVal checkWhiteSide As Boolean) As Boolean
        Dim isPositionStalemate As Boolean
        isPositionStalemate = True

        Dim kingChar As Char
        If checkWhiteSide Then
            kingChar = "K"
        Else
            kingChar = "k"
        End If

        Dim square As Char
        Dim squareIsUpper As Boolean

        Dim possibleMOves As Dictionary(Of Integer(), Integer())
        possibleMOves = initMoveDict()

        ' if king is not in check
        If Not isPieceBeingAttacked(findCoordsOfPieceOnBoard(kingChar, game.board), game.board) Then
            For x = 0 To 7
                For y = 0 To 7
                    square = game.board(x, y)
                    squareIsUpper = Char.IsUpper(square)
                    If square <> " " Then
                        If checkWhiteSide Then
                            If squareIsUpper Then
                                If validMoves(game, {x, y}).Count <> 0 Then
                                    isPositionStalemate = False
                                End If
                            End If
                        Else
                            If Not squareIsUpper Then
                                If validMoves(game, {x, y}).Count <> 0 Then
                                    isPositionStalemate = False
                                End If
                            End If
                        End If

                    End If
                Next
            Next
        Else
            isPositionStalemate = False
        End If
        isStalemate = isPositionStalemate
    End Function

    ' given a board, returns true if there is insufficient material
    Public Function isInsufficientMaterial(ByVal board As Char(,)) As Boolean
        Dim insufficient As Boolean
        insufficient = False

        Dim whitePieces() As String
        Dim blackPieces() As String
        whitePieces = {}
        blackPieces = {}

        Dim square As Char
        Dim squareIsUpper As Boolean
        For x = 0 To 7
            For y = 0 To 7
                square = board(x, y)
                squareIsUpper = Char.IsUpper(square)
                If square <> " " Then
                    If squareIsUpper Then
                        whitePieces = updateHistory(square, whitePieces)
                    Else
                        blackPieces = updateHistory(square, blackPieces)
                    End If
                End If
            Next
        Next

        ' king v king
        ' king + bishop v king
        ' king + knight v king

        ' king v king
        If whitePieces.Length = 1 And blackPieces.Length = 1 Then
            insufficient = True
        Else
            ' king + bishop v king
            ' king + knight v king
            If whitePieces.Length = 2 And blackPieces.Length = 1 Then
                If whitePieces.Contains("B") Or whitePieces.Contains("N") Then
                    insufficient = True
                End If
            Else
                If whitePieces.Length = 1 And blackPieces.Length = 2 Then
                    If blackPieces.Contains("b") Or blackPieces.Contains("n") Then
                        insufficient = True
                    End If
                End If
            End If
        End If
        isInsufficientMaterial = insufficient
    End Function

    ' add move to history or boardHistory (returns new array), redim if necessary
    Public Function updateHistory(ByVal s As String, ByVal history() As String) As String()
        If history.Length > 0 Then
            If String.IsNullOrEmpty(history(history.Length - 1)) Then
                ' if history array has more space
                Dim firstNullIndex As Integer

                For x = 0 To history.Length - 1
                    If String.IsNullOrEmpty(history(x)) Then
                        firstNullIndex = x
                        Exit For
                    End If
                Next

                history(firstNullIndex) = s
                updateHistory = history
            Else
                ' if history array has no more space
                ' redim array and recurse once
                ReDim Preserve history(history.Length)
                updateHistory = updateHistory(s, history)
            End If
        Else
            updateHistory = {s}
        End If
    End Function

    ' reurn game status
    Public Function gameStatus(ByVal game As Game, ByVal checkWhiteSide As Boolean) As Integer
        Dim status As Integer
        status = 0

        If isCheckmate(game, checkWhiteSide) Then
            status = 1
        End If
        If isStalemate(game, checkWhiteSide) Then
            status = 2
        End If
        If isInsufficientMaterial(game.board) Then
            status = 3
        End If
        If game.blackTime.timeLeft < New TimeSpan(0, 0, 0) Or game.whiteTime.timeLeft < New TimeSpan(0, 0, 0) Then
            status = 4
        End If

        gameStatus = status
    End Function

    ' return SANmove given a Move object
    Public Function getSANMove(ByVal move As Move) As String
        Dim movingPieceFile = coordstoSAN(move.startCoords)(0)
        Dim destinationCoordsSAN = coordstoSAN(move.destinationCoords)
        Dim movingPiece = Char.ToUpper(move.gameState.board(move.startCoords(0), move.startCoords(1)))
        Dim SANMove = destinationCoordsSAN

        If movingPiece <> "P" Then
            SANMove = movingPiece & destinationCoordsSAN
        End If

        For x = 0 To move.moveKeys.Length - 1
            ' take care of special moves
            Select Case move.moveKeys(x)
                Case 1
                    If movingPiece <> "P" Then
                        SANMove = movingPiece & "x" & destinationCoordsSAN
                    Else
                        SANMove = movingPieceFile & "x" & destinationCoordsSAN
                    End If

                Case 2
                    SANMove = movingPieceFile & "x" & destinationCoordsSAN & " e.p"

                Case 3
                    SANMove = SANMove & "=" & move.promotion
                    If move.moveKeys.Length = 1 Then
                        SANMove = destinationCoordsSAN & "=" & move.promotion
                    End If

                Case 4
                    SANMove = "0-0"

                Case 5
                    SANMove = "0-0-0"

                Case 6
                    SANMove = SANMove + "+"

                Case 7
                    SANMove = SANMove + "#"
            End Select
        Next

        getSANMove = SANMove
    End Function

    ' initialise and return a ChessClock structure given time constraints
    Public Function initChessClock(ByVal totalTime As Integer, ByVal interval As Integer, ByVal increment As Integer) As ChessClock
        Dim clock As ChessClock
        clock.totalTime = New TimeSpan(0, totalTime, 0)
        clock.timeLeft = New TimeSpan(0, totalTime, 0)
        clock.interval = TimeSpan.FromMilliseconds(interval)
        clock.increment = New TimeSpan(0, 0, increment)
        clock.timer = New Timer With {.Interval = interval}
        initChessClock = clock
    End Function

    ' initialise new Game structure, given a stringboard and time constraints
    ' does not add handlers to the timer objects, this needs to be done manually
    ' note: totaltime is amount of minutes, interval is milliseconds and increment in seconds
    ' example:
    '     1. create a game structure that can be globally accessed, for this example it will be called newGame
    '     2. init this game structure, e.g. 
    '          newGame = chess.initGame(My.Resources.txt_chessboardStartingPosition, 100)
    '     3. add handlers. to do this, reference each timer and set the handler to the clockTick function.
    '        clocktick requires 2 arguments, a byref to a chessclock object it will modify, and the addressof a sub that will be called every clocktick (set by you)
    '        the second argument can be used to point to a sub that updates the visuals of the clocks for example
    '        e.g.
    '          AddHandler newGame.whiteTime.timer.Tick, Sub() chess.clockTick(newGame.whiteTime, AddressOf updateWhiteTime)
    '          AddHandler newGame.blackTime.timer.Tick, Sub() chess.clockTick(newGame.blackTime, AddressOf updateBlackTime
    Public Function initGame(ByVal stringBoard As String, ByVal totalTimeMinutes As Integer, Optional ByVal intervalMilliseconds As Integer = 100, Optional ByVal incrementSeconds As Integer = 0)
        Dim whiteTime As ChessClock
        whiteTime = initChessClock(totalTimeMinutes, intervalMilliseconds, incrementSeconds)

        Dim blackTime As ChessClock
        blackTime = initChessClock(totalTimeMinutes, intervalMilliseconds, incrementSeconds)

        Dim newGame As Game
        newGame.board = boardFromString(stringBoard)
        newGame.history = {}
        newGame.boardHistory = {stringBoard}
        newGame.whiteTime = whiteTime
        newGame.blackTime = blackTime
        newGame.whiteToMove = True

        initGame = newGame
    End Function

    ' returns board after move given a Move structure
    Public Function moveOnBoard(ByVal move As Move) As Char(,)
        Dim newBoard(7, 7) As Char
        Array.Copy(move.gameState.board, newBoard, move.gameState.board.Length)

        Dim piece As Char
        piece = newBoard(move.startCoords(0), move.startCoords(1))

        Dim pieceIsWhite As Boolean
        pieceIsWhite = Char.IsUpper(piece)

        piece = Char.ToUpper(piece)
        ' {2, 3} {1, 2}
        For x = 0 To move.moveKeys.Length - 1
            Select Case move.moveKeys(x)
                Case 0 To 1
                    ' normal moves and captures
                    newBoard(move.destinationCoords(0), move.destinationCoords(1)) = newBoard(move.startCoords(0), move.startCoords(1))
                    newBoard(move.startCoords(0), move.startCoords(1)) = " "
                Case 2
                    ' en passant
                    newBoard(move.destinationCoords(0), move.destinationCoords(1)) = newBoard(move.startCoords(0), move.startCoords(1))
                    newBoard(move.startCoords(0), move.startCoords(1)) = " "
                    If pieceIsWhite Then
                        newBoard(move.destinationCoords(0), move.destinationCoords(1) - 1) = " "
                    Else
                        newBoard(move.destinationCoords(0), move.destinationCoords(1) + 1) = " "
                    End If
                Case 3
                    ' pawn promotion
                    newBoard(move.destinationCoords(0), move.destinationCoords(1)) = move.promotion
                    newBoard(move.startCoords(0), move.startCoords(1)) = " "
                Case 4
                    ' kingside castling
                    If pieceIsWhite Then
                        newBoard(4, 0) = " "
                        newBoard(6, 0) = "K"
                        newBoard(7, 0) = " "
                        newBoard(5, 0) = "R"
                    Else
                        newBoard(4, 7) = " "
                        newBoard(6, 7) = "k"
                        newBoard(7, 7) = " "
                        newBoard(5, 7) = "r"
                    End If
                Case 5
                    ' queenside castling
                    If pieceIsWhite Then
                        newBoard(4, 0) = " "
                        newBoard(2, 0) = "K"
                        newBoard(0, 0) = " "
                        newBoard(3, 0) = "R"
                    Else
                        newBoard(4, 7) = " "
                        newBoard(2, 7) = "k"
                        newBoard(0, 7) = " "
                        newBoard(3, 7) = "r"
                    End If
            End Select
        Next

        moveOnBoard = newBoard
    End Function

    ' given a Game structure, returns a Game structure with sides switched
    ' this updates the whiteToMove variable and toggles the timers, and handles setting the timer on the first turn
    Public Function switchSideGame(ByVal game As Game)
        Dim gameSideSwitched As Game
        gameSideSwitched = game

        ' if first turn
        If gameSideSwitched.boardHistory.Length = 2 Then
            enableClock(gameSideSwitched.whiteTime, False)
            enableClock(gameSideSwitched.blackTime, True)
        Else
            toggleClock(gameSideSwitched.whiteTime)
            toggleClock(gameSideSwitched.blackTime)
        End If
        switchSideGame = gameSideSwitched
    End Function

    ' given a Move structure detailing wanted move, returns a Game structure with move completed
    ' this updates the board, history, boardHistory and whiteToMove variables
    Public Function doMove(ByVal move As Move) As Game
        Dim gameAfterMove As Game
        gameAfterMove.history = updateHistory(getSANMove(move), move.gameState.history)
        gameAfterMove.board = moveOnBoard(move)
        gameAfterMove.boardHistory = updateHistory(boardAsString(gameAfterMove.board), move.gameState.boardHistory)
        gameAfterMove.whiteTime = move.gameState.whiteTime
        gameAfterMove.blackTime = move.gameState.blackTime
        gameAfterMove.whiteToMove = Not move.gameState.whiteToMove

        doMove = gameAfterMove
    End Function

    ' resizes and adds coords to a line
    Private Function addToLine(ByVal line As Integer(,), ByVal coords As Integer()) As Integer(,)
        If line(0, 0) <> -1 And line(0, 1) <> -1 Then
            Dim newLine(line.GetLength(0), line.GetLength(1) - 1) As Integer
            For x = 0 To line.GetLength(0) - 1
                For y = 0 To line.GetLength(1) - 1
                    newLine(x, y) = line(x, y)
                Next
            Next
            newLine(newLine.GetLength(0) - 1, 0) = coords(0)
            newLine(newLine.GetLength(0) - 1, 1) = coords(1)
            addToLine = newLine
        Else
            line(0, 0) = coords(0)
            line(0, 1) = coords(1)
            addToLine = line
        End If
    End Function

    ' returns true if coordinates are in bounds, false if not
    Private Function coordsInBounds(ByVal coords As Integer()) As Boolean
        Dim inBounds = False
        If coords(0) >= 0 And coords(0) <= 7 And coords(1) >= 0 And coords(1) <= 7 Then
            inBounds = True
        End If
        coordsInBounds = inBounds
    End Function

    ' initialises an empty line
    Private Function initLine() As Integer(,)
        Dim line(,) As Integer
        ReDim line(0, 1)
        line(0, 0) = -1
        line(0, 1) = -1
        initLine = line
    End Function

    ' given a board, a line and a piece works out valid moves
    ' if return captures is true, return captures as well (won't return for knights or pawns or special captures.
    Private Function validMovesFromLine(ByVal line As Integer(,), ByVal board As Char(,), Optional ByVal pieceIsWhite As Boolean = True, Optional ByVal returnCaptures As Boolean = False, Optional ByVal allowKingCapture As Boolean = False) As Integer(,)
        ' init new line for storing valid moves
        Dim validMoves(,) As Integer
        validMoves = initLine()

        Dim captures(,) As Integer
        captures = initLine()

        Dim tempPieceIsWhite As Boolean
        Dim tempPieceCoords() As Integer
        Dim tempPiece As Char

        For row = 0 To line.GetLength(0) - 1
            tempPiece = board(line(row, 0), line(row, 1))
            tempPieceCoords = {line(row, 0), line(row, 1)}
            tempPieceIsWhite = Char.IsUpper(tempPiece)

            If tempPiece = " " Then
                validMoves = addToLine(validMoves, tempPieceCoords)
            Else
                If allowKingCapture Then
                    If returnCaptures Then
                        If (Not pieceIsWhite) = tempPieceIsWhite Then
                            captures = addToLine(captures, tempPieceCoords)
                        End If
                    End If
                Else
                    If returnCaptures And Char.ToUpper(tempPiece) <> "K" Then
                        If (Not pieceIsWhite) = tempPieceIsWhite Then
                            captures = addToLine(captures, tempPieceCoords)
                        End If
                    End If
                End If
                Exit For
            End If
        Next

        If returnCaptures Then
            validMovesFromLine = captures
        Else
            validMovesFromLine = validMoves
        End If
    End Function

    ' line to moveDict
    Private Function lineToMoveDict(ByVal line As Integer(,), Optional ByVal defaultMoveKey As Integer = 0) As Dictionary(Of Integer(), Integer())
        Dim moveDict As New Dictionary(Of Integer(), Integer())
        For row = 0 To line.GetLength(0) - 1
            moveDict.Add({line(row, 0), line(row, 1)}, {defaultMoveKey})
        Next

        lineToMoveDict = moveDict
    End Function

    ' returns a moveDict of moves for pieces where the moveKey is either 0 or 1
    Private Function genPossibleLine(ByVal piece As Char, ByVal pieceIsWhite As Boolean, ByVal coords As Integer(), ByVal lineNumber As Integer) As Integer(,)
        ' init line to store moves
        Dim line(,) As Integer
        line = initLine()
        Select Case piece
            Case "P"
                If pieceIsWhite Then
                    ' normal moves (pawn promotions are not normal moves)
                    Dim oneMoveAhead = {coords(0), coords(1) + 1}
                    If coordsInBounds(oneMoveAhead) And oneMoveAhead(1) <> 7 Then
                        line = addToLine(line, oneMoveAhead)
                    End If
                    ' check if on starting rank for double move
                    If coords(1) = 1 Then
                        line = addToLine(line, {coords(0), coords(1) + 2})
                    End If
                Else
                    ' normal moves (pawn promotions are not normal moves)
                    Dim oneMoveAhead = {coords(0), coords(1) - 1}
                    If coordsInBounds(oneMoveAhead) And oneMoveAhead(1) <> 0 Then
                        line = addToLine(line, oneMoveAhead)
                    End If
                    ' check if on starting rank for double move
                    If coords(1) = 6 Then
                        line = addToLine(line, {coords(0), coords(1) - 2})
                    End If
                End If
            Case "N"
                Dim possibleCase() As Integer
                Select Case lineNumber
                    Case 0
                        possibleCase = {coords(0) + 1, coords(1) + 2}
                    Case 1
                        possibleCase = {coords(0) + 2, coords(1) + 1}
                    Case 2
                        possibleCase = {coords(0) + 2, coords(1) - 1}
                    Case 3
                        possibleCase = {coords(0) + 1, coords(1) - 2}
                    Case 4
                        possibleCase = {coords(0) - 1, coords(1) - 2}
                    Case 5
                        possibleCase = {coords(0) - 2, coords(1) - 1}
                    Case 6
                        possibleCase = {coords(0) - 2, coords(1) + 1}
                    Case 7
                        possibleCase = {coords(0) - 1, coords(1) + 2}
                    Case Else
                        possibleCase = {-1, -1}
                End Select
                If coordsInBounds(possibleCase) Then
                    line = addToLine(line, possibleCase)
                End If
            Case "B"
                Dim lastCoord As Integer()
                lastCoord = coords
                For x = 0 To 7
                    Select Case lineNumber
                        Case 0
                            lastCoord = {lastCoord(0) + 1, lastCoord(1) + 1}
                        Case 1
                            lastCoord = {lastCoord(0) + 1, lastCoord(1) - 1}
                        Case 2
                            lastCoord = {lastCoord(0) - 1, lastCoord(1) - 1}
                        Case 3
                            lastCoord = {lastCoord(0) - 1, lastCoord(1) + 1}
                    End Select
                    If coordsInBounds(lastCoord) Then
                        line = addToLine(line, lastCoord)
                    End If
                Next
            Case "R"
                Dim lastCoord As Integer()
                lastCoord = coords
                For x = 0 To 7
                    Select Case lineNumber
                        Case 0
                            lastCoord = {lastCoord(0), lastCoord(1) + 1}
                        Case 1
                            lastCoord = {lastCoord(0) + 1, lastCoord(1)}
                        Case 2
                            lastCoord = {lastCoord(0), lastCoord(1) - 1}
                        Case 3
                            lastCoord = {lastCoord(0) - 1, lastCoord(1)}
                    End Select
                    If coordsInBounds(lastCoord) Then
                        line = addToLine(line, lastCoord)
                    End If
                Next
            Case "K"
                Dim possibleCase() As Integer
                Select Case lineNumber
                    Case 0
                        possibleCase = {coords(0), coords(1) + 1}
                    Case 1
                        possibleCase = {coords(0) + 1, coords(1) + 1}
                    Case 2
                        possibleCase = {coords(0) + 1, coords(1)}
                    Case 3
                        possibleCase = {coords(0) + 1, coords(1) - 1}
                    Case 4
                        possibleCase = {coords(0), coords(1) - 1}
                    Case 5
                        possibleCase = {coords(0) - 1, coords(1) - 1}
                    Case 6
                        possibleCase = {coords(0) - 1, coords(1)}
                    Case 7
                        possibleCase = {coords(0) - 1, coords(1) + 1}
                    Case Else
                        possibleCase = {-1, -1}
                End Select
                If coordsInBounds(possibleCase) Then
                    line = addToLine(line, possibleCase)
                End If
        End Select
        genPossibleLine = line
    End Function

    ' checks if line is empty
    Private Function isLineEmpty(ByVal line As Integer(,)) As Boolean
        If line(0, 0) = -1 And line(0, 1) = -1 Then
            isLineEmpty = True
        Else
            isLineEmpty = False
        End If
    End Function

    ' filter empty values in moveDict
    Private Function filterEmptyValues(ByVal moveDict As Dictionary(Of Integer(), Integer())) As Dictionary(Of Integer(), Integer())
        Dim newDict As New Dictionary(Of Integer(), Integer())
        For Each keyValuePair In moveDict
            If Not (keyValuePair.Key(0) = -1 And keyValuePair.Key(1) = -1) Then
                newDict.Add(keyValuePair.Key, keyValuePair.Value)
            End If
        Next
        filterEmptyValues = newDict
    End Function

    ' given a line of possible moves, returns a moveDict with the valid moves inside
    Private Function validateLine(ByVal line As Integer(,), ByVal board As Char(,), Optional ByVal moveKey As Integer = 0) As Dictionary(Of Integer(), Integer())
        Dim validNormalMoves(,) As Integer
        Dim validMoveDict As New Dictionary(Of Integer(), Integer())
        validMoveDict = initMoveDict()

        If Not isLineEmpty(line) Then
            validNormalMoves = validMovesFromLine(line, board)
            validMoveDict = filterEmptyValues(lineToMoveDict(validNormalMoves, moveKey))
        End If

        validateLine = validMoveDict
    End Function

    ' add moveDict to other moveDict
    Private Function addMoveDicts(ByVal moveDict As Dictionary(Of Integer(), Integer()), ByVal moveDict2 As Dictionary(Of Integer(), Integer())) As Dictionary(Of Integer(), Integer())
        addMoveDicts = moveDict.Union(moveDict2).ToDictionary(Function(d) d.Key, Function(d) d.Value)
    End Function

    ' get the amount of lines each piece has
    Private Function getNumberOfLines(ByVal piece As Char) As Integer
        Dim numberOfLines As Integer
        numberOfLines = 3
        Select Case piece
            Case "P"
                numberOfLines = 0
            Case "N"
                numberOfLines = 7
            Case "K"
                numberOfLines = 7
        End Select
        getNumberOfLines = numberOfLines
    End Function

    ' wrapper function that returns complete dictionary of all normal moves
    Private Function getNormalMoves(ByVal piece As Char, ByVal pieceIsWhite As Boolean, ByVal coords As Integer(), ByVal board As Char(,), Optional ByVal moveKey As Integer = 0) As Dictionary(Of Integer(), Integer())
        ' moveDict
        Dim moveDict As New Dictionary(Of Integer(), Integer())
        moveDict = initMoveDict()

        ' possible normal moves (movekey 0)
        Dim possibleNormalOnBlankBoard(,) As Integer
        If piece <> "Q" Then
            For x = 0 To getNumberOfLines(piece)
                possibleNormalOnBlankBoard = genPossibleLine(piece, pieceIsWhite, coords, x)
                moveDict = addMoveDicts(moveDict, validateLine(possibleNormalOnBlankBoard, board, moveKey))
            Next
        Else
            For x = 0 To 3
                possibleNormalOnBlankBoard = genPossibleLine("B", pieceIsWhite, coords, x)
                moveDict = addMoveDicts(moveDict, validateLine(possibleNormalOnBlankBoard, board, moveKey))
                possibleNormalOnBlankBoard = genPossibleLine("R", pieceIsWhite, coords, x)
                moveDict = addMoveDicts(moveDict, validateLine(possibleNormalOnBlankBoard, board, moveKey))
            Next
        End If
        getNormalMoves = moveDict
    End Function

    ' wrapper function that returns complete dictionary of all captures
    Private Function getCaptures(ByVal piece As Char, ByVal pieceIsWhite As Boolean, ByVal coords As Integer(), ByVal board As Char(,), Optional ByVal moveKey As Integer = 1, Optional ByVal allowKingCapture As Boolean = False) As Dictionary(Of Integer(), Integer())
        ' moveDict
        Dim moveDict As New Dictionary(Of Integer(), Integer())
        moveDict = initMoveDict()

        Dim possibleNormalOnBlankBoard(,) As Integer
        Dim captureOnLine(,) As Integer

        Select Case piece
            Case "Q"
                For x = 0 To 3
                    possibleNormalOnBlankBoard = genPossibleLine("B", pieceIsWhite, coords, x)
                    If Not isLineEmpty(possibleNormalOnBlankBoard) Then
                        If allowKingCapture Then
                            captureOnLine = validMovesFromLine(possibleNormalOnBlankBoard, board, pieceIsWhite, True, True)
                        Else
                            captureOnLine = validMovesFromLine(possibleNormalOnBlankBoard, board, pieceIsWhite, True)
                        End If
                        moveDict = addMoveDicts(moveDict, filterEmptyValues(lineToMoveDict(captureOnLine, moveKey)))
                    End If
                    possibleNormalOnBlankBoard = genPossibleLine("R", pieceIsWhite, coords, x)
                    If Not isLineEmpty(possibleNormalOnBlankBoard) Then
                        If allowKingCapture Then
                            captureOnLine = validMovesFromLine(possibleNormalOnBlankBoard, board, pieceIsWhite, True, True)
                        Else
                            captureOnLine = validMovesFromLine(possibleNormalOnBlankBoard, board, pieceIsWhite, True)
                        End If
                        moveDict = addMoveDicts(moveDict, filterEmptyValues(lineToMoveDict(captureOnLine, moveKey)))
                    End If
                Next
            Case "P"
                If pieceIsWhite Then
                    Dim rightCaptureCoords = {coords(0) + 1, coords(1) + 1}
                    Dim leftCaptureCoords = {coords(0) - 1, coords(1) + 1}

                    If coordsInBounds(rightCaptureCoords) Then
                        Dim rightCapturePiece = board(coords(0) + 1, coords(1) + 1)
                        If rightCapturePiece <> " " Then
                            Dim rightCapturePieceIsWhite = Char.IsUpper(rightCapturePiece)
                            If allowKingCapture Then
                                If (Not pieceIsWhite) = rightCapturePieceIsWhite Then
                                    moveDict.Add(rightCaptureCoords, {1})
                                End If
                            Else
                                If (Not pieceIsWhite) = rightCapturePieceIsWhite And Char.ToUpper(rightCapturePiece) <> "K" Then
                                    If rightCaptureCoords(1) = 7 Then
                                        moveDict.Add(rightCaptureCoords, {1, 3})
                                    Else
                                        moveDict.Add(rightCaptureCoords, {1})
                                    End If
                                End If
                            End If
                        End If
                    End If

                    If coordsInBounds(leftCaptureCoords) Then
                        Dim leftCapturePiece = board(coords(0) - 1, coords(1) + 1)
                        If leftCapturePiece <> " " Then
                            Dim leftCapturePieceIsWhite = Char.IsUpper(leftCapturePiece)
                            If allowKingCapture Then
                                If (Not pieceIsWhite) = leftCapturePieceIsWhite Then
                                    moveDict.Add(leftCaptureCoords, {1})
                                End If
                            Else
                                If (Not pieceIsWhite) = leftCapturePieceIsWhite And Char.ToUpper(leftCapturePiece) <> "K" Then
                                    If leftCaptureCoords(1) = 7 Then
                                        moveDict.Add(leftCaptureCoords, {1, 3})
                                    Else
                                        moveDict.Add(leftCaptureCoords, {1})
                                    End If
                                End If
                            End If
                        End If
                    End If
                Else
                    Dim rightCaptureCoords = {coords(0) + 1, coords(1) - 1}
                    Dim leftCaptureCoords = {coords(0) - 1, coords(1) - 1}

                    If coordsInBounds(rightCaptureCoords) Then
                        Dim rightCapturePiece = board(coords(0) + 1, coords(1) - 1)
                        If rightCapturePiece <> " " Then
                            Dim rightCapturePieceIsWhite = Char.IsUpper(rightCapturePiece)
                            If allowKingCapture Then
                                If (Not pieceIsWhite) = rightCapturePieceIsWhite Then
                                    moveDict.Add(rightCaptureCoords, {1})
                                End If
                            Else
                                If (Not pieceIsWhite) = rightCapturePieceIsWhite And Char.ToUpper(rightCapturePiece) <> "K" Then
                                    If rightCaptureCoords(1) = 0 Then
                                        moveDict.Add(rightCaptureCoords, {1, 3})
                                    Else
                                        moveDict.Add(rightCaptureCoords, {1})
                                    End If
                                End If
                            End If
                        End If
                    End If
                    If coordsInBounds(leftCaptureCoords) Then
                        Dim leftCapturePiece = board(coords(0) - 1, coords(1) - 1)
                        If leftCapturePiece <> " " Then
                            Dim leftCapturePieceIsWhite = Char.IsUpper(leftCapturePiece)
                            If allowKingCapture Then
                                If (Not pieceIsWhite) = leftCapturePieceIsWhite Then
                                    moveDict.Add(leftCaptureCoords, {1})
                                End If
                            Else
                                If (Not pieceIsWhite) = leftCapturePieceIsWhite And Char.ToUpper(leftCapturePiece) <> "K" Then
                                    If leftCaptureCoords(1) = 0 Then
                                        moveDict.Add(leftCaptureCoords, {1, 3})
                                    Else
                                        moveDict.Add(leftCaptureCoords, {1})
                                    End If

                                End If
                            End If

                        End If
                    End If
                End If
            Case Else
                For x = 0 To getNumberOfLines(piece)
                    possibleNormalOnBlankBoard = genPossibleLine(piece, pieceIsWhite, coords, x)

                    If Not isLineEmpty(possibleNormalOnBlankBoard) Then
                        If allowKingCapture Then
                            captureOnLine = validMovesFromLine(possibleNormalOnBlankBoard, board, pieceIsWhite, True, True)
                        Else
                            captureOnLine = validMovesFromLine(possibleNormalOnBlankBoard, board, pieceIsWhite, True)
                        End If
                        moveDict = addMoveDicts(moveDict, filterEmptyValues(lineToMoveDict(captureOnLine, moveKey)))
                    End If
                Next
        End Select
        getCaptures = moveDict
    End Function

    ' init moveDict
    Private Function initMoveDict()
        Dim moveDict As New Dictionary(Of Integer(), Integer())
        moveDict.Add({-1, -1}, {-1})
        moveDict.Clear()
        initMoveDict = moveDict
    End Function

    ' return possible en passant
    Private Function possibleEnPassant(ByVal pieceIsWhite As Boolean, ByVal coords As Integer(), ByVal game As Game, Optional ByVal moveKey As Integer = 2) As Dictionary(Of Integer(), Integer())
        ' moveDict
        Dim moveDict As New Dictionary(Of Integer(), Integer())
        moveDict = initMoveDict()

        Dim possible() As Integer
        Dim lastMoveBoard As Char(,)

        If pieceIsWhite Then
            If coords(1) = 4 Then
                ' check right side
                possible = {coords(0) + 1, coords(1)}
                If coordsInBounds(possible) Then
                    ' check if positioning valid
                    If Not Char.IsUpper(game.board(coords(0) + 1, coords(1))) = pieceIsWhite And Char.ToUpper(game.board(coords(0) + 1, coords(1))) = "P" And game.board(possible(0), 6) = " " Then
                        lastMoveBoard = boardFromString(game.boardHistory(game.boardHistory.Length - 3))
                        If lastMoveBoard(possible(0), 6) = game.board(coords(0) + 1, coords(1)) And lastMoveBoard(coords(0) + 1, coords(1)) = " " Then
                            moveDict.Add({possible(0), possible(1) + 1}, {moveKey})
                        End If
                    End If
                End If

                ' check left side
                possible = {coords(0) - 1, coords(1)}
                If coordsInBounds(possible) Then
                    If Not Char.IsUpper(game.board(coords(0) - 1, coords(1))) = pieceIsWhite And Char.ToUpper(game.board(coords(0) - 1, coords(1))) = "P" And game.board(possible(0), 6) = " " Then
                        lastMoveBoard = boardFromString(game.boardHistory(game.boardHistory.Length - 3))
                        If lastMoveBoard(possible(0), 6) = game.board(coords(0) - 1, coords(1)) And lastMoveBoard(coords(0) - 1, coords(1)) = " " Then
                            moveDict.Add({possible(0), possible(1) + 1}, {moveKey})
                        End If
                    End If
                End If
            End If

        Else
            If coords(1) = 3 Then
                ' check right side
                possible = {coords(0) + 1, coords(1)}
                If coordsInBounds(possible) Then
                    ' check if positioning valid
                    If Not Char.IsUpper(game.board(coords(0) + 1, coords(1))) = pieceIsWhite And Char.ToUpper(game.board(coords(0) + 1, coords(1))) = "P" And game.board(possible(0), 1) = " " Then
                        lastMoveBoard = boardFromString(game.boardHistory(game.boardHistory.Length - 3))
                        If lastMoveBoard(possible(0), 1) = game.board(coords(0) + 1, coords(1)) And lastMoveBoard(coords(0) + 1, coords(1)) = " " Then
                            moveDict.Add({possible(0), possible(1) - 1}, {moveKey})
                        End If
                    End If
                End If

                ' check left side
                possible = {coords(0) - 1, coords(1)}
                If coordsInBounds(possible) Then
                    If Not Char.IsUpper(game.board(coords(0) - 1, coords(1))) = pieceIsWhite And Char.ToUpper(game.board(coords(0) - 1, coords(1))) = "P" And game.board(possible(0), 1) = " " Then
                        lastMoveBoard = boardFromString(game.boardHistory(game.boardHistory.Length - 3))
                        If lastMoveBoard(possible(0), 1) = game.board(coords(0) - 1, coords(1)) And lastMoveBoard(coords(0) - 1, coords(1)) = " " Then
                            moveDict.Add({possible(0), possible(1) - 1}, {moveKey})
                        End If
                    End If
                End If
            End If
        End If
        possibleEnPassant = moveDict
    End Function

    ' return possible pawn promotion (doesn't take into consideration captures on last rank, which is dealt with getCaptures)
    Private Function possiblePromotions(ByVal pieceIsWhite As Boolean, ByVal coords As Integer(), ByVal board As Char(,), Optional ByVal moveKey As Integer = 3) As Dictionary(Of Integer(), Integer())
        ' init moveDict
        Dim moveDict As New Dictionary(Of Integer(), Integer())
        moveDict = initMoveDict()

        If pieceIsWhite Then
            If coords(1) = 6 And board(coords(0), coords(1) + 1) = " " Then
                moveDict.Add({coords(0), coords(1) + 1}, {moveKey})
            End If
        Else
            If coords(1) = 1 And board(coords(0), coords(1) - 1) = " " Then
                moveDict.Add({coords(0), coords(1) - 1}, {moveKey})
            End If
        End If

        possiblePromotions = moveDict
    End Function

    ' returns an array of pieces that have been in a specified coords
    Private Function pieceInCoordinateThroughGame(ByVal coords As Integer(), ByVal game As Game) As Char()
        Dim pieces() As Char
        ReDim pieces(game.boardHistory.Length - 1)

        Dim currentGameBoardState(,) As Char

        For x = 0 To game.boardHistory.Length - 1
            currentGameBoardState = boardFromString(game.boardHistory(x))
            pieces(x) = currentGameBoardState(coords(0), coords(1))
        Next

        pieceInCoordinateThroughGame = pieces
    End Function

    ' checks if all items in a char array are a specific char
    Private Function isCharArrayValid(ByVal checkChar As Char, ByVal charArray As Char()) As Boolean
        Dim isValid As Boolean
        isValid = True
        For x = 0 To charArray.Length - 1
            If charArray(x) <> checkChar Then
                isValid = False
                Exit For
            End If
        Next
        isCharArrayValid = isValid
    End Function

    ' given the coords of a piece, checks if it is being attacked (used to find if king in check)
    Private Function isPieceBeingAttacked(ByVal coords As Integer(), ByVal board As Char(,)) As Boolean
        Dim pieceBeingAttacked As Boolean
        pieceBeingAttacked = False

        Dim pieceIsWhite As Boolean
        pieceIsWhite = Char.IsUpper(board(coords(0), coords(1)))

        Dim square As Char
        Dim pieceOnSquareIsWhite As Boolean
        Dim captures As New Dictionary(Of Integer(), Integer())

        For x = 0 To 7
            For y = 0 To 7
                square = board(x, y)
                pieceOnSquareIsWhite = Char.IsUpper(square)
                If square <> " " Then
                    If Not pieceOnSquareIsWhite = pieceIsWhite Then
                        captures = getCaptures(Char.ToUpper(square), pieceOnSquareIsWhite, {x, y}, board, 1, True)
                        For Each keyValuePair In captures
                            If keyValuePair.Key(0) = coords(0) And keyValuePair.Key(1) = coords(1) Then
                                pieceBeingAttacked = True
                            End If
                        Next
                    End If
                End If
            Next
        Next

        isPieceBeingAttacked = pieceBeingAttacked
    End Function

    ' given a line of moves, checks if the king would be in check if moved through them (used in castling)
    Private Function kingInCheckThroughMoves(ByVal line As Integer(,), ByVal game As Game) As Boolean
        Dim tempBoard(,) As Char
        Dim inCheck = False

        For x = 0 To line.GetLength(0) - 1
            tempBoard = boardFromString(boardAsString(game.board)) 'WRITE ABOUT THIS
            If x <> 0 Then
                tempBoard(line(x, 0), line(x, 1)) = tempBoard(line(0, 0), line(0, 1))
                tempBoard(line(0, 0), line(0, 1)) = " "
            End If

            If isPieceBeingAttacked({line(x, 0), line(x, 1)}, tempBoard) Then
                inCheck = True
            End If
        Next

        kingInCheckThroughMoves = inCheck
    End Function

    ' return possible castles
    Private Function possibleCastles(ByVal kingIsWhite As Boolean, ByVal game As Game) As Dictionary(Of Integer(), Integer())
        ' check if either piece has moved throughout the game
        Dim kingCoords As Char()
        Dim kingSideRookCoords As Char()
        Dim queenSideRookCoords As Char()
        If kingIsWhite Then
            kingCoords = pieceInCoordinateThroughGame({4, 0}, game)
            kingSideRookCoords = pieceInCoordinateThroughGame({7, 0}, game)
            queenSideRookCoords = pieceInCoordinateThroughGame({0, 0}, game)
        Else
            kingCoords = pieceInCoordinateThroughGame({4, 7}, game)
            kingSideRookCoords = pieceInCoordinateThroughGame({7, 7}, game)
            queenSideRookCoords = pieceInCoordinateThroughGame({0, 7}, game)
        End If

        Dim kingHasMoved As Boolean
        Dim queenSideRookHasMoved As Boolean
        Dim kingSideRookHasMoved As Boolean
        If kingIsWhite Then
            kingHasMoved = Not isCharArrayValid("K", kingCoords)
            queenSideRookHasMoved = Not isCharArrayValid("R", queenSideRookCoords)
            kingSideRookHasMoved = Not isCharArrayValid("R", kingSideRookCoords)
        Else
            kingHasMoved = Not isCharArrayValid("k", kingCoords)
            queenSideRookHasMoved = Not isCharArrayValid("r", queenSideRookCoords)
            kingSideRookHasMoved = Not isCharArrayValid("r", kingSideRookCoords)
        End If

        ' check if there is space between the king and the rook
        Dim queenSideSpaceEmpty As Boolean
        Dim kingSideSpaceEmpty As Boolean

        If kingIsWhite Then
            kingSideSpaceEmpty = game.board(5, 0) = " " And game.board(6, 0) = " "
            queenSideSpaceEmpty = game.board(3, 0) = " " And game.board(2, 0) = " " And game.board(1, 0) = " "
        Else
            kingSideSpaceEmpty = game.board(5, 7) = " " And game.board(6, 7) = " "
            queenSideSpaceEmpty = game.board(3, 7) = " " And game.board(2, 7) = " " And game.board(1, 7) = " "
        End If

        ' check if king in check or will move through check
        Dim queenSideSquares(,) As Integer = {{}}
        Dim kingSideSquares(,) As Integer = {{}}
        If kingIsWhite Then
            If queenSideSpaceEmpty Then
                queenSideSquares = {{4, 0}, {3, 0}, {2, 0}}
            End If
            If kingSideSpaceEmpty Then
                kingSideSquares = {{4, 0}, {5, 0}, {6, 0}}
            End If
        Else
            If queenSideSpaceEmpty Then
                queenSideSquares = {{4, 7}, {3, 7}, {2, 7}}
            End If
            If kingSideSpaceEmpty Then
                kingSideSquares = {{4, 7}, {5, 7}, {6, 7}}
            End If
        End If

        Dim kingSideCastlePossible As Boolean
        kingSideCastlePossible = False
        Dim queenSideCastlePossible As Boolean
        queenSideCastlePossible = False

        ' if the king hasn't moved
        If Not kingHasMoved Then
            ' and there is empty space between the king and the rook and the rook hasn't moved
            If kingSideSpaceEmpty And Not kingSideRookHasMoved Then
                ' and if the king is not in check through the castle, castling is possible
                kingSideCastlePossible = Not kingInCheckThroughMoves(kingSideSquares, game)
            End If
            If queenSideSpaceEmpty And Not queenSideRookHasMoved Then
                queenSideCastlePossible = Not kingInCheckThroughMoves(queenSideSquares, game)
            End If
        End If

        ' put results in moveDict
        Dim moveDict As New Dictionary(Of Integer(), Integer())
        moveDict = initMoveDict()

        If kingSideCastlePossible Then
            If kingIsWhite Then
                moveDict.Add({6, 0}, {4})
            Else
                moveDict.Add({6, 7}, {4})
            End If
        End If
        If queenSideCastlePossible Then
            If kingIsWhite Then
                moveDict.Add({2, 0}, {5})
            Else
                moveDict.Add({2, 7}, {5})
            End If
        End If

        possibleCastles = moveDict
    End Function

    ' find the coordinates of the last occurunce of a specific piece on a board (used to find the king)
    Private Function findCoordsOfPieceOnBoard(ByVal piece As Char, ByVal board As Char(,)) As Integer()
        Dim coords() As Integer
        coords = {-1, -1}
        For x = 0 To 7
            For y = 0 To 7
                If board(x, y) = piece Then
                    coords(0) = x
                    coords(1) = y
                End If
            Next
        Next
        findCoordsOfPieceOnBoard = coords
    End Function

    ' given a moveDict and a board, returns a moveDict with all the moves that leave the king in check removed
    Private Function removeMovesThatResultInCheck(ByVal whiteSideTurn As Boolean, ByVal startCoords As Integer(), ByVal moveDict As Dictionary(Of Integer(), Integer()), ByVal game As Game) As Dictionary(Of Integer(), Integer())
        Dim newMoveDict As Dictionary(Of Integer(), Integer())
        newMoveDict = initMoveDict()

        ' how this works - 
        '  - create a move object
        '  - do move on temporary board    
        '  - find king on temp board
        ' - if king not being attacked, add move to new move dict

        Dim move As Move

        move.gameState = game
        move.startCoords = startCoords

        If whiteSideTurn Then
            move.promotion = "Q"
        Else
            move.promotion = "q"
        End If

        Dim tempBoard(,) As Char
        Dim kingCoords() As Integer

        For Each keyValuePair In moveDict
            move.destinationCoords = keyValuePair.Key
            move.moveKeys = keyValuePair.Value
            tempBoard = moveOnBoard(move)

            If whiteSideTurn Then
                kingCoords = findCoordsOfPieceOnBoard("K", tempBoard)
            Else
                kingCoords = findCoordsOfPieceOnBoard("k", tempBoard)
            End If

            If Not isPieceBeingAttacked(kingCoords, tempBoard) Then
                newMoveDict(keyValuePair.Key) = keyValuePair.Value
            End If
        Next

        removeMovesThatResultInCheck = newMoveDict
    End Function

    ' given a moveDict, append moveKey 6 to any moves that result in check for other side
    Private Function possibleCheckMoves(ByVal startCoords As Integer(), ByVal moveDict As Dictionary(Of Integer(), Integer()), ByVal game As Game) As Dictionary(Of Integer(), Integer())
        Dim newMoveDict As Dictionary(Of Integer(), Integer())
        newMoveDict = initMoveDict()

        Dim pieceIsWhite As Boolean
        pieceIsWhite = Char.IsUpper(game.board(startCoords(0), startCoords(1)))

        Dim move As Move

        move.gameState = game
        move.startCoords = startCoords

        If pieceIsWhite Then
            move.promotion = "Q"
        Else
            move.promotion = "q"
        End If

        Dim tempBoard(,) As Char
        Dim oppositeKingCoords() As Integer

        Dim tempArray() As Integer

        For Each keyValuePair In moveDict
            move.destinationCoords = keyValuePair.Key
            move.moveKeys = keyValuePair.Value
            tempBoard = moveOnBoard(move)

            If pieceIsWhite Then
                oppositeKingCoords = findCoordsOfPieceOnBoard("k", tempBoard)
            Else
                oppositeKingCoords = findCoordsOfPieceOnBoard("K", tempBoard)
            End If

            If isPieceBeingAttacked(oppositeKingCoords, tempBoard) Then
                ReDim tempArray(keyValuePair.Value.Length)
                Array.Copy(keyValuePair.Value, tempArray, keyValuePair.Value.Length)
                tempArray(tempArray.Length - 1) = 6
                newMoveDict(keyValuePair.Key) = tempArray
            Else
                newMoveDict(keyValuePair.Key) = keyValuePair.Value
            End If
        Next

        possibleCheckMoves = newMoveDict
    End Function

    ' given a moveDict, append moveKey 7 to any moves that result in a checkmate for other side
    Private Function possibleCheckmateMoves(ByVal startCoords As Integer(), ByVal moveDict As Dictionary(Of Integer(), Integer()), ByVal game As Game) As Dictionary(Of Integer(), Integer())
        Dim newMoveDict As Dictionary(Of Integer(), Integer())
        newMoveDict = initMoveDict()

        Dim pieceIsWhite As Boolean
        pieceIsWhite = Char.IsUpper(game.board(startCoords(0), startCoords(1)))

        Dim move As Move

        move.gameState = game
        move.startCoords = startCoords

        If pieceIsWhite Then
            move.promotion = "Q"
        Else
            move.promotion = "q"
        End If

        Dim tempArray() As Integer
        tempArray = {}
        Dim tempGame As Game

        For Each keyValuePair In moveDict
            move.destinationCoords = keyValuePair.Key
            move.moveKeys = keyValuePair.Value
            tempGame = doMove(move)


            If isCheckmate(tempGame, Not pieceIsWhite) Then
                ReDim tempArray(keyValuePair.Value.Length - 1)
                Array.Copy(keyValuePair.Value, tempArray, keyValuePair.Value.Length)
                tempArray(tempArray.Length - 1) = 7
                newMoveDict(keyValuePair.Key) = tempArray
            Else
                newMoveDict(keyValuePair.Key) = keyValuePair.Value
            End If
        Next

        possibleCheckmateMoves = newMoveDict
    End Function

    ' given a board and coords, return valid moves in dictionary (<valid moves coords> : <array of related movekeys>)
    Public Function validMoves(ByVal gameState As Game, ByVal coords As Integer(), Optional ByVal disableCheckingForCheck As Boolean = False) As Dictionary(Of Integer(), Integer())
        Dim piece As Char
        piece = gameState.board(coords(0), coords(1))

        Dim pieceIsWhite As Boolean
        pieceIsWhite = Char.IsUpper(piece)

        piece = Char.ToUpper(piece)

        ' init moveDict
        Dim moveDict As New Dictionary(Of Integer(), Integer())
        moveDict = initMoveDict()

        ' normal moves (moveKey 0)
        Dim normalMoves As New Dictionary(Of Integer(), Integer())
        normalMoves = getNormalMoves(piece, pieceIsWhite, coords, gameState.board)
        moveDict = addMoveDicts(moveDict, normalMoves)

        ' captures (moveKey 1, pawn captures add movekey 3 if capture is on last rank)
        Dim captures As New Dictionary(Of Integer(), Integer())
        captures = getCaptures(piece, pieceIsWhite, coords, gameState.board)
        moveDict = addMoveDicts(moveDict, captures)

        ' en passant (moveKey 2)
        Dim enPassant As New Dictionary(Of Integer(), Integer())
        If piece = "P" Then
            enPassant = possibleEnPassant(pieceIsWhite, coords, gameState)
            moveDict = addMoveDicts(moveDict, enPassant)
        End If

        ' pawn promotion (moveKey 3)
        Dim pawnPromotions As New Dictionary(Of Integer(), Integer())
        If piece = "P" Then
            pawnPromotions = possiblePromotions(pieceIsWhite, coords, gameState.board)
            moveDict = addMoveDicts(moveDict, pawnPromotions)
        End If

        ' castles (moveKey 4 and 5)
        Dim castles As New Dictionary(Of Integer(), Integer())
        If piece = "K" Then
            castles = possibleCastles(pieceIsWhite, gameState)
            moveDict = addMoveDicts(moveDict, castles)
        End If

        ' remove moves that result in check
        moveDict = removeMovesThatResultInCheck(pieceIsWhite, coords, moveDict, gameState)

        If Not disableCheckingForCheck Then
            ' moves that result in check for other side (moveKey 6)
            moveDict = possibleCheckMoves(coords, moveDict, gameState)

            ' moves that result in checkamte for other side (moveKey 7)
            moveDict = possibleCheckmateMoves(coords, moveDict, gameState)
        End If

        validMoves = moveDict
    End Function

    ' given a game structure return a game object taken a move back
    Public Function takebackMove(ByVal game As Game) As Game
        If game.boardHistory.Length > 1 Then
            Dim gameBeforeMove As Game

            ' update board
            gameBeforeMove.board = boardFromString(game.boardHistory(game.boardHistory.Length - 2))

            ' update history 
            Dim historyBeforeMove = game.history
            Array.Resize(historyBeforeMove, historyBeforeMove.Length - 1)
            gameBeforeMove.history = historyBeforeMove

            ' update boardHistory
            Dim boardHistoryBeforeMove = game.boardHistory
            Array.Resize(boardHistoryBeforeMove, boardHistoryBeforeMove.Length - 1)
            gameBeforeMove.boardHistory = boardHistoryBeforeMove

            ' copy time left for both sides
            gameBeforeMove.whiteTime = game.whiteTime
            gameBeforeMove.blackTime = game.blackTime

            ' update whiteToMove (switch sides)
            gameBeforeMove.whiteToMove = Not game.whiteToMove

            ' toggle clocks
            toggleClock(gameBeforeMove.whiteTime)
            toggleClock(gameBeforeMove.blackTime)

            takebackMove = gameBeforeMove
        Else
            takebackMove = game
        End If

    End Function

    ' DEBUG prints game info 
    Public Sub printGame(ByVal game As Game)
        Console.WriteLine("game board (as string): ")
        Console.WriteLine(boardAsString(game.board))
        Console.WriteLine("")
        Console.WriteLine("game history: ")
        For x = 0 To game.history.Length - 1
            Console.WriteLine(game.history(x))
        Next
        Console.WriteLine("")
        Console.WriteLine("game board history: ")
        For x = 0 To game.boardHistory.Length - 1
            Console.WriteLine(game.boardHistory(x))
        Next
        Console.WriteLine("")
        Console.WriteLine("white time: ")
        Console.WriteLine(game.whiteTime)
        Console.WriteLine("")
        Console.WriteLine("black time: ")
        Console.WriteLine(game.blackTime)
        Console.WriteLine("")
        Console.WriteLine("white to move: ")
        Console.WriteLine(game.whiteToMove)
    End Sub

    ' given a clock byref, will add increment onto clock
    Public Sub clockAddIncrement(ByRef clock As ChessClock)
        clock.timeLeft = clock.timeLeft.Add(clock.increment)
    End Sub

    ' given a clock byref, will modify it based on interval. also takes an additional sub that will be called
    Public Sub clockTick(ByRef clock As ChessClock, ByRef updateTimeSub As Action, ByRef endGameSub As Action(Of Boolean, Integer), ByVal whiteClock As Boolean)
        clock.timeLeft = clock.timeLeft.Subtract(clock.interval)
        If clock.timeLeft < New TimeSpan(0, 0, 0) Then
            Dim b = New TimeSpan(0, 0, 0) - TimeSpan.FromTicks(clock.interval.Ticks * 2)
            If clock.timeLeft > b Then
                endGameSub.Invoke(Not whiteClock, 4)
            End If
        Else
            updateTimeSub.Invoke()
        End If
    End Sub


    ' given a clock byref, will enable it if enable is true, will disable if false
    Public Sub enableClock(ByRef clock As ChessClock, ByVal enable As Boolean)
        clock.timer.Enabled = enable
    End Sub

    ' given a clock byref, toggles the enabled status of a clock
    Public Sub toggleClock(ByRef clock As ChessClock)
        clock.timer.Enabled = Not clock.timer.Enabled
    End Sub

    ' makes sure each millisecond has only one trailing zero
    Private Function formatMilliseconds(ByVal num As Integer) As String
        If num <> 0 Then
            Dim temp As String = num.ToString
            temp = temp.TrimEnd(New String({"0"}))
            formatMilliseconds = temp & "0"
        Else
            formatMilliseconds = num.ToString & "0"
        End If
    End Function

    ' convert TimeSpan to string and takes care of all possible time ranges
    Public Function timespanToString(ByVal time As TimeSpan) As String
        If time.TotalHours >= 1 Then
            timespanToString = String.Format("{0:00}:{1:00}:{2:00}", time.TotalHours, time.Minutes, time.Seconds)
        ElseIf time.Minutes >= 1 Then
            timespanToString = String.Format("{0:00}:{1:00}.{2:00}", time.Minutes, time.Seconds, formatMilliseconds(time.Milliseconds))
        Else
            timespanToString = String.Format("{0:00}.{1:00}", time.Seconds, formatMilliseconds(time.Milliseconds))
        End If
    End Function
End Module
