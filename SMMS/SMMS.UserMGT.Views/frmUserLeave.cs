using Microsoft.Reporting.WinForms;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMMS.UserMGT.Views
{
    public partial class frmUserLeave : Form
    {


        #region VARIABLES
        EmployeeLeavesDTO oEmployeeLeavesDTOO = new EmployeeLeavesDTO();
        #endregion VARIABLES

        #region INITIALIZE
        public frmUserLeave()
        {
            InitializeComponent();
        }
        #endregion INITIALIZE

        #region EVENTS
        private void frmUserLeave_Load(object sender, EventArgs e)
        {
            init();
            this.reportViewer1.RefreshReport();
        }
        private void T1cmbDayHalf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)T1cmbDayHalf.SelectedValue == (int)Enums.LeaveMode.Half)
            {
                T1cmbHalf.Enabled = true;
            }
            else
            {
                T1cmbHalf.Enabled = false;
            }
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (validateInputs())
            {
                if (AplayLeave())
                {
                    MessageBox.Show("Sucsesfuly apply leaves", ResponseMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void T1dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if ((int)T1cmbDayHalf.SelectedValue == (int)Enums.LeaveMode.Full)
            {
                if (T1dtpFromDate.Value.Date > T1dtpToDate.Value.Date)
                {
                    MessageBox.Show("From date Should be less than to date!", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double totaldays = (T1dtpToDate.Value - T1dtpFromDate.Value).TotalDays + 1;
                txtNoOfDays.Text = totaldays.ToString("0.00");
            }
            else
            {
                T1dtpToDate.Value = T1dtpFromDate.Value;
                txtNoOfDays.Text = "0.5";
            }
        }
        private void T1dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (T1dtpFromDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
            {
                MessageBox.Show("You should apply leaves before a day!", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                T1dtpFromDate.Focus();
                return;
            }
        }
        private void T1txtEmpId_TextChanged(object sender, EventArgs e)
        {
            SearchEmployee();
        }
        private void T1cmbLeaveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)T1cmbLeaveType.SelectedValue == (int)Enums.LeaveType.Anual)
            {
                txtLeaveBal.Text = oEmployeeLeavesDTOO.anualLeaveBal.ToString();
            }
            else if ((int)T1cmbLeaveType.SelectedValue == (int)Enums.LeaveType.Casual)
            {
                txtLeaveBal.Text = oEmployeeLeavesDTOO.casualLeaveBal.ToString();
            }
            else if ((int)T1cmbLeaveType.SelectedValue == (int)Enums.LeaveType.Medical)
            {
                txtLeaveBal.Text = oEmployeeLeavesDTOO.medicalLeaveBal.ToString();
            }
            else if ((int)T1cmbLeaveType.SelectedValue == (int)Enums.LeaveType.Short)
            {
                txtLeaveBal.Text = oEmployeeLeavesDTOO.shortLeave.ToString();
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<EmployeeLeavesDTO> Leavs = new List<EmployeeLeavesDTO>();
            Leavs.Add(oEmployeeLeavesDTOO);
            T2dgvLeavesBal.DataSource = Leavs;
            T2dgvLeavesBal.ClearSelection();
        }
        private void btnGenarateReport_Click(object sender, EventArgs e)
        {
            try
            {
                picLoading.Visible = true;
                LoadLeaveReport();
                picLoading.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went Wrong!");
            }
        }
        #endregion EVENTS

        #region METHODS
        private void init()
        {
            try
            {
                picLoading.Visible = false;
                setDropDowns();
                T1cmbHalf.Enabled = false;
                T1dtpFromDate.Value = DateTime.Now.AddDays(1);
                T1dtpToDate.Value = DateTime.Now.AddDays(1);
                T1txtEmpId.Text = GlobalParameters.CurrentUserId;
                oEmployeeLeavesDTOO = GetLeavesDetails();
                T2dgvLeavesBal.AutoGenerateColumns = false;
                Bind_Months();
                T1cmbLeaveType.SelectedIndex = 0;
                T1cmbLeaveType_SelectedIndexChanged(null,null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void setDropDowns()
        {
            T1cmbLeaveType.DataSource = Enum.GetValues(typeof(Enums.LeaveType));
            T1cmbDayHalf.DataSource = Enum.GetValues(typeof(Enums.LeaveMode));
            T1cmbHalf.DataSource = Enum.GetValues(typeof(Enums.LeaveHalf));
        }
        private RequestLeaveDTO collectData()
        {
            RequestLeaveDTO oRequestLeaveDTO = new RequestLeaveDTO();
            oRequestLeaveDTO.empId = T1txtEmpId.Text;
            oRequestLeaveDTO.leaveType = (int)(Enums.LeaveType)T1cmbLeaveType.SelectedValue;
            oRequestLeaveDTO.isFullDay = (int)(Enums.LeaveMode)T1cmbDayHalf.SelectedValue;
            oRequestLeaveDTO.half = (int)(Enums.LeaveHalf)T1cmbHalf.SelectedValue;
            oRequestLeaveDTO.fromDate = T1dtpFromDate.Value;
            oRequestLeaveDTO.toDate = T1dtpToDate.Value;
            oRequestLeaveDTO.discription = T1txtDiscription.Text;
            oRequestLeaveDTO.isApprove = (int)Enums.LeaveIsApprove.Pendeing;
            oRequestLeaveDTO.modifiedUser = GlobalParameters.CurrentUserId;
            oRequestLeaveDTO.modifiedDateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
            oRequestLeaveDTO.modifiedMachine = GlobalParameters.CurrentMachine;

            return oRequestLeaveDTO;
        }
        private bool validateInputs()
        {
            if (string.IsNullOrEmpty(T1txtEmpName.Text))
            {
                MessageBox.Show("Please enter valid employee Id", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(T1txtDiscription.Text))
            {
                MessageBox.Show("Please enter discription", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (T1cmbLeaveType.Text != Enums.LeaveType.NoPay.ToString())
            {
                if (Convert.ToInt32(txtLeaveBal.Text) < 1)
                {
                    MessageBox.Show("Not Enough  "+T1cmbLeaveType.Text+ "Leaves Plese select other type or Nopay!!!", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; 
                }
            }
            if (!validateDates())
            {
                return false;
            }
            return true;
        }

        private bool validateDates()
        {
            if (T1dtpFromDate.Value.Date > T1dtpToDate.Value.Date)
            {
                MessageBox.Show("From date Should be less than to date!", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (T1dtpFromDate.Value.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
            {
                MessageBox.Show("You should apply leaves before a day!", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                T1dtpFromDate.Focus();
                return false;
            }
            return true;
        }
        private void ResetForm()
        {
            //T1txtEmpId.Text = string.Empty;
            //T1txtEmpName.Text = string.Empty;
            //T1txtDepartment.Text = string.Empty;
            T1txtDiscription.Text = string.Empty;
            T1cmbLeaveType.SelectedIndex = 0;
            T1cmbDayHalf.SelectedIndex = 0;
            T1cmbHalf.SelectedIndex = 0;
            txtLeaveBal.Text = string.Empty;
            T1dtpFromDate.Value = DateTime.Now.AddDays(1);
            T1dtpToDate.Value = DateTime.Now.AddDays(1);
            txtLeaveBal.Text = string.Empty;
        }
        private void LoadLeaveReport()
        {
            List<RequestLeaveDTO> lst = new List<RequestLeaveDTO>();
            lst = GetRequestLeaveDetails();
            int year = Convert.ToInt32(cmbYear.Text);
            int month = Convert.ToInt32(T2cmbMonth.SelectedValue);
            if (month > 0)
            {
                lst = lst.Where(c => c.fromDate.Year == year && c.fromDate.Month == month).ToList();
            }
            else
            {
                lst = lst.Where(c => c.fromDate.Year == year).ToList();
            }
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(lst);
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.ReportPath = @"E:\SIBA\2nd chapter\project work\SMMS\SMMS\SMMS.UserMGT.Views\rptrequestLeaves.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
            //ReportPageSettings rst = reportViewer1.LocalReport.GetDefaultPageSettings();
            //if (reportViewer1.ParentForm.Width > rst.PaperSize.Width)
            //{
            //    int vPad = (reportViewer1.ParentForm.Width - rst.PaperSize.Width) / 2;
            //    reportViewer1.Padding = new Padding(vPad - 20, 1, vPad - 20, 1);
            //}
        }
        private void Bind_Months()
        {
            T2cmbMonth.DataSource = Enum.GetValues(typeof(Enums.Months));
        }
        #endregion METHODS

        #region WEB_API_CALL
        private bool AplayLeave()
        {
            try
            {
                bool result = false;
                RequestLeaveDTO prodcut = collectData();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "User/ApplayLeave";
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
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
        private EmployeeLeavesDTO GetLeavesDetails()
        {
            try
            {
                EmployeeLeavesDTO oEmployeeLeavesDTOO = new EmployeeLeavesDTO();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "User/GetLeaveDetails?empID=" + T1txtEmpId.Text;
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        oEmployeeLeavesDTOO = JsonConvert.DeserializeObject<EmployeeLeavesDTO>(jsnString);

                    }
                }
                return oEmployeeLeavesDTOO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private List<RequestLeaveDTO> GetRequestLeaveDetails()
        {
            try
            {
                List<RequestLeaveDTO> oEmployeeLeavesDTOO = new List<RequestLeaveDTO>();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "User/GetRequestLeaveDetails?empID=" + T1txtEmpId.Text;
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        oEmployeeLeavesDTOO = JsonConvert.DeserializeObject<List<RequestLeaveDTO>>(jsnString);

                    }
                }
                return oEmployeeLeavesDTOO;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ResponseMessages.CommonError);
                return null;
            }
        }
        private List<EmployeeDTO> SearchEmployee()
        {
            try
            {
                List<EmployeeDTO> oEmployeeDTO = new List<EmployeeDTO>();
                EmployeeDTO employee = new EmployeeDTO();
                employee.empId = T1txtEmpId.Text;
                if (!string.IsNullOrEmpty(employee.empId))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(WebAPIPaths.Host);
                        string path = WebAPIPaths.WebAPI + "Employee/SearchEmployee";
                        HttpResponseMessage response = client.PostAsJsonAsync(path, employee).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            String jsnString = response.Content.ReadAsStringAsync().Result;
                            oEmployeeDTO = JsonConvert.DeserializeObject<List<EmployeeDTO>>(jsnString);
                            if (oEmployeeDTO != null)
                            {
                                T1txtEmpName.Text = oEmployeeDTO.FirstOrDefault().empName;
                                T1txtDepartment.Text = oEmployeeDTO.FirstOrDefault().empDepartment;
                            }
                        }
                    } 
                }
                return oEmployeeDTO;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        #endregion WEB_API_CALL


    }
}
