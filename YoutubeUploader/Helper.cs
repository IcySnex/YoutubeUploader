using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace YoutubeUploader
{
    class Helper
    {
        #region system
        public static bool IsValidFile(string path) { try { if (File.Exists(path)) { return true; } else { return false; } } catch { return false; } }
        #endregion

        #region string options
        public static string ApplyStropt(string str, string filename, j_stropt opt)
        {
            return str.Replace(opt.replacement, filename.Substring(RemoveL(opt.start, filename), RemoveL(opt.lenght, filename)).Replace('-', ' ').Trim());
        }
        public static string ApplyStropt(string str, string filename, List<j_stropt> opts)
        {
            foreach (j_stropt opt in opts) { str = ApplyStropt(str, filename, opt); }
            return str;
        }
        public static int RemoveL(string str, string filename)
        {
            try { return str.StartsWith("-") ? filename.Length - int.Parse(str.Substring(1)) : int.Parse(str); } 
            catch { return str.StartsWith("-") ? int.Parse(str.Substring(1)) : int.Parse(str); }
        }
        #endregion

        #region google
        async public static Task<UserCredential> CreateCredentials(string user)
        {
            using FileStream fs = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read); { return await GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.FromStream(fs).Secrets, new[] { YouTubeService.Scope.YoutubeUpload, YouTubeService.Scope.Youtube }, user, CancellationToken.None); }
        }
        async public static Task<bool> Upload(string title, string description, string[] tags, string privacy, string videoPath, string thumbnailPath, string[] playlists, UserCredential user, CancellationToken ct)
        {
            YouTubeService yts = new YouTubeService(new BaseClientService.Initializer() { HttpClientInitializer = user, ApplicationName = "YouTubeUploader" });
            Video video = new Video
            {
                Snippet = new VideoSnippet { Title = title, Description = description, Tags = tags, CategoryId = "22", },
                Status = new VideoStatus { MadeForKids = false, PrivacyStatus = privacy }
            };
            using FileStream fs = new FileStream(videoPath, FileMode.Open, FileAccess.Read);
            {
                MainWindow win = (MainWindow)Application.Current.MainWindow;
                VideosResource.InsertMediaUpload vr = yts.Videos.Insert(video, "snippet,status", fs, "video/*");
                vr.ProgressChanged += (IUploadProgress iup) =>
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            if (iup.Status == UploadStatus.NotStarted) { win.lb_state.Text = "Upload not startet..."; ; win.pg_state.Value = 0; }
                            else if (iup.Status == UploadStatus.Starting) { win.lb_state.Text = "Upload starting..."; ; win.pg_state.Value = 0; }
                            else if (iup.Status == UploadStatus.Uploading) { win.lb_state.Text = "Uploading..."; ; win.pg_state.Maximum = new FileInfo(videoPath).Length / 1000; win.pg_state.Value = iup.BytesSent / 1000; }
                            else if (iup.Status == UploadStatus.Failed) { win.lb_state.Text = "Upload failed..."; ; win.pg_state.Value = 0; MessageBox.Show($"Failed uploading video to youtube. (ex: \"{iup.Exception.Message}\")", "Error/Upload cancelled!", MessageBoxButton.OK, MessageBoxImage.Warning); win.LoadNext("", win.cb_fluentqueue.IsChecked.Value); }
                        });
                    };
                vr.ResponseReceived += async (Video video) =>
                    {
                        await Application.Current.Dispatcher.Invoke(async() =>
                        {
                            win.lb_state.Text = "Upload finished...";
                            if (!string.IsNullOrWhiteSpace(thumbnailPath))
                            {
                                win.lb_state.Text = "Setting Thumbnail..."; win.pg_state.Value = win.pg_state.Maximum;
                                using FileStream fs_ = new FileStream(thumbnailPath, FileMode.Open, FileAccess.Read);
                                {
                                    ThumbnailsResource.SetMediaUpload tr = yts.Thumbnails.Set(video.Id, fs_, "image/png");
                                    tr.ProgressChanged += (IUploadProgress iup) =>
                                        {
                                            Application.Current.Dispatcher.Invoke(() =>
                                            {
                                                if (iup.Status == UploadStatus.Failed) { MessageBox.Show($"Failed setting thumbnail on video (id: {video.Id}). (ex: \"{iup.Exception.Message}\")", "Error!", MessageBoxButton.OK, MessageBoxImage.Error); win.pg_state.Value = 0; }
                                            });
                                        };
                                    await tr.UploadAsync(ct);
                                }
                            }
                            if (playlists.Length > 0)
                            {
                                win.lb_state.Text = "Adding video to playlist(s)..."; win.pg_state.Value = win.pg_state.Maximum;
                                foreach (string pl in playlists)
                                {
                                    PlaylistItem playlist = new PlaylistItem() { Snippet = new PlaylistItemSnippet() { PlaylistId = pl, ResourceId = new ResourceId() { Kind = "youtube#video", VideoId = video.Id } } };
                                    playlist = await yts.PlaylistItems.Insert(playlist, "snippet").ExecuteAsync();
                                }
                            }
                            win.lb_state.Text = "Finished Video..."; win.pg_state.Value = win.pg_state.Maximum;
                            if (!win.cb_fluentqueue.IsChecked.Value) { MessageBox.Show($"Upload finished (id: {video.Id}).", "Done!", MessageBoxButton.OK, MessageBoxImage.Information); }
                            win.LoadNext("", win.cb_fluentqueue.IsChecked.Value);
                        });
                    };
                await vr.UploadAsync(ct);
                return true;
            }
        }
        #endregion
    }
}
