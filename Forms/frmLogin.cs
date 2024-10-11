using System.Data;
using Project.Forms;
using Project.Services.Database;

namespace Project
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        { 
            Database db = new();

            var queryParams = new SelectQueryParams
            {
                TableName = "funcionario",
                Where = $"cpf_func = {txtId.Text} AND senha_func = md5(\"{txtPsw.Text}\")"
            };

            var result = db.SelectQuery(queryParams);
             
            if (result != null && result.Rows.Count == 1)
            {
                this.Hide();
                frmMain frmMain = new(result.Rows[0][2].ToString() ?? "");
                frmMain.ShowDialog();
                this.Close();
            }
        }
    }
}
