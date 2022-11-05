using SMMS.IMG.Views;
using SMMS.SalesMGT.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket_management_system
{
    public partial class frmReportsHome : Form
    {
        public frmReportsHome()
        {
            InitializeComponent();
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            frmHome frmhome = new frmHome();
            frmhome.Show();
            frmhome.OpenChildForm(new frmSalesReport(), null, true);
        }

        private void btnInventoryReport_Click(object sender, EventArgs e)
        {
            frmHome frmhome = new frmHome();
            frmhome.Show();
            frmhome.OpenChildForm(new frmInventoryReport(), null, true);
        }
    }
}
