namespace Supermarket_management_system
{
    partial class frmUsersAreaHome
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
            this.btnSalaryMGT = new System.Windows.Forms.Button();
            this.btnSalaryReport = new System.Windows.Forms.Button();
            this.btnLeaves = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSalaryMGT
            // 
            this.btnSalaryMGT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSalaryMGT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalaryMGT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalaryMGT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalaryMGT.Location = new System.Drawing.Point(520, 30);
            this.btnSalaryMGT.Name = "btnSalaryMGT";
            this.btnSalaryMGT.Size = new System.Drawing.Size(154, 63);
            this.btnSalaryMGT.TabIndex = 7;
            this.btnSalaryMGT.Text = "ACCOUNT ";
            this.btnSalaryMGT.UseVisualStyleBackColor = false;
            this.btnSalaryMGT.Click += new System.EventHandler(this.btnSalaryMGT_Click);
            // 
            // btnSalaryReport
            // 
            this.btnSalaryReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSalaryReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalaryReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalaryReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalaryReport.Location = new System.Drawing.Point(289, 30);
            this.btnSalaryReport.Name = "btnSalaryReport";
            this.btnSalaryReport.Size = new System.Drawing.Size(154, 63);
            this.btnSalaryReport.TabIndex = 5;
            this.btnSalaryReport.Text = "SALARY REPORT";
            this.btnSalaryReport.UseVisualStyleBackColor = false;
            this.btnSalaryReport.Click += new System.EventHandler(this.btnSalaryReport_Click);
            // 
            // btnLeaves
            // 
            this.btnLeaves.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnLeaves.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeaves.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLeaves.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeaves.Location = new System.Drawing.Point(58, 30);
            this.btnLeaves.Name = "btnLeaves";
            this.btnLeaves.Size = new System.Drawing.Size(154, 63);
            this.btnLeaves.TabIndex = 6;
            this.btnLeaves.Text = "LEAVES";
            this.btnLeaves.UseVisualStyleBackColor = false;
            this.btnLeaves.Click += new System.EventHandler(this.btnLeaves_Click);
            // 
            // frmUsersAreaHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalaryMGT);
            this.Controls.Add(this.btnSalaryReport);
            this.Controls.Add(this.btnLeaves);
            this.Name = "frmUsersAreaHome";
            this.Text = "USERS AREA";
            this.Load += new System.EventHandler(this.frmUsersAreaHome_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalaryMGT;
        private System.Windows.Forms.Button btnSalaryReport;
        private System.Windows.Forms.Button btnLeaves;
    }
}