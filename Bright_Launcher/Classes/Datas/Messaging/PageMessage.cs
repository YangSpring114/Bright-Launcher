using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bright_Launcher.Classes.Datas.Messaging {
    public record PageMessage {
        public object Page { get; set; }

        public string PageName { get; set; }
    }
}
