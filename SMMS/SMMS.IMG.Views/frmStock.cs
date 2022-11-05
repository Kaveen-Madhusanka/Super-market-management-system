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
    public partial class frmStock : Form
    {
        #region VARIABLES
        bool IsFormLoad = false;
        List<productDTO> oproductDTO = new List<productDTO>();
        #endregion VARIABLES

        #region INITIALIZE
        public frmStock()
        {
            InitializeComponent();
        }
        #endregion INITIALIZE

        #region EVENTS
        private void frmStock_Load(object sender, EventArgs e)
        {
            init();
            IsFormLoad = true;
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
        private void dgvStock_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvStock.Rows[e.RowIndex];
                    txtProductName.Text = row.Cells["pname"].Value.ToString();
                    //txtProductQuntity.Text = row.Cells["pQuntity"].Value.ToString();
                    cmbproduct.SelectedValue = row.Cells["pid"].Value.ToString();
                    txtBarcode.Text = row.Cells["pbarcode1"].Value.ToString();

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void cmbproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTextBoxValues();
        }
        private void btnStockIn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductQuntity.Text))
            {
                productDTO product = CollectData();
                product.pQuntity = product.pQuntity + Convert.ToDouble(txtProductQuntity.Text);
                if (UpdateStock(product))
                {
                    MessageBox.Show("Successfuly Stock in !", ResponseMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(ResponseMessages.CommonError, ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Enter Quntity!", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductQuntity.Text))
            {
                productDTO product = CollectData();
                if (product.pQuntity > Convert.ToDouble(txtProductQuntity.Text))
                {
                    product.pQuntity = product.pQuntity - Convert.ToDouble(txtProductQuntity.Text);
                    if (UpdateStock(product))
                    {
                        MessageBox.Show("Successfuly Stock out !", ResponseMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                    }
                    else
                    {
                        MessageBox.Show(ResponseMessages.CommonError, ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Stock not enough!", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("Please Enter Quntity!", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        #endregion EVENTS

        #region METHODS
        private void init()
        {
            try
            {
                dgvStock.AutoGenerateColumns = false;
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
            dgvStock.DataSource = GetProducts();
        }
        private void setDropDowns()
        {
            this.cmbproduct.DataSource = oproductDTO;
            this.cmbproduct.DisplayMember = "pId";
            this.cmbproduct.ValueMember = "pId";
        }
        private productDTO CollectData()
        {
            productDTO product = oproductDTO.Where(x => x.pId == cmbproduct.SelectedValue.ToString()).FirstOrDefault();
            product.modifiedUser = GlobalParameters.CurrentUserId;
            product.modifiedDateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
            product.modifiedMachine = GlobalParameters.CurrentMachine;

            return product;
        }
        private void SetTextBoxValues()
        {
            if (IsFormLoad)
            {
                productDTO product = oproductDTO.Where(x => x.pId == cmbproduct.SelectedValue.ToString()).FirstOrDefault();
                txtProductName.Text = product.pName;
                txtBarcode.Text = product.pBarcode;
            }
        }
        private void ResetForm()
        {
            cmbproduct.SelectedIndex = 0;
            txtProductName.Text = string.Empty;
            txtProductQuntity.Text = string.Empty;
            txtProductSearch.Text = string.Empty;
            txtBarcode.Text = string.Empty;
            LoadProducts();
        }
        #endregion METHODS

        #region WEB_API_CALL
        private List<productDTO> GetProducts()
        {
            try
            {

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
                return oproductDTO;
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
                        dgvStock.DataSource = oproductDTO;

                    }
                }
                return oproductDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool UpdateStock(productDTO prodcut)
        {
            try
            {
                bool result = false;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Stock/updateStock";
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

        #endregion WEB_API_CALL


    }
}
