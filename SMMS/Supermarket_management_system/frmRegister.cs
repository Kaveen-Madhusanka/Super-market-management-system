using Newtonsoft.Json;
using SMMS.Common;
using SMMS.HRIMGT.Domain;
using SMMS.UserMGT.Domain;
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

namespace Supermarket_management_system
{
    public partial class frmRegister : Form
    {
        #region VARIABLES
        #endregion VARIABLES

        #region INITIALIZE
        public frmRegister()
        {
            InitializeComponent();
        }
        #endregion INITIALIZE

        #region EVENTS
        private void frmRegister_Load(object sender, EventArgs e)
        {
            ActiveControl = txtUserName;
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text == string.Empty)
            {
                txtUserName.ForeColor = Color.DarkGray;
                txtUserName.Text = "Enter User Name";
            }
        }

        private void txtUserName_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "Enter User Name")
            {
                txtUserName.Text = string.Empty;
                txtUserName.ForeColor = Color.Black;
            }
        }
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == string.Empty)
            {
                txtEmail.ForeColor = Color.DarkGray;
                txtEmail.Text = "Enter Email";
            }
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Enter Email")
            {
                txtEmail.Text = string.Empty;
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == string.Empty)
            {
                txtPassword.ForeColor = Color.DarkGray;
                txtPassword.Text = "Enter Password";
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter Password")
            {
                txtPassword.Text = string.Empty;
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtReEnterPassword_Leave(object sender, EventArgs e)
        {
            if (txtReEnterPassword.Text == string.Empty)
            {
                txtReEnterPassword.ForeColor = Color.DarkGray;
                txtReEnterPassword.Text = "Enter Password";
            }
        }

        private void txtReEnterPassword_Click(object sender, EventArgs e)
        {
            if (txtReEnterPassword.Text == "Enter Password")
            {
                txtReEnterPassword.Text = string.Empty;
                txtReEnterPassword.ForeColor = Color.Black;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            this.Dispose();
            login.Show();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateEmptyInputs())
            {
                if (GetEmaployee()!= null)
                {
                    if (ValidateInputFormat())
                    {
                        if (InsertUser())
                        {
                            MessageBox.Show(ResponseMessages.RegisterSucsess, ResponseMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetForm();
                        }
                        else
                        {
                            MessageBox.Show(ResponseMessages.RegisterError, ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You should register as employee before register as user. Then enter employee id as user name", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        #endregion EVENTS

        #region METHODS
        private UserDTO CollectData()
        {
            UserDTO user = new UserDTO();
            user.userID = txtUserName.Text.Trim();
            user.userName = txtUserName.Text.Trim();
            user.userEmailAddress = txtEmail.Text;
            user.userPhoneNo = string.Empty;
            user.userType = (int)Enums.UserType.staff;
            user.userRole = 1;
            user.userStatus = (int)Enums.UserStatus.Active;
            user.userLoginMachine = GlobalParameters.CurrentMachine;
            user.userRole = 1;
            user.userInvLoginAttempts = 0;
            user.userLastLoginAttempt = DateTime.Now;
            user.userLastLogin = DateTime.Now;
            user.userLastPwdChange = DateTime.Now;
            user.userPassword = txtPassword.Text;
            user.userInvLoginAttempts = 0;
            user.isPwdNeverExpire = 0;
            user.modifiedDateTime = DateTime.Now;
            user.modifiedUser = GlobalParameters.CurrentUserId;
            user.modifiedMachine = GlobalParameters.CurrentMachine;

            return user;

        }
        private void ResetForm()
        {
            txtUserName.Text = "Enter User Name";
            txtEmail.Text = "Enter Email";
            txtPassword.Text = "Enter Password";
            txtReEnterPassword.Text = "Enter Password";
        }
        private bool ValidateEmptyInputs()
        {
            bool result = false;
            if (txtUserName.Text == "Enter User Name")
            {
                MessageBox.Show("Please Enter Username");
                this.ActiveControl = txtUserName;
                result = false;
            }
            else if (txtPassword.Text == "Enter Password")
            {
                MessageBox.Show("Please Enter Password");
                this.ActiveControl = txtPassword;
                result = false;
            }
            else if (txtEmail.Text == "Enter Email")
            {
                MessageBox.Show("Please Enter Email");
                this.ActiveControl = txtEmail;
                result = false;
            }
            else if (txtReEnterPassword.Text == "Re-Enter Password")
            {
                MessageBox.Show("Please fill Re-enter password!");
                this.ActiveControl = txtReEnterPassword;
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
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
        private bool ValidateInputFormat()
        {
            bool result = true;
            //User Name
            //Email
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Enter Valid Email");
                txtEmail.Focus();
                return false;
            }
            //Password
            if (txtPassword.Text != txtReEnterPassword.Text)
            {
                MessageBox.Show("Password not matched");
                txtReEnterPassword.Focus();
                return false;
            }
            else
            {
                if (txtPassword.Text.Length < 8)
                {
                    MessageBox.Show("Password length must be more than 8 digit");
                    txtPassword.Focus();
                    return false;
                }
            }

            return result;
        }
        #endregion METHODS

        #region WEB_API_CALL
        private bool InsertUser()
        {
            try
            {
                bool result = false;
                UserDTO user = CollectData();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "User/InsertUser";
                    HttpResponseMessage response = client.PostAsJsonAsync(path, user).Result;
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
        private EmployeeDTO GetEmaployee()
        {
            try
            {
                List<EmployeeDTO> oEmployeeDTO = new List<EmployeeDTO>();
                EmployeeDTO employee = new EmployeeDTO();
                employee.empId = txtUserName.Text;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Employee/SearchEmployee";
                    HttpResponseMessage response = client.PostAsJsonAsync(path, employee).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        oEmployeeDTO = JsonConvert.DeserializeObject<List<EmployeeDTO>>(jsnString);
                    }
                }
                return oEmployeeDTO.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion WEB_API_CALL


    }
}
