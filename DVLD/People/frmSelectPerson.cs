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

namespace DVLD.People
{
    public partial class frmSelectPerson : Form
    {

        public delegate void DataBackEventHandler(int PersonID);
        public event DataBackEventHandler DataBack;



        public clsPerson _Person;
        public frmSelectPerson()
        {

            InitializeComponent();
            ctrlPersonCard1.RemovelblEdit();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMangePeople frm = new frmMangePeople();
            frm.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           



            try
            {
                _Person = clsPerson.Find(int.Parse(tbPersonID.Text.Trim()));
            }

            catch 
            {
               
                
            }

            if(_Person == null) 
            {
                MessageBox.Show("No Person Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

            ctrlPersonCard1.LoadPersonInfo(int.Parse(tbPersonID.Text.Trim()));

            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) 
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            tbPersonID.Text = "";
            _Person = null;
            
            ctrlPersonCard1.LoadPersonInfo(-1);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int PersonID = int.Parse(tbPersonID.Text.Trim().ToString());

            if (clsUser.IsUserExist(PersonID))
            {
                
                MessageBox.Show("This Person Is Already user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPersonID.Text = "";
                _Person = null;
                ctrlPersonCard1.LoadPersonInfo(-1);
                return;
            }




            if (_Person != null)
            {
                DataBack?.Invoke(_Person.ID);
                this.Close();
            }

            else 
            {
                MessageBox.Show("No Person Selected ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }

        }
    }
}
