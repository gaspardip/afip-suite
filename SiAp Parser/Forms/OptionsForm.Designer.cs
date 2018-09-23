namespace SIAP.Parser
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
            this.cbLoadLastPreferences = new System.Windows.Forms.CheckBox();
            this.cbGenerateVouchersNumbers = new System.Windows.Forms.CheckBox();
            this.cbValidateRowBasedOnDate = new System.Windows.Forms.CheckBox();
            this.cbShowResults = new System.Windows.Forms.CheckBox();
            this.cbGetMissingFields = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbLoadLastPreferences
            // 
            this.cbLoadLastPreferences.AutoSize = true;
            this.cbLoadLastPreferences.Location = new System.Drawing.Point(23, 68);
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
            this.cbGenerateVouchersNumbers.Location = new System.Drawing.Point(22, 44);
            this.cbGenerateVouchersNumbers.Name = "cbGenerateVouchersNumbers";
            this.cbGenerateVouchersNumbers.Size = new System.Drawing.Size(298, 17);
            this.cbGenerateVouchersNumbers.TabIndex = 4;
            this.cbGenerateVouchersNumbers.Text = "Generar números de comprobantes en caso de que falten";
            this.cbGenerateVouchersNumbers.UseVisualStyleBackColor = true;
            this.cbGenerateVouchersNumbers.CheckedChanged += new System.EventHandler(this.cbSettings_CheckedChanged);
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
            // cbShowResults
            // 
            this.cbShowResults.AutoSize = true;
            this.cbShowResults.Location = new System.Drawing.Point(23, 91);
            this.cbShowResults.Name = "cbShowResults";
            this.cbShowResults.Size = new System.Drawing.Size(268, 17);
            this.cbShowResults.TabIndex = 8;
            this.cbShowResults.Text = "Mostrar pantalla de resultados al finalizar el proceso";
            this.cbShowResults.UseVisualStyleBackColor = true;
            this.cbShowResults.CheckedChanged += new System.EventHandler(this.cbSettings_CheckedChanged);
            // 
            // cbGetMissingFields
            // 
            this.cbGetMissingFields.AutoSize = true;
            this.cbGetMissingFields.Location = new System.Drawing.Point(22, 114);
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
            this.ClientSize = new System.Drawing.Size(588, 152);
            this.Controls.Add(this.cbGetMissingFields);
            this.Controls.Add(this.cbShowResults);
            this.Controls.Add(this.cbLoadLastPreferences);
            this.Controls.Add(this.cbGenerateVouchersNumbers);
            this.Controls.Add(this.cbValidateRowBasedOnDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar opciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cbLoadLastPreferences;
        private System.Windows.Forms.CheckBox cbGenerateVouchersNumbers;
        private System.Windows.Forms.CheckBox cbValidateRowBasedOnDate;
        private System.Windows.Forms.CheckBox cbShowResults;
        private System.Windows.Forms.CheckBox cbGetMissingFields;
    }
}