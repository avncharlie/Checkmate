Public NotInheritable Class frm_about

    ' display attribution in about box
    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = "Checkmate by Alvin Charles" & vbCrLf & vbCrLf & "Attribution - " & vbCrLf & "Crown by Viktor Vorobyev from the Noun Project" & vbCrLf & "Settings by EnQiu from the Noun Project" & "Checkmate by Valter Bispo from the Noun Project" & vbCrLf & "alpha chess set pieces by Eric Bentzen" & vbCrLf & "cburnett chess set pieces by Colin M.L Burnett" & vbCrLf & "cheq chess set pieces by Adobe Systems, Inc." & vbCrLf & "leipzig chess set pieces (freeware)" & vbCrLf & "merida chess set pieces (freeware)"
    End Sub

    ' close form on ok button click
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class