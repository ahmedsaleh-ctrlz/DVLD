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
    public partial class ShowUserDetails : Form
    {
        clsUser _CurrentUser;
        public ShowUserDetails(clsUser User)
        {
            InitializeComponent();
            _CurrentUser = User;
 
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_CurrentUser.PersonID);
            frm.ShowDialog();
        }

        private void ShowUserDetails_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_CurrentUser);
        }
    }
}
