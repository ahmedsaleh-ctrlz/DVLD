namespace DVLD
{
    partial class frmAddEditLocalLicense
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.tcAddUpdate = new System.Windows.Forms.TabControl();
            this.tbPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlPersonCardWithFilter1 = new DVLD.Controls.ctrlPersonCardWithFilter();
            this.tbApplicationInfo = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbLicenses = new System.Windows.Forms.ComboBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.LblApplicationDate = new System.Windows.Forms.Label();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tcAddUpdate.SuspendLayout();
            this.tbPersonInfo.SuspendLayout();
            this.tbApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Palatino Linotype", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(239, 29);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(102, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // tcAddUpdate
            // 
            this.tcAddUpdate.Controls.Add(this.tbPersonInfo);
            this.tcAddUpdate.Controls.Add(this.tbApplicationInfo);
            this.tcAddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAddUpdate.Location = new System.Drawing.Point(23, 82);
            this.tcAddUpdate.Name = "tcAddUpdate";
            this.tcAddUpdate.SelectedIndex = 0;
            this.tcAddUpdate.Size = new System.Drawing.Size(968, 476);
            this.tcAddUpdate.TabIndex = 1;
            // 
            // tbPersonInfo
            // 
            this.tbPersonInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPersonInfo.Controls.Add(this.btnNext);
            this.tbPersonInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tbPersonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPersonInfo.ForeColor = System.Drawing.Color.Black;
            this.tbPersonInfo.Location = new System.Drawing.Point(4, 29);
            this.tbPersonInfo.Name = "tbPersonInfo";
            this.tbPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPersonInfo.Size = new System.Drawing.Size(960, 443);
            this.tbPersonInfo.TabIndex = 0;
            this.tbPersonInfo.Text = "Peson Info";
            this.tbPersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::DVLD.Properties.Resources.Next_32;
            this.btnNext.Location = new System.Drawing.Point(833, 375);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(90, 47);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlPersonCardWithFilter1
            // 
           
            this.ctrlPersonCardWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(-1, 5);
            this.ctrlPersonCardWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Person = null;
            this.ctrlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(1124, 437);
            this.ctrlPersonCardWithFilter1.TabIndex = 2;
            // 
            // tbApplicationInfo
            // 
            this.tbApplicationInfo.Controls.Add(this.btnClose);
            this.tbApplicationInfo.Controls.Add(this.btnSave);
            this.tbApplicationInfo.Controls.Add(this.cbLicenses);
            this.tbApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.tbApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.tbApplicationInfo.Controls.Add(this.LblApplicationDate);
            this.tbApplicationInfo.Controls.Add(this.lblApplicationID);
            this.tbApplicationInfo.Controls.Add(this.label6);
            this.tbApplicationInfo.Controls.Add(this.label5);
            this.tbApplicationInfo.Controls.Add(this.label4);
            this.tbApplicationInfo.Controls.Add(this.label3);
            this.tbApplicationInfo.Controls.Add(this.label2);
            this.tbApplicationInfo.Location = new System.Drawing.Point(4, 29);
            this.tbApplicationInfo.Name = "tbApplicationInfo";
            this.tbApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbApplicationInfo.Size = new System.Drawing.Size(960, 443);
            this.tbApplicationInfo.TabIndex = 1;
            this.tbApplicationInfo.Text = "Application Info";
            this.tbApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.cross_32;
            this.btnClose.Location = new System.Drawing.Point(810, 380);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 48);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD.Properties.Resources.Save_32;
            this.btnSave.Location = new System.Drawing.Point(674, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 48);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbLicenses
            // 
            this.cbLicenses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenses.FormattingEnabled = true;
            this.cbLicenses.Location = new System.Drawing.Point(240, 162);
            this.cbLicenses.Name = "cbLicenses";
            this.cbLicenses.Size = new System.Drawing.Size(274, 28);
            this.cbLicenses.TabIndex = 10;
           
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(236, 246);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(39, 20);
            this.lblCreatedBy.TabIndex = 9;
            this.lblCreatedBy.Text = "???";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(236, 203);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(39, 20);
            this.lblApplicationFees.TabIndex = 8;
            this.lblApplicationFees.Text = "???";
            // 
            // LblApplicationDate
            // 
            this.LblApplicationDate.AutoSize = true;
            this.LblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblApplicationDate.Location = new System.Drawing.Point(236, 127);
            this.LblApplicationDate.Name = "LblApplicationDate";
            this.LblApplicationDate.Size = new System.Drawing.Size(39, 20);
            this.LblApplicationDate.TabIndex = 6;
            this.LblApplicationDate.Text = "???";
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationID.Location = new System.Drawing.Point(236, 81);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(49, 20);
            this.lblApplicationID.TabIndex = 5;
            this.lblApplicationID.Text = "[???]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(108, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Created By :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(72, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Application Fee :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "License Class ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Application ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Application Date :";
            // 
            // frmAddEditLocalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 603);
            this.Controls.Add(this.tcAddUpdate);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditLocalLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditLocalLicense";
            this.Load += new System.EventHandler(this.frmAddEditLocalLicense_Load);
            this.tcAddUpdate.ResumeLayout(false);
            this.tbPersonInfo.ResumeLayout(false);
            this.tbApplicationInfo.ResumeLayout(false);
            this.tbApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tcAddUpdate;
        private System.Windows.Forms.TabPage tbPersonInfo;
        private System.Windows.Forms.TabPage tbApplicationInfo;
        private System.Windows.Forms.Button btnNext;
        private Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label LblApplicationDate;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLicenses;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}