using System;
using System.Collections.Generic;
using SMMS.IMGT.Domain;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using SMMS.Common;
using Newtonsoft.Json;
using System.Net.Mail;

namespace SMMS.IMG.Views
{
    public partial class frmSupplier : Form
    {


        #region VARIABLES
        #endregion VARIABLES

        #region INITIALIZE
        public frmSupplier()
        {
            InitializeComponent();
        }
        #endregion INITIALIZE

        #region EVENTS
        private void frmSupplier_Load(object sender, EventArgs e)
        {
            init();
        }
        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadSuppliers();
            }
            else
            {
                SearchSuppliers();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (AddSupplier())
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
        private void btnUpdatte_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (UpdateSupplier())
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSupplierID.Text))
            {
                if (MessageBox.Show(ResponseMessages.DeleteQuestion, ResponseMessages.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (DeleteSupplier())
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
                MessageBox.Show("Please insert Id for the Supplier", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        private void dgvSuppliers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvSuppliers.Rows[e.RowIndex];
                    txtSupplierID.Text = row.Cells["sid"].Value.ToString();
                    txtSName.Text = row.Cells["Sname"].Value.ToString();
                    txtSAddress.Text = row.Cells["saddress"].Value.ToString();
                    txtContactNo.Text = row.Cells["scontactNo"].Value.ToString();
                    txtSEmail.Text = row.Cells["sEmail"].Value.ToString();
                    txtAddedProducts.Text = row.Cells["sProducts"].Value.ToString();
                    cmbProducts.SelectedValue = row.Cells["sProducts"].Value.ToString();
                    btnAdd.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void btnAddproduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAddedProducts.Text))
                {
                    txtAddedProducts.Text = cmbProducts.SelectedValue.ToString();
                }
                else
                {
                    txtAddedProducts.Text = txtAddedProducts.Text + "," + cmbProducts.SelectedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        #endregion EVENTS

        #region MTHODS
        private void init()
        {
            try
            {
                dgvSuppliers.AutoGenerateColumns = false;
                LoadSuppliers();
                setDropDowns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void LoadSuppliers()
        {
            dgvSuppliers.DataSource = GetSuppliers();
        }
        private supplierDTO collectData()
        {
            supplierDTO osupplierDTO = new supplierDTO();
            osupplierDTO.sId = txtSupplierID.Text.Trim();
            osupplierDTO.sName = txtSName.Text;
            osupplierDTO.sAddress = txtSAddress.Text;
            osupplierDTO.sContactNo = Convert.ToInt32(txtContactNo.Text);
            osupplierDTO.sEmail = txtSEmail.Text;
            osupplierDTO.pId = txtAddedProducts.Text;
            osupplierDTO.modifiedUser = GlobalParameters.CurrentUserId;
            osupplierDTO.modifiedDateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
            osupplierDTO.modifiedMachine = GlobalParameters.CurrentMachine;

            return osupplierDTO;
        }
        private void setDropDowns()
        {
            List<productDTO> suppliers = GetProducts();
            this.cmbProducts.DataSource = suppliers;
            this.cmbProducts.DisplayMember = "pName";
            this.cmbProducts.ValueMember = "pId";
        }
        private void ResetForm()
        {
            txtSupplierID.Text = string.Empty;
            txtSName.Text = string.Empty;
            txtSAddress.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtSearch.Text = string.Empty;
            txtSEmail.Text = string.Empty;
            txtAddedProducts.Text = string.Empty;
            cmbProducts.SelectedIndex = 0;

            btnAdd.Enabled = true;
            LoadSuppliers();
        }
        public bool IsValidEmail(string email)
        {
            if (email.IndexOf("@") <= 0) return false;
            try
            {
                var address = new MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool ValidateInputs()
        {
            bool result = true;
            if (string.IsNullOrEmpty(txtSupplierID.Text))
            {
                MessageBox.Show("Please insert Id for the Supplier", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtSupplierID;
                return false;

            }
            else if (string.IsNullOrEmpty(txtSName.Text))
            {
                MessageBox.Show("Please insert Name for the Supplier", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtSName;
                return false;
            }
            else if (string.IsNullOrEmpty(txtSAddress.Text))
            {
                MessageBox.Show("Please insert Address for the Supplier", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtSAddress;
                return false;
            }
            else if (string.IsNullOrEmpty(txtContactNo.Text))
            {
                MessageBox.Show("Please insert Contact no for the Supplier", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtContactNo;
                return false;
            }
            else if (txtContactNo.Text.Length < 10)
            {
                MessageBox.Show("Contact No Invalid", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtContactNo;
                return false;
            }
            else if (string.IsNullOrEmpty(txtSEmail.Text))
            {
                MessageBox.Show("Please insert Email for the Supplier", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtSEmail;
                return false;
            }
            else if (!IsValidEmail(txtSEmail.Text))
            {
                MessageBox.Show("Invaid Email", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtSEmail;
                return false;
            }
            else if (string.IsNullOrEmpty(txtAddedProducts.Text))
            {
                MessageBox.Show("Please Enter product for supplier", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = cmbProducts;
                return false;
            }
            return true;
        }
        #endregion METHODS

        #region WEB_API_CALLS
        private List<supplierDTO> GetSuppliers()
        {
            try
            {
                List<supplierDTO> osupplierDTO = new List<supplierDTO>();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Supplier/GetSupplier";
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        osupplierDTO = JsonConvert.DeserializeObject<List<supplierDTO>>(jsnString);
                    }
                }
                return osupplierDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private List<supplierDTO> SearchSuppliers()
        {
            try
            {
                List<supplierDTO> osupplierDTO = new List<supplierDTO>();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Supplier/searchSupplier?sId=" + txtSearch.Text;
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        osupplierDTO = JsonConvert.DeserializeObject<List<supplierDTO>>(jsnString);
                        dgvSuppliers.DataSource = osupplierDTO;

                    }
                }
                return osupplierDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool AddSupplier()
        {
            try
            {
                bool result = false;
                supplierDTO Supplier = collectData();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Supplier/addSupplier";
                    HttpResponseMessage response = client.PostAsJsonAsync(path, Supplier).Result;
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

        private bool UpdateSupplier()
        {
            try
            {
                bool result = false;
                supplierDTO Supplier = collectData();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Supplier/updateSupplier";
                    HttpResponseMessage response = client.PutAsJsonAsync(path, Supplier).Result;
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
                return oproductDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool DeleteSupplier()
        {
            try
            {
                bool result = false;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Supplier/deleteSupplier?sId=" + txtSupplierID.Text.Trim();
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
