using Mysqlx.Crud;
using Project.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Forms.Popups
{

    public partial class frmReceipt : Form
    {
        private readonly List<Product> receiptContent;
        private readonly decimal totalValue;
        private readonly int totalItems;
        private readonly string paymentMethod;

        public frmReceipt(List<Product> receiptContent, decimal totalValue, int totalItems, string paymentMethod)
        {
            this.paymentMethod = paymentMethod;
            this.receiptContent = receiptContent;
            this.totalValue = totalValue;
            this.totalItems = totalItems;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dialPrint.ShowDialog() == DialogResult.OK)
            {
                docReceipt.Print();
                MessageBox.Show($"Documento criado/enviado para impressão com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Close();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            string receiptContent = " Item".PadRight(11) + "Código".PadRight(11) + "Descrição".PadRight(28) +
                                    "Qtde.".PadRight(10) + "Vl. Unit.".PadRight(11) + "Vl. Total\n";

            receiptContent += new string('-', 81) + "\n";

            foreach (ListViewItem item in listReceipt.Items)
            {
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    bool hasNumber = decimal.TryParse(subItem.Text, out decimal result);

                    if (!hasNumber)
                    {
                        if (subItem.Text.Length > 24)
                        {
                            receiptContent += subItem.Text[..24] + "...".PadRight(5);
                            continue;
                        }

                        if (subItem.Text.Length <= 6)
                        {
                            receiptContent += subItem.Text.PadRight(subItem.Text.Length + 24);
                            continue;
                        }

                        receiptContent += subItem.Text.PadRight(29);
                        continue;
                    }

                    receiptContent += subItem.Text.PadRight(11);
                }
                receiptContent += "\n";
            }
            receiptContent += new string('-', 81) + "\n";
            receiptContent += "Quantidade Total de Itens: ".PadRight(26) + totalItems + "\n";
            receiptContent += "Valor Total: R$".PadRight(16) + totalValue + "\n";
            receiptContent += "Valor Pago:  R$".PadRight(16) + totalValue + "\n";
            receiptContent += "Método de pagamento: ".PadRight(21) + paymentMethod;

            e.Graphics?.DrawString(receiptContent, new Font("Courier New", 12), Brushes.Black, 10, 10);
        }

        private void frmReceipt_Load(object sender, EventArgs e)
        {
            int itemCount = 1;

            foreach (var product in receiptContent)
            {
                ListViewItem item = new(itemCount.ToString().PadLeft(3, '0'));
                item.SubItems.Add(product.ID.PadLeft(5, '0'));
                item.SubItems.Add(product.Desc);
                item.SubItems.Add(product.Qty.ToString().PadLeft(2, '0'));
                item.SubItems.Add(product.ProductValue == 0 ? "Erro" : product.ProductValue.ToString("F2"));
                item.SubItems.Add(product.ProductValue == 0 ? "Erro" : (product.ProductValue * product.Qty).ToString("F2"));
                listReceipt.Items.Add(item);
                itemCount++;
            }
        }

        private void listReceipt_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item != null)
                e.Item.Selected = false;
        }
    }
}
