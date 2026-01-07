namespace DVLD.Controls
{
    partial class ctrlPersonCardWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlPersonCardWithFilter));
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.btnSerach = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.ctrlPersonCard1 = new DVLD.ctrlPersonCard();
            this.gbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(231, 13);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(100, 24);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filter By";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "National No.",
            "Person ID"});
            this.cbFilter.Location = new System.Drawing.Point(94, 10);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 28);
            this.cbFilter.TabIndex = 3;
            // 
            // btnSerach
            // 
            this.btnSerach.Image = ((System.Drawing.Image)(resources.GetObject("btnSerach.Image")));
            this.btnSerach.Location = new System.Drawing.Point(346, 8);
            this.btnSerach.Name = "btnSerach";
            this.btnSerach.Size = new System.Drawing.Size(44, 36);
            this.btnSerach.TabIndex = 4;
            this.btnSerach.UseVisualStyleBackColor = true;
            this.btnSerach.Click += new System.EventHandler(this.btnSerach_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(396, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 36);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.button1);
            this.gbFilters.Controls.Add(this.btnSerach);
            this.gbFilters.Controls.Add(this.cbFilter);
            this.gbFilters.Controls.Add(this.label1);
            this.gbFilters.Controls.Add(this.tbSearch);
            this.gbFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbFilters.Location = new System.Drawing.Point(0, -3);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(450, 46);
            this.gbFilters.TabIndex = 6;
            this.gbFilters.TabStop = false;
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(0, 41);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(975, 389);
            this.ctrlPersonCard1.TabIndex = 0;
            // 
            // ctrlPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFilters);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Name = "ctrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(926, 430);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Button btnSerach;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbFilters;
    }
}
