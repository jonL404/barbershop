using System;
using System.Net.Mail;
using System.Windows.Forms;
using BARBEARIA.Models;
using BARBEARIA.Data; // <- import do helper

namespace BARBEARIA
{
    public partial class telaLogin : Form
    {
        public telaLogin()
        {
            InitializeComponent();
        }

        private void XBarber_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            var model = new LoginModel
            {
                Email = textBox1.Text?.Trim(),
                Senha = textBox2.Text
            };

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                MessageBox.Show("O email é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            try
            {
                var _ = new MailAddress(model.Email);
            }
            catch
            {
                MessageBox.Show("Formato de email inválido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(model.Senha))
            {
                MessageBox.Show("A senha é obrigatória.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            try
            {
                // Autentica e obtém o nível do usuário
                var nivel = DbHelper.AuthenticateUserLevel(model.Email, model.Senha);
                if (!string.IsNullOrEmpty(nivel))
                {
                    MessageBox.Show($"Login efetuado com sucesso. Nível: {nivel}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // abre a tela inicial após login bem-sucedido
                    this.Hide();
                    var init = new telaInicial();
                    init.Show();
                    // Opcional: outras telas podem ler DbHelper.CurrentUserLevel para permissões
                }
                else
                {
                    MessageBox.Show("Email ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show($"Erro de conexão com o banco: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            telaCadastrarCliente telaCadastro = new telaCadastrarCliente();
            telaCadastro.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
