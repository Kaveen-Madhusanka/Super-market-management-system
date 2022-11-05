namespace Supermarket_management_system
{
    partial class frmLoad
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
            this.components = new System.ComponentModel.Container();
            this.pnlV1BorderBottom = new System.Windows.Forms.Label();
            this.lblV1Version = new System.Windows.Forms.Label();
            this.tmSplash = new System.Windows.Forms.Timer(this.components);
            this.pbV1Logo = new System.Windows.Forms.PictureBox();
            this.pbV1Loder = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbV1Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbV1Loder)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlV1BorderBottom
            // 
            this.pnlV1BorderBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.pnlV1BorderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlV1BorderBottom.ForeColor = System.Drawing.Color.White;
            this.pnlV1BorderBottom.Location = new System.Drawing.Point(0, 302);
            this.pnlV1BorderBottom.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.pnlV1BorderBottom.Name = "pnlV1BorderBottom";
            this.pnlV1BorderBottom.Size = new System.Drawing.Size(821, 40);
            this.pnlV1BorderBottom.TabIndex = 96;
            this.pnlV1BorderBottom.Text = "KMSSystems™, All Rights Reserved";
            this.pnlV1BorderBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblV1Version
            // 
            this.lblV1Version.BackColor = System.Drawing.Color.Transparent;
            this.lblV1Version.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblV1Version.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(118)))), ((int)(((byte)(189)))));
            this.lblV1Version.Location = new System.Drawing.Point(311, 223);
            this.lblV1Version.Name = "lblV1Version";
            this.lblV1Version.Size = new System.Drawing.Size(210, 17);
            this.lblV1Version.TabIndex = 95;
            this.lblV1Version.Text = "Version 1.0.0.0";
            this.lblV1Version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmSplash
            // 
            this.tmSplash.Interval = 2000;
            this.tmSplash.Tick += new System.EventHandler(this.tmSplash_Tick);
            // 
            // pbV1Logo
            // 
            this.pbV1Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbV1Logo.Image = global::Supermarket_management_system.Properties.Resources.KMS_Logo;
            this.pbV1Logo.Location = new System.Drawing.Point(321, 9);
            this.pbV1Logo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbV1Logo.Name = "pbV1Logo";
            this.pbV1Logo.Size = new System.Drawing.Size(200, 197);
            this.pbV1Logo.TabIndex = 94;
            this.pbV1Logo.TabStop = false;
            // 
            // pbV1Loder
            // 
            this.pbV1Loder.BackColor = System.Drawing.Color.Transparent;
            this.pbV1Loder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbV1Loder.Image = global::Supermarket_management_system.Properties.Resources.icon_Loader;
            this.pbV1Loder.Location = new System.Drawing.Point(241, 210);
            this.pbV1Loder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbV1Loder.Name = "pbV1Loder";
            this.pbV1Loder.Size = new System.Drawing.Size(350, 89);
            this.pbV1Loder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbV1Loder.TabIndex = 97;
            this.pbV1Loder.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(817, 340);
            this.panel1.TabIndex = 98;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(171)))), ((int)(((byte)(242)))));
            this.panel2.Location = new System.Drawing.Point(9, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(40, 5);
            this.panel2.TabIndex = 1;
            this.panel2.Visible = false;
            // 
            // frmLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 342);
            this.ControlBox = false;
            this.Controls.Add(this.pnlV1BorderBottom);
            this.Controls.Add(this.lblV1Version);
            this.Controls.Add(this.pbV1Logo);
            this.Controls.Add(this.pbV1Loder);
            this.Controls.Add(this.panel1);
            this.Name = "frmLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLoad";
            this.Load += new System.EventHandler(this.frmLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbV1Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbV1Loder)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label pnlV1BorderBottom;
        private System.Windows.Forms.Label lblV1Version;
        private System.Windows.Forms.PictureBox pbV1Logo;
        private System.Windows.Forms.PictureBox pbV1Loder;
        private System.Windows.Forms.Timer tmSplash;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}