
namespace Supermarket_management_system
{
    partial class frmReportsHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInventoryReport = new System.Windows.Forms.Button();
            this.btnSalesReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInventoryReport
            // 
            this.btnInventoryReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnInventoryReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventoryReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInventoryReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryReport.Location = new System.Drawing.Point(284, 31);
            this.btnInventoryReport.Name = "btnInventoryReport";
            this.btnInventoryReport.Size = new System.Drawing.Size(154, 63);
            this.btnInventoryReport.TabIndex = 2;
            this.btnInventoryReport.Text = "INVENTORY REPORT";
            this.btnInventoryReport.UseVisualStyleBackColor = false;
            this.btnInventoryReport.Click += new System.EventHandler(this.btnInventoryReport_Click);
            // 
            // btnSalesReport
            // 
            this.btnSalesReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSalesReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalesReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalesReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesReport.Location = new System.Drawing.Point(53, 31);
            this.btnSalesReport.Name = "btnSalesReport";
            this.btnSalesReport.Size = new System.Drawing.Size(154, 63);
            this.btnSalesReport.TabIndex = 3;
            this.btnSalesReport.Text = "SALES REPORT";
            this.btnSalesReport.UseVisualStyleBackColor = false;
            this.btnSalesReport.Click += new System.EventHandler(this.btnSalesReport_Click);
            // 
            // frmReportsHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnInventoryReport);
            this.Controls.Add(this.btnSalesReport);
            this.Name = "frmReportsHome";
            this.Text = "REPORTS";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnInventoryReport;
        private System.Windows.Forms.Button btnSalesReport;
    }
}