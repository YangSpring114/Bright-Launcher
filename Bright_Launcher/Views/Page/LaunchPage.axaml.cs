using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MinecraftLaunch;

namespace Bright_Launcher.Views.Pages;

public partial class LaunchPage : UserControl
{
    public LaunchPage()
    {
        InitializeComponent();
    }

    private void VersionsSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(Versions.SelectedItem != null)
        {
            ComboBoxItem Item = Versions.SelectedItem as ComboBoxItem;
            Version.Text = Item.Content.ToString();
        }

    }

}