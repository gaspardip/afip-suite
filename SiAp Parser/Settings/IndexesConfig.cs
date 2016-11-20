using System;
using System.IO;
using System.Windows.Forms;
using SiAp_Parser.Serialization;

namespace SiAp_Parser.Settings
{
    public class IndexesConfig
    {
        public IndexesConfig()
        {
            this.DialogFilter = "Archivos XML|*.xml";
            this.SaveFileDialogTitle = "Guardar preferencias";
            this.OpenFileDialogTitle = "Cargar preferencias";
            this.Directory = Path.Combine(Application.StartupPath, "Indices");
        }

        public string DialogFilter { get; set; }
        public string OpenFileDialogTitle { get; set; }
        public string SaveFileDialogTitle { get; set; }
        public string Directory { get; set; }
        public string IndexFileDefaultName { get { return DateTime.Now.ToString("yyyyMMddHHmmss"); } }
    }
}
