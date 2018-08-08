<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_customTimeControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_customTimeControl))
        Me.lbl_customTimeControl = New System.Windows.Forms.Label()
        Me.tb_timePerSide = New System.Windows.Forms.TrackBar()
        Me.lbl_totalTimeLabel = New System.Windows.Forms.Label()
        Me.lbl_incrementLabel = New System.Windows.Forms.Label()
        Me.tb_increment = New System.Windows.Forms.TrackBar()
        Me.tbox_totalTime = New System.Windows.Forms.TextBox()
        Me.tbox_increment = New System.Windows.Forms.TextBox()
        Me.lbl_result = New System.Windows.Forms.Label()
        Me.btn_continue = New System.Windows.Forms.Button()
        Me.btn_back = New System.Windows.Forms.Button()
        CType(Me.tb_timePerSide, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tb_increment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_customTimeControl
        '
        Me.lbl_customTimeControl.AutoSize = True
        Me.lbl_customTimeControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_customTimeControl.Location = New System.Drawing.Point(12, 9)
        Me.lbl_customTimeControl.Name = "lbl_customTimeControl"
        Me.lbl_customTimeControl.Size = New System.Drawing.Size(241, 29)
        Me.lbl_customTimeControl.TabIndex = 0
        Me.lbl_customTimeControl.Text = "Custom Time Control"
        Me.lbl_customTimeControl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tb_timePerSide
        '
        Me.tb_timePerSide.Location = New System.Drawing.Point(12, 80)
        Me.tb_timePerSide.Maximum = 60
        Me.tb_timePerSide.Minimum = 1
        Me.tb_timePerSide.Name = "tb_timePerSide"
        Me.tb_timePerSide.Size = New System.Drawing.Size(343, 45)
        Me.tb_timePerSide.TabIndex = 1
        Me.tb_timePerSide.Value = 1
        '
        'lbl_totalTimeLabel
        '
        Me.lbl_totalTimeLabel.AutoSize = True
        Me.lbl_totalTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_totalTimeLabel.Location = New System.Drawing.Point(17, 61)
        Me.lbl_totalTimeLabel.Name = "lbl_totalTimeLabel"
        Me.lbl_totalTimeLabel.Size = New System.Drawing.Size(106, 16)
        Me.lbl_totalTimeLabel.TabIndex = 2
        Me.lbl_totalTimeLabel.Text = "Minutes per side"
        '
        'lbl_incrementLabel
        '
        Me.lbl_incrementLabel.AutoSize = True
        Me.lbl_incrementLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_incrementLabel.Location = New System.Drawing.Point(17, 128)
        Me.lbl_incrementLabel.Name = "lbl_incrementLabel"
        Me.lbl_incrementLabel.Size = New System.Drawing.Size(134, 16)
        Me.lbl_incrementLabel.TabIndex = 4
        Me.lbl_incrementLabel.Text = "Increment in seconds"
        '
        'tb_increment
        '
        Me.tb_increment.Location = New System.Drawing.Point(12, 147)
        Me.tb_increment.Maximum = 60
        Me.tb_increment.Name = "tb_increment"
        Me.tb_increment.Size = New System.Drawing.Size(343, 45)
        Me.tb_increment.TabIndex = 3
        '
        'tbox_totalTime
        '
        Me.tbox_totalTime.Location = New System.Drawing.Point(361, 80)
        Me.tbox_totalTime.Name = "tbox_totalTime"
        Me.tbox_totalTime.Size = New System.Drawing.Size(58, 20)
        Me.tbox_totalTime.TabIndex = 5
        Me.tbox_totalTime.Text = "1"
        '
        'tbox_increment
        '
        Me.tbox_increment.Location = New System.Drawing.Point(361, 147)
        Me.tbox_increment.Name = "tbox_increment"
        Me.tbox_increment.Size = New System.Drawing.Size(58, 20)
        Me.tbox_increment.TabIndex = 6
        Me.tbox_increment.Text = "0"
        '
        'lbl_result
        '
        Me.lbl_result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_result.Font = New System.Drawing.Font("Maiandra GD", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_result.Location = New System.Drawing.Point(20, 195)
        Me.lbl_result.Name = "lbl_result"
        Me.lbl_result.Size = New System.Drawing.Size(308, 56)
        Me.lbl_result.TabIndex = 7
        Me.lbl_result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_continue
        '
        Me.btn_continue.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_continue.Location = New System.Drawing.Point(334, 195)
        Me.btn_continue.Name = "btn_continue"
        Me.btn_continue.Size = New System.Drawing.Size(85, 56)
        Me.btn_continue.TabIndex = 8
        Me.btn_continue.Text = "Continue"
        Me.btn_continue.UseVisualStyleBackColor = True
        '
        'btn_back
        '
        Me.btn_back.Location = New System.Drawing.Point(20, 261)
        Me.btn_back.Name = "btn_back"
        Me.btn_back.Size = New System.Drawing.Size(75, 23)
        Me.btn_back.TabIndex = 9
        Me.btn_back.Text = "Back"
        Me.btn_back.UseVisualStyleBackColor = True
        '
        'frm_customTimeControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 294)
        Me.Controls.Add(Me.btn_back)
        Me.Controls.Add(Me.btn_continue)
        Me.Controls.Add(Me.lbl_result)
        Me.Controls.Add(Me.tbox_increment)
        Me.Controls.Add(Me.tbox_totalTime)
        Me.Controls.Add(Me.lbl_incrementLabel)
        Me.Controls.Add(Me.tb_increment)
        Me.Controls.Add(Me.lbl_totalTimeLabel)
        Me.Controls.Add(Me.tb_timePerSide)
        Me.Controls.Add(Me.lbl_customTimeControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frm_customTimeControl"
        Me.Text = "Custom Time Control"
        CType(Me.tb_timePerSide, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tb_increment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_customTimeControl As System.Windows.Forms.Label
    Friend WithEvents tb_timePerSide As System.Windows.Forms.TrackBar
    Friend WithEvents lbl_totalTimeLabel As System.Windows.Forms.Label
    Friend WithEvents lbl_incrementLabel As System.Windows.Forms.Label
    Friend WithEvents tb_increment As System.Windows.Forms.TrackBar
    Friend WithEvents tbox_totalTime As System.Windows.Forms.TextBox
    Friend WithEvents tbox_increment As System.Windows.Forms.TextBox
    Friend WithEvents lbl_result As System.Windows.Forms.Label
    Friend WithEvents btn_continue As System.Windows.Forms.Button
    Friend WithEvents btn_back As System.Windows.Forms.Button
End Class
