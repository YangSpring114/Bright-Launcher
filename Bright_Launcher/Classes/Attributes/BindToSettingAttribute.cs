using System;

namespace Bright_Launcher.Classes.Attributes {
    public class BindToSettingAttribute : Attribute {
        public string ConfigName { get; init; }
    }
}
