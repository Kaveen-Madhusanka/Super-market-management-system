using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using SMMS.Common;
using SMMS.SalesMGT.Domain;
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

namespace SMMS.SalesMGT.Views
{
    public partial class frmSalesReport : Form
    {
        #region VARIABLES
        #endregion VARIABLES

        #region INITIALIZE
        public frmSalesReport()
        {
            InitializeComponent();
        }
        #endregion INITIALIZE

        #region EVENTS 
        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            this.rptvSales.RefreshReport();
            init();
        }

        private void btnGenarateReport_Click(object sender, EventArgs e)
        {
            try
            {
                List<_SalesDTO> o_SalesDTO = new List<_SalesDTO>();
                o_SalesDTO = GetLastBillNO();
                //{
                //    new _SalesDTO
                //    {
                //        billNo = "B001",
                //        cashier = "Test",
                //        discount = 250 ,
                //        modifiedDateTime = DateTime.Now,
                //        total = 1500
                //    },
                //    new _SalesDTO
                //    {
                //        billNo = "B002",
                //        cashier = "Test1",
                //        discount = 350,
                //        modifiedDateTime = DateTime.Now,
                //        total = 5000
                //    }
                //};
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(o_SalesDTO);
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

                ReportDataSource rds = new ReportDataSource("dtsSales", dt);
                rptvSales.LocalReport.ReportPath = @"E:\SIBA\2nd chapter\project work\SMMS\SMMS\SMMS.SalesMGT.Views\rptSales.rdlc";
                rptvSales.LocalReport.DataSources.Clear();
                rptvSales.LocalReport.DataSources.Add(rds);
                rptvSales.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion EVENTS

        #region METHODS 
        private void init()
        {
            BindMonths();
        }
        private void BindMonths()
        {
            cmbMonth.DataSource = Enum.GetValues(typeof(Enums.Months));
            cmbMonth.SelectedIndex = 0;
        }
        #endregion METHODS

        #region WEB_API_CALL
        private List<_SalesDTO> GetLastBillNO()
        {
            try
            {
                List<_SalesDTO> Sales = new List<_SalesDTO>();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "Sales/GetDataToSalesReport?year=" + cmbYear.Text + "&month="+ Convert.ToInt32(cmbMonth.SelectedValue) + "";
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        Sales = JsonConvert.DeserializeObject<List<_SalesDTO>>(jsnString);
                    }
                }
                return Sales;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion WEB_API_CALL
    }
}
