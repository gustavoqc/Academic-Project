namespace Project.Forms
{
    partial class RegisterPanel
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterPanel));
            pnlReg = new Panel();
            tspReg = new ToolStrip();
            btnEmployee = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnProducts = new ToolStripButton();
            pnlProduct = new Panel();
            txtLinkUrl = new TextBox();
            label9 = new Label();
            numValue = new NumericUpDown();
            label7 = new Label();
            txtDesc = new TextBox();
            imgProd = new PictureBox();
            label8 = new Label();
            numQty = new NumericUpDown();
            btnAddCateg = new Button();
            btnRegisterP = new Button();
            label10 = new Label();
            cmbCateg = new ComboBox();
            label11 = new Label();
            txtProductName = new TextBox();
            label12 = new Label();
            txtProdId = new TextBox();
            pnlEmployee = new Panel();
            btnAddPos = new Button();
            btnCopy = new Button();
            txtTempPsw = new TextBox();
            btnRegister = new Button();
            label6 = new Label();
            label5 = new Label();
            dtAdDate = new DateTimePicker();
            txtId = new TextBox();
            label4 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            cmbPos = new ComboBox();
            label2 = new Label();
            txtName = new TextBox();
            label1 = new Label();
            tooltip = new ToolTip(components);
            openFile = new OpenFileDialog();
            pnlReg.SuspendLayout();
            tspReg.SuspendLayout();
            pnlProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgProd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            pnlEmployee.SuspendLayout();
            SuspendLayout();
            // 
            // pnlReg
            // 
            pnlReg.BackColor = Color.FromArgb(224, 224, 224);
            pnlReg.Controls.Add(tspReg);
            pnlReg.Controls.Add(pnlProduct);
            pnlReg.Controls.Add(pnlEmployee);
            pnlReg.Dock = DockStyle.Fill;
            pnlReg.Location = new Point(0, 0);
            pnlReg.Margin = new Padding(4);
            pnlReg.Name = "pnlReg";
            pnlReg.Size = new Size(662, 324);
            pnlReg.TabIndex = 1;
            // 
            // tspReg
            // 
            tspReg.BackColor = Color.Transparent;
            tspReg.Font = new Font("Arial", 10F);
            tspReg.GripStyle = ToolStripGripStyle.Hidden;
            tspReg.Items.AddRange(new ToolStripItem[] { btnEmployee, toolStripSeparator1, btnProducts });
            tspReg.Location = new Point(0, 0);
            tspReg.Name = "tspReg";
            tspReg.Size = new Size(662, 35);
            tspReg.TabIndex = 0;
            // 
            // btnEmployee
            // 
            btnEmployee.AutoSize = false;
            btnEmployee.BackColor = Color.Transparent;
            btnEmployee.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnEmployee.Font = new Font("Arial", 11F);
            btnEmployee.Image = (Image)resources.GetObject("btnEmployee.Image");
            btnEmployee.ImageTransparentColor = Color.Magenta;
            btnEmployee.Margin = new Padding(10, 5, 0, 5);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Padding = new Padding(1);
            btnEmployee.Size = new Size(135, 25);
            btnEmployee.Text = "Novo Funcionário";
            btnEmployee.Click += BtnEmployee_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.AutoSize = false;
            toolStripSeparator1.BackColor = Color.Black;
            toolStripSeparator1.ForeColor = Color.Black;
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(25, 30);
            // 
            // btnProducts
            // 
            btnProducts.AutoSize = false;
            btnProducts.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnProducts.Font = new Font("Arial", 11F);
            btnProducts.Image = (Image)resources.GetObject("btnProducts.Image");
            btnProducts.ImageTransparentColor = Color.Magenta;
            btnProducts.Margin = new Padding(0, 5, 5, 5);
            btnProducts.Name = "btnProducts";
            btnProducts.Padding = new Padding(1);
            btnProducts.Size = new Size(135, 25);
            btnProducts.Text = "Novo Produto";
            btnProducts.Click += btnProducts_Click;
            // 
            // pnlProduct
            // 
            pnlProduct.Controls.Add(txtLinkUrl);
            pnlProduct.Controls.Add(label9);
            pnlProduct.Controls.Add(numValue);
            pnlProduct.Controls.Add(label7);
            pnlProduct.Controls.Add(txtDesc);
            pnlProduct.Controls.Add(imgProd);
            pnlProduct.Controls.Add(label8);
            pnlProduct.Controls.Add(numQty);
            pnlProduct.Controls.Add(btnAddCateg);
            pnlProduct.Controls.Add(btnRegisterP);
            pnlProduct.Controls.Add(label10);
            pnlProduct.Controls.Add(cmbCateg);
            pnlProduct.Controls.Add(label11);
            pnlProduct.Controls.Add(txtProductName);
            pnlProduct.Controls.Add(label12);
            pnlProduct.Controls.Add(txtProdId);
            pnlProduct.Location = new Point(-1, 38);
            pnlProduct.Margin = new Padding(4);
            pnlProduct.Name = "pnlProduct";
            pnlProduct.Size = new Size(663, 283);
            pnlProduct.TabIndex = 12;
            pnlProduct.Tag = "";
            // 
            // txtLinkUrl
            // 
            txtLinkUrl.BackColor = Color.WhiteSmoke;
            txtLinkUrl.BorderStyle = BorderStyle.FixedSingle;
            txtLinkUrl.Location = new Point(84, 58);
            txtLinkUrl.Margin = new Padding(4);
            txtLinkUrl.Name = "txtLinkUrl";
            txtLinkUrl.Size = new Size(176, 26);
            txtLinkUrl.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(35, 63);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(39, 18);
            label9.TabIndex = 20;
            label9.Text = "URL";
            // 
            // numValue
            // 
            numValue.DecimalPlaces = 2;
            numValue.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numValue.Location = new Point(84, 102);
            numValue.Maximum = new decimal(new int[] { 99999, 0, 0, 131072 });
            numValue.Name = "numValue";
            numValue.Size = new Size(120, 26);
            numValue.TabIndex = 3;
            numValue.TextAlign = HorizontalAlignment.Center;
            numValue.ThousandsSeparator = true;
            numValue.Enter += numValue_Enter;
            numValue.KeyPress += numValue_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 216);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(49, 18);
            label7.TabIndex = 18;
            label7.Text = "Desc.";
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(84, 189);
            txtDesc.Margin = new Padding(4);
            txtDesc.MaximumSize = new Size(256, 75);
            txtDesc.MinimumSize = new Size(256, 75);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.ScrollBars = ScrollBars.Vertical;
            txtDesc.Size = new Size(256, 75);
            txtDesc.TabIndex = 6;
            // 
            // imgProd
            // 
            imgProd.BorderStyle = BorderStyle.FixedSingle;
            imgProd.Image = Properties.Resources.images;
            imgProd.InitialImage = Properties.Resources.images;
            imgProd.Location = new Point(449, 13);
            imgProd.Margin = new Padding(4);
            imgProd.Name = "imgProd";
            imgProd.Size = new Size(176, 157);
            imgProd.SizeMode = PictureBoxSizeMode.StretchImage;
            imgProd.TabIndex = 16;
            imgProd.TabStop = false;
            imgProd.Click += imgProd_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(219, 105);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(42, 18);
            label8.TabIndex = 15;
            label8.Text = "Qtde";
            // 
            // numQty
            // 
            numQty.BorderStyle = BorderStyle.FixedSingle;
            numQty.Location = new Point(269, 102);
            numQty.Margin = new Padding(4);
            numQty.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numQty.Name = "numQty";
            numQty.Size = new Size(71, 26);
            numQty.TabIndex = 4;
            numQty.TextAlign = HorizontalAlignment.Center;
            numQty.Enter += numQty_Enter;
            // 
            // btnAddCateg
            // 
            btnAddCateg.BackgroundImage = Properties.Resources.plus;
            btnAddCateg.BackgroundImageLayout = ImageLayout.Stretch;
            btnAddCateg.FlatAppearance.BorderSize = 0;
            btnAddCateg.FlatStyle = FlatStyle.Flat;
            btnAddCateg.ForeColor = SystemColors.ControlText;
            btnAddCateg.Location = new Point(235, 151);
            btnAddCateg.Margin = new Padding(4);
            btnAddCateg.Name = "btnAddCateg";
            btnAddCateg.Size = new Size(15, 15);
            btnAddCateg.TabIndex = 7;
            btnAddCateg.Tag = "C";
            tooltip.SetToolTip(btnAddCateg, "Adicionar nova categoria");
            btnAddCateg.UseVisualStyleBackColor = true;
            btnAddCateg.Click += btnAddItem_Click;
            // 
            // btnRegisterP
            // 
            btnRegisterP.AutoSize = true;
            btnRegisterP.BackColor = Color.LightGray;
            btnRegisterP.FlatAppearance.BorderColor = Color.Black;
            btnRegisterP.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            btnRegisterP.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            btnRegisterP.FlatStyle = FlatStyle.Flat;
            btnRegisterP.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnRegisterP.ForeColor = Color.Black;
            btnRegisterP.Location = new Point(459, 204);
            btnRegisterP.Margin = new Padding(6, 6, 0, 6);
            btnRegisterP.Name = "btnRegisterP";
            btnRegisterP.Size = new Size(161, 42);
            btnRegisterP.TabIndex = 7;
            btnRegisterP.Tag = "P";
            btnRegisterP.Text = "Cadastrar";
            btnRegisterP.UseVisualStyleBackColor = false;
            btnRegisterP.Click += btnRegister_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(32, 105);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(44, 18);
            label10.TabIndex = 4;
            label10.Text = "Valor";
            // 
            // cmbCateg
            // 
            cmbCateg.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCateg.FlatStyle = FlatStyle.Flat;
            cmbCateg.FormattingEnabled = true;
            cmbCateg.Location = new Point(84, 146);
            cmbCateg.Margin = new Padding(4);
            cmbCateg.Name = "cmbCateg";
            cmbCateg.RightToLeft = RightToLeft.No;
            cmbCateg.Size = new Size(143, 26);
            cmbCateg.TabIndex = 5;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(26, 149);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(55, 18);
            label11.TabIndex = 2;
            label11.Text = "Categ.";
            // 
            // txtProductName
            // 
            txtProductName.BackColor = Color.WhiteSmoke;
            txtProductName.BorderStyle = BorderStyle.FixedSingle;
            txtProductName.Location = new Point(84, 17);
            txtProductName.Margin = new Padding(4);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(302, 26);
            txtProductName.TabIndex = 1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(27, 19);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(50, 18);
            label12.TabIndex = 0;
            label12.Text = "Nome";
            // 
            // txtProdId
            // 
            txtProdId.Enabled = false;
            txtProdId.Location = new Point(545, 212);
            txtProdId.Name = "txtProdId";
            txtProdId.Size = new Size(25, 26);
            txtProdId.TabIndex = 19;
            txtProdId.Visible = false;
            // 
            // pnlEmployee
            // 
            pnlEmployee.Controls.Add(btnAddPos);
            pnlEmployee.Controls.Add(btnCopy);
            pnlEmployee.Controls.Add(txtTempPsw);
            pnlEmployee.Controls.Add(btnRegister);
            pnlEmployee.Controls.Add(label6);
            pnlEmployee.Controls.Add(label5);
            pnlEmployee.Controls.Add(dtAdDate);
            pnlEmployee.Controls.Add(txtId);
            pnlEmployee.Controls.Add(label4);
            pnlEmployee.Controls.Add(txtEmail);
            pnlEmployee.Controls.Add(label3);
            pnlEmployee.Controls.Add(cmbPos);
            pnlEmployee.Controls.Add(label2);
            pnlEmployee.Controls.Add(txtName);
            pnlEmployee.Controls.Add(label1);
            pnlEmployee.Location = new Point(-1, 38);
            pnlEmployee.Margin = new Padding(4);
            pnlEmployee.Name = "pnlEmployee";
            pnlEmployee.Size = new Size(663, 283);
            pnlEmployee.TabIndex = 1;
            // 
            // btnAddPos
            // 
            btnAddPos.BackgroundImage = Properties.Resources.plus;
            btnAddPos.BackgroundImageLayout = ImageLayout.Stretch;
            btnAddPos.FlatAppearance.BorderSize = 0;
            btnAddPos.FlatStyle = FlatStyle.Flat;
            btnAddPos.ForeColor = SystemColors.ControlText;
            btnAddPos.Location = new Point(605, 107);
            btnAddPos.Margin = new Padding(4);
            btnAddPos.Name = "btnAddPos";
            btnAddPos.Size = new Size(15, 15);
            btnAddPos.TabIndex = 13;
            btnAddPos.Tag = "P";
            tooltip.SetToolTip(btnAddPos, "Adicionar nova categoria");
            btnAddPos.UseVisualStyleBackColor = true;
            btnAddPos.Click += btnAddItem_Click;
            // 
            // btnCopy
            // 
            btnCopy.BackColor = Color.Transparent;
            btnCopy.BackgroundImage = Properties.Resources.copy;
            btnCopy.BackgroundImageLayout = ImageLayout.Stretch;
            btnCopy.FlatAppearance.BorderSize = 0;
            btnCopy.FlatStyle = FlatStyle.Flat;
            btnCopy.Location = new Point(292, 173);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(23, 23);
            btnCopy.TabIndex = 12;
            tooltip.SetToolTip(btnCopy, "Copiar para a Área de Transferência");
            btnCopy.UseVisualStyleBackColor = false;
            btnCopy.Click += btnCopy_Click;
            // 
            // txtTempPsw
            // 
            txtTempPsw.BackColor = Color.Gainsboro;
            txtTempPsw.BorderStyle = BorderStyle.FixedSingle;
            txtTempPsw.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTempPsw.ForeColor = Color.Gray;
            txtTempPsw.Location = new Point(109, 172);
            txtTempPsw.Margin = new Padding(4);
            txtTempPsw.Name = "txtTempPsw";
            txtTempPsw.ReadOnly = true;
            txtTempPsw.Size = new Size(176, 26);
            txtTempPsw.TabIndex = 11;
            txtTempPsw.TextAlign = HorizontalAlignment.Center;
            // 
            // btnRegister
            // 
            btnRegister.AutoSize = true;
            btnRegister.BackColor = Color.LightGray;
            btnRegister.FlatAppearance.BorderColor = Color.Black;
            btnRegister.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            btnRegister.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnRegister.ForeColor = Color.Black;
            btnRegister.Location = new Point(437, 193);
            btnRegister.Margin = new Padding(6, 6, 0, 6);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(161, 42);
            btnRegister.TabIndex = 5;
            btnRegister.Tag = "E";
            btnRegister.Text = "Cadastrar";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 167);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.MaximumSize = new Size(129, 0);
            label6.Name = "label6";
            label6.Size = new Size(87, 36);
            label6.TabIndex = 10;
            label6.Text = "Senha Temporária";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(406, 37);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.MaximumSize = new Size(100, 0);
            label5.Name = "label5";
            label5.Size = new Size(79, 36);
            label5.TabIndex = 9;
            label5.Text = "Data de Admissão";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dtAdDate
            // 
            dtAdDate.CustomFormat = "";
            dtAdDate.Format = DateTimePickerFormat.Short;
            dtAdDate.Location = new Point(493, 40);
            dtAdDate.Margin = new Padding(4);
            dtAdDate.Name = "dtAdDate";
            dtAdDate.RightToLeft = RightToLeft.No;
            dtAdDate.Size = new Size(105, 26);
            dtAdDate.TabIndex = 3;
            dtAdDate.Value = new DateTime(2024, 9, 29, 0, 0, 0, 0);
            // 
            // txtId
            // 
            txtId.BackColor = Color.WhiteSmoke;
            txtId.BorderStyle = BorderStyle.FixedSingle;
            txtId.Location = new Point(109, 24);
            txtId.Margin = new Padding(4);
            txtId.MaxLength = 11;
            txtId.Name = "txtId";
            txtId.Size = new Size(176, 26);
            txtId.TabIndex = 0;
            txtId.KeyPress += txtId_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 26);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(41, 18);
            label4.TabIndex = 6;
            label4.Text = "CPF";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.WhiteSmoke;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(109, 121);
            txtEmail.Margin = new Padding(4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(256, 26);
            txtEmail.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 123);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(53, 18);
            label3.TabIndex = 4;
            label3.Text = "E-mail";
            // 
            // cmbPos
            // 
            cmbPos.BackColor = Color.White;
            cmbPos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPos.FlatStyle = FlatStyle.Flat;
            cmbPos.FormattingEnabled = true;
            cmbPos.Location = new Point(493, 101);
            cmbPos.Margin = new Padding(4);
            cmbPos.Name = "cmbPos";
            cmbPos.Size = new Size(105, 26);
            cmbPos.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(433, 104);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(52, 18);
            label2.TabIndex = 2;
            label2.Text = "Cargo";
            // 
            // txtName
            // 
            txtName.BackColor = Color.WhiteSmoke;
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Location = new Point(109, 71);
            txtName.Margin = new Padding(4);
            txtName.Name = "txtName";
            txtName.Size = new Size(256, 26);
            txtName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 73);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(50, 18);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // RegisterPanel
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pnlReg);
            Font = new Font("Arial", 12F);
            Margin = new Padding(4);
            Name = "RegisterPanel";
            Size = new Size(662, 324);
            Load += userRegister_Load;
            pnlReg.ResumeLayout(false);
            pnlReg.PerformLayout();
            tspReg.ResumeLayout(false);
            tspReg.PerformLayout();
            pnlProduct.ResumeLayout(false);
            pnlProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgProd).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            pnlEmployee.ResumeLayout(false);
            pnlEmployee.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlReg;
        private ToolStrip tspReg;
        private ToolStripButton btnEmployee;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnProducts;
        private Panel pnlEmployee;
        private TextBox txtTempPsw;
        private Button btnRegister;
        private Label label6;
        private Label label5;
        private DateTimePicker dtAdDate;
        private TextBox txtId;
        private Label label4;
        private TextBox txtEmail;
        private Label label3;
        private ComboBox cmbPos;
        private Label label2;
        private TextBox txtName;
        private Label label1;
        private Panel pnlProduct;
        private Label label7;
        private TextBox txtDesc;
        private PictureBox imgProd;
        private Label label8;
        private NumericUpDown numQty;
        private Button btnAddCateg;
        private Button btnRegisterP;
        private Label label10;
        private ComboBox cmbCateg;
        private Label label11;
        private TextBox txtProductName;
        private Label label12;
        private ToolTip tooltip;
        private Button btnCopy;
        private TextBox txtProdId;
        private OpenFileDialog openFile;
        private NumericUpDown numValue;
        private Button btnAddPos;
        private TextBox txtLinkUrl;
        private Label label9;
    }
}
