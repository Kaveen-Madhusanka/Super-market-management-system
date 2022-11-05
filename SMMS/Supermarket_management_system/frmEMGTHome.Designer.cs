namespace Supermarket_management_system
{
    partial class frmEMGTHome
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
            this.btnPayRoll = new System.Windows.Forms.Button();
            this.btnLivesMGT = new System.Windows.Forms.Button();
            this.btnEmployeeMGT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPayRoll
            // 
            this.btnPayRoll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnPayRoll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayRoll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPayRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayRoll.Location = new System.Drawing.Point(520, 30);
            this.btnPayRoll.Name = "btnPayRoll";
            this.btnPayRoll.Size = new System.Drawing.Size(154, 63);
            this.btnPayRoll.TabIndex = 4;
            this.btnPayRoll.Text = "Payroll  Management";
            this.btnPayRoll.UseVisualStyleBackColor = false;
            this.btnPayRoll.Click += new System.EventHandler(this.btnPayRoll_Click);
            // 
            // btnLivesMGT
            // 
            this.btnLivesMGT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnLivesMGT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLivesMGT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLivesMGT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLivesMGT.Location = new System.Drawing.Point(289, 30);
            this.btnLivesMGT.Name = "btnLivesMGT";
            this.btnLivesMGT.Size = new System.Drawing.Size(154, 63);
            this.btnLivesMGT.TabIndex = 2;
            this.btnLivesMGT.Text = "Leave Management";
            this.btnLivesMGT.UseVisualStyleBackColor = false;
            this.btnLivesMGT.Click += new System.EventHandler(this.btnLivesMGT_Click);
            // 
            // btnEmployeeMGT
            // 
            this.btnEmployeeMGT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnEmployeeMGT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployeeMGT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmployeeMGT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployeeMGT.Location = new System.Drawing.Point(58, 30);
            this.btnEmployeeMGT.Name = "btnEmployeeMGT";
            this.btnEmployeeMGT.Size = new System.Drawing.Size(154, 63);
            this.btnEmployeeMGT.TabIndex = 3;
            this.btnEmployeeMGT.Text = "Employee Management";
            this.btnEmployeeMGT.UseVisualStyleBackColor = false;
            this.btnEmployeeMGT.Click += new System.EventHandler(this.btnEmployeeMGT_Click);
            // 
            // frmEMGTHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPayRoll);
            this.Controls.Add(this.btnLivesMGT);
            this.Controls.Add(this.btnEmployeeMGT);
            this.Name = "frmEMGTHome";
            this.Text = "EMPLOYEE MANAGEMENT";
            this.Load += new System.EventHandler(this.frmEMGTHome_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPayRoll;
        private System.Windows.Forms.Button btnLivesMGT;
        private System.Windows.Forms.Button btnEmployeeMGT;
    }
}