﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class game
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(game))
        Me.pb_canvas = New System.Windows.Forms.PictureBox()
        Me.lbl_whiteTimeHeader = New System.Windows.Forms.Label()
        Me.lbl_blackTimeHeader = New System.Windows.Forms.Label()
        Me.lbl_whiteTimeCounter = New System.Windows.Forms.Label()
        Me.lbl_blackTimeCounter = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_takeBack = New System.Windows.Forms.Button()
        Me.lbl_movesHeader = New System.Windows.Forms.Label()
        Me.btn_resign = New System.Windows.Forms.Button()
        Me.btn_options = New System.Windows.Forms.Button()
        Me.lv_moves = New System.Windows.Forms.ListView()
        Me.hiddenColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.white = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.black = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ms_menu = New System.Windows.Forms.MenuStrip()
        Me.tsmi_file = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_about = New System.Windows.Forms.ToolStripMenuItem()
        Me.tss_1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmi_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_loadGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.tss_2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmi_options = New System.Windows.Forms.ToolStripMenuItem()
        Me.tss_3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmi_exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_game = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_takeBack = New System.Windows.Forms.ToolStripMenuItem()
        Me.tss_4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmi_resign = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_mainMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_view = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_piecesStyle = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_pieceStyleStub1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_pieceStyleStub2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_pieceStyleStub3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_newPieceStyleStub = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_boardStyle = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_boardStyleStub1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_boardStyleStub2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_boardStyleStub3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_newBoardStyleStub = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsdToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsdToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsdToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsdToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.pb_canvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ms_menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'pb_canvas
        '
        Me.pb_canvas.BackColor = System.Drawing.Color.White
        Me.pb_canvas.Location = New System.Drawing.Point(12, 29)
        Me.pb_canvas.Name = "pb_canvas"
        Me.pb_canvas.Size = New System.Drawing.Size(560, 560)
        Me.pb_canvas.TabIndex = 0
        Me.pb_canvas.TabStop = False
        '
        'lbl_whiteTimeHeader
        '
        Me.lbl_whiteTimeHeader.AutoSize = True
        Me.lbl_whiteTimeHeader.Font = New System.Drawing.Font("OCR A Extended", 12.0!)
        Me.lbl_whiteTimeHeader.Location = New System.Drawing.Point(595, 29)
        Me.lbl_whiteTimeHeader.Name = "lbl_whiteTimeHeader"
        Me.lbl_whiteTimeHeader.Size = New System.Drawing.Size(108, 17)
        Me.lbl_whiteTimeHeader.TabIndex = 1
        Me.lbl_whiteTimeHeader.Text = "WHITE TIME"
        '
        'lbl_blackTimeHeader
        '
        Me.lbl_blackTimeHeader.AutoSize = True
        Me.lbl_blackTimeHeader.Font = New System.Drawing.Font("OCR A Extended", 12.0!)
        Me.lbl_blackTimeHeader.Location = New System.Drawing.Point(595, 113)
        Me.lbl_blackTimeHeader.Name = "lbl_blackTimeHeader"
        Me.lbl_blackTimeHeader.Size = New System.Drawing.Size(108, 17)
        Me.lbl_blackTimeHeader.TabIndex = 2
        Me.lbl_blackTimeHeader.Text = "BLACK TIME"
        '
        'lbl_whiteTimeCounter
        '
        Me.lbl_whiteTimeCounter.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lbl_whiteTimeCounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_whiteTimeCounter.Font = New System.Drawing.Font("Maiandra GD", 16.0!)
        Me.lbl_whiteTimeCounter.Location = New System.Drawing.Point(598, 50)
        Me.lbl_whiteTimeCounter.Name = "lbl_whiteTimeCounter"
        Me.lbl_whiteTimeCounter.Size = New System.Drawing.Size(208, 49)
        Me.lbl_whiteTimeCounter.TabIndex = 3
        Me.lbl_whiteTimeCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_blackTimeCounter
        '
        Me.lbl_blackTimeCounter.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lbl_blackTimeCounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_blackTimeCounter.Font = New System.Drawing.Font("Maiandra GD", 16.0!)
        Me.lbl_blackTimeCounter.Location = New System.Drawing.Point(598, 134)
        Me.lbl_blackTimeCounter.Name = "lbl_blackTimeCounter"
        Me.lbl_blackTimeCounter.Size = New System.Drawing.Size(208, 49)
        Me.lbl_blackTimeCounter.TabIndex = 4
        Me.lbl_blackTimeCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Info
        Me.Label1.Font = New System.Drawing.Font("OCR A Extended", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(595, 198)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(211, 39)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "White to move"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_takeBack
        '
        Me.btn_takeBack.Font = New System.Drawing.Font("OCR A Extended", 9.0!)
        Me.btn_takeBack.Location = New System.Drawing.Point(598, 270)
        Me.btn_takeBack.Name = "btn_takeBack"
        Me.btn_takeBack.Size = New System.Drawing.Size(210, 23)
        Me.btn_takeBack.TabIndex = 11
        Me.btn_takeBack.Text = "TAKE BACK"
        Me.btn_takeBack.UseVisualStyleBackColor = True
        '
        'lbl_movesHeader
        '
        Me.lbl_movesHeader.AutoSize = True
        Me.lbl_movesHeader.Font = New System.Drawing.Font("OCR A Extended", 12.0!)
        Me.lbl_movesHeader.Location = New System.Drawing.Point(595, 249)
        Me.lbl_movesHeader.Name = "lbl_movesHeader"
        Me.lbl_movesHeader.Size = New System.Drawing.Size(58, 17)
        Me.lbl_movesHeader.TabIndex = 9
        Me.lbl_movesHeader.Text = "Moves"
        '
        'btn_resign
        '
        Me.btn_resign.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_resign.Location = New System.Drawing.Point(599, 562)
        Me.btn_resign.Name = "btn_resign"
        Me.btn_resign.Size = New System.Drawing.Size(104, 27)
        Me.btn_resign.TabIndex = 10
        Me.btn_resign.Text = "Resign"
        Me.btn_resign.UseVisualStyleBackColor = True
        '
        'btn_options
        '
        Me.btn_options.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_options.Location = New System.Drawing.Point(704, 562)
        Me.btn_options.Name = "btn_options"
        Me.btn_options.Size = New System.Drawing.Size(104, 27)
        Me.btn_options.TabIndex = 8
        Me.btn_options.Text = "Options"
        Me.btn_options.UseVisualStyleBackColor = True
        '
        'lv_moves
        '
        Me.lv_moves.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.hiddenColumn, Me.white, Me.black})
        Me.lv_moves.Enabled = False
        Me.lv_moves.Location = New System.Drawing.Point(599, 290)
        Me.lv_moves.Name = "lv_moves"
        Me.lv_moves.Size = New System.Drawing.Size(208, 264)
        Me.lv_moves.TabIndex = 12
        Me.lv_moves.UseCompatibleStateImageBehavior = False
        Me.lv_moves.View = System.Windows.Forms.View.Details
        '
        'hiddenColumn
        '
        Me.hiddenColumn.Width = 0
        '
        'white
        '
        Me.white.Text = "White"
        Me.white.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.white.Width = 102
        '
        'black
        '
        Me.black.Text = "Black"
        Me.black.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.black.Width = 102
        '
        'ms_menu
        '
        Me.ms_menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_file, Me.tsmi_game, Me.tsmi_view})
        Me.ms_menu.Location = New System.Drawing.Point(0, 0)
        Me.ms_menu.Name = "ms_menu"
        Me.ms_menu.Size = New System.Drawing.Size(818, 24)
        Me.ms_menu.TabIndex = 13
        Me.ms_menu.Text = "MenuStrip1"
        '
        'tsmi_file
        '
        Me.tsmi_file.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_about, Me.tss_1, Me.tsmi_save, Me.tsmi_loadGame, Me.tss_2, Me.tsmi_options, Me.tss_3, Me.tsmi_exit})
        Me.tsmi_file.Name = "tsmi_file"
        Me.tsmi_file.Size = New System.Drawing.Size(37, 20)
        Me.tsmi_file.Text = "File"
        '
        'tsmi_about
        '
        Me.tsmi_about.Name = "tsmi_about"
        Me.tsmi_about.Size = New System.Drawing.Size(142, 22)
        Me.tsmi_about.Text = "About"
        '
        'tss_1
        '
        Me.tss_1.Name = "tss_1"
        Me.tss_1.Size = New System.Drawing.Size(139, 6)
        '
        'tsmi_save
        '
        Me.tsmi_save.Name = "tsmi_save"
        Me.tsmi_save.Size = New System.Drawing.Size(142, 22)
        Me.tsmi_save.Text = "Save..."
        '
        'tsmi_loadGame
        '
        Me.tsmi_loadGame.Name = "tsmi_loadGame"
        Me.tsmi_loadGame.Size = New System.Drawing.Size(142, 22)
        Me.tsmi_loadGame.Text = "Load game..."
        '
        'tss_2
        '
        Me.tss_2.Name = "tss_2"
        Me.tss_2.Size = New System.Drawing.Size(139, 6)
        '
        'tsmi_options
        '
        Me.tsmi_options.Name = "tsmi_options"
        Me.tsmi_options.Size = New System.Drawing.Size(142, 22)
        Me.tsmi_options.Text = "Options..."
        '
        'tss_3
        '
        Me.tss_3.Name = "tss_3"
        Me.tss_3.Size = New System.Drawing.Size(139, 6)
        '
        'tsmi_exit
        '
        Me.tsmi_exit.Name = "tsmi_exit"
        Me.tsmi_exit.Size = New System.Drawing.Size(142, 22)
        Me.tsmi_exit.Text = "Exit"
        '
        'tsmi_game
        '
        Me.tsmi_game.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_takeBack, Me.tss_4, Me.tsmi_resign, Me.tsmi_mainMenu})
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
        'tss_4
        '
        Me.tss_4.Name = "tss_4"
        Me.tss_4.Size = New System.Drawing.Size(141, 6)
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
        'tsmi_view
        '
        Me.tsmi_view.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_piecesStyle, Me.tsmi_boardStyle})
        Me.tsmi_view.Name = "tsmi_view"
        Me.tsmi_view.Size = New System.Drawing.Size(44, 20)
        Me.tsmi_view.Text = "View"
        '
        'tsmi_piecesStyle
        '
        Me.tsmi_piecesStyle.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_pieceStyleStub1, Me.tsmi_pieceStyleStub2, Me.tsmi_pieceStyleStub3, Me.tsmi_newPieceStyleStub})
        Me.tsmi_piecesStyle.Name = "tsmi_piecesStyle"
        Me.tsmi_piecesStyle.Size = New System.Drawing.Size(134, 22)
        Me.tsmi_piecesStyle.Text = "Pieces style"
        '
        'tsmi_pieceStyleStub1
        '
        Me.tsmi_pieceStyleStub1.Name = "tsmi_pieceStyleStub1"
        Me.tsmi_pieceStyleStub1.Size = New System.Drawing.Size(134, 22)
        Me.tsmi_pieceStyleStub1.Text = "Style 1"
        '
        'tsmi_pieceStyleStub2
        '
        Me.tsmi_pieceStyleStub2.Name = "tsmi_pieceStyleStub2"
        Me.tsmi_pieceStyleStub2.Size = New System.Drawing.Size(134, 22)
        Me.tsmi_pieceStyleStub2.Text = "Style 2"
        '
        'tsmi_pieceStyleStub3
        '
        Me.tsmi_pieceStyleStub3.Name = "tsmi_pieceStyleStub3"
        Me.tsmi_pieceStyleStub3.Size = New System.Drawing.Size(134, 22)
        Me.tsmi_pieceStyleStub3.Text = "Style 3"
        '
        'tsmi_newPieceStyleStub
        '
        Me.tsmi_newPieceStyleStub.Name = "tsmi_newPieceStyleStub"
        Me.tsmi_newPieceStyleStub.Size = New System.Drawing.Size(134, 22)
        Me.tsmi_newPieceStyleStub.Text = "New style..."
        '
        'tsmi_boardStyle
        '
        Me.tsmi_boardStyle.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_boardStyleStub1, Me.tsmi_boardStyleStub2, Me.tsmi_boardStyleStub3, Me.tsmi_newBoardStyleStub})
        Me.tsmi_boardStyle.Name = "tsmi_boardStyle"
        Me.tsmi_boardStyle.Size = New System.Drawing.Size(134, 22)
        Me.tsmi_boardStyle.Text = "Board style"
        '
        'tsmi_boardStyleStub1
        '
        Me.tsmi_boardStyleStub1.Name = "tsmi_boardStyleStub1"
        Me.tsmi_boardStyleStub1.Size = New System.Drawing.Size(134, 22)
        Me.tsmi_boardStyleStub1.Text = "Style 1"
        '
        'tsmi_boardStyleStub2
        '
        Me.tsmi_boardStyleStub2.Name = "tsmi_boardStyleStub2"
        Me.tsmi_boardStyleStub2.Size = New System.Drawing.Size(134, 22)
        Me.tsmi_boardStyleStub2.Text = "Style 2"
        '
        'tsmi_boardStyleStub3
        '
        Me.tsmi_boardStyleStub3.Name = "tsmi_boardStyleStub3"
        Me.tsmi_boardStyleStub3.Size = New System.Drawing.Size(134, 22)
        Me.tsmi_boardStyleStub3.Text = "Style 3"
        '
        'tsmi_newBoardStyleStub
        '
        Me.tsmi_newBoardStyleStub.Name = "tsmi_newBoardStyleStub"
        Me.tsmi_newBoardStyleStub.Size = New System.Drawing.Size(134, 22)
        Me.tsmi_newBoardStyleStub.Text = "New style..."
        '
        'AdsToolStripMenuItem
        '
        Me.AdsToolStripMenuItem.Name = "AdsToolStripMenuItem"
        Me.AdsToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.AdsToolStripMenuItem.Text = "ads"
        '
        'AsdToolStripMenuItem
        '
        Me.AsdToolStripMenuItem.Name = "AsdToolStripMenuItem"
        Me.AsdToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AsdToolStripMenuItem.Text = "asd"
        '
        'AsdToolStripMenuItem1
        '
        Me.AsdToolStripMenuItem1.Name = "AsdToolStripMenuItem1"
        Me.AsdToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.AsdToolStripMenuItem1.Text = "asd"
        '
        'AsdToolStripMenuItem2
        '
        Me.AsdToolStripMenuItem2.Name = "AsdToolStripMenuItem2"
        Me.AsdToolStripMenuItem2.Size = New System.Drawing.Size(152, 22)
        Me.AsdToolStripMenuItem2.Text = "asd"
        '
        'AsdToolStripMenuItem3
        '
        Me.AsdToolStripMenuItem3.Name = "AsdToolStripMenuItem3"
        Me.AsdToolStripMenuItem3.Size = New System.Drawing.Size(152, 22)
        Me.AsdToolStripMenuItem3.Text = "asd"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'game
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 599)
        Me.Controls.Add(Me.lv_moves)
        Me.Controls.Add(Me.btn_options)
        Me.Controls.Add(Me.btn_resign)
        Me.Controls.Add(Me.lbl_movesHeader)
        Me.Controls.Add(Me.btn_takeBack)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_blackTimeCounter)
        Me.Controls.Add(Me.lbl_whiteTimeCounter)
        Me.Controls.Add(Me.lbl_blackTimeHeader)
        Me.Controls.Add(Me.lbl_whiteTimeHeader)
        Me.Controls.Add(Me.pb_canvas)
        Me.Controls.Add(Me.ms_menu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.ms_menu
        Me.Name = "game"
        Me.Text = "Checkmate"
        CType(Me.pb_canvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ms_menu.ResumeLayout(False)
        Me.ms_menu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pb_canvas As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_whiteTimeHeader As System.Windows.Forms.Label
    Friend WithEvents lbl_blackTimeHeader As System.Windows.Forms.Label
    Friend WithEvents lbl_whiteTimeCounter As System.Windows.Forms.Label
    Friend WithEvents lbl_blackTimeCounter As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_takeBack As System.Windows.Forms.Button
    Friend WithEvents lbl_movesHeader As System.Windows.Forms.Label
    Friend WithEvents btn_resign As System.Windows.Forms.Button
    Friend WithEvents btn_options As System.Windows.Forms.Button
    Friend WithEvents lv_moves As System.Windows.Forms.ListView
    Friend WithEvents hiddenColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents white As System.Windows.Forms.ColumnHeader
    Friend WithEvents black As System.Windows.Forms.ColumnHeader
    Friend WithEvents ms_menu As System.Windows.Forms.MenuStrip
    Friend WithEvents AdsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsdToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsdToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsdToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsdToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_file As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_about As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tss_1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmi_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_loadGame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tss_2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmi_options As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tss_3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmi_game As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_takeBack As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tss_4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmi_resign As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_mainMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_view As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_piecesStyle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_pieceStyleStub1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_pieceStyleStub2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_pieceStyleStub3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_newPieceStyleStub As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_boardStyle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_boardStyleStub1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_boardStyleStub2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_boardStyleStub3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_newBoardStyleStub As System.Windows.Forms.ToolStripMenuItem
End Class
