using Bright_Launcher.Classes.Datas.Messaging;
using Bright_Launcher.Services.UI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Bright_Launcher.ViewModels.Windows {
    public partial class MainWindowViewModel : ObservableObject {
        private NavigationService _navigationService;

        public MainWindowViewModel(NavigationService navigationService) {
            _navigationService = navigationService;

            WeakReferenceMessenger.Default.Register<PageMessage>(this, HandleMessage);
            _navigationService.Navigation("LaunchPage");
        }

        [ObservableProperty]
        private object content;

        [RelayCommand]
        private void Navigation(string name) {
            _navigationService?.Navigation(name);
        }

        private void HandleMessage(object obj, PageMessage message) {
            Content = message.Page;
        }
    }
}
