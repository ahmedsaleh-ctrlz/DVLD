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
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
        }


        public void LoadUserInfo(clsUser User) 
        {
            
            ctrlPersonCard1.LoadPersonInfo(User.PersonID);
            
            lblUserID.Text = User.UserID.ToString();
            lblUserName.Text = User.UserName.ToString();
            if (User.IsActive == true) 
            {
                lblIsActive.Text = "Yes";
            }
            else
            {
                lblIsActive.Text = "No";
            }

        }
    }
}
