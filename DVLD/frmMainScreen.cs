using DVLDDataBussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD
{
    public partial class frmMainScreen : Form
    {

        public static clsUser CurrentUser;

        public frmMainScreen(clsUser User)
        {
            InitializeComponent();
            CurrentUser = User;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient mdiClient)
                {
                    mdiClient.BackColor = Color.Black;
                }
            }

        }
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {


            string formName = "frmMangePeople";

           
            Form existingForm = System.Windows.Forms.Application.OpenForms[formName];

            if (existingForm != null)
            {
                
                existingForm.BringToFront();
                System.Media.SystemSounds.Beep.Play();

            }
            else
            {
        
                frmMangePeople frm = new frmMangePeople
                {
                    MdiParent = this, 
                    Name = formName   
                };
                frm.Show();
            }


        }

        private void accountSettingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowUserDetails frm = new ShowUserDetails(CurrentUser);
            frm.MdiParent = this;
            frm.Show(); 
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();

        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(CurrentUser);
            frm.MdiParent = this;
            frm.Show();

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string formName = "frmMangeUsers";


            Form existingForm = System.Windows.Forms.Application.OpenForms[formName];

            if (existingForm != null)
            {

                existingForm.BringToFront();
                System.Media.SystemSounds.Beep.Play();

            }

            else
            {
                frmMangeUsers frm = new frmMangeUsers();
                frm.MdiParent = this;
                frm.Show();
            }

        }

        private void mangeApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangeApplicationTypes frm = new frmMangeApplicationTypes();  
            frm.MdiParent = this;
            frm.Show();
        }

        private void mangeTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangeTestType frm = new frmMangeTestType();
            frm.MdiParent = this;
            frm.Show();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLocalLicense frm = new frmAddEditLocalLicense();  
            frm.MdiParent = this;   
            frm.Show(); 
        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangeLocalDrivingLicense frm = new frmMangeLocalDrivingLicense();
            frm.MdiParent = this;
            frm.Show();
        }

        
    }
}
