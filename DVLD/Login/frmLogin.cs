using DVLD.Classes;
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
    public partial class frmLogin : Form
    {

       


        public frmLogin()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser CurrentUser = clsUser.FindUserWithUserName(tbUserName.Text.Trim());

            if (CurrentUser != null)
            {
                string Password=tbPassword.Text.Trim();



                if (clsSecuirty.ComputeHash(Password) == CurrentUser.Password.Trim())
                {
                    if (!CurrentUser.IsActive)
                    {
                        MessageBox.Show("This User Not Active contact your manger", "Not Active", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (chkRememberme.Checked)
                    {
                        clsGlobal.SaveUserNameAndPasswordOnReg(tbUserName.Text.Trim(),tbPassword.Text.Trim());
                    }
                    else if (!chkRememberme.Checked) 
                    {

                        clsGlobal.SaveUserNameAndPasswordOnReg("","");
                    }

                    clsGlobal.CurrentUser = CurrentUser;    
                    frmMainScreen frm = new frmMainScreen(CurrentUser);
                    clsLogger.SaveLogInEventLogger($"New Login From USER : {CurrentUser.UserName} at {DateTime.Now.ToString()} ");
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password incorrect , try again", "Password incorrect", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    tbPassword.Focus();
                }
            }
            else
            {
                MessageBox.Show("UserName not exist , try again", "UserName incorrect", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbUserName.Focus();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "";
            string password = "";
            clsGlobal.GetUserNameAndPasswordFromReg(ref UserName,ref password);    
            tbUserName.Text = UserName;
            tbPassword.Text = password; 
            chkRememberme.Checked = true;

        }
    }
}