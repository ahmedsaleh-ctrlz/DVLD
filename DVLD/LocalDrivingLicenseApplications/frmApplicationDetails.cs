using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.LocalDrivingLicenseApplications
{
    public partial class frmApplicationDetails : Form
    {
        int _LocalDrivingLicenseApplicationID;
        public frmApplicationDetails()
        {
            InitializeComponent();
        }

        public frmApplicationDetails(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;   
        }

        private void frmApplicationDetails_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicenseInfo1.LoadLocalDrivingLicenseAppInfo(_LocalDrivingLicenseApplicationID);
        }
    }
}
