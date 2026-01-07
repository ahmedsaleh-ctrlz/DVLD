namespace DVLD.LocalDrivingLicenseApplications
{
    partial class frmApplicationDetails
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
            this.ctrlLocalDrivingLicenseInfo1 = new DVLD.Controls.ctrlLocalDrivingLicenseInfo();
            this.SuspendLayout();
            // 
            // ctrlLocalDrivingLicenseInfo1
            // 
            this.ctrlLocalDrivingLicenseInfo1.Location = new System.Drawing.Point(-3, -1);
            this.ctrlLocalDrivingLicenseInfo1.Name = "ctrlLocalDrivingLicenseInfo1";
            this.ctrlLocalDrivingLicenseInfo1.Size = new System.Drawing.Size(918, 555);
            this.ctrlLocalDrivingLicenseInfo1.TabIndex = 0;
            // 
            // frmApplicationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 548);
            this.Controls.Add(this.ctrlLocalDrivingLicenseInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmApplicationDetails";
            this.Text = "Local Driving License Info";
            this.Load += new System.EventHandler(this.frmApplicationDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlLocalDrivingLicenseInfo ctrlLocalDrivingLicenseInfo1;
    }
}