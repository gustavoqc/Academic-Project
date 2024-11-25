using System.Data;
using Project.Forms;
using Project.Services.Database;

namespace Project
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void TxtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtPsw.Text))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos corretamente!", "Erro no login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatabaseQuery db = new();

            var queryParams = new SelectQueryParams
            {
                TableName = "funcionario",
                Where = $"cpf_func = \'{txtId.Text}\' AND senha_func = md5(\'{txtPsw.Text.Replace("'", "\\'")}\')"
            };

            var result = db.SelectQuery(queryParams);

            if (result == null || result.Rows.Count < 1)
            {
                MessageBox.Show("CPF ou Senha inválidos!", "Erro no login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Hide();
            FrmMain frmMain = new(result.Rows[0][2].ToString()!, result.Rows[0][0].ToString()!);
            frmMain.ShowDialog();
            this.Close();
        }
    }
}
