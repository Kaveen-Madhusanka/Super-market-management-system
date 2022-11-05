using ExcelDataReader;
using Newtonsoft.Json;
using SMMS.Common;
using SMMS.HRIMGT.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMMS.HRIMGT.Views
{
    public partial class frmPayRoll : Form
    {
        #region VARIABLES
        DataTableCollection tableCollection;
        List<AttendanceDTO> Attendance = new List<AttendanceDTO>();
        List<SalaryDTO> SalaraySearch = new List<SalaryDTO>();
        List<AttendanceDTO> AttendanceForMonth = new List<AttendanceDTO>();
        bool isBonus = false;
        #endregion VARIABLES

        #region INITIALIZE
        public frmPayRoll()
        {
            InitializeComponent();
        }
        #endregion INITIALIZE

        #region EVENTS
        private void frmPayRoll_Load(object sender, EventArgs e)
        {
            try
            {

                dgvT1Attendance.AutoGenerateColumns = false;
                dgvT2Salary.AutoGenerateColumns = false;
                cmbT2EmployeeType.SelectedIndex = 0;
                SetSalary();
                pnlDiscription.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnT1Import_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        txtT1FileName.Text = openFileDialog.FileName;
                        using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                });
                                tableCollection = result.Tables;
                                cmbSheet.Items.Clear();
                                foreach (DataTable table in tableCollection)
                                    cmbSheet.Items.Add(table.TableName);//add sheet to combobox
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some another program open this file");
            }
        }
        private void cmbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cmbSheet.SelectedItem.ToString()];
            //dgvData.DataSource = dt;// Addd any excell sheet to data grid view
            dgvT1Attendance.DataSource = AddToList(dt);
        }
        private void btnT1Upload_Click(object sender, EventArgs e)
        {
            if (Attendance.Count > 0)
            {
                if (AddAttendance(Attendance))
                {
                    MessageBox.Show("Sucessfuly Uploaded ", ResponseMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
            }
            else
            {
                MessageBox.Show("PLease Browse file", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnT2Bouns_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtT2Amount.Text))
            {
                MessageBox.Show("Please Enter Amount", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pnlDiscription.Visible = true;
            isBonus = true;
        }
        private void txtT2Search_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtT2Search.Text))
            {
                dgvT2Salary.DataSource = SalaraySearch.Where(x => x.empId.Contains(txtT2Search.Text)).ToList();
                dgvT2Salary.Refresh();
            }
            else
            {
                dgvT2Salary.DataSource = SalaraySearch;
            }
        }
        private void btnT2Deduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtT2Amount.Text))
            {
                MessageBox.Show("Please Enter Amount", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pnlDiscription.Visible = true;
            isBonus = false;

        }
        private void pnlbtnOk_Click(object sender, EventArgs e)
        {
            if (rtxtDescription.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Discription!", ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isBonus)
            {
                try
                {
                    List<SalaryDTO> salary = (List<SalaryDTO>)dgvT2Salary.DataSource;
                    if (cmbT2EmployeeType.Text != "All")
                    {
                        int empType = (int)((Enums.EmployeeType)Enum.Parse(typeof(Enums.EmployeeType), cmbT2EmployeeType.Text));
                        salary = salary
                            .Where(x => x.EmployeeType == empType)
                            .Select(x =>
                            {
                                x.bonus = Convert.ToDouble(txtT2Amount.Text);
                                x.discription1 = rtxtDescription.Text;
                                x.salary = ((x.Basic + x.bonus) - x.deduction) - (x.NoPay * 1000);
                                return x;
                            })
                            .ToList();
                    }
                    else
                    {
                        salary = salary
                           .Select(x =>
                           {
                               x.bonus = Convert.ToDouble(txtT2Amount.Text);
                               x.discription1 = rtxtDescription.Text;
                               x.salary = ((x.Basic + x.bonus) - x.deduction) - (x.NoPay * 1000);
                               return x;
                           })
                           .ToList();
                    }
                    dgvT2Salary.Refresh();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ResponseMessages.CommonError, ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    List<SalaryDTO> salary = (List<SalaryDTO>)dgvT2Salary.DataSource;
                    if (cmbT2EmployeeType.Text != "All")
                    {
                        int empType = (int)((Enums.EmployeeType)Enum.Parse(typeof(Enums.EmployeeType), cmbT2EmployeeType.Text));
                        salary = salary
                            .Where(x => x.EmployeeType == empType)
                            .Select(x =>
                            {
                                x.deduction = Convert.ToDouble(txtT2Amount.Text);
                                x.discription2 = rtxtDescription.Text;
                                x.salary = (x.Basic + x.bonus) - x.deduction;
                                return x;
                            })
                            .ToList();
                    }
                    else
                    {
                        salary = salary
                           .Select(x =>
                           {
                               x.deduction = Convert.ToDouble(txtT2Amount.Text);
                               x.discription2 = rtxtDescription.Text;
                               x.salary = (x.Basic + x.bonus) - x.deduction;
                               return x;
                           })
                           .ToList();
                    }
                    dgvT2Salary.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ResponseMessages.CommonError, ResponseMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            cmbT2EmployeeType.SelectedIndex = 0;
            txtT2Amount.Text = string.Empty;
            pnlDiscription.Visible = false;
            rtxtDescription.Text = string.Empty;
        }
        private void pnlClose_Click(object sender, EventArgs e)
        {
            pnlDiscription.Visible = false;
            rtxtDescription.Text = string.Empty;
        }
        private void btnFinalize_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (AddSalary())
                {
                    MessageBox.Show("Sucessfuly Finalized ", ResponseMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvT2Salary.DataSource = null;
                }
            }
        }
        private void tbcPayRoll_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSalary();
        }
        #endregion EVENTS

        #region METHODS 
        private List<AttendanceDTO> AddToList(DataTable dt)
        {
            try
            {
                List<AttendanceDTO> oAttendance = new List<AttendanceDTO>();

                oAttendance = (from rw in dt.AsEnumerable()
                               select new AttendanceDTO()
                               {
                                   empID = Convert.ToString(rw["Employee ID"]),
                                   inTime = Convert.ToString(rw["Time in"]),
                                   outTime = Convert.ToString(rw["Time Out"]),
                                   dateType = Convert.ToString(rw["Date Type"]),
                                   date = Convert.ToString(rw["Date"]),
                                   modifiedUser = GlobalParameters.CurrentUserId,
                                   modifiedDateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy h:mm tt")),
                                   modifiedMachine = GlobalParameters.CurrentMachine
                               }).ToList();
                Attendance = oAttendance;
                return oAttendance;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check File Format!!");
                return null;
            }
        }
        private void clear()
        {
            txtT1FileName.Text = string.Empty;
            cmbSheet.DataSource = null;
            dgvT1Attendance.DataSource = null;
        }
        private void SetSalary()
        {
            List<SalaryDTO> salary = new List<SalaryDTO>();
            List<AttendanceDTO> Attendance = GetAttendance();
            Attendance = Attendance.GroupBy(i => i.empID).Select(group => group.First()).ToList();
            AttendanceForMonth = Attendance;
            for (int i = 0; i < Attendance.Count; i++)
            {
                SalaryDTO oSalaryDTO = new SalaryDTO();
                oSalaryDTO.empId = Attendance[i].empID;
                oSalaryDTO.noOfFullDay = Attendance.Count(x => x.dateType == "Full Day" && x.empID == Attendance[i].empID);
                oSalaryDTO.noOfHalfDay = Attendance.Count(x => x.dateType == "Half Day" && x.empID == Attendance[i].empID);
                oSalaryDTO.Basic = 0.00;
                oSalaryDTO.bonus = 0.00;
                oSalaryDTO.deduction = 0.00;
                oSalaryDTO.salary = 0.00;
                oSalaryDTO.NoPay = GetNoPaysById(oSalaryDTO.empId);
                salary.Add(oSalaryDTO);
            }
            salary = setBasic(salary);
            dgvT2Salary.DataSource = null;
            dgvT2Salary.DataSource = salary;
            SalaraySearch = salary;
        }
        private List<SalaryDTO> setBasic(List<SalaryDTO> _salary)
        {
            List<SalaryDTO> salary = _salary;
            for (int i = 0; i < salary.Count; i++)
            {
                EmployeeDTO oEmployeeDTO = GetEmployee(salary[i].empId);
                salary[i].EmployeeType = oEmployeeDTO.empType;
                salary[i].EmployeeTypeText = oEmployeeDTO.empTypeText;
                switch (oEmployeeDTO.empType)
                {
                    case (int)Enums.EmployeeType.SalesManager:
                        {
                            salary[i].Basic = 40000;
                            break;
                        }
                    case (int)Enums.EmployeeType.StockManager:
                        {
                            salary[i].Basic = 30000;
                            break;
                        }
                    case (int)Enums.EmployeeType.HRManager:
                        {
                            salary[i].Basic = 50000;
                            break;
                        }
                    case (int)Enums.EmployeeType.Helper:
                        {
                            salary[i].Basic = 25000;
                            break;
                        }
                    case (int)Enums.EmployeeType.Cashier:
                        {
                            salary[i].Basic = 28000;
                            break;
                        }
                    case (int)Enums.EmployeeType.Admin:
                        {
                            salary[i].Basic = 30000;
                            break;
                        }
                    default: break;
                }
                salary[i].salary = salary[i].Basic;
                salary[i].salary = salary[i].salary - (salary[i].NoPay * 1000);
            }

            return salary;
        }
        #endregion METHODS

        #region WEB_API_CALL
        private bool AddAttendance(List<AttendanceDTO> oAttendanceDTO)
        {
            try
            {
                bool result = false;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Attendance/AddAttendance";
                    HttpResponseMessage response = client.PostAsJsonAsync(path, oAttendanceDTO).Result;
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

        private List<AttendanceDTO> GetAttendance()
        {
            try
            {
                List<AttendanceDTO> result = new List<AttendanceDTO>();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Attendance/GetAttendance";
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        result = JsonConvert.DeserializeObject<List<AttendanceDTO>>(jsnString);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private EmployeeDTO GetEmployee(string empId)
        {
            try
            {
                EmployeeDTO result = new EmployeeDTO();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Employee/GetEmployee?empId=" + empId;
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        result = JsonConvert.DeserializeObject<EmployeeDTO>(jsnString);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private int GetNoPaysById(string empId)
        {
            try
            {
                int result = 0;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "LeaveManagement/GetNoPaysById?empId=" + empId;
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        result = JsonConvert.DeserializeObject<int>(jsnString);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private bool AddSalary()
        {
            try
            {
                List<SalaryDTO> salary = (List<SalaryDTO>)dgvT2Salary.DataSource;
                salary = salary.Select(x =>
                {
                    x.year = DateTime.Now.Year;
                    x.year = Convert.ToDateTime(AttendanceForMonth[0].date).Year;
                    x.month = DateTime.Now.Month;
                    x.month = Convert.ToDateTime(AttendanceForMonth[0].date).Month;
                    x.modifiedUser = GlobalParameters.CurrentUserId;
                    x.modifiedDateTime = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
                    x.modifiedMachine = GlobalParameters.CurrentMachine;
                    return x;
                })
                .ToList();
                bool result = false;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Payroll/AddSalary";
                    HttpResponseMessage response = client.PostAsJsonAsync(path, salary).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        result = JsonConvert.DeserializeObject<bool>(jsnString);
                    }
                }

                return result;
            }
            catch (Exception)
            {
                MessageBox.Show("Something Went Wrong !");
                return false;
            }
        }
        #endregion WEB_API_CALL

       
    }
}
