using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Bright_Launcher.ViewModels.Windows;
using Bright_Launcher.Views.Pages.Setting;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Net.Http;

namespace Bright_Launcher.Views.Pages {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void MainWindow_PointerEnter(object sender, PointerEventArgs e) {
            GridX.Margin = new Thickness(0, 20, 0, 0);
            foreach (var item in Buttons.Children) {
                item.Height = 30;
            }
        }

        private void MainWindow_PointerLeave(object sender, PointerEventArgs e) {
            GridX.Margin = new Thickness(0, 0, 0, 0);
            foreach (var item in Buttons.Children) {
                item.Height = 0;
            }
        }
    }
}