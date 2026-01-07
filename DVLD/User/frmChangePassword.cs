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
    public partial class frmChangePassword : Form
    {
        private clsUser _User;
        public frmChangePassword(clsUser User)
        {
            InitializeComponent();
            _User = User;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_User);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsSecuirty.ComputeHash(tbCurrentPass.Text.Trim()) == _User.Password.Trim())
            {
                if (tbNewPass.Text.Trim() == tbConfirmPass.Text.Trim())
                {
                    _User.Password = tbConfirmPass.Text.Trim();
                    if (_User.SaveUser())
                    {
                        MessageBox.Show("Password Updated", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    {
                        MessageBox.Show("Couldn't Update Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }

                else
                {
                    MessageBox.Show("Password Dosent Match.", "Password Dosent Match", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    errorProvider1.SetError(tbConfirmPass, "Password Dosent Match");
                    return;

                }
            }

            else
            {
                MessageBox.Show("Incorrect Password Try again.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

        }
    }
}
