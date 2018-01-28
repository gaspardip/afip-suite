using System;
using System.Windows.Forms;

namespace SiAp_Parser
{
    ///  <inheritdoc />
    ///  <summary>
    ///  </summary>
    ///  http://stackoverflow.com/questions/1665533/communicate-between-two-windows-forms-in-c-sharp
    public partial class OptionsForm : Form
    {
        private MainForm mainForm;

        public OptionsForm(MainForm f)
        {
            InitializeComponent();

            mainForm = f;

            cbValidateRowBasedOnDate.Checked = f.SettingsManager.CurrentSettings.ValidateRowsBasedOnDate.Value;
            cbGenerateVouchersNumbers.Checked = f.SettingsManager.CurrentSettings.GenerateVouchersNumbersIfMissing.Value;
            cbLoadLastPreferences.Checked = f.SettingsManager.CurrentSettings.LoadLastIndexesUsed.Value;
            cbSaveOptionsOnExit.Checked = f.SettingsManager.CurrentSettings.SaveOnExit.Value;
            cbShowResults.Checked = f.SettingsManager.CurrentSettings.ShowResults.Value;
            cbAutoSaveLogs.Checked = f.SettingsManager.CurrentSettings.AutoSaveLogs.Value;
            cbGetMissingFields.Checked = f.SettingsManager.CurrentSettings.GetMissingFieldsAutomatically.Value;
        }

        private void cbSettings_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;

            if (cb == null)
                return;

            if (cb != ActiveControl)
                return;

            var cbIsChecked = cb.Checked;

            switch (cb.Name)
            {
                case "cbValidateRowBasedOnDate":
                    mainForm.SettingsManager.CurrentSettings.ValidateRowsBasedOnDate.Value = cbIsChecked;
                    break;
                case "cbGenerateVouchersNumbers":
                    mainForm.SettingsManager.CurrentSettings.GenerateVouchersNumbersIfMissing.Value = cbIsChecked;
                    break;
                case "cbLoadLastPreferences":
                    mainForm.SettingsManager.CurrentSettings.LoadLastIndexesUsed.Value = cbIsChecked;
                    break;
                case "cbSaveOptionsOnExit":
                    btnSaveOptions.Enabled = mainForm.SettingsManager.CurrentSettings.SaveOnExit.Value = cbIsChecked;
                    break;
                case "cbShowResults":
                    mainForm.SettingsManager.CurrentSettings.ShowResults.Value = cbIsChecked;
                    break;
                case "cbAutoSaveResults":
                    mainForm.SettingsManager.CurrentSettings.AutoSaveLogs.Value = cbIsChecked;
                    break;
                case "cbGetMissingFields":
                    mainForm.SettingsManager.CurrentSettings.GetMissingFieldsAutomatically.Value = cbIsChecked;
                    break;
            }
        }

        private void btnSaveOptions_Click(object sender, EventArgs e)
        {
            if (mainForm.SettingsManager.Save())
                MessageBox.Show("Opciones guardadas con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Ocurrió un error guardando las opciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
