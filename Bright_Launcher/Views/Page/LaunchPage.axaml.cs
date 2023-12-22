using Avalonia.Controls;
using Bright_Launcher.ViewModels.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace Bright_Launcher.Views.Pages;

public partial class LaunchPage : UserControl {
    public LaunchPage() {
        InitializeComponent();
        DataContext = App.ServiceProvider.GetService<LaunchPageViewModel>();
    }
}