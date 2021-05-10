Public Class about
    Private Sub BTN_github_Click(sender As Object, e As EventArgs) Handles BTN_github.Click
        Process.Start("https://github.com/IcySnex/YoutubeUploader")
    End Sub

    Private Sub BTN_close_Click(sender As Object, e As EventArgs) Handles BTN_close.Click
        Me.Close()
    End Sub
End Class