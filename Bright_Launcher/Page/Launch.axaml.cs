using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MinecraftLaunch.Launch;
using MinecraftLaunch;

namespace Bright_Launcher;

public partial class Launch : UserControl
{
    public Launch()
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