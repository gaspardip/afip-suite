using SiAp_Parser.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SiAp_Parser.Settings
{
    [Serializable]
    [XmlRoot("settings")]
    [XmlInclude(typeof(Setting<bool>))]
    [XmlInclude(typeof(Setting<ushort>))]
    [XmlInclude(typeof(Setting<string>))]
    public class Settings
    {
        public Settings()
        {
            ValidateRowsBasedOnDate = new Setting<bool>(true);
            SalesPointAndVoucherNumberInTheSameColumn = new Setting<bool>(true);
            GenerateVouchersNumbersIfMissing = new Setting<bool>(true);
            LoadLastIndexesUsed = new Setting<bool>(false);
            LastIndexesUsedPath = new Setting<string>(string.Empty);
            LastBookTypeUsed = new Setting<TiposLibro>(TiposLibro.UNDEFINED);
            SaveOnExit = new Setting<bool>(true);
            ShowResults = new Setting<bool>(false);
            OutputPath = new Setting<string>(string.Empty);
            AutoSaveLogs = new Setting<bool>(true);
            LastFileUsedPath = new Setting<string>(string.Empty);
            GetMissingFieldsAutomatically = new Setting<bool>(true);
        }

        public override bool Equals(object obj)
        {
            var s = obj as Settings;

            if (s == null)
                return false;

            return
                (ValidateRowsBasedOnDate.Value == s.ValidateRowsBasedOnDate.Value) &&
                (SalesPointAndVoucherNumberInTheSameColumn.Value == s.SalesPointAndVoucherNumberInTheSameColumn.Value) &&
                (GenerateVouchersNumbersIfMissing.Value == s.GenerateVouchersNumbersIfMissing.Value) &&
                (LoadLastIndexesUsed.Value == s.LoadLastIndexesUsed.Value) &&
                (LastIndexesUsedPath.Value == s.LastIndexesUsedPath.Value) &&
                (LastBookTypeUsed.Value == s.LastBookTypeUsed.Value) &&
                (SaveOnExit.Value == s.SaveOnExit.Value) &&
                (ShowResults.Value == s.ShowResults.Value) &&
                (OutputPath.Value == s.OutputPath.Value) &&
                (AutoSaveLogs.Value == s.AutoSaveLogs.Value) &&
                (GetMissingFieldsAutomatically.Value == s.GetMissingFieldsAutomatically.Value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("ValidateRowsBasedOnDate: {0}", ValidateRowsBasedOnDate));
            sb.AppendLine(string.Format("SalesPointAndVoucherNumberInTheSameColumn: {0}", SalesPointAndVoucherNumberInTheSameColumn));
            sb.AppendLine(string.Format("GenerateVouchersNumbersIfMissing: {0}", GenerateVouchersNumbersIfMissing));
            sb.AppendLine(string.Format("LoadLastIndexesUsed: {0}", LoadLastIndexesUsed));
            sb.AppendLine(string.Format("LastIndexesUsedPath: {0}", LastIndexesUsedPath));
            sb.AppendLine(string.Format("LastBookTypeUsed: {0}", LastBookTypeUsed));
            sb.AppendLine(string.Format("SaveOnExit: {0}", SaveOnExit));
            sb.AppendLine(string.Format("ShowResults: {0}", ShowResults));
            sb.AppendLine(string.Format("OutputPath: {0}", OutputPath));
            sb.AppendLine(string.Format("OutputPath: {0}", GetMissingFieldsAutomatically));

            return sb.ToString();
        }

        [XmlElement("checkRowsBasedOnDate")]
        public Setting<bool> ValidateRowsBasedOnDate { get; set; }
        [XmlElement("salesPointAndVoucherNumberInTheSameColumn")]
        public Setting<bool> SalesPointAndVoucherNumberInTheSameColumn { get; set; }
        [XmlElement("generateVouchersNumbersIfMissing")]
        public Setting<bool> GenerateVouchersNumbersIfMissing { get; set; }
        [XmlElement("loadLastIndexesUsed")]
        public Setting<bool> LoadLastIndexesUsed { get; set; }
        [XmlElement("lastIndexesUsedPath")]
        public Setting<string> LastIndexesUsedPath { get; set; }
        [XmlElement("lastBookTypeUsed")]
        public Setting<TiposLibro> LastBookTypeUsed { get; set; }
        [XmlElement("saveOnExit")]
        public Setting<bool> SaveOnExit { get; set; }
        [XmlElement("showResults")]
        public Setting<bool> ShowResults { get; set; }
        [XmlElement("autoSaveLogs")]
        public Setting<bool> AutoSaveLogs { get; set; }
        [XmlElement("outputPath")]
        public Setting<string> OutputPath { get; set; }
        [XmlElement("lastFileUsedPath")]
        public Setting<string> LastFileUsedPath { get; set; }
        [XmlElement("getMissingFieldsAutomatically")]
        public Setting<bool> GetMissingFieldsAutomatically { get; set; }
    }
}
