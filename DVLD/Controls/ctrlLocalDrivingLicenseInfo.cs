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

namespace DVLD.Controls
{


    public partial class ctrlLocalDrivingLicenseInfo : UserControl
    {


        int _LocalLicenseApplicationID;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        clsApplication _Application;

        int LocalDrivingLicenseApplicationID
        {
            get { return _LocalLicenseApplicationID; }
        }



        public ctrlLocalDrivingLicenseInfo()
        {
            InitializeComponent();
        }


        public void LoadLocalDrivingLicenseAppInfo(int localLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(localLicenseApplicationID);

            

            _FillInfo();


        }

        private void _FillInfo()
        {
            lblDLApplicaitonID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblPassedTest.Text = "....";
            ctrlApplicationInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);

        }
    }
}
