using System;
using System.Linq;
using System.Windows.Forms;

namespace SiAp_Parser
{
    public partial class ResultsForm : Form
    {
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
            decimal c, t = 0;

            for (int i = 0; i < dgvResults.Rows.Count; ++i)
            {
                //c += Convert.ToInt32(dgvResults.Rows[i].Cells[1].Value);
                t += Convert.ToDecimal(dgvResults.Rows[i].Cells[dgvResults.Rows[i].Cells.Count - 1].Value);
            }

            lblTotalImport.Text = Math.Round(t, 2).ToString();
        }
    }
}
