using System.IO;
using System.Windows.Forms;

namespace SiAp_Parser.Settings
{
    public class PreferencesConfig
    {
        public PreferencesConfig()
        {
            this.Directory = Path.Combine(Application.StartupPath, "Config");
            this.Filename = "config.xml";
            this.FilePath = Path.Combine(this.Directory, this.Filename);
        }

        public string Directory { get; set; }
        public string Filename { get; set; }
        public string FilePath { get; set; }
    }
}
