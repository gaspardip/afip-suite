using System;
using System.Windows.Forms;

namespace GeneradorDeLibros
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var t1 = new CUIT("25900875100");
            var t2 = new CUIT("25-90087510-0");
            var t3 = new CUIT("kappa");
        }
    }
}
