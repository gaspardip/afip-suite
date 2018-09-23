using System;
using System.Windows.Forms;
using SIAP.Parser.Settings;

namespace SIAP.Parser
{
    ///  <inheritdoc />
    ///  <summary>
    ///  </summary>
    ///  http://stackoverflow.com/questions/1665533/communicate-between-two-windows-forms-in-c-sharp
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();

            cbValidateRowBasedOnDate.Checked = SettingsManager.Instance.CurrentSettings.ValidateRowsBasedOnDate.Value;
            cbGenerateVouchersNumbers.Checked = SettingsManager.Instance.CurrentSettings.GenerateVouchersNumbersIfMissing.Value;
            cbLoadLastPreferences.Checked = SettingsManager.Instance.CurrentSettings.LoadLastIndexesUsed.Value;
            cbGetMissingFields.Checked = SettingsManager.Instance.CurrentSettings.GetMissingFieldsAutomatically.Value;
        }

        private void cbSettings_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is CheckBox cb))
                return;

            if (cb != ActiveControl)
                return;

            switch (cb.Name)
            {
                case "cbValidateRowBasedOnDate":
                    SettingsManager.Instance.CurrentSettings.ValidateRowsBasedOnDate.Value = cb.Checked;
                    break;
                case "cbGenerateVouchersNumbers":
                    SettingsManager.Instance.CurrentSettings.GenerateVouchersNumbersIfMissing.Value = cb.Checked;
                    break;
                case "cbLoadLastPreferences":
                    SettingsManager.Instance.CurrentSettings.LoadLastIndexesUsed.Value = cb.Checked;
                    break;
                case "cbGetMissingFields":
                    SettingsManager.Instance.CurrentSettings.GetMissingFieldsAutomatically.Value = cb.Checked;
                    break;
            }
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsManager.Instance.Save();
        }
    }
}
