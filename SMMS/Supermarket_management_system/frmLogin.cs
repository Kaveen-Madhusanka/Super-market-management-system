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

namespace Supermarket_management_system
{
    public partial class frmLogin : Form
    {
        #region VARIABLES

        #endregion VARIABLES

        #region INITIALIZE
        public frmLogin()
        {
            InitializeComponent();

        }
        #endregion INITIALIZE

        #region EVENTS
        private void frmLogin_Load(object sender, EventArgs e)
        {
            ActiveControl = txtUserName;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateUser())
            {
                AddGlobalData();
                frmHome home = new frmHome();
                home.WindowState = FormWindowState.Maximized;
                home.Show();
                this.Hide();
            }
            
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnRegoster_Click(object sender, EventArgs e)
        {
            frmRegister register = new frmRegister();
            this.Dispose();
            register.Show();
        }
        private void txtUserName_Click(object sender, EventArgs e)
        {
            hidePlaceholderUname();
        }
        private void txtPassword_Click(object sender, EventArgs e)
        {
            hidePlaceholderPasssword();
        }
        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text == string.Empty)
            {
                txtUserName.ForeColor = Color.DarkGray;
                txtUserName.Text = "Enter User Name";
            }
        }
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == string.Empty)
            {
                //txtPassword.ForeColor = Color.DarkGray;
                //txtPassword.Text = "Enter Password";
                frontxtPWD.BringToFront();
            }
        }
        private void frontxtPWD_Click(object sender, EventArgs e)
        {
            hidePlaceholderPasssword();
        }
        #endregion EVENTS

        #region METHODS
        private void hidePlaceholderUname()
        {
            if (txtUserName.Text == "Enter User Name")
            {
                txtUserName.Text = string.Empty;
                txtUserName.ForeColor = Color.Black;
            }
        }
        private void hidePlaceholderPasssword()
        {
            //if (txtPassword.Text == "Enter Password")
            //{
            //    txtPassword.Text = string.Empty;
            //    txtPassword.ForeColor = Color.Black;
            //}
            txtPassword.BringToFront();
            txtPassword.Focus();
        }
        private bool ValidateUser()
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
            else
            {
                int UserStatus = IsValidUser();
                switch (UserStatus)
                {
                    case (int)Enums.UserLoginResult.ValidUser:
                        result = true;
                        break;
                    case (int)Enums.UserLoginResult.InactiveUser:
                        result = false;
                        MessageBox.Show("You are not Active user");
                        break;
                    case (int)Enums.UserLoginResult.InvalidPassword:
                        result = false;
                        MessageBox.Show("Incorrect password!");
                        break;
                    case (int)Enums.UserLoginResult.InvalidUser:
                        result = false;
                        MessageBox.Show("User Name is Incorrect!");
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
        #endregion METHODS

        #region WEB_API_CALLS

        public int IsValidUser()
        {
            try
            {
                int Result = 0;
                //string CipherPassword = EncriptionFcatory.Encrypt(txtPassword.Text, txtUserName.Text);
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "User/IsValidUser?UserName=" + txtUserName.Text.Trim()+"&Password="+ txtPassword.Text;
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        Result = JsonConvert.DeserializeObject<int>(jsnString);

                    }
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        #endregion WEB_API_CALLS

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Tab))
            {
                txtPassword.BringToFront();
                txtPassword.Focus();
                return true;
            }
            if (keyData == (Keys.Enter))
            {
                btnLogin.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void AddGlobalData()
        {
            GlobalParameters.CurrentUserId = txtUserName.Text;
            GlobalParameters.CurrentUsername = txtUserName.Text;
            GlobalParameters.CurrentMachine = System.Environment.MachineName;
            
        }
    }
}
