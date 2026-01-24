using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BARBEARIA
{
    public partial class telaAdminClientes : Form
    {
        public telaAdminClientes()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            telaCadastrarCliente cadForms = new telaCadastrarCliente();
            cadForms.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            telaAdmin telaAdmin = new telaAdmin();
            telaAdmin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            telaRemoverCliente remForms = new telaRemoverCliente();
            remForms.Show();
        }
    }
}
