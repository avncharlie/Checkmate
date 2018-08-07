Module resources
    Public stringboardStartingPosition As String = "RNBQKBNRPPPPPPPP                                pppppppprnbqkbnr"
    Public timeControlInfoLabels() As String = {"Time controls restrict the total time each player has in a game. The time a player takes on their turn is deducted from the time they have remaining while the other players clock is paused. Once a player moves, their clock is paused while the other player takes their turn.", "As well as total time controls, there is also something known as 'increment'. Increment is a certain amount of time that is added onto each player's time once their turn is started. For example, if a game was started with a two minute time control and a fifteen second increment and the first player took five seconds to move, they would have two minutes - five seconds + fifteen seconds increment = two minutes and five seconds left on their clock.", "Time controls are expressed as x+y, where x is the total time in minutes for each player and y is the increment in seconds. E.g a '1 + 5' game would mean each player has one minute to play and five seconds increment."}

    Public startupFolder As String = Application.StartupPath & "\" & "resources\"
    Public settingsFile As String = startupFolder & "settings.txt"
    Public mainScreenChessboardPath As String = startupFolder & "mainScreenChessboard.png"
    Public timeControlInfoScreenExampePath As String = startupFolder & "timeControlInfoExample.png"
    Public settingsCogPath As String = startupFolder & "settings.png"

    Public defaultChessboardDarkSquareHex As String = "#54727C"
    Public defaultChessboardLightSquareHex As String = "#FFFFFF"
    Public defaultValidMoveIndicatorHex As String = "#BFADD8E6"
    Public defaultValidDotCaptureIndicatorHex As String = "#E6D14B4B"
    Public defaultValidSquareCaptureIndicatorHex As String = "#E6E6ADAD"
    Public defaultKingInCheckHex As String = "#E6D14B4B"
    Public defaultSelectedPieceHex As String = "#BF98FB98"

    Public defaultInterval As Integer = 100
    Public defaultBoardSwitchingEnabled As Boolean = True
    Public defaultPieceStyle As Integer = 0
    Public defaultSwitchSideDelay As Integer = 200
    Public defaultMoveHighlightStyle As Integer = 0


    Public Function chessPiecesFilePath(ByVal c As Char, Optional ByVal style As Integer = 0) As String
        Dim filename As String
        Dim foldername As String
        Select Case Char.ToUpper(c)
            Case "P"
                filename = "Pawn.png"
            Case "R"
                filename = "Rook.png"
            Case "N"
                filename = "Knight.png"
            Case "B"
                filename = "Bishop.png"
            Case "Q"
                filename = "Queen.png"
            Case Else
                filename = "King.png"
        End Select

        If Char.IsUpper(c) Then
            filename = "White" & filename
        Else
            filename = "Black" & filename
        End If

        Select Case style
            Case 0
                foldername = "alpha"
            Case 1
                foldername = "cburnett"
            Case 2
                foldername = "cheq"
            Case 3
                foldername = "leipzig"
            Case Else
                foldername = "merida"
        End Select

        filename = startupFolder & "pieces\" & foldername & "\" & filename

        If c = " " Then
            filename = startupFolder & "transparent.png"
        End If

        chessPiecesFilePath = filename
    End Function

    Public Function chessSoundsFilePath(ByVal n As Integer) As String
        chessSoundsFilePath = startupFolder & "sounds\" & "movePiece" & (n + 1) & ".wav"
    End Function

End Module
