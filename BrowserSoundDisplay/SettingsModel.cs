using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserSoundDisplay
{
    public class SettingsModel
    {
        public string BackgroundColour { get; set; }
        public string TextFont { get; set; }
        public string TextColour { get; set; }
        public string TextSize { get; set; }
        public string MusicBrowser { get; set; }
        public List<ItemModel> PlaylistInfo { get; set; }
    }
}
