using MinecraftLaunch.Classes.Models.Auth;
using System.Collections.ObjectModel;

namespace Bright_Launcher.Classes.Datas {
    public record SettingData {
        public string JavaPath { get; set; }

        public string Javas { get; set; }

        public ObservableCollection<Account> Accounts { get; set; }

        public Account Account { get; set; }
    }
}
