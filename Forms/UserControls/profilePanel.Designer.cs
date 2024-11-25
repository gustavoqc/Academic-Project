namespace Project.Forms.UserControls
{
    partial class profilePanel
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
            pnlProfile = new Panel();
            label8 = new Label();
            txtConfirmPsw = new TextBox();
            txtCPF = new MaskedTextBox();
            label1 = new Label();
            txtAdmDt = new TextBox();
            label5 = new Label();
            txtId = new TextBox();
            btnUpdateProfile = new Button();
            label7 = new Label();
            txtPsw = new TextBox();
            label6 = new Label();
            txtPos = new TextBox();
            label4 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            pnlProfile.SuspendLayout();
            SuspendLayout();
            // 
            // pnlProfile
            // 
            pnlProfile.Controls.Add(label8);
            pnlProfile.Controls.Add(txtConfirmPsw);
            pnlProfile.Controls.Add(txtCPF);
            pnlProfile.Controls.Add(label1);
            pnlProfile.Controls.Add(txtAdmDt);
            pnlProfile.Controls.Add(label5);
            pnlProfile.Controls.Add(txtId);
            pnlProfile.Controls.Add(btnUpdateProfile);
            pnlProfile.Controls.Add(label7);
            pnlProfile.Controls.Add(txtPsw);
            pnlProfile.Controls.Add(label6);
            pnlProfile.Controls.Add(txtPos);
            pnlProfile.Controls.Add(label4);
            pnlProfile.Controls.Add(txtEmail);
            pnlProfile.Controls.Add(label3);
            pnlProfile.Controls.Add(txtName);
            pnlProfile.Controls.Add(label2);
            pnlProfile.Dock = DockStyle.Fill;
            pnlProfile.Location = new Point(0, 0);
            pnlProfile.Name = "pnlProfile";
            pnlProfile.Size = new Size(662, 324);
            pnlProfile.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 222);
            label8.MaximumSize = new Size(100, 0);
            label8.Name = "label8";
            label8.Size = new Size(98, 36);
            label8.TabIndex = 20;
            label8.Text = "Confirmação de Senha";
            label8.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtConfirmPsw
            // 
            txtConfirmPsw.Enabled = false;
            txtConfirmPsw.Location = new Point(116, 227);
            txtConfirmPsw.Name = "txtConfirmPsw";
            txtConfirmPsw.Size = new Size(233, 26);
            txtConfirmPsw.TabIndex = 3;
            txtConfirmPsw.UseSystemPasswordChar = true;
            txtConfirmPsw.EnabledChanged += txtConfirmPsw_EnabledChanged;
            // 
            // txtCPF
            // 
            txtCPF.Enabled = false;
            txtCPF.Location = new Point(116, 31);
            txtCPF.Name = "txtCPF";
            txtCPF.Size = new Size(166, 26);
            txtCPF.TabIndex = 18;
            txtCPF.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(408, 75);
            label1.MaximumSize = new Size(80, 0);
            label1.Name = "label1";
            label1.Size = new Size(79, 36);
            label1.TabIndex = 17;
            label1.Text = "Dt. Admissão";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtAdmDt
            // 
            txtAdmDt.Enabled = false;
            txtAdmDt.Location = new Point(504, 78);
            txtAdmDt.Name = "txtAdmDt";
            txtAdmDt.Size = new Size(116, 26);
            txtAdmDt.TabIndex = 16;
            txtAdmDt.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(432, 33);
            label5.Name = "label5";
            label5.Size = new Size(23, 18);
            label5.TabIndex = 15;
            label5.Text = "ID";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(504, 30);
            txtId.Name = "txtId";
            txtId.Size = new Size(116, 26);
            txtId.TabIndex = 14;
            txtId.TextAlign = HorizontalAlignment.Center;
            // 
            // btnUpdateProfile
            // 
            btnUpdateProfile.AutoSize = true;
            btnUpdateProfile.BackColor = Color.LightGray;
            btnUpdateProfile.FlatAppearance.BorderColor = Color.Black;
            btnUpdateProfile.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            btnUpdateProfile.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            btnUpdateProfile.FlatStyle = FlatStyle.Flat;
            btnUpdateProfile.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnUpdateProfile.ForeColor = Color.Black;
            btnUpdateProfile.Location = new Point(459, 225);
            btnUpdateProfile.Margin = new Padding(6, 6, 0, 6);
            btnUpdateProfile.Name = "btnUpdateProfile";
            btnUpdateProfile.Size = new Size(161, 42);
            btnUpdateProfile.TabIndex = 4;
            btnUpdateProfile.Tag = "";
            btnUpdateProfile.Text = "Atualizar Cadastro";
            btnUpdateProfile.UseVisualStyleBackColor = false;
            btnUpdateProfile.Click += btnUpdateProfile_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 180);
            label7.Name = "label7";
            label7.Size = new Size(53, 18);
            label7.TabIndex = 13;
            label7.Text = "Senha";
            // 
            // txtPsw
            // 
            txtPsw.Location = new Point(116, 177);
            txtPsw.Name = "txtPsw";
            txtPsw.Size = new Size(233, 26);
            txtPsw.TabIndex = 2;
            txtPsw.UseSystemPasswordChar = true;
            txtPsw.TextChanged += txtPsw_TextChanged;
            txtPsw.Enter += txtPsw_Enter;
            txtPsw.Leave += txtPsw_Leave;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(422, 136);
            label6.Name = "label6";
            label6.Size = new Size(52, 18);
            label6.TabIndex = 11;
            label6.Text = "Cargo";
            // 
            // txtPos
            // 
            txtPos.Enabled = false;
            txtPos.Location = new Point(504, 133);
            txtPos.Name = "txtPos";
            txtPos.Size = new Size(116, 26);
            txtPos.TabIndex = 10;
            txtPos.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 131);
            label4.Name = "label4";
            label4.Size = new Size(53, 18);
            label4.TabIndex = 7;
            label4.Text = "E-mail";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(116, 128);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(233, 26);
            txtEmail.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 81);
            label3.Name = "label3";
            label3.Size = new Size(50, 18);
            label3.TabIndex = 5;
            label3.Text = "Nome";
            // 
            // txtName
            // 
            txtName.Enabled = false;
            txtName.Location = new Point(116, 78);
            txtName.Name = "txtName";
            txtName.Size = new Size(233, 26);
            txtName.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 34);
            label2.Name = "label2";
            label2.Size = new Size(41, 18);
            label2.TabIndex = 3;
            label2.Text = "CPF";
            // 
            // profilePanel
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            Controls.Add(pnlProfile);
            Font = new Font("Arial", 12F);
            Margin = new Padding(4);
            Name = "profilePanel";
            Size = new Size(662, 324);
            Load += profilePanel_Load;
            pnlProfile.ResumeLayout(false);
            pnlProfile.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlProfile;
        private Label label6;
        private TextBox txtPos;
        private Label label4;
        private TextBox txtEmail;
        private Label label3;
        private TextBox txtName;
        private Label label2;
        private Label label7;
        private TextBox txtPsw;
        private Button btnUpdateProfile;
        private Label label1;
        private TextBox txtAdmDt;
        private Label label5;
        private TextBox txtId;
        private MaskedTextBox txtCPF;
        private Label label8;
        private TextBox txtConfirmPsw;
    }
}
