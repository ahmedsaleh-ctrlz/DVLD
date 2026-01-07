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
using System.IO;

namespace DVLD
{
    public partial class frmAddEditPerson : Form
    {
        public delegate void RefreshForm();
        public event RefreshForm Refresh;

        public enum enMode { AddNew, Update }
        private enMode _Mode;
        private clsPerson _Person;
        private int _PersonID;
        private bool _ImageSet = false;
        private static string DVLDImagePath = "C:\\MyC\\DVLD_Image_Pathes";

        public frmAddEditPerson(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
            _Mode = (_PersonID == -1) ? enMode.AddNew : enMode.Update;
            if (_Mode == enMode.AddNew)
            {
                _Person = new clsPerson();
            }
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
            }
            else if (_Mode == enMode.Update)
            {
                lblTitle.Text = "Update Person";
            }

            if (rbMale.Checked)
            {
                pbImage.Image = Properties.Resources.Male_512;
            }

            if (rbFemale.Checked)
            {
                pbImage.Image = Properties.Resources.Female_512;
            }

            lblRemove.Visible = (pbImage.ImageLocation != null);
            dtpDateOfBirh.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirh.MinDate = DateTime.Now.AddYears(-100);
            dtpDateOfBirh.Value = dtpDateOfBirh.MaxDate;
            _FillCountriesInComboBox();
            cbCountries.SelectedIndex = 50;
        }

        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("Person Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblPersonID.Text = _Person.ID.ToString();
            tbFirst.Text = _Person.FirstName;
            tbSecond.Text = _Person.SecondName;
            tbThird.Text = _Person.ThirdName;
            tbLast.Text = _Person.LastName;
            tbNaional.Text = _Person.NationalNo;
            tbPhone.Text = _Person.Phone;
            tbEmail.Text = _Person.Email;
            tbAddress.Text = _Person.Address;
            dtpDateOfBirh.Value = _Person.DateOfBirth;

            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                pbImage.ImageLocation = _Person.ImagePath;
            }

            lblRemove.Visible = (!string.IsNullOrEmpty(pbImage.ImageLocation));

            if (_Person.Gender == 0)
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }

            if (pbImage.ImageLocation == null)
            {
                if (rbMale.Checked)
                {
                    pbImage.Image = Properties.Resources.Male_512;
                }
                else
                {
                    pbImage.Image = Properties.Resources.Female_512;
                }
            }

            if (cbCountries.Items.Cast<DataRowView>().Any(row => Convert.ToInt16(row["CountryID"]) == _Person.NationalCountryID))
            {
                cbCountries.SelectedValue = _Person.NationalCountryID;
            }
            else
            {
                cbCountries.SelectedIndex = -1;
                MessageBox.Show("الدولة المرتبطة بالشخص غير موجودة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void _FillCountriesInComboBox()
        {
            DataTable dt = clsCountry.GetAllCountry();
            cbCountries.DataSource = dt;
            cbCountries.DisplayMember = "CountryName";
            cbCountries.ValueMember = "CountryID";
            cbCountries.SelectedIndex = -1;
        }

        private bool _HandleImage()
        {
            if (_Person.ImagePath != pbImage.ImageLocation)
            {
                if (!string.IsNullOrEmpty(_Person.ImagePath))
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                        return false;
                    }
                }

                if (!string.IsNullOrEmpty(pbImage.ImageLocation))
                {
                    string SourceImageFile = pbImage.ImageLocation;
                    if (clsUtil.CopyImageToProjectFile(ref SourceImageFile))
                    {
                        pbImage.ImageLocation = SourceImageFile;
                        _Person.ImagePath = SourceImageFile; // تحديث ImagePath في الكائن
                    }
                    else
                    {
                        MessageBox.Show("Error copying image.");
                        return false;
                    }
                }
                else
                {
                    _Person.ImagePath = null; // لو مسحت الصورة، ضع ImagePath كـ null
                }
            }
            return true;
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            rbMale.Checked = true;
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFirst.Text) || string.IsNullOrWhiteSpace(tbNaional.Text))
            {
                MessageBox.Show("يرجى إدخال الاسم الأول والرقم الوطني!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbCountries.SelectedValue == null)
            {
                MessageBox.Show("يرجى اختيار دولة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_HandleImage()) { return; }

            _Person.FirstName = tbFirst.Text;
            _Person.SecondName = tbSecond.Text;
            _Person.ThirdName = tbThird.Text;
            _Person.LastName = tbLast.Text;
            _Person.NationalNo = tbNaional.Text;
            _Person.Phone = tbPhone.Text;
            _Person.Email = tbEmail.Text;
            _Person.Address = tbAddress.Text;
            _Person.DateOfBirth = dtpDateOfBirh.Value;
            _Person.Gender = rbMale.Checked ? (short)0 : (short)1;

            try
            {
                _Person.NationalCountryID = Convert.ToInt16(cbCountries.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في اختيار الدولة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Person.Save())
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show(_Mode == enMode.Update ? "تم تحديث الشخص بنجاح" : "تم إضافة الشخص بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (_Mode == enMode.AddNew)
                {
                    _Mode = enMode.Update;
                    lblTitle.Text = "Update Person";
                    lblPersonID.Text = _Person.ID.ToString();
                }
            }
            else
            {
                MessageBox.Show("فشل حفظ البيانات!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Refresh?.Invoke();
        }

        private void tbNaional_Validating(object sender, CancelEventArgs e)
        {
            int excludePersonID = (_Mode == enMode.Update) ? _PersonID : -1;
            if (clsPerson.IsNationalNoExist(tbNaional.Text, excludePersonID))
            {
                errorProvider1.SetError(tbNaional, "National NO Already EXITST");
                e.Cancel = true;
                System.Media.SystemSounds.Asterisk.Play();
            }
            else
            {
                errorProvider1.SetError(tbNaional, "");
            }
        }

        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Title = "Select an Image";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pbImage.ImageLocation = openFileDialog1.FileName;
                    lblRemove.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطأ في تحميل الصورة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == null)
                pbImage.Image = Properties.Resources.Male_512;
        }

        private void rbFemale_CheckedChanged_1(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == null)
                pbImage.Image = Properties.Resources.Female_512;
        }
        private void lblRemove_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;

            if (rbMale.Checked)
            {
                pbImage.Image = Properties.Resources.Male_512;
            }
            else if (rbFemale.Checked)
            {
                pbImage.Image = Properties.Resources.Female_512;
            }

            lblRemove.Visible = false;
        }
    }
}