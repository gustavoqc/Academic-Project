using System.Data;
using System.Windows.Forms;
using Project.Forms;
using Project.Services.Database;

namespace Project.Controls
{
    public partial class ControlPanel : UserControl
    {
        public ControlPanel()
        {
            InitializeComponent();
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

        private void HideActionButtons()
        {
            btnUpdateInv.Visible = false;
            btnUpdateProduct.Visible = false;
            btnDeleteProd.Visible = false;
            btnApprove.Visible = false;
            btnDeny.Visible = false;
        }

        private void ShowActionButtons(char set)
        {
            bool isRowSelected = gridInv.SelectedRows.Count > 0;
            if (set.Equals('I'))
            {
                btnUpdateInv.Visible = isRowSelected;
                btnUpdateProduct.Visible = isRowSelected;
                btnDeleteProd.Visible = isRowSelected;
                return;
            }

            btnApprove.Visible = isRowSelected;
            btnDeny.Visible = isRowSelected;
        }

        private async Task<DataTable?> InventoryData()
        {
            return await Task.Run(() =>
            {
                Database db = new();

                var queryParams = new SelectQueryParams
                {
                    TableName = "produto",

                    Columns =
                    [
                        new() { Name = "id_produto", Alias = "ID" },
                        new() { Name = "nome_produto", Alias = "Produto" },
                        new() { Name = "categoria_produto", Alias = "Categoria" },
                        new() { Name = "valor_produto", Alias = "Valor" },
                        new() { Name = "descricao_produto", Alias = "Descrição" },
                        new() { Name = "estoque_produto", Alias = "Qtde" }
                    ],

                    OrderBy = "estoque_produto ASC"
                };

                return db.SelectQuery(queryParams) ?? null;
            });
        }

        private async Task<DataTable?> TransactionData(char status)
        {
            string transStatus = "";

            switch (status)
            {
                case 'A':
                    transStatus = "=";
                    break;
                case 'H':
                    transStatus = "!=";
                    break;
            }

            return await Task.Run(() =>
            {
                Database db = new();

                var queryParams = new SelectQueryParams
                {
                    TableName = "transacao T",

                    Columns =
                    [
                        new() { Name = "T.id_transacao"},
                        new() { Name = "T.transacao_valida"},
                        new() { Name = "C.nome_cliente", Alias = "Cliente" },
                        new() { Name = "T.dt_transacao", Alias = "Data" },
                        new() { Name = "T.valor_total", Alias = "Valor" },
                        new() { Name = "T.descricao_transacao", Alias = "Descrição" },
                        new() { Name = "P.nome_pagamento", Alias = "Pagamento" }
                    ],

                    InnerJoin =
                    [
                        "cliente C ON T.id_cliente_selecionado = C.id_cliente",
                        "pagamento P ON T.tipo_pagamento_selecionado = P.tipo_pagamento"
                    ],

                    Where = $"status_transacao {transStatus} 0",
                    OrderBy = "dt_transacao ASC, transacao_valida Desc"
                };

                return db.SelectQuery(queryParams) ?? null;
            });
        }

        private async void LoadData(string data)
        {
            pgbData.Visible = true;
            gridInv.DataSource = "";

            switch (data)
            {
                case "I":
                    gridInv.DataSource = await InventoryData();
                    gridInv.DefaultCellStyle.BackColor = Color.White;
                    break;
                case "TA":
                    gridInv.DataSource = await TransactionData('A');
                    gridInv.Columns[1].Visible = false;
                    gridInv.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
                    break;
                case "TH":
                    gridInv.DataSource = await TransactionData('H');
                    gridInv.Columns[1].Visible = false;

                    foreach (DataGridViewRow row in gridInv.Rows)
                    {
                        if (!(bool)row.Cells[1].Value)
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 160, 160);
                            continue;
                        }
                        row.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192);
                    }

                    break;
            }

            if (gridInv.SelectedRows.Count > 0)
            {
                gridInv.Columns[0].Visible = false;
                gridInv.ClearSelection();
            }

            if (!pgbData.IsDisposed)
                pgbData.Visible = false;
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {
            editProduct.Visible = false;
            HideActionButtons();
            LoadData("I");
            gridInv.Tag = "I";
        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            HideActionButtons();
            LoadData("I");
            gridInv.Tag = "I";
        }

