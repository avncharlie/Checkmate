Public Class timeControlInfo

    Private Sub timeControlInfo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub


    Private Sub timeControlInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl_1.Text = Checkmate.My.Resources.txt_timeControlInfoLabel1
        lbl_2.Text = Checkmate.My.Resources.txt_timeControlInfoLabel2
        lbl_3.Text = Checkmate.My.Resources.txt_timeControlInfoLabel3
        pb_example.Image = Checkmate.My.Resources.pic_timeControlInfoExample
    End Sub
End Class