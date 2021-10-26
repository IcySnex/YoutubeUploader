using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace YoutubeUploader
{
    public partial class MainWindow : Window
    {
        #region main
        public MainWindow()
        {
            InitializeComponent();
            foreach (string s in Settings.value.users)
            {
                if (s == Settings.value.user) { cb_user.SelectedIndex = cb_user.Items.Add(s); } else { cb_user.Items.Add(s); }
            }
            if (cb_user.SelectedIndex == -1) { cb_user.SelectedIndex = 0; }
            tb_details_title.Text = Settings.value.details.title;
            tb_details_description.Text = Settings.value.details.description;
            tb_details_tags.Text = Settings.value.details.tags;
            cb_fluentqueue.IsChecked = Settings.value.fluentqueue;
            cb_privacy.SelectedIndex = Settings.value.details.privacy;
            tb_details_thumbnail.Text = Settings.value.details.thumbnail;
            tb_details_playlist.Text = Settings.value.details.playlist;
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Settings.value.details.thumbnail = tb_details_thumbnail.Text;
            Settings.value.details.privacy = cb_privacy.SelectedIndex;
            Settings.value.fluentqueue = cb_fluentqueue.IsChecked.Value;
            Settings.value.details.title = tb_details_title.Text;
            Settings.value.details.description = tb_details_description.Text;
            Settings.value.details.tags = tb_details_tags.Text;
            Settings.value.details.playlist = tb_details_playlist.Text;
            Settings.Save();
        }
        #endregion

        #region top bar
        private void btn_about(object sender, RoutedEventArgs e) => Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName = "https://github.com/IcySnex/YoutubeUploader" });
        private void btn_googledoc(object sender, RoutedEventArgs e) => Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName = "https://developers.google.com/youtube/v3/code_samples/dotnet" });
        #endregion

        #region home
        private async void btn_start(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("client_secrets.json"))
            {
                if (MessageBox.Show("There is no \"client_secrets.json\" file, do you want to load one?", "Error!", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes) { btn_loadclientsecrets(sender, e); return; } else { return; }
            }
            lb_loginstatus.Text = "Please login with your youtube account in your default browser...";
            if ((await Helper.CreateCredentials(cb_user.SelectedItem.ToString())).Token.AccessToken != "")
            {
                tbc.SelectedIndex = 1;
            }
        }
        private void btn_loadclientsecrets(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog { CheckFileExists = true, Title = "Please choose your \"client_secrets.json\" file.", FileName = "client_secrets.json", Filter = "client_secrets|*.json" };
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists("client_secrets.json")) { if (MessageBox.Show("There is already a \"client_secrets.json\" file, do you want to overwrite it?", "File already exists!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes) { File.Delete("client_secrets.json"); } else { return; } }
                File.Copy(ofd.FileName, "client_secrets.json");
            }
        }
        private void lb_getclientsecrets(object sender, MouseButtonEventArgs e) => Process.Start(new ProcessStartInfo() { UseShellExecute = true, FileName = "https://marketplace.concretecms.com/marketplace/addons/ga-popular-pages/getting-client_secret.json/" });
        #endregion

        #region user
        private void cb_user_changed(object sender, SelectionChangedEventArgs e)
        {
            btn_user_remove.IsEnabled = cb_user.SelectedIndex != 0;
            if (cb_user.SelectedIndex != -1) { Settings.value.user = cb_user.SelectedIndex == 0 ? "Default" : cb_user.SelectedItem.ToString(); }
        }
        private void btn_user_remove_Click(object sender, RoutedEventArgs e)
        {
            Settings.value.users.Remove(cb_user.SelectedItem.ToString());
            cb_user.Items.RemoveAt(cb_user.SelectedIndex);
            cb_user.SelectedIndex = 0;
        }
        private async void dg_createuser_ok(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_createuser_ok.Text)) { MessageBox.Show("Username cannot be empty.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error); dg_createuser.IsOpen = false; return; }
            if ((await Helper.CreateCredentials(tb_createuser_ok.Text)).Token.AccessToken != "")
            {
                cb_user.SelectedIndex = cb_user.Items.Add(tb_createuser_ok.Text);
                Settings.value.users.Add(tb_createuser_ok.Text);
                dg_createuser.IsOpen = false;
            }
            else { MessageBox.Show("Something went wrong.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error); dg_createuser.IsOpen = false; return; }
        }
        #endregion

        #region details
        private void btn_details_title(object sender, RoutedEventArgs e)
        {
            lb_stropt.Text = "String Options (Title)";
            stropt_clear();
            foreach (j_stropt stropt in Settings.value.details.stropt_title) { sp_stropt.Children.Add(new UC_stropt(stropt)); }
            sp_stropt.Children[0].Visibility = sp_stropt.Children.Count == 1 ? Visibility.Visible : Visibility.Collapsed;
            dg_stropt.IsOpen = true;
        }
        private void btn_details_desc(object sender, RoutedEventArgs e)
        {
            lb_stropt.Text = "String Options (Description)";
            stropt_clear();
            foreach (j_stropt stropt in Settings.value.details.stropt_description) { sp_stropt.Children.Add(new UC_stropt(stropt)); }
            sp_stropt.Children[0].Visibility = sp_stropt.Children.Count == 1 ? Visibility.Visible : Visibility.Collapsed;
            dg_stropt.IsOpen = true;
        }
        private void btn_details_tags(object sender, RoutedEventArgs e)
        {
            lb_stropt.Text = "String Options (Tags)";
            stropt_clear();
            foreach (j_stropt stropt in Settings.value.details.stropt_tags) { sp_stropt.Children.Add(new UC_stropt(stropt)); }
            sp_stropt.Children[0].Visibility = sp_stropt.Children.Count == 1 ? Visibility.Visible : Visibility.Collapsed;
            dg_stropt.IsOpen = true;
        }
        private void btn_details_thumbnail(object sender, RoutedEventArgs e)
        {
            lb_stropt.Text = "String Options (Thumbnail)";
            stropt_clear();
            foreach (j_stropt stropt in Settings.value.details.stropt_thumbnail) { sp_stropt.Children.Add(new UC_stropt(stropt)); }
            sp_stropt.Children[0].Visibility = sp_stropt.Children.Count == 1 ? Visibility.Visible : Visibility.Collapsed;
            dg_stropt.IsOpen = true;
        }

        private void btn_stropt_save(object sender, RoutedEventArgs e)
        {
            if (lb_stropt.Text == "String Options (Title)")
            {
                Settings.value.details.stropt_title.Clear();
                foreach (UC_stropt child in sp_stropt.Children.OfType<UIElement>().Where(ui => ui.GetType() == typeof(UC_stropt)))
                {
                    Settings.value.details.stropt_title.Add(new j_stropt { replacement = child.replacement.Text, start = child.start.Text, lenght = child.lenght.Text });
                }
            }
            else if (lb_stropt.Text == "String Options (Description)")
            {
                Settings.value.details.stropt_description.Clear();
                foreach (UC_stropt child in sp_stropt.Children.OfType<UIElement>().Where(ui => ui.GetType() == typeof(UC_stropt)))
                {
                    Settings.value.details.stropt_description.Add(new j_stropt { replacement = child.replacement.Text, start = child.start.Text, lenght = child.lenght.Text });
                }
            }
            else if (lb_stropt.Text == "String Options (Tags)")
            {
                Settings.value.details.stropt_tags.Clear();
                foreach (UC_stropt child in sp_stropt.Children.OfType<UIElement>().Where(ui => ui.GetType() == typeof(UC_stropt)))
                {
                    Settings.value.details.stropt_tags.Add(new j_stropt { replacement = child.replacement.Text, start = child.start.Text, lenght = child.lenght.Text });
                }
            }
            else if (lb_stropt.Text == "String Options (Thumbnail)")
            {
                Settings.value.details.stropt_thumbnail.Clear();
                foreach (UC_stropt child in sp_stropt.Children.OfType<UIElement>().Where(ui => ui.GetType() == typeof(UC_stropt)))
                {
                    Settings.value.details.stropt_thumbnail.Add(new j_stropt { replacement = child.replacement.Text, start = child.start.Text, lenght = child.lenght.Text });
                }
            }
            dg_stropt.IsOpen = false;
        }
        private void btn_stropt_add(object sender, RoutedEventArgs e)
        {
            sp_stropt.Children.Add(new UC_stropt(new j_stropt()));
            sp_stropt.Children[0].Visibility = Visibility.Collapsed;

        }
        private void stropt_clear()
        {
            sp_stropt.Children.Clear();
            sp_stropt.Children.Add(new TextBlock { Text = "Press 'Add More' to add a string option", Foreground = Brushes.LightGray, HorizontalAlignment = HorizontalAlignment.Center, FontSize = 15, Margin = new Thickness(0, 90, 0, 0) });
        }

        private void btn_details_thumbnail_browse(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog { CheckFileExists = true, Title = "Please choose a thumbnail.", Filter = "Image Files|*.png;*.jpeg;*:jpg;*" };
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) { tb_details_thumbnail.Text = ofd.FileName; }
        }
        #endregion

        #region load direct
        System.Windows.Forms.OpenFileDialog ofd_single = new System.Windows.Forms.OpenFileDialog { CheckFileExists = true, Title = "Please choose a video you want to load.", Filter = "Youtube-supported video formats|*.mkv;*.webm;*.flv;*.avi;*.mov;*.mp4;*.mpg;*.mpeg;*.m4v" };
        System.Windows.Forms.FolderBrowserDialog ofd_multi = new System.Windows.Forms.FolderBrowserDialog() { UseDescriptionForTitle = true, Description = "Please choose a folder you want to load." };
        private void btn_video_browse(object sender, RoutedEventArgs e) { if (ofd_single.ShowDialog() == System.Windows.Forms.DialogResult.OK) { LoadNext(ofd_single.FileName); } }
        private void btn_video_drop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) { MessageBox.Show("Please drop a supported video format. Supported video formats are: '.mkv, .webm, .flv, .avi, .mov, .mp4, .mpg, .mpeg, .m4v'.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            FileInfo file = new FileInfo(((string[])e.Data.GetData(DataFormats.FileDrop)).FirstOrDefault());
            if (".mkv.webm.flv.avi.mov.mp4.mpg.mpeg.m4v".Contains(file.Extension)) { LoadNext(file.FullName); } else { MessageBox.Show("Please drop a supported video format. Supported video formats are: '.mkv, .webm, .flv, .avi, .mov, .mp4, .mpg, .mpeg, .m4v'.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
        #endregion

        #region queue
        private void btn_queue_file(object sender, RoutedEventArgs e) { if (ofd_single.ShowDialog() == System.Windows.Forms.DialogResult.OK) { LoadToQueue(ofd_single.FileName); } }
        private void btn_queue_folder(object sender, RoutedEventArgs e)
        {
            if (ofd_multi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string file in Directory.GetFiles(ofd_multi.SelectedPath)) { LoadToQueue(file); }
            }
        }
        private void btn_queue_drop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) { MessageBox.Show("Please drop a supported video format. Supported video formats are: '.mkv, .webm, .flv, .avi, .mov, .mp4, .mpg, .mpeg, .m4v'.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            foreach (string fil in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                FileInfo file = new FileInfo(fil);
                if (".mkv.webm.flv.avi.mov.mp4.mpg.mpeg.m4v".Contains(file.Extension)) { LoadToQueue(file.FullName); } else { MessageBox.Show("Please drop a supported video format. Supported video formats are: '.mkv, .webm, .flv, .avi, .mov, .mp4, .mpg, .mpeg, .m4v'.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }

        private void btn_queue_clear(object sender, RoutedEventArgs e)
        {
            sp_queue.Children.Clear();
            gb_queue.Header = "Queue | Loaded: 0";
            MessageBox.Show("Cleared the entire queue.", "Queue Cleared!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void LoadToQueue(string path)
        {
            sp_queue.Children.Add(new UC_queue(path));
            gb_queue.Header = $"Queue | Loaded: {sp_queue.Children.Count}";
            if (string.IsNullOrWhiteSpace(tb_video_path.Text)) { LoadNext(); }
        }
        public void LoadNext(string path = "", bool start = false)
        {
            if (path != "") { tb_video_path.Text = path; }
            else
            {
                if (sp_queue.Children.Count == 0) { MessageBox.Show($"Finished uploading the entire queue!)", "Queue finished!", MessageBoxButton.OK, MessageBoxImage.Information); return; }
                tb_video_path.Text = ((UC_queue)sp_queue.Children[0]).tb_path.Text;
                sp_queue.Children.RemoveAt(0);
            }
            if (start) { btn_state(this, null); }
        }
        #endregion

        #region state
        CancellationTokenSource ct = new CancellationTokenSource();
        private async void btn_state(object sender, RoutedEventArgs e)
        {
            if (btn_state_.Content.ToString() == "Start")
            {
                if (string.IsNullOrWhiteSpace(tb_video_path.Text)) { MessageBox.Show($"Please first load a video you want to upload. (\"{tb_video_path.Text}\")", "Error!", MessageBoxButton.OK, MessageBoxImage.Error); return; }
                if (!Helper.IsValidFile(tb_video_path.Text)) { MessageBox.Show($"Loaded video does not exist. (\"{tb_video_path.Text}\")", "Error!", MessageBoxButton.OK, MessageBoxImage.Error); return; }
                string filename = new FileInfo(tb_video_path.Text).Name;
                string title = Helper.ApplyStropt(tb_details_title.Text, filename, Settings.value.details.stropt_title);
                string description = Helper.ApplyStropt(tb_details_description.Text, filename, Settings.value.details.stropt_description);
                string tags = Helper.ApplyStropt(tb_details_tags.Text, filename, Settings.value.details.stropt_tags);
                string thumbnail = Helper.ApplyStropt(tb_details_thumbnail.Text, filename, Settings.value.details.stropt_thumbnail);
                if (string.IsNullOrWhiteSpace(title) | string.IsNullOrWhiteSpace(description)) { MessageBox.Show($"Title/Description cannot be empty. (\"{title}\" | \"{description}\")", "Error!", MessageBoxButton.OK, MessageBoxImage.Error); return; }
                if (!string.IsNullOrWhiteSpace(thumbnail) && !Helper.IsValidFile(thumbnail)) { MessageBox.Show($"Loaded Thumbnail does not exist. (\"{thumbnail}\")", "Error!", MessageBoxButton.OK, MessageBoxImage.Error); return; }

                ui(false);
                await Helper.Upload(title, description, tags.Split(','), cb_privacy.Text, tb_video_path.Text, thumbnail, tb_details_playlist.Text.Split(','), await Helper.CreateCredentials(cb_user.SelectedItem.ToString()), ct.Token);
                tb_video_path.Text = "";
                ui(true);
            }
            else
            {
                ct.Cancel();
                ui(true);
            }
        }

        public void ui(bool mode)
        {
            cb_user.IsEnabled = mode;
            btn_user_remove.IsEnabled = cb_user.SelectedIndex == 0 ? false : mode;
            btn_user_create.IsEnabled = mode;
            btn_video_browse_.IsEnabled = mode;
            btn_video_drop_.IsEnabled = mode;
            tb_details_title.IsReadOnly = !mode;
            tb_details_description.IsReadOnly = !mode;
            tb_details_tags.IsReadOnly = !mode;
            tb_details_thumbnail.IsReadOnly = !mode;
            tb_details_playlist.IsReadOnly = !mode;
            btn_details_title_.IsEnabled = mode;
            btn_details_desc_.IsEnabled = mode;
            btn_details_tags_.IsEnabled = mode;
            cb_privacy.IsEnabled = mode;
            btn_details_thumbnail_.IsEnabled = mode;
            btn_details_thumbnail_browse_.IsEnabled = mode;
            btn_state_.Content = mode ? "Start" : "Stop";
        }
        #endregion

        #region string options
        private void btn_stropt(object sender, RoutedEventArgs e) => dg_copystropt.IsOpen = true;
        private void btn_copystropt(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_video_path.Text)) { MessageBox.Show($"Please first load a video you want to upload. (\"{tb_video_path.Text}\")", "Error!", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            if (!Helper.IsValidFile(tb_video_path.Text)) { MessageBox.Show($"Loaded video does not exist. (\"{tb_video_path.Text}\")", "Error!", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            string filename = new FileInfo(tb_video_path.Text).Name;
            if (((Button)sender).Content.ToString() == "Title")
            {Clipboard.SetText(Helper.ApplyStropt(tb_details_title.Text, filename, Settings.value.details.stropt_title));
            } else if (((Button)sender).Content.ToString() == "Description")
            { Clipboard.SetText(Helper.ApplyStropt(tb_details_description.Text, filename, Settings.value.details.stropt_description));
            } else if (((Button)sender).Content.ToString() == "Tags")
            { Clipboard.SetText(Helper.ApplyStropt(tb_details_tags.Text, filename, Settings.value.details.stropt_tags));
            } else if (((Button) sender).Content.ToString() == "Thumbnail")
            { Clipboard.SetText(Helper.ApplyStropt(tb_details_thumbnail.Text, filename, Settings.value.details.stropt_thumbnail)); }
        }
        #endregion
    }
}
