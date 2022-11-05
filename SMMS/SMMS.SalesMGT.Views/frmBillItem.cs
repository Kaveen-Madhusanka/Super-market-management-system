using SMMS.SalesMGT.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMMS.SalesMGT.Views
{
    public partial class frmBillItem : Form
    {
        public frmBillItem(SalesDTO oSalesDTO)
        {
            InitializeComponent();
            txtItem.Text = oSalesDTO.Name;
            txtQuantity.Text = oSalesDTO.quntity.ToString();
            txtPrice.Text = oSalesDTO.price.ToString();
            txtDiscount.Text = oSalesDTO.discount.ToString();
            txtTotal.Text = oSalesDTO.subTotal.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SalesDTO oSalesDTO = new SalesDTO();
            oSalesDTO.Name = txtItem.Text;
            oSalesDTO.quntity = Convert.ToDouble(txtQuantity.Text);
            oSalesDTO.discount = Convert.ToDouble(txtDiscount.Text);
            oSalesDTO.price = Convert.ToDouble(txtPrice.Text);
            oSalesDTO.subTotal = Convert.ToDouble(txtTotal.Text);
            GlobalBillDTO.Bill = oSalesDTO;
            GlobalBillDTO.isUpdate = true;
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            SalesDTO oSalesDTO = new SalesDTO();
            oSalesDTO.Name = txtItem.Text;
            GlobalBillDTO.Bill = oSalesDTO;
            GlobalBillDTO.isUpdate = false;
            this.Close();
        }
    }
}
