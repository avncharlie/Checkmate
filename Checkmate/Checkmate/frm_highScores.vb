Public Class frm_highScores
    Dim counter As Integer
    Dim highScoreArray() As String

    ' loads the highscores from the highscore file, sorts them and displays them
    Private Sub highScores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sortedIndexes() As Integer

        ' load high scores
        populateHighScoreArray(highScoreArray)

        ' if there is at least 1 high score
        If highScoreArray(0) <> "ï»¿" Then
            sortedIndexes = sortHighScoreArray(highScoreArray)

            For x = 0 To sortedIndexes.Length - 1
                lbl_highScores.Text = lbl_highScores.Text & highScoreArray(sortedIndexes(x)) & vbCrLf
            Next
        End If
    End Sub

    ' takes a byref highScores and puts highscores file line by line into it
    Private Sub populateHighScoreArray(ByRef highScores As String())
        ' open file
        FileSystem.FileOpen(1, resources.highscoreFile, OpenMode.Input)

        ' init high score array
        highScores = {""}

        ' init counter and setup loop
        counter = 0
        FileSystem.Input(1, highScores(counter))

        ' read file from loop
        While Not EOF(1)
            ReDim Preserve highScores(highScoreArray.Length)
            counter += 1
            FileSystem.Input(1, highScores(counter))
        End While

        ' close file
        FileSystem.FileClose(1)
    End Sub

    ' given a high score, return just the seconds value of the high score
    Private Function timeFromHighScore(ByVal highScore As String) As Single
        Dim highScoreWordArray() As String
        highScoreWordArray = highScore.Split(" ")

        Dim time As String
        time = highScoreWordArray(highScoreWordArray.Length - 2)

        timeFromHighScore = time
    End Function

    ' given a high score array, returns an array with the high scores sorted as an array of indexes
    Private Function sortHighScoreArray(ByVal highScores As String()) As Integer()
        Dim sortedHighScoreIndexes() As Integer

        Dim tempTime As String
        Dim lowestTimeIndex As Integer
        Dim sortedIndexCounter As Integer

        ' init sortedHighScores
        sortedHighScoreIndexes = {}
        sortedIndexCounter = 0

        Dim lowestTime As Single

        While sortedHighScoreIndexes.Length <> highScores.Length
            lowestTime = 100000000000000000
            For x = 0 To highScores.Length - 1

                tempTime = timeFromHighScore(highScores(x))

                If Not sortedHighScoreIndexes.Contains(x) Then
                    If tempTime < lowestTime Then
                        lowestTime = tempTime
                        lowestTimeIndex = x
                    End If
                End If
            Next

            ReDim Preserve sortedHighScoreIndexes(sortedHighScoreIndexes.Length)
            sortedHighScoreIndexes(sortedIndexCounter) = lowestTimeIndex
            sortedIndexCounter = sortedIndexCounter + 1
        End While

        sortHighScoreArray = sortedHighScoreIndexes
    End Function
End Class