Module options
    ' will be set by user in either new game creation or load game process
    Public increment As Integer = 0
    Public totalTime As Integer = 0
    Public loadGame As Boolean = False
    Public loadGamePath As String
    Public whitePlayerName As String
    Public blackPlayerName As String

    ' default values
    Public interval As Integer = resources.defaultInterval
    Public pieceStyle As Integer = resources.defaultPieceStyle
    Public switchSideDelay As Integer = resources.defaultSwitchSideDelay
    Public boardSwitchingEnabled As Boolean = resources.defaultBoardSwitchingEnabled
    Public moveHighlightStyle As Integer = resources.defaultMoveHighlightStyle
    Public chessboardDarkSquareHex As String = resources.defaultChessboardDarkSquareHex
    Public chessboardLightSquareHex As String = resources.defaultChessboardLightSquareHex
    Public validMoveIndicatorHex As String = resources.defaultValidMoveIndicatorHex
    Public validDotCaptureIndicatorHex As String = resources.defaultValidDotCaptureIndicatorHex
    Public validSquareCaptureIndicatorHex As String = resources.defaultValidSquareCaptureIndicatorHex
    Public kingInCheckHex As String = resources.defaultKingInCheckHex
    Public selectedPieceHex As String = resources.defaultSelectedPieceHex

    ' used by program
    Public optionsOpenedFromMainMenu As Boolean = False
End Module