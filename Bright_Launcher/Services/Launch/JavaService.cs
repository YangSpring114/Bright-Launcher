using MinecraftLaunch.Classes.Models.Game;
using MinecraftLaunch.Components.Fetcher;
using System.Collections.Generic;

namespace Bright_Launcher.Services.Launch {
    public class JavaService {
        private JavaFetcher _javaFetcher = new();

        public IEnumerable<JavaEntry> FindJava() {
            return _javaFetcher.Fetch();
        }
    }
}
