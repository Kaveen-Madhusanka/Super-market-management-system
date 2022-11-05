namespace SMMS.UserMGT.Views
{
    partial class frmUserLeave
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtNoOfDays = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.T1txtDiscription = new System.Windows.Forms.RichTextBox();
            this.T1dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.T1dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLeaveBal = new System.Windows.Forms.TextBox();
            this.T1cmbLeaveType = new System.Windows.Forms.ComboBox();
            this.T1cmbHalf = new System.Windows.Forms.ComboBox();
            this.T1cmbDayHalf = new System.Windows.Forms.ComboBox();
            this.T1txtEmpId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.T1txtDepartment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.T1txtEmpName = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.btnGenarateReport = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.T2cmbMonth = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.T2dgvLeavesBal = new System.Windows.Forms.DataGridView();
            this.casualLeaves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicalLeaves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anualLeaves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortLeaves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T2dgvLeavesBal)).BeginInit();
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
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtNoOfDays);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.T1txtDiscription);
            this.tabPage1.Controls.Add(this.T1dtpToDate);
            this.tabPage1.Controls.Add(this.T1dtpFromDate);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtLeaveBal);
            this.tabPage1.Controls.Add(this.T1cmbLeaveType);
            this.tabPage1.Controls.Add(this.T1cmbHalf);
            this.tabPage1.Controls.Add(this.T1cmbDayHalf);
            this.tabPage1.Controls.Add(this.T1txtEmpId);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.T1txtDepartment);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.T1txtEmpName);
            this.tabPage1.Controls.Add(this.btnClear);
            this.tabPage1.Controls.Add(this.btnApply);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "APPLAY LEAVE";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtNoOfDays
            // 
            this.txtNoOfDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfDays.Location = new System.Drawing.Point(501, 191);
            this.txtNoOfDays.Name = "txtNoOfDays";
            this.txtNoOfDays.ReadOnly = true;
            this.txtNoOfDays.Size = new System.Drawing.Size(215, 24);
            this.txtNoOfDays.TabIndex = 42;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(407, 194);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 18);
            this.label11.TabIndex = 41;
            this.label11.Text = "No of Days : ";
            // 
            // T1txtDiscription
            // 
            this.T1txtDiscription.Location = new System.Drawing.Point(170, 242);
            this.T1txtDiscription.Name = "T1txtDiscription";
            this.T1txtDiscription.Size = new System.Drawing.Size(216, 74);
            this.T1txtDiscription.TabIndex = 40;
            this.T1txtDiscription.Text = "";
            // 
            // T1dtpToDate
            // 
            this.T1dtpToDate.Location = new System.Drawing.Point(171, 206);
            this.T1dtpToDate.Name = "T1dtpToDate";
            this.T1dtpToDate.Size = new System.Drawing.Size(215, 20);
            this.T1dtpToDate.TabIndex = 39;
            this.T1dtpToDate.ValueChanged += new System.EventHandler(this.T1dtpToDate_ValueChanged);
            // 
            // T1dtpFromDate
            // 
            this.T1dtpFromDate.Location = new System.Drawing.Point(171, 180);
            this.T1dtpFromDate.Name = "T1dtpFromDate";
            this.T1dtpFromDate.Size = new System.Drawing.Size(215, 20);
            this.T1dtpFromDate.TabIndex = 39;
            this.T1dtpFromDate.ValueChanged += new System.EventHandler(this.T1dtpFromDate_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(31, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 18);
            this.label9.TabIndex = 38;
            this.label9.Text = "To Date                :";
            // 
            // txtLeaveBal
            // 
            this.txtLeaveBal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeaveBal.Location = new System.Drawing.Point(501, 116);
            this.txtLeaveBal.Name = "txtLeaveBal";
            this.txtLeaveBal.ReadOnly = true;
            this.txtLeaveBal.Size = new System.Drawing.Size(215, 24);
            this.txtLeaveBal.TabIndex = 37;
            // 
            // T1cmbLeaveType
            // 
            this.T1cmbLeaveType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T1cmbLeaveType.FormattingEnabled = true;
            this.T1cmbLeaveType.Location = new System.Drawing.Point(171, 116);
            this.T1cmbLeaveType.Name = "T1cmbLeaveType";
            this.T1cmbLeaveType.Size = new System.Drawing.Size(215, 26);
            this.T1cmbLeaveType.TabIndex = 25;
            this.T1cmbLeaveType.SelectedIndexChanged += new System.EventHandler(this.T1cmbLeaveType_SelectedIndexChanged);
            // 
            // T1cmbHalf
            // 
            this.T1cmbHalf.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T1cmbHalf.FormattingEnabled = true;
            this.T1cmbHalf.Location = new System.Drawing.Point(501, 146);
            this.T1cmbHalf.Name = "T1cmbHalf";
            this.T1cmbHalf.Size = new System.Drawing.Size(215, 26);
            this.T1cmbHalf.TabIndex = 23;
            // 
            // T1cmbDayHalf
            // 
            this.T1cmbDayHalf.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T1cmbDayHalf.FormattingEnabled = true;
            this.T1cmbDayHalf.Location = new System.Drawing.Point(171, 148);
            this.T1cmbDayHalf.Name = "T1cmbDayHalf";
            this.T1cmbDayHalf.Size = new System.Drawing.Size(215, 26);
            this.T1cmbDayHalf.TabIndex = 23;
            this.T1cmbDayHalf.SelectedIndexChanged += new System.EventHandler(this.T1cmbDayHalf_SelectedIndexChanged);
            // 
            // T1txtEmpId
            // 
            this.T1txtEmpId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T1txtEmpId.Location = new System.Drawing.Point(171, 24);
            this.T1txtEmpId.Name = "T1txtEmpId";
            this.T1txtEmpId.ReadOnly = true;
            this.T1txtEmpId.Size = new System.Drawing.Size(215, 24);
            this.T1txtEmpId.TabIndex = 21;
            this.T1txtEmpId.TextChanged += new System.EventHandler(this.T1txtEmpId_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 18);
            this.label7.TabIndex = 36;
            this.label7.Text = "Emp ID                  :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 18);
            this.label6.TabIndex = 35;
            this.label6.Text = "Department           :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 18);
            this.label5.TabIndex = 34;
            this.label5.Text = "Leave Type           :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 18);
            this.label4.TabIndex = 33;
            this.label4.Text = "Full/Half Day         :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(407, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 18);
            this.label10.TabIndex = 27;
            this.label10.Text = "Half             : ";
            // 
            // T1txtDepartment
            // 
            this.T1txtDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T1txtDepartment.Location = new System.Drawing.Point(171, 87);
            this.T1txtDepartment.Name = "T1txtDepartment";
            this.T1txtDepartment.ReadOnly = true;
            this.T1txtDepartment.Size = new System.Drawing.Size(215, 24);
            this.T1txtDepartment.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(407, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 18);
            this.label8.TabIndex = 27;
            this.label8.Text = "Balance       : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 18);
            this.label3.TabIndex = 30;
            this.label3.Text = "From Date            :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "Leave Discription : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 18);
            this.label1.TabIndex = 24;
            this.label1.Text = "Name                    :";
            // 
            // T1txtEmpName
            // 
            this.T1txtEmpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T1txtEmpName.Location = new System.Drawing.Point(171, 54);
            this.T1txtEmpName.Name = "T1txtEmpName";
            this.T1txtEmpName.ReadOnly = true;
            this.T1txtEmpName.Size = new System.Drawing.Size(215, 24);
            this.T1txtEmpName.TabIndex = 22;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(222, 359);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(164, 32);
            this.btnClear.TabIndex = 32;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(30, 359);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(164, 32);
            this.btnApply.TabIndex = 31;
            this.btnApply.Text = "Apply Leave";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.picLoading);
            this.tabPage2.Controls.Add(this.btnGenarateReport);
            this.tabPage2.Controls.Add(this.reportViewer1);
            this.tabPage2.Controls.Add(this.T2cmbMonth);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.cmbYear);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.T2dgvLeavesBal);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "LEAVE BALANCE";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // picLoading
            // 
            this.picLoading.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picLoading.Image = global::SMMS.UserMGT.Views.Properties.Resources.loading;
            this.picLoading.Location = new System.Drawing.Point(191, 68);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(196, 196);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoading.TabIndex = 25;
            this.picLoading.TabStop = false;
            // 
            // btnGenarateReport
            // 
            this.btnGenarateReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenarateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenarateReport.Location = new System.Drawing.Point(112, 97);
            this.btnGenarateReport.Name = "btnGenarateReport";
            this.btnGenarateReport.Size = new System.Drawing.Size(123, 27);
            this.btnGenarateReport.TabIndex = 24;
            this.btnGenarateReport.Text = "Genarate Report";
            this.btnGenarateReport.UseVisualStyleBackColor = true;
            this.btnGenarateReport.Click += new System.EventHandler(this.btnGenarateReport_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.Location = new System.Drawing.Point(0, 135);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(789, 286);
            this.reportViewer1.TabIndex = 23;
            // 
            // T2cmbMonth
            // 
            this.T2cmbMonth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.T2cmbMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T2cmbMonth.FormattingEnabled = true;
            this.T2cmbMonth.Location = new System.Drawing.Point(88, 65);
            this.T2cmbMonth.Name = "T2cmbMonth";
            this.T2cmbMonth.Size = new System.Drawing.Size(148, 26);
            this.T2cmbMonth.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(2, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 18);
            this.label14.TabIndex = 21;
            this.label14.Text = "Month :";
            // 
            // cmbYear
            // 
            this.cmbYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.cmbYear.Location = new System.Drawing.Point(87, 33);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(148, 26);
            this.cmbYear.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 18);
            this.label13.TabIndex = 19;
            this.label13.Text = "Year :";
            // 
            // T2dgvLeavesBal
            // 
            this.T2dgvLeavesBal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.T2dgvLeavesBal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.T2dgvLeavesBal.BackgroundColor = System.Drawing.Color.Gray;
            this.T2dgvLeavesBal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.T2dgvLeavesBal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.T2dgvLeavesBal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.T2dgvLeavesBal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.casualLeaves,
            this.medicalLeaves,
            this.anualLeaves,
            this.shortLeaves});
            this.T2dgvLeavesBal.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.T2dgvLeavesBal.DefaultCellStyle = dataGridViewCellStyle2;
            this.T2dgvLeavesBal.Location = new System.Drawing.Point(241, 33);
            this.T2dgvLeavesBal.MultiSelect = false;
            this.T2dgvLeavesBal.Name = "T2dgvLeavesBal";
            this.T2dgvLeavesBal.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.T2dgvLeavesBal.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.T2dgvLeavesBal.RowHeadersVisible = false;
            this.T2dgvLeavesBal.Size = new System.Drawing.Size(548, 72);
            this.T2dgvLeavesBal.TabIndex = 18;
            // 
            // casualLeaves
            // 
            this.casualLeaves.DataPropertyName = "casualLeaveBal";
            this.casualLeaves.HeaderText = "Casual Leaves";
            this.casualLeaves.Name = "casualLeaves";
            this.casualLeaves.ReadOnly = true;
            // 
            // medicalLeaves
            // 
            this.medicalLeaves.DataPropertyName = "medicalLeaveBal";
            this.medicalLeaves.HeaderText = "Medical Leaves";
            this.medicalLeaves.Name = "medicalLeaves";
            this.medicalLeaves.ReadOnly = true;
            // 
            // anualLeaves
            // 
            this.anualLeaves.DataPropertyName = "anualLeaveBal";
            this.anualLeaves.HeaderText = "Anual Leaves";
            this.anualLeaves.Name = "anualLeaves";
            this.anualLeaves.ReadOnly = true;
            // 
            // shortLeaves
            // 
            this.shortLeaves.DataPropertyName = "shortLeave";
            this.shortLeaves.HeaderText = "Short Leaves";
            this.shortLeaves.Name = "shortLeaves";
            this.shortLeaves.ReadOnly = true;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(420, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(166, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "LEAVES BALANCE";
            // 
            // frmUserLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmUserLeave";
            this.Text = "USER LEAVE";
            this.Load += new System.EventHandler(this.frmUserLeave_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T2dgvLeavesBal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLeaveBal;
        private System.Windows.Forms.ComboBox T1cmbLeaveType;
        private System.Windows.Forms.ComboBox T1cmbDayHalf;
        private System.Windows.Forms.TextBox T1txtEmpId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox T1txtDepartment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox T1txtEmpName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.RichTextBox T1txtDiscription;
        private System.Windows.Forms.DateTimePicker T1dtpToDate;
        private System.Windows.Forms.DateTimePicker T1dtpFromDate;
        private System.Windows.Forms.ComboBox T1cmbHalf;
        private System.Windows.Forms.TextBox txtNoOfDays;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView T2dgvLeavesBal;
        private System.Windows.Forms.DataGridViewTextBoxColumn casualLeaves;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicalLeaves;
        private System.Windows.Forms.DataGridViewTextBoxColumn anualLeaves;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortLeaves;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox T2cmbMonth;
        private System.Windows.Forms.Label label14;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnGenarateReport;
        private System.Windows.Forms.PictureBox picLoading;
    }
}