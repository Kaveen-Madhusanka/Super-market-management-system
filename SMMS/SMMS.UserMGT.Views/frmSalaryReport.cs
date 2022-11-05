using Microsoft.Reporting.WinForms;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMMS.UserMGT.Views
{
    public partial class frmSalaryReport : Form
    {




        #region VARIABLES
        #endregion VARIABLES

        #region INITIALIZE
        public frmSalaryReport()
        {
            InitializeComponent();
        }
        #endregion INITIALIZE

        #region EVENTS
        private void frmSalaryReport_Load(object sender, EventArgs e)
        {

            this.rptvSalary.RefreshReport();
            init();
        }
        private void btnGenarateReport_Click(object sender, EventArgs e)
        {
            LoadReport();
        }
        #endregion EVENTS

        #region METHODS
        private void init()
        {
            Bind_Months();
        }
        private void LoadReport()
        {
            try
            {
                List<reportSalaryDTO> lst = new List<reportSalaryDTO>();
                lst.Add(GetSalaryData());
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(lst);
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

                ReportDataSource rds = new ReportDataSource("dtsSalary", dt);
                rptvSalary.LocalReport.ReportPath = @"E:\SIBA\2nd chapter\project work\SMMS\SMMS\SMMS.UserMGT.Views\rptSalary.rdlc";
                rptvSalary.LocalReport.DataSources.Clear();
                rptvSalary.LocalReport.DataSources.Add(rds);
                rptvSalary.RefreshReport();
            }
            catch (Exception)
            {
                MessageBox.Show("Something Went Wrong !");
            }
        }
        private void Bind_Months()
        {
            T2cmbMonth.DataSource = Enum.GetValues(typeof(Enums.Months));
        }
        #endregion METHODS

        #region WEB_API_CALLS
        private reportSalaryDTO GetSalaryData()
        {
            try
            {
                reportSalaryDTO oreportSalaryDTO = new reportSalaryDTO();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "User/GetSalaryData?empID=" + GlobalParameters.CurrentUserId + "&month="+(int)T2cmbMonth.SelectedValue + "&year=" + cmbYear.Text;
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        oreportSalaryDTO = JsonConvert.DeserializeObject<reportSalaryDTO>(jsnString);

                    }
                }
                return oreportSalaryDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion WEB_API_CALLS

       
    }
}
