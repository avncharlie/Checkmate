<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class timeControlInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(timeControlInfo))
        Me.lbl_header = New System.Windows.Forms.Label()
        Me.lbl_1 = New System.Windows.Forms.Label()
        Me.lbl_2 = New System.Windows.Forms.Label()
        Me.tlp_timeControlInfo = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_3 = New System.Windows.Forms.Label()
        Me.pb_example = New System.Windows.Forms.PictureBox()
        Me.tlp_timeControlInfo.SuspendLayout()
        CType(Me.pb_example, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_header
        '
        Me.lbl_header.AutoSize = True
        Me.lbl_header.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_header.Location = New System.Drawing.Point(13, 13)
        Me.lbl_header.Name = "lbl_header"
        Me.lbl_header.Size = New System.Drawing.Size(227, 24)
        Me.lbl_header.TabIndex = 0
        Me.lbl_header.Text = "How to use Time Controls"
        '
        'lbl_1
        '
        Me.lbl_1.AutoSize = True
        Me.lbl_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_1.Location = New System.Drawing.Point(3, 0)
        Me.lbl_1.Name = "lbl_1"
        Me.lbl_1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lbl_1.Size = New System.Drawing.Size(283, 26)
        Me.lbl_1.TabIndex = 1
        '
        'lbl_2
        '
        Me.lbl_2.AutoSize = True
        Me.lbl_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_2.Location = New System.Drawing.Point(3, 26)
        Me.lbl_2.Name = "lbl_2"
        Me.lbl_2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lbl_2.Size = New System.Drawing.Size(283, 26)
        Me.lbl_2.TabIndex = 2
        '
        'tlp_timeControlInfo
        '
        Me.tlp_timeControlInfo.ColumnCount = 1
        Me.tlp_timeControlInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_timeControlInfo.Controls.Add(Me.lbl_1, 0, 0)
        Me.tlp_timeControlInfo.Controls.Add(Me.lbl_2, 0, 1)
        Me.tlp_timeControlInfo.Controls.Add(Me.lbl_3, 0, 2)
        Me.tlp_timeControlInfo.Location = New System.Drawing.Point(12, 50)
        Me.tlp_timeControlInfo.Name = "tlp_timeControlInfo"
        Me.tlp_timeControlInfo.RowCount = 8
        Me.tlp_timeControlInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_timeControlInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_timeControlInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_timeControlInfo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlp_timeControlInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_timeControlInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_timeControlInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_timeControlInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlp_timeControlInfo.Size = New System.Drawing.Size(289, 400)
        Me.tlp_timeControlInfo.TabIndex = 3
        '
        'lbl_3
        '
        Me.lbl_3.AutoSize = True
        Me.lbl_3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_3.Location = New System.Drawing.Point(3, 52)
        Me.lbl_3.Name = "lbl_3"
        Me.lbl_3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lbl_3.Size = New System.Drawing.Size(283, 26)
        Me.lbl_3.TabIndex = 3
        '
        'pb_example
        '
        Me.pb_example.Location = New System.Drawing.Point(12, 440)
        Me.pb_example.Name = "pb_example"
        Me.pb_example.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.pb_example.Size = New System.Drawing.Size(267, 199)
        Me.pb_example.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_example.TabIndex = 4
        Me.pb_example.TabStop = False
        '
        'timeControlInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(301, 284)
        Me.Controls.Add(Me.pb_example)
        Me.Controls.Add(Me.tlp_timeControlInfo)
        Me.Controls.Add(Me.lbl_header)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "timeControlInfo"
        Me.Text = "Time Controls Information"
        Me.TopMost = True
        Me.tlp_timeControlInfo.ResumeLayout(False)
        Me.tlp_timeControlInfo.PerformLayout()
        CType(Me.pb_example, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_header As System.Windows.Forms.Label
    Friend WithEvents lbl_1 As System.Windows.Forms.Label
    Friend WithEvents lbl_2 As System.Windows.Forms.Label
    Friend WithEvents tlp_timeControlInfo As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_3 As System.Windows.Forms.Label
    Friend WithEvents pb_example As System.Windows.Forms.PictureBox
End Class
