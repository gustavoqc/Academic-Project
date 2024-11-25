namespace Project
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            txtId = new TextBox();
            btnLogin = new Button();
            label2 = new Label();
            label1 = new Label();
            txtPsw = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtId);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtPsw);
            panel1.Location = new Point(40, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(282, 250);
            panel1.TabIndex = 0;
            // 
            // txtId
            // 
            txtId.BackColor = Color.FromArgb(224, 224, 224);
            txtId.BorderStyle = BorderStyle.FixedSingle;
            txtId.Font = new Font("Arial", 14F);
            txtId.Location = new Point(58, 42);
            txtId.MaxLength = 11;
            txtId.MinimumSize = new Size(0, 25);
            txtId.Name = "txtId";
            txtId.Size = new Size(164, 29);
            txtId.TabIndex = 0;
            txtId.TextAlign = HorizontalAlignment.Center;
            txtId.WordWrap = false;
            txtId.KeyPress += TxtId_KeyPress;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.GrayText;
            btnLogin.FlatAppearance.BorderColor = Color.Black;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(58, 171);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(164, 35);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(113, 94);
            label2.Name = "label2";
            label2.Size = new Size(53, 18);
            label2.TabIndex = 4;
            label2.Text = "Senha";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(118, 21);
            label1.Name = "label1";
            label1.Size = new Size(41, 18);
            label1.TabIndex = 3;
            label1.Text = "CPF";
            // 
            // txtPsw
            // 
            txtPsw.BackColor = Color.FromArgb(224, 224, 224);
            txtPsw.BorderStyle = BorderStyle.FixedSingle;
            txtPsw.Font = new Font("Arial", 14F);
            txtPsw.Location = new Point(58, 115);
            txtPsw.MinimumSize = new Size(0, 25);
            txtPsw.Name = "txtPsw";
            txtPsw.PasswordChar = '*';
            txtPsw.Size = new Size(164, 29);
            txtPsw.TabIndex = 1;
            txtPsw.TextAlign = HorizontalAlignment.Center;
            txtPsw.UseSystemPasswordChar = true;
            txtPsw.WordWrap = false;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(359, 323);
            Controls.Add(panel1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtPsw;
        private Label label2;
        private Label label1;
        private Button btnLogin;
        private TextBox txtId;
    }
}
