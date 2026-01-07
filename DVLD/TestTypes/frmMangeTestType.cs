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
    public partial class frmMangeTestType : Form
    {

        private DataTable _dtAllTests;
        public frmMangeTestType()
        {
            InitializeComponent();
        }

        private void _RefreshData()
        {

            _dtAllTests = clsTestType.GetAllTestTypes();
            dgvTests.DataSource = _dtAllTests;
            lblRecords.Text = dgvTests.Rows.Count.ToString();


        }

        private void frmMangeTestType_Load(object sender, EventArgs e)
        {

            _dtAllTests = clsTestType.GetAllTestTypes();
            dgvTests.DataSource = _dtAllTests;
            lblRecords.Text = dgvTests.Rows.Count.ToString();

            dgvTests.Columns[0].HeaderText = "ID";
            dgvTests.Columns[0].Width = 120;

            dgvTests.Columns[1].HeaderText = "Title";
            dgvTests.Columns[1].Width = 200;

            dgvTests.Columns[2].HeaderText = "Description";
            dgvTests.Columns[2].Width = 400;

            dgvTests.Columns[3].HeaderText = "Fees";
            dgvTests.Columns[3].Width = 100;
        }

        private void editApplicationTyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType((int)dgvTests.CurrentRow.Cells[0].Value);
            frm.RefreshData += _RefreshData;
            frm.ShowDialog();
        }
    }
}
