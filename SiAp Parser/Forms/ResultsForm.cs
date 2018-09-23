using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using SIAP.Parser.Models;
using SIAP.Parser.Settings;

namespace SIAP.Parser
{
    using System.Linq;

    public partial class ResultsForm : Form
    {
        private readonly CultureInfo culture = CultureInfo.GetCultureInfo("es-ar");

        public List<Comprobante> Resultado { get; set; }

        public ResultsForm()
        {
            InitializeComponent();
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            int i = 0;

            foreach (Comprobante c in Resultado)
            {
                dgvResults.Rows.Add(
                    ++i,
                    c.Fecha.ToString("MM/dd/yyyy"),
                    c.Tipo,
                    c.PuntoDeVenta,
                    c.Numero,
                    c.Contratante,
                    c.NumeroIdentificacionContratante,
                    c.ImpuestoLiquidadoTotal,
                    c.ImporteNoGravados,
                    c.ImporteIngresosBrutos,
                    c.ImporteTotal
                );
            }

            lblCreditoFiscal.Text = this.Resultado.Sum(x => x.ImpuestoLiquidadoTotal).ToString("C", culture);
            lblTotalImport.Text = this.Resultado.Sum(x => x.ImporteTotal).ToString("C", culture);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var logs = GenerateLogFromVoucherList(this.Resultado);

                if (logs == null)
                    return;

                var dialog = new CommonOpenFileDialog
                                 {
                                     InitialDirectory = SettingsManager.Instance.OutputConfig.Directory,
                                     IsFolderPicker = true,
                                     Title = SettingsManager.Instance.OutputConfig.VouchersSaveFileDialogTitle,
                                 };

                if (dialog.ShowDialog() != CommonFileDialogResult.Ok)
                    return;

                string vouchersFileName = string.Concat(
                    SettingsManager.Instance.CurrentBookType.ToString(),
                    "_",
                    "COMPROBANTES",
                    "_",
                    OutputConfig.DefaultFileName,
                    ".txt");

                string aliquotsFileName = string.Concat(
                    SettingsManager.Instance.CurrentBookType.ToString(),
                    "_",
                    "ALICUOTAS",
                    "_",
                    OutputConfig.DefaultFileName,
                    ".txt");

                File.WriteAllText(Path.Combine(dialog.FileName, vouchersFileName), logs["vouchers"]["log"]);
                File.WriteAllText(Path.Combine(dialog.FileName, aliquotsFileName), logs["aliquots"]["log"]);

                MessageBox.Show(
                    $"{logs["vouchers"]["amount"]} comprobantes generados, {logs["aliquots"]["amount"]} alicuotas generadas",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private Dictionary<string, Dictionary<string, string>> GenerateLogFromVoucherList(List<Comprobante> list)
        {
            if (list == null || list.Count == 0)
                return null;

            var vouchersSb = new StringBuilder();
            var aliquotsSb = new StringBuilder();

            var dic = new Dictionary<string, Dictionary<string, string>>();

            ushort vc = 0;
            ushort ac = 0;

            foreach (var c in list)
            {
                vouchersSb.AppendLine(c.ToString());
                vc++;

                switch (c)
                {
                    case ComprobanteCompra acc:
                        acc.Alicuotas.ForEach(a =>
                        {
                            aliquotsSb.AppendLine(a.ToString());
                            ac++;
                        });
                        break;
                    case ComprobanteVenta acv:
                        acv.Alicuotas.ForEach(a =>
                        {
                            aliquotsSb.AppendLine(a.ToString());
                            ac++;
                        });
                        break;
                }
            }

            dic["vouchers"] = new Dictionary<string, string>
                                  {
                                      { "log", vouchersSb.ToString() },
                                      { "amount", vc.ToString() }
                                  };

            dic["aliquots"] = new Dictionary<string, string>
                                  {
                                      { "log", aliquotsSb.ToString() },
                                      { "amount", ac.ToString() }
                                  };

            return dic;
        }
    }
}
