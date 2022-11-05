using SMMS.Common;
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
    public partial class frmLoad : Form
    {
        public frmLoad()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void frmLoad_Load(object sender, EventArgs e)
        {
            GlobalParameters.CurrentUserId = "emp1150080";
            GlobalParameters.CurrentUsername = "Kaveen";
            GlobalParameters.CurrentMachine = "PC9";
            tmSplash.Start();

        }

        private void tmSplash_Tick(object sender, EventArgs e)
        {
            try
            {
                panel2.Width += 200;

                if (panel2.Width >= 599)
                {
                    tmSplash.Stop();
                    frmLogin login = new frmLogin();
                    login.Show();
                    this.Hide();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
