
namespace SMMS.HRIMGT.Views
{
    partial class frmPayRoll
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbcPayRoll = new System.Windows.Forms.TabControl();
            this.tbcAttendance = new System.Windows.Forms.TabPage();
            this.cmbSheet = new System.Windows.Forms.ComboBox();
            this.dgvT1Attendance = new System.Windows.Forms.DataGridView();
            this.empId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnT1Upload = new System.Windows.Forms.Button();
            this.btnT1Import = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtT1FileName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbcSalary = new System.Windows.Forms.TabPage();
            this.pnlDiscription = new System.Windows.Forms.Panel();
            this.pnlClose = new System.Windows.Forms.Button();
            this.pnlbtnOk = new System.Windows.Forms.Button();
            this.rtxtDescription = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtT2Search = new System.Windows.Forms.TextBox();
            this.txtT2Amount = new System.Windows.Forms.TextBox();
            this.cmbT2EmployeeType = new System.Windows.Forms.ComboBox();
            this.btnT2Deduct = new System.Windows.Forms.Button();
            this.btnFinalize = new System.Windows.Forms.Button();
            this.btnT2Bouns = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvT2Salary = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noOfFullDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noOfHalfDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bonus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desuction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbcPayRoll.SuspendLayout();
            this.tbcAttendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvT1Attendance)).BeginInit();
            this.tbcSalary.SuspendLayout();
            this.pnlDiscription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvT2Salary)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcPayRoll
            // 
            this.tbcPayRoll.Controls.Add(this.tbcAttendance);
            this.tbcPayRoll.Controls.Add(this.tbcSalary);
            this.tbcPayRoll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcPayRoll.Location = new System.Drawing.Point(0, 0);
            this.tbcPayRoll.Name = "tbcPayRoll";
            this.tbcPayRoll.SelectedIndex = 0;
            this.tbcPayRoll.Size = new System.Drawing.Size(983, 450);
            this.tbcPayRoll.TabIndex = 0;
            this.tbcPayRoll.SelectedIndexChanged += new System.EventHandler(this.tbcPayRoll_SelectedIndexChanged);
            // 
            // tbcAttendance
            // 
            this.tbcAttendance.Controls.Add(this.cmbSheet);
            this.tbcAttendance.Controls.Add(this.dgvT1Attendance);
            this.tbcAttendance.Controls.Add(this.btnT1Upload);
            this.tbcAttendance.Controls.Add(this.btnT1Import);
            this.tbcAttendance.Controls.Add(this.label10);
            this.tbcAttendance.Controls.Add(this.txtT1FileName);
            this.tbcAttendance.Controls.Add(this.label6);
            this.tbcAttendance.Controls.Add(this.label7);
            this.tbcAttendance.Location = new System.Drawing.Point(4, 22);
            this.tbcAttendance.Name = "tbcAttendance";
            this.tbcAttendance.Padding = new System.Windows.Forms.Padding(3);
            this.tbcAttendance.Size = new System.Drawing.Size(975, 424);
            this.tbcAttendance.TabIndex = 0;
            this.tbcAttendance.Text = "ATTENDANCE";
            this.tbcAttendance.UseVisualStyleBackColor = true;
            // 
            // cmbSheet
            // 
            this.cmbSheet.FormattingEnabled = true;
            this.cmbSheet.Location = new System.Drawing.Point(598, 8);
            this.cmbSheet.Name = "cmbSheet";
            this.cmbSheet.Size = new System.Drawing.Size(106, 21);
            this.cmbSheet.TabIndex = 58;
            this.cmbSheet.SelectedIndexChanged += new System.EventHandler(this.cmbSheet_SelectedIndexChanged);
            // 
            // dgvT1Attendance
            // 
            this.dgvT1Attendance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvT1Attendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvT1Attendance.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(77)))), ((int)(((byte)(91)))));
            this.dgvT1Attendance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvT1Attendance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvT1Attendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvT1Attendance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empId,
            this.inTime,
            this.outTime,
            this.dateType,
            this.date});
            this.dgvT1Attendance.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvT1Attendance.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvT1Attendance.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(77)))), ((int)(((byte)(91)))));
            this.dgvT1Attendance.Location = new System.Drawing.Point(7, 38);
            this.dgvT1Attendance.Name = "dgvT1Attendance";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvT1Attendance.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvT1Attendance.RowHeadersVisible = false;
            this.dgvT1Attendance.Size = new System.Drawing.Size(852, 386);
            this.dgvT1Attendance.TabIndex = 50;
            // 
            // empId
            // 
            this.empId.DataPropertyName = "empID";
            this.empId.HeaderText = "Employee ID";
            this.empId.Name = "empId";
            // 
            // inTime
            // 
            this.inTime.DataPropertyName = "inTime";
            this.inTime.HeaderText = "In Time";
            this.inTime.Name = "inTime";
            // 
            // outTime
            // 
            this.outTime.DataPropertyName = "outTime";
            this.outTime.HeaderText = "Out Time";
            this.outTime.Name = "outTime";
            // 
            // dateType
            // 
            this.dateType.DataPropertyName = "dateType";
            this.dateType.HeaderText = "Date Type";
            this.dateType.Name = "dateType";
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            // 
            // btnT1Upload
            // 
            this.btnT1Upload.BackColor = System.Drawing.Color.LimeGreen;
            this.btnT1Upload.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnT1Upload.ForeColor = System.Drawing.Color.White;
            this.btnT1Upload.Location = new System.Drawing.Point(710, 5);
            this.btnT1Upload.Name = "btnT1Upload";
            this.btnT1Upload.Size = new System.Drawing.Size(152, 27);
            this.btnT1Upload.TabIndex = 49;
            this.btnT1Upload.Text = "Upload";
            this.btnT1Upload.UseVisualStyleBackColor = false;
            this.btnT1Upload.Click += new System.EventHandler(this.btnT1Upload_Click);
            // 
            // btnT1Import
            // 
            this.btnT1Import.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnT1Import.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnT1Import.ForeColor = System.Drawing.Color.White;
            this.btnT1Import.Location = new System.Drawing.Point(370, 5);
            this.btnT1Import.Name = "btnT1Import";
            this.btnT1Import.Size = new System.Drawing.Size(152, 27);
            this.btnT1Import.TabIndex = 49;
            this.btnT1Import.Text = "Import";
            this.btnT1Import.UseVisualStyleBackColor = false;
            this.btnT1Import.Click += new System.EventHandler(this.btnT1Import_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(135, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 18);
            this.label10.TabIndex = 48;
            this.label10.Text = ":";
            // 
            // txtT1FileName
            // 
            this.txtT1FileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtT1FileName.Location = new System.Drawing.Point(154, 6);
            this.txtT1FileName.Name = "txtT1FileName";
            this.txtT1FileName.Size = new System.Drawing.Size(210, 24);
            this.txtT1FileName.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(548, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 18);
            this.label6.TabIndex = 47;
            this.label6.Text = "Sheet :";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 18);
            this.label7.TabIndex = 47;
            this.label7.Text = "Attendance File";
            // 
            // tbcSalary
            // 
            this.tbcSalary.Controls.Add(this.pnlDiscription);
            this.tbcSalary.Controls.Add(this.txtT2Search);
            this.tbcSalary.Controls.Add(this.txtT2Amount);
            this.tbcSalary.Controls.Add(this.cmbT2EmployeeType);
            this.tbcSalary.Controls.Add(this.btnT2Deduct);
            this.tbcSalary.Controls.Add(this.btnFinalize);
            this.tbcSalary.Controls.Add(this.btnT2Bouns);
            this.tbcSalary.Controls.Add(this.label4);
            this.tbcSalary.Controls.Add(this.label1);
            this.tbcSalary.Controls.Add(this.label5);
            this.tbcSalary.Controls.Add(this.label3);
            this.tbcSalary.Controls.Add(this.label2);
            this.tbcSalary.Controls.Add(this.dgvT2Salary);
            this.tbcSalary.Location = new System.Drawing.Point(4, 22);
            this.tbcSalary.Name = "tbcSalary";
            this.tbcSalary.Padding = new System.Windows.Forms.Padding(3);
            this.tbcSalary.Size = new System.Drawing.Size(975, 424);
            this.tbcSalary.TabIndex = 1;
            this.tbcSalary.Text = "SALARY";
            this.tbcSalary.UseVisualStyleBackColor = true;
            // 
            // pnlDiscription
            // 
            this.pnlDiscription.BackColor = System.Drawing.Color.Teal;
            this.pnlDiscription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDiscription.Controls.Add(this.pnlClose);
            this.pnlDiscription.Controls.Add(this.pnlbtnOk);
            this.pnlDiscription.Controls.Add(this.rtxtDescription);
            this.pnlDiscription.Controls.Add(this.label8);
            this.pnlDiscription.Location = new System.Drawing.Point(258, 169);
            this.pnlDiscription.Name = "pnlDiscription";
            this.pnlDiscription.Size = new System.Drawing.Size(460, 142);
            this.pnlDiscription.TabIndex = 59;
            // 
            // pnlClose
            // 
            this.pnlClose.BackColor = System.Drawing.Color.Red;
            this.pnlClose.ForeColor = System.Drawing.Color.White;
            this.pnlClose.Location = new System.Drawing.Point(429, 1);
            this.pnlClose.Name = "pnlClose";
            this.pnlClose.Size = new System.Drawing.Size(31, 23);
            this.pnlClose.TabIndex = 56;
            this.pnlClose.Text = "X";
            this.pnlClose.UseVisualStyleBackColor = false;
            this.pnlClose.Click += new System.EventHandler(this.pnlClose_Click);
            // 
            // pnlbtnOk
            // 
            this.pnlbtnOk.Location = new System.Drawing.Point(192, 116);
            this.pnlbtnOk.Name = "pnlbtnOk";
            this.pnlbtnOk.Size = new System.Drawing.Size(75, 23);
            this.pnlbtnOk.TabIndex = 56;
            this.pnlbtnOk.Text = "OK";
            this.pnlbtnOk.UseVisualStyleBackColor = true;
            this.pnlbtnOk.Click += new System.EventHandler(this.pnlbtnOk_Click);
            // 
            // rtxtDescription
            // 
            this.rtxtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtDescription.Location = new System.Drawing.Point(20, 30);
            this.rtxtDescription.Name = "rtxtDescription";
            this.rtxtDescription.Size = new System.Drawing.Size(423, 80);
            this.rtxtDescription.TabIndex = 55;
            this.rtxtDescription.Text = "";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(145, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 18);
            this.label8.TabIndex = 53;
            this.label8.Text = "Please Enter Discription";
            // 
            // txtT2Search
            // 
            this.txtT2Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtT2Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtT2Search.Location = new System.Drawing.Point(830, 13);
            this.txtT2Search.Name = "txtT2Search";
            this.txtT2Search.Size = new System.Drawing.Size(142, 24);
            this.txtT2Search.TabIndex = 58;
            this.txtT2Search.TextChanged += new System.EventHandler(this.txtT2Search_TextChanged);
            // 
            // txtT2Amount
            // 
            this.txtT2Amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtT2Amount.Location = new System.Drawing.Point(292, 12);
            this.txtT2Amount.Name = "txtT2Amount";
            this.txtT2Amount.Size = new System.Drawing.Size(95, 24);
            this.txtT2Amount.TabIndex = 58;
            // 
            // cmbT2EmployeeType
            // 
            this.cmbT2EmployeeType.FormattingEnabled = true;
            this.cmbT2EmployeeType.Items.AddRange(new object[] {
            "All",
            "HRManager",
            "StockManager ",
            "SalesManager ",
            "Cashier ",
            "Helper ",
            "Admin "});
            this.cmbT2EmployeeType.Location = new System.Drawing.Point(106, 14);
            this.cmbT2EmployeeType.Name = "cmbT2EmployeeType";
            this.cmbT2EmployeeType.Size = new System.Drawing.Size(121, 21);
            this.cmbT2EmployeeType.TabIndex = 57;
            // 
            // btnT2Deduct
            // 
            this.btnT2Deduct.BackColor = System.Drawing.Color.Red;
            this.btnT2Deduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnT2Deduct.ForeColor = System.Drawing.Color.White;
            this.btnT2Deduct.Location = new System.Drawing.Point(521, 11);
            this.btnT2Deduct.Name = "btnT2Deduct";
            this.btnT2Deduct.Size = new System.Drawing.Size(122, 27);
            this.btnT2Deduct.TabIndex = 55;
            this.btnT2Deduct.Text = "Deduct";
            this.btnT2Deduct.UseVisualStyleBackColor = false;
            this.btnT2Deduct.Click += new System.EventHandler(this.btnT2Deduct_Click);
            // 
            // btnFinalize
            // 
            this.btnFinalize.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnFinalize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalize.ForeColor = System.Drawing.Color.White;
            this.btnFinalize.Location = new System.Drawing.Point(649, 11);
            this.btnFinalize.Name = "btnFinalize";
            this.btnFinalize.Size = new System.Drawing.Size(122, 27);
            this.btnFinalize.TabIndex = 56;
            this.btnFinalize.Text = "Finalize";
            this.btnFinalize.UseVisualStyleBackColor = false;
            this.btnFinalize.Click += new System.EventHandler(this.btnFinalize_Click);
            // 
            // btnT2Bouns
            // 
            this.btnT2Bouns.BackColor = System.Drawing.Color.LimeGreen;
            this.btnT2Bouns.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnT2Bouns.ForeColor = System.Drawing.Color.White;
            this.btnT2Bouns.Location = new System.Drawing.Point(393, 10);
            this.btnT2Bouns.Name = "btnT2Bouns";
            this.btnT2Bouns.Size = new System.Drawing.Size(122, 27);
            this.btnT2Bouns.TabIndex = 56;
            this.btnT2Bouns.Text = "Bonus";
            this.btnT2Bouns.UseVisualStyleBackColor = false;
            this.btnT2Bouns.Click += new System.EventHandler(this.btnT2Bouns_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(273, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 18);
            this.label4.TabIndex = 54;
            this.label4.Text = ":";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 18);
            this.label1.TabIndex = 54;
            this.label1.Text = ":";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(768, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 18);
            this.label5.TabIndex = 53;
            this.label5.Text = "Search :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(239, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 18);
            this.label3.TabIndex = 53;
            this.label3.Text = "Amt";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 53;
            this.label2.Text = "Emp Type";
            // 
            // dgvT2Salary
            // 
            this.dgvT2Salary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvT2Salary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvT2Salary.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(77)))), ((int)(((byte)(91)))));
            this.dgvT2Salary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvT2Salary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvT2Salary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvT2Salary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.empType,
            this.noOfFullDay,
            this.noOfHalfDay,
            this.NoPay,
            this.basic,
            this.bonus,
            this.desuction,
            this.salary});
            this.dgvT2Salary.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvT2Salary.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvT2Salary.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(77)))), ((int)(((byte)(91)))));
            this.dgvT2Salary.Location = new System.Drawing.Point(5, 45);
            this.dgvT2Salary.Name = "dgvT2Salary";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvT2Salary.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvT2Salary.RowHeadersVisible = false;
            this.dgvT2Salary.Size = new System.Drawing.Size(967, 379);
            this.dgvT2Salary.TabIndex = 51;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "empId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Employee ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // empType
            // 
            this.empType.DataPropertyName = "EmployeeTypeText";
            this.empType.HeaderText = "Type";
            this.empType.Name = "empType";
            // 
            // noOfFullDay
            // 
            this.noOfFullDay.DataPropertyName = "noOfFullDay";
            this.noOfFullDay.HeaderText = "No Of Full Day";
            this.noOfFullDay.Name = "noOfFullDay";
            this.noOfFullDay.Visible = false;
            // 
            // noOfHalfDay
            // 
            this.noOfHalfDay.DataPropertyName = "noOfHalfDay";
            this.noOfHalfDay.HeaderText = "No Of Half Day";
            this.noOfHalfDay.Name = "noOfHalfDay";
            this.noOfHalfDay.Visible = false;
            // 
            // NoPay
            // 
            this.NoPay.DataPropertyName = "NoPay";
            this.NoPay.HeaderText = "No Pay";
            this.NoPay.Name = "NoPay";
            // 
            // basic
            // 
            this.basic.DataPropertyName = "Basic";
            this.basic.HeaderText = "Basic";
            this.basic.Name = "basic";
            // 
            // bonus
            // 
            this.bonus.DataPropertyName = "bonus";
            this.bonus.HeaderText = "Bonus";
            this.bonus.Name = "bonus";
            // 
            // desuction
            // 
            this.desuction.DataPropertyName = "deduction";
            this.desuction.HeaderText = "Deduction";
            this.desuction.Name = "desuction";
            // 
            // salary
            // 
            this.salary.DataPropertyName = "salary";
            this.salary.HeaderText = "Salary";
            this.salary.Name = "salary";
            // 
            // frmPayRoll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 450);
            this.Controls.Add(this.tbcPayRoll);
            this.Name = "frmPayRoll";
            this.Text = "PAYROLL MANAGEMENT";
            this.Load += new System.EventHandler(this.frmPayRoll_Load);
            this.tbcPayRoll.ResumeLayout(false);
            this.tbcAttendance.ResumeLayout(false);
            this.tbcAttendance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvT1Attendance)).EndInit();
            this.tbcSalary.ResumeLayout(false);
            this.tbcSalary.PerformLayout();
            this.pnlDiscription.ResumeLayout(false);
            this.pnlDiscription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvT2Salary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcPayRoll;
        private System.Windows.Forms.TabPage tbcAttendance;
        private System.Windows.Forms.TabPage tbcSalary;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtT1FileName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnT1Upload;
        private System.Windows.Forms.Button btnT1Import;
        private System.Windows.Forms.DataGridView dgvT1Attendance;
        private System.Windows.Forms.DataGridView dgvT2Salary;
        private System.Windows.Forms.ComboBox cmbT2EmployeeType;
        private System.Windows.Forms.Button btnT2Deduct;
        private System.Windows.Forms.Button btnT2Bouns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtT2Amount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtT2Search;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSheet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn empId;
        private System.Windows.Forms.DataGridViewTextBoxColumn inTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn outTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateType;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.Panel pnlDiscription;
        private System.Windows.Forms.RichTextBox rtxtDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button pnlClose;
        private System.Windows.Forms.Button pnlbtnOk;
        private System.Windows.Forms.Button btnFinalize;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn empType;
        private System.Windows.Forms.DataGridViewTextBoxColumn noOfFullDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn noOfHalfDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn basic;
        private System.Windows.Forms.DataGridViewTextBoxColumn bonus;
        private System.Windows.Forms.DataGridViewTextBoxColumn desuction;
        private System.Windows.Forms.DataGridViewTextBoxColumn salary;
    }
}