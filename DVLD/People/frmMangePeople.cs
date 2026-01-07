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
using System.Threading;

namespace DVLD
{
    public partial class frmMangePeople : Form
    {
        private DataTable _dtAllPeople;
        
        

      
        public frmMangePeople()
        {
            InitializeComponent();
            
        }

        private async void frmMangePeople_Load(object sender, EventArgs e)
        {
            _dtAllPeople = await Task.Run(() => clsPerson.GetAllPeople());
            dgvPeople.DataSource = _dtAllPeople;
            cbFilter.SelectedIndex = 2;
            _RefreshRecordLabel();

            if (dgvPeople.Rows.Count > 0)
            {

                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 80;

                dgvPeople.Columns[1].HeaderText = "National No.";
                dgvPeople.Columns[1].Width = 80;


                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 120;

       

                dgvPeople.Columns[3].HeaderText = "Last Name";
                dgvPeople.Columns[3].Width = 120;

                dgvPeople.Columns[4].HeaderText = "Date Of Birth";
                dgvPeople.Columns[4].Width = 120;

                dgvPeople.Columns[5].HeaderText = "Gender";
                dgvPeople.Columns[5].Width = 100;

       

                dgvPeople.Columns[6].HeaderText = "Phone";
                dgvPeople.Columns[6].Width = 120;


                dgvPeople.Columns[7].HeaderText = "Email";
                dgvPeople.Columns[7].Width = 110;


                dgvPeople.Columns[8].HeaderText = "Nationality";
                dgvPeople.Columns[8].Width = 120;

            }

        }

        private void _RefreshRecordLabel() 
        {

            if (dgvPeople.Rows.Count == 0)
            {
                lblRecord.Text = "No Records Exist ";
            }

            else
            {
                lblRecord.Text = dgvPeople.Rows.Count.ToString();

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filterBy = "";


            switch (cbFilter.Text)
            {
                case "Person ID":
                    filterBy = "PersonID";
                    break;
                case "National No.":
                    filterBy = "NationalNo";
                    break;

                case "First Name":
                    filterBy = "FirstName";
                    break;

                case "Last Name":
                    filterBy = "LastName";
                    break;

                case "Email":
                    filterBy = "Email";
                    break;

                case "Nationality":
                    filterBy = "CountryName";
                    break;
            }
                    if (textBox1.Text.Trim() == "" || filterBy == "None")
                    {
                        _dtAllPeople.DefaultView.RowFilter = "";
                        lblRecord.Text = dgvPeople.Rows.Count.ToString();
                        return;
                    }


                    if (filterBy == "PersonID")
                        //in this case we deal with integer not string.

                        _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterBy, textBox1.Text.Trim());
                    else
                        _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterBy, textBox1.Text.Trim());

                    lblRecord.Text = dgvPeople.Rows.Count.ToString();



         }


        

        private void btnAddPerson_Click(object sender, EventArgs e)
        {

            frmAddEditPerson frm = new frmAddEditPerson(-1);
            frm.Refresh += _RefreshData;
            frm.ShowDialog();
        }

        private void _RefreshData() 
        {

            _dtAllPeople = clsPerson.GetAllPeople();
            dgvPeople.DataSource = _dtAllPeople;
           
            _RefreshRecordLabel() ;


        }

        private void edITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.Refresh += _RefreshData;
            frm.ShowDialog();
        }

        private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int IDPersonToDelete = (int)dgvPeople.CurrentRow.Cells[0].Value;



            if (
            MessageBox.Show($"Are You Sure To Delete This Person With ID {IDPersonToDelete}","Warrning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)
            == DialogResult.Yes) 
            {

                if (clsPerson.Delete(IDPersonToDelete)) 
                {
                    MessageBox.Show($"Person With ID {IDPersonToDelete} Deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshData();
                }
                else 
                {
                    MessageBox.Show("Perosn Not Deleted");
                
                }

            
            
            }
            else 
            {
                MessageBox.Show("حدث خطا اثناء حذف الشخص");
            
            }

           
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();
        }

        private void dgvPeople_DoubleClick(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {

                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;

                }

            }

            
        }
    }
}

