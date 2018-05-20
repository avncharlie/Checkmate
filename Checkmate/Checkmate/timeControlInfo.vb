Public Class timeControlInfo

    Private Sub timeControlInfo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        pb_example.Image = Image.FromFile(My.Application.Info.DirectoryPath & "/Resources/timeControlInfo/" & "Example.png")
    End Sub

    Private Function getLabelTexts(ByVal number) As String
        Dim filePath = My.Application.Info.DirectoryPath & "/Resources/timeControlInfo/" & "label" & number & ".txt"
        getLabelTexts = My.Computer.FileSystem.ReadAllText(filePath)
    End Function

    Private Sub timeControlInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl_1.Text = getLabelTexts(1)
        lbl_2.Text = getLabelTexts(2)
        lbl_3.Text = getLabelTexts(3)
        pb_example.Image = Image.FromFile(My.Application.Info.DirectoryPath & "/Resources/timeControlInfo/" & "Example.png")
    End Sub
End Class