using System;
using System.Text;
using System.Xml.Serialization;
using SIAP.Parser.Enums;

namespace SIAP.Parser.Settings
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
            GenerateVouchersNumbersIfMissing = new Setting<bool>(true);
            LoadLastIndexesUsed = new Setting<bool>(false);
            LastDocumentSettingsPath = new Setting<string>(string.Empty);
            LastBookTypeUsed = new Setting<TiposLibro>(TiposLibro.UNDEFINED);
            OutputPath = new Setting<string>(string.Empty);
            LastFileUsedPath = new Setting<string>(string.Empty);
            GetMissingFieldsAutomatically = new Setting<bool>(true);
        }

        public override bool Equals(object obj)
        {
            var s = (Settings)obj;

            if (s == null)
                return false;

            return
                ValidateRowsBasedOnDate.Value == s.ValidateRowsBasedOnDate.Value &&
                GenerateVouchersNumbersIfMissing.Value == s.GenerateVouchersNumbersIfMissing.Value &&
                LoadLastIndexesUsed.Value == s.LoadLastIndexesUsed.Value &&
                LastDocumentSettingsPath.Value == s.LastDocumentSettingsPath.Value &&
                LastBookTypeUsed.Value == s.LastBookTypeUsed.Value &&
                OutputPath.Value == s.OutputPath.Value &&
                GetMissingFieldsAutomatically.Value == s.GetMissingFieldsAutomatically.Value;
        }

        public override int GetHashCode() => base.GetHashCode();

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"ValidateRowsBasedOnDate: {ValidateRowsBasedOnDate}");
            sb.AppendLine($"GenerateVouchersNumbersIfMissing: {GenerateVouchersNumbersIfMissing}");
            sb.AppendLine($"LoadLastIndexesUsed: {LoadLastIndexesUsed}");
            sb.AppendLine($"LastIndexesUsedPath: {LastDocumentSettingsPath}");
            sb.AppendLine($"LastBookTypeUsed: {LastBookTypeUsed}");
            sb.AppendLine($"OutputPath: {OutputPath}");
            sb.AppendLine($"OutputPath: {GetMissingFieldsAutomatically}");

            return sb.ToString();
        }

        [XmlElement("checkRowsBasedOnDate")]
        public Setting<bool> ValidateRowsBasedOnDate { get; set; }
        [XmlElement("generateVouchersNumbersIfMissing")]
        public Setting<bool> GenerateVouchersNumbersIfMissing { get; set; }
        [XmlElement("loadLastIndexesUsed")]
        public Setting<bool> LoadLastIndexesUsed { get; set; }
        [XmlElement("lastIndexesUsedPath")]
        public Setting<string> LastDocumentSettingsPath { get; set; }
        [XmlElement("lastBookTypeUsed")]
        public Setting<TiposLibro> LastBookTypeUsed { get; set; }
        [XmlElement("outputPath")]
        public Setting<string> OutputPath { get; set; }
        [XmlElement("lastFileUsedPath")]
        public Setting<string> LastFileUsedPath { get; set; }
        [XmlElement("getMissingFieldsAutomatically")]
        public Setting<bool> GetMissingFieldsAutomatically { get; set; }
    }
}
