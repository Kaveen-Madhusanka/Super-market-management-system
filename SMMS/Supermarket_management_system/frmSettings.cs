using Newtonsoft.Json;
using SMMS.Common;
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
    public partial class frmSettings : Form
    {


        #region VARIABLES
        #endregion VARIABLES

        #region INITIALIZE
        public frmSettings()
        {
            InitializeComponent();
        }
        #endregion INITIALIZE

        #region EVETNS
        private void frmSettings_Load(object sender, EventArgs e)
        {
            cmbSSL.SelectedIndex = 0;
        }
        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                EmailDTO emailDTO = new EmailDTO();
                emailDTO.email = txtEmail.Text;
                emailDTO.password = txtPassword.Text;
                emailDTO.host = txtHost.Text;
                emailDTO.ssl = cmbSSL.Text == "True" ? 1 :0;
                
                if (UpdateEmailsettings(emailDTO))
                {
                    MessageBox.Show("Configuration successful!", ResponseMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
                else
                {
                    MessageBox.Show("Something Went Wrong!", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        #endregion EVETNS

        #region MTEHODS
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
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Please insert  the Email", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtEmail;
                return false;
            }
            else if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please insert valid Email", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtPassword;
                return false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please insert the Password", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtPassword;
                return false;
            }
            else if (string.IsNullOrEmpty(txtHost.Text))
            {
                MessageBox.Show("IPlease insert the Host Ex:smtp.gmail.com!", ResponseMessages.Stop, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.ActiveControl = txtHost;
                return false;
            }
            return true;
        }

        private void clear()
        {
            txtEmail.Text = string.Empty;
            txtHost.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cmbSSL.SelectedIndex = 0;
        }
        #endregion METHODS

        #region WEB_API_CALL
        private bool UpdateEmailsettings(EmailDTO emailDTO)
        {
            try
            {
                bool result = false;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "User/UpdateEmailsettings";
                    HttpResponseMessage response = client.PutAsJsonAsync(path, emailDTO).Result;
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
