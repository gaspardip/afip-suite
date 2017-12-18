using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using SiAp_Parser.Settings;
using SiAp_Parser.Extensions;
using SiAp_Parser.Helpers;
using SiAp_Parser.Models;
using SiAp_Parser.Enums;
using SiAp_Parser.Serialization;
using System.Collections;
using NLog;

namespace SiAp_Parser
{
    public partial class MainForm : Form
    {
        internal SettingsManager settingsMgr;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public MainForm()
        {
            InitializeComponent();

            settingsMgr = new SettingsManager(true);

            #region ComboBox

            cmbTipo.Items.Add(new ComboBoxItem { Text = "Comprobantes compras", Value = TiposLibro.COMPRAS });
            cmbTipo.Items.Add(new ComboBoxItem { Text = "Comprobantes ventas", Value = TiposLibro.VENTAS });

            cmbTipo.SelectedIndex = 0;

            #endregion

            if (!settingsMgr.CurrentSettings.LoadLastIndexesUsed.Value)
                return;

            if (!File.Exists(settingsMgr.CurrentSettings.LastDocumentSettingsPath.Value))
                return;

            try
            {
                var ds = SerializationHelpers.Deserialize<DocumentSettings>(settingsMgr.CurrentSettings.LastDocumentSettingsPath.Value);

                RestoreDocumentSettings(ds);

                txtFilepath.Text = settingsMgr.CurrentSettings.LastFileUsedPath.Value;
                btnProcessFile.Enabled = true;
                tabCtrlSettings.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                (
                    String.Format("Ocurrió un error al cargar las preferencias{0}{1}", Environment.NewLine + Environment.NewLine, ex.Message),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (settingsMgr.CurrentSettings.SaveOnExit.Value)
                settingsMgr.Save();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (settingsMgr.HasUnsavedChanges && !settingsMgr.CurrentSettings.SaveOnExit.Value)
                e.Cancel = MessageBox.Show("Tiene cambios sin guardar. ¿Está seguro que quiere salir?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No;
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Title = "Abrir archivo excel",
                Filter = "Archivos excel|*.xls;*.xlsx",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Multiselect = false,
                ReadOnlyChecked = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                settingsMgr.CurrentSettings.LastFileUsedPath.Value = ofd.FileName;

                var fileNameToLower = ofd.FileName.ToLower();

                var isBuysBook = fileNameToLower.IndexOf("compras", StringComparison.CurrentCultureIgnoreCase) != -1;
                var isSalesBook = fileNameToLower.IndexOf("ventas", StringComparison.CurrentCultureIgnoreCase) != -1;
                var weirdCase = isBuysBook == isSalesBook;

                cmbTipo.SelectedIndex = (isBuysBook || weirdCase) || !isSalesBook ? 0 : 1;

                txtFilepath.Text = ofd.FileName;
                tabCtrlSettings.Visible = true;
                btnProcessFile.Enabled = true;
            }
        }

        private void btnProcessFile_Click(object sender, EventArgs e)
        {
            settingsMgr.CurrentSettings.LastBookTypeUsed.Value = settingsMgr.CurrentBookType;
            settingsMgr.CurrentSettings.LastDocumentSettingsPath.Value = settingsMgr.CurrentIndexesPath;

            var comprobantes = new List<dynamic>();

            var indexes = new Dictionary<string, dynamic>()
            {
                { "Aliquots", new Dictionary<string, int>() },
            };

            #region Control associations

            var associations = new Dictionary<string, dynamic>
            {
                {
                    "Date",
                    new List<Control>
                    {
                        { cbDate },
                        { nudDate }
                    }
                },
                {
                    "VoucherType",
                    new List<Control>
                    {
                        { cbVoucherType },
                        { nudVoucherType }
                    }
                },
                {
                    "SalesPoint",
                    new List<Control>
                    {
                        { cbSalesPoint },
                        { nudSalesPoint }
                    }
                },
                {
                    "VoucherNumber",
                    new List<Control>
                    {
                        { cbVoucherNumber },
                        { nudVoucherNumber }
                    }
                },
                {
                    "SellerName",
                    new List<Control>
                    {
                        { cbSellerName },
                        { nudSellerName }
                    }
                },
                {
                    "SellerNumber",
                    new List<Control>
                    {
                        { cbSellerNumber },
                        { nudSellerNumber }
                    }
                },
                {
                    "Aliquots",
                    new Dictionary<string, List<Control>>
                    {
                        {
                            "21",
                            new List<Control>
                            {
                                cbAliquot21,
                                nudAliquot21
                            }
                        },
                        {
                            "105",
                            new List<Control>
                            {
                                cbAliquot105,
                                nudAliquot105
                            }
                        },
                        {
                            "27",
                            new List<Control>
                            {
                                cbAliquot27,
                                nudAliquot27
                            }
                        },
                        {
                            "5",
                            new List<Control>
                            {
                                cbAliquot5,
                                nudAliquot5
                            }
                        },
                        {
                            "250",
                            new List<Control>
                            {
                                cbAliquot250,
                                nudAliquot250
                            }
                        },
                        {
                            "0",
                            new List<Control>
                            {
                                cbAliquot0,
                                nudAliquot0
                            }
                        }
                    }
                },
                {
                    "UntaxedNet",
                    new List<Control>
                    {
                        { cbUntaxedNet },
                        { nudUntaxedNet }
                    }
                },
                {
                    "GrossIncome",
                    new List<dynamic>
                    {
                        { cbGrossIncome },
                        { txtGrossIncome }
                    }
                },
                {
                    "InternalTaxes",
                    new List<dynamic>
                    {
                        { cbInternalTaxes },
                        { nudInternalTaxes }
                    }
                },
                {
                    "Total",
                    new List<Control>
                    {
                        { cbTotal },
                        { nudTotal }
                    }
                },
            };

            #endregion

            switch (settingsMgr.CurrentBookType)
            {
                case TiposLibro.COMPRAS:
                    #region Buys associations
                    associations.Add
                    (
                        "ImportClearance",
                        new List<Control>
                        {
                            { cbImportClearance },
                            { nudImportClearance }
                        }
                    );
                    associations.Add
                    (
                        "VATPerceptionsAmount",
                        new List<Control>
                        {
                            { cbVATPerceptionsAmount },
                            { nudVATPerceptionsAmount }
                        }
                    );
                    associations.Add
                    (
                        "ComputableTaxCredit",
                        new List<Control>
                        {
                            { cbComputableTaxCredit },
                            { nudComputableTaxCredit }
                        }
                    );
                    associations.Add
                    (
                        "CUITIssuer",
                        new List<Control>
                        {
                            { cbCUITIssuer },
                            { nudCUITIssuer }
                        }
                    );
                    associations.Add
                    (
                        "IssuerName",
                        new List<Control>
                        {
                            { cbIssuerName },
                            { nudIssuerName }
                        }
                    );
                    associations.Add
                    (
                        "VATCommission",
                        new List<Control>
                        {
                            { cbVATCommission },
                            { nudVATCommission }
                        }
                    );
                    break;
                #endregion
                case TiposLibro.VENTAS:
                    #region Sales associations
                    associations.Add
                    (
                        "VoucherNumberUntil",
                        new List<Control>
                        {
                            { cbVoucherNumberUntil },
                            { nudVoucherNumberUntil }
                        }
                    );
                    associations.Add
                    (
                        "UncategorizedPerceptionAmount",
                        new List<Control>
                        {
                            { cbUncategorizedPerceptionAmount },
                            { nudUncategorizedPerceptionAmount }
                        }
                    );
                    associations.Add
                    (
                        "PaymentExpireDate",
                        new List<Control>
                        {
                            { cbPaymentExpireDate },
                            { nudPaymentExpireDate }
                        }
                    );
                    #endregion
                    break;
            }

            foreach (var a in associations)
            {
                int? i = null;

                switch (a.Key)
                {
                    case "Aliquots":
                        foreach (KeyValuePair<string, List<Control>> aliquot in a.Value)
                        {
                            i = GenerateIndex(aliquot.Value[0] as CheckBox, aliquot.Value[1] as NumericUpDown);
                            if (i == null) continue;
                            indexes["Aliquots"].Add(aliquot.Key, (int)i);
                        }
                        break;
                    case "GrossIncome":
                        var list = GenerateIndexes(a.Value[0], a.Value[1]);
                        if (list == null) continue;
                        indexes["GrossIncome"] = list;
                        break;
                    default:
                        i = GenerateIndex(a.Value[0] as CheckBox, a.Value[1] as NumericUpDown);
                        break;
                }

                if (i == null) continue;

                indexes.Add(a.Key, i);
            }

            var indexesCopy = indexes;

            if (
                cbSalesPointAndVoucherNumberInTheSameColumn.Checked &&
                (indexes.ContainsKey("SalesPoint") && indexes.ContainsKey("VoucherNumber")) &&
                (indexes["SalesPoint"] == indexes["VoucherNumber"])
            )
                indexesCopy.Remove("VoucherNumber");

            if (CheckIndexesEquality(indexesCopy))
            {
                MessageBox.Show("Todos los índices deben ser diferentes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // http://stackoverflow.com/questions/21849756/excel-data-reader-issues-column-names-and-sheet-selection
            try
            {
                var excelReader = File.Open(txtFilepath.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite).GetExcelDataReader();

                while (excelReader.Read())
                {
                    DateTime date;

                    try
                    {
                        date = excelReader.GetDateTime((int)indexes["Date"]);
                    }
                    catch
                    {
                        continue;
                    }


                    bool isValidRow = date.Year != 1;

                    if (isValidRow)
                    {
                        dynamic c = null;
                        Persona p = null;

                        switch (settingsMgr.CurrentBookType)
                        {
                            case TiposLibro.COMPRAS:
                                c = new ComprobanteCompra();

                                if (indexes.ContainsKey("ImportClearance"))
                                    c.DespachoImportacion = excelReader.GetSafeString((int)indexes["ImportClearance"]).Trim();
                                if (indexes.ContainsKey("VATPerceptionsAmount"))
                                    c.ImportePercepcionesIVA = excelReader.GetSafeDouble((int)indexes["VATPerceptionsAmount"]);
                                if (indexes.ContainsKey("CUITIssuer"))
                                    c.CUITEmisor = excelReader.GetSafeString((int)indexes["CUITIssuer"]).Trim();
                                if (indexes.ContainsKey("ComputableTaxCredit"))
                                    c.CreditoFiscalComputable = excelReader.GetSafeDouble((int)indexes["ComputableTaxCredit"]);
                                if (indexes.ContainsKey("IssuerName"))
                                    c.DenominacionEmisor = excelReader.GetSafeString((int)indexes["IssuerName"]).Trim();
                                if (indexes.ContainsKey("VATCommission"))
                                    c.IVAComision = excelReader.GetSafeDouble((int)indexes["VATCommission"]);
                                break;
                            case TiposLibro.VENTAS:
                                c = new ComprobanteVenta();

                                if (indexes.ContainsKey("VoucherNumberUntil"))
                                    c.NumeroHasta = excelReader.GetInt32((int)indexes["VoucherNumberUntil"]);
                                if (indexes.ContainsKey("UncategorizedPerceptionAmount"))
                                    c.ImportePercepcionNoCategorizados = excelReader.GetSafeDouble((int)indexes["UncategorizedPerceptionAmount"]);
                                if (indexes.ContainsKey("PaymentExpireDate"))
                                    c.FechaVencimientoPago = excelReader.GetDateTime((int)indexes["PaymentExpireDate"]);
                                break;
                        }

                        if (indexes.ContainsKey("Date"))
                            c.Fecha = date;
                        if (indexes.ContainsKey("VoucherType"))
                            c.Tipo = excelReader.GetSafeString((int)indexes["VoucherType"]);

                        if (indexes.ContainsKey("SalesPoint") || indexes.ContainsKey("VoucherNumber"))
                        {
                            if (cbSalesPointAndVoucherNumberInTheSameColumn.Checked)
                            {
                                var strNumbers = excelReader.GetSafeString((int)indexes["SalesPoint"]);
                                var numbers = new string[] { "1", "1" };

                                if (!string.IsNullOrEmpty(strNumbers))
                                    numbers = strNumbers.Replace(" ", string.Empty).Split('-');

                                // There is no salespoint for some reason... just use 1
                                if (numbers.Length == 1)
                                    numbers = new string[] { "1", numbers[0] };

                                short salesPoint;
                                int voucherNumber;

                                Int16.TryParse(numbers[0], out salesPoint);
                                c.PuntoDeVenta = salesPoint;

                                Int32.TryParse(numbers[1], out voucherNumber);
                                c.Numero = voucherNumber;
                            }
                            else
                            {
                                c.PuntoDeVenta = excelReader.GetInt16((int)indexes["SalesPoint"]);
                                c.Numero = excelReader.GetInt32((int)indexes["VoucherNumber"]);
                            }

                            if (settingsMgr.CurrentBookType == TiposLibro.VENTAS && c.NumeroHasta == 0)
                            {
                                c.NumeroHasta = c.Numero;
                            }
                        }

                        if (indexes.ContainsKey("SellerName"))
                        {
                            try
                            {
                                c.Contratante = excelReader.GetSafeString((int)indexes["SellerName"]).Trim();
                            }
                            catch
                            {
                                if (
                                    string.IsNullOrEmpty(c.Contratante) &&
                                    settingsMgr.CurrentSettings.GetMissingFieldsAutomatically.Value &&
                                    indexes.ContainsKey("SellerNumber"))
                                {
                                    c.NumeroIdentificacionContratante = excelReader.GetSafeString((int)indexes["SellerNumber"]).Trim();

                                    if (!string.IsNullOrEmpty(c.NumeroIdentificacionContratante))
                                    {
                                        p = (new CuitOnlineHelper(c.NumeroIdentificacionContratante)).GetPersonInfo();

                                        if (p != null)
                                            c.Contratante = p.Denominacion;
                                    }
                                }
                            }
                        }

                        if (indexes.ContainsKey("SellerNumber"))
                        {
                            if (c.NumeroIdentificacionContratante == "0")
                            {
                                try
                                {
                                    c.NumeroIdentificacionContratante = excelReader.GetSafeString((int)indexes["SellerNumber"]).Trim();

                                    if (!ValidationHelper.IsValidCUIT(c.NumeroIdentificacionContratante))
                                        throw new ArgumentException("Un CUIT no tiene el formato correcto");
                                }
                                catch
                                {
                                    if (
                                        settingsMgr.CurrentSettings.GetMissingFieldsAutomatically.Value &&
                                        indexes.ContainsKey("SellerName") && !string.IsNullOrEmpty(c.Contratante))
                                    {
                                        p = (new CuitOnlineHelper(c.Contratante)).GetPersonInfo();

                                        if (p != null)
                                            c.NumeroIdentificacionContratante = p.CUIT;
                                    }
                                }
                            }
                        }

                        if (indexes["Aliquots"].Count > 0)
                        {
                            foreach (KeyValuePair<string, int> item in indexes["Aliquots"])
                            {
                                double importeNeto = excelReader.GetSafeDouble(item.Value);

                                if (importeNeto <= 0)
                                    continue;

                                dynamic a = null;

                                switch (settingsMgr.CurrentBookType)
                                {
                                    case TiposLibro.COMPRAS:
                                        a = new AlicuotaCompra()
                                        {
                                            TipoComprobante = c.Tipo,
                                            PuntoDeVenta = c.PuntoDeVenta,
                                            NumeroComprobante = c.Numero,
                                            CodigoDocumentoContratante = c.CodigoDocumentoContratante,
                                            NumeroIdentificacionContratante = c.NumeroIdentificacionContratante,
                                            ImporteNeto = importeNeto
                                        };
                                        break;
                                    case TiposLibro.VENTAS:
                                        a = new AlicuotaVenta()
                                        {
                                            TipoComprobante = c.Tipo,
                                            PuntoDeVenta = c.PuntoDeVenta,
                                            NumeroComprobante = c.Numero,
                                            ImporteNeto = importeNeto
                                        };
                                        break;
                                }

                                switch (item.Key)
                                {
                                    case "21":
                                        a.Porcentaje = 21d;
                                        break;
                                    case "105":
                                        a.Porcentaje = 10.5d;
                                        break;
                                    case "27":
                                        a.Porcentaje = 27d;
                                        break;
                                    case "5":
                                        a.Porcentaje = 5d;
                                        break;
                                    case "250":
                                        a.Porcentaje = 2.5d;
                                        break;
                                    case "0":
                                        a.Porcentaje = 0;
                                        break;
                                }

                                c.Alicuotas.Add(a);
                            }
                        }

                        if (indexes.ContainsKey("UntaxedNet"))
                            c.ImporteConceptosNoIntegranElNetoGravado = excelReader.GetSafeDouble((int)indexes["UntaxedNet"]);
                        if (indexes.ContainsKey("GrossIncome"))
                        {
                            foreach (int i in indexes["GrossIncome"])
                            {
                                c.ImporteIngresosBrutos += excelReader.GetSafeDouble(i);
                            }
                        }
                        if (indexes.ContainsKey("InternalTaxes"))
                            c.ImporteImpuestosInternos = excelReader.GetSafeDouble((int)indexes["InternalTaxes"]);
                        if (indexes.ContainsKey("Total"))
                            c.ImporteTotal = excelReader.GetSafeDouble((int)indexes["Total"]);

                        if (c.Tipo == TipoComprobante.FACTURAS_C || c.Tipo == TipoComprobante.NOTAS_DE_CREDITO_C)
                        {
                            c.ImporteConceptosNoIntegranElNetoGravado = 0;
                            c.CantidadAlicuotasIVA = 0;
                        }
                        else
                            c.CantidadAlicuotasIVA = (ushort)c.Alicuotas.Count;

                        // Verificar si es nota de credito de cualquier tipo...

                        if (c.EsValido)
                            comprobantes.Add(c);
                    }
                }

                excelReader.Close();
            }
            #region Exceptions
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #region PathTooLongException
            catch (PathTooLongException)
            {
                MessageBox.Show
                (
                    "La longitud hacia el archivo seleccionada es demasiado larga. Pruebe renombrando el archivo a un nombre mas corto o moviéndolo de ubicación",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtFilepath.Text = string.Empty;
                return;
            }
            #endregion
            #region FileNotFoundException
            catch (FileNotFoundException)
            {
                MessageBox.Show
                (
                    "El archivo seleccionado no fue encontrado, por favor intente de nuevo",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                txtFilepath.Text = string.Empty;
                return;
            }
            #endregion
            #region IndexOutOfRangeException
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show
                (
                    "Al menos uno de los indices es mayor al numero de columnas en el archivo seleccionado",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            catch (Exception ex)
            {
                string msg = "Ocurrió un error al procesar el archivo" + Environment.NewLine + Environment.NewLine + ex.Message;
#if DEBUG
                msg += string.Format(Environment.NewLine + "StackTrace: {0}", ex.StackTrace);
#endif

                MessageBox.Show
                (
                    msg,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }
            #endregion
            #endregion

            if (settingsMgr.CurrentSettings.ShowResults.Value)
            {
                int i = 0;
                var resultsForm = new ResultsForm();

                foreach (Comprobante c in comprobantes)
                {
                    resultsForm.AddResultsRow(
                        ++i,
                        c.Fecha.ToString("MM/dd/yyyy"),
                        c.Tipo,
                        c.PuntoDeVenta,
                        c.Numero,
                        c.Contratante,
                        c.NumeroIdentificacionContratante,
                        c.ImporteConceptosNoIntegranElNetoGravado,
                        c.ImporteIngresosBrutos,
                        c.ImporteTotal
                    );
                }

                resultsForm.ShowDialog(this);
            }
            else
            {
                var logs = GenerateLogFromVoucherList(comprobantes);

                if (logs == null)
                    return;

                if (settingsMgr.CurrentSettings.AutoSaveLogs.Value)
                {
                    settingsMgr.OutputConfig.FileName = "vouchers.txt";
                    settingsMgr.OutputConfig.FileName = "aliquots.txt";
                    File.WriteAllText(settingsMgr.OutputConfig.FilePath, logs["aliquots"]["log"]);
                }
                else
                {
                    var sfd = new SaveFileDialog();

                    sfd.Filter = settingsMgr.OutputConfig.DialogFilter;
                    sfd.Title = settingsMgr.OutputConfig.VouchersSaveFileDialogTitle;
                    sfd.InitialDirectory = settingsMgr.OutputConfig.Directory;
                    sfd.FileName = string.Concat(settingsMgr.CurrentBookType.ToString(), "_", "COMPROBANTES", "_", settingsMgr.OutputConfig.DefaultFileName, ".txt");

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    try
                    {
                        settingsMgr.OutputConfig.FileName = sfd.FileName;

                        File.WriteAllText(settingsMgr.OutputConfig.FilePath, logs["vouchers"]["log"]);

                        sfd.Title = settingsMgr.OutputConfig.AliquotsSaveFileDialogTitle;
                        sfd.InitialDirectory = Directory.GetParent(sfd.FileName).FullName;
                        sfd.FileName = string.Concat(settingsMgr.CurrentBookType.ToString(), "_", "ALICUOTAS", "_", settingsMgr.OutputConfig.DefaultFileName, ".txt");

                        if (sfd.ShowDialog() != DialogResult.OK)
                            return;

                        settingsMgr.OutputConfig.FileName = sfd.FileName;

                        File.WriteAllText(settingsMgr.OutputConfig.FilePath, logs["aliquots"]["log"]);

                        MessageBox.Show
                        (
                            string.Format("{0} comprobantes generados, {1} alicuotas generadas", logs["vouchers"]["amount"], logs["aliquots"]["amount"]),
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
        }

        // http://stackoverflow.com/questions/24338735/check-if-the-all-values-of-array-are-different
        private bool CheckIndexesEquality(Dictionary<string, dynamic> indexes)
        {
            List<int> values = new List<int>();

            foreach (var item in indexes.Values)
            {
                if (item is int)
                {
                    values.Add(item);
                }
                else if (item is decimal)
                {
                    values.Add((int)item);
                }
                else if (item is IEnumerable)
                {
                    var isDictionary = item is Dictionary<string, int>;
                    foreach (var subitem in item)
                    {
                        values.Add(Convert.ToInt32(isDictionary ? subitem.Value : subitem));
                    }
                }
            }

            return !(values.Distinct().Count() == values.Count);
        }

        private void btnSaveDocumentSettings_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();

            sfd.Filter = settingsMgr.IndexesConfig.DialogFilter;
            sfd.Title = settingsMgr.IndexesConfig.SaveFileDialogTitle;
            sfd.InitialDirectory = settingsMgr.IndexesConfig.Directory;
            sfd.FileName = string.Concat(settingsMgr.IndexesConfig.IndexFileDefaultName, "_", settingsMgr.CurrentBookType.ToString());

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var documentSettings = new DocumentSettings();

            documentSettings.SalesPointAndVoucherNumberInTheSameColumn.Value = cbSalesPointAndVoucherNumberInTheSameColumn.Checked;

            var indexes = new Indexes
            {
                Date = new Index(nudDate.Value, cbDate.Checked),
                VoucherType = new Index(nudVoucherType.Value, cbVoucherType.Checked),
                SalesPoint = new Index(nudSalesPoint.Value, cbSalesPoint.Checked),
                VoucherNumber = new Index(nudVoucherNumber.Value, cbVoucherNumber.Checked),
                SellerName = new Index(nudSellerName.Value, cbSellerName.Checked),
                SellerIDNumber = new Index(nudSellerNumber.Value, cbSellerNumber.Checked),
                UntaxedNet = new Index(nudUntaxedNet.Value, cbUntaxedNet.Checked),
                GrossIncome = new Index(txtGrossIncome.Text, cbGrossIncome.Checked),
                InternalTaxes = new Index(nudInternalTaxes.Value, cbInternalTaxes.Checked),
                Total = new Index(nudTotal.Value, cbTotal.Checked),
                Aliquots = new List<Serialization.Alicuota>()
                    {
                        { new Serialization.Alicuota(21, nudAliquot21.Value, cbAliquot21.Checked) },
                        { new Serialization.Alicuota(10.5m, nudAliquot105.Value, cbAliquot105.Checked) },
                        { new Serialization.Alicuota(27, nudAliquot27.Value, cbAliquot27.Checked)},
                        { new Serialization.Alicuota(5, nudAliquot5.Value, cbAliquot5.Checked)},
                        { new Serialization.Alicuota(2.5m, nudAliquot250.Value, cbAliquot250.Checked)},
                        { new Serialization.Alicuota(0, nudAliquot0.Value, cbAliquot0.Checked)},
                    }
            };

            switch (settingsMgr.CurrentSettings.LastBookTypeUsed.Value)
            {
                case TiposLibro.COMPRAS:
                    indexes = new BuysIndexes(indexes)
                    {
                        ImportClearance = new Index(nudImportClearance.Value, cbImportClearance.Checked),
                        VATPerceptionsAmount = new Index(nudVATPerceptionsAmount.Value, cbVATPerceptionsAmount.Checked),
                        ComputableTaxCredit = new Index(nudComputableTaxCredit.Value, cbComputableTaxCredit.Checked),
                        CUITIssuer = new Index(nudCUITIssuer.Value, cbCUITIssuer.Checked),
                        IssuerName = new Index(nudIssuerName.Value, cbIssuerName.Checked),
                        VATCommission = new Index(nudVATCommission.Value, cbVATCommission.Checked)
                    };
                    break;
                case TiposLibro.VENTAS:
                    indexes = new SalesIndexes(indexes)
                    {
                        VoucherNumberUntil = new Index(nudVoucherNumberUntil.Value, cbVoucherNumberUntil.Checked),
                        UncategorizedPerceptionAmount = new Index(nudUncategorizedPerceptionAmount.Value, cbUncategorizedPerceptionAmount.Checked),
                        PaymentExpireDate = new Index(nudPaymentExpireDate.Value, cbPaymentExpireDate.Checked)
                    };
                    break;
            }

            documentSettings.Indexes = indexes;

            byte[] oldHash = File.Exists(sfd.FileName) ? sfd.FileName.GetFileHash() : new byte[] { };

            string xml = documentSettings.SerializeToXML();

            try
            {
                File.WriteAllText(sfd.FileName, xml);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (File.Exists(sfd.FileName) && sfd.FileName.FileHasBeenModified(oldHash))
                {
                    MessageBox.Show("Preferencias guardadas con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void btnLoadDocumentSettings_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            ofd.Filter = settingsMgr.IndexesConfig.DialogFilter;
            ofd.Title = settingsMgr.IndexesConfig.OpenFileDialogTitle;
            ofd.InitialDirectory = settingsMgr.IndexesConfig.Directory;

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            settingsMgr.CurrentIndexesPath = ofd.FileName;

            var ds = SerializationHelpers.Deserialize<DocumentSettings>(ofd.FileName);

            RestoreDocumentSettings(ds);

            Text = string.Concat("SiAp Parser", " - ", ofd.FileName);

            MessageBox.Show("Preferencias cargadas con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int? GenerateIndex(CheckBox cb, NumericUpDown nud)
        {
            if (cb == null || nud == null)
                return null;

            if (!cb.Enabled || !cb.Checked || !nud.Enabled)
                return null;

            int i = (int)nud.Value;

            return i;
        }

        private List<int> GenerateIndexes(CheckBox cb, TextBox txtBox)
        {
            if (cb == null || txtBox == null)
                return null;

            if (!cb.Enabled || !cb.Enabled || !txtBox.Enabled || string.IsNullOrWhiteSpace(txtBox.Text))
                return null;

            var indexes = Regex.Replace(txtBox.Text, @"\s+", string.Empty).Split(',');

            return indexes.Select(n => int.Parse(n)).ToList();
        }

        /// <summary>
        /// Restores both indexes and document-specific settings (NOT GLOBAL SETTINGS)
        /// </summary>
        /// <param name="i"></param>
        private void RestoreDocumentSettings(DocumentSettings settings)
        {
            if (settings == null)
                return;

            #region Settings

            cbSalesPointAndVoucherNumberInTheSameColumn.Checked = settings.SalesPointAndVoucherNumberInTheSameColumn.Value;

            #endregion

            #region Indexes

            var i = settings.Indexes;

            if (i == null)
                return;

            #region General indexes

            cbDate.Checked = nudDate.Enabled = i.Date.Enabled;
            cbVoucherType.Checked = nudVoucherType.Enabled = i.VoucherType.Enabled;
            cbSalesPoint.Checked = nudSalesPoint.Enabled = i.SalesPoint.Enabled;
            cbVoucherNumber.Checked = nudVoucherNumber.Enabled = i.VoucherNumber.Enabled;
            cbSellerName.Checked = nudSellerName.Enabled = i.SellerName.Enabled;
            cbSellerNumber.Checked = nudSellerNumber.Enabled = i.SellerIDNumber.Enabled;
            cbUntaxedNet.Checked = nudUntaxedNet.Enabled = i.UntaxedNet.Enabled;
            cbInternalTaxes.Checked = nudInternalTaxes.Enabled = i.InternalTaxes.Enabled;
            cbGrossIncome.Checked = txtGrossIncome.Enabled = i.GrossIncome.Enabled;
            cbTotal.Checked = nudTotal.Enabled = i.Total.Enabled;

            nudDate.Value = i.Date.Number;
            nudVoucherType.Value = i.VoucherType.Number;
            nudSalesPoint.Value = i.SalesPoint.Number;
            nudVoucherNumber.Value = i.VoucherNumber.Number;
            nudSellerName.Value = i.SellerName.Number;
            nudSellerNumber.Value = i.SellerIDNumber.Number;
            nudUntaxedNet.Value = i.UntaxedNet.Number;
            nudInternalTaxes.Value = i.InternalTaxes.Number;
            txtGrossIncome.Text = i.GrossIncome.Value;
            nudTotal.Value = i.Total.Number;

            #endregion

            #region Buys indexes

            if (i is BuysIndexes bi)
            {
                cbImportClearance.Checked = nudImportClearance.Enabled = bi.ImportClearance.Enabled;
                cbVATPerceptionsAmount.Checked = nudVATPerceptionsAmount.Enabled = bi.VATPerceptionsAmount.Enabled;
                cbComputableTaxCredit.Checked = nudComputableTaxCredit.Enabled = bi.ComputableTaxCredit.Enabled;
                cbCUITIssuer.Checked = nudCUITIssuer.Enabled = bi.CUITIssuer.Enabled;
                cbIssuerName.Checked = nudIssuerName.Enabled = bi.IssuerName.Enabled;
                cbVATCommission.Checked = nudVATCommission.Enabled = bi.VATCommission.Enabled;

                nudImportClearance.Value = bi.ImportClearance.Number;
                nudVATPerceptionsAmount.Value = bi.VATPerceptionsAmount.Number;
                nudComputableTaxCredit.Value = bi.ComputableTaxCredit.Number;
                nudCUITIssuer.Value = bi.CUITIssuer.Number;
                nudIssuerName.Value = bi.IssuerName.Number;
                nudVATCommission.Value = bi.VATCommission.Number;
            }

            #endregion

            #region Sales indexes

            if (i is SalesIndexes si)
            {
                cbVoucherNumberUntil.Checked = nudVoucherNumberUntil.Enabled = si.VoucherNumberUntil.Enabled;
                cbUncategorizedPerceptionAmount.Checked = nudUncategorizedPerceptionAmount.Enabled = si.UncategorizedPerceptionAmount.Enabled;
                cbPaymentExpireDate.Checked = nudPaymentExpireDate.Enabled = si.PaymentExpireDate.Enabled;

                nudVoucherNumberUntil.Value = si.VoucherNumberUntil.Number;
                nudUncategorizedPerceptionAmount.Value = si.UncategorizedPerceptionAmount.Number;
                nudPaymentExpireDate.Value = si.PaymentExpireDate.Number;
            }

            #endregion

            #region Aliquots

            foreach (var a in i.Aliquots)
            {
                switch ((int)(a.Percentage * 100))
                {
                    case 2700:
                        nudAliquot27.Value = a.Index;
                        cbAliquot27.Checked = a.Enabled;
                        break;
                    case 1050:
                        nudAliquot105.Value = a.Index;
                        cbAliquot105.Checked = a.Enabled;
                        break;
                    case 2100:
                        nudAliquot21.Value = a.Index;
                        cbAliquot21.Checked = a.Enabled;
                        break;
                }
            }

            #endregion

            #endregion
        }

        private void cbIndexes_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;

            if (cb == null)
                return;

            if (cb != ActiveControl)
                return;

            Control control = null;

            switch (cb.Name)
            {
                #region General for both book types

                case "cbDate":
                    control = nudDate;
                    break;
                case "cbVoucherType":
                    control = nudVoucherType;
                    break;
                case "cbSalesPoint":
                    control = nudSalesPoint;
                    break;
                case "cbVoucherNumber":
                    control = cbVoucherNumber;
                    break;
                case "cbSellerName":
                    control = cbSellerName;
                    break;
                case "cbSellerNumber":
                    control = nudSellerNumber;
                    break;
                case "cbUntaxedNet":
                    control = nudUntaxedNet;
                    break;
                case "cbGrossIncome":
                    control = txtGrossIncome;
                    break;
                case "cbInternalTaxes":
                    control = nudInternalTaxes;
                    break;
                case "cbTotal":
                    control = nudTotal;
                    break;
                #endregion

                #region Aliquots

                case "cbAliquot21":
                    control = nudAliquot21;
                    break;
                case "cbAliquot105":
                    control = nudAliquot105;
                    break;
                case "cbAliquot27":
                    control = nudAliquot27;
                    break;

                #endregion

                #region Buys book

                case "cbImportClearance":
                    control = nudImportClearance;
                    break;
                case "cbVATPerceptionsAmount":
                    control = nudVATPerceptionsAmount;
                    break;
                case "cbComputableTaxCredit":
                    control = nudComputableTaxCredit;
                    break;
                case "cbCUITIssuer":
                    control = nudCUITIssuer;
                    break;
                case "cbIssuerName":
                    control = nudIssuerName;
                    break;
                case "cbVATCommission":
                    control = nudVATCommission;
                    break;

                    #endregion
            }

            try
            {
                control.Enabled = cb.Checked;
            }
            catch (NullReferenceException)
            {
                cb.Checked = false;
                MessageBox.Show
                (
                    "Control asociado no encontrado",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            settingsMgr.CurrentBookType = (TiposLibro)((ComboBoxItem)((ComboBox)sender).SelectedItem).Value;

            switch (settingsMgr.CurrentBookType)
            {
                case TiposLibro.COMPRAS:
                    tabSalesIndexes.Enabled = false;
                    tabBuysIndexes.Enabled = true;
                    tabSpecificIndexes.SelectedIndex = 0;
                    break;
                case TiposLibro.VENTAS:
                    tabBuysIndexes.Enabled = false;
                    tabSalesIndexes.Enabled = true;
                    tabSpecificIndexes.SelectedIndex = 1;
                    break;
            }
        }

        private void tabSpecificIndexes_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = !e.TabPage.Enabled;
        }

        #region Menu

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl is Label || ctrl is Button) continue;
                if (ctrl is ComboBox) ((ComboBox)ctrl).SelectedIndex = 0;
                if (ctrl is TextBox) ctrl.Text = string.Empty;
                if (ctrl is NumericUpDown) ((NumericUpDown)ctrl).Value = 0;
            }

            tabCtrlSettings.Visible = btnProcessFile.Enabled = false;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var of = new OptionsForm(this);
            of.ShowDialog();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ab = new AboutBox();
            ab.ShowDialog();
        }

        #endregion

        private Dictionary<string, Dictionary<string, string>> GenerateLogFromVoucherList(dynamic list)
        {
            if (list == null)
                return null;

            if (list.Count == 0)
                return null;

            var vouchersSb = new StringBuilder();
            var aliquotsSb = new StringBuilder();

            var dic = new Dictionary<string, Dictionary<string, string>>();

            ushort vc = 0, ac = 0;

            foreach (var c in list)
            {
                vouchersSb.AppendLine(c.ToString());
                vc++;

                foreach (var a in c.Alicuotas)
                {
                    aliquotsSb.AppendLine(a.ToString());
                    ac++;
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

        private void cbAutodetectIndexes_Click(object sender, EventArgs e)
        {
            string input =
                Interaction.InputBox
                (
                    "Por favor ingrese el índice (basado en 0) de la fila en la que se encuetran las cabeceras de la tabla",
                    "Atención",
                    "0",
                    -1,
                    -1
                );

            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                return;

            int headersIndex = int.Parse(input);

            if (headersIndex < 0)
                return;

            input =
                Interaction.InputBox
                (
                    "Por favor ingrese la cantidad de columnas de la tabla",
                    "Atención",
                    "2",
                    -1,
                    -1
                );

            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                return;

            int columnsAmount = int.Parse(input);

            if (columnsAmount < 2)
                return;

            try
            {
                var excelReader = File.Open(txtFilepath.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite).GetExcelDataReader();
                var dic = new Dictionary<string, int>();

                for (int i = 0; i <= headersIndex; i++)
                    excelReader.Read();

                for (int i = 0; i <= columnsAmount; i++)
                {
                    try
                    {
                        string lec = Regex.Replace(excelReader.GetSafeString(i).ToLower(), @"[.%]", string.Empty).Trim();

                        if (string.IsNullOrEmpty(lec) || string.IsNullOrWhiteSpace(lec))
                            continue;

                        if (lec.IndexOf("fecha") != -1)
                            dic.Add("Date", i);
                        else if (lec.IndexOf("tipo") != -1 || lec.IndexOf("tipo de comprobante") != -1)
                            dic.Add("VoucherType", i);
                        else if (lec.IndexOf("punto de venta") != -1)
                            dic.Add("SalesPoint", i);
                        else if (lec.IndexOf("número") != -1 || lec.IndexOf("numero") != -1 || lec.IndexOf("número de comprobante") != -1 || lec.IndexOf("número de factura") != -1)
                            dic.Add("VoucherNumber", i);
                        else if (lec.IndexOf("proveedor") != -1)
                            dic.Add("SellerName", i);
                    }
                    catch
                    {
                        continue;
                    }
                }

                if (cbDate.Checked)
                    nudDate.Value = dic["Date"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}