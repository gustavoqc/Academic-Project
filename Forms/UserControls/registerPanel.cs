using System.Security.Cryptography;
using System.Windows.Forms;
using Project.Services.Database;

namespace Project.Forms
{
    public partial class registerPanel : UserControl
    {
        public registerPanel()
        {
            InitializeComponent();
        }

        public static string RandomPassword()
        {
            Random random = new();
            const string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%&";
            int maxSize = random.Next(10, 13);
            char[] senha = new char[maxSize];
            byte[] bytes = new byte[maxSize];

            using (var gerador = RandomNumberGenerator.Create())
            {
                gerador.GetBytes(bytes);
            }

            for (int i = 0; i < maxSize; i++)
            {
                senha[i] = caracteres[bytes[i] % caracteres.Length];
            }

            return new string(senha);
        }

        private static void ClearTextBoxes(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
        }

        private void LoadCategories()
        {
            cmbCateg.Items.Clear();

            if (Properties.Settings.Default.CategoryOptions != null)
            {
                foreach (var value in Properties.Settings.Default.CategoryOptions)
                {
                    cmbCateg.Items.Add(value ?? "");
                }
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(pnlProduct);
            Database db = new();

            var queryParams = new SelectQueryParams
            {
                TableName = "produto",
                Columns = [new() { Name = "MAX(id_produto) + 1" }]
            };

            string? ProdId = db.SelectQuery(queryParams)?.Rows[0][0]?.ToString()?.PadLeft(5, '0');
            txtProdId.Text = ProdId ?? "";

            LoadCategories();
            imgProd.Image = imgProd.InitialImage;
            pnlProduct.BringToFront();
            pnlProduct.Enabled = true;
            pnlEmployee.Enabled = false;
            cmbCateg.SelectedIndex = -1;
            numValue.Value = 0;
            numQty.Value = 0;
        }

        private static void InsertEmployee(string id, string name, string email, DateTime admDate, string position, string psw)
        {
            Database db = new();

            var queryParams = new InsertQueryParams
            {
                TableName = "funcionario",
                Columns = ["nome_func", "cpf_func", "cargo_func", "email_func", "dt_admissao", "senha_func"],
                Values = [$"\"{name}\"", $"\"{id}\"", $"\"{position}\"", $"\"{email}\"", $"\"{admDate:yyyy-MM-dd}\"", $"md5(\"{psw}\")"]
            };

            if (db.InsertQuery(queryParams) > 0)
            {
                MessageBox.Show("Dados inseridos com sucesso.");
                return;
            }
            MessageBox.Show("Erro ao inserir dados, tente novamente mais tarde.");
        }

        private static int InsertProducts(string name, string category, string value, string amount, string desc, string img_path)
        {
            Database db = new();

            var queryParams = new InsertQueryParams
            {
                TableName = "produto",
                Columns = ["nome_produto", "categoria_produto", "valor_produto", "estoque_produto", "descricao_produto", "imagem_produto_path"],
                Values = [$"\"{name}\"", $"\"{category}\"", value.Replace(',', '.'), amount, $"\"{desc}\"", $"\"{img_path}\""]
            };

            if (db.InsertQuery(queryParams) > 0)
            {
                MessageBox.Show("Dados inseridos com sucesso.");
                return 1;
            }
            MessageBox.Show("Erro ao inserir dados, tente novamente mais tarde.");
            return 0;
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            pnlEmployee.BringToFront();
            pnlEmployee.Enabled = true;
            pnlProduct.Enabled = false;

            ClearTextBoxes(pnlEmployee);
            txtTempPsw.Text = RandomPassword();
            dtAdDate.Value = DateTime.Now;
            cmbPos.SelectedIndex = -1;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Tag is string tag && tag.Equals("E"))
            {
                InsertEmployee(txtId.Text, txtName.Text, txtEmail.Text, dtAdDate.Value, cmbPos.Text, txtTempPsw.Text);
                btnEmployee_Click(sender, e);
                return;
            }

            string? documentsPath = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.ToString();
            string folderPath = Path.Combine(documentsPath ?? "C://", "Products_Images");
            string savePath = Path.Combine(folderPath, $"Product_{txtProdId.Text}.png");
            int rows = InsertProducts(txtProductName.Text, cmbCateg.Text, numValue.Value.ToString(), numQty.Value.ToString(), txtDesc.Text, $"Product_{txtProdId.Text}.png");
            
            if (rows == 1)
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                if (!File.Exists(savePath))
                {
                    File.Copy(imgProd.Tag?.ToString() ?? $"{folderPath}\\no-image.png", savePath);
                }

                btnProducts_Click(sender, e);
            }
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void imgProd_Click(object sender, EventArgs e)
        {
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                imgProd.Image = Image.FromFile(openFile.FileName);
                imgProd.Tag = Path.GetFullPath(openFile.FileName);
            }
        }

        private void btnAddCateg_Click(object sender, EventArgs e)
        {
            frmNewCategory frmNewCategory = new();
            if (frmNewCategory.ShowDialog() == DialogResult.OK)
            {
                string newCategory = frmNewCategory.CategoryName.Trim().ToLower();
                newCategory = char.ToUpper(newCategory[0]) + newCategory.Substring(1);

                if (!string.IsNullOrWhiteSpace(newCategory) && !cmbCateg.Items.Contains(newCategory))
                {
                    var settings = Properties.Settings.Default;
                    settings.CategoryOptions ??= [];

                    cmbCateg.Items.Add(newCategory);

                    if (!settings.CategoryOptions.Contains(newCategory))
                    {
                        settings.CategoryOptions.Add(newCategory);
                        settings.Save();
                    }

                    LoadCategories();
                }
                else
                {
                    MessageBox.Show("Categoria já existe!");
                }

                cmbCateg.SelectedItem = newCategory;
            }
        }

        private void userRegister_Load(object sender, EventArgs e)
        {
            btnEmployee_Click(sender, e);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            ToolTip tooltip = new();

            Clipboard.SetText(txtTempPsw.Text);
            tooltip.Show("Texto copiado para a área de transferência", btnCopy, 0, -btnCopy.Height, 1000);
        }

        private void numValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                e.KeyChar = ',';

            if (e.KeyChar == ',')
            {
                if (((NumericUpDown)sender).Text.Contains(','))
                {
                    e.Handled = true;
                }
            }
        }

        private void numValue_Enter(object sender, EventArgs e)
        {
            numValue.Select(0, 6);
        }
    }
}
