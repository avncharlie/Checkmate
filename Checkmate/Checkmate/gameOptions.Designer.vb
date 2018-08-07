<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gameOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gameOptions))
        Me.tbox_interval = New System.Windows.Forms.TextBox()
        Me.lbl_intervalHeader = New System.Windows.Forms.Label()
        Me.tb_interval = New System.Windows.Forms.TrackBar()
        Me.lbl_optionsHeader = New System.Windows.Forms.Label()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.btn_restoreDefault = New System.Windows.Forms.Button()
        Me.lbl_pieceStyle = New System.Windows.Forms.Label()
        Me.cb_pieceStyle = New System.Windows.Forms.ComboBox()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.tbox_switchSideDelay = New System.Windows.Forms.TextBox()
        Me.lbl_switchSideDelayHeader = New System.Windows.Forms.Label()
        Me.tb_switchSideDelay = New System.Windows.Forms.TrackBar()
        Me.lbl_boardSwitchEnabledHeader = New System.Windows.Forms.Label()
        Me.cb_boardSwitchEnabled = New System.Windows.Forms.CheckBox()
        Me.cb_moveHighlightStyle = New System.Windows.Forms.ComboBox()
        Me.lbl_moveHighlightStyleHeader = New System.Windows.Forms.Label()
        Me.pb_boardPreview = New System.Windows.Forms.PictureBox()
        Me.lbl_chessboardPreview = New System.Windows.Forms.Label()
        Me.lbl_darkSquares = New System.Windows.Forms.Label()
        Me.btn_darkSquares = New System.Windows.Forms.Button()
        Me.lbl_darkboardPreview = New System.Windows.Forms.Label()
        Me.cd_colorPicker = New System.Windows.Forms.ColorDialog()
        Me.lbl_lightboardPreview = New System.Windows.Forms.Label()
        Me.btn_lightSquares = New System.Windows.Forms.Button()
        Me.lbl_lightSquares = New System.Windows.Forms.Label()
        Me.lbl_validMoveIndicatorPreview = New System.Windows.Forms.Label()
        Me.btn_moveIndicator = New System.Windows.Forms.Button()
        Me.lbl_moveIndicator = New System.Windows.Forms.Label()
        Me.lbl_dotCapturePreview = New System.Windows.Forms.Label()
        Me.btn_dotCapture = New System.Windows.Forms.Button()
        Me.lbl_dotCapture = New System.Windows.Forms.Label()
        Me.lbl_squareCapturesPreview = New System.Windows.Forms.Label()
        Me.btn_squareCaptures = New System.Windows.Forms.Button()
        Me.lbl_squareCaptures = New System.Windows.Forms.Label()
        Me.lbl_kingInCheckPreview = New System.Windows.Forms.Label()
        Me.btn_kingInCheck = New System.Windows.Forms.Button()
        Me.lbl_kingInCheck = New System.Windows.Forms.Label()
        Me.lbl_selectedPiecePreview = New System.Windows.Forms.Label()
        Me.btn_selectedPiece = New System.Windows.Forms.Button()
        Me.lbl_selectedPiece = New System.Windows.Forms.Label()
        Me.lbl_intervalWarning = New System.Windows.Forms.Label()
        CType(Me.tb_interval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tb_switchSideDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_boardPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbox_interval
        '
        Me.tbox_interval.Location = New System.Drawing.Point(594, 80)
        Me.tbox_interval.Name = "tbox_interval"
        Me.tbox_interval.Size = New System.Drawing.Size(58, 20)
        Me.tbox_interval.TabIndex = 9
        Me.tbox_interval.Text = "10"
        '
        'lbl_intervalHeader
        '
        Me.lbl_intervalHeader.AutoSize = True
        Me.lbl_intervalHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_intervalHeader.Location = New System.Drawing.Point(17, 61)
        Me.lbl_intervalHeader.Name = "lbl_intervalHeader"
        Me.lbl_intervalHeader.Size = New System.Drawing.Size(175, 16)
        Me.lbl_intervalHeader.TabIndex = 8
        Me.lbl_intervalHeader.Text = "Timer interval (milliseconds)"
        '
        'tb_interval
        '
        Me.tb_interval.Location = New System.Drawing.Point(12, 80)
        Me.tb_interval.Maximum = 1000
        Me.tb_interval.Minimum = 10
        Me.tb_interval.Name = "tb_interval"
        Me.tb_interval.Size = New System.Drawing.Size(576, 45)
        Me.tb_interval.TabIndex = 7
        Me.tb_interval.TickFrequency = 5
        Me.tb_interval.Value = 10
        '
        'lbl_optionsHeader
        '
        Me.lbl_optionsHeader.AutoSize = True
        Me.lbl_optionsHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_optionsHeader.Location = New System.Drawing.Point(12, 9)
        Me.lbl_optionsHeader.Name = "lbl_optionsHeader"
        Me.lbl_optionsHeader.Size = New System.Drawing.Size(97, 29)
        Me.lbl_optionsHeader.TabIndex = 6
        Me.lbl_optionsHeader.Text = "Options"
        Me.lbl_optionsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_save
        '
        Me.btn_save.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save.Location = New System.Drawing.Point(359, 609)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(96, 40)
        Me.btn_save.TabIndex = 10
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_restoreDefault
        '
        Me.btn_restoreDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_restoreDefault.Location = New System.Drawing.Point(138, 609)
        Me.btn_restoreDefault.Name = "btn_restoreDefault"
        Me.btn_restoreDefault.Size = New System.Drawing.Size(190, 40)
        Me.btn_restoreDefault.TabIndex = 11
        Me.btn_restoreDefault.Text = "Restore default values"
        Me.btn_restoreDefault.UseVisualStyleBackColor = True
        '
        'lbl_pieceStyle
        '
        Me.lbl_pieceStyle.AutoSize = True
        Me.lbl_pieceStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pieceStyle.Location = New System.Drawing.Point(18, 257)
        Me.lbl_pieceStyle.Name = "lbl_pieceStyle"
        Me.lbl_pieceStyle.Size = New System.Drawing.Size(74, 16)
        Me.lbl_pieceStyle.TabIndex = 12
        Me.lbl_pieceStyle.Text = "Piece style"
        '
        'cb_pieceStyle
        '
        Me.cb_pieceStyle.FormattingEnabled = True
        Me.cb_pieceStyle.Items.AddRange(New Object() {"alpha", "cburnett", "cheq", "leipzig", "merida"})
        Me.cb_pieceStyle.Location = New System.Drawing.Point(21, 276)
        Me.cb_pieceStyle.Name = "cb_pieceStyle"
        Me.cb_pieceStyle.Size = New System.Drawing.Size(121, 21)
        Me.cb_pieceStyle.TabIndex = 13
        '
        'btn_cancel
        '
        Me.btn_cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancel.Location = New System.Drawing.Point(12, 609)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(97, 40)
        Me.btn_cancel.TabIndex = 21
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'tbox_switchSideDelay
        '
        Me.tbox_switchSideDelay.Location = New System.Drawing.Point(594, 208)
        Me.tbox_switchSideDelay.Name = "tbox_switchSideDelay"
        Me.tbox_switchSideDelay.Size = New System.Drawing.Size(58, 20)
        Me.tbox_switchSideDelay.TabIndex = 24
        Me.tbox_switchSideDelay.Text = "1"
        '
        'lbl_switchSideDelayHeader
        '
        Me.lbl_switchSideDelayHeader.AutoSize = True
        Me.lbl_switchSideDelayHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_switchSideDelayHeader.Location = New System.Drawing.Point(18, 189)
        Me.lbl_switchSideDelayHeader.Name = "lbl_switchSideDelayHeader"
        Me.lbl_switchSideDelayHeader.Size = New System.Drawing.Size(426, 16)
        Me.lbl_switchSideDelayHeader.TabIndex = 23
        Me.lbl_switchSideDelayHeader.Text = "Delay between placing move and switching board sides (milliseconds)"
        '
        'tb_switchSideDelay
        '
        Me.tb_switchSideDelay.Location = New System.Drawing.Point(12, 208)
        Me.tb_switchSideDelay.Maximum = 2000
        Me.tb_switchSideDelay.Minimum = 10
        Me.tb_switchSideDelay.Name = "tb_switchSideDelay"
        Me.tb_switchSideDelay.Size = New System.Drawing.Size(576, 45)
        Me.tb_switchSideDelay.TabIndex = 22
        Me.tb_switchSideDelay.TickFrequency = 10
        Me.tb_switchSideDelay.Value = 10
        '
        'lbl_boardSwitchEnabledHeader
        '
        Me.lbl_boardSwitchEnabledHeader.AutoSize = True
        Me.lbl_boardSwitchEnabledHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_boardSwitchEnabledHeader.Location = New System.Drawing.Point(18, 130)
        Me.lbl_boardSwitchEnabledHeader.Name = "lbl_boardSwitchEnabledHeader"
        Me.lbl_boardSwitchEnabledHeader.Size = New System.Drawing.Size(174, 16)
        Me.lbl_boardSwitchEnabledHeader.TabIndex = 25
        Me.lbl_boardSwitchEnabledHeader.Text = "Switch board sides after turn"
        '
        'cb_boardSwitchEnabled
        '
        Me.cb_boardSwitchEnabled.AutoSize = True
        Me.cb_boardSwitchEnabled.Location = New System.Drawing.Point(20, 151)
        Me.cb_boardSwitchEnabled.Name = "cb_boardSwitchEnabled"
        Me.cb_boardSwitchEnabled.Size = New System.Drawing.Size(65, 17)
        Me.cb_boardSwitchEnabled.TabIndex = 26
        Me.cb_boardSwitchEnabled.Text = "Enabled"
        Me.cb_boardSwitchEnabled.UseVisualStyleBackColor = True
        '
        'cb_moveHighlightStyle
        '
        Me.cb_moveHighlightStyle.FormattingEnabled = True
        Me.cb_moveHighlightStyle.Items.AddRange(New Object() {"dots", "squares"})
        Me.cb_moveHighlightStyle.Location = New System.Drawing.Point(20, 338)
        Me.cb_moveHighlightStyle.Name = "cb_moveHighlightStyle"
        Me.cb_moveHighlightStyle.Size = New System.Drawing.Size(121, 21)
        Me.cb_moveHighlightStyle.TabIndex = 28
        '
        'lbl_moveHighlightStyleHeader
        '
        Me.lbl_moveHighlightStyleHeader.AutoSize = True
        Me.lbl_moveHighlightStyleHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_moveHighlightStyleHeader.Location = New System.Drawing.Point(17, 319)
        Me.lbl_moveHighlightStyleHeader.Name = "lbl_moveHighlightStyleHeader"
        Me.lbl_moveHighlightStyleHeader.Size = New System.Drawing.Size(125, 16)
        Me.lbl_moveHighlightStyleHeader.TabIndex = 27
        Me.lbl_moveHighlightStyleHeader.Text = "Move highlight style"
        '
        'pb_boardPreview
        '
        Me.pb_boardPreview.BackColor = System.Drawing.Color.White
        Me.pb_boardPreview.Location = New System.Drawing.Point(168, 276)
        Me.pb_boardPreview.Name = "pb_boardPreview"
        Me.pb_boardPreview.Size = New System.Drawing.Size(310, 310)
        Me.pb_boardPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_boardPreview.TabIndex = 29
        Me.pb_boardPreview.TabStop = False
        '
        'lbl_chessboardPreview
        '
        Me.lbl_chessboardPreview.AutoSize = True
        Me.lbl_chessboardPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_chessboardPreview.Location = New System.Drawing.Point(165, 256)
        Me.lbl_chessboardPreview.Name = "lbl_chessboardPreview"
        Me.lbl_chessboardPreview.Size = New System.Drawing.Size(132, 16)
        Me.lbl_chessboardPreview.TabIndex = 30
        Me.lbl_chessboardPreview.Text = "Chessboard preview"
        '
        'lbl_darkSquares
        '
        Me.lbl_darkSquares.AutoSize = True
        Me.lbl_darkSquares.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_darkSquares.Location = New System.Drawing.Point(17, 381)
        Me.lbl_darkSquares.Name = "lbl_darkSquares"
        Me.lbl_darkSquares.Size = New System.Drawing.Size(128, 16)
        Me.lbl_darkSquares.TabIndex = 31
        Me.lbl_darkSquares.Text = "Dark board squares"
        '
        'btn_darkSquares
        '
        Me.btn_darkSquares.Location = New System.Drawing.Point(86, 400)
        Me.btn_darkSquares.Name = "btn_darkSquares"
        Me.btn_darkSquares.Size = New System.Drawing.Size(55, 24)
        Me.btn_darkSquares.TabIndex = 32
        Me.btn_darkSquares.Text = "Change"
        Me.btn_darkSquares.UseVisualStyleBackColor = True
        '
        'lbl_darkboardPreview
        '
        Me.lbl_darkboardPreview.BackColor = System.Drawing.Color.White
        Me.lbl_darkboardPreview.Location = New System.Drawing.Point(20, 400)
        Me.lbl_darkboardPreview.Name = "lbl_darkboardPreview"
        Me.lbl_darkboardPreview.Size = New System.Drawing.Size(60, 24)
        Me.lbl_darkboardPreview.TabIndex = 33
        '
        'lbl_lightboardPreview
        '
        Me.lbl_lightboardPreview.BackColor = System.Drawing.Color.White
        Me.lbl_lightboardPreview.Location = New System.Drawing.Point(20, 470)
        Me.lbl_lightboardPreview.Name = "lbl_lightboardPreview"
        Me.lbl_lightboardPreview.Size = New System.Drawing.Size(60, 24)
        Me.lbl_lightboardPreview.TabIndex = 36
        '
        'btn_lightSquares
        '
        Me.btn_lightSquares.Location = New System.Drawing.Point(86, 470)
        Me.btn_lightSquares.Name = "btn_lightSquares"
        Me.btn_lightSquares.Size = New System.Drawing.Size(55, 24)
        Me.btn_lightSquares.TabIndex = 35
        Me.btn_lightSquares.Text = "Change"
        Me.btn_lightSquares.UseVisualStyleBackColor = True
        '
        'lbl_lightSquares
        '
        Me.lbl_lightSquares.AutoSize = True
        Me.lbl_lightSquares.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_lightSquares.Location = New System.Drawing.Point(17, 451)
        Me.lbl_lightSquares.Name = "lbl_lightSquares"
        Me.lbl_lightSquares.Size = New System.Drawing.Size(127, 16)
        Me.lbl_lightSquares.TabIndex = 34
        Me.lbl_lightSquares.Text = "Light board squares"
        '
        'lbl_validMoveIndicatorPreview
        '
        Me.lbl_validMoveIndicatorPreview.BackColor = System.Drawing.Color.White
        Me.lbl_validMoveIndicatorPreview.Location = New System.Drawing.Point(20, 537)
        Me.lbl_validMoveIndicatorPreview.Name = "lbl_validMoveIndicatorPreview"
        Me.lbl_validMoveIndicatorPreview.Size = New System.Drawing.Size(60, 24)
        Me.lbl_validMoveIndicatorPreview.TabIndex = 39
        '
        'btn_moveIndicator
        '
        Me.btn_moveIndicator.Location = New System.Drawing.Point(86, 537)
        Me.btn_moveIndicator.Name = "btn_moveIndicator"
        Me.btn_moveIndicator.Size = New System.Drawing.Size(55, 24)
        Me.btn_moveIndicator.TabIndex = 38
        Me.btn_moveIndicator.Text = "Change"
        Me.btn_moveIndicator.UseVisualStyleBackColor = True
        '
        'lbl_moveIndicator
        '
        Me.lbl_moveIndicator.AutoSize = True
        Me.lbl_moveIndicator.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_moveIndicator.Location = New System.Drawing.Point(17, 518)
        Me.lbl_moveIndicator.Name = "lbl_moveIndicator"
        Me.lbl_moveIndicator.Size = New System.Drawing.Size(83, 16)
        Me.lbl_moveIndicator.TabIndex = 37
        Me.lbl_moveIndicator.Text = "Valid moves"
        '
        'lbl_dotCapturePreview
        '
        Me.lbl_dotCapturePreview.BackColor = System.Drawing.Color.White
        Me.lbl_dotCapturePreview.Location = New System.Drawing.Point(501, 300)
        Me.lbl_dotCapturePreview.Name = "lbl_dotCapturePreview"
        Me.lbl_dotCapturePreview.Size = New System.Drawing.Size(60, 24)
        Me.lbl_dotCapturePreview.TabIndex = 42
        '
        'btn_dotCapture
        '
        Me.btn_dotCapture.Location = New System.Drawing.Point(567, 300)
        Me.btn_dotCapture.Name = "btn_dotCapture"
        Me.btn_dotCapture.Size = New System.Drawing.Size(55, 24)
        Me.btn_dotCapture.TabIndex = 41
        Me.btn_dotCapture.Text = "Change"
        Me.btn_dotCapture.UseVisualStyleBackColor = True
        '
        'lbl_dotCapture
        '
        Me.lbl_dotCapture.AutoSize = True
        Me.lbl_dotCapture.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dotCapture.Location = New System.Drawing.Point(498, 281)
        Me.lbl_dotCapture.Name = "lbl_dotCapture"
        Me.lbl_dotCapture.Size = New System.Drawing.Size(131, 16)
        Me.lbl_dotCapture.TabIndex = 40
        Me.lbl_dotCapture.Text = "Valid captures (dots)"
        '
        'lbl_squareCapturesPreview
        '
        Me.lbl_squareCapturesPreview.BackColor = System.Drawing.Color.White
        Me.lbl_squareCapturesPreview.Location = New System.Drawing.Point(501, 380)
        Me.lbl_squareCapturesPreview.Name = "lbl_squareCapturesPreview"
        Me.lbl_squareCapturesPreview.Size = New System.Drawing.Size(60, 24)
        Me.lbl_squareCapturesPreview.TabIndex = 45
        '
        'btn_squareCaptures
        '
        Me.btn_squareCaptures.Location = New System.Drawing.Point(567, 380)
        Me.btn_squareCaptures.Name = "btn_squareCaptures"
        Me.btn_squareCaptures.Size = New System.Drawing.Size(55, 24)
        Me.btn_squareCaptures.TabIndex = 44
        Me.btn_squareCaptures.Text = "Change"
        Me.btn_squareCaptures.UseVisualStyleBackColor = True
        '
        'lbl_squareCaptures
        '
        Me.lbl_squareCaptures.AutoSize = True
        Me.lbl_squareCaptures.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_squareCaptures.Location = New System.Drawing.Point(498, 361)
        Me.lbl_squareCaptures.Name = "lbl_squareCaptures"
        Me.lbl_squareCaptures.Size = New System.Drawing.Size(154, 16)
        Me.lbl_squareCaptures.TabIndex = 43
        Me.lbl_squareCaptures.Text = "Valid captures (squares)"
        '
        'lbl_kingInCheckPreview
        '
        Me.lbl_kingInCheckPreview.BackColor = System.Drawing.Color.White
        Me.lbl_kingInCheckPreview.Location = New System.Drawing.Point(501, 459)
        Me.lbl_kingInCheckPreview.Name = "lbl_kingInCheckPreview"
        Me.lbl_kingInCheckPreview.Size = New System.Drawing.Size(60, 24)
        Me.lbl_kingInCheckPreview.TabIndex = 48
        '
        'btn_kingInCheck
        '
        Me.btn_kingInCheck.Location = New System.Drawing.Point(567, 459)
        Me.btn_kingInCheck.Name = "btn_kingInCheck"
        Me.btn_kingInCheck.Size = New System.Drawing.Size(55, 24)
        Me.btn_kingInCheck.TabIndex = 47
        Me.btn_kingInCheck.Text = "Change"
        Me.btn_kingInCheck.UseVisualStyleBackColor = True
        '
        'lbl_kingInCheck
        '
        Me.lbl_kingInCheck.AutoSize = True
        Me.lbl_kingInCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_kingInCheck.Location = New System.Drawing.Point(498, 440)
        Me.lbl_kingInCheck.Name = "lbl_kingInCheck"
        Me.lbl_kingInCheck.Size = New System.Drawing.Size(86, 16)
        Me.lbl_kingInCheck.TabIndex = 46
        Me.lbl_kingInCheck.Text = "King in check"
        '
        'lbl_selectedPiecePreview
        '
        Me.lbl_selectedPiecePreview.BackColor = System.Drawing.Color.White
        Me.lbl_selectedPiecePreview.Location = New System.Drawing.Point(501, 537)
        Me.lbl_selectedPiecePreview.Name = "lbl_selectedPiecePreview"
        Me.lbl_selectedPiecePreview.Size = New System.Drawing.Size(60, 24)
        Me.lbl_selectedPiecePreview.TabIndex = 51
        '
        'btn_selectedPiece
        '
        Me.btn_selectedPiece.Location = New System.Drawing.Point(567, 537)
        Me.btn_selectedPiece.Name = "btn_selectedPiece"
        Me.btn_selectedPiece.Size = New System.Drawing.Size(55, 24)
        Me.btn_selectedPiece.TabIndex = 50
        Me.btn_selectedPiece.Text = "Change"
        Me.btn_selectedPiece.UseVisualStyleBackColor = True
        '
        'lbl_selectedPiece
        '
        Me.lbl_selectedPiece.AutoSize = True
        Me.lbl_selectedPiece.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_selectedPiece.Location = New System.Drawing.Point(498, 518)
        Me.lbl_selectedPiece.Name = "lbl_selectedPiece"
        Me.lbl_selectedPiece.Size = New System.Drawing.Size(139, 16)
        Me.lbl_selectedPiece.TabIndex = 49
        Me.lbl_selectedPiece.Text = "Selected piece colour"
        '
        'lbl_intervalWarning
        '
        Me.lbl_intervalWarning.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lbl_intervalWarning.ForeColor = System.Drawing.Color.White
        Me.lbl_intervalWarning.Location = New System.Drawing.Point(384, 9)
        Me.lbl_intervalWarning.Name = "lbl_intervalWarning"
        Me.lbl_intervalWarning.Padding = New System.Windows.Forms.Padding(3)
        Me.lbl_intervalWarning.Size = New System.Drawing.Size(272, 57)
        Me.lbl_intervalWarning.TabIndex = 52
        Me.lbl_intervalWarning.Text = "Note: if timer interval is modified while a game has started, the changes will no" & _
            "t take affect until the next game."
        Me.lbl_intervalWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gameOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 661)
        Me.Controls.Add(Me.lbl_intervalWarning)
        Me.Controls.Add(Me.lbl_selectedPiecePreview)
        Me.Controls.Add(Me.btn_selectedPiece)
        Me.Controls.Add(Me.lbl_selectedPiece)
        Me.Controls.Add(Me.lbl_kingInCheckPreview)
        Me.Controls.Add(Me.btn_kingInCheck)
        Me.Controls.Add(Me.lbl_kingInCheck)
        Me.Controls.Add(Me.lbl_squareCapturesPreview)
        Me.Controls.Add(Me.btn_squareCaptures)
        Me.Controls.Add(Me.lbl_squareCaptures)
        Me.Controls.Add(Me.lbl_dotCapturePreview)
        Me.Controls.Add(Me.btn_dotCapture)
        Me.Controls.Add(Me.lbl_dotCapture)
        Me.Controls.Add(Me.lbl_validMoveIndicatorPreview)
        Me.Controls.Add(Me.btn_moveIndicator)
        Me.Controls.Add(Me.lbl_moveIndicator)
        Me.Controls.Add(Me.lbl_lightboardPreview)
        Me.Controls.Add(Me.btn_lightSquares)
        Me.Controls.Add(Me.lbl_lightSquares)
        Me.Controls.Add(Me.lbl_darkboardPreview)
        Me.Controls.Add(Me.btn_darkSquares)
        Me.Controls.Add(Me.lbl_darkSquares)
        Me.Controls.Add(Me.lbl_chessboardPreview)
        Me.Controls.Add(Me.pb_boardPreview)
        Me.Controls.Add(Me.cb_moveHighlightStyle)
        Me.Controls.Add(Me.lbl_moveHighlightStyleHeader)
        Me.Controls.Add(Me.cb_boardSwitchEnabled)
        Me.Controls.Add(Me.lbl_boardSwitchEnabledHeader)
        Me.Controls.Add(Me.tbox_switchSideDelay)
        Me.Controls.Add(Me.lbl_switchSideDelayHeader)
        Me.Controls.Add(Me.tb_switchSideDelay)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.cb_pieceStyle)
        Me.Controls.Add(Me.lbl_pieceStyle)
        Me.Controls.Add(Me.btn_restoreDefault)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.tbox_interval)
        Me.Controls.Add(Me.lbl_intervalHeader)
        Me.Controls.Add(Me.tb_interval)
        Me.Controls.Add(Me.lbl_optionsHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "gameOptions"
        Me.Text = "Options"
        Me.TopMost = True
        CType(Me.tb_interval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tb_switchSideDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_boardPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbox_interval As System.Windows.Forms.TextBox
    Friend WithEvents lbl_intervalHeader As System.Windows.Forms.Label
    Friend WithEvents tb_interval As System.Windows.Forms.TrackBar
    Friend WithEvents lbl_optionsHeader As System.Windows.Forms.Label
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_restoreDefault As System.Windows.Forms.Button
    Friend WithEvents lbl_pieceStyle As System.Windows.Forms.Label
    Friend WithEvents cb_pieceStyle As System.Windows.Forms.ComboBox
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents tbox_switchSideDelay As System.Windows.Forms.TextBox
    Friend WithEvents lbl_switchSideDelayHeader As System.Windows.Forms.Label
    Friend WithEvents tb_switchSideDelay As System.Windows.Forms.TrackBar
    Friend WithEvents lbl_boardSwitchEnabledHeader As System.Windows.Forms.Label
    Friend WithEvents cb_boardSwitchEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents cb_moveHighlightStyle As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_moveHighlightStyleHeader As System.Windows.Forms.Label
    Friend WithEvents pb_boardPreview As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_chessboardPreview As System.Windows.Forms.Label
    Friend WithEvents lbl_darkSquares As System.Windows.Forms.Label
    Friend WithEvents btn_darkSquares As System.Windows.Forms.Button
    Friend WithEvents lbl_darkboardPreview As System.Windows.Forms.Label
    Friend WithEvents cd_colorPicker As System.Windows.Forms.ColorDialog
    Friend WithEvents lbl_lightboardPreview As System.Windows.Forms.Label
    Friend WithEvents btn_lightSquares As System.Windows.Forms.Button
    Friend WithEvents lbl_lightSquares As System.Windows.Forms.Label
    Friend WithEvents lbl_validMoveIndicatorPreview As System.Windows.Forms.Label
    Friend WithEvents btn_moveIndicator As System.Windows.Forms.Button
    Friend WithEvents lbl_moveIndicator As System.Windows.Forms.Label
    Friend WithEvents lbl_dotCapturePreview As System.Windows.Forms.Label
    Friend WithEvents btn_dotCapture As System.Windows.Forms.Button
    Friend WithEvents lbl_dotCapture As System.Windows.Forms.Label
    Friend WithEvents lbl_squareCapturesPreview As System.Windows.Forms.Label
    Friend WithEvents btn_squareCaptures As System.Windows.Forms.Button
    Friend WithEvents lbl_squareCaptures As System.Windows.Forms.Label
    Friend WithEvents lbl_kingInCheckPreview As System.Windows.Forms.Label
    Friend WithEvents btn_kingInCheck As System.Windows.Forms.Button
    Friend WithEvents lbl_kingInCheck As System.Windows.Forms.Label
    Friend WithEvents lbl_selectedPiecePreview As System.Windows.Forms.Label
    Friend WithEvents btn_selectedPiece As System.Windows.Forms.Button
    Friend WithEvents lbl_selectedPiece As System.Windows.Forms.Label
    Friend WithEvents lbl_intervalWarning As System.Windows.Forms.Label
End Class
