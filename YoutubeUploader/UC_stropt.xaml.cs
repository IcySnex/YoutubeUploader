using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace YoutubeUploader
{
    public partial class UC_stropt : UserControl
    {
        string changed = "";
        public UC_stropt(j_stropt stropt)
        {
            InitializeComponent();
            replacement.Text = stropt.replacement;
            start.Text = stropt.start.ToString();
            lenght.Text = stropt.lenght.ToString();
            changed = $"{stropt.start}:{stropt.lenght}";
        }

        private void btn_remove(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Application.Current.MainWindow;
            win.sp_stropt.Children.Remove(this);
            win.sp_stropt.Children[0].Visibility = win.sp_stropt.Children.Count == 1 ? Visibility.Visible : Visibility.Collapsed;
        }

        private void replacementfocus(object sender, RoutedEventArgs e) { if (string.IsNullOrWhiteSpace(replacement.Text)) { MessageBox.Show("{Replacement} cannot be empty.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error); replacement.Text = "{replacement}"; } }
    }
}
