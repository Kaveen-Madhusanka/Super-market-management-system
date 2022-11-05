namespace SMMS.HRIMGT.Views
{
    partial class frmlLeaveManagemnt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtLeaveSearch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvREquestedLeaves = new System.Windows.Forms.DataGridView();
            this.empId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leaveType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leaveMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnApprove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.T2cmbMonth = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbT2Year = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.rptLeaves = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtT2EmployeeId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenarateReport = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvREquestedLeaves)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtLeaveSearch);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.dgvREquestedLeaves);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Approve L:eaves";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtLeaveSearch
            // 
            this.txtLeaveSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeaveSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeaveSearch.Location = new System.Drawing.Point(501, 37);
            this.txtLeaveSearch.Name = "txtLeaveSearch";
            this.txtLeaveSearch.Size = new System.Drawing.Size(288, 24);
            this.txtLeaveSearch.TabIndex = 44;
            this.txtLeaveSearch.TextChanged += new System.EventHandler(this.txtLeaveSearch_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(432, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 18);
            this.label8.TabIndex = 45;
            this.label8.Text = "Search :";
            // 
            // dgvREquestedLeaves
            // 
            this.dgvREquestedLeaves.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvREquestedLeaves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvREquestedLeaves.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(77)))), ((int)(((byte)(91)))));
            this.dgvREquestedLeaves.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvREquestedLeaves.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvREquestedLeaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvREquestedLeaves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empId,
            this.leaveType,
            this.leaveMode,
            this.fromDate,
            this.toDate,
            this.discription,
            this.btnApprove});
            this.dgvREquestedLeaves.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvREquestedLeaves.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvREquestedLeaves.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(77)))), ((int)(((byte)(91)))));
            this.dgvREquestedLeaves.Location = new System.Drawing.Point(0, 64);
            this.dgvREquestedLeaves.Name = "dgvREquestedLeaves";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvREquestedLeaves.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvREquestedLeaves.RowHeadersVisible = false;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvREquestedLeaves.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvREquestedLeaves.Size = new System.Drawing.Size(792, 360);
            this.dgvREquestedLeaves.TabIndex = 43;
            this.dgvREquestedLeaves.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvREquestedLeaves_CellClick);
            this.dgvREquestedLeaves.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvREquestedLeaves_CellMouseLeave);
            this.dgvREquestedLeaves.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvREquestedLeaves_CellMouseMove);
            // 
            // empId
            // 
            this.empId.DataPropertyName = "empId";
            this.empId.HeaderText = "ID";
            this.empId.Name = "empId";
            // 
            // leaveType
            // 
            this.leaveType.DataPropertyName = "leaveTypeText";
            this.leaveType.HeaderText = "Leave Type ";
            this.leaveType.Name = "leaveType";
            // 
            // leaveMode
            // 
            this.leaveMode.DataPropertyName = "isFullDayText";
            this.leaveMode.HeaderText = "Leave Mode";
            this.leaveMode.Name = "leaveMode";
            // 
            // fromDate
            // 
            this.fromDate.DataPropertyName = "fromDate";
            this.fromDate.HeaderText = "Start Date";
            this.fromDate.Name = "fromDate";
            // 
            // toDate
            // 
            this.toDate.DataPropertyName = "toDate";
            this.toDate.HeaderText = "End Date";
            this.toDate.Name = "toDate";
            // 
            // discription
            // 
            this.discription.DataPropertyName = "discription";
            this.discription.HeaderText = "Description ";
            this.discription.Name = "discription";
            // 
            // btnApprove
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.DefaultCellStyle = dataGridViewCellStyle7;
            this.btnApprove.HeaderText = "Approve";
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseColumnTextForButtonValue = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(245, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 20);
            this.label7.TabIndex = 42;
            this.label7.Text = "Requested Leaves ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnGenarateReport);
            this.tabPage2.Controls.Add(this.txtT2EmployeeId);
            this.tabPage2.Controls.Add(this.rptLeaves);
            this.tabPage2.Controls.Add(this.T2cmbMonth);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.cmbT2Year);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Leave Reports";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // T2cmbMonth
            // 
            this.T2cmbMonth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.T2cmbMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T2cmbMonth.FormattingEnabled = true;
            this.T2cmbMonth.Location = new System.Drawing.Point(333, 38);
            this.T2cmbMonth.Name = "T2cmbMonth";
            this.T2cmbMonth.Size = new System.Drawing.Size(148, 26);
            this.T2cmbMonth.TabIndex = 26;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(247, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 18);
            this.label14.TabIndex = 25;
            this.label14.Text = "Month :";
            // 
            // cmbT2Year
            // 
            this.cmbT2Year.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbT2Year.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbT2Year.FormattingEnabled = true;
            this.cmbT2Year.Items.AddRange(new object[] {
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
            this.cmbT2Year.Location = new System.Drawing.Point(332, 6);
            this.cmbT2Year.Name = "cmbT2Year";
            this.cmbT2Year.Size = new System.Drawing.Size(148, 26);
            this.cmbT2Year.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(246, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 18);
            this.label13.TabIndex = 23;
            this.label13.Text = "Year :";
            // 
            // rptLeaves
            // 
            this.rptLeaves.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rptLeaves.Location = new System.Drawing.Point(5, 74);
            this.rptLeaves.Name = "rptLeaves";
            this.rptLeaves.Size = new System.Drawing.Size(781, 344);
            this.rptLeaves.TabIndex = 27;
            // 
            // txtT2EmployeeId
            // 
            this.txtT2EmployeeId.Location = new System.Drawing.Point(105, 6);
            this.txtT2EmployeeId.Name = "txtT2EmployeeId";
            this.txtT2EmployeeId.Size = new System.Drawing.Size(100, 20);
            this.txtT2EmployeeId.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "Employee Id :";
            // 
            // btnGenarateReport
            // 
            this.btnGenarateReport.Location = new System.Drawing.Point(8, 40);
            this.btnGenarateReport.Name = "btnGenarateReport";
            this.btnGenarateReport.Size = new System.Drawing.Size(98, 23);
            this.btnGenarateReport.TabIndex = 29;
            this.btnGenarateReport.Text = "Genarate Report";
            this.btnGenarateReport.UseVisualStyleBackColor = true;
            this.btnGenarateReport.Click += new System.EventHandler(this.btnGenarateReport_Click);
            // 
            // frmlLeaveManagemnt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmlLeaveManagemnt";
            this.Text = "LEAVE MANAGEMENT";
            this.Load += new System.EventHandler(this.frmlLeaveManagemnt_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvREquestedLeaves)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvREquestedLeaves;
        private System.Windows.Forms.TextBox txtLeaveSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn empId;
        private System.Windows.Forms.DataGridViewTextBoxColumn leaveType;
        private System.Windows.Forms.DataGridViewTextBoxColumn leaveMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn toDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn discription;
        private System.Windows.Forms.DataGridViewButtonColumn btnApprove;
        private System.Windows.Forms.ComboBox T2cmbMonth;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbT2Year;
        private System.Windows.Forms.Label label13;
        private Microsoft.Reporting.WinForms.ReportViewer rptLeaves;
        private System.Windows.Forms.Button btnGenarateReport;
        private System.Windows.Forms.TextBox txtT2EmployeeId;
        private System.Windows.Forms.Label label1;
    }
}