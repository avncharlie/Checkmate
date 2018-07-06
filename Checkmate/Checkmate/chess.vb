Module chess

    ' definitions in documentation:
    '   - board: 2d char array of pieces
    '   - string board: char of length 64 holding all pieces on board
    '   - coords: 2 item integer array in form of [x, y]
    '   - SAN (Standard Algebraic Notation): char of length 2 in the form [file, rank] showing coordinates on board
    '   - SANMove: char of variable length that holds a valid chess move in valid SAN notation
    '   - history: an array of SANMoves
    '   - moveKey: a key identifying types of moves as follows:
    '      0 - none
    '      1 - capture
    '      2 - en passant capture
    '      3 - pawn promotion
    '      4 - kingside castling
    '      5 - queenside castling
    '      6 - check
    '      7 - checkmate
    '   - moveDict: a dictionary with the form (coords, <array of moveKeys>), used to show possible moves 

    ' TODO
    '   get rid of last 4 movekeys
    '   side indicator
    '   rollback history
    '       array storing board positions - controlled by user
    '       take last item from history - controlled by user
    '   move validation
    '       list valid moves in dictionary with moveKeys
    '   timers


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

    ' add move to history (returns new array), redim if necessary
    Function updateHistory(ByVal move As String, ByVal history() As String) As String()

        If String.IsNullOrEmpty(history(history.Length - 1)) Then
            ' if history array has more space
            Dim firstNullIndex As Integer

            For x = 0 To history.Length - 1
                If String.IsNullOrEmpty(history(x)) Then
                    firstNullIndex = x
                    Exit For
                End If
            Next

            history(firstNullIndex) = move
            updateHistory = history
        Else
            ' if history array has no more space
            ' redim array and recurse once
            ReDim Preserve history(history.Length)
            updateHistory = updateHistory(move, history)
        End If

    End Function

    ' return SANmove with two coordinates (before and after) of a piece, an optional moveKey with additions, an optional pawn promotion piece for pawn promotions and a board
    Function getSANMove(ByVal startCoords As Integer(), ByVal destinationCoords As Integer(), ByVal board(,) As Char, Optional ByVal moveKey As Integer() = Nothing, Optional ByVal promotion As Char = "Q") As String
        If moveKey Is Nothing Then
            moveKey = {0}
        End If

        Dim movingPieceFile = coordstoSAN(startCoords)(0)
        Dim destinationCoordsSAN = coordstoSAN(destinationCoords)
        Dim movingPiece = Char.ToUpper(board(startCoords(0), startCoords(1)))
        Dim move = destinationCoordsSAN

        If movingPiece <> "P" Then
            move = movingPiece & destinationCoordsSAN
        End If

        For x = 0 To moveKey.Length - 1
            ' take care of special moves
            Select Case moveKey(x)
                Case 1
                    If movingPiece <> "P" Then
                        move = movingPiece & "x" & destinationCoordsSAN
                    Else
                        move = movingPieceFile & "x" & destinationCoordsSAN
                    End If

                Case 2
                    move = getSANMove(startCoords, destinationCoords, board, {1}) & " e.p"

                Case 3
                    move = move & "=" & promotion
                    If moveKey.Length = 1 Then
                        move = destinationCoordsSAN & "=" & promotion
                    End If

                Case 4
                    move = "0-0"

                Case 5
                    move = "0-0-0"

                Case 6
                    move = move + "+"

                Case 7
                    move = move + "#"

                Case 8
                    move = "1 - 0"

                Case 9
                    move = "0 - 1"

                Case 10
                    move = "draw"

                Case 11
                    move = ""
            End Select
        Next

        getSANMove = move
    End Function

    Public Sub foo()
        Dim m = getSANMove({0, 1}, {0, 3}, boardFromString(Checkmate.My.Resources.txt_chessboardStartingPosition), {1, 3, 7})
        Dim dict As New Dictionary(Of Integer(), Integer())()
        dict.Add({10, 1}, {1, 3})
        dict.Add({9, 2}, {5, 2})
        dict.Add({8, 3}, {6, 3})
        dict.Add({7, 4}, {4, 1})

        For Each pair As KeyValuePair(Of Integer(), Integer()) In dict
            MsgBox(pair.Key(0) & "  -  " & pair.Value(1))
        Next
    End Sub

End Module
