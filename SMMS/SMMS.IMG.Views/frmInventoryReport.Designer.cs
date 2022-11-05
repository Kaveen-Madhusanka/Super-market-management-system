
namespace SMMS.IMG.Views
{
    partial class frmInventoryReport
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
            this.cmbCatogery = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.rptvInventory = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // btnGenarateReport
            // 
            this.btnGenarateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenarateReport.Location = new System.Drawing.Point(251, 12);
            this.btnGenarateReport.Name = "btnGenarateReport";
            this.btnGenarateReport.Size = new System.Drawing.Size(116, 26);
            this.btnGenarateReport.TabIndex = 33;
            this.btnGenarateReport.Text = "Genarete Report";
            this.btnGenarateReport.UseVisualStyleBackColor = true;
            this.btnGenarateReport.Click += new System.EventHandler(this.btnGenarateReport_Click);
            // 
            // cmbCatogery
            // 
            this.cmbCatogery.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCatogery.FormattingEnabled = true;
            this.cmbCatogery.Items.AddRange(new object[] {
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
            this.cmbCatogery.Location = new System.Drawing.Point(92, 12);
            this.cmbCatogery.Name = "cmbCatogery";
            this.cmbCatogery.Size = new System.Drawing.Size(134, 26);
            this.cmbCatogery.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(10, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 18);
            this.label13.TabIndex = 29;
            this.label13.Text = "Catogery :";
            // 
            // rptvInventory
            // 
            this.rptvInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rptvInventory.Location = new System.Drawing.Point(12, 44);
            this.rptvInventory.Name = "rptvInventory";
            this.rptvInventory.Size = new System.Drawing.Size(788, 410);
            this.rptvInventory.TabIndex = 34;
            // 
            // frmInventoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptvInventory);
            this.Controls.Add(this.btnGenarateReport);
            this.Controls.Add(this.cmbCatogery);
            this.Controls.Add(this.label13);
            this.Name = "frmInventoryReport";
            this.Text = "frmInventoryReport";
            this.Load += new System.EventHandler(this.frmInventoryReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenarateReport;
        private System.Windows.Forms.ComboBox cmbCatogery;
        private System.Windows.Forms.Label label13;
        private Microsoft.Reporting.WinForms.ReportViewer rptvInventory;
    }
}