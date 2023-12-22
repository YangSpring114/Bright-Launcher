using Avalonia.Controls;

namespace Bright_Launcher.Views.Pages.Setting;

public partial class SettingPage : UserControl {
    public static SettingPage SP { get; set; }
    public SettingPage() {
        InitializeComponent();
        SP = this;
        FrameX.Content = new LaunchSettingPage();
    }
}