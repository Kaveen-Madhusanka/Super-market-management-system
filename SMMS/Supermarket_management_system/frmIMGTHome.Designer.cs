namespace Supermarket_management_system
{
    partial class frmIMGTHome
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
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnStockManagement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.Location = new System.Drawing.Point(60, 31);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(154, 63);
            this.btnProduct.TabIndex = 0;
            this.btnProduct.Text = "Product Management";
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSuppliers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuppliers.Location = new System.Drawing.Point(291, 31);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(154, 63);
            this.btnSuppliers.TabIndex = 0;
            this.btnSuppliers.Text = "Suppliers Management";
            this.btnSuppliers.UseVisualStyleBackColor = false;
            this.btnSuppliers.Click += new System.EventHandler(this.btnSuppliers_Click);
            // 
            // btnStockManagement
            // 
            this.btnStockManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnStockManagement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStockManagement.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStockManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockManagement.Location = new System.Drawing.Point(522, 31);
            this.btnStockManagement.Name = "btnStockManagement";
            this.btnStockManagement.Size = new System.Drawing.Size(154, 63);
            this.btnStockManagement.TabIndex = 1;
            this.btnStockManagement.Text = "Stock Management";
            this.btnStockManagement.UseVisualStyleBackColor = false;
            this.btnStockManagement.Click += new System.EventHandler(this.btnStockManagement_Click);
            // 
            // frmIMGTHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStockManagement);
            this.Controls.Add(this.btnSuppliers);
            this.Controls.Add(this.btnProduct);
            this.Name = "frmIMGTHome";
            this.Text = "INVENTORY MANAGEMENT";
            this.Load += new System.EventHandler(this.frmIMGTHome_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnSuppliers;
        private System.Windows.Forms.Button btnStockManagement;
    }
}