using DVLD.User;
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
    public partial class frmMangeUsers : Form
    {
        public frmMangeUsers()
        {
            InitializeComponent();
        }

        private void frmMangeUsers_Load(object sender, EventArgs e)
        {
            dgvUsers.DataSource = clsUser.GetAllUsers();
            lblRecords.Text = dgvUsers.Rows.Count.ToString();       
            cbFilter.SelectedIndex = 0;

        }

        private void _Refresh() 
        {

            dgvUsers.DataSource = clsUser.GetAllUsers();
            lblRecords.Text = dgvUsers.Rows.Count.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0) 
            {
                if (int.TryParse(tbFilter.Text.Trim(), out int value))
                {
                    dgvUsers.DataSource = clsUser.FilterUserByUserID(value);
                }

                else
                {
                    dgvUsers.DataSource = clsUser.FilterUserByUserID(-1);
                }

               
            }
            

            else if (cbFilter.SelectedIndex == 1) 
            {

                if (int.TryParse(tbFilter.Text.Trim(), out int value))
                {
                    dgvUsers.DataSource = clsUser.FilterUserByPersonID(value);
                }

                else
                {
                    dgvUsers.DataSource = clsUser.FilterUserByPersonID(-1);
                }
            }
            else if (cbFilter.SelectedIndex == 2) 
            {
                dgvUsers.DataSource = clsUser.FilterUserByUserName(tbFilter.Text.Trim());
            }

            else 
            {
                dgvUsers.DataSource = clsUser.FilterUserByName(tbFilter.Text.Trim());
            }

            if (string.IsNullOrEmpty(tbFilter.Text.Trim()))
            {
               dgvUsers.DataSource = clsUser.GetAllUsers();    
            }


            _Refresh();

        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 0 || cbFilter.SelectedIndex==1) 
            {

                if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) 
                {
                    e.Handled = true;
                
                }
            
            }

            else if(cbFilter.SelectedIndex == 2 || cbFilter.SelectedIndex == 3) 
            {

                if (!char.IsLetter (e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;

                }


            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(-1);
            frm.RefreshData += _Refresh;
            frm.ShowDialog();
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID =int.Parse( dgvUsers.CurrentRow.Cells[0].Value.ToString());
            frmAddEditUser frm = new frmAddEditUser(UserID);
            frm.RefreshData += _Refresh;
            frm.ShowDialog();

        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {


            int UserIDToDelete = int.Parse(dgvUsers.CurrentRow.Cells[0].Value.ToString());


            if (
            MessageBox.Show($"Are You Sure To Delete This User With ID {UserIDToDelete}", "Warrning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            == DialogResult.Yes)
            {

                if (clsUser.DeleteUser(UserIDToDelete))
                {
                    MessageBox.Show($"User With ID {UserIDToDelete} Deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("User Not Deleted");

                }



            }
            else
            {
                MessageBox.Show("حدث خطا اثناء حذف الشخص");

            }

            _Refresh();
        }
    


        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = int.Parse(dgvUsers.CurrentRow.Cells[0].Value.ToString());
            clsUser User = clsUser.FindUser(UserID);

            frmChangePassword frm = new frmChangePassword(User);
            frm.ShowDialog();
        }

        private void userInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = int.Parse(dgvUsers.CurrentRow.Cells[0].Value.ToString());
            clsUser User = clsUser.FindUser(UserID);
            ShowUserDetails frm = new ShowUserDetails(User );
            frm.ShowDialog();
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int UserID = int.Parse(dgvUsers.CurrentRow.Cells[0].Value.ToString());
            clsUser User = clsUser.FindUser(UserID);
            ShowUserDetails frm = new ShowUserDetails(User);
            frm.ShowDialog();
        }
    }
}
