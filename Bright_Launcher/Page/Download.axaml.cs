using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MinecraftLaunch.Modules.Installer;
using System;
using System.Threading.Tasks;
using MinecraftLaunch;
using MinecraftLaunch.Modules.Models.Launch;
using MinecraftLaunch.Modules.Models.Auth;

namespace Bright_Launcher;

public partial class Download : UserControl
{
    public static LaunchConfig LaunchConfig { get; } = new LaunchConfig();
    public Account UserInfo { get; private set; }
    public Download()
    {
        InitializeComponent();
    }

    private void VersionsListSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (VersionsList != null)
        {
            ListBoxItem Items = VersionsList.SelectedItem as ListBoxItem;
            Version.Text = Items.Content.ToString();
        }

    }

}