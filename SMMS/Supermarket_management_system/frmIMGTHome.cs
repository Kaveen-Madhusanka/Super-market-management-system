using SMMS.Common;
using SMMS.IMG.Views;
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
    public partial class frmIMGTHome : Form
    {
        public frmIMGTHome()
        {
            InitializeComponent();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmHome frmhome = new frmHome();
            //frmhome.Name = "kaveen";
            frmhome.Show();
            frmhome.OpenChildForm(new frmproduct(), null, true);
        }

        private void frmIMGTHome_Load(object sender, EventArgs e)
        {
            SetColorTheme();
        }

        private void SetColorTheme()
        {
            if (GlobalParameters.ThemeColor != Color.Empty)
            {
                foreach (Control control in this.Controls)
                {
                    control.BackColor = GlobalParameters.ThemeColor;
                    control.ForeColor = Color.White;
                }
            }
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            frmHome frmhome = new frmHome();
            frmhome.Show();
            frmhome.OpenChildForm(new frmSupplier(), null, true);
        }

        private void btnStockManagement_Click(object sender, EventArgs e)
        {
            frmHome frmhome = new frmHome();
            frmhome.Show();
            frmhome.OpenChildForm(new frmStock(), null, true);
        }
    }
}
