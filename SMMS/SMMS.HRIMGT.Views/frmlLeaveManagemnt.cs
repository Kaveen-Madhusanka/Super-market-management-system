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

namespace SMMS.HRIMGT.Views
{
    public partial class frmlLeaveManagemnt : Form
    {

        #region  VARIABLES
        #endregion VARIABLES

        #region  INITIALIZE
        public frmlLeaveManagemnt()
        {
            InitializeComponent();
        }
        #endregion INITIALIZE

        #region EVENTS
        private void frmlLeaveManagemnt_Load(object sender, EventArgs e)
        {
            init();
            this.rptLeaves.RefreshReport();
        }

        private void dgvREquestedLeaves_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgvREquestedLeaves.CurrentCell.Selected = false;
                dgvREquestedLeaves.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                dgvREquestedLeaves.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        private void dgvREquestedLeaves_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dgvREquestedLeaves.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dgvREquestedLeaves.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }
        private void txtLeaveSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLeaveSearch.Text))
            {
                GetRequestLeavesDetails();
            }
            else
            {
                GetRequestLeaveDetails();
            }
        }

        private void dgvREquestedLeaves_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvREquestedLeaves.Columns["btnApprove"].Index && e.RowIndex >= 0)
                {
                    if (MessageBox.Show(ResponseMessages.LeaveQuestion, ResponseMessages.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        empRequestedLeaveDTo oempRequestedLeaveDTo = new empRequestedLeaveDTo();
                        DataGridViewRow row = dgvREquestedLeaves.Rows[e.RowIndex];
                        oempRequestedLeaveDTo.empId = row.Cells["empId"].Value.ToString();
                        oempRequestedLeaveDTo.leaveTypeText = row.Cells["leaveType"].Value.ToString();
                        oempRequestedLeaveDTo.isFullDayText = row.Cells["leaveMode"].Value.ToString();
                        oempRequestedLeaveDTo.fromDate = Convert.ToDateTime(row.Cells["fromDate"].Value);
                        oempRequestedLeaveDTo.toDate = Convert.ToDateTime(row.Cells["toDate"].Value);
                        oempRequestedLeaveDTo.discription = row.Cells["discription"].Value.ToString();
                        oempRequestedLeaveDTo.isApprove = (int)Enums.LeaveIsApprove.Approved;
                        oempRequestedLeaveDTo.modifiedUser = GlobalParameters.CurrentUserId;
                        oempRequestedLeaveDTo.modifiedDateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
                        oempRequestedLeaveDTo.modifiedMachine = GlobalParameters.CurrentMachine;
                        if (ApproveLeave(oempRequestedLeaveDTo))
                        {
                            MessageBox.Show(ResponseMessages.LeaveApproved, ResponseMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        GetRequestLeavesDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion EVENTS

        #region  METHODS
        private void init()
        {
            dgvREquestedLeaves.AutoGenerateColumns = false;
            GetRequestLeavesDetails();
            Bind_Months();
            cmbT2Year.SelectedIndex = 0;
        }
        #endregion METHODS

        #region WEB_API_CALL
        private List<empRequestedLeaveDTo> GetRequestLeavesDetails()
        {
            try
            {
                List<empRequestedLeaveDTo> oEmployeeLeavesDTOO = new List<empRequestedLeaveDTo>();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "LeaveManagement/GetRequestLeavesDetails";
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        oEmployeeLeavesDTOO = JsonConvert.DeserializeObject<List<empRequestedLeaveDTo>>(jsnString);
                        dgvREquestedLeaves.DataSource = oEmployeeLeavesDTOO;
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

        private List<empRequestedLeaveDTo> GetRequestLeaveDetails()
        {
            try
            {
                List<empRequestedLeaveDTo> oempRequestedLeaveDTo = new List<empRequestedLeaveDTo>();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "User/GetRequestLeaveDetails?empID=" + txtLeaveSearch.Text;
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        oempRequestedLeaveDTo = JsonConvert.DeserializeObject<List<empRequestedLeaveDTo>>(jsnString);
                        dgvREquestedLeaves.DataSource = oempRequestedLeaveDTo;
                    }
                }
                return oempRequestedLeaveDTo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ResponseMessages.CommonError);
                return null;
            }
        }

        private bool ApproveLeave(empRequestedLeaveDTo oempRequestedLeaveDTo)
        {
            try
            {
                bool result = false;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "LeaveManagement/ApproveLeave";
                    HttpResponseMessage response = client.PostAsJsonAsync(path, oempRequestedLeaveDTo).Result;
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

        // Report Ganarete 
        private void Bind_Months()
        {
            T2cmbMonth.DataSource = Enum.GetValues(typeof(Enums.Months));
        }
        private void LoadReport()
        {
            try
            {
                List<RequestLeaveDTO> lst = new List<RequestLeaveDTO>();
                lst = GetRequestLeaveDetailsForReport();
                int year = Convert.ToInt32(cmbT2Year.Text);
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
                rptLeaves.LocalReport.ReportPath = @"E:\SIBA\2nd chapter\project work\SMMS\SMMS\SMMS.UserMGT.Views\rptrequestLeaves.rdlc";
                rptLeaves.LocalReport.DataSources.Clear();
                rptLeaves.LocalReport.DataSources.Add(rds);
                rptLeaves.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private List<RequestLeaveDTO> GetRequestLeaveDetailsForReport()
        {
            try
            {
                List<RequestLeaveDTO> oEmployeeLeavesDTOO = new List<RequestLeaveDTO>();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "User/GetRequestLeaveDetails?empID=" + txtT2EmployeeId.Text;
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

        private void btnGenarateReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtT2EmployeeId.Text))
                {
                    LoadReport();
                }
                else
                {
                    MessageBox.Show("Plese Enter Employee Id!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something Went Wrong!");
            }
        }
    }
}
