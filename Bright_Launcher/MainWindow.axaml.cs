using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System.IO;
using System.Net.Http;

namespace Bright_Launcher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_PointerEnter(object? sender, PointerEventArgs e)
        {
            GridX.Margin = new Thickness(0, 20, 0, 0);
            DownloadButton.Height = 30;
            HomeButton.Height = 30;
            TZButton.Height = 30;
            NATButton.Height = 30;
            SetButton.Height = 30;
        }

        private void MainWindow_PointerLeave(object? sender, PointerEventArgs e)
        {
            GridX.Margin = new Thickness(0, 0, 0, 0);
            HomeButton.Height = 0;
            DownloadButton.Height = 0;
            TZButton.Height = 0;
            NATButton.Height = 0;
            SetButton.Height = 0;
        }

        private void LaunchP(object sender, RoutedEventArgs e)
        {
            FrameX.Content = new Launch();
        }

        private void ExpandP(object sender, RoutedEventArgs e)
        {
            FrameX.Content = new Expand();
        }

        private void DownloadP(object sender, RoutedEventArgs e)
        {
            FrameX.Content = new Download();
        }

        private void SettingP(object sender, RoutedEventArgs e)
        {
            FrameX.Content = new SettingPage();
        }
    }
}