        private void GridInv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridInv.Columns[e.ColumnIndex].Name == "Qtde")
            {
                if (e.Value is int value)
                {
                    if (e.CellStyle == null) return;

                    if (value <= 5)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 160, 160);
                        return;
                    }
                    else if (value > 5 && value < 15)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 255, 192);
                        return;
                    }

                    e.CellStyle.BackColor = Color.FromArgb(192, 255, 192);
                }
            }
        }

        private void TimerData_Tick(object sender, EventArgs e)
        {
            LoadData(gridInv.Tag?.ToString() ?? "I");
        }

        private void btnActiveTrans_Click(object sender, EventArgs e)
        {
            editProduct.Visible = false;
            HideActionButtons();
            LoadData("TA");
            gridInv.Tag = "TA";
        }

        private void btnHistoryTrans_Click(object sender, EventArgs e)
        {
            editProduct.Visible = false;
            HideActionButtons();
            LoadData("TH");
            gridInv.Tag = "TH";
        }

        private void btnDeleteProd_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Deseja deletar o produto?", "Deletar", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Database db = new();

                var queryParams = new DeleteQueryParams
                {
                    TableName = "produto",
                    Where = new() { Column = "id_produto", Value = gridInv.SelectedCells[0].Value.ToString() ?? "" }
                };

                db.DeleteQuery(queryParams);
                LoadData("I");
            }
        }

        private void gridInv_SelectionChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(gridInv.Tag?.ToString()) && !gridInv.Tag.Equals("TH"))
            {
                ShowActionButtons(char.Parse(gridInv.Tag?.ToString()?[..1] ?? ""));
            }
        }

        private void btnUpdateInv_Click(object sender, EventArgs e)
        {
            int lastIndex = gridInv.SelectedCells.Count - 1;
            int currentAmount = Convert.ToInt32(gridInv.SelectedCells[lastIndex].Value);

            frmUpdateInventory frmQty = new(currentAmount);
            DialogResult result = frmQty.ShowDialog();

            int newQty = frmQty.productQty;

            if (result == DialogResult.OK)
            {
                Database db = new();

                var queryParams = new UpdateQueryParams
                {
                    TableName = "produto",
                    Columns = [new() { Name = "estoque_produto", Value = newQty.ToString() }],
                    Where = new() { Column = "id_produto", Value = gridInv.SelectedCells[0].Value.ToString() ?? "" }
                };

                db.UpdateQuery(queryParams);
            }

            LoadData("I");
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            LoadCategories();
            HideActionButtons();
            string? documentsPath = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.ToString();
            string folderPath = Path.Combine(documentsPath ?? "C://", "Products_Images");
            var orderedTextBoxes = editProduct.Controls.OfType<TextBox>().OrderBy(control => control.Top).ToList();
            string imgPath;
            int i = 0;

            foreach (Control txtBox in orderedTextBoxes)
            {
                if (i == 2)
                    i++;

                if (i == 3)
                    i++;

                txtBox.Text = gridInv.SelectedCells[i].Value.ToString();
                i++;
            }

            txtProdId.Text = txtProdId.Text.PadLeft(5, '0');
            cmbCateg.Text = gridInv.SelectedCells[2].Value.ToString();
            numValue.Value = Convert.ToDecimal(gridInv.SelectedCells[3].Value);
            imgPath = Path.Combine(folderPath, $"Product_{txtProdId.Text}.png");

            if (File.Exists(imgPath))
                imgProd.Image = Image.FromFile(imgPath);
            else
                imgProd.Image = imgProd.InitialImage;

            imgProd.Tag = imgPath;
            editProduct.Visible = true;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            Database db = new();

            var queryParams = new UpdateQueryParams
            {
                TableName = "transacao",
                Columns =
                [
                    new() { Name = "status_transacao", Value = "1" },
                    new() { Name = "transacao_valida", Value = "1" }
                ],
                Where = new() { Column = "id_transacao", Value = gridInv.SelectedCells[0].Value.ToString() ?? "" }
            };

            db.UpdateQuery(queryParams);

            gridInv.Tag = "TH";
            HideActionButtons();
            LoadData("TH");

        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            Database db = new();

            var queryParams = new UpdateQueryParams
            {
                TableName = "transacao",
                Columns =
                [
                    new() { Name = "status_transacao", Value = "1" },
                    new() { Name = "transacao_valida", Value = "0" }
                ],
                Where = new() { Column = "id_transacao", Value = gridInv.SelectedCells[0].Value.ToString() ?? "" }
            };

            db.UpdateQuery(queryParams);

            gridInv.Tag = "TH";
            HideActionButtons();
            LoadData("TH");
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            string? documentsPath = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.ToString();
            string folderPath = Path.Combine(documentsPath ?? "C://", "Products_Images");
            string savePath = Path.Combine(folderPath, $"Product_{txtProdId.Text}.png");
            Database db = new();

            var queryParams = new UpdateQueryParams
            {
                TableName = "produto",
                Columns =
                [
                    new() {Name = "nome_produto", Value = $"\"{txtProductName.Text}\""},
                    new() {Name = "categoria_produto", Value = $"\"{cmbCateg.Text}\""},
                    new() {Name = "valor_produto", Value = numValue.Value.ToString().Replace(',', '.')},
                    new() {Name = "descricao_produto", Value = $"\"{txtDesc.Text}\""}
                ],
                Where = new() { Column = "id_produto", Value = $"{int.Parse(txtProdId.Text)}" }
            };

            if (db.UpdateQuery(queryParams) > 0)
            {
                File.Copy(imgProd.Tag?.ToString() ?? $"{folderPath}\\no-image.png", savePath, true);
            }

            imgProd.Tag = null;
            editProduct.Visible = false;
        }

        private void imgProd_Click(object sender, EventArgs e)
        {
            if (imgProd.Image != null)
            {
                imgProd.Image.Dispose();
                imgProd.Image = null;
            }

            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                imgProd.Image = Image.FromFile(openFile.FileName);
                imgProd.Tag = Path.GetFullPath(openFile.FileName);
            }
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

        private void editProduct_VisibleChanged(object sender, EventArgs e)
        {
            if (!editProduct.Visible)
            {
                gridInv.ClearSelection();
            }
        }
    }
}
