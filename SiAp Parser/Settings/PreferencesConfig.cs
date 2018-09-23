using System.IO;
using System.Windows.Forms;

namespace SIAP.Parser.Settings
{
    public class PreferencesConfig
    {
        public PreferencesConfig()
        {
            Directory = Path.Combine(Application.StartupPath, "Config");
            Filename = "config.xml";
            FilePath = Path.Combine(Directory, Filename);
        }

        public string Directory { get; set; }
        public string Filename { get; set; }
        public string FilePath { get; set; }
    }
}
