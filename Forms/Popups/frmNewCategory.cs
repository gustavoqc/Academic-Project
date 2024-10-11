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
    public partial class frmNewCategory : Form
    {
        public string CategoryName { get; private set; } = "";

        public frmNewCategory()
        {
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            CategoryName = txtCategory.Text;
            this.Close();
        }
    }
}
