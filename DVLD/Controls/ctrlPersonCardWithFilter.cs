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

namespace DVLD.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public clsPerson Person { get; set; }


        public int PersonID { get; set; }
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            cbFilter.SelectedIndex = 0;
            

        }

        private bool _EditLinkEnabled= true;
        
        public bool EditLinkEnabled 
        {
            get 
            {
                return _EditLinkEnabled;    
            }

            set 
            {
                _EditLinkEnabled = value;
                ctrlPersonCard1.EnableEditLink = _EditLinkEnabled; 
            }


        }

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnSerach.Visible = _ShowAddPerson;
            }
        }

        
        private bool _FilterVisible = true;
        public bool FilterVisible
        {
            get
            {
                return _FilterVisible;
            }
            set
            {
                _FilterVisible = value;
                gbFilters.Visible = _FilterVisible;
            }
        }





        private void button1_Click(object sender, EventArgs e)
        {
          
            ctrlPersonCard1.LoadPersonInfo(-1);
            ctrlPersonCard1.EnableEditLink=false;
            tbSearch.Text = string.Empty;
        }

        private void btnSerach_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text != string.Empty) 
            {

                switch(cbFilter.SelectedIndex)
                {
                    case 0:
                        Person = clsPerson.Find(tbSearch.Text.Trim());
                        break;

                    case 1:
                        Person = clsPerson.Find(int.Parse(tbSearch.Text.Trim()));
                        break;
                }

                if(Person != null) 
                {
                    ctrlPersonCard1.LoadPersonInfo(Person.ID);
                    PersonID = Person.ID;   
                    ctrlPersonCard1.EnableEditLink=true;
                }

                else 
                {
                    MessageBox.Show("No Person Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            else 
            {
                MessageBox.Show("Please Enter a Value to search","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }



        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cbFilter.SelectedIndex == 1)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        public void LoadPersonInfo(int PersonID) 
        {
            ctrlPersonCard1.LoadPersonInfo(PersonID);
            Person = clsPerson.Find(PersonID);  
        }

      
    }
}
