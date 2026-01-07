using DVLD.LocalDrivingLicenseApplications;
using DVLDBuisness;
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

namespace DVLD
{
    public partial class frmMangeLocalDrivingLicense : Form
    {
        private DataTable _dtLocalDrivingLicense;


        public frmMangeLocalDrivingLicense()
        {
            InitializeComponent();
            
        }





        private void _Refresh()
        {
            _dtLocalDrivingLicense = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvLocalDrivingLicense.DataSource = _dtLocalDrivingLicense;
            lblRecords.Text = dgvLocalDrivingLicense.Rows.Count.ToString();
        }

        private void frnMangeLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            _dtLocalDrivingLicense = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvLocalDrivingLicense.DataSource = _dtLocalDrivingLicense;

            if (dgvLocalDrivingLicense.Rows.Count > 0)

            {
                dgvLocalDrivingLicense.Columns[0].HeaderText = "L.D.L AppID";
                dgvLocalDrivingLicense.Columns[0].Width = 100;

                dgvLocalDrivingLicense.Columns[1].HeaderText = "Driving Class";
                dgvLocalDrivingLicense.Columns[1].Width = 270;

                dgvLocalDrivingLicense.Columns[2].HeaderText = "National No";
                dgvLocalDrivingLicense.Columns[2].Width = 100;

                dgvLocalDrivingLicense.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicense.Columns[3].Width = 270;

                dgvLocalDrivingLicense.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicense.Columns[4].Width = 150;

                dgvLocalDrivingLicense.Columns[5].HeaderText = "Passed Tests";
                dgvLocalDrivingLicense.Columns[5].Width = 20;

                dgvLocalDrivingLicense.Columns[6].HeaderText = "Status";
                dgvLocalDrivingLicense.Columns[6].Width = 100;

            }

            cbFilter.SelectedIndex = 0;



        }



        private void tbFilter_TextChanged(object sender, EventArgs e)
        {



                string FilterColumn = "";
                //Map Selected Filter to real Column name 
                switch (cbFilter.Text)
                {

                    case "L.D.L.AppID":
                        FilterColumn = "LocalDrivingLicenseApplicationID";
                        break;

                    case "National No.":
                        FilterColumn = "NationalNo";
                        break;


                    case "Full Name":
                        FilterColumn = "FullName";
                        break;

                    case "Status":
                        FilterColumn = "Status";
                        break;


                    default:
                        FilterColumn = "None";
                        break;



                }

                if (tbFilter.Text.Trim() == "" || FilterColumn == "None")
                {
                    _dtLocalDrivingLicense.DefaultView.RowFilter = "";
                    lblRecords.Text = dgvLocalDrivingLicense.Rows.Count.ToString();
                    return;
                }


                if (FilterColumn == "LocalDrivingLicenseApplicationID")
                    //in this case we deal with integer not string.
                    _dtLocalDrivingLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbFilter.Text.Trim());
                else
                    _dtLocalDrivingLicense.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbFilter.Text.Trim());

                lblRecords.Text = dgvLocalDrivingLicense.Rows.Count.ToString();
            
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Visible = (cbFilter.Text != "None");

            if (tbFilter.Visible)
            {
                tbFilter.Text = "";
                tbFilter.Focus();
            }

            _dtLocalDrivingLicense.DefaultView.RowFilter = "";
            lblRecords.Text = dgvLocalDrivingLicense.Rows.Count.ToString();
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 1) 
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void btnAddLocalLicence_Click(object sender, EventArgs e)
        {
            frmAddEditLocalLicense frm = new frmAddEditLocalLicense();
            frm.RefreshData += _Refresh;
            frm.ShowDialog();

        }

        private void editApplicationTyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLocalLicense frm = new frmAddEditLocalLicense((int)dgvLocalDrivingLicense.CurrentRow.Cells[0].Value);
            frm.RefreshData += _Refresh;
            frm.ShowDialog();   
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Are You Sure to cancel this Application ? ", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.No)
            {
                return;
            }

            int LDLAppID = (int)dgvLocalDrivingLicense.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LDLAppID);

           

                if (localDrivingLicenseApplication.Delete()) 
                 
                {
                    MessageBox.Show("Application Deleted","success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                     _Refresh();
                 }

                else 
                {
                    MessageBox.Show("Application Not Deleted", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            
           
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmApplicationDetails frm = new frmApplicationDetails((int)dgvLocalDrivingLicense.CurrentRow.Cells[0].Value);     
            frm.ShowDialog();   

        }

        private void canelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are You Sure to cancel this Application ? ", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.No) 
            {
                return;
            }

            int LocalDrivingAppID = (int)dgvLocalDrivingLicense.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication _LocalDrivingLicenseApp =
            clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingAppID);


           
             if(_LocalDrivingLicenseApp.Cancel())
             {
                    MessageBox.Show($"Application With ID {LocalDrivingAppID} Cancelled", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

             _Refresh();
             }

             else 
             {
                    MessageBox.Show($"Application With ID {LocalDrivingAppID} Cannot Cancelled", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }

        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisionTestAppointments frm = new frmVisionTestAppointments((int)dgvLocalDrivingLicense.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }


}
