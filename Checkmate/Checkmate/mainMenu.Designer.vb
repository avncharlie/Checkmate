<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainMenu))
        Me.lbl_header = New System.Windows.Forms.Label()
        Me.pb_mainScreen = New System.Windows.Forms.PictureBox()
        Me.btn_newGame = New System.Windows.Forms.Button()
        Me.btn_loadGame = New System.Windows.Forms.Button()
        Me.btn_newTimedGame = New System.Windows.Forms.Button()
        Me.btn_options = New System.Windows.Forms.Button()
        CType(Me.pb_mainScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_header
        '
        Me.lbl_header.Font = New System.Drawing.Font("Maiandra GD", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_header.Location = New System.Drawing.Point(12, 13)
        Me.lbl_header.Name = "lbl_header"
        Me.lbl_header.Size = New System.Drawing.Size(260, 44)
        Me.lbl_header.TabIndex = 0
        Me.lbl_header.Text = "CHECKMATE"
        Me.lbl_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_mainScreen
        '
        Me.pb_mainScreen.Location = New System.Drawing.Point(18, 63)
        Me.pb_mainScreen.Name = "pb_mainScreen"
        Me.pb_mainScreen.Size = New System.Drawing.Size(254, 258)
        Me.pb_mainScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_mainScreen.TabIndex = 1
        Me.pb_mainScreen.TabStop = False
        '
        'btn_newGame
        '
        Me.btn_newGame.Font = New System.Drawing.Font("Maiandra GD", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_newGame.Location = New System.Drawing.Point(42, 95)
        Me.btn_newGame.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_newGame.Name = "btn_newGame"
        Me.btn_newGame.Size = New System.Drawing.Size(204, 43)
        Me.btn_newGame.TabIndex = 3
        Me.btn_newGame.Text = "New Game"
        Me.btn_newGame.UseVisualStyleBackColor = True
        '
        'btn_loadGame
        '
        Me.btn_loadGame.Font = New System.Drawing.Font("Maiandra GD", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_loadGame.Location = New System.Drawing.Point(42, 257)
        Me.btn_loadGame.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_loadGame.Name = "btn_loadGame"
        Me.btn_loadGame.Size = New System.Drawing.Size(143, 43)
        Me.btn_loadGame.TabIndex = 4
        Me.btn_loadGame.Text = "Load Game"
        Me.btn_loadGame.UseVisualStyleBackColor = True
        '
        'btn_newTimedGame
        '
        Me.btn_newTimedGame.Font = New System.Drawing.Font("Maiandra GD", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_newTimedGame.Location = New System.Drawing.Point(42, 151)
        Me.btn_newTimedGame.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_newTimedGame.Name = "btn_newTimedGame"
        Me.btn_newTimedGame.Size = New System.Drawing.Size(204, 43)
        Me.btn_newTimedGame.TabIndex = 5
        Me.btn_newTimedGame.Text = "New Timed Game"
        Me.btn_newTimedGame.UseVisualStyleBackColor = True
        '
        'btn_options
        '
        Me.btn_options.Font = New System.Drawing.Font("Maiandra GD", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_options.Location = New System.Drawing.Point(189, 257)
        Me.btn_options.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_options.Name = "btn_options"
        Me.btn_options.Size = New System.Drawing.Size(57, 43)
        Me.btn_options.TabIndex = 6
        Me.btn_options.UseVisualStyleBackColor = True
        '
        'mainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 347)
        Me.Controls.Add(Me.btn_options)
        Me.Controls.Add(Me.btn_newTimedGame)
        Me.Controls.Add(Me.btn_loadGame)
        Me.Controls.Add(Me.btn_newGame)
        Me.Controls.Add(Me.pb_mainScreen)
        Me.Controls.Add(Me.lbl_header)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "mainMenu"
        Me.Text = "Checkmate"
        CType(Me.pb_mainScreen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_header As System.Windows.Forms.Label
    Friend WithEvents pb_mainScreen As System.Windows.Forms.PictureBox
    Friend WithEvents btn_newGame As System.Windows.Forms.Button
    Friend WithEvents btn_loadGame As System.Windows.Forms.Button
    Friend WithEvents btn_newTimedGame As System.Windows.Forms.Button
    Friend WithEvents btn_options As System.Windows.Forms.Button
End Class
