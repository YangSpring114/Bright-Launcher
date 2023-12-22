using System.Reflection;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Bright_Launcher.Classes.Attributes;
using CommunityToolkit.Mvvm.ComponentModel;
using Bright_Launcher.Classes.Datas.Messaging;
using Bright_Launcher.Services.Setting;
using System.Linq;
using System.Collections.Generic;

namespace Bright_Launcher.ViewModels.Pages.Setting {
    public class SettingPageViewModelBase : ObservableObject {
        private Dictionary<string, PropertyInfo> _properties;

        public SettingPageViewModelBase(SettingService settingService) {
            _properties = GetType()
                .GetProperties()
                .Where(x => x.GetCustomAttribute<BindToSettingAttribute>() is not null)
                .ToDictionary(x => x.Name, x => x);

            var settingProperties = settingService.Data
                .GetType()
                .GetProperties();

            foreach (var propertyA in _properties.Values) {
                propertyA.SetValue(this, settingProperties.FirstOrDefault(x => x.Name == propertyA.Name)
                    .GetValue(settingService.Data));
            }

            PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (_properties.TryGetValue(e.PropertyName, out var propertyInfo)) {
                WeakReferenceMessenger.Default.Send(new PropertyChangedMessage {
                    Name = e.PropertyName,
                    Value = propertyInfo.GetValue(this)
                });
            }
        }
    }
}
