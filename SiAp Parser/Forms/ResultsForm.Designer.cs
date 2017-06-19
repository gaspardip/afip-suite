namespace SiAp_Parser
{
    partial class ResultsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalImport = new System.Windows.Forms.Label();
            this.rowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VoucherType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VoucherNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssuerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellerNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UntaxedNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrossIncome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowNumber,
            this.Date,
            this.VoucherType,
            this.SalesPoint,
            this.VoucherNumber,
            this.IssuerName,
            this.SellerNumber,
            this.UntaxedNet,
            this.GrossIncome,
            this.Total});
            this.dgvResults.Location = new System.Drawing.Point(12, 12);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(901, 265);
            this.dgvResults.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(12, 299);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(113, 46);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Exportar";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Importe total:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Importe total crédito fiscal:";
            // 
            // lblTotalImport
            // 
            this.lblTotalImport.AutoSize = true;
            this.lblTotalImport.Location = new System.Drawing.Point(420, 299);
            this.lblTotalImport.Name = "lblTotalImport";
            this.lblTotalImport.Size = new System.Drawing.Size(10, 13);
            this.lblTotalImport.TabIndex = 4;
            this.lblTotalImport.Text = "-";
            // 
            // rowNumber
            // 
            this.rowNumber.Frozen = true;
            this.rowNumber.HeaderText = "#";
            this.rowNumber.Name = "rowNumber";
            this.rowNumber.ReadOnly = true;
            this.rowNumber.Width = 39;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Date.Frozen = true;
            this.Date.HeaderText = "Fecha";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 62;
            // 
            // VoucherType
            // 
            this.VoucherType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.VoucherType.Frozen = true;
            this.VoucherType.HeaderText = "Tipo de comprobante";
            this.VoucherType.Name = "VoucherType";
            this.VoucherType.ReadOnly = true;
            this.VoucherType.Width = 122;
            // 
            // SalesPoint
            // 
            this.SalesPoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SalesPoint.Frozen = true;
            this.SalesPoint.HeaderText = "Punto de venta";
            this.SalesPoint.Name = "SalesPoint";
            this.SalesPoint.ReadOnly = true;
            this.SalesPoint.Width = 96;
            // 
            // VoucherNumber
            // 
            this.VoucherNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.VoucherNumber.Frozen = true;
            this.VoucherNumber.HeaderText = "Número de comprobante";
            this.VoucherNumber.Name = "VoucherNumber";
            this.VoucherNumber.ReadOnly = true;
            this.VoucherNumber.Width = 136;
            // 
            // IssuerName
            // 
            this.IssuerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IssuerName.Frozen = true;
            this.IssuerName.HeaderText = "Contratante";
            this.IssuerName.Name = "IssuerName";
            this.IssuerName.ReadOnly = true;
            this.IssuerName.Width = 87;
            // 
            // SellerNumber
            // 
            this.SellerNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SellerNumber.Frozen = true;
            this.SellerNumber.HeaderText = "# ID del contratante";
            this.SellerNumber.Name = "SellerNumber";
            this.SellerNumber.ReadOnly = true;
            this.SellerNumber.Width = 116;
            // 
            // UntaxedNet
            // 
            this.UntaxedNet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.UntaxedNet.Frozen = true;
            this.UntaxedNet.HeaderText = "No gravados";
            this.UntaxedNet.Name = "UntaxedNet";
            this.UntaxedNet.ReadOnly = true;
            this.UntaxedNet.Width = 86;
            // 
            // GrossIncome
            // 
            this.GrossIncome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.GrossIncome.Frozen = true;
            this.GrossIncome.HeaderText = "Ingresos Brutos";
            this.GrossIncome.Name = "GrossIncome";
            this.GrossIncome.ReadOnly = true;
            this.GrossIncome.Width = 96;
            // 
            // Total
            // 
            this.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Total.Frozen = true;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 56;
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 359);
            this.Controls.Add(this.lblTotalImport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvResults);
            this.Name = "ResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resultados";
            this.Load += new System.EventHandler(this.ResultsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn VoucherType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn VoucherNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssuerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellerNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn UntaxedNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrossIncome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}