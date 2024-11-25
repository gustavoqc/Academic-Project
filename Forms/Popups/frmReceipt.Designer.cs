namespace Project.Forms.Popups
{
    partial class frmReceipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceipt));
            tspActions = new ToolStrip();
            btnPrint = new ToolStripButton();
            pnlReceipt = new Panel();
            pnlDocument = new Panel();
            listReceipt = new ListView();
            itemCount = new ColumnHeader();
            itemID = new ColumnHeader();
            itemDesc = new ColumnHeader();
            itemQty = new ColumnHeader();
            itemUnValue = new ColumnHeader();
            itemTotal = new ColumnHeader();
            pnlActions = new Panel();
            tspFormActions = new ToolStrip();
            btnClose = new ToolStripButton();
            docReceipt = new System.Drawing.Printing.PrintDocument();
            dialPrint = new PrintDialog();
            tspActions.SuspendLayout();
            pnlReceipt.SuspendLayout();
            pnlDocument.SuspendLayout();
            pnlActions.SuspendLayout();
            tspFormActions.SuspendLayout();
            SuspendLayout();
            // 
            // tspActions
            // 
            tspActions.AutoSize = false;
            tspActions.BackColor = Color.WhiteSmoke;
            tspActions.CanOverflow = false;
            tspActions.Dock = DockStyle.None;
            tspActions.Font = new Font("Arial", 12F);
            tspActions.GripStyle = ToolStripGripStyle.Hidden;
            tspActions.ImageScalingSize = new Size(20, 20);
            tspActions.Items.AddRange(new ToolStripItem[] { btnPrint });
            tspActions.Location = new Point(0, 0);
            tspActions.Name = "tspActions";
            tspActions.Padding = new Padding(15, 3, 0, 3);
            tspActions.RenderMode = ToolStripRenderMode.System;
            tspActions.Size = new Size(280, 39);
            tspActions.TabIndex = 0;
            // 
            // btnPrint
            // 
            btnPrint.AutoSize = false;
            btnPrint.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPrint.Image = (Image)resources.GetObject("btnPrint.Image");
            btnPrint.ImageTransparentColor = Color.Magenta;
            btnPrint.Margin = new Padding(5, 1, 0, 2);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(30, 30);
            btnPrint.Text = "&Imprimir";
            btnPrint.TextImageRelation = TextImageRelation.TextAboveImage;
            btnPrint.Click += BtnPrint_Click;
            // 
            // pnlReceipt
            // 
            pnlReceipt.BorderStyle = BorderStyle.FixedSingle;
            pnlReceipt.Controls.Add(pnlDocument);
            pnlReceipt.Controls.Add(pnlActions);
            pnlReceipt.Dock = DockStyle.Fill;
            pnlReceipt.Location = new Point(0, 0);
            pnlReceipt.Name = "pnlReceipt";
            pnlReceipt.Size = new Size(580, 330);
            pnlReceipt.TabIndex = 1;
            // 
            // pnlDocument
            // 
            pnlDocument.BackColor = Color.Transparent;
            pnlDocument.Controls.Add(listReceipt);
            pnlDocument.Dock = DockStyle.Fill;
            pnlDocument.Location = new Point(0, 39);
            pnlDocument.Name = "pnlDocument";
            pnlDocument.Size = new Size(578, 289);
            pnlDocument.TabIndex = 0;
            pnlDocument.TabStop = true;
            // 
            // listReceipt
            // 
            listReceipt.Alignment = ListViewAlignment.SnapToGrid;
            listReceipt.BorderStyle = BorderStyle.None;
            listReceipt.Columns.AddRange(new ColumnHeader[] { itemCount, itemID, itemDesc, itemQty, itemUnValue, itemTotal });
            listReceipt.Dock = DockStyle.Fill;
            listReceipt.Font = new Font("Courier New", 11F);
            listReceipt.FullRowSelect = true;
            listReceipt.GridLines = true;
            listReceipt.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listReceipt.HideSelection = true;
            listReceipt.LabelWrap = false;
            listReceipt.Location = new Point(0, 0);
            listReceipt.MultiSelect = false;
            listReceipt.Name = "listReceipt";
            listReceipt.Size = new Size(578, 289);
            listReceipt.TabIndex = 3;
            listReceipt.UseCompatibleStateImageBehavior = false;
            listReceipt.View = View.Details;
            listReceipt.ItemSelectionChanged += ListReceipt_ItemSelectionChanged;
            // 
            // itemCount
            // 
            itemCount.Text = "Item";
            itemCount.Width = 50;
            // 
            // itemID
            // 
            itemID.Text = "Código";
            itemID.TextAlign = HorizontalAlignment.Center;
            itemID.Width = 80;
            // 
            // itemDesc
            // 
            itemDesc.Text = "Descrição";
            itemDesc.TextAlign = HorizontalAlignment.Center;
            itemDesc.Width = 188;
            // 
            // itemQty
            // 
            itemQty.Text = "Qtde.";
            itemQty.TextAlign = HorizontalAlignment.Center;
            // 
            // itemUnValue
            // 
            itemUnValue.Text = "Vl. Unit.";
            itemUnValue.TextAlign = HorizontalAlignment.Center;
            itemUnValue.Width = 100;
            // 
            // itemTotal
            // 
            itemTotal.Text = "Vl. Total";
            itemTotal.TextAlign = HorizontalAlignment.Center;
            itemTotal.Width = 100;
            // 
            // pnlActions
            // 
            pnlActions.AutoSize = true;
            pnlActions.BackColor = Color.Transparent;
            pnlActions.Controls.Add(tspFormActions);
            pnlActions.Controls.Add(tspActions);
            pnlActions.Dock = DockStyle.Top;
            pnlActions.Location = new Point(0, 0);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(578, 39);
            pnlActions.TabIndex = 3;
            // 
            // tspFormActions
            // 
            tspFormActions.AutoSize = false;
            tspFormActions.BackColor = Color.WhiteSmoke;
            tspFormActions.CanOverflow = false;
            tspFormActions.Dock = DockStyle.None;
            tspFormActions.Font = new Font("Arial", 12F);
            tspFormActions.GripStyle = ToolStripGripStyle.Hidden;
            tspFormActions.ImageScalingSize = new Size(20, 20);
            tspFormActions.Items.AddRange(new ToolStripItem[] { btnClose });
            tspFormActions.Location = new Point(280, 0);
            tspFormActions.Name = "tspFormActions";
            tspFormActions.Padding = new Padding(0, 3, 15, 3);
            tspFormActions.RenderMode = ToolStripRenderMode.System;
            tspFormActions.RightToLeft = RightToLeft.Yes;
            tspFormActions.Size = new Size(298, 39);
            tspFormActions.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.AutoSize = false;
            btnClose.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.ImageTransparentColor = Color.Magenta;
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 30);
            btnClose.Text = "&Close";
            btnClose.TextImageRelation = TextImageRelation.TextAboveImage;
            btnClose.Click += BtnClose_Click;
            // 
            // docReceipt
            // 
            docReceipt.PrintPage += DocReceipt_PrintPage;
            // 
            // dialPrint
            // 
            dialPrint.AllowPrintToFile = false;
            dialPrint.Document = docReceipt;
            // 
            // frmReceipt
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(580, 330);
            Controls.Add(pnlReceipt);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "frmReceipt";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmReceipt";
            Load += FrmReceipt_Load;
            tspActions.ResumeLayout(false);
            tspActions.PerformLayout();
            pnlReceipt.ResumeLayout(false);
            pnlReceipt.PerformLayout();
            pnlDocument.ResumeLayout(false);
            pnlActions.ResumeLayout(false);
            tspFormActions.ResumeLayout(false);
            tspFormActions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStrip tspActions;
        private Panel pnlReceipt;
        private ToolStripButton btnPrint;
        private ToolStrip tspFormActions;
        private ToolStripButton btnClose;
        private System.Drawing.Printing.PrintDocument docReceipt;
        private PrintDialog dialPrint;
        private Panel pnlActions;
        private Panel pnlDocument;
        private ListView listReceipt;
        private ColumnHeader itemCount;
        private ColumnHeader itemID;
        private ColumnHeader itemDesc;
        private ColumnHeader itemQty;
        private ColumnHeader itemUnValue;
        private ColumnHeader itemTotal;
    }
}