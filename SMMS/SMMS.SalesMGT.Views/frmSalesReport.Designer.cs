
namespace SMMS.SalesMGT.Views
{
    partial class frmSalesReport
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
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.rptvSales = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnGenarateReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbMonth
            // 
            this.cmbMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(229, 12);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(89, 26);
            this.cmbMonth.TabIndex = 26;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(169, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 18);
            this.label14.TabIndex = 25;
            this.label14.Text = "Month :";
            // 
            // cmbYear
            // 
            this.cmbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Items.AddRange(new object[] {
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2034",
            "2035",
            "2036",
            "2037",
            "2038"});
            this.cmbYear.Location = new System.Drawing.Point(58, 12);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(89, 26);
            this.cmbYear.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 18);
            this.label13.TabIndex = 23;
            this.label13.Text = "Year :";
            // 
            // rptvSales
            // 
            this.rptvSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rptvSales.Location = new System.Drawing.Point(12, 44);
            this.rptvSales.Name = "rptvSales";
            this.rptvSales.Size = new System.Drawing.Size(786, 405);
            this.rptvSales.TabIndex = 27;
            // 
            // btnGenarateReport
            // 
            this.btnGenarateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenarateReport.Location = new System.Drawing.Point(322, 12);
            this.btnGenarateReport.Name = "btnGenarateReport";
            this.btnGenarateReport.Size = new System.Drawing.Size(116, 26);
            this.btnGenarateReport.TabIndex = 28;
            this.btnGenarateReport.Text = "Genarete Report";
            this.btnGenarateReport.UseVisualStyleBackColor = true;
            this.btnGenarateReport.Click += new System.EventHandler(this.btnGenarateReport_Click);
            // 
            // frmSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGenarateReport);
            this.Controls.Add(this.rptvSales);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label13);
            this.Name = "frmSalesReport";
            this.Text = "SALES REPORT";
            this.Load += new System.EventHandler(this.frmSalesReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label13;
        private Microsoft.Reporting.WinForms.ReportViewer rptvSales;
        private System.Windows.Forms.Button btnGenarateReport;
    }
}