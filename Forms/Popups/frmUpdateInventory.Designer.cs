namespace Project.Forms
{
    partial class frmUpdateInventory
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
            label1 = new Label();
            btnUpdate = new Button();
            numNewValue = new NumericUpDown();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numNewValue).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14F);
            label1.Location = new Point(6, 9);
            label1.Name = "label1";
            label1.Size = new Size(202, 22);
            label1.TabIndex = 0;
            label1.Text = "Selecione o novo valor";
            // 
            // btnUpdate
            // 
            btnUpdate.AutoSize = true;
            btnUpdate.DialogResult = DialogResult.OK;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(21, 93);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 30);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Salvar";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // numNewValue
            // 
            numNewValue.Font = new Font("Arial", 12F);
            numNewValue.Location = new Point(76, 49);
            numNewValue.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numNewValue.Name = "numNewValue";
            numNewValue.Size = new Size(60, 26);
            numNewValue.TabIndex = 1;
            numNewValue.TextAlign = HorizontalAlignment.Center;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(115, 93);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(83, 30);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmUpdateInventory
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(220, 140);
            Controls.Add(btnCancel);
            Controls.Add(numNewValue);
            Controls.Add(btnUpdate);
            Controls.Add(label1);
            Font = new Font("Arial", 12F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "frmUpdateInventory";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Atualizar Estoque";
            Load += frmUpdateInventory_Load;
            ((System.ComponentModel.ISupportInitialize)numNewValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnUpdate;
        private NumericUpDown numNewValue;
        private Button btnCancel;
    }
}