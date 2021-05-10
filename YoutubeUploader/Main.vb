Imports System.IO
Imports System.Reflection
Imports System.Threading
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Services
Imports Google.Apis.Upload
Imports Google.Apis.YouTube.v3
Imports Google.Apis.YouTube.v3.Data

Public Class Main

#Region "Main"
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CB_user.SelectedItem = My.Settings.CB_user
        CB_details_privacy.SelectedIndex = 0
    End Sub
#End Region

#Region "Google API"

#Region "Create New User"
    Public Shared Async Function CreateCredantional(ByVal username As String) As Task(Of UserCredential)
        Dim credential As UserCredential
        Using stream As FileStream = New FileStream("client_secrets.json", FileMode.Open, FileAccess.Read)
            credential = Await GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, {Google.Apis.YouTube.v3.YouTubeService.Scope.YoutubeUpload}, username, CancellationToken.None)
        End Using

        Return credential
    End Function
#End Region

#Region "Upload"
    Private Async Sub Upload(ByVal title As String, ByVal description As String, ByVal tags As String(), ByVal user As String, ByVal videopath As String, ByVal privacy As String)
        Dim credential As UserCredential = Await CreateCredantional(user)
        Dim youtubeService = New YouTubeService(New BaseClientService.Initializer() With {
                                                .HttpClientInitializer = credential,
                                                .ApplicationName = Assembly.GetExecutingAssembly().GetName.Name})

        Dim video = New Video()
        video.Snippet = New VideoSnippet()
        video.Snippet.Title = title
        video.Snippet.Description = description
        video.Snippet.Tags = tags
        video.Snippet.CategoryId = "22"
        video.Status = New VideoStatus()
        video.Status.PrivacyStatus = privacy

        Using filestream = New FileStream(videopath, FileMode.Open)
            Dim videoInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", filestream, "video/*")
            AddHandler videoInsertRequest.ProgressChanged, AddressOf videoInsertRequest_ProgressChanged
            AddHandler videoInsertRequest.ResponseReceived, AddressOf videoInsertRequest_ResponseReceived
            Await videoInsertRequest.UploadAsync
        End Using
    End Sub
#End Region

#Region "Handlers"
    Private Sub videoInsertRequest_ProgressChanged(ByVal progress As IUploadProgress)
        Control.CheckForIllegalCrossThreadCalls = False
        Select Case progress.Status
            Case UploadStatus.NotStarted
                LB_state_state.Text = "Upload not startet..."
            Case UploadStatus.Starting
                LB_state_state.Text = "Upload has startet..."
            Case UploadStatus.Uploading
                LB_state_state.Text = "Uploading..."
                PB_state_progress.Maximum = New FileInfo(TB_video_path.Text).Length / 1000
                PB_state_progress.Value = progress.BytesSent / 1000
            Case UploadStatus.Failed
                LB_state_state.Text = "Upload has failed..."
                MsgBox($"The Upload has failed!{vbCrLf}{vbCrLf}Exception:""{vbCrLf}{progress.Exception.ToString}""", MsgBoxStyle.Critical)
                LoadNext()
        End Select
    End Sub

    Private Async Sub videoInsertRequest_ResponseReceived(ByVal video As Video)
        PB_state_progress.Value = PB_state_progress.Maximum
        LB_state_state.Text = "Upload has sucessfully finished..."
        If CB_fluentqueue.Checked Then
            If queue.Count >= 1 Then
                Reset("f")
                Await Task.Delay(150)
                LoadNext()
                Await Task.Delay(150)
                Start()
            End If
        Else
            Reset()
            If MessageBox.Show("Video sucessfully uploaded to youtube! Do you want to open it?", "Upload finished", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Process.Start($"https://www.youtube.com/watch?v={video.Id}")
            End If
        End If
    End Sub
#End Region

#End Region

#Region "Load/Reset"

#Region "Load"
    Private Sub LoadSingle()
        OFD_loadvideo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop

        If OFD_loadvideo.ShowDialog() = DialogResult.OK Then
            If OFD_loadvideo.FileName IsNot "" Then
                If queue.Contains(OFD_loadvideo.FileName) Then
                    MsgBox("Video already exists in queue!", MsgBoxStyle.Critical)
                Else
                    Try
                        If queue.Contains(OFD_loadvideo.FileName) Then
                            MsgBox("Video already exists in queue!", MsgBoxStyle.Critical)
                        Else
                            queue.Add(OFD_loadvideo.FileName)
                            ReloadQueue()

                            If TB_video_path.Text = "" Then
                                LoadNext()
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("Failed adding video to queue!", MsgBoxStyle.Critical)
                    End Try
                End If
            Else
                MsgBox("Failed adding video to queue!", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub LoadFolder()
        If FBD_loadvideo.ShowDialog = DialogResult.OK Then
            Dim i As Integer
            For Each item As FileInfo In New DirectoryInfo(FBD_loadvideo.SelectedPath).GetFiles
                If item.Extension = ".mkv" Or item.Extension = ".webm" Or item.Extension = ".flv" Or item.Extension = ".avi" Or item.Extension = ".mov" Or item.Extension = ".mp4" Or item.Extension = ".mpg" Or item.Extension = ".mpeg" Or item.Extension = ".m4v" Then
                    If queue.Contains(item.FullName) Then
                        MsgBox("Video already exists in queue!", MsgBoxStyle.Critical)
                    Else
                        queue.Add(item.FullName)
                        i += 1
                    End If
                End If
            Next
            If i = 0 Then
                MsgBox("This folder doesnt contain any supportet videos! (Supportet formats: .mkv .webm .flv .avi .mov .mp4 .mpg .mpeg .m4v)", MsgBoxStyle.Critical)
            Else
                ReloadQueue()

                If TB_video_path.Text = "" Then
                    LoadNext()
                End If
            End If
        End If
    End Sub
#End Region

#Region "LoadNext"
    Private Sub LoadNext()
        ResetText()

        If queue.Count < 1 Then
            TabControl1.SelectedTab = TabControl1.TabPages(0)
            MsgBox("All videos in queue finished!", MsgBoxStyle.Information)
            ReloadQueue()
        Else
            TB_video_path.Text = queue(0)
            queue.RemoveAt(0)
            ReloadQueue()
        End If
    End Sub
#End Region

#Region "Reset"
    Private Sub Reset(Optional modi As String = "n")
        Control.CheckForIllegalCrossThreadCalls = False

        TB_video_path.Text = ""
        PB_state_progress.Maximum = 100
        PB_state_progress.Value = 0

        If modi = "n" Then
            TB_details_title.Text = ""
            TB_details_description.Text = ""
            TB_details_tags.Text = ""
        End If

        SetState(True)
    End Sub
#End Region

#Region "SetState"
    Private Sub SetState(ByVal state As Boolean)
        CB_user.Enabled = state
        BTN_adduser.Enabled = state
        TB_video_path.Enabled = state
        BTN_video_browse.Enabled = state
        BTN_video_dragdrop.Enabled = state
        TB_details_title.Enabled = state
        TB_details_description.Enabled = state
        TB_details_tags.Enabled = state
        CB_details_privacy.Enabled = state
        BTN_state_start.Enabled = state
        If CB_user.SelectedItem = "Default" Then
            BTN_removeuser.Enabled = False
        Else
            BTN_removeuser.Enabled = state ''AAA
        End If
    End Sub
#End Region

#End Region

#Region "MenuBar"

    Private Sub BTN_menubar_about_Click(sender As Object, e As EventArgs) Handles BTN_menubar_about.Click
        about.ShowDialog()
    End Sub

    Private Sub BTN_menubar_googledocs_Click(sender As Object, e As EventArgs) Handles BTN_menubar_googledocs.Click
        Process.Start("https://developers.google.com/youtube/v3/code_samples/dotnet")
    End Sub

#End Region

#Region "Start"
    Private Async Sub BTN_home_start_Click(sender As Object, e As EventArgs) Handles BTN_home_start.Click
        If File.Exists("client_secrets.json") Then
            Dim cred As UserCredential = Await CreateCredantional("Default")
            LB_home_state.Text = "Please login with your youtube account in your default browser..."
            If Not cred.Token.AccessToken = "" Then
                LB_home_state.Text = "Sucessfully logged in!"
                TabControl1.SelectedIndex = 1
            End If
        Else
            MsgBox("Please load your client_secrets.json file first!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub BTN_home_load_Click(sender As Object, e As EventArgs) Handles BTN_home_load.Click
        If OFD_clientsecrets.ShowDialog = DialogResult.OK Then
            If File.Exists("client_secrets.json") Then
                If MessageBox.Show("There is already a client_secrets loaded. Do you want to overwrite it?", "File already exists!", MessageBoxButtons.YesNo, icon:=MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                    File.Delete("client_secrets.json")
                Else
                    Exit Sub
                End If
            End If
            File.Copy(OFD_clientsecrets.FileName, "client_secrets.json")
        End If
    End Sub

    Private Sub LLB_getclientsecrets_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LLB_getclientsecrets.LinkClicked
        Process.Start("https://www.concrete5.org/marketplace/addons/ga-popular-pages/getting-client_secret.json/")
    End Sub
#End Region

#Region "Login"
    Private Sub CB_user_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_user.SelectedIndexChanged
        If CB_user.SelectedItem = "Default" Then
            BTN_removeuser.Enabled = False
        End If

        My.Settings.CB_user = CB_user.SelectedItem
    End Sub

    Private Sub BTN_adduser_Click(sender As Object, e As EventArgs) Handles BTN_adduser.Click
        new_user.ShowDialog()
    End Sub

    Private Sub BTN_removeuser_Click(sender As Object, e As EventArgs) Handles BTN_removeuser.Click
        CB_user.Items.Remove(CB_user.SelectedItem)
    End Sub
#End Region

#Region "Video Path"

    Private Sub BTN_video_browse_Click(sender As Object, e As EventArgs) Handles BTN_video_browse.Click
        If OFD_loadvideo.ShowDialog = DialogResult.OK Then
            TB_video_path.Text = OFD_loadvideo.FileName
        End If
    End Sub

#Region "Drag & Drop"
    Private Sub BTN_video_dragdrop_DragEnter(sender As Object, e As DragEventArgs) Handles BTN_video_dragdrop.DragEnter, BTN_queue_dragdrop.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub BTN_video_dragdrop_DragDrop(sender As Object, e As DragEventArgs) Handles BTN_video_dragdrop.DragDrop
        Dim count As Integer = 0
        For Each fi In e.Data.GetData(DataFormats.FileDrop)
            count += 1
        Next
        If count = 1 Then
            Dim file As FileInfo = New FileInfo(e.Data.GetData(DataFormats.FileDrop)(0))
            If file.Extension = ".mkv" Or file.Extension = ".webm" Or file.Extension = ".flv" Or file.Extension = ".avi" Or file.Extension = ".mov" Or file.Extension = ".mp4" Or file.Extension = ".mpg" Or file.Extension = ".mpeg" Or file.Extension = ".m4v" Then
                If file.FullName IsNot "" Then
                    TB_video_path.Text = file.FullName
                Else
                    MsgBox("Failed adding video!", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("The file you drag & dropped in isnt supportet! (Supportet formats: .mkv .webm .flv .avi .mov .mp4 .mpg .mpeg .m4v)", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Please only drag & drop one video!", MsgBoxStyle.Critical)
        End If
    End Sub
#End Region

#End Region

#Region "Video Details"
    Private Sub TB_details_title_TextChanged(sender As Object, e As EventArgs) Handles TB_details_title.TextChanged
        If TB_details_title.Text.Length >= 100 Then
            TB_details_title.Text = TB_details_title.Text.Substring(0, 99)
            MsgBox("The title length must be under 100!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub TB_details_description_TextChanged(sender As Object, e As EventArgs) Handles TB_details_description.TextChanged
        If TB_details_description.Text.Length >= 5000 Then
            TB_details_description.Text = TB_details_description.Text.Substring(0, 4999)
            MsgBox("The description length must be under 100!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub TB_details_tags_TextChanged(sender As Object, e As EventArgs) Handles TB_details_tags.TextChanged
        If TB_details_tags.Text.Length >= 400 Then
            TB_details_tags.Text = TB_details_tags.Text.Substring(0, 399)
            MsgBox("The tags length must be under 100!", MsgBoxStyle.Critical)
        End If
    End Sub
#End Region

#Region "State"

#Region "Start"
    Private Sub Start()
        If Not File.Exists(TB_video_path.Text) Then
            MsgBox("The video path you entered doesnt exist!", MsgBoxStyle.Critical)
            TB_video_path.Focus()
            Exit Sub
        End If
        If TB_details_title.Text = "" Or TB_details_title.Text.Count(Function(c As Char) c = " ") >= TB_details_title.Text.Length Then
            MsgBox("Please enter a valid title for your youtube video!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If TB_details_description.Text = "" Or TB_details_description.Text.Count(Function(c As Char) c = " ") >= TB_details_description.Text.Length Then
            MsgBox("Please enter a valid description for your youtube video!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        SetState(False)
        Upload(TB_details_title.Text, TB_details_description.Text, TB_details_tags.Text.Split(","), CB_user.SelectedItem, TB_video_path.Text, CB_details_privacy.SelectedItem)
    End Sub
#End Region

#Region "Buttons"
    Private Sub BTN_state_start_Click(sender As Object, e As EventArgs) Handles BTN_state_start.Click
        Start()
    End Sub

    Private Sub LB_CB_fluentqueue_info_Click(sender As Object, e As EventArgs) Handles LB_CB_fluentqueue_info.Click
        MsgBox($"Enables seamless transition between videos in queue (- usefull for bulk uploading videos). {vbCrLf}{vbCrLf}(Disables the notification for finishing a trimmed video)", MsgBoxStyle.Information)
    End Sub
#End Region

#End Region

#Region "Queue"

    Public Shared queue As New List(Of String)

#Region "Reload"
    Public Shared Sub ReloadQueuePublic()
        Main.ReloadQueue()
    End Sub

    Private Sub ReloadQueue()
        GB_queue.Text = "Loaded videos: " & queue.Count
        queue.Sort()

        FLY_queue.Controls.Clear()
        For Each item As String In queue
            Me.Invoke(CType(Sub() FLY_queue.Controls.Add(New UC_queue(item) With {.Name = item.Replace(" ", "_")}), MethodInvoker))
        Next
    End Sub
#End Region

#Region "Clear"
    Private Sub Clear()
        queue.Clear()
        ReloadQueue()
    End Sub
#End Region

#Region "Buttons"

    Private Sub BTN_queue_file_Click(sender As Object, e As EventArgs) Handles BTN_queue_file.Click
        LoadSingle()
    End Sub

    Private Sub BTN_queue_folder_Click(sender As Object, e As EventArgs) Handles BTN_queue_folder.Click
        LoadFolder()
    End Sub

    Private Sub BTN_clear_Click(sender As Object, e As EventArgs) Handles BTN_clear.Click
        Clear()
    End Sub

#Region "Drag & Drop"
    Private Sub BTN_queue_dragdrop_DragDrop(sender As Object, e As DragEventArgs) Handles BTN_queue_dragdrop.DragDrop
        For Each fi In e.Data.GetData(DataFormats.FileDrop)
            Dim file As FileInfo = New FileInfo(fi)
            If file.Extension = ".mkv" Or file.Extension = ".webm" Or file.Extension = ".flv" Or file.Extension = ".avi" Or file.Extension = ".mov" Or file.Extension = ".mp4" Or file.Extension = ".mpg" Or file.Extension = ".mpeg" Or file.Extension = ".m4v" Then
                If file.FullName IsNot "" Then
                    If queue.Contains(file.FullName) Then
                        MsgBox("Video already exists in queue!", MsgBoxStyle.Critical)
                    Else
                        Try
                            queue.Add(file.FullName)
                            ReloadQueue()

                            If TB_video_path.Text = "" Then
                                LoadNext()
                            End If
                        Catch ex As Exception
                            MsgBox("Failed adding video to queue!", MsgBoxStyle.Critical)
                        End Try
                    End If
                End If
            Else
                MsgBox("The file you drag & dropped in isnt supportet! (Supportet formats: .mkv .webm .flv .avi .mov .mp4 .mpg .mpeg .m4v)", MsgBoxStyle.Critical)
            End If
        Next
    End Sub
#End Region

#End Region

#End Region

End Class
