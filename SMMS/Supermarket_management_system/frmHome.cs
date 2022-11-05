using Newtonsoft.Json;
using SMMS.Common;
using SMMS.HRIMGT.Domain;
using SMMS.IMG.Views;
using SMMS.SalesMGT.Views;
using Supermarket_management_system.Designs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket_management_system
{
    public partial class frmHome : Form
    {
        #region VARIABLES
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        Form activeForm;
        #endregion VARIABLES
        #region INITIALIZE

        public frmHome()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;// comment for get border
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]// for control without control box 
        private extern static void ReleaseCapture();// for control without control box 
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion INITIALIZE

        #region METHODS
        
        //Methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    //panelMenu.BackColor = color;// for change side bar panel color
                    //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    GlobalParameters.ThemeColor = color;
                    btnCloseChildForm.Visible = true;

                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
            pcbLogo.BringToFront();
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            //panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            //panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        public void OpenChildForm(Form childForm, object btnSender, bool isChild = false)
        {
            if (isChild == true)
            {
                this.panelDesktopPane.Controls.Clear();
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                this.panelDesktopPane.Controls.Add(childForm);
                this.panelDesktopPane.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
                lblTitle.Text = childForm.Text;

                List<string> elements = new List<string>();
                foreach (Form item in Application.OpenForms)
                    elements.Add(item.Name);
                int index = elements.IndexOf("frmHome");
                if (index >= 0)
                {
                    Application.OpenForms[index].Close();
                }
                this.WindowState = FormWindowState.Maximized;
                btnCloseChildForm.Visible = true;
            }
            else
            {
                if (activeForm != null)
                {
                    activeForm.Close();
                }
                ActivateButton(btnSender);
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                this.panelDesktopPane.Controls.Add(childForm);
                this.panelDesktopPane.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
                lblTitle.Text = childForm.Text;
            }
        }
        #endregion METHODS
        #region EVENTS
        private void button1_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender);
            //OpenChildForm(new frmproduct(), sender);
            OpenChildForm(new frmIMGTHome(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender);
            OpenChildForm(new frmSales(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmEMGTHome(), sender);
        }
        private void btnUsersArea_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmUsersAreaHome(), sender);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            this.Dispose();
            login.Show();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmHome_Deactivate(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            this.TopMost = false;
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmReportsHome(), sender);
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSettings(), sender);
        }

        #endregion EVENTS

        private void frmHome_Load(object sender, EventArgs e)
        {
            Authorization(SearchEmployee());
        }

        private void Authorization(EmployeeDTO employeeDTO)
        {
            if (employeeDTO != null)
            {
                if (employeeDTO.empType == (int)Enums.EmployeeType.Cashier)
                {
                    button3.Enabled = false;
                    btnReports.Enabled = false;
                    btnSettings.Enabled = false;
                    button1.Enabled = false;
                }
                else if (employeeDTO.empType == (int)Enums.EmployeeType.Helper)
                {
                    button3.Enabled = false;
                    button2.Enabled = false;
                    btnReports.Enabled = false;
                    btnSettings.Enabled = false;
                    button1.Enabled = false;
                }
                else if (employeeDTO.empType == (int)Enums.EmployeeType.HRManager)
                {
                    button2.Enabled = false;
                    btnReports.Enabled = false;
                    btnSettings.Enabled = false;
                    button1.Enabled = false;
                }
                else if (employeeDTO.empType == (int)Enums.EmployeeType.StockManager)
                {
                    button2.Enabled = false;
                    button3.Enabled = false;
                    btnSettings.Enabled = false;
                    button1.Enabled = false;
                }
                else if (employeeDTO.empType == (int)Enums.EmployeeType.SalesManager)
                {
                    button3.Enabled = false;
                    button1.Enabled = false;
                    btnSettings.Enabled = false;
                    button1.Enabled = false;
                } 
            }
        }
        private EmployeeDTO SearchEmployee()
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
    }
}
