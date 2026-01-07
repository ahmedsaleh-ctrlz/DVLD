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
    public partial class frmVisionTestAppointments : Form
    {

        private DataTable _dtTestAppointment;


        int _LocalDrivingLicenseApplicationID;


        public frmVisionTestAppointments(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;   
        }

        private void frmVisionTestAppointments_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicenseInfo1.LoadLocalDrivingLicenseAppInfo(_LocalDrivingLicenseApplicationID);
            _dtTestAppointment = clsTestAppointment.GetTestAppointmentsForLocalDrivingLicenseID(_LocalDrivingLicenseApplicationID, 1);
            dgvTestAppointmests.DataSource = _dtTestAppointment;    
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
