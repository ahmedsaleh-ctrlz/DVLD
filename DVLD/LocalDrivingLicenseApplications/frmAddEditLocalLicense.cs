using DVLD.Classes;
using DVLDBuisness;
using DVLDDataBussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddEditLocalLicense : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        public delegate void DataBackHandler();
        public event DataBackHandler RefreshData;
        clsApplication _Application;    



        public frmAddEditLocalLicense()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;


        }



        public frmAddEditLocalLicense(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

        }

        private void _ResetDefaultValue() 
        {
            _FillClassesIntoCB();
            if (_Mode == enMode.AddNew)
            {
                ctrlPersonCardWithFilter1.EditLinkEnabled = false;
                lblTitle.Text = "Add New Local Driving License";
                LblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.NewDrivingLicense).ApplicationFee.ToString();
                tbApplicationInfo.Enabled = false;
                cbLicenses.SelectedIndex = 2;
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
               
                
            }
            else 
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tbApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
            }

        }
       
        



      
        private void _LoadData()
            
        {
            ctrlPersonCardWithFilter1.FilterVisible = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            _Application = clsApplication.FindBaseApplication(_LocalDrivingLicenseApplication.ApplicationID);


            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_Application.ApplicantPersonID);
            
            lblApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            LblApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            cbLicenses.SelectedIndex = cbLicenses.FindString(clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            lblApplicationFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedBy.Text = clsUser.FindUser(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;
            btnNext.Visible = false;    

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _FillClassesIntoCB() 
        {
            DataTable dt = clsLicenseClass.GetAllLicenseClasses();
            foreach(DataRow row in dt.Rows) 
            {
                cbLicenses.Items.Add(row["ClassName"].ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            

       

            int LicenseClassID = clsLicenseClass.Find(cbLicenses.Text).LicenseClassID;


            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFilter1.Person.ID; 
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblApplicationFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;



            if (clsLocalDrivingLicenseApplication.IsThereAnyActiveLicense(ctrlPersonCardWithFilter1.Person.NationalNo, cbLicenses.Text))
            {
                MessageBox.Show("There is already Active Application For This License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (_LocalDrivingLicenseApplication.Save())
            {
                lblApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            RefreshData?.Invoke();


        }

        private void frmAddEditLocalLicense_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (_Mode == enMode.Update) 
            {
                _LoadData();
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            clsPerson Person = clsPerson.Find(ctrlPersonCardWithFilter1.PersonID);
            if(Person == null) 
            {
                MessageBox.Show("Please Select Person First","Select Person",MessageBoxButtons.OK, MessageBoxIcon.Error);   
                return; 
            }

          
                
                tbApplicationInfo.Enabled = true;
                tcAddUpdate.SelectedTab = tcAddUpdate.TabPages[1];
          




          

        }

      
    }
}
