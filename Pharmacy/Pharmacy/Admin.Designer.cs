namespace Pharmacy
{
    partial class Admin
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
            this.dgvAdmin = new System.Windows.Forms.DataGridView();
            this.btnAdminDelete = new System.Windows.Forms.Button();
            this.btnAdminConfirm = new System.Windows.Forms.Button();
            this.txtAdminMail = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmin)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAdmin
            // 
            this.dgvAdmin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdmin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAdmin.Location = new System.Drawing.Point(0, 317);
            this.dgvAdmin.Name = "dgvAdmin";
            this.dgvAdmin.RowHeadersWidth = 62;
            this.dgvAdmin.RowTemplate.Height = 28;
            this.dgvAdmin.Size = new System.Drawing.Size(1240, 309);
            this.dgvAdmin.TabIndex = 0;
            this.dgvAdmin.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdmin_CellDoubleClick);
            // 
            // btnAdminDelete
            // 
            this.btnAdminDelete.Location = new System.Drawing.Point(395, 177);
            this.btnAdminDelete.Name = "btnAdminDelete";
            this.btnAdminDelete.Size = new System.Drawing.Size(137, 33);
            this.btnAdminDelete.TabIndex = 1;
            this.btnAdminDelete.Text = "Delete";
            this.btnAdminDelete.UseVisualStyleBackColor = true;
            this.btnAdminDelete.Visible = false;
            this.btnAdminDelete.Click += new System.EventHandler(this.btnAdminDelete_Click);
            // 
            // btnAdminConfirm
            // 
            this.btnAdminConfirm.Location = new System.Drawing.Point(577, 177);
            this.btnAdminConfirm.Name = "btnAdminConfirm";
            this.btnAdminConfirm.Size = new System.Drawing.Size(137, 33);
            this.btnAdminConfirm.TabIndex = 2;
            this.btnAdminConfirm.Text = "Confirm";
            this.btnAdminConfirm.UseVisualStyleBackColor = true;
            this.btnAdminConfirm.Visible = false;
            this.btnAdminConfirm.Click += new System.EventHandler(this.btnAdminConfirm_Click);
            // 
            // txtAdminMail
            // 
            this.txtAdminMail.Location = new System.Drawing.Point(64, 177);
            this.txtAdminMail.Name = "txtAdminMail";
            this.txtAdminMail.ReadOnly = true;
            this.txtAdminMail.Size = new System.Drawing.Size(244, 26);
            this.txtAdminMail.TabIndex = 3;
            this.txtAdminMail.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1240, 33);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(89, 29);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 626);
            this.Controls.Add(this.txtAdminMail);
            this.Controls.Add(this.btnAdminConfirm);
            this.Controls.Add(this.btnAdminDelete);
            this.Controls.Add(this.dgvAdmin);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Admin_FormClosing);
            this.Load += new System.EventHandler(this.Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmin)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAdmin;
        private System.Windows.Forms.Button btnAdminDelete;
        private System.Windows.Forms.Button btnAdminConfirm;
        private System.Windows.Forms.TextBox txtAdminMail;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
    }
}