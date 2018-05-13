using System;
using System.Globalization;
using System.Windows.Forms;

namespace SiAp_Parser
{
    public partial class ResultsForm : Form
    {
        private readonly CultureInfo culture = CultureInfo.GetCultureInfo("es-ar");

        public ResultsForm()
        {
            InitializeComponent();
        }

        public void AddResultsRow(params object[] values)
        {
            dgvResults.Rows.Add(values);
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            decimal c = 0;
            decimal t = 0;

            int columns = dgvResults.ColumnCount;

            for (int i = 0; i < dgvResults.Rows.Count; ++i)
            {
                c += Convert.ToInt32(dgvResults.Rows[i].Cells[columns - 4].Value);
                t += Convert.ToDecimal(dgvResults.Rows[i].Cells[columns - 1].Value);
            }

            lblCreditoFiscal.Text = c.ToString("C", culture);
            lblTotalImport.Text = t.ToString("C", culture);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }
    }
}
