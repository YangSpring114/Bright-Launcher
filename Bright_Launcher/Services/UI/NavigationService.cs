using Bright_Launcher.Classes.Datas.Messaging;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bright_Launcher.Services.UI {
    public class NavigationService {
        private readonly string _baseNameSpace = "Bright_Launcher.Views.Pages.";

        public void Navigation(string key) {
            var page = App.ServiceProvider
                .GetService(Type.GetType($"{_baseNameSpace}{key}"));

            WeakReferenceMessenger.Default.Send(new PageMessage {
                Page = page,
                PageName = key
            });
        }
    }
}
