using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using MySqlX.XDevAPI.Common;
using Project.Controls;
using Project.Services;
using Project.Services.Database;

namespace Project.Forms
{
    public partial class RegisterPanel : UserControl
    {
        public RegisterPanel()
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
            DatabaseQuery db = new();

            var queryParams = new SelectQueryParams
            {
                TableName = "categoria_produto",

                Columns =
                [
                    new() { Name = "id_categ"},
                    new() { Name = "nome_categ"}
                ],
            };

            cmbCateg.DataSource = db.SelectQuery(queryParams);
            cmbCateg.DisplayMember = "nome_categ";
            cmbCateg.ValueMember = "id_categ";
        }

        private void LoadPositions()
        {
            DatabaseQuery db = new();

            var queryParams = new SelectQueryParams
            {
                TableName = "cargo_func",

                Columns =
                [
                    new() { Name = "id_cargo"},
                    new() { Name = "nome_cargo"}
                ],
            };

            cmbPos.DataSource = db.SelectQuery(queryParams);
            cmbPos.DisplayMember = "nome_cargo";
            cmbPos.ValueMember = "id_cargo";
        }

        private static bool ProductExists(string productName)
        {
            DatabaseQuery db = new();

            var queryParams = new SelectQueryParams
            {
                TableName = "produto",
                Where = $"REPLACE(nome_prod, ' ', '') LIKE REPLACE(\"%{productName}%\", ' ', '')"
            };

            var result = db.SelectQuery(queryParams);

            if (result != null && result.Rows.Count > 0)
                return true;

            return false;
        }
        private void btnProducts_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(pnlProduct);
            txtProductName.Focus();
            DatabaseQuery db = new();

