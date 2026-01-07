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
    public partial class ctrlPersonCard : UserControl
    {
        clsPerson _Person;

        private bool _EditLinkEnable = true;
        public bool EnableEditLink 
        {
            get 
            {
                return _EditLinkEnable;
            }
            set 
            {
                _EditLinkEnable = value;    
                lblLinkLabel.Enabled = _EditLinkEnable;    
            }
        }  
        

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void  LoadPersonInfo(int personID)
        {

            _Person = clsPerson.Find(personID);

            if(_Person == null)
            
            {
                lblPersonID.Text = string.Empty;
                lblName.Text = string.Empty;
                lblNational.Text = string.Empty;
                lblEmail.Text = string.Empty;
                lblAddress.Text = string.Empty  ;
                lblDate.Text = string.Empty;
                lblPhone.Text = string.Empty;
                lblCountry.Text = string.Empty;
                lblGender.Text = string.Empty;
                pbImage.Image = null;
                return; 
            }



            lblPersonID.Text = personID.ToString();
            lblName.Text = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
            lblNational.Text = _Person.NationalNo;
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblDate.Text = _Person.DateOfBirth.ToString("d");
            lblPhone.Text = _Person.Phone;
            lblCountry.Text = clsCountry.GetCountryNameByID(_Person.NationalCountryID);

            //Gender
            if (_Person.Gender == 0)
            {
                pbGender.BackgroundImage = Properties.Resources.man_gentleman_husband_male_guy;
                lblGender.Text = "Male";

            }
            else if (_Person.Gender == 1)
            {
                {
                    pbGender.BackgroundImage = Properties.Resources.woman_girl_lady_female_wife;
                    lblGender.Text = "Female";
                }

            }

            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {

                pbImage.ImageLocation = _Person.ImagePath; 
            }

            else 
            {
                if (_Person.Gender == 0)
                {
                    pbImage.Image = Properties.Resources.Male_512;


                }
                else if (_Person.Gender == 1)
                {

                    pbImage.Image = Properties.Resources.Female_512;



                }

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_Person.ID);
            frm.ShowDialog();
        }

        public void RemovelblEdit() 
        {
            lblLinkLabel.Enabled = false;
        }
    }
}