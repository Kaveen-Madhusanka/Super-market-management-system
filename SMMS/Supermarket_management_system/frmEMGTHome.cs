using SMMS.Common;
using SMMS.HRIMGT.Views;
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
    public partial class frmEMGTHome : Form
    {
        public frmEMGTHome()
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

        private void frmEMGTHome_Load(object sender, EventArgs e)
        {
            SetColorTheme();
        }

        private void btnEmployeeMGT_Click(object sender, EventArgs e)
        {
            frmHome frmhome = new frmHome();
            frmhome.Show();
            frmhome.OpenChildForm(new frmEmployee(), null, true);
        }

        private void btnLivesMGT_Click(object sender, EventArgs e)
        {
            frmHome frmhome = new frmHome();
            frmhome.Show();
            frmhome.OpenChildForm(new frmlLeaveManagemnt(), null, true);
        }

        private void btnPayRoll_Click(object sender, EventArgs e)
        {
            frmHome frmhome = new frmHome();
            frmhome.Show();
            frmhome.OpenChildForm(new frmPayRoll(), null, true);
        }
    }
}
