using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Bright_Launcher;

public partial class Account : UserControl
{
    public Account()
    {
        InitializeComponent();
    }

    private void Back(object sender, RoutedEventArgs e)
    {
        SettingPage.SP.FrameX.Content = new LaunchSettingPage();
    }
}