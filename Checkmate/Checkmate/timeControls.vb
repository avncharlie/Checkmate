Public Class timeControls
    Private Sub timeControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub link_howDoesThisWork_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles link_howDoesThisWork.LinkClicked
        timeControlInfo.Show()
    End Sub
End Class
