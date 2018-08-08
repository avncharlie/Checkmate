Module resources
    ' this is a strinboard representation of the starting position of a new game. used when creating new games
    Public Const stringboardStartingPosition As String = "RNBQKBNRPPPPPPPP                                pppppppprnbqkbnr"

    ' these are the constants that are loaded into the labels in the frm_timeControlInfo form
    Public Const timeControlInfoLabel1 As String = "Time controls restrict the total time each player has in a game. The time a player takes on their turn is deducted from the time they have remaining while the other players clock is paused. Once a player moves, their clock is paused while the other player takes their turn."
    Public Const timeControlInfoLabel2 As String = "As well as total time controls, there is also something known as 'increment'. Increment is a certain amount of time that is added onto each player's time once their turn is started. For example, if a game was started with a two minute time control and a fifteen second increment and the first player took five seconds to move, they would have two minutes - five seconds + fifteen seconds increment = two minutes and five seconds left on their clock."
    Public Const timeControlInfoLabel3 As String = "Time controls are expressed as x+y, where x is the total time in minutes for each player and y is the increment in seconds. E.g a '1 + 5' game would mean each player has one minute to play and five seconds increment."

    ' these are various files that are relatively positioned from the startupFolder
    Public startupFolder As String = Application.StartupPath & "\" & "resources\"
    Public settingsFile As String = startupFolder & "settings.txt"
    Public highscoreFile As String = startupFolder & "highscores.txt"
    Public mainScreenChessboardPath As String = startupFolder & "mainScreenChessboard.png"
    Public timeControlInfoScreenExampePath As String = startupFolder & "timeControlInfoExample.png"
    Public settingsCogPath As String = startupFolder & "settings.png"

    ' this is the default colour scheme for the game
    Public Const defaultChessboardDarkSquareHex As String = "#54727C"
    Public Const defaultChessboardLightSquareHex As String = "#FFFFFF"
    Public Const defaultValidMoveIndicatorHex As String = "#BFADD8E6"
    Public Const defaultValidDotCaptureIndicatorHex As String = "#E6D14B4B"
    Public Const defaultValidSquareCaptureIndicatorHex As String = "#E6E6ADAD"
    Public Const defaultKingInCheckHex As String = "#E6D14B4B"
    Public Const defaultSelectedPieceHex As String = "#BF98FB98"

    ' these are the default game options
    Public Const defaultInterval As Integer = 100
    Public Const defaultBoardSwitchingEnabled As Boolean = True
    Public Const defaultPieceStyle As Integer = 0
    Public Const defaultSwitchSideDelay As Integer = 200
    Public Const defaultMoveHighlightStyle As Integer = 0

    ' this function takes a character as a char and a pieceStyle as an integer and returns the appropriate image path 
    Public Function chessPiecesFilePath(ByVal piece As Char, Optional ByVal style As Integer = 0) As String
        Dim filename As String
        Dim foldername As String
        Select Case Char.ToUpper(piece)
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

        If Char.IsUpper(piece) Then
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

        If piece = " " Then
            filename = startupFolder & "transparent.png"
        End If

        chessPiecesFilePath = filename
    End Function

    ' this function takes an integer and returns the corresponding sound file 
    Public Function chessSoundsFilePath(ByVal n As Integer) As String
        chessSoundsFilePath = startupFolder & "sounds\" & "movePiece" & (n + 1) & ".wav"
    End Function
End Module