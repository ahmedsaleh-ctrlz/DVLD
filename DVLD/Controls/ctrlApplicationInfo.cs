using DVLDBuisness;
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
    public partial class ctrlApplicationInfo : UserControl
    {
        int _ApplicationID;

        clsApplication _Application;
        public int ApplicationID 
        {
            get {  return _ApplicationID; } 
        }
        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfo(int ApplicationID) 
        {
            _Application = clsApplication.FindBaseApplication(ApplicationID);
            _FillInfo();


        }

        private void _FillInfo() 
        
        {
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.StatusText;
            lblFees.Text = _Application.PaidFees.ToString();
            lblType.Text = _Application.ApplicationTypeInfo.ApplicationTitle;
            lblPerson.Text = _Application.PersonInfo.PersonFullName;
            lblDate.Text = _Application.ApplicationDate.ToString();
            lblStatusDate.Text = _Application.LastStatusDate.ToString();
            lblCreatedBy.Text = _Application.CreatedByUserInfo.UserName;
        }


       
    }
}
