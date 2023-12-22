using System.Linq;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Bright_Launcher.Services.Launch;
using MinecraftLaunch.Classes.Models.Game;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Bright_Launcher.ViewModels.Pages {
    public partial class LaunchPageViewModel : ObservableObject {
        private GameService _gameService;
        private LaunchService _launchService;

        [ObservableProperty]
        private GameEntry gameEntry;

        [ObservableProperty]
        private ObservableCollection<GameEntry> gameEntries;

        public LaunchPageViewModel(LaunchService launchService, GameService gameService) {
            _gameService = gameService;
            _launchService = launchService;
            
            PropertyChanged += OnPropertyChanged;
            GameEntries = [.. gameService.Load()];
            GameEntry = gameEntries.FirstOrDefault();
        }

        [RelayCommand(CanExecute = nameof(CanExecuteLaunch))]
        private void Launch() {
            _launchService.LaunchGame();
        }

        private bool CanExecuteLaunch() => GameEntry is not null;

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (e.PropertyName is nameof(GameEntry)) {
                _gameService.ActiveGameEntry = GameEntry;
            }
        }
    }
}

