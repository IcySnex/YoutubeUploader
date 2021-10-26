using System.Windows;
using System.Windows.Controls;

namespace YoutubeUploader
{
    /// <summary>
    /// Interaction logic for UC_queu.xaml
    /// </summary>
    public partial class UC_queue : UserControl
    {
        public UC_queue(string path)
        {
            InitializeComponent();
            tb_path.Text = path;
        }

        private void btn_remove(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Application.Current.MainWindow;
            win.sp_queue.Children.Remove(this);
        }
    }
}
