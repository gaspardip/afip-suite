using System;
using System.IO;
using System.Windows.Forms;

namespace SIAP.Parser.Settings
{
    public class IndexesConfig
    {
        public IndexesConfig()
        {
            DialogFilter = "Archivos XML|*.xml";
            SaveFileDialogTitle = "Guardar preferencias";
            OpenFileDialogTitle = "Cargar preferencias";
            Directory = Path.Combine(Application.StartupPath, "Indices");
        }

        public string DialogFilter { get; set; }
        public string OpenFileDialogTitle { get; set; }
        public string SaveFileDialogTitle { get; set; }
        public string Directory { get; set; }
        public string IndexFileDefaultName => DateTime.Now.ToString("yyyyMMddHHmmss");
    }
}
