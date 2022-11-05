using Newtonsoft.Json;
using SMMS.Common;
using SMMS.IMGT.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMMS.IMG.Views
{
    public partial class frmproduct : Form
    {

        #region VARIABLES
        #endregion VARIABLES

        #region INITIALIZE
        public frmproduct()
        {
            InitializeComponent();
        }
        #endregion INITIALIZE

        #region EVENTS
        private void frmProduct_Load(object sender, EventArgs e)
        {
            init();
        }
        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtProductSearch.Text))
            {
                LoadProducts();
            }
            else
            {
                SearchProducts();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (AddProduct())
                {
                    MessageBox.Show(ResponseMessages.InsertSuccess, ResponseMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(ResponseMessages.InsertError, ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(ResponseMessages.UpdateQuestion, ResponseMessages.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ValidateInputs())
                {
                    if (UpdateProduct())
                    {
                        MessageBox.Show(ResponseMessages.UpdateSuccess, ResponseMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                    }
                    else
                    {
                        MessageBox.Show(ResponseMessages.UpdateError, ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                } 
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductID.Text))
            {
                if (MessageBox.Show(ResponseMessages.DeleteQuestion, ResponseMessages.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (DeleteProduct())
                    {
                        MessageBox.Show(ResponseMessages.DeleteSuccess, ResponseMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                    }
                    else
                    {
                        MessageBox.Show(ResponseMessages.DeleteError, ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } 
            }
            else
            {
                MessageBox.Show("Please insert Id for the product", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        private void dgvProducts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
                    txtProductID.Text = row.Cells["pid"].Value.ToString();
                    txtProductName.Text = row.Cells["pname"].Value.ToString();
                    cmbProductCatogery.Text =  row.Cells["pcatogery"].Value.ToString();
                    cmbProductQType.Text = row.Cells["pqType"].Value.ToString();
                    txtProductQuntity.Text = row.Cells["pQuntity"].Value.ToString();
                    txtPrice.Text = row.Cells["price"].Value.ToString();
                    cmbSupplier.SelectedValue = row.Cells["pSupplier"].Value.ToString();
                    txtBarcode.Text = row.Cells["pbarcode1"].Value.ToString();

                    btnAdd.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void KeyPressOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            ValidateAlredyAdd();
        }
        #endregion EVENTS

        #region MTHODS
        private void LoadTheme()
        {
            //foreach (Control btns in this.Controls)
            //{
            //    if (btns.GetType() == typeof(Button))
            //    {
            //        Button btn = (Button)btns;
            //        btn.BackColor = ThemeColor.PrimaryColor;
            //        btn.ForeColor = Color.White;
            //        btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            //    }
            //}
            //label4.ForeColor = ThemeColor.SecondaryColor;
            //label5.ForeColor = ThemeColor.PrimaryColor;
        }

        private void init()
        {
            try
            {
                dgvProducts.AutoGenerateColumns = false;
                LoadProducts();
                setDropDowns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadProducts()
        {
            dgvProducts.DataSource = GetProducts();
        }

        private productDTO collectData()
        {
            productDTO oproductDTO = new productDTO();
            oproductDTO.pId = txtProductID.Text.Trim();
            oproductDTO.pName = txtProductName.Text;
            oproductDTO.pCategoery = (int)Enum.Parse(typeof(Enums.ProductCatogery), cmbProductCatogery.Text); 
            oproductDTO.pQuntityType = (int)(Enums.ProductCatogery)cmbProductQType.SelectedValue;
            oproductDTO.pQuntity = Convert.ToDouble(txtProductQuntity.Text);
            oproductDTO.pPrice = Convert.ToDouble(txtPrice.Text);
            oproductDTO.pBarcode = txtBarcode.Text;
            oproductDTO.sId = cmbSupplier.SelectedValue.ToString();
            oproductDTO.modifiedUser = GlobalParameters.CurrentUserId;
            oproductDTO.modifiedDateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
            oproductDTO.modifiedMachine = GlobalParameters.CurrentMachine;

            return oproductDTO;
        }

        private void setDropDowns()
        {
            cmbProductCatogery.DataSource = Enum.GetValues(typeof(Common.Enums.ProductCatogery));

            cmbProductQType.DataSource = Enum.GetValues(typeof(Common.Enums.QunitiType));

            List<supplierDTO> suppliers = GetSuppliers();
            this.cmbSupplier.DataSource = suppliers;
            this.cmbSupplier.DisplayMember = "sName";
            this.cmbSupplier.ValueMember = "sId";
        }

        private void ResetForm()
        {
            txtProductID.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductQuntity.Text = string.Empty;
            txtBarcode.Text = string.Empty;
            txtProductSearch.Text = string.Empty;
            cmbProductCatogery.SelectedIndex = 0;
            cmbProductQType.SelectedIndex = 0;
            cmbSupplier.SelectedIndex = 0;
            txtPrice.Text = string.Empty;

            btnAdd.Enabled = true;
            LoadProducts();
        }

        private bool ValidateInputs()
        {
            bool result = true;
            if (string.IsNullOrEmpty(txtProductID.Text))
            {
                MessageBox.Show("Please insert Id for the product", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtProductID;
                return false;

            }
            else if (string.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Please insert Name for the product", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtProductName;
                return false;
            }
            else if (string.IsNullOrEmpty(txtProductQuntity.Text))
            {
                MessageBox.Show("Please insert initial quntity for the product", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtProductQuntity;
                return false;
            }
            else if (string.IsNullOrEmpty(txtBarcode.Text))
            {
                MessageBox.Show("Please insert Barcode for the product", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtBarcode;
                return false;
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Please insert price for the product", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtPrice;
                return false;
            }
            return true;
        }

        private void ValidateAlredyAdd()
        {
            productDTO product = new productDTO();
            List<productDTO> products = (List<productDTO>)dgvProducts.DataSource;
            product = products.Where(x=> x.pId == txtProductID.Text).FirstOrDefault();
            if (product != null)
            {
                txtProductName.Text = product.pName;
                cmbProductCatogery.SelectedItem = product.pCategoeryText;
                cmbProductQType.SelectedItem = product.pQuntityTypeText;
                txtProductQuntity.Text = product.pQuntity.ToString();
                txtPrice.Text = product.pPrice.ToString();
                cmbSupplier.SelectedValue = product.sId;
                txtBarcode.Text = product.pBarcode;

                this.btnAdd.Enabled = false;
            }
            else
            {
                txtProductName.Text = string.Empty;
                txtProductQuntity.Text = string.Empty;
                txtBarcode.Text = string.Empty;
                txtProductSearch.Text = string.Empty;
                cmbProductCatogery.SelectedIndex = 0;
                cmbProductQType.SelectedIndex = 0;
                cmbSupplier.SelectedIndex = 0;
                txtPrice.Text = string.Empty;

                this.btnAdd.Enabled = true;
            }
        }
        #endregion METHODS

        #region WEB_API_CALLS
        private List<productDTO> GetProducts()
        {
            try
            {
                List<productDTO> oproductDTO = new List<productDTO>();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    //string path = WebAPIPaths.WebAPI + "product/GetProducts?batchno=" + ddlV1BatchNo.SelectedValue.ToString() + "&processDate=" + dtpV1ProcessDate.Value.ToString("yyyy-MM-dd") + "&clearingCycle=" + Convert.ToInt32(ddlV1ClearingCycle.SelectedValue);
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

        private List<productDTO> SearchProducts()
        {
            try
            {
                List<productDTO> oproductDTO = new List<productDTO>();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "product/searchProduct?pId=" + txtProductSearch.Text;
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        oproductDTO = JsonConvert.DeserializeObject<List<productDTO>>(jsnString);
                        dgvProducts.DataSource = oproductDTO;

                    }
                }
                return oproductDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool AddProduct()
        {
            try
            {
                bool result = false;
                productDTO prodcut = collectData();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "product/addProduct";
                    HttpResponseMessage response = client.PostAsJsonAsync(path, prodcut).Result;
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

                throw;
            }

        }

        private bool UpdateProduct()
        {
            try
            {
                bool result = false;
                productDTO prodcut = collectData();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "product/updateProduct";
                    HttpResponseMessage response = client.PutAsJsonAsync(path, prodcut).Result;
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

                throw;
            }

        }

        private List<supplierDTO> GetSuppliers()
        {
            try
            {
                List<supplierDTO> oproductDTO = new List<supplierDTO>();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Supplier/GetSupplier";
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        oproductDTO = JsonConvert.DeserializeObject<List<supplierDTO>>(jsnString);
                    }
                }
                return oproductDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool DeleteProduct()
        {
            try
            {
                bool result = false;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "product/deleteProduct?pId="+ txtProductID.Text.Trim();
                    HttpResponseMessage response = client.DeleteAsync(path).Result;
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

                throw;
            }

        }

        #endregion WEB_API_CALLS

       
    }
}
