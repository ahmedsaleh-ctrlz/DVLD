namespace DVLD
{
    partial class frmMangeLocalDrivingLicense
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMangeLocalDrivingLicense));
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.dgvLocalDrivingLicense = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddLocalLicence = new System.Windows.Forms.Button();
            this.editApplicationTyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicense)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFilter
            // 
            this.cbFilter.AllowDrop = true;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbFilter.Location = new System.Drawing.Point(215, 214);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(142, 26);
            this.cbFilter.TabIndex = 16;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(114, 722);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "#Records :";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(235, 722);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(32, 24);
            this.lblRecords.TabIndex = 14;
            this.lblRecords.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(134, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Filter By";
            // 
            // tbFilter
            // 
            this.tbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilter.Location = new System.Drawing.Point(363, 214);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(139, 26);
            this.tbFilter.TabIndex = 12;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            this.tbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilter_KeyPress);
            // 
            // dgvLocalDrivingLicense
            // 
            this.dgvLocalDrivingLicense.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicense.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvLocalDrivingLicense.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalDrivingLicense.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalDrivingLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicense.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalDrivingLicense.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLocalDrivingLicense.GridColor = System.Drawing.Color.Black;
            this.dgvLocalDrivingLicense.Location = new System.Drawing.Point(62, 254);
            this.dgvLocalDrivingLicense.Name = "dgvLocalDrivingLicense";
            this.dgvLocalDrivingLicense.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalDrivingLicense.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLocalDrivingLicense.Size = new System.Drawing.Size(1181, 452);
            this.dgvLocalDrivingLicense.TabIndex = 11;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editApplicationTyToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.showApplicationDetailsToolStripMenuItem,
            this.canelApplicationToolStripMenuItem,
            this.shToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(222, 216);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(505, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(446, 44);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mange Local Driving License";
            // 
            // btnAddLocalLicence
            // 
            this.btnAddLocalLicence.Image = ((System.Drawing.Image)(resources.GetObject("btnAddLocalLicence.Image")));
            this.btnAddLocalLicence.Location = new System.Drawing.Point(1200, 212);
            this.btnAddLocalLicence.Name = "btnAddLocalLicence";
            this.btnAddLocalLicence.Size = new System.Drawing.Size(43, 32);
            this.btnAddLocalLicence.TabIndex = 17;
            this.btnAddLocalLicence.UseVisualStyleBackColor = true;
            this.btnAddLocalLicence.Click += new System.EventHandler(this.btnAddLocalLicence_Click);
            // 
            // editApplicationTyToolStripMenuItem
            // 
            this.editApplicationTyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editApplicationTyToolStripMenuItem.Image")));
            this.editApplicationTyToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editApplicationTyToolStripMenuItem.Name = "editApplicationTyToolStripMenuItem";
            this.editApplicationTyToolStripMenuItem.Size = new System.Drawing.Size(221, 38);
            this.editApplicationTyToolStripMenuItem.Text = "Edit";
            this.editApplicationTyToolStripMenuItem.Click += new System.EventHandler(this.editApplicationTyToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(221, 38);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showApplicationDetailsToolStripMenuItem.Image")));
            this.showApplicationDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(221, 38);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // canelApplicationToolStripMenuItem
            // 
            this.canelApplicationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("canelApplicationToolStripMenuItem.Image")));
            this.canelApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.canelApplicationToolStripMenuItem.Name = "canelApplicationToolStripMenuItem";
            this.canelApplicationToolStripMenuItem.Size = new System.Drawing.Size(221, 38);
            this.canelApplicationToolStripMenuItem.Text = "Canel Application";
            this.canelApplicationToolStripMenuItem.Click += new System.EventHandler(this.canelApplicationToolStripMenuItem_Click);
            // 
            // shToolStripMenuItem
            // 
            this.shToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTestToolStripMenuItem,
            this.scheduleWrittenTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.shToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("shToolStripMenuItem.Image")));
            this.shToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.shToolStripMenuItem.Name = "shToolStripMenuItem";
            this.shToolStripMenuItem.Size = new System.Drawing.Size(221, 38);
            this.shToolStripMenuItem.Text = "Sechdule Tests";
            // 
            // scheduleVisionTestToolStripMenuItem
            // 
            this.scheduleVisionTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleVisionTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("scheduleVisionTestToolStripMenuItem.Image")));
            this.scheduleVisionTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleVisionTestToolStripMenuItem.Name = "scheduleVisionTestToolStripMenuItem";
            this.scheduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(204, 38);
            this.scheduleVisionTestToolStripMenuItem.Text = "Schedule Vision Test";
            this.scheduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleVisionTestToolStripMenuItem_Click);
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            this.scheduleWrittenTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleWrittenTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("scheduleWrittenTestToolStripMenuItem.Image")));
            this.scheduleWrittenTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            this.scheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(204, 38);
            this.scheduleWrittenTestToolStripMenuItem.Text = "Schedule Written Test";
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleStreetTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("scheduleStreetTestToolStripMenuItem.Image")));
            this.scheduleStreetTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(204, 38);
            this.scheduleStreetTestToolStripMenuItem.Text = "Schedule Street Test";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(605, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(247, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // frmMangeLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 799);
            this.Controls.Add(this.btnAddLocalLicence);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.dgvLocalDrivingLicense);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMangeLocalDrivingLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frnMangeLocalDrivingLicense";
            this.Load += new System.EventHandler(this.frnMangeLocalDrivingLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicense)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddLocalLicence;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicense;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editApplicationTyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
    }
}