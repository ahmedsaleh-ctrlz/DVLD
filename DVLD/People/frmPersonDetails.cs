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
    public partial class frmPersonDetails : Form
    {
        private int _PersonID;
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llblEditPersonDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_PersonID);
            frm.ShowDialog();  
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            
            ctrlPersonCard1.LoadPersonInfo(_PersonID);
        }
    }
}
