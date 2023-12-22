using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Bright_Launcher.Services.Setting;
using Bright_Launcher.Classes.Attributes;
using MinecraftLaunch.Classes.Models.Game;
using CommunityToolkit.Mvvm.ComponentModel;
using Bright_Launcher.Services.Launch;
using System.Threading.Tasks;

namespace Bright_Launcher.ViewModels.Pages.Setting {
    public partial class LaunchSettingPageViewModel : SettingPageViewModelBase {
        private JavaService _javaService;
        private SettingService _settingService;

        public LaunchSettingPageViewModel(SettingService settingService, JavaService javaService) : base(settingService) {
            _javaService = javaService;
            _settingService = settingService;
        }
        
        [ObservableProperty]
        [property:BindToSetting(ConfigName = nameof(Javas))]
        public ObservableCollection<JavaEntry> javas;

        [RelayCommand]
        private async Task FindJava() {
            var result = await Task.Run(() => {
                return _javaService.FindJava();
            });

            Javas = new(result);
        }
    }
}
