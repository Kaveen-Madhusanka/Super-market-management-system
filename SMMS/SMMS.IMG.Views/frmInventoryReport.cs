using Microsoft.Reporting.WinForms;
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

namespace SMMS.IMG.Views
{
    public partial class frmInventoryReport : Form
    {
       

      

        #region VARIABLES
        #endregion VARIABLES

        #region INITIALIZE
        public frmInventoryReport()
        {
            InitializeComponent();
        }
        #endregion INITIALIZE

        #region EVENTS
        private void frmInventoryReport_Load(object sender, EventArgs e)
        {
            this.rptvInventory.RefreshReport();
            init();
        }
        private void btnGenarateReport_Click(object sender, EventArgs e)
        {
            try
            {
                List<productDTO> oProducts = GetProducts();
                if (!string.IsNullOrEmpty(cmbCatogery.Text))
                {
                    oProducts = oProducts.Where(x => x.pCategoery == Convert.ToInt32(cmbCatogery.SelectedValue)).ToList();
                }
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(oProducts);
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

                ReportDataSource rds = new ReportDataSource("dtsProduct", dt);
                rptvInventory.LocalReport.ReportPath = @"E:\SIBA\2nd chapter\project work\SMMS\SMMS\SMMS.IMG.Views\rptInventory.rdlc";
                rptvInventory.LocalReport.DataSources.Clear();
                rptvInventory.LocalReport.DataSources.Add(rds);
                rptvInventory.RefreshReport();
                cmbCatogery.SelectedIndex = -1;
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
            setDropDowns();
        }

        private void setDropDowns()
        {
            cmbCatogery.DataSource = Enum.GetValues(typeof(Common.Enums.ProductCatogery));
            cmbCatogery.SelectedIndex = -1;
        }
        #endregion METHODS

        #region WEB_API_CALL
        private List<productDTO> GetProducts()
        {
            try
            {
                List<productDTO> oproductDTO = new List<productDTO>();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WebAPIPaths.Host);
                    string path = WebAPIPaths.WebAPI + "product/GetProducts";
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        oproductDTO = JsonConvert.DeserializeObject<List<productDTO>>(jsnString);
                    }
                }
                return oproductDTO.OrderByDescending(x => x.pId).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion WEB_API_CALL


    }
}
