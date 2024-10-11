using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Forms
{
    public partial class frmUpdateInventory : Form
    {
        public int productQty;

        public frmUpdateInventory(int productQty)
        {
            this.productQty = productQty;
            InitializeComponent();
        }

        private void frmUpdateInventory_Load(object sender, EventArgs e)
        {
            numNewValue.Value = productQty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            productQty = (int) numNewValue.Value;
        }
    }
}
