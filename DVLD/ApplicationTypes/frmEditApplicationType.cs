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
    public partial class frmEditApplicationType : Form
    {

        public delegate void EventHandler();
        public event EventHandler RefreshData;


        private clsApplicationTypes _ApplicationType;
        public frmEditApplicationType()
        {
            InitializeComponent();
            
        }

        public frmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationType = clsApplicationTypes.Find(ApplicationTypeID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _LoadData() 
        {
            lblApplicationTypeID.Text = _ApplicationType.ApplicationTypeID.ToString();
            tbApplicationTitle.Text = _ApplicationType.ApplicationTitle.ToString();
            tbApplicationFee.Text = _ApplicationType.ApplicationFee.ToString();

        }
        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
           _LoadData();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _ApplicationType.ApplicationTitle = tbApplicationTitle.Text.Trim();
            _ApplicationType.ApplicationFee = float.Parse( tbApplicationFee.Text.Trim());


            if (_ApplicationType.Update()) 
            {
                MessageBox.Show("Updated Successfully ✅","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
                RefreshData?.Invoke();
                _LoadData();
            }

            else 
            {
                MessageBox.Show("Data Not Updated ❌", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbApplicationFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
