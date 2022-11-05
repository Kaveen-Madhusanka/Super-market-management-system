
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using SMMS.Common;
using SMMS.IMGT.Domain;
using SMMS.SalesMGT.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMMS.SalesMGT.Views
{
    public partial class frmSales : Form
    {

        #region VARIABLES
        List<productDTO> Products = new List<productDTO>();
        List<SalesDTO> Bill = new List<SalesDTO>();
        String ActiveTextBox = "txtQuntity";
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        private double sumOfDiscount = 0.00;
        #endregion VARIABLES

        #region INITIALIZE
        public frmSales()
        {
            InitializeComponent();
        }
        #endregion INITIALIZE

        #region EVENTS
        private void frmSales_Load(object sender, EventArgs e)
        {
            init();
        }
        private void Key_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (ActiveTextBox == "txtQuntity")
            {
                if (txtQuntity.Text == "0")
                {
                    txtQuntity.Text = " ";
                    txtQuntity.Text = btn.Text;
                }
                else if (btn.Text == ".")
                {
                    if (!txtQuntity.Text.Contains("."))
                    {
                        txtQuntity.Text = txtQuntity.Text + btn.Text;
                    }
                }
                else
                {
                    txtQuntity.Text = txtQuntity.Text + btn.Text;
                }
            }
            else if (ActiveTextBox == "txtDiscount")
            {
                if (txtDiscount.Text == "0")
                {
                    txtDiscount.Text = " ";
                    txtDiscount.Text = btn.Text;
                }
                else if (btn.Text == ".")
                {
                    if (!txtDiscount.Text.Contains("."))
                    {
                        txtDiscount.Text = txtDiscount.Text + btn.Text;
                    }
                }
                else
                {
                    txtDiscount.Text = txtDiscount.Text + btn.Text;
                }
            }
            else if (ActiveTextBox == "txtCash")
            {
                if (txtCash.Text == "0")
                {
                    txtCash.Text = " ";
                    txtCash.Text = btn.Text;
                }
                else if (btn.Text == ".")
                {
                    if (!txtCash.Text.Contains("."))
                    {
                        txtCash.Text = txtCash.Text + btn.Text;
                    }
                }
                else
                {
                    txtCash.Text = txtCash.Text + btn.Text;
                }
            }
        }
        private void KeyBackespace_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQuntity.Text))
            {
                txtQuntity.Text = txtQuntity.Text.Remove(txtQuntity.Text.Length - 1, 1);
            }
        }
        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                productDTO oproductDTO = new productDTO();
                oproductDTO = Products.Where(x => x.pId == cmbProductName.SelectedValue.ToString()).FirstOrDefault();
                if (oproductDTO != null)
                {
                    txtBarcode.Text = oproductDTO.pBarcode;
                    txtItemId.Text = oproductDTO.pId;
                    txtPrice.Text = oproductDTO.pPrice.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtItemId.Text))
            {
                AddItemToBill();
                CLear();
            }
            else
            {
                MessageBox.Show("Please Add products", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void txtQuntity_Click(object sender, EventArgs e)
        {
            ActiveTextBox = "txtQuntity";
        }
        private void txtDiscount_Click(object sender, EventArgs e)
        {
            ActiveTextBox = "txtDiscount";
        }
        private void txtCash_Click(object sender, EventArgs e)
        {
            ActiveTextBox = "txtCash";
        }
        private void btnPay_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCash.Text))
            {
                MessageBox.Show("Please Enter Cash");
            }
            else if (Convert.ToDouble(txtCash.Text) < Convert.ToDouble(txtTotal.Text))
            {
                MessageBox.Show("Cash not enough for pay bill.!");
            }
            else
            {
                printclick();
                AddBill();
                lblBalance.Text = (Convert.ToDouble(txtCash.Text) - Convert.ToDouble(txtTotal.Text)).ToString();
                lblTotal.Text = "0.00";
                dgvBill.DataSource = null;
                //lblBalance.Text = string.Empty;
                txtTotal.Text = "0.00";
                Bill.Clear();
                IncreesBillNo();
            }
        }
        private void dgvBill_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    SalesDTO oSalesDTO = new SalesDTO();
                    DataGridViewRow row = dgvBill.Rows[e.RowIndex];
                    oSalesDTO.Name = row.Cells["item"].Value.ToString();
                    oSalesDTO.quntity = (double)row.Cells["quntity"].Value;
                    oSalesDTO.price = (double)row.Cells["itemPrice"].Value;
                    oSalesDTO.discount = (double)row.Cells["discount"].Value;
                    oSalesDTO.subTotal = (double)row.Cells["total"].Value;

                    Form formBackground = new Form();
                    try
                    {
                        using (frmBillItem uu = new frmBillItem(oSalesDTO))
                        {
                            formBackground.StartPosition = FormStartPosition.Manual;
                            formBackground.FormBorderStyle = FormBorderStyle.None;
                            formBackground.Opacity = .50d;
                            formBackground.BackColor = Color.Black;
                            formBackground.WindowState = FormWindowState.Maximized;
                            formBackground.TopMost = true;
                            formBackground.Location = this.Location;
                            formBackground.ShowInTaskbar = false;
                            formBackground.Show();

                            uu.Owner = formBackground;
                            uu.ShowDialog();
                            formBackground.Dispose();
                            if (GlobalBillDTO.isUpdate)
                            {
                                UpdateItem();
                            }
                            else
                            {
                                DeleteItem();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        formBackground.Dispose();
                    }
                    ////
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somethin went Wrong");
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Add))
            {
                btnAddItem_Click(null, null);
                cmbProductName.Focus();
                return true;
            }
            if (keyData == (Keys.ShiftKey | Keys.Shift))
            {
                btnPay_Click(null, null);
                cmbProductName.Focus();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnDiscard_Click(object sender, EventArgs e)
        {
            dgvBill.DataSource = null;
            lblTotal.Text = "0.00";
            lblBalance.Text = "0.00";
            txtTotal.Text = "0.00";
            Bill.Clear();
        }
        private void BTNcLEAR_Click(object sender, EventArgs e)
        {
            txtCash.Text = string.Empty;
            lblBalance.Text = string.Empty;
            CLear();
            Bill.Clear();
        }
        #endregion EVENTS

        #region METHODS
        private void init()
        {
            GenaarateBillNo();
            lblCashier.Text = GlobalParameters.CurrentUserId;
            lblDate.Text = DateTime.Now.ToString("MM-dd-yy");
            txtDiscount.Text = "0.00";
            txtQuntity.Text = "1";
            dgvBill.AutoGenerateColumns = false;
            cmbProductName.Items.Clear();
            cmbProductName.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbProductName.AutoCompleteSource = AutoCompleteSource.ListItems;
            setDropdowns();
        }
        private void setDropdowns()
        {
            Products = GetProducts();
            cmbProductName.DataSource = Products;
            cmbProductName.DisplayMember = "pName";
            cmbProductName.ValueMember = "pId";
        }
        private void AddItemToBill()
        {
            var alredyAdd = Bill.Where(x => x.pID == txtItemId.Text).FirstOrDefault();
            if (alredyAdd == null)
            {
                SalesDTO item = new SalesDTO();
                item.Name = cmbProductName.Text;
                item.quntity = Convert.ToDouble(txtQuntity.Text);
                item.pID = txtItemId.Text;
                item.discount = Convert.ToDouble(txtDiscount.Text);
                item.price = Convert.ToDouble(txtPrice.Text);
                item.subTotal = (Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtQuntity.Text)) - ((Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtQuntity.Text) * Convert.ToDouble(txtDiscount.Text)) / 100);
                sumOfDiscount = sumOfDiscount + ((Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtQuntity.Text) * Convert.ToDouble(txtDiscount.Text)) / 100);
                Bill.Add(item);
                dgvBill.DataSource = null;
                dgvBill.DataSource = Bill;
                lblTotal.Text = (Convert.ToDouble(lblTotal.Text) + item.subTotal).ToString("F");
                txtTotal.Text = lblTotal.Text;
            }
            else
            {
                MessageBox.Show("Alredy " + cmbProductName.Text + " Add to the bill. You can edit the item.!!! ", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        private void CLear()
        {
            txtBarcode.Text = string.Empty;
            cmbProductName.Text = string.Empty;
            txtItemId.Text = string.Empty;
            txtQuntity.Text = "1";
            txtDiscount.Text = "0.00";
            txtPrice.Text = "0.00";
            sumOfDiscount = 0.00;
        }
        private void UpdateItem()
        {
            try
            {
                foreach (var bill in Bill.Where(w => w.Name == GlobalBillDTO.Bill.Name))
                {
                    bill.quntity = GlobalBillDTO.Bill.quntity;
                    bill.discount = GlobalBillDTO.Bill.discount;
                    bill.subTotal = (GlobalBillDTO.Bill.price * GlobalBillDTO.Bill.quntity) - ((GlobalBillDTO.Bill.price * GlobalBillDTO.Bill.quntity) * GlobalBillDTO.Bill.discount / 100);
                }
                dgvBill.DataSource = null;
                dgvBill.DataSource = Bill;
                lblTotal.Text = Bill.Sum(x => x.subTotal).ToString("F");
                txtTotal.Text = lblTotal.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somethin went Wrong");
            }
        }
        private void DeleteItem()
        {
            try
            {
                Bill.RemoveAll(X => X.Name == GlobalBillDTO.Bill.Name);
                dgvBill.DataSource = null;
                dgvBill.DataSource = Bill;
                lblTotal.Text = Bill.Sum(x => x.subTotal).ToString("F");
                txtTotal.Text = lblTotal.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private _SalesDTO collectData()
        {
            try
            {
                _SalesDTO o_SalesDTO = new _SalesDTO();

                o_SalesDTO.billNo = lblBillNo.Text;
                o_SalesDTO.cashier = lblCashier.Text;
                o_SalesDTO.total = Convert.ToDouble(lblTotal.Text);
                o_SalesDTO.discount = sumOfDiscount;
                o_SalesDTO.modifiedUser = GlobalParameters.CurrentUserId;
                o_SalesDTO.modifiedDateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
                o_SalesDTO.modifiedMachine = GlobalParameters.CurrentMachine;

                return (o_SalesDTO);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        private void IncreesBillNo()
        {
            if (!string.IsNullOrEmpty(lblBillNo.Text))
            {
                lblBillNo.Text = GlobalParameters.CurrentUserId.Substring(GlobalParameters.CurrentUserId.Length - 2).ToString() + (1 + Convert.ToInt32(lblBillNo.Text.Remove(0, 2))).ToString();

            }
        }
        private string GenaarateBillNo()
        {
            try
            {
                String BillNo = GetLastBillNO();
                if (!string.IsNullOrEmpty(BillNo))
                {
                    lblBillNo.Text = GlobalParameters.CurrentUserId.Substring(GlobalParameters.CurrentUserId.Length - 2).ToString() + (1 + Convert.ToInt32(BillNo.Remove(0, 2))).ToString();
                }
                else
                {
                    lblBillNo.Text = GlobalParameters.CurrentUserId.Substring(GlobalParameters.CurrentUserId.Length - 2).ToString() + 1;
                }
                return BillNo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bill No Genartion error");
                return string.Empty;
            }
        }
        private bool AddBill()
        {
            bool result = false;
            result = addSales();
            result = addOrder();
            result = updateProductQuntity();
            return result;
        }
        private List<orderDTO> CollectOrderData()
        {
            try
            {
                List<orderDTO> order = new List<orderDTO>();
                foreach (var item in Bill)
                {
                    orderDTO oorderDTO = new orderDTO();
                    oorderDTO.billNo = lblBillNo.Text;
                    oorderDTO.pid = item.pID;
                    oorderDTO.quantity = item.quntity;
                    oorderDTO.discount = item.discount;
                    oorderDTO.subTotal = item.subTotal;
                    oorderDTO.modifiedUser = GlobalParameters.CurrentUserId;
                    oorderDTO.modifiedDateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
                    oorderDTO.modifiedMachine = GlobalParameters.CurrentMachine;
                    order.Add(oorderDTO);
                }
                return order;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong!");
                return null;
            }
        }
        #endregion METHODS

        #region WEB_API_CALL
        private List<productDTO> GetProducts()
        {
            try
            {
                List<productDTO> oproductDTO = new List<productDTO>();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "product/GetProducts";
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        oproductDTO = JsonConvert.DeserializeObject<List<productDTO>>(jsnString);
                    }
                }
                return oproductDTO.OrderByDescending(x => x.pId).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool addSales()
        {
            try
            {
                bool result = false;
                _SalesDTO o_SalesDTO = collectData();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Sales/addSales";
                    HttpResponseMessage response = client.PostAsJsonAsync(path, o_SalesDTO).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        result = JsonConvert.DeserializeObject<bool>(jsnString);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        private string GetLastBillNO()
        {
            try
            {
                string billNo = string.Empty;
                using (HttpClient client = new HttpClient())
                {
                    string UserId = GlobalParameters.CurrentUserId.Substring(GlobalParameters.CurrentUserId.Length - 2).Trim();
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Sales/GetLastBillNO?userID=" + UserId + "";
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        billNo = JsonConvert.DeserializeObject<string>(jsnString);
                    }
                }
                return billNo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool addOrder()
        {
            try
            {
                bool result = false;
                List<orderDTO> Order = CollectOrderData();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Order/addOrder";
                    HttpResponseMessage response = client.PostAsJsonAsync(path, Order).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        result = JsonConvert.DeserializeObject<bool>(jsnString);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        private bool updateProductQuntity()
        {
            try
            {
                bool result = false;
                List<orderDTO> Order = CollectOrderData();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Order/updateProductQuntity";
                    HttpResponseMessage response = client.PutAsJsonAsync(path, Order).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        result = JsonConvert.DeserializeObject<bool>(jsnString);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        #endregion WEB_API_CALL


        #region PRINT
        private void printclick()
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(Bill);
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

            ReportDataSource rds = new ReportDataSource("DataSetBill", dt);
            string Total = lblTotal.Text;
            LocalReport report = new LocalReport();
            string path = @"E:\SIBA\2nd chapter\project work\SMMS\SMMS\SMMS.SalesMGT.Views\rptBill.rdlc";
            report.ReportPath = path;
            report.DataSources.Add(rds);
            ReportParameter rp = new ReportParameter("Total", Total);
            report.SetParameters(rp);
            PrintToPrinter(report);
        }
        public static void PrintToPrinter(LocalReport report)
        {
            Export(report);

        }

        public static void Export(LocalReport report, bool print = true)
        {
            string deviceInfo =
             @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>4.3in</PageWidth>
                <PageHeight>8.0in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0.1in</MarginLeft>
                <MarginRight>0.1in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;

            if (print)
            {
                Print();
            }
        }


        public static void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        public static Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        public static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }
        #endregion PRINT
    }
}
