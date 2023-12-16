using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Threading.Tasks;
using MinecraftLaunch;
using MinecraftLaunch.Classes.Models.Auth;
namespace Bright_Launcher.Views.Pages;

public partial class DownloadPage : UserControl
{
    public Account UserInfo { get; private set; }
    public DownloadPage()
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