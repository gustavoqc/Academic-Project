using Project.Services.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project.Forms.UserControls
{
    public partial class profilePanel : UserControl
    {
        public profilePanel()
        {
            InitializeComponent();
        }

        private void profilePanel_Load(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(Parent!.Parent!.Controls.Find("lblID", true).First().Text);

            DatabaseQuery db = new();

            var queryParams = new SelectQueryParams
            {
                TableName = "funcionario",
                Columns = [
                    new() {Name = "id_func"},
                    new() {Name = "nome_func"},
                    new() {Name = "C.nome_cargo"},
                    new() {Name = "cpf_func"},
                    new() {Name = "dt_admissao"},
                    new() {Name = "senha_func"},
                    new() {Name = "email_func"},
                ],
                InnerJoin = ["cargo_func C ON C.id_cargo = cargo_func"],
                Where = $"id_func = {employeeID}",
            };

            var data = db.SelectQuery(queryParams);

            if (data == null)
                return;

            txtId.Text = data.Rows[0][0].ToString();
            txtName.Text = data.Rows[0][1].ToString();
            txtPos.Text = data.Rows[0][2].ToString();
            txtCPF.Text = data.Rows[0][3].ToString();
            txtAdmDt.Text = data.Rows[0][4].ToString()![..10];
            txtEmail.Text = data.Rows[0][6].ToString();
            txtPsw.Text = "Password";
            txtCPF.Mask = "000,000,000-00";
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPsw.Text) && !string.IsNullOrEmpty(txtConfirmPsw.Text))
            {
                if (!txtConfirmPsw.Text.Equals(txtPsw.Text))
                {
                    MessageBox.Show("As senhas não concidem!", "Erro no cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string employeeID = Parent!.Parent!.Controls.Find("lblID", true).First().Text;
                DatabaseQuery db = new();

                var queryParams = new UpdateQueryParams
                {
                    TableName = "funcionario",
                    Columns = [
                        new() {Name = "email_func", Value = $"\"{txtEmail.Text.Replace("'", "\\'")}\""},
                        new() {Name = "senha_func", Value = $"MD5(\"{txtPsw.Text.Replace("'", "\\'")}\")"}
                    ],
                    Where = new() { Column = "id_func", Value = employeeID }
                };

                var result = db.UpdateQuery(queryParams);
                if (result > 0)
                    MessageBox.Show("Cadastro atualizado com sucesso!!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPsw.Text = "";
                txtConfirmPsw.Text = "";
                txtPsw_Leave(sender, e);
            }
            else
                MessageBox.Show("Os campos devem ser preenchidos corretamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtPsw_TextChanged(object sender, EventArgs e)
        {
            if (!txtPsw.Text.Equals("Password"))
                txtConfirmPsw.Enabled = true;
            else
                txtConfirmPsw.Enabled = false;
        }

        private void txtPsw_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPsw.Text))
                txtPsw.Text = "Password";
        }

        private void txtConfirmPsw_EnabledChanged(object sender, EventArgs e)
        {
            if (!txtConfirmPsw.Enabled)
                txtConfirmPsw.Text = "";
        }

        private void txtPsw_Enter(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate {
                txtPsw.SelectAll();
            });
        }
    }
}
