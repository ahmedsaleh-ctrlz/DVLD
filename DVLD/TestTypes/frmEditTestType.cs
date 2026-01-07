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
    public partial class frmEditTestType : Form
    {
        public delegate void EventHandler();
        public event EventHandler RefreshData;

        private clsTestType _TestType;


        public frmEditTestType()
        {
            InitializeComponent();
        }

        public frmEditTestType(int ID)
        {
            InitializeComponent();
            _TestType = clsTestType.Find(ID);
        }

        private void _LoadData()
        {
            lblTestTypeID.Text = _TestType.TestTypeID.ToString();
            tbTestTitle.Text = _TestType.TestTypeTitle.ToString();
            tbDescription.Text = _TestType.TestTypeDescription.ToString();
            tbTestFee.Text = _TestType.TestTypeFees.ToString();

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestType.TestTypeTitle = tbTestTitle.Text.Trim();
            _TestType.TestTypeDescription = tbDescription.Text.Trim();  
            _TestType.TestTypeFees = float.Parse(tbTestFee.Text.Trim());


            if (_TestType.Update())
            {
                MessageBox.Show("Updated Successfully ✅", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData?.Invoke();
                _LoadData();
            }

            else
            {
                MessageBox.Show("Data Not Updated ❌", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbTestFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
    
