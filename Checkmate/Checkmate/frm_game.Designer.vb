<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_game
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_game))
        Me.lbl_whiteTimeHeader = New System.Windows.Forms.Label()
        Me.lbl_blackTimeHeader = New System.Windows.Forms.Label()
        Me.lbl_whiteTimeCounter = New System.Windows.Forms.Label()
        Me.lbl_blackTimeCounter = New System.Windows.Forms.Label()
        Me.lbl_moveIndicator = New System.Windows.Forms.Label()
        Me.btn_takeBack = New System.Windows.Forms.Button()
        Me.lbl_movesHeader = New System.Windows.Forms.Label()
        Me.btn_resign = New System.Windows.Forms.Button()
        Me.ms_menu = New System.Windows.Forms.MenuStrip()
        Me.tsmi_file = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_about = New System.Windows.Forms.ToolStripMenuItem()
        Me.tss_FileAboutSave = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmi_saveGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.tss_fileSaveOptions = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmi_optionsFromFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.tss_fileOptionsExit = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmi_exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_game = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_takeBack = New System.Windows.Forms.ToolStripMenuItem()
        Me.tss_gameTakebackResign = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmi_resign = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_mainMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.tss_gameMainmenuOptions = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmi_optionsFromGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_view = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_pieceStyle = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_pieceStyle1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_pieceStyle2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_pieceStyle3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_pieceStyle4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_pieceStyle5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_moveHighlighting = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_dots = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_squares = New System.Windows.Forms.ToolStripMenuItem()
        Me.tss_viewMoveOptions = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmi_optionsFromView = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlp_mainContainer = New System.Windows.Forms.TableLayoutPanel()
        Me.tlp_sidebarContainer = New System.Windows.Forms.TableLayoutPanel()
        Me.tlp_mainSidebarControls = New System.Windows.Forms.TableLayoutPanel()
        Me.lv_moves = New System.Windows.Forms.ListView()
        Me.ch_hiddenColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_white = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ch_black = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tlp_resignAndOptions = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_options = New System.Windows.Forms.Button()
        Me.p_chessboardContainerContainer = New System.Windows.Forms.Panel()
        Me.p_chessboardContainer = New System.Windows.Forms.Panel()
        Me.p_startGame = New System.Windows.Forms.Panel()
        Me.lbl_startGameDialog = New System.Windows.Forms.Label()
        Me.btn_startGame = New System.Windows.Forms.Button()
        Me.p_endGame = New System.Windows.Forms.Panel()
        Me.lbl_endGameDialog = New System.Windows.Forms.Label()
        Me.btn_endGameMainMenu = New System.Windows.Forms.Button()
        Me.btn_endGameDialogClose = New System.Windows.Forms.Button()
        Me.p_enterNames = New System.Windows.Forms.Panel()
        Me.btn_confirmPlayerName = New System.Windows.Forms.Button()
        Me.tb_blackPlayerName = New System.Windows.Forms.TextBox()
        Me.tb_whitePlayerName = New System.Windows.Forms.TextBox()
        Me.lbl_blackPlayerHeader = New System.Windows.Forms.Label()
        Me.lbl_whitePlayerName = New System.Windows.Forms.Label()
        Me.lbl_enterNamesHeader = New System.Windows.Forms.Label()
        Me.p_choosePawnPromotionPiece = New System.Windows.Forms.Panel()
        Me.pb_pawnPromotionRook = New System.Windows.Forms.PictureBox()
        Me.pb_pawnPromotionQueen = New System.Windows.Forms.PictureBox()
        Me.pb_pawnPromotionBishop = New System.Windows.Forms.PictureBox()
        Me.pb_pawnPromotionKnight = New System.Windows.Forms.PictureBox()
        Me.lbl_pawnPromotion = New System.Windows.Forms.Label()
        Me.pb_chessboard = New System.Windows.Forms.PictureBox()
        Me.ms_menu.SuspendLayout()
        Me.tlp_mainContainer.SuspendLayout()
        Me.tlp_sidebarContainer.SuspendLayout()
        Me.tlp_mainSidebarControls.SuspendLayout()
        Me.tlp_resignAndOptions.SuspendLayout()
        Me.p_chessboardContainerContainer.SuspendLayout()
        Me.p_chessboardContainer.SuspendLayout()
        Me.p_startGame.SuspendLayout()
        Me.p_endGame.SuspendLayout()
        Me.p_enterNames.SuspendLayout()
        Me.p_choosePawnPromotionPiece.SuspendLayout()
        CType(Me.pb_pawnPromotionRook, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_pawnPromotionQueen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_pawnPromotionBishop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_pawnPromotionKnight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_chessboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_whiteTimeHeader
        '
        Me.lbl_whiteTimeHeader.AutoSize = True
        Me.lbl_whiteTimeHeader.Font = New System.Drawing.Font("OCR A Extended", 12.0!)
        Me.lbl_whiteTimeHeader.Location = New System.Drawing.Point(3, 0)
        Me.lbl_whiteTimeHeader.Name = "lbl_whiteTimeHeader"
        Me.lbl_whiteTimeHeader.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.lbl_whiteTimeHeader.Size = New System.Drawing.Size(108, 22)
        Me.lbl_whiteTimeHeader.TabIndex = 1
        Me.lbl_whiteTimeHeader.Text = "WHITE TIME"
        '
        'lbl_blackTimeHeader
        '
        Me.lbl_blackTimeHeader.AutoSize = True
        Me.lbl_blackTimeHeader.Font = New System.Drawing.Font("OCR A Extended", 12.0!)
        Me.lbl_blackTimeHeader.Location = New System.Drawing.Point(3, 71)
        Me.lbl_blackTimeHeader.Name = "lbl_blackTimeHeader"
        Me.lbl_blackTimeHeader.Padding = New System.Windows.Forms.Padding(0, 12, 0, 5)
        Me.lbl_blackTimeHeader.Size = New System.Drawing.Size(108, 34)
        Me.lbl_blackTimeHeader.TabIndex = 2
        Me.lbl_blackTimeHeader.Text = "BLACK TIME"
        '
        'lbl_whiteTimeCounter
        '
        Me.lbl_whiteTimeCounter.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lbl_whiteTimeCounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_whiteTimeCounter.Font = New System.Drawing.Font("Maiandra GD", 16.0!)
        Me.lbl_whiteTimeCounter.Location = New System.Drawing.Point(3, 22)
        Me.lbl_whiteTimeCounter.Name = "lbl_whiteTimeCounter"
        Me.lbl_whiteTimeCounter.Size = New System.Drawing.Size(200, 49)
        Me.lbl_whiteTimeCounter.TabIndex = 3
        Me.lbl_whiteTimeCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_blackTimeCounter
        '
        Me.lbl_blackTimeCounter.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lbl_blackTimeCounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_blackTimeCounter.Font = New System.Drawing.Font("Maiandra GD", 16.0!)
        Me.lbl_blackTimeCounter.Location = New System.Drawing.Point(3, 105)
        Me.lbl_blackTimeCounter.Name = "lbl_blackTimeCounter"
        Me.lbl_blackTimeCounter.Size = New System.Drawing.Size(200, 49)
        Me.lbl_blackTimeCounter.TabIndex = 4
        Me.lbl_blackTimeCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_moveIndicator
        '
        Me.lbl_moveIndicator.BackColor = System.Drawing.SystemColors.Info
        Me.lbl_moveIndicator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_moveIndicator.Font = New System.Drawing.Font("OCR A Extended", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_moveIndicator.Location = New System.Drawing.Point(3, 167)
        Me.lbl_moveIndicator.Name = "lbl_moveIndicator"
        Me.lbl_moveIndicator.Size = New System.Drawing.Size(200, 39)
        Me.lbl_moveIndicator.TabIndex = 5
        Me.lbl_moveIndicator.Text = "White to move"
        Me.lbl_moveIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_takeBack
        '
        Me.btn_takeBack.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_takeBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_takeBack.Font = New System.Drawing.Font("OCR A Extended", 9.0!)
        Me.btn_takeBack.Location = New System.Drawing.Point(3, 238)
        Me.btn_takeBack.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.btn_takeBack.Name = "btn_takeBack"
        Me.btn_takeBack.Size = New System.Drawing.Size(200, 23)
        Me.btn_takeBack.TabIndex = 11
        Me.btn_takeBack.Text = "TAKE BACK"
        Me.btn_takeBack.UseVisualStyleBackColor = True
        '
        'lbl_movesHeader
        '
        Me.lbl_movesHeader.AutoSize = True
        Me.lbl_movesHeader.Font = New System.Drawing.Font("OCR A Extended", 12.0!)
        Me.lbl_movesHeader.Location = New System.Drawing.Point(3, 206)
        Me.lbl_movesHeader.Name = "lbl_movesHeader"
        Me.lbl_movesHeader.Padding = New System.Windows.Forms.Padding(0, 12, 0, 0)
        Me.lbl_movesHeader.Size = New System.Drawing.Size(58, 29)
        Me.lbl_movesHeader.TabIndex = 9
        Me.lbl_movesHeader.Text = "Moves"
        '
        'btn_resign
        '
        Me.btn_resign.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_resign.Location = New System.Drawing.Point(3, 3)
        Me.btn_resign.Name = "btn_resign"
        Me.btn_resign.Size = New System.Drawing.Size(97, 27)
        Me.btn_resign.TabIndex = 10
        Me.btn_resign.Text = "Resign"
        Me.btn_resign.UseVisualStyleBackColor = True
        '
        'ms_menu
        '
        Me.ms_menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_file, Me.tsmi_game, Me.tsmi_view})
        Me.ms_menu.Location = New System.Drawing.Point(0, 0)
        Me.ms_menu.Name = "ms_menu"
        Me.ms_menu.Size = New System.Drawing.Size(998, 24)
        Me.ms_menu.TabIndex = 13
        Me.ms_menu.Text = "MenuStrip1"
        '
        'tsmi_file
        '
        Me.tsmi_file.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_about, Me.tss_FileAboutSave, Me.tsmi_saveGame, Me.tss_fileSaveOptions, Me.tsmi_optionsFromFile, Me.tss_fileOptionsExit, Me.tsmi_exit})
        Me.tsmi_file.Name = "tsmi_file"
        Me.tsmi_file.Size = New System.Drawing.Size(37, 20)
        Me.tsmi_file.Text = "File"
        '
        'tsmi_about
        '
        Me.tsmi_about.Name = "tsmi_about"
        Me.tsmi_about.Size = New System.Drawing.Size(125, 22)
        Me.tsmi_about.Text = "About"
        '
        'tss_FileAboutSave
        '
        Me.tss_FileAboutSave.Name = "tss_FileAboutSave"
        Me.tss_FileAboutSave.Size = New System.Drawing.Size(122, 6)
        '
        'tsmi_saveGame
        '
        Me.tsmi_saveGame.Name = "tsmi_saveGame"
        Me.tsmi_saveGame.Size = New System.Drawing.Size(125, 22)
        Me.tsmi_saveGame.Text = "Save..."
        '
        'tss_fileSaveOptions
        '
        Me.tss_fileSaveOptions.Name = "tss_fileSaveOptions"
        Me.tss_fileSaveOptions.Size = New System.Drawing.Size(122, 6)
        '
        'tsmi_optionsFromFile
        '
        Me.tsmi_optionsFromFile.Name = "tsmi_optionsFromFile"
        Me.tsmi_optionsFromFile.Size = New System.Drawing.Size(125, 22)
        Me.tsmi_optionsFromFile.Text = "Options..."
        '
        'tss_fileOptionsExit
        '
        Me.tss_fileOptionsExit.Name = "tss_fileOptionsExit"
        Me.tss_fileOptionsExit.Size = New System.Drawing.Size(122, 6)
        '
        'tsmi_exit
        '
        Me.tsmi_exit.Name = "tsmi_exit"
        Me.tsmi_exit.Size = New System.Drawing.Size(125, 22)
        Me.tsmi_exit.Text = "Exit"
        '
        'tsmi_game
        '
        Me.tsmi_game.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_takeBack, Me.tss_gameTakebackResign, Me.tsmi_resign, Me.tsmi_mainMenu, Me.tss_gameMainmenuOptions, Me.tsmi_optionsFromGame})
        Me.tsmi_game.Name = "tsmi_game"
        Me.tsmi_game.Size = New System.Drawing.Size(50, 20)
        Me.tsmi_game.Text = "Game"
        '
        'tsmi_takeBack
        '
        Me.tsmi_takeBack.Name = "tsmi_takeBack"
        Me.tsmi_takeBack.Size = New System.Drawing.Size(144, 22)
        Me.tsmi_takeBack.Text = "Take back..."
        '
        'tss_gameTakebackResign
        '
        Me.tss_gameTakebackResign.Name = "tss_gameTakebackResign"
        Me.tss_gameTakebackResign.Size = New System.Drawing.Size(141, 6)
        '
        'tsmi_resign
        '
        Me.tsmi_resign.Name = "tsmi_resign"
        Me.tsmi_resign.Size = New System.Drawing.Size(144, 22)
        Me.tsmi_resign.Text = "Resign"
        '
        'tsmi_mainMenu
        '
        Me.tsmi_mainMenu.Name = "tsmi_mainMenu"
        Me.tsmi_mainMenu.Size = New System.Drawing.Size(144, 22)
        Me.tsmi_mainMenu.Text = "Main menu..."
        '
        'tss_gameMainmenuOptions
        '
        Me.tss_gameMainmenuOptions.Name = "tss_gameMainmenuOptions"
        Me.tss_gameMainmenuOptions.Size = New System.Drawing.Size(141, 6)
        '
        'tsmi_optionsFromGame
        '
        Me.tsmi_optionsFromGame.Name = "tsmi_optionsFromGame"
        Me.tsmi_optionsFromGame.Size = New System.Drawing.Size(144, 22)
        Me.tsmi_optionsFromGame.Text = "Options..."
        '
        'tsmi_view
        '
        Me.tsmi_view.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_pieceStyle, Me.tsmi_moveHighlighting, Me.tss_viewMoveOptions, Me.tsmi_optionsFromView})
        Me.tsmi_view.Name = "tsmi_view"
        Me.tsmi_view.Size = New System.Drawing.Size(44, 20)
        Me.tsmi_view.Text = "View"
        '
        'tsmi_pieceStyle
        '
        Me.tsmi_pieceStyle.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_pieceStyle1, Me.tsmi_pieceStyle2, Me.tsmi_pieceStyle3, Me.tsmi_pieceStyle4, Me.tsmi_pieceStyle5})
        Me.tsmi_pieceStyle.Name = "tsmi_pieceStyle"
        Me.tsmi_pieceStyle.Size = New System.Drawing.Size(199, 22)
        Me.tsmi_pieceStyle.Text = "Piece style"
        '
        'tsmi_pieceStyle1
        '
        Me.tsmi_pieceStyle1.Checked = True
        Me.tsmi_pieceStyle1.CheckOnClick = True
        Me.tsmi_pieceStyle1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmi_pieceStyle1.Name = "tsmi_pieceStyle1"
        Me.tsmi_pieceStyle1.Size = New System.Drawing.Size(119, 22)
        Me.tsmi_pieceStyle1.Text = "alpha"
        '
        'tsmi_pieceStyle2
        '
        Me.tsmi_pieceStyle2.CheckOnClick = True
        Me.tsmi_pieceStyle2.Name = "tsmi_pieceStyle2"
        Me.tsmi_pieceStyle2.Size = New System.Drawing.Size(119, 22)
        Me.tsmi_pieceStyle2.Text = "cburnett"
        '
        'tsmi_pieceStyle3
        '
        Me.tsmi_pieceStyle3.CheckOnClick = True
        Me.tsmi_pieceStyle3.Name = "tsmi_pieceStyle3"
        Me.tsmi_pieceStyle3.Size = New System.Drawing.Size(119, 22)
        Me.tsmi_pieceStyle3.Text = "cheq"
        '
        'tsmi_pieceStyle4
        '
        Me.tsmi_pieceStyle4.CheckOnClick = True
        Me.tsmi_pieceStyle4.Name = "tsmi_pieceStyle4"
        Me.tsmi_pieceStyle4.Size = New System.Drawing.Size(119, 22)
        Me.tsmi_pieceStyle4.Text = "leipzig"
        '
        'tsmi_pieceStyle5
        '
        Me.tsmi_pieceStyle5.CheckOnClick = True
        Me.tsmi_pieceStyle5.Name = "tsmi_pieceStyle5"
        Me.tsmi_pieceStyle5.Size = New System.Drawing.Size(119, 22)
        Me.tsmi_pieceStyle5.Text = "merida"
        '
        'tsmi_moveHighlighting
        '
        Me.tsmi_moveHighlighting.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_dots, Me.tsmi_squares})
        Me.tsmi_moveHighlighting.Name = "tsmi_moveHighlighting"
        Me.tsmi_moveHighlighting.Size = New System.Drawing.Size(199, 22)
        Me.tsmi_moveHighlighting.Text = "Move highlighting style"
        '
        'tsmi_dots
        '
        Me.tsmi_dots.Checked = True
        Me.tsmi_dots.CheckOnClick = True
        Me.tsmi_dots.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmi_dots.Name = "tsmi_dots"
        Me.tsmi_dots.Size = New System.Drawing.Size(115, 22)
        Me.tsmi_dots.Text = "Dots"
        '
        'tsmi_squares
        '
        Me.tsmi_squares.Name = "tsmi_squares"
        Me.tsmi_squares.Size = New System.Drawing.Size(115, 22)
        Me.tsmi_squares.Text = "Squares"
        '
        'tss_viewMoveOptions
        '
        Me.tss_viewMoveOptions.Name = "tss_viewMoveOptions"
        Me.tss_viewMoveOptions.Size = New System.Drawing.Size(196, 6)
        '
        'tsmi_optionsFromView
        '
        Me.tsmi_optionsFromView.Name = "tsmi_optionsFromView"
        Me.tsmi_optionsFromView.Size = New System.Drawing.Size(199, 22)
        Me.tsmi_optionsFromView.Text = "More options..."
        '
        'tlp_mainContainer
        '
        Me.tlp_mainContainer.ColumnCount = 2
        Me.tlp_mainContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_mainContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlp_mainContainer.Controls.Add(Me.tlp_sidebarContainer, 1, 0)
        Me.tlp_mainContainer.Controls.Add(Me.p_chessboardContainerContainer, 0, 0)
        Me.tlp_mainContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_mainContainer.Location = New System.Drawing.Point(0, 24)
        Me.tlp_mainContainer.Name = "tlp_mainContainer"
        Me.tlp_mainContainer.RowCount = 1
        Me.tlp_mainContainer.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_mainContainer.Size = New System.Drawing.Size(998, 587)
        Me.tlp_mainContainer.TabIndex = 15
        '
        'tlp_sidebarContainer
        '
        Me.tlp_sidebarContainer.ColumnCount = 1
        Me.tlp_sidebarContainer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_sidebarContainer.Controls.Add(Me.tlp_mainSidebarControls, 0, 0)
        Me.tlp_sidebarContainer.Controls.Add(Me.tlp_resignAndOptions, 0, 1)
        Me.tlp_sidebarContainer.Location = New System.Drawing.Point(783, 3)
        Me.tlp_sidebarContainer.Name = "tlp_sidebarContainer"
        Me.tlp_sidebarContainer.RowCount = 2
        Me.tlp_sidebarContainer.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_sidebarContainer.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_sidebarContainer.Size = New System.Drawing.Size(212, 581)
        Me.tlp_sidebarContainer.TabIndex = 16
        '
        'tlp_mainSidebarControls
        '
        Me.tlp_mainSidebarControls.ColumnCount = 1
        Me.tlp_mainSidebarControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_mainSidebarControls.Controls.Add(Me.lbl_whiteTimeHeader, 0, 0)
        Me.tlp_mainSidebarControls.Controls.Add(Me.lbl_whiteTimeCounter, 0, 1)
        Me.tlp_mainSidebarControls.Controls.Add(Me.lbl_blackTimeHeader, 0, 2)
        Me.tlp_mainSidebarControls.Controls.Add(Me.lbl_blackTimeCounter, 0, 3)
        Me.tlp_mainSidebarControls.Controls.Add(Me.lbl_moveIndicator, 0, 5)
        Me.tlp_mainSidebarControls.Controls.Add(Me.lbl_movesHeader, 0, 6)
        Me.tlp_mainSidebarControls.Controls.Add(Me.lv_moves, 0, 8)
        Me.tlp_mainSidebarControls.Controls.Add(Me.btn_takeBack, 0, 7)
        Me.tlp_mainSidebarControls.Location = New System.Drawing.Point(3, 3)
        Me.tlp_mainSidebarControls.Name = "tlp_mainSidebarControls"
        Me.tlp_mainSidebarControls.RowCount = 9
        Me.tlp_mainSidebarControls.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_mainSidebarControls.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_mainSidebarControls.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_mainSidebarControls.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_mainSidebarControls.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13.0!))
        Me.tlp_mainSidebarControls.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_mainSidebarControls.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_mainSidebarControls.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_mainSidebarControls.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_mainSidebarControls.Size = New System.Drawing.Size(206, 537)
        Me.tlp_mainSidebarControls.TabIndex = 1
        '
        'lv_moves
        '
        Me.lv_moves.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ch_hiddenColumn, Me.ch_white, Me.ch_black})
        Me.lv_moves.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv_moves.Location = New System.Drawing.Point(3, 261)
        Me.lv_moves.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lv_moves.Name = "lv_moves"
        Me.lv_moves.Size = New System.Drawing.Size(200, 273)
        Me.lv_moves.TabIndex = 12
        Me.lv_moves.UseCompatibleStateImageBehavior = False
        Me.lv_moves.View = System.Windows.Forms.View.Details
        '
        'ch_hiddenColumn
        '
        Me.ch_hiddenColumn.Width = 0
        '
        'ch_white
        '
        Me.ch_white.Text = "White"
        Me.ch_white.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ch_white.Width = 101
        '
        'ch_black
        '
        Me.ch_black.Text = "Black"
        Me.ch_black.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ch_black.Width = 101
        '
        'tlp_resignAndOptions
        '
        Me.tlp_resignAndOptions.ColumnCount = 2
        Me.tlp_resignAndOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_resignAndOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_resignAndOptions.Controls.Add(Me.btn_options, 0, 0)
        Me.tlp_resignAndOptions.Controls.Add(Me.btn_resign, 0, 0)
        Me.tlp_resignAndOptions.Location = New System.Drawing.Point(3, 546)
        Me.tlp_resignAndOptions.Name = "tlp_resignAndOptions"
        Me.tlp_resignAndOptions.RowCount = 1
        Me.tlp_resignAndOptions.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_resignAndOptions.Size = New System.Drawing.Size(206, 35)
        Me.tlp_resignAndOptions.TabIndex = 17
        '
        'btn_options
        '
        Me.btn_options.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_options.Location = New System.Drawing.Point(106, 3)
        Me.btn_options.Name = "btn_options"
        Me.btn_options.Size = New System.Drawing.Size(97, 27)
        Me.btn_options.TabIndex = 11
        Me.btn_options.Text = "Options"
        Me.btn_options.UseVisualStyleBackColor = True
        '
        'p_chessboardContainerContainer
        '
        Me.p_chessboardContainerContainer.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.p_chessboardContainerContainer.Controls.Add(Me.p_chessboardContainer)
        Me.p_chessboardContainerContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.p_chessboardContainerContainer.Location = New System.Drawing.Point(13, 3)
        Me.p_chessboardContainerContainer.Margin = New System.Windows.Forms.Padding(13, 3, 3, 7)
        Me.p_chessboardContainerContainer.Name = "p_chessboardContainerContainer"
        Me.p_chessboardContainerContainer.Size = New System.Drawing.Size(764, 577)
        Me.p_chessboardContainerContainer.TabIndex = 17
        '
        'p_chessboardContainer
        '
        Me.p_chessboardContainer.BackColor = System.Drawing.Color.Transparent
        Me.p_chessboardContainer.Controls.Add(Me.p_startGame)
        Me.p_chessboardContainer.Controls.Add(Me.p_endGame)
        Me.p_chessboardContainer.Controls.Add(Me.p_enterNames)
        Me.p_chessboardContainer.Controls.Add(Me.p_choosePawnPromotionPiece)
        Me.p_chessboardContainer.Controls.Add(Me.pb_chessboard)
        Me.p_chessboardContainer.Location = New System.Drawing.Point(94, 0)
        Me.p_chessboardContainer.Name = "p_chessboardContainer"
        Me.p_chessboardContainer.Size = New System.Drawing.Size(577, 577)
        Me.p_chessboardContainer.TabIndex = 0
        '
        'p_startGame
        '
        Me.p_startGame.Controls.Add(Me.lbl_startGameDialog)
        Me.p_startGame.Controls.Add(Me.btn_startGame)
        Me.p_startGame.Location = New System.Drawing.Point(76, 178)
        Me.p_startGame.Name = "p_startGame"
        Me.p_startGame.Size = New System.Drawing.Size(242, 107)
        Me.p_startGame.TabIndex = 9
        '
        'lbl_startGameDialog
        '
        Me.lbl_startGameDialog.Font = New System.Drawing.Font("Maiandra GD", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_startGameDialog.Location = New System.Drawing.Point(35, 0)
        Me.lbl_startGameDialog.Name = "lbl_startGameDialog"
        Me.lbl_startGameDialog.Padding = New System.Windows.Forms.Padding(0, 15, 0, 0)
        Me.lbl_startGameDialog.Size = New System.Drawing.Size(179, 62)
        Me.lbl_startGameDialog.TabIndex = 1
        Me.lbl_startGameDialog.Text = "Start game?"
        Me.lbl_startGameDialog.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btn_startGame
        '
        Me.btn_startGame.Location = New System.Drawing.Point(78, 65)
        Me.btn_startGame.Name = "btn_startGame"
        Me.btn_startGame.Size = New System.Drawing.Size(83, 29)
        Me.btn_startGame.TabIndex = 2
        Me.btn_startGame.Text = "Confirm"
        Me.btn_startGame.UseVisualStyleBackColor = True
        '
        'p_endGame
        '
        Me.p_endGame.Controls.Add(Me.lbl_endGameDialog)
        Me.p_endGame.Controls.Add(Me.btn_endGameMainMenu)
        Me.p_endGame.Controls.Add(Me.btn_endGameDialogClose)
        Me.p_endGame.Location = New System.Drawing.Point(76, 40)
        Me.p_endGame.Name = "p_endGame"
        Me.p_endGame.Size = New System.Drawing.Size(240, 117)
        Me.p_endGame.TabIndex = 8
        '
        'lbl_endGameDialog
        '
        Me.lbl_endGameDialog.Font = New System.Drawing.Font("Maiandra GD", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_endGameDialog.Location = New System.Drawing.Point(0, -1)
        Me.lbl_endGameDialog.Name = "lbl_endGameDialog"
        Me.lbl_endGameDialog.Padding = New System.Windows.Forms.Padding(0, 15, 0, 0)
        Me.lbl_endGameDialog.Size = New System.Drawing.Size(240, 118)
        Me.lbl_endGameDialog.TabIndex = 3
        Me.lbl_endGameDialog.Text = "end game b"
        Me.lbl_endGameDialog.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btn_endGameMainMenu
        '
        Me.btn_endGameMainMenu.Location = New System.Drawing.Point(20, 84)
        Me.btn_endGameMainMenu.Name = "btn_endGameMainMenu"
        Me.btn_endGameMainMenu.Size = New System.Drawing.Size(75, 23)
        Me.btn_endGameMainMenu.TabIndex = 4
        Me.btn_endGameMainMenu.Text = "Main menu"
        Me.btn_endGameMainMenu.UseVisualStyleBackColor = True
        '
        'btn_endGameDialogClose
        '
        Me.btn_endGameDialogClose.Location = New System.Drawing.Point(148, 84)
        Me.btn_endGameDialogClose.Name = "btn_endGameDialogClose"
        Me.btn_endGameDialogClose.Size = New System.Drawing.Size(75, 23)
        Me.btn_endGameDialogClose.TabIndex = 5
        Me.btn_endGameDialogClose.Text = "Close"
        Me.btn_endGameDialogClose.UseVisualStyleBackColor = True
        '
        'p_enterNames
        '
        Me.p_enterNames.Controls.Add(Me.btn_confirmPlayerName)
        Me.p_enterNames.Controls.Add(Me.tb_blackPlayerName)
        Me.p_enterNames.Controls.Add(Me.tb_whitePlayerName)
        Me.p_enterNames.Controls.Add(Me.lbl_blackPlayerHeader)
        Me.p_enterNames.Controls.Add(Me.lbl_whitePlayerName)
        Me.p_enterNames.Controls.Add(Me.lbl_enterNamesHeader)
        Me.p_enterNames.Location = New System.Drawing.Point(96, 291)
        Me.p_enterNames.Name = "p_enterNames"
        Me.p_enterNames.Size = New System.Drawing.Size(342, 155)
        Me.p_enterNames.TabIndex = 7
        Me.p_enterNames.Visible = False
        '
        'btn_confirmPlayerName
        '
        Me.btn_confirmPlayerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_confirmPlayerName.Location = New System.Drawing.Point(248, 70)
        Me.btn_confirmPlayerName.Name = "btn_confirmPlayerName"
        Me.btn_confirmPlayerName.Size = New System.Drawing.Size(76, 60)
        Me.btn_confirmPlayerName.TabIndex = 5
        Me.btn_confirmPlayerName.Text = "Confirm"
        Me.btn_confirmPlayerName.UseVisualStyleBackColor = True
        '
        'tb_blackPlayerName
        '
        Me.tb_blackPlayerName.Location = New System.Drawing.Point(92, 111)
        Me.tb_blackPlayerName.Name = "tb_blackPlayerName"
        Me.tb_blackPlayerName.Size = New System.Drawing.Size(130, 20)
        Me.tb_blackPlayerName.TabIndex = 4
        '
        'tb_whitePlayerName
        '
        Me.tb_whitePlayerName.Location = New System.Drawing.Point(92, 70)
        Me.tb_whitePlayerName.Name = "tb_whitePlayerName"
        Me.tb_whitePlayerName.Size = New System.Drawing.Size(130, 20)
        Me.tb_whitePlayerName.TabIndex = 3
        '
        'lbl_blackPlayerHeader
        '
        Me.lbl_blackPlayerHeader.Font = New System.Drawing.Font("Maiandra GD", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_blackPlayerHeader.Location = New System.Drawing.Point(13, 108)
        Me.lbl_blackPlayerHeader.Name = "lbl_blackPlayerHeader"
        Me.lbl_blackPlayerHeader.Size = New System.Drawing.Size(83, 23)
        Me.lbl_blackPlayerHeader.TabIndex = 2
        Me.lbl_blackPlayerHeader.Text = "Black:"
        Me.lbl_blackPlayerHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_whitePlayerName
        '
        Me.lbl_whitePlayerName.Font = New System.Drawing.Font("Maiandra GD", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_whitePlayerName.Location = New System.Drawing.Point(10, 67)
        Me.lbl_whitePlayerName.Name = "lbl_whitePlayerName"
        Me.lbl_whitePlayerName.Size = New System.Drawing.Size(95, 23)
        Me.lbl_whitePlayerName.TabIndex = 1
        Me.lbl_whitePlayerName.Text = "White:"
        Me.lbl_whitePlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_enterNamesHeader
        '
        Me.lbl_enterNamesHeader.BackColor = System.Drawing.Color.Gainsboro
        Me.lbl_enterNamesHeader.Font = New System.Drawing.Font("Maiandra GD", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_enterNamesHeader.Location = New System.Drawing.Point(28, 9)
        Me.lbl_enterNamesHeader.Name = "lbl_enterNamesHeader"
        Me.lbl_enterNamesHeader.Size = New System.Drawing.Size(283, 40)
        Me.lbl_enterNamesHeader.TabIndex = 0
        Me.lbl_enterNamesHeader.Text = "Enter player names"
        Me.lbl_enterNamesHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'p_choosePawnPromotionPiece
        '
        Me.p_choosePawnPromotionPiece.Controls.Add(Me.pb_pawnPromotionRook)
        Me.p_choosePawnPromotionPiece.Controls.Add(Me.pb_pawnPromotionQueen)
        Me.p_choosePawnPromotionPiece.Controls.Add(Me.pb_pawnPromotionBishop)
        Me.p_choosePawnPromotionPiece.Controls.Add(Me.pb_pawnPromotionKnight)
        Me.p_choosePawnPromotionPiece.Controls.Add(Me.lbl_pawnPromotion)
        Me.p_choosePawnPromotionPiece.Location = New System.Drawing.Point(272, 25)
        Me.p_choosePawnPromotionPiece.Name = "p_choosePawnPromotionPiece"
        Me.p_choosePawnPromotionPiece.Size = New System.Drawing.Size(274, 119)
        Me.p_choosePawnPromotionPiece.TabIndex = 6
        Me.p_choosePawnPromotionPiece.Visible = False
        '
        'pb_pawnPromotionRook
        '
        Me.pb_pawnPromotionRook.BackColor = System.Drawing.Color.Gainsboro
        Me.pb_pawnPromotionRook.Location = New System.Drawing.Point(150, 56)
        Me.pb_pawnPromotionRook.Name = "pb_pawnPromotionRook"
        Me.pb_pawnPromotionRook.Size = New System.Drawing.Size(45, 50)
        Me.pb_pawnPromotionRook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_pawnPromotionRook.TabIndex = 4
        Me.pb_pawnPromotionRook.TabStop = False
        '
        'pb_pawnPromotionQueen
        '
        Me.pb_pawnPromotionQueen.BackColor = System.Drawing.Color.Gainsboro
        Me.pb_pawnPromotionQueen.Location = New System.Drawing.Point(219, 56)
        Me.pb_pawnPromotionQueen.Name = "pb_pawnPromotionQueen"
        Me.pb_pawnPromotionQueen.Size = New System.Drawing.Size(45, 50)
        Me.pb_pawnPromotionQueen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_pawnPromotionQueen.TabIndex = 3
        Me.pb_pawnPromotionQueen.TabStop = False
        '
        'pb_pawnPromotionBishop
        '
        Me.pb_pawnPromotionBishop.BackColor = System.Drawing.Color.Gainsboro
        Me.pb_pawnPromotionBishop.Location = New System.Drawing.Point(81, 56)
        Me.pb_pawnPromotionBishop.Name = "pb_pawnPromotionBishop"
        Me.pb_pawnPromotionBishop.Size = New System.Drawing.Size(45, 50)
        Me.pb_pawnPromotionBishop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_pawnPromotionBishop.TabIndex = 2
        Me.pb_pawnPromotionBishop.TabStop = False
        '
        'pb_pawnPromotionKnight
        '
        Me.pb_pawnPromotionKnight.BackColor = System.Drawing.Color.Gainsboro
        Me.pb_pawnPromotionKnight.Location = New System.Drawing.Point(11, 56)
        Me.pb_pawnPromotionKnight.Name = "pb_pawnPromotionKnight"
        Me.pb_pawnPromotionKnight.Size = New System.Drawing.Size(45, 50)
        Me.pb_pawnPromotionKnight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_pawnPromotionKnight.TabIndex = 1
        Me.pb_pawnPromotionKnight.TabStop = False
        '
        'lbl_pawnPromotion
        '
        Me.lbl_pawnPromotion.Font = New System.Drawing.Font("Maiandra GD", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pawnPromotion.Location = New System.Drawing.Point(0, 15)
        Me.lbl_pawnPromotion.Name = "lbl_pawnPromotion"
        Me.lbl_pawnPromotion.Size = New System.Drawing.Size(274, 23)
        Me.lbl_pawnPromotion.TabIndex = 0
        Me.lbl_pawnPromotion.Text = "Choose pawn promotion piece"
        Me.lbl_pawnPromotion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_chessboard
        '
        Me.pb_chessboard.BackColor = System.Drawing.Color.White
        Me.pb_chessboard.Cursor = System.Windows.Forms.Cursors.Default
        Me.pb_chessboard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pb_chessboard.Location = New System.Drawing.Point(0, 0)
        Me.pb_chessboard.Name = "pb_chessboard"
        Me.pb_chessboard.Size = New System.Drawing.Size(577, 577)
        Me.pb_chessboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_chessboard.TabIndex = 0
        Me.pb_chessboard.TabStop = False
        '
        'frm_game
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(998, 611)
        Me.Controls.Add(Me.tlp_mainContainer)
        Me.Controls.Add(Me.ms_menu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.ms_menu
        Me.MinimumSize = New System.Drawing.Size(827, 650)
        Me.Name = "frm_game"
        Me.Text = "Checkmate"
        Me.ms_menu.ResumeLayout(False)
        Me.ms_menu.PerformLayout()
        Me.tlp_mainContainer.ResumeLayout(False)
        Me.tlp_sidebarContainer.ResumeLayout(False)
        Me.tlp_mainSidebarControls.ResumeLayout(False)
        Me.tlp_mainSidebarControls.PerformLayout()
        Me.tlp_resignAndOptions.ResumeLayout(False)
        Me.p_chessboardContainerContainer.ResumeLayout(False)
        Me.p_chessboardContainer.ResumeLayout(False)
        Me.p_startGame.ResumeLayout(False)
        Me.p_endGame.ResumeLayout(False)
        Me.p_enterNames.ResumeLayout(False)
        Me.p_enterNames.PerformLayout()
        Me.p_choosePawnPromotionPiece.ResumeLayout(False)
        CType(Me.pb_pawnPromotionRook, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_pawnPromotionQueen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_pawnPromotionBishop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_pawnPromotionKnight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_chessboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_whiteTimeHeader As System.Windows.Forms.Label
    Friend WithEvents lbl_blackTimeHeader As System.Windows.Forms.Label
    Friend WithEvents lbl_whiteTimeCounter As System.Windows.Forms.Label
    Friend WithEvents lbl_blackTimeCounter As System.Windows.Forms.Label
    Friend WithEvents lbl_moveIndicator As System.Windows.Forms.Label
    Friend WithEvents btn_takeBack As System.Windows.Forms.Button
    Friend WithEvents lbl_movesHeader As System.Windows.Forms.Label
    Friend WithEvents btn_resign As System.Windows.Forms.Button
    Friend WithEvents ms_menu As System.Windows.Forms.MenuStrip
    Friend WithEvents tlp_mainContainer As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_mainSidebarControls As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lv_moves As System.Windows.Forms.ListView
    Friend WithEvents ch_hiddenColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_white As System.Windows.Forms.ColumnHeader
    Friend WithEvents ch_black As System.Windows.Forms.ColumnHeader
    Friend WithEvents tlp_sidebarContainer As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlp_resignAndOptions As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents p_chessboardContainerContainer As System.Windows.Forms.Panel
    Friend WithEvents p_chessboardContainer As System.Windows.Forms.Panel
    Friend WithEvents pb_chessboard As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_startGameDialog As System.Windows.Forms.Label
    Friend WithEvents btn_startGame As System.Windows.Forms.Button
    Friend WithEvents lbl_endGameDialog As System.Windows.Forms.Label
    Friend WithEvents btn_endGameDialogClose As System.Windows.Forms.Button
    Friend WithEvents btn_endGameMainMenu As System.Windows.Forms.Button
    Friend WithEvents p_choosePawnPromotionPiece As System.Windows.Forms.Panel
    Friend WithEvents lbl_pawnPromotion As System.Windows.Forms.Label
    Friend WithEvents pb_pawnPromotionRook As System.Windows.Forms.PictureBox
    Friend WithEvents pb_pawnPromotionQueen As System.Windows.Forms.PictureBox
    Friend WithEvents pb_pawnPromotionBishop As System.Windows.Forms.PictureBox
    Friend WithEvents pb_pawnPromotionKnight As System.Windows.Forms.PictureBox
    Friend WithEvents tsmi_file As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_about As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tss_FileAboutSave As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmi_saveGame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tss_fileOptionsExit As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmi_exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_game As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_takeBack As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tss_gameTakebackResign As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmi_resign As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_mainMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_view As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_pieceStyle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_pieceStyle1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_pieceStyle2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_pieceStyle3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_pieceStyle4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_moveHighlighting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_dots As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_squares As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_pieceStyle5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_options As System.Windows.Forms.Button
    Friend WithEvents tss_fileSaveOptions As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmi_optionsFromFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tss_gameMainmenuOptions As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmi_optionsFromGame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tss_viewMoveOptions As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmi_optionsFromView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents p_enterNames As System.Windows.Forms.Panel
    Friend WithEvents tb_blackPlayerName As System.Windows.Forms.TextBox
    Friend WithEvents tb_whitePlayerName As System.Windows.Forms.TextBox
    Friend WithEvents lbl_blackPlayerHeader As System.Windows.Forms.Label
    Friend WithEvents lbl_whitePlayerName As System.Windows.Forms.Label
    Friend WithEvents lbl_enterNamesHeader As System.Windows.Forms.Label
    Friend WithEvents btn_confirmPlayerName As System.Windows.Forms.Button
    Friend WithEvents p_endGame As System.Windows.Forms.Panel
    Friend WithEvents p_startGame As System.Windows.Forms.Panel
End Class
