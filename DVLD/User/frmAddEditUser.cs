using DVLD.People;
using DVLDDataBussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class frmAddEditUser : Form
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode;
        private clsUser _User;
        private int _UserID;

        public delegate void DataBackHandler();
        public event DataBackHandler RefreshData;

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;

            _Mode = _UserID == -1 ? enMode.AddNew : enMode.Update;

            if (_Mode == enMode.AddNew)
            {
                _User = new clsUser();
                _ResetDefaultValues();
            }
            else
            {
                _LoadUserData();
            }
        }

        private void _ResetDefaultValues()
        {
            lblPersonID.Text = "???";
            lblTitle.Text = "Add New User";
            tbUserName.Text = "";
            tbPassword.Text = "";
            radioButton1.Checked = true;
            ctrlPersonCard1.RemovelblEdit();
        }

        private void _LoadUserData()
        {
            _User = clsUser.FindUser(_UserID);
            if (_User == null)
            {
                MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblUserID.Text = _User.UserID.ToString(); 
            lblTitle.Text = "Update User";
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID); // استخدام PersonID بدل ID
            lblPersonID.Text = _User.PersonID.ToString();
            tbUserName.Text = _User.UserName;
            tbPassword.Text = _User.Password;
            if (_User.IsActive)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSelectPerson frm = new frmSelectPerson();
            frm.DataBack += _GetSelectedPersonID;
            frm.ShowDialog();
        }

        private void _GetSelectedPersonID(int PersonID)
        {
            lblPersonID.Text = PersonID.ToString();
            _User.PersonID = PersonID; // تحديث PersonID في الكائن
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // التحقق من اختيار PersonID
            if (string.IsNullOrEmpty(lblPersonID.Text) || lblPersonID.Text == "???")
            {
                MessageBox.Show("Please select a person first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (radioButton1.Checked)
            {
                _User.IsActive = true;
            }
            else
            {
                _User.IsActive = false;
            }

            _User.UserName = tbUserName.Text.Trim();
            _User.Password = tbPassword.Text.Trim();
            _User.PersonID = int.Parse(lblPersonID.Text); // تأكيد تحديث PersonID

            if (_User.SaveUser())
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show(_Mode == enMode.Update ? "User Updated Successfully" : "User Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (_Mode == enMode.AddNew)
                {
                    _Mode = enMode.Update;
                    lblTitle.Text = "Update User";
                    _UserID = _User.UserID; // تحديث UserID
                    lblUserID.Text = _User.UserID.ToString(); // افترض إن lblUserID موجود
                }
            }
            else
            {
                MessageBox.Show("فشل حفظ البيانات! تحقق من القيم أو اتصل بالدعم.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RefreshData?.Invoke();
        }
    }
}