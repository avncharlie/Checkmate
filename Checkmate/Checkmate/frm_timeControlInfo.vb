Public Class frm_timeControlInfo

    ' form closes on escape
    Private Sub timeControlInfo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    ' load info text from resources
    Private Sub timeControlInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl_info1.Text = resources.timeControlInfoLabel1
        lbl_info2.Text = resources.timeControlInfoLabel2
        lbl_info3.Text = resources.timeControlInfoLabel3
        pb_example.Image = Image.FromFile(resources.timeControlInfoScreenExampePath)
    End Sub
End Class