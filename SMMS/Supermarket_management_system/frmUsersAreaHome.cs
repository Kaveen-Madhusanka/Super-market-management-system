using SMMS.Common;
using SMMS.UserMGT.Views;
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
    public partial class frmUsersAreaHome : Form
    {
        public frmUsersAreaHome()
        {
            InitializeComponent();
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
        private void frmUsersAreaHome_Load(object sender, EventArgs e)
        {
            SetColorTheme();
        }
        private void btnLeaves_Click(object sender, EventArgs e)
        {
            frmHome frmhome = new frmHome();
            frmhome.Show();
            frmhome.OpenChildForm(new frmUserLeave(), null, true);
        }

        private void btnSalaryReport_Click(object sender, EventArgs e)
        {
            frmHome frmhome = new frmHome();
            frmhome.Show();
            frmhome.OpenChildForm(new frmSalaryReport(), null, true);
        }

        private void btnSalaryMGT_Click(object sender, EventArgs e)
        {
            frmHome frmhome = new frmHome();
            frmhome.Show();
            frmhome.OpenChildForm(new frmUserAccount(), null, true);
        }
    }
}
