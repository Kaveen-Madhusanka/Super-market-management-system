using Newtonsoft.Json;
using SMMS.Common;
using SMMS.HRIMGT.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMMS.HRIMGT.Views
{
    public partial class frmEmployee : Form
    {


        #region VARIABLES
        List<EmployeeDTO> Employees = new List<EmployeeDTO>();
        #endregion.VARIABLES

        #region INITIALIZE
        public frmEmployee()
        {
            InitializeComponent();
        }
        #endregion.INITIALIZE

        #region EVENTS
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            init();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (AddEmployee())
                {
                    MessageBox.Show(ResponseMessages.RegisterSuccess, ResponseMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(ResponseMessages.InsertError, ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (true)
            {
                if (!string.IsNullOrEmpty(txtEmpId.Text))
                {
                    if (MessageBox.Show(ResponseMessages.DeleteQuestion, ResponseMessages.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (DeleteEmployee())
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
                    MessageBox.Show("Please insert  the Employee Id", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (UpdateEmployee())
                {
                    MessageBox.Show(ResponseMessages.EmployeUpdateSuccess, ResponseMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(ResponseMessages.InsertError, ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        private void dgvEmployees_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];
                    txtEmpId.Text = row.Cells["empId"].Value.ToString();
                    txtEmpName.Text = row.Cells["empName"].Value.ToString();
                    txtEmail.Text = row.Cells["email"].Value.ToString();
                    txtContact.Text = row.Cells["contactNo"].Value.ToString();
                    txtAddress.Text = row.Cells["address"].Value.ToString();
                    //var x = row.Cells["department"].Value.ToString();
                    cmbDepartment.Text = row.Cells["department"].Value.ToString();
                    cmbEmpType.Text = row.Cells["empType"].Value.ToString();
                    dtpEmpDOB.Value = Convert.ToDateTime(row.Cells["dob"].Value);

                    btnRegister.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
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
        private void txtEmployeeSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeSearch.Text))
            {
                LoadEmployees();
            }
            else
            {
                SearchEmployee();
            }
        }
        private void txtEmpId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EmployeeDTO oEmployeeDTO = new EmployeeDTO();
                oEmployeeDTO = Employees.Where(x => x.empId == txtEmpId.Text).FirstOrDefault();
                if (oEmployeeDTO != null)
                {
                    txtEmpId.Text = oEmployeeDTO.empId;
                    txtEmpName.Text = oEmployeeDTO.empName;
                    txtEmail.Text = oEmployeeDTO.empEmail;
                    txtContact.Text = oEmployeeDTO.empContact;
                    txtAddress.Text = oEmployeeDTO.empAddress;
                    cmbDepartment.Text = oEmployeeDTO.empDepartment;
                    cmbEmpType.SelectedItem = (Enums.EmployeeType)oEmployeeDTO.empType;
                    dtpEmpDOB.Value = oEmployeeDTO.empDOB;
                    btnRegister.Enabled = false;
                }
                else
                {
                    txtEmpName.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtContact.Text = string.Empty;
                    txtAddress.Text = string.Empty;
                    cmbDepartment.SelectedIndex = 0;
                    cmbEmpType.SelectedIndex = 0;
                    dtpEmpDOB.Value = DateTime.Now;
                    btnRegister.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion.EVENTS

        #region METHODS
        private void init()
        {
            try
            {
                dgvEmployees.AutoGenerateColumns = false;
                LoadEmployees();
                setDropDowns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void setDropDowns()
        {
            cmbDepartment.DataSource = Enum.GetValues(typeof(Enums.Department));
            cmbEmpType.DataSource = Enum.GetValues(typeof(Enums.EmployeeType));
        }
        private EmployeeDTO CollectData()
        {
            EmployeeDTO oEmployeeDTO = new EmployeeDTO();
            oEmployeeDTO.empId = txtEmpId.Text;
            oEmployeeDTO.empName = txtEmpName.Text;
            oEmployeeDTO.empEmail = txtEmail.Text;
            oEmployeeDTO.empContact = txtContact.Text;
            oEmployeeDTO.empAddress = txtAddress.Text;
            oEmployeeDTO.empDepartment = cmbDepartment.SelectedValue.ToString();
            oEmployeeDTO.empType = (int)(Enums.EmployeeType)cmbEmpType.SelectedValue;
            oEmployeeDTO.empDOB = dtpEmpDOB.Value;
            oEmployeeDTO.modifiedUser = GlobalParameters.CurrentUserId;
            oEmployeeDTO.modifiedDateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
            oEmployeeDTO.modifiedMachine = GlobalParameters.CurrentMachine;
            return oEmployeeDTO;
        }
        private void ResetForm()
        {
            txtEmpId.Text = string.Empty;
            txtEmpName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtAddress.Text = string.Empty;
            cmbDepartment.SelectedIndex = 0;
            cmbEmpType.SelectedIndex = 0;
            dtpEmpDOB.Value = DateTime.Now;
            btnRegister.Enabled = true;
            LoadEmployees();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtEmpId.Text))
            {
                MessageBox.Show("Please insert  the EmployeeId", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtEmpId;
                return false;
            }
            else if (string.IsNullOrEmpty(txtEmpName.Text))
            {
                MessageBox.Show("Please insert the Employee Name", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtEmpName;
                return false;
            }
            else if (txtContact.Text.Length < 10)
            {
                MessageBox.Show("Invalid contact No!", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtContact;
                return false;
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Please insert Address for the Employee!", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtAddress;
                return false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Please insert Email for the Employee", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtEmail;
                return false;
            }
            else if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Invaid Email", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtEmail;
                return false;
            }
            return true;
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
        #endregion.METHODS

        #region  WEB_API_CALL
        private void LoadEmployees()
        {
            try
            {
                List<EmployeeDTO> oEmployeeDTO = new List<EmployeeDTO>();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Employee/GetEmployees";
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        oEmployeeDTO = JsonConvert.DeserializeObject<List<EmployeeDTO>>(jsnString);
                        dgvEmployees.DataSource = oEmployeeDTO;
                        Employees = oEmployeeDTO;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private bool AddEmployee()
        {
            try
            {
                bool result = false;
                EmployeeDTO employee = CollectData();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Employee/AddEmployee";
                    HttpResponseMessage response = client.PostAsJsonAsync(path, employee).Result;
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
        private bool UpdateEmployee()
        {
            try
            {
                bool result = false;
                EmployeeDTO employee = CollectData();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Employee/UpdateEmployee";
                    HttpResponseMessage response = client.PutAsJsonAsync(path, employee).Result;
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
        private bool DeleteEmployee()
        {
            try
            {
                bool result = false;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Employee/DeleteEmployee?employee=" + txtEmpId.Text.Trim();
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
        private List<EmployeeDTO> SearchEmployee()
        {
            try
            {
                List<EmployeeDTO> oEmployeeDTO = new List<EmployeeDTO>();
                EmployeeDTO employee = new EmployeeDTO();
                employee.empId = txtEmployeeSearch.Text;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Employee/SearchEmployee";
                    HttpResponseMessage response = client.PostAsJsonAsync(path, employee).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        oEmployeeDTO = JsonConvert.DeserializeObject<List<EmployeeDTO>>(jsnString);
                        dgvEmployees.DataSource = oEmployeeDTO;
                    }
                }
                return oEmployeeDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        #endregion.WEB_API_CALL
    }
}
