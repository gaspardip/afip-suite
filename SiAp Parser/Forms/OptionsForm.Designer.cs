namespace SiAp_Parser
{
    partial class OptionsForm
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
            this.cbSaveOptionsOnExit = new System.Windows.Forms.CheckBox();
            this.cbLoadLastPreferences = new System.Windows.Forms.CheckBox();
            this.cbGenerateVouchersNumbers = new System.Windows.Forms.CheckBox();
            this.cbSalesPointAndVoucherNumberInTheSameColumn = new System.Windows.Forms.CheckBox();
            this.cbValidateRowBasedOnDate = new System.Windows.Forms.CheckBox();
            this.btnSaveOptions = new System.Windows.Forms.Button();
            this.cbShowResults = new System.Windows.Forms.CheckBox();
            this.cbAutoSaveLogs = new System.Windows.Forms.CheckBox();
            this.cbGetMissingFields = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbSaveOptionsOnExit
            // 
            this.cbSaveOptionsOnExit.AutoSize = true;
            this.cbSaveOptionsOnExit.Location = new System.Drawing.Point(23, 115);
            this.cbSaveOptionsOnExit.Name = "cbSaveOptionsOnExit";
            this.cbSaveOptionsOnExit.Size = new System.Drawing.Size(303, 17);
            this.cbSaveOptionsOnExit.TabIndex = 8;
            this.cbSaveOptionsOnExit.Text = "Guardar opciones automaticamente al salir de la aplicación";
            this.cbSaveOptionsOnExit.UseVisualStyleBackColor = true;
            this.cbSaveOptionsOnExit.CheckedChanged += new System.EventHandler(this.cbSettings_CheckedChanged);
            // 
            // cbLoadLastPreferences
            // 
            this.cbLoadLastPreferences.AutoSize = true;
            this.cbLoadLastPreferences.Location = new System.Drawing.Point(23, 91);
            this.cbLoadLastPreferences.Name = "cbLoadLastPreferences";
            this.cbLoadLastPreferences.Size = new System.Drawing.Size(298, 17);
            this.cbLoadLastPreferences.TabIndex = 7;
            this.cbLoadLastPreferences.Text = "Cargar las ultimas preferencias usadas al abrir el programa";
            this.cbLoadLastPreferences.UseVisualStyleBackColor = true;
            this.cbLoadLastPreferences.CheckedChanged += new System.EventHandler(this.cbSettings_CheckedChanged);
            // 
            // cbGenerateVouchersNumbers
            // 
            this.cbGenerateVouchersNumbers.AutoSize = true;
            this.cbGenerateVouchersNumbers.Location = new System.Drawing.Point(22, 67);
            this.cbGenerateVouchersNumbers.Name = "cbGenerateVouchersNumbers";
            this.cbGenerateVouchersNumbers.Size = new System.Drawing.Size(298, 17);
            this.cbGenerateVouchersNumbers.TabIndex = 4;
            this.cbGenerateVouchersNumbers.Text = "Generar números de comprobantes en caso de que falten";
            this.cbGenerateVouchersNumbers.UseVisualStyleBackColor = true;
            this.cbGenerateVouchersNumbers.CheckedChanged += new System.EventHandler(this.cbSettings_CheckedChanged);
            // 
            // cbSalesPointAndVoucherNumberInTheSameColumn
            // 
            this.cbSalesPointAndVoucherNumberInTheSameColumn.AutoSize = true;
            this.cbSalesPointAndVoucherNumberInTheSameColumn.Location = new System.Drawing.Point(22, 44);
            this.cbSalesPointAndVoucherNumberInTheSameColumn.Name = "cbSalesPointAndVoucherNumberInTheSameColumn";
            this.cbSalesPointAndVoucherNumberInTheSameColumn.Size = new System.Drawing.Size(402, 17);
            this.cbSalesPointAndVoucherNumberInTheSameColumn.TabIndex = 5;
            this.cbSalesPointAndVoucherNumberInTheSameColumn.Text = "El punto de venta y número de comprobante se encuentra en la misma columna";
            this.cbSalesPointAndVoucherNumberInTheSameColumn.UseVisualStyleBackColor = true;
            this.cbSalesPointAndVoucherNumberInTheSameColumn.CheckedChanged += new System.EventHandler(this.cbSettings_CheckedChanged);
            // 
            // cbValidateRowBasedOnDate
            // 
            this.cbValidateRowBasedOnDate.AutoSize = true;
            this.cbValidateRowBasedOnDate.Location = new System.Drawing.Point(22, 21);
            this.cbValidateRowBasedOnDate.Name = "cbValidateRowBasedOnDate";
            this.cbValidateRowBasedOnDate.Size = new System.Drawing.Size(165, 17);
            this.cbValidateRowBasedOnDate.TabIndex = 6;
            this.cbValidateRowBasedOnDate.Text = "Validar fila en base a la fecha";
            this.cbValidateRowBasedOnDate.UseVisualStyleBackColor = true;
            this.cbValidateRowBasedOnDate.CheckedChanged += new System.EventHandler(this.cbSettings_CheckedChanged);
            // 
            // btnSaveOptions
            // 
            this.btnSaveOptions.Location = new System.Drawing.Point(23, 231);
            this.btnSaveOptions.Name = "btnSaveOptions";
            this.btnSaveOptions.Size = new System.Drawing.Size(553, 39);
            this.btnSaveOptions.TabIndex = 9;
            this.btnSaveOptions.Text = "Guardar opciones";
            this.btnSaveOptions.UseVisualStyleBackColor = true;
            this.btnSaveOptions.Click += new System.EventHandler(this.btnSaveOptions_Click);
            // 
            // cbShowResults
            // 
            this.cbShowResults.AutoSize = true;
            this.cbShowResults.Location = new System.Drawing.Point(23, 138);
            this.cbShowResults.Name = "cbShowResults";
            this.cbShowResults.Size = new System.Drawing.Size(268, 17);
            this.cbShowResults.TabIndex = 8;
            this.cbShowResults.Text = "Mostrar pantalla de resultados al finalizar el proceso";
            this.cbShowResults.UseVisualStyleBackColor = true;
            this.cbShowResults.CheckedChanged += new System.EventHandler(this.cbSettings_CheckedChanged);
            // 
            // cbAutoSaveLogs
            // 
            this.cbAutoSaveLogs.AutoSize = true;
            this.cbAutoSaveLogs.Location = new System.Drawing.Point(22, 161);
            this.cbAutoSaveLogs.Name = "cbAutoSaveLogs";
            this.cbAutoSaveLogs.Size = new System.Drawing.Size(278, 17);
            this.cbAutoSaveLogs.TabIndex = 8;
            this.cbAutoSaveLogs.Text = "Guardar los documentos generados automaticamente";
            this.cbAutoSaveLogs.UseVisualStyleBackColor = true;
            this.cbAutoSaveLogs.CheckedChanged += new System.EventHandler(this.cbSettings_CheckedChanged);
            // 
            // cbGetMissingFields
            // 
            this.cbGetMissingFields.AutoSize = true;
            this.cbGetMissingFields.Location = new System.Drawing.Point(22, 184);
            this.cbGetMissingFields.Name = "cbGetMissingFields";
            this.cbGetMissingFields.Size = new System.Drawing.Size(356, 17);
            this.cbGetMissingFields.TabIndex = 8;
            this.cbGetMissingFields.Text = "Buscar y corregir razones sociales y CUITS faltantes automáticamente";
            this.cbGetMissingFields.UseVisualStyleBackColor = true;
            this.cbGetMissingFields.CheckedChanged += new System.EventHandler(this.cbSettings_CheckedChanged);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 305);
            this.Controls.Add(this.btnSaveOptions);
            this.Controls.Add(this.cbGetMissingFields);
            this.Controls.Add(this.cbAutoSaveLogs);
            this.Controls.Add(this.cbShowResults);
            this.Controls.Add(this.cbSaveOptionsOnExit);
            this.Controls.Add(this.cbLoadLastPreferences);
            this.Controls.Add(this.cbGenerateVouchersNumbers);
            this.Controls.Add(this.cbSalesPointAndVoucherNumberInTheSameColumn);
            this.Controls.Add(this.cbValidateRowBasedOnDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar opciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbSaveOptionsOnExit;
        private System.Windows.Forms.CheckBox cbLoadLastPreferences;
        private System.Windows.Forms.CheckBox cbGenerateVouchersNumbers;
        private System.Windows.Forms.CheckBox cbSalesPointAndVoucherNumberInTheSameColumn;
        private System.Windows.Forms.CheckBox cbValidateRowBasedOnDate;
        private System.Windows.Forms.Button btnSaveOptions;
        private System.Windows.Forms.CheckBox cbShowResults;
        private System.Windows.Forms.CheckBox cbAutoSaveLogs;
        private System.Windows.Forms.CheckBox cbGetMissingFields;
    }
}