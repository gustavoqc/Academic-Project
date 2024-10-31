namespace Project.Forms
{
    partial class frmNewItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAddItem = new Button();
            lblText = new Label();
            txtNewItem = new TextBox();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // btnAddItem
            // 
            btnAddItem.AutoSize = true;
            btnAddItem.BackColor = Color.Silver;
            btnAddItem.DialogResult = DialogResult.OK;
            btnAddItem.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnAddItem.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            btnAddItem.FlatStyle = FlatStyle.Flat;
            btnAddItem.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            btnAddItem.Location = new Point(28, 105);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(104, 30);
            btnAddItem.TabIndex = 2;
            btnAddItem.Text = "Salvar";
            btnAddItem.UseVisualStyleBackColor = false;
            btnAddItem.Click += btnAddCategory_Click;
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblText.Location = new Point(39, 22);
            lblText.Name = "lblText";
            lblText.Size = new Size(202, 22);
            lblText.TabIndex = 1;
            lblText.Text = "Digite a nova categoria";
            // 
            // txtNewItem
            // 
            txtNewItem.Location = new Point(28, 60);
            txtNewItem.Name = "txtNewItem";
            txtNewItem.Size = new Size(225, 26);
            txtNewItem.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.BackColor = Color.Silver;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            btnCancel.Location = new Point(149, 105);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(104, 30);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // frmNewItem
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(286, 163);
            Controls.Add(btnCancel);
            Controls.Add(txtNewItem);
            Controls.Add(lblText);
            Controls.Add(btnAddItem);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "frmNewItem";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nova Categoria";
            Load += frmNewItem_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddItem;
        private Label lblText;
        private TextBox txtNewItem;
        private Button btnCancel;
    }
}