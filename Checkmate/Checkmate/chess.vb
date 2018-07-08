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

    ' TODO
    '   ##################### means needs work or attention
    '   move validation
    '       list valid moves in dictionary with moveKeys
    '   timers

    Structure ChessClock
        Public totalTime As Double
        Public timeLeft As Double
        Public timer As Timer
    End Structure

    Structure Game
        Public board As Char(,)
        Public history As String()
        Public boardHistory As String()
        Public whiteTime As ChessClock
        Public blackTime As ChessClock
        Public whiteToMove As Boolean
    End Structure

    Structure Move
        Public gameState As Game
        Public startCoords As Integer()
        Public destinationCoords As Integer()
        Public moveKeys As Integer()
        Public promotion As Char
    End Structure


    ' returns a board made from a string board
    Function boardFromString(ByVal s As String) As Char(,)

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
    Function boardAsString(ByVal b As Char(,)) As String

        Dim s As String = ""
        For y = 0 To 7
            For x = 0 To 7
                s = s + b(x, y)
            Next
        Next
        boardAsString = s
    End Function

    ' returns a SAN made from coords
    Function coordstoSAN(ByVal coords As Integer()) As String
        coordstoSAN = Chr(coords(0) + 97) & coords(1) + 1
    End Function

    ' add move to history or boardHistory (returns new array), redim if necessary
    Function updateHistory(ByVal s As String, ByVal history() As String) As String()
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

    ' return SANmove given a Move object
    Function getSANMove(ByVal move As Move) As String
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
                    SANMove = movingPiece & "x" & destinationCoordsSAN & " e.p"

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

                Case 8
                    SANMove = "1 - 0"

                Case 9
                    SANMove = "0 - 1"

                Case 10
                    SANMove = "draw"

                Case 11
                    SANMove = ""
            End Select
        Next

        getSANMove = SANMove
    End Function

    ' initialise new Game object, given a stringboard and time constraints
    Function initGame(ByVal stringBoard As String, ByVal totalTime As Double, ByVal whiteHandler As EventHandler, ByVal blackHandler As EventHandler, Optional ByVal interval As Integer = 100)
        Dim whiteTime As ChessClock
        whiteTime.totalTime = totalTime
        whiteTime.timeLeft = totalTime
        whiteTime.timer = New Timer With {.Interval = interval}
        AddHandler whiteTime.timer.Tick, whiteHandler

        Dim blackTime As ChessClock
        blackTime.totalTime = totalTime
        blackTime.timeLeft = totalTime
        blackTime.timer = New Timer With {.Interval = interval}
        AddHandler blackTime.timer.Tick, blackHandler

        Dim game As Game
        game.board = boardFromString(stringBoard)
        game.history = {}
        game.boardHistory = {stringBoard}
        game.whiteTime = whiteTime
        game.blackTime = blackTime
        game.whiteToMove = True

        initGame = game
    End Function

    ' returns board after move given a Move object #####################
    Function moveOnBoard(ByVal move As Move) As Char(,)
        Dim newBoard(7, 7) As Char
        newBoard = move.gameState.board
        newBoard(move.destinationCoords(0), move.destinationCoords(1)) = newBoard(move.startCoords(0), move.startCoords(1))
        newBoard(move.startCoords(0), move.startCoords(1)) = " "

        moveOnBoard = newBoard
    End Function

    ' given a Move object detailing wanted move, returns a Game object with move completed
    ' this updates the board, history, boardHistory and whiteToMove variables
    Function doMove(ByVal move As Move) As Game
        Dim gameAfterMove As Game
        gameAfterMove.board = moveOnBoard(move)
        gameAfterMove.history = updateHistory(getSANMove(move), move.gameState.history)
        gameAfterMove.boardHistory = updateHistory(boardAsString(gameAfterMove.board), move.gameState.boardHistory)
        gameAfterMove.whiteTime = move.gameState.whiteTime
        gameAfterMove.blackTime = move.gameState.blackTime
        gameAfterMove.whiteToMove = Not move.gameState.whiteToMove

        doMove = gameAfterMove
    End Function

    ' given a game object return a game object taken a move back
    Function takebackMove(ByVal game As Game) As Game
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

        takebackMove = gameBeforeMove
    End Function

    ' DEBUG prints game info 
    Sub printGame(ByVal game As Game)
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



    Sub whitetest()
        Console.WriteLine("white")
    End Sub

    Sub blacktest()
        Console.WriteLine("black")
    End Sub

    ' DEBUG tester    
    Public Sub foo()
        ' DICTIONARY EXAMPLE
        'Dim m = getSANMove({0, 1}, {0, 3}, boardFromString(Checkmate.My.Resources.txt_chessboardStartingPosition), {1, 3, 7})
        'Dim dict As New Dictionary(Of Integer(), Integer())()
        'dict.Add({10, 1}, {1, 3})
        'dict.Add({9, 2}, {5, 2})
        'dict.Add({8, 3}, {6, 3})
        'dict.Add({7, 4}, {4, 1})

        'For Each pair As KeyValuePair(Of Integer(), Integer()) In dict
        '    MsgBox(pair.Key(0) & "  -  " & pair.Value(1))
        'Next

        ' TAKEBACK MOVE EXAMPLE
        'Dim game As Game
        'game = initGame(My.Resources.txt_chessboardStartingPosition, 10, AddressOf whitetest, AddressOf blacktest)
        'Console.WriteLine("ORIGINAL GAME:")
        'printGame(game)

        'Dim move As Move
        'move.gameState = game
        'move.startCoords = {0, 1}
        'move.destinationCoords = {0, 3}
        'move.moveKeys = {0}
        'move.promotion = "Q"

        'game = doMove(move)
        'Console.WriteLine("")
        'Console.WriteLine("GAME AFTER ONE MOVE (A4):")
        'printGame(game)

        'game = takebackMove(game)
        'Console.WriteLine("")
        'Console.WriteLine("GAME TAKEN BACK ONE MOVE:")
        'printGame(game)

        Dim game As Game
        game = initGame(My.Resources.txt_chessboardStartingPosition, 10, New EventHandler(AddressOf whitetest), New EventHandler(AddressOf blacktest))
        game.whiteTime.timer.Enabled = True
    End Sub
End Module
