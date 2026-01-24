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
    public partial class telaAdmin : Form
    {
        public telaAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            telaCancelamentoServico cancelForms = new telaCancelamentoServico();
            cancelForms.Show();
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            this.Close();
            telaAdminClientes adminClientsForms = new telaAdminClientes();
            adminClientsForms.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            telaLogin loginForms = new telaLogin();
            loginForms.Show();
        }
    }
}
