
namespace SMMS.UserMGT.Views
{
    partial class frmSalaryReport
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
            this.btnGenarateReport = new System.Windows.Forms.Button();
            this.T2cmbMonth = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.rptvSalary = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // btnGenarateReport
            // 
            this.btnGenarateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenarateReport.Location = new System.Drawing.Point(119, 76);
            this.btnGenarateReport.Name = "btnGenarateReport";
            this.btnGenarateReport.Size = new System.Drawing.Size(123, 27);
            this.btnGenarateReport.TabIndex = 29;
            this.btnGenarateReport.Text = "Genarate Report";
            this.btnGenarateReport.UseVisualStyleBackColor = true;
            this.btnGenarateReport.Click += new System.EventHandler(this.btnGenarateReport_Click);
            // 
            // T2cmbMonth
            // 
            this.T2cmbMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T2cmbMonth.FormattingEnabled = true;
            this.T2cmbMonth.Location = new System.Drawing.Point(95, 44);
            this.T2cmbMonth.Name = "T2cmbMonth";
            this.T2cmbMonth.Size = new System.Drawing.Size(148, 26);
            this.T2cmbMonth.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(9, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 18);
            this.label14.TabIndex = 27;
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
            this.cmbYear.Location = new System.Drawing.Point(94, 12);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(148, 26);
            this.cmbYear.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 18);
            this.label13.TabIndex = 25;
            this.label13.Text = "Year :";
            // 
            // rptvSalary
            // 
            this.rptvSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rptvSalary.Location = new System.Drawing.Point(11, 109);
            this.rptvSalary.Name = "rptvSalary";
            this.rptvSalary.Size = new System.Drawing.Size(786, 341);
            this.rptvSalary.TabIndex = 30;
            // 
            // frmSalaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptvSalary);
            this.Controls.Add(this.btnGenarateReport);
            this.Controls.Add(this.T2cmbMonth);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label13);
            this.Name = "frmSalaryReport";
            this.Text = "SALARY REPORTS";
            this.Load += new System.EventHandler(this.frmSalaryReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenarateReport;
        private System.Windows.Forms.ComboBox T2cmbMonth;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label13;
        private Microsoft.Reporting.WinForms.ReportViewer rptvSalary;
    }
}