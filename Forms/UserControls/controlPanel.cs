using System.Data;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Project.Forms;
using Project.Forms.Popups;
using Project.Services;
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

        private static async Task<DataTable?> InventoryData()
        {
            return await Task.Run(() =>
            {
                DatabaseQuery db = new();

                var queryParams = new SelectQueryParams
                {
                    TableName = "produto",

                    Columns =
                    [
                        new() { Name = "id_prod", Alias = "ID" },
                        new() { Name = "nome_prod", Alias = "Produto" },
                        new() { Name = "C.nome_categ", Alias = "Categoria" },
                        new() { Name = "valor_prod", Alias = "Valor" },
                        new() { Name = "descricao_prod", Alias = "Descrição" },
                        new() { Name = "estoque_prod", Alias = "Qtde" }
                    ],
                    InnerJoin = ["categoria_produto C ON categoria_prod = C.id_categ"],
                    OrderBy = "estoque_prod ASC"
                };

                return db.SelectQuery(queryParams) ?? null;
            });
        }

        private static async Task<DataTable?> EmployeeData()
        {
            return await Task.Run(() =>
            {
                DatabaseQuery db = new();

                var queryParams = new SelectQueryParams
                {
                    TableName = "funcionario",

                    Columns =
                    [
                        new() { Name = "id_func", Alias = "ID" },
                        new() { Name = "nome_func", Alias = "Nome" },
                        new() { Name = "C.nome_cargo", Alias = "Cargo" },
                        new() { Name = "email_func", Alias = "Email" },
                        new() { Name = "dt_admissao", Alias = "Admissão" }
                    ],
                    InnerJoin = ["cargo_func C ON cargo_func = C.id_cargo"],
                    OrderBy = "C.nome_cargo ASC"
                };

                return db.SelectQuery(queryParams) ?? null;
            });
        }

        private static async Task<DataTable?> TransactionData(char status)
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
                DatabaseQuery db = new();

                var queryParams = new SelectQueryParams
                {
                    TableName = "transacao T",

                    Columns =
                    [
                        new() { Name = "T.id_transacao", Alias = "ID"},
                        new() { Name = "T.transacao_valida"},
                        new() { Name = "C.id_cliente"},
                        new() { Name = "E.id_func"},
                        new() { Name = "C.nome_cliente", Alias = "Cliente" },
                        new() { Name = "T.dt_transacao", Alias = "Data" },
                        new() { Name = "T.valor_total", Alias = "Valor" },
                        new() { Name = "T.descricao_transacao", Alias = "Descrição" },
                        new() { Name = "P.nome_pagamento", Alias = "Pagamento" }
                    ],

                    InnerJoin =
                    [
                        "pagamento P ON T.tipo_pagamento_selecionado = P.tipo_pagamento"
                    ],

                    LeftJoin =
                    [
                        "cliente C ON T.id_cliente_selecionado = C.id_cliente",
                        "funcionario E ON T.id_func_selecionado = E.id_func"
                    ],

                    Where = $"status_transacao {transStatus} 0",
                    OrderBy = "transacao_valida DESC, dt_transacao DESC"
                };

                return db.SelectQuery(queryParams) ?? null;
            });
        }

        private async void LoadData(string data)
        {
            txtSearch.Text = "";
            TxtSearch_Leave("", EventArgs.Empty);
            pgbData.Visible = true;
            gridInv.Columns.Clear();
            gridInv.DataSource = "";

            switch (data)
            {
                case "I":
                    gridInv.DataSource = await InventoryData();
                    gridInv.DefaultCellStyle.BackColor = Color.White;
                    break;
                case "E":
                    gridInv.DataSource = await EmployeeData();
                    gridInv.DefaultCellStyle.BackColor = Color.White;
                    break;
                case "TA":
                    gridInv.DataSource = await TransactionData('A');
                    break;
                case "TH":
                    gridInv.DataSource = await TransactionData('H');
                    break;
            }

            gridInv.ClearSelection();

            if (!pgbData.IsDisposed)
                pgbData.Visible = false;
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {
            LoadData("I");
            gridInv.Tag = "I";
            txtSearch.Tag = "I";
        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            var pnlControls = Parent!.Parent!.Controls.Find("pnlControls", true).First();
            var btnReg = pnlControls!.Controls.Find("btnReg", true).First();

            if (btnReg != null && btnReg.Visible)
                btnEntries.DropDownItems.Add("Colaboradores", null, btnEmployee_Click!);

            HideActionButtons();
            LoadData("I");
            txtSearch.Tag = "I";
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
                        e.CellStyle.BackColor = Color.FromArgb(255, 160, 160);
                    else if (value > 5 && value <= 15)
                        e.CellStyle.BackColor = Color.FromArgb(255, 255, 192);
                    else
                        e.CellStyle.BackColor = Color.FromArgb(192, 255, 192);
                }
                return;
            }

            if (gridInv.Tag?.Equals("TA") ?? false)
            {
                gridInv.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
                return;
            }

            if (gridInv.Tag?.Equals("TH") ?? false)
            {
                foreach (DataGridViewRow row in gridInv.Rows)
                {
                    if (!(bool)row.Cells[1].Value)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 160, 160);
                        continue;
                    }
                    row.DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192);
                }
            }
        }

        private void TimerData_Tick(object sender, EventArgs e)
        {
            LoadData(gridInv.Tag?.ToString() ?? "I");
        }

        private void BtnActiveTrans_Click(object sender, EventArgs e)
        {
            LoadData("TA");
            gridInv.Tag = "TA";
        }

        private void BtnHistoryTrans_Click(object sender, EventArgs e)
        {
            LoadData("TH");
            gridInv.Tag = "TH";
        }

        private void BtnDeleteProd_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show($"Deseja realmente excluir o produto \"{gridInv.SelectedCells[1].Value}\" permanentemente?", "Excluir Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                DatabaseQuery db = new();

                var queryParams = new DeleteQueryParams
                {
                    TableName = "produto",
                    Where = new() { Column = "id_prod", Value = gridInv.SelectedCells[0].Value.ToString() ?? "" }
                };

                db.DeleteQuery(queryParams);
                LoadData("I");
            }
        }

        private void GridInv_SelectionChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(gridInv.Tag?.ToString()) && !gridInv.Tag.Equals("TH") && !gridInv.Tag.Equals("E"))
            {
                ShowActionButtons(char.Parse(gridInv.Tag.ToString()![..1]!));
            }
        }

        private void BtnUpdateInv_Click(object sender, EventArgs e)
        {
            int lastIndex = gridInv.SelectedCells.Count - 1;
            int currentAmount = Convert.ToInt32(gridInv.SelectedCells[lastIndex].Value);

            frmUpdateInventory frmQty = new(currentAmount);
            DialogResult result = frmQty.ShowDialog();

            int newQty = frmQty.productQty;

            if (result == DialogResult.OK)
            {
                DatabaseQuery db = new();

                var queryParams = new UpdateQueryParams
                {
                    TableName = "produto",
                    Columns = [new() { Name = "estoque_prod", Value = newQty.ToString() }],
                    Where = new() { Column = "id_prod", Value = gridInv.SelectedCells[0].Value.ToString() ?? "" }
                };

                db.UpdateQuery(queryParams);
            }

            LoadData("I");
        }

        private void BtnUpdateProduct_Click(object sender, EventArgs e)
        {
            LoadCategories();
            HideActionButtons();
            string? documentsPath = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.ToString();
            string folderPath = Path.Combine(documentsPath ?? "C://", "Images");
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
            cmbCateg.SelectedIndex = cmbCateg.FindStringExact(gridInv.SelectedCells[2].Value.ToString());
            numValue.Value = Convert.ToDecimal(gridInv.SelectedCells[3].Value);
            imgPath = Path.Combine(folderPath, $"{gridInv.SelectedCells[1].Value}.png");

            if (File.Exists(imgPath))
                imgProd.Image = Image.FromFile(imgPath);
            else
                imgProd.Image = imgProd.InitialImage;

            editProduct.BringToFront();
            editProduct.Visible = true;
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            DatabaseQuery db = new();
            string desc = gridInv.SelectedCells[7].Value.ToString() ?? "Error";
            var items = desc.Split(["|-|"], StringSplitOptions.TrimEntries);
            List<(string, int)> products = [];
            string message = "";

            foreach (var item in items)
            {
                var data = item.Split(["-"], StringSplitOptions.RemoveEmptyEntries);
                int itemId = Convert.ToInt32(GetText(data[0]));
                int itemQty = Convert.ToInt32(GetText(data[2]));
                var currentInv = HasInventory(itemId, itemQty);

                if (!Convert.ToBoolean(currentInv[0]))
                {
                    message += $"• {currentInv[2]} ({currentInv[3]}/{itemQty}) \n";
                    continue;
                }

                products.Add((currentInv[1], Convert.ToInt32(currentInv[3]) - itemQty));
            }

            if (!message.Equals(""))
            {
                MessageBox.Show($"Não foi possível validar a transação. Os seguintes itens não possuem quantidade suficiente em estoque:\n\n{message}", "Erro durante validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var item in products)
            {
                var queryParams = new UpdateQueryParams
                {
                    TableName = "produto",
                    Columns = [new() { Name = "estoque_prod", Value = $"{item.Item2}" }],
                    Where = new() { Column = "id_prod", Value = $"{item.Item1}" }
                };

                db.UpdateQuery(queryParams);
            }

            ValidateTransaction();
            gridInv.Tag = "TH";
            HideActionButtons();
            LoadData("TH");
        }

        private void BtnDeny_Click(object sender, EventArgs e)
        {
            DatabaseQuery db = new();

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

        private void BtnEditProduct_Click(object sender, EventArgs e)
        {
            var validFields = FieldValidation.ValidateControls(editProduct);
            var errorMessage = FieldValidation.SetMessage(validFields);

            if (validFields.Any(key => key.Key > 0))
            {
                MessageBox.Show($"Todos os campos devem ser preenchidos corretamente! \n\n{errorMessage}", "Erro no cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string? documentsPath = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.ToString();
            string folderPath = Path.Combine(documentsPath ?? "C://", "Images");
            string savePath = Path.Combine(folderPath, $"{gridInv.SelectedCells[1].Value}.png");
            DatabaseQuery db = new();

            var queryParams = new UpdateQueryParams
            {
                TableName = "produto",
                Columns =
                [
                    new() {Name = "nome_prod", Value = $"\"{txtProductName.Text}\""},
                    new() {Name = "categoria_prod", Value = $"\"{cmbCateg.SelectedValue}\""},
                    new() {Name = "valor_prod", Value = numValue.Value.ToString().Replace(',', '.')},
                    new() {Name = "descricao_prod", Value = $"\"{txtDesc.Text}\""}
                ],
                Where = new() { Column = "id_prod", Value = $"{int.Parse(txtProdId.Text)}" }
            };

            if (db.UpdateQuery(queryParams) > 0)
            {
                string? imgTag = imgProd.Tag?.ToString();

                if (imgTag != null)
                {
                    File.Copy(imgTag, savePath, true);
                    RegisterPanel.CopyImageToWebPageFolder(savePath);
                }

                imgProd.Image = null;
                imgProd.Tag = null;
            }

            editProduct.SendToBack();
            editProduct.Visible = false;
            LoadData("I");
        }

        private void ImgProd_Click(object sender, EventArgs e)
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

        private void NumValue_KeyPress(object sender, KeyPressEventArgs e)
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

        private void EditProduct_VisibleChanged(object sender, EventArgs e)
        {
            if (editProduct.Visible)
            {
                txtSearch.Visible = false;
                return;
            }

            txtSearch.Visible = true;
            gridInv.ClearSelection();
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text.Equals("Buscar registro..."))
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = "Buscar registro...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (gridInv.DataSource is DataView view)
            {
                gridInv.Columns.Clear();
                gridInv.DataSource = view.Table;
            }

            if (!string.IsNullOrEmpty(txtSearch.Text) && !txtSearch.Text.Equals("Buscar registro..."))
            {
                if (gridInv.DataSource is DataTable dataTable)
                {
                    DataView filteredData = new(dataTable);
                    string searchText = txtSearch.Text;

                    if (int.TryParse(searchText, out int searchValue))
                        filteredData.RowFilter = $"Id = {searchValue}";
                    else
                        filteredData.RowFilter = FilterSearch(searchText);

                    gridInv.Columns.Clear();
                    gridInv.DataSource = filteredData;
                }
            }

            gridInv.ClearSelection();
        }

        private string FilterSearch(string searchText)
        {
            searchText = searchText.Replace("'", "\\'");
            return txtSearch.Tag switch
            {
                "E" => $"Nome LIKE '%{searchText}%' OR Convert(Admissão, 'System.String') LIKE '%{searchText}%' OR Cargo LIKE '{searchText}%'",
                "I" => $"Produto LIKE '%{searchText}%' OR Categoria LIKE '{searchText}%'",
                "T" => $"Cliente LIKE '{searchText}%'",
                _ => "",
            };
        }

        private void GridInv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            string tag = gridInv.Tag!.ToString()![..1];

            gridInv.Columns[1].Visible = true;
            gridInv.Columns[2].Visible = true;
            gridInv.Columns[3].Visible = true;

            if (!tag.Equals("E"))
                gridInv.Columns[0].Visible = false;

            if (tag.Equals("T"))
            {
                gridInv.Columns[1].Visible = false;
                gridInv.Columns[2].Visible = false;
                gridInv.Columns[3].Visible = false;
            }
        }

        private void btnTransactions_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            pnlProduct.Focus();
            editProduct.Visible = false;
            HideActionButtons();
            txtSearch.Tag = "T";
            txtSearch.Text = "";
            TxtSearch_Leave(sender, e);
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            LoadData("E");
            txtSearch.Tag = "E";
            gridInv.Tag = "E";
        }

        private void btnEntries_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            pnlProduct.Focus();
            editProduct.Visible = false;
            HideActionButtons();
            txtSearch.Text = "";
            TxtSearch_Leave(sender, e);
        }

        private void gridInv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridInv.Tag!.Equals("TH"))
            {
                bool isValid = Convert.ToBoolean(gridInv.Rows[e.RowIndex].Cells[1].Value);

                var employee = gridInv.Rows[e.RowIndex].Cells[3].Value;
                int? employeeID = employee is DBNull ? null : Convert.ToInt32(employee);
                var customer = gridInv.Rows[e.RowIndex].Cells[2].Value;
                int? customerID = customer is DBNull ? null : Convert.ToInt32(customer);

                string? employeeData = GetEmployee(employeeID);
                List<string>? customerData = GetCustomer(customerID);

                string descText = gridInv.Rows[e.RowIndex].Cells["Descrição"].Value.ToString()!;
                decimal totalValue = Convert.ToDecimal(gridInv.Rows[e.RowIndex].Cells["Valor"].Value);
                string paymentMethod = gridInv.Rows[e.RowIndex].Cells["Pagamento"].Value.ToString()!;

                var items = descText.Split(["|-|"], StringSplitOptions.TrimEntries);
                List<Product> receiptContent = [];

                foreach (var item in items)
                {
                    var data = item.Split(["-"], StringSplitOptions.RemoveEmptyEntries);

                    Product product = new()
                    {
                        ID = GetText(data[0]),
                        Desc = GetText(data[1]),
                        Qty = Convert.ToInt32(GetText(data[2])),
                        ProductValue = GetProductValue(GetText(data[0]))
                    };

                    receiptContent.Add(product);
                }

                frmReceipt frmReceipt = new(receiptContent, totalValue, items.Length, paymentMethod, employeeData, customerData, isValid);
                frmReceipt.ShowDialog();
            }
        }

        decimal GetProductValue(string productID)
        {
            decimal value;

            DatabaseQuery db = new();

            var queryParams = new SelectQueryParams
            {
                TableName = "produto",
                Columns = [new() { Name = "valor_prod" }],
                Where = $"id_prod = {productID}"
            };

            var result = db.SelectQuery(queryParams);

            if (result != null && result.Rows.Count > 0)
                value = Convert.ToDecimal(result.Rows[0][0]);
            else
                value = 0;

            return value;
        }

        string GetText(string input)
        {
            return input[(input.IndexOf(':') + 1)..].Trim();
        }

        void ValidateTransaction()
        {
            DatabaseQuery db = new();

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
        }

        static List<string> HasInventory(int itemId, int itemQty)
        {
            DatabaseQuery db = new();

            var queryParams = new SelectQueryParams
            {
                TableName = "produto",
                Columns =
                [
                    new() { Name = "id_prod"},
                    new() { Name = $"IF(estoque_prod >= {itemQty}, TRUE, FALSE)"},
                    new() { Name = "estoque_prod" },
                    new() { Name = "nome_prod" }
                ],
                Where = $"id_prod = {itemId}"
            };

            var result = db.SelectQuery(queryParams);
            int id = Convert.ToInt32(result!.Rows[0][0]);
            int inventory = Convert.ToInt32(result!.Rows[0][2]);
            string product = result.Rows[0][3].ToString()!;

            if (result.Rows.Count > 0)
            {
                if (Convert.ToBoolean(result.Rows[0][1]))
                {
                    return ["true", $"{id}", $"{product}", $"{inventory}"];
                }
            }

            return ["false", $"{id}", $"{product}", $"{inventory}"];
        }

        static string? GetEmployee(int? id)
        {
            if (id != null)
            {
                DatabaseQuery db = new();

                var queryParams = new SelectQueryParams
                {
                    TableName = "funcionario",
                    Columns = [new() { Name = "nome_func" }],
                    Where = $"id_func = {id}",
                    OrderBy = "dt_admissao DESC"
                };

                var result = db.SelectQuery(queryParams);

                if (result != null && result.Rows.Count > 0)
                    return result.Rows[0][0].ToString()!;
            }

            return null;
        }

        static List<string>? GetCustomer(int? id)
        {
            if (id != null)
            {
                DatabaseQuery db = new();

                var queryParams = new SelectQueryParams
                {
                    TableName = "cliente",
                    Columns =
                    [
                        new() { Name = "nome_cliente" },
                        new() { Name = "cpf_cliente" }
                    ],
                    Where = $"id_cliente = {id}"
                };

                var result = db.SelectQuery(queryParams);

                if (result != null && result.Rows.Count > 0)
                    return [result.Rows[0][0].ToString(), result.Rows[0][1].ToString()];
            }

            return null;
        }

        private void numValue_Enter(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate {
                numValue.Select(0, numValue.Value.ToString().Length);
            });
        }
    }
}
