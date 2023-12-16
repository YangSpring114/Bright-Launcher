using Bright_Launcher.Classes.Datas;
using MinecraftLaunch.Extensions;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bright_Launcher.Services.Setting {
    public class SettingService {
        public SettingData Data { get; set; }

        public readonly string DataFilePath = Path.Combine(Environment.CurrentDirectory, 
            "setting.json");

        public SettingService() {
            Load();
        }

        private void Load() {
            var dataFileInfo = DataFilePath.ToFileInfo();
            if (!dataFileInfo.Directory.Exists) {
                dataFileInfo.Directory.Create();
            }

            if (dataFileInfo.Exists) {
                string json = File.ReadAllText(DataFilePath);
                Data = JsonSerializer.Deserialize<SettingData>(json)!;
            } else {
                _ = SaveAsync();
            }
        }

        public async ValueTask SaveAsync() {
            var json = JsonSerializer.Serialize(Data ?? new());
            await File.WriteAllTextAsync(DataFilePath, json);
        }
    }
}
