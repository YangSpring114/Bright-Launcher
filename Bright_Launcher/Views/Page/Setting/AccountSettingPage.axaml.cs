using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Bright_Launcher.Views.Pages.Setting;

public partial class AccountSettingPage : UserControl
{
    public AccountSettingPage()
    {
        InitializeComponent();
    }

    private void Back(object sender, RoutedEventArgs e)
    {
        SettingPage.SP.FrameX.Content = new LaunchSettingPage();
    }
}