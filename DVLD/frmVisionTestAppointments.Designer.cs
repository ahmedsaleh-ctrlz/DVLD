namespace DVLD
{
    partial class frmVisionTestAppointments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisionTestAppointments));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvTestAppointmests = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlLocalDrivingLicenseInfo1 = new DVLD.Controls.ctrlLocalDrivingLicenseInfo();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointmests)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(267, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vision Test Appointments";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(380, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dgvTestAppointmests
            // 
            this.dgvTestAppointmests.BackgroundColor = System.Drawing.Color.White;
            this.dgvTestAppointmests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestAppointmests.Location = new System.Drawing.Point(34, 699);
            this.dgvTestAppointmests.Name = "dgvTestAppointmests";
            this.dgvTestAppointmests.Size = new System.Drawing.Size(841, 151);
            this.dgvTestAppointmests.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 671);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Appointments";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.cross_32;
            this.btnClose.Location = new System.Drawing.Point(770, 856);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 38);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlLocalDrivingLicenseInfo1
            // 
            this.ctrlLocalDrivingLicenseInfo1.Location = new System.Drawing.Point(34, 172);
            this.ctrlLocalDrivingLicenseInfo1.Name = "ctrlLocalDrivingLicenseInfo1";
            this.ctrlLocalDrivingLicenseInfo1.Size = new System.Drawing.Size(852, 475);
            this.ctrlLocalDrivingLicenseInfo1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(833, 661);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 36);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmVisionTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 906);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTestAppointmests);
            this.Controls.Add(this.ctrlLocalDrivingLicenseInfo1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "frmVisionTestAppointments";
            this.Text = "frmVisionTestAppointments";
            this.Load += new System.EventHandler(this.frmVisionTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointmests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Controls.ctrlLocalDrivingLicenseInfo ctrlLocalDrivingLicenseInfo1;
        private System.Windows.Forms.DataGridView dgvTestAppointmests;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
    }
}