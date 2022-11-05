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
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMMS.UserMGT.Views
{
    public partial class frmUserAccount : Form
    {
       

        #region VARIABLES
        Random rnd = new Random();
        int VerficationCode;
        int ClicklUpdate = 0; // Contact 1, address 2, password 3
        EmployeeDTO oEmployeeDTO = new EmployeeDTO();
        UserDTO userData = new UserDTO();
        #endregion VARIABLES

        #region INITIALIZE
        public frmUserAccount()
        {
            InitializeComponent();
        }
        #endregion INITIALIZE

        #region EVENTS
        private void frmUserAccount_Load(object sender, EventArgs e)
        {
            Init();
        }
        private void btnUpdateContact_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNewContact.Text))
                {
                    ClicklUpdate = 1;
                    sendEmail();
                    pnlVerification.Visible = true;
                    txtPnlVerficationcode.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Please Enter New Contact", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something Went Wrong!", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnPnlOk_Click(object sender, EventArgs e)
        {
            if (VerficationCode.ToString() == txtPnlVerficationcode.Text)
            {
                oEmployeeDTO.modifiedUser = GlobalParameters.CurrentUserId;
                oEmployeeDTO.modifiedDateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
                oEmployeeDTO.modifiedMachine = GlobalParameters.CurrentMachine;
                userData.modifiedUser = GlobalParameters.CurrentUserId;
                userData.modifiedDateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
                userData.modifiedMachine = GlobalParameters.CurrentMachine;

                if (ClicklUpdate == 1)//contact
                {
                    oEmployeeDTO.empContact = txtNewContact.Text;
                    userData.userPhoneNo = txtNewContact.Text;
                    UpdateEmployee(oEmployeeDTO);
                    ChangeUserData(userData);
                }
                else if (ClicklUpdate == 2)// address
                {
                    oEmployeeDTO.empAddress = txtNewAddress.Text;
                    UpdateEmployee(oEmployeeDTO);
                }
                else if (ClicklUpdate == 3)// password
                {
                    userData.userPassword = Common.EncriptionFcatory.Encrypt(txtNewPassword.Text, userData.userID);
                    ChangeUserData(userData);
                }
                MessageBox.Show("Successfuly Updated!", ResponseMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
            else
            {
                MessageBox.Show("Wrong Verification Code!", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNewAddress.Text))
                {
                    ClicklUpdate = 2;
                    sendEmail();
                    pnlVerification.Visible = true;
                    txtPnlVerficationcode.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Please Enter New Address", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something Went Wrong!", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNewPassword.Text))
                {
                    if (txtNewPassword.Text.Length >= 8)
                    {
                        ClicklUpdate = 3;
                        sendEmail();
                        pnlVerification.Visible = true;
                        txtPnlVerficationcode.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Password length must be  8 digit or more!", ResponseMessages.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter New Password", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something Went Wrong!", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNewContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnContactChange_Click(object sender, EventArgs e)
        {
            DisableAll();
            txtNewContact.Enabled = true;
            btnUpdateContact.Enabled = true;
        }

        private void btnAddressChange_Click(object sender, EventArgs e)
        {
            DisableAll();
            txtNewAddress.Enabled = true;
            btnUpdateAddress.Enabled = true;
        }

        private void btnPasswordChange_Click(object sender, EventArgs e)
        {
            DisableAll();
            txtNewPassword.Enabled = true;
            btnUpdatePassword.Enabled = true;
        }
        #endregion EVENTS

        #region METHODS
        private void Init()
        {
            pnlVerification.Visible = false;
            userData = GetUser();
            oEmployeeDTO = GetEmaployee();
            setUserData();
            DisableAll();
        }
        private void setUserData()
        {
            txtEmpId.Text = userData.userID;
            txtContact.Text = userData.userPhoneNo;
            txtPassword.Text = Common.EncriptionFcatory.Decrypt(userData.userPassword,userData.userID);
            txtAddress.Text = oEmployeeDTO.empAddress;
        }
        private bool sendEmail()
        {
            try
            {
                if (string.IsNullOrEmpty(oEmployeeDTO.empEmail))
                {
                    return false;
                }
                EmailDTO emailDTO = GetEmailDetails();
                VerficationCode = rnd.Next();
                SmtpClient clientDetails = new SmtpClient();
                clientDetails.Port = 587;
                clientDetails.Host = "smtp.gmail.com";
                clientDetails.EnableSsl = true;
                clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                clientDetails.UseDefaultCredentials = false;
                clientDetails.Credentials = new NetworkCredential(emailDTO.email, emailDTO.password);

                MailMessage mailDetails = new MailMessage();
                mailDetails.From = new MailAddress(emailDTO.email);
                mailDetails.To.Add(oEmployeeDTO.empEmail);//to address
                mailDetails.Subject = "Verification ".Trim();
                mailDetails.IsBodyHtml = true;
                mailDetails.Body = " <p>Dear Employee, <br /> <br /> Your Verification code : " + " " + VerficationCode + "</p>";

                clientDetails.Send(mailDetails);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void DisableAll()
        {
            txtNewContact.Enabled = false;
            txtNewAddress.Enabled = false;
            txtNewPassword.Enabled = false;
            txtPnlVerficationcode.Enabled = false;
            btnUpdateContact.Enabled = false;
            btnUpdateAddress.Enabled = false;
            btnUpdatePassword.Enabled = false;
        }
        private void Clear()
        {
            txtNewContact.Text = string.Empty;
            txtNewAddress.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtPnlVerficationcode.Text = string.Empty;
            Init();
        }
        #endregion METHODS

        #region WEB_API_CALL
        private UserDTO GetUser()
        {
            try
            {
                UserDTO oUserDTO = new UserDTO();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "User/GetUserbyName?UserId=" + GlobalParameters.CurrentUserId;
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        oUserDTO = JsonConvert.DeserializeObject<UserDTO>(jsnString);

                    }
                }
                return oUserDTO;
            }
            catch (Exception)
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
                employee.empId = GlobalParameters.CurrentUserId;
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
        private bool UpdateEmployee(EmployeeDTO employee)
        {
            try
            {
                bool result = false;
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
        private bool ChangeUserData(UserDTO oUserDTO)
        {
            try
            {
                bool result = false;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "User/ChangeUserData";
                    HttpResponseMessage response = client.PutAsJsonAsync(path, oUserDTO).Result;
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
        private EmailDTO GetEmailDetails()
        {
            try
            {

                EmailDTO emailDTO = new EmailDTO();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "User/GetEmailDetails";
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        emailDTO = JsonConvert.DeserializeObject<EmailDTO>(jsnString);
                    }
                }
                return emailDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion WEB_API_CALL




    }
}
