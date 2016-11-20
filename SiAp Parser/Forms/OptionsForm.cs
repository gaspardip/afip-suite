using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiAp_Parser.Settings;

namespace SiAp_Parser
{
    /// <summary>
    /// 
    /// </summary>
    /// http://stackoverflow.com/questions/1665533/communicate-between-two-windows-forms-in-c-sharp
    public partial class OptionsForm : Form
    {
        private MainForm mainForm;

        public OptionsForm(MainForm f)
        {
            InitializeComponent();

            mainForm = f;

            cbValidateRowBasedOnDate.Checked = f.settingsMgr.CurrentSettings.ValidateRowsBasedOnDate.Value;
            cbSalesPointAndVoucherNumberInTheSameColumn.Checked = f.settingsMgr.CurrentSettings.SalesPointAndVoucherNumberInTheSameColumn.Value;
            cbGenerateVouchersNumbers.Checked = f.settingsMgr.CurrentSettings.GenerateVouchersNumbersIfMissing.Value;
            cbLoadLastPreferences.Checked = f.settingsMgr.CurrentSettings.LoadLastIndexesUsed.Value;
            cbSaveOptionsOnExit.Checked = f.settingsMgr.CurrentSettings.SaveOnExit.Value;
            cbShowResults.Checked = f.settingsMgr.CurrentSettings.ShowResults.Value;
            cbAutoSaveLogs.Checked = f.settingsMgr.CurrentSettings.AutoSaveLogs.Value;
        }

        private void cbSettings_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;

            if (cb == null)
                return;

            if (cb != ActiveControl)
                return;

            bool cbIsChecked = cb.Checked;

            switch (cb.Name)
            {
                case "cbValidateRowBasedOnDate":
                    mainForm.settingsMgr.CurrentSettings.ValidateRowsBasedOnDate.Value = cbIsChecked;
                    break;
                case "cbSalesPointAndVoucherNumberInTheSameColumn":
                    mainForm.settingsMgr.CurrentSettings.SalesPointAndVoucherNumberInTheSameColumn.Value = cbIsChecked;
                    break;
                case "cbGenerateVouchersNumbers":
                    mainForm.settingsMgr.CurrentSettings.GenerateVouchersNumbersIfMissing.Value = cbIsChecked;
                    break;
                case "cbLoadLastPreferences":
                    mainForm.settingsMgr.CurrentSettings.LoadLastIndexesUsed.Value = cbIsChecked;
                    break;
                case "cbSaveOptionsOnExit":
                    btnSaveOptions.Enabled = mainForm.settingsMgr.CurrentSettings.SaveOnExit.Value = cbIsChecked;
                    break;
                case "cbShowResults":
                    mainForm.settingsMgr.CurrentSettings.ShowResults.Value = cbIsChecked;
                    break;
                case "cbAutoSaveResults":
                    mainForm.settingsMgr.CurrentSettings.AutoSaveLogs.Value = cbIsChecked;
                    break;
            }
        }

        private void btnSaveOptions_Click(object sender, EventArgs e)
        {
            if (mainForm.settingsMgr.Save())
                MessageBox.Show("Opciones guardadas con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Ocurrió un error guardando las opciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
