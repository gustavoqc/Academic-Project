using Project.Services;
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
    public partial class frmNewItem : Form
    {
        private char itemTag { get; set; }
        public string newItem { get; private set; } = "";

        public frmNewItem(char itemTag)
        {
            this.itemTag = itemTag;
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            newItem = txtNewItem.Text.Replace("'", "\\'");
            this.Close();
        }

        private void frmNewItem_Load(object sender, EventArgs e)
        {
            switch (itemTag)
            {
                case 'P':
                    lblText.Text = "Digite o novo cargo";
                    this.Text = "Novo Cargo";
                    break;
                case 'C':
                    lblText.Text = "Digite a nova categoria";
                    this.Text = "Nova Categoria";
                    break;
            }
        }
    }
}
