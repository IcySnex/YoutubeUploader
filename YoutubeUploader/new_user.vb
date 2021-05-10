Imports Google.Apis.Auth.OAuth2

Public Class new_user
    Private Async Sub BTN_create_Click(sender As Object, e As EventArgs) Handles BTN_create.Click
        If TB_username.Text = "" Or TB_username.Text.Count(Function(c As Char) c = " ") >= TB_username.Text.Length Then
            MsgBox("Please enter a valid username for your new profile!", MsgBoxStyle.Critical)
        Else
            Dim cred As UserCredential = Await Main.CreateCredantional(TB_username.Text)
            Me.Text = "Create New User - Waiting for login"
            If Not cred.Token.AccessToken = "" Then
                Main.CB_user.Items.Add(TB_username.Text)
                Main.CB_user.SelectedItem = TB_username.Text
                Me.Close()
            End If
        End If
    End Sub
End Class