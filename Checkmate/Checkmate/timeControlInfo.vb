Public Class timeControlInfo

    Private Sub timeControlInfo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub


    Private Sub timeControlInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl_1.Text = resources.timeControlInfoLabels(0)
        lbl_2.Text = resources.timeControlInfoLabels(1)
        lbl_3.Text = resources.timeControlInfoLabels(2)
        pb_example.Image = Image.FromFile(resources.timeControlInfoScreenExampePath)
    End Sub
End Class