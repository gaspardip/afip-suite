using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiAp_Parser.Settings
{
    public class OutputConfig
    {
        public OutputConfig(string defaultFolder = "Generado")
        {
            this.DialogFilter = this.DialogFilter = "Archivos de texto|*.txt";
            this.VouchersSaveFileDialogTitle = "Guardar comprobantes";
            this.AliquotsSaveFileDialogTitle = "Guardar alicuotas";
            this.Directory = Path.Combine(Application.StartupPath, defaultFolder);
        }

        public string Directory { get; set; }

        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                this.FilePath = Path.Combine(this.Directory, this._fileName);
            }
        }
        public string FilePath { get; private set; }
        public string DialogFilter { get; set; }
        public string DefaultFileName { get { return DateTime.Now.ToString("yyyyMMddHHmmss"); } }
        public string VouchersSaveFileDialogTitle { get; set; }
        public string AliquotsSaveFileDialogTitle { get; set; }
    }
}
