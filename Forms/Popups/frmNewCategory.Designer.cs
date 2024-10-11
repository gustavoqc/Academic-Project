namespace Project.Forms
{
    partial class frmNewCategory
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
            btnAddCategory = new Button();
            label1 = new Label();
            txtCategory = new TextBox();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // btnAddCategory
            // 
            btnAddCategory.AutoSize = true;
            btnAddCategory.BackColor = Color.Silver;
            btnAddCategory.DialogResult = DialogResult.OK;
            btnAddCategory.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnAddCategory.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            btnAddCategory.FlatStyle = FlatStyle.Flat;
            btnAddCategory.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            btnAddCategory.Location = new Point(28, 105);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(104, 30);
            btnAddCategory.TabIndex = 1;
            btnAddCategory.Text = "Salvar";
            btnAddCategory.UseVisualStyleBackColor = false;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(39, 22);
            label1.Name = "label1";
            label1.Size = new Size(202, 22);
            label1.TabIndex = 1;
            label1.Text = "Digite a nova categoria";
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(28, 60);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(225, 26);
            txtCategory.TabIndex = 2;
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
            // frmNewCategory
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(286, 163);
            Controls.Add(btnCancel);
            Controls.Add(txtCategory);
            Controls.Add(label1);
            Controls.Add(btnAddCategory);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "frmNewCategory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nova Categoria";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddCategory;
        private Label label1;
        private TextBox txtCategory;
        private Button btnCancel;
    }
}