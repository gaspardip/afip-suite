using System;
using System.IO;
using System.Windows.Forms;

namespace SIAP.Parser.Settings
{
    public class OutputConfig
    {
        public OutputConfig(string defaultFolder = "Generado")
        {
            this.VouchersSaveFileDialogTitle = "Guardar comprobantes";
            this.AliquotsSaveFileDialogTitle = "Guardar alicuotas";
            this.Directory = Path.Combine(Application.StartupPath, defaultFolder);
        }

        public string Directory { get; set; }

        private string _fileName;
        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                this.FilePath = Path.Combine(this.Directory, this._fileName);
            }
        }
        public string FilePath { get; private set; }
        public static string DefaultFileName => DateTime.Now.ToString("yyyyMMddHHmmss");
        public string VouchersSaveFileDialogTitle { get; set; }
        public string AliquotsSaveFileDialogTitle { get; set; }
    }
}