            var queryParams = new SelectQueryParams
            {
                TableName = "produto",
                Columns = [new() { Name = "MAX(id_prod) + 1" }]
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

        private static void InsertEmployee(string id, string name, string email, DateTime admDate, int position, string psw)
        {
            DatabaseQuery db = new();

            var queryParams = new InsertQueryParams
            {
                TableName = "funcionario",
                Columns = ["nome_func", "cpf_func", "cargo_func", "email_func", "dt_admissao", "senha_func"],
                Values = [$"\"{name}\"", $"\"{id}\"", $"{position}", $"\"{email}\"", $"\"{admDate:yyyy-MM-dd}\"", $"md5(\"{psw}\")"]
            };

            if (db.InsertQuery(queryParams) > 0)
            {
                MessageBox.Show("Dados inseridos com sucesso.", "Cadastro concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private int InsertProducts(string name, int category, string value, string amount, string desc, string img_path, string link_url)
        {
            DatabaseQuery db = new();

            var queryParams = new InsertQueryParams
            {
                TableName = "produto",
                Columns = ["nome_prod", "categoria_prod", "valor_prod", "estoque_prod", "descricao_prod", "imagem_prod_path", "link_url"],
                Values = [$"\"{ToTitleCase(name)}\"", $"{category}", value.Replace(',', '.'), amount, $"\"{desc}\"", $"\"{img_path}\"", $"\"{link_url}\""]
            };

            if (db.InsertQuery(queryParams) > 0)
            {
                MessageBox.Show("Dados inseridos com sucesso.", "Cadastro concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 1;
            }

            return 0;
        }

        private Control? ControlExists()
        {
            foreach (Control control in Parent!.Controls)
            {
                if (control is UserControl)
                {
                    return control;
                }
            }
            return null;
        }

        private void DeleteActiveControl()
        {
            Control? control = ControlExists();
            if (control != null)
            {
                if (Parent!.Controls.Contains(control))
                {
                    Parent!.Controls.Remove(control);
                    control.Dispose();
                }
            }
        }

        private async void GoToProduct()
        {
            string productName = txtProductName.Text;
            Panel frmMain = (Panel)Parent!;

            ControlPanel? ctrlPanel = new()
            {
                Dock = DockStyle.Fill
            };

            DeleteActiveControl();
            frmMain.Controls.Clear();
            frmMain.Controls.Add(ctrlPanel);

            var tspCont = ctrlPanel.Controls.Find("tspCont", true).First() as ToolStrip;
            var txtSearch = tspCont!.Items.Find("txtSearch", true).First() as ToolStripTextBox;
            var grdData = ctrlPanel.Controls.Find("gridInv", true).First() as DataGridView;

            await Task.Delay(5);
            if (grdData!.DataSource != null)
            {
                txtSearch!.TextBox.Text = productName;
                txtSearch.TextBox.ForeColor = Color.Black;
            }

        }

        private string ToTitleCase(string text)
        {
            TextInfo formatedText = CultureInfo.CurrentCulture.TextInfo;
            return formatedText.ToTitleCase(text.ToLowerInvariant());
        }

        private void BtnEmployee_Click(object sender, EventArgs e)
        {
            pnlEmployee.BringToFront();
            pnlEmployee.Enabled = true;
            pnlProduct.Enabled = false;

            ClearTextBoxes(pnlEmployee);
            LoadPositions();
            txtId.Focus();
            txtTempPsw.Text = RandomPassword();
            dtAdDate.Value = DateTime.Now;
            cmbPos.SelectedIndex = -1;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var validFields = FieldValidation.ValidateControls(pnlProduct);
            var errorMessage = FieldValidation.SetMessage(validFields);

            // Insert employee
            if (button.Tag is string tag && tag.Equals("E"))
            {
                validFields = FieldValidation.ValidateControls(pnlEmployee);
                errorMessage = FieldValidation.SetMessage(validFields);

                if (validFields.Any(key => key.Key > 0))
                {
                    MessageBox.Show($"Todos os campos devem ser preenchidos corretamente! \n\n{errorMessage}", "Erro no cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                InsertEmployee(txtId.Text, txtName.Text.Replace("'", "\\'"), txtEmail.Text.Replace("'", "\\'"), dtAdDate.Value, (int)cmbPos.SelectedValue!, txtTempPsw.Text);
                BtnEmployee_Click(sender, e);
                return;
            }

            // Insert Product
            if (validFields.Any(key => key.Key > 0))
            {
                MessageBox.Show($"Todos os campos devem ser preenchidos corretamente! \n\n{errorMessage}", "Erro no cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ProductExists(txtProductName.Text))
            {
                var formatedText = ToTitleCase(txtProductName.Text);
                var response = MessageBox.Show($"Produto \"{formatedText}\" já cadastrado! \n Deseja alterar o cadastro?", "Produto Encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (response == DialogResult.Yes)
                {
                    GoToProduct();
                }
                return;
            }

            string? documentsPath = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.ToString();
            string folderPath = Path.Combine(documentsPath ?? "C://", "Images");
            string savePath = Path.Combine(folderPath, $"{txtProductName.Text.Replace(" ", "-")}.png");
            int rows = InsertProducts(txtProductName.Text.Replace("'", "\\'"), (int)cmbCateg.SelectedValue!, numValue.Value.ToString(), numQty.Value.ToString(), txtDesc.Text.Replace("'", "\\'"), $"\\\\Images\\\\{txtProductName.Text.Replace("'", "\\'").Replace(" ", "-")}.png", txtLinkUrl.Text.Replace("'", "\\'"));

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

            CopyImageToWebPageFolder(savePath);
        }

        public static void CopyImageToWebPageFolder(string savePath)
        {
            var solutionDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));

            var reactAppPath = Path.Combine(solutionDirectory, "Web-Project", "web", "public", "Images");

            reactAppPath = Path.GetFullPath(reactAppPath);

            if (!Directory.Exists(reactAppPath))
                Directory.CreateDirectory(reactAppPath);

            var fileName = Path.GetFileName(savePath);
            var destinationPath = Path.Combine(reactAppPath, fileName);

            File.Copy(savePath, destinationPath, overwrite: true);
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

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            char tag = Convert.ToChar(((Button)sender).Tag);

            frmNewItem frmNewItem = new(tag);

            if (frmNewItem.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(frmNewItem.newItem))
                {
                    var item = tag.Equals('C') ? "Nova Categoria" : "Novo Cargo";
                    MessageBox.Show($"Campo \"{item}\" deve ser preenchido corretamente!!", "Erro no cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SelectQueryParams queryParams;
                InsertQueryParams insertParams;
                DatabaseQuery db = new();

                string newItem = ToTitleCase(frmNewItem.newItem.Trim()).Replace("'", "\\'");

                if (tag.Equals('C'))
                {
                    queryParams = new SelectQueryParams
                    {
                        TableName = "categoria_produto",
                        Where = $"nome_categ LIKE \'%{newItem}%\' OR SOUNDEX(nome_categ) LIKE SOUNDEX(\'{newItem}\')"
                    };
                }
                else
                {
                    queryParams = new SelectQueryParams
                    {
                        TableName = "cargo_func",
                        Where = $"nome_cargo LIKE \'%{newItem}%\' OR SOUNDEX(nome_cargo) LIKE SOUNDEX(\'{newItem}\')"
                    };
                }

                var result = db.SelectQuery(queryParams);
                int itemId = result?.Rows.Count > 0 ? Convert.ToInt32(result?.Rows[0][0]) : -1;

                if (result != null && result.Rows.Count < 1)
                {
                    if (!string.IsNullOrWhiteSpace(newItem))
                    {
                        if (tag.Equals('C'))
                        {
                            insertParams = new InsertQueryParams
                            {
                                TableName = "categoria_produto",
                                Columns = ["nome_categ"],
                                Values = [$"\'{newItem}\'"]
                            };

                            db.InsertQuery(insertParams);
                            LoadCategories();
                        }
                        else
                        {
                            insertParams = new InsertQueryParams
                            {
                                TableName = "cargo_func",
                                Columns = ["nome_cargo"],
                                Values = [$"\'{newItem}\'"]
                            };

                            db.InsertQuery(insertParams);
                            LoadPositions();
                        }

                    }
                }
                else
                    MessageBox.Show($"Item \"{result?.Rows[0][1]}\" já cadastrado!", "Item encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (tag.Equals('C'))
                    cmbCateg.SelectedValue = itemId;
                else
                    cmbPos.SelectedValue = itemId;
            }
        }

        private void userRegister_Load(object sender, EventArgs e)
        {
            BtnEmployee_Click(sender, e);
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
            BeginInvoke((MethodInvoker)delegate {
                numValue.Select(0, 6);
            });
        }

        private void numQty_Enter(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate {
                numQty.Select(0, 3);
            });
        }
    }
}
