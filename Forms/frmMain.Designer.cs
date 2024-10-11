namespace Project.Forms
{
    partial class frmMain
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
            components = new System.ComponentModel.Container();
            btnReg = new Button();
            pnlControls = new FlowLayoutPanel();
            btnControl = new Button();
            tooltip = new ToolTip(components);
            pnlMain = new Panel();
            pnlControls.SuspendLayout();
            SuspendLayout();
            // 
            // btnReg
            // 
            btnReg.AutoSize = true;
            btnReg.BackColor = Color.LightGray;
            btnReg.Enabled = false;
            btnReg.FlatAppearance.BorderColor = Color.Black;
            btnReg.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            btnReg.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            btnReg.FlatStyle = FlatStyle.Flat;
            btnReg.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnReg.ForeColor = Color.Black;
            btnReg.Location = new Point(115, 5);
            btnReg.Margin = new Padding(5, 5, 0, 5);
            btnReg.Name = "btnReg";
            btnReg.Size = new Size(114, 31);
            btnReg.TabIndex = 1;
            btnReg.Text = "C&adastro";
            btnReg.UseVisualStyleBackColor = false;
            btnReg.Visible = false;
            btnReg.Click += btnReg_Click;
            // 
            // pnlControls
            // 
            pnlControls.AutoSize = true;
            pnlControls.BackColor = Color.Transparent;
            pnlControls.Controls.Add(btnControl);
            pnlControls.Controls.Add(btnReg);
            pnlControls.Dock = DockStyle.Top;
            pnlControls.Location = new Point(0, 0);
            pnlControls.Name = "pnlControls";
            pnlControls.Padding = new Padding(5, 0, 0, 0);
            pnlControls.Size = new Size(649, 41);
            pnlControls.TabIndex = 2;
            // 
            // btnControl
            // 
            btnControl.AutoSize = true;
            btnControl.BackColor = Color.LightGray;
            btnControl.FlatAppearance.BorderColor = Color.Black;
            btnControl.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            btnControl.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            btnControl.FlatStyle = FlatStyle.Flat;
            btnControl.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnControl.ForeColor = Color.Black;
            btnControl.Location = new Point(10, 5);
            btnControl.Margin = new Padding(5, 5, 0, 5);
            btnControl.Name = "btnControl";
            btnControl.Size = new Size(100, 31);
            btnControl.TabIndex = 0;
            btnControl.Text = "&Controle";
            btnControl.UseVisualStyleBackColor = false;
            btnControl.Click += btnControl_Click;
            // 
            // pnlMain
            // 
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Location = new Point(-7, 44);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(662, 324);
            pnlMain.TabIndex = 3;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(649, 361);
            Controls.Add(pnlMain);
            Controls.Add(pnlControls);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Painel de Controle";
            Load += frmMain_Load;
            pnlControls.ResumeLayout(false);
            pnlControls.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnReg;
        private FlowLayoutPanel pnlControls;
        private Button btnControl;
        private ToolTip tooltip;
        private Panel pnlMain;
    }
}