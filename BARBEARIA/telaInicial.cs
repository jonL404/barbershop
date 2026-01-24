using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BARBEARIA.Data; // adicionado para acessar DbHelper

namespace BARBEARIA
{
    public partial class telaInicial : Form
    {
        public telaInicial()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Mostrar botão admin apenas se o usuário logado tiver nível "admin"
            adminButton.Visible = string.Equals(DbHelper.CurrentUserLevel, "admin", StringComparison.OrdinalIgnoreCase);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            telaServico serviceForms = new telaServico();
            serviceForms.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            telaLogin loginForms = new telaLogin();
            loginForms.Show();
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            this.Close();
            telaAdmin adminForms = new telaAdmin();
            adminForms.Show();
        }
    }
}
