using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Project.Controls;
using Org.BouncyCastle.Asn1.Pkcs;
using Project.Forms.UserControls;

namespace Project.Forms
{
    public partial class FrmMain : Form
    {
        private readonly string employeePosition;
        private readonly string employeeID;

        public FrmMain(string employeePosition, string employeeID)
        {
            this.employeePosition = employeePosition;
            this.employeeID = employeeID;
            InitializeComponent();
        }

        private void DeleteActiveControl()
        {
            Control? control = ControlExists();
            if (control != null)
            {
                if (pnlMain.Controls.Contains(control))
                {
                    pnlMain.Controls.Remove(control);
                    control.Dispose();
                }
            }
        }

        private Control? ControlExists()
        {
            foreach (Control control in pnlMain.Controls)
            {
                if (control is UserControl)
                {
                    return control;
                }
            }
            return null;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblID.Text = employeeID.ToString();

            if (!string.IsNullOrWhiteSpace(employeePosition) && employeePosition.Equals("1"))
            {
                btnReg.Visible = true;
                btnReg.Enabled = true;
            }

            btnControl_Click(sender, e);
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            DeleteActiveControl();

            RegisterPanel? regPanel = new()
            {
                Dock = DockStyle.Fill
            };
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(regPanel);
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            DeleteActiveControl();

            ControlPanel? ctrlPanel = new()
            {
                Dock = DockStyle.Fill
            };

            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(ctrlPanel);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Desconectando", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                FrmLogin frmLogin = new();
                frmLogin.ShowDialog();
                this.Close();
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            DeleteActiveControl();

            profilePanel? profilePanel = new()
            {
                Dock = DockStyle.Fill
            };

            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(profilePanel);
        }
    }
}
