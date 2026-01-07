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
    public partial class frmMangeApplicationTypes : Form
    {
        private DataTable _dtAllApplication;
        public frmMangeApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmMangeApplicationTypes_Load(object sender, EventArgs e)
        {

            _dtAllApplication = clsApplicationTypes.GetAllApplicationsType();
            dgvApplications.DataSource = _dtAllApplication;
            lblRecords.Text = dgvApplications.Rows.Count.ToString();

            dgvApplications.Columns[0].HeaderText = "ID";
            dgvApplications.Columns[0].Width = 110;
                          
            dgvApplications.Columns[1].HeaderText = "Title";
            dgvApplications.Columns[1].Width = 400;
                          
            dgvApplications.Columns[2].HeaderText = "Fees";
            dgvApplications.Columns[2].Width = 100;

        }

        private void _RefreshData() 
        {

            _dtAllApplication = clsApplicationTypes.GetAllApplicationsType();
            dgvApplications.DataSource = _dtAllApplication;
            lblRecords.Text = dgvApplications.Rows.Count.ToString();


        }

        private void editApplicationTyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType((int)dgvApplications.CurrentRow.Cells[0].Value);
            frm.RefreshData += _RefreshData;
            frm.ShowDialog();
        }
    }
}
