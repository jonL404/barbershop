using System;
using System.Net.Mail;
using System.Windows.Forms;
using BARBEARIA.Data;

namespace BARBEARIA
{
	public partial class telaCadastrarCliente : Form
	{
		public telaCadastrarCliente()
		{
			InitializeComponent();
			// conecta o botão ao manipulador
			this.button1.Click += button1_Click;
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			var nome = textBox1.Text?.Trim();
			var email = textBox2.Text?.Trim();
			var senha = textBox3.Text;

			if (string.IsNullOrWhiteSpace(nome))
			{
				MessageBox.Show("O nome é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				textBox1.Focus();
				return;
			}

			if (string.IsNullOrWhiteSpace(email))
			{
				MessageBox.Show("O email é obrigatório.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				textBox2.Focus();
				return;
			}

			try
			{
				var _ = new MailAddress(email);
			}
			catch
			{
				MessageBox.Show("Formato de email inválido.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				textBox2.Focus();
				return;
			}

			if (string.IsNullOrWhiteSpace(senha))
			{
				MessageBox.Show("A senha é obrigatória.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				textBox3.Focus();
				return;
			}

			try
			{
				// uso do DbHelper totalmente qualificado para evitar conflito de tipos com BARBEARIA.DbHelper
				var created = BARBEARIA.Data.DbHelper.CreateUser(nome, email, senha);
				if (created)
				{
					MessageBox.Show("Cadastro realizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
					var login = new telaAdmin();
					login.Show();
				}
				else
				{
					MessageBox.Show("Falha ao cadastrar. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (MySql.Data.MySqlClient.MySqlException mex)
			{
				// 1062 é código comum para duplicata em MySQL; trate conforme seu esquema
				if (mex.Number == 1062)
					MessageBox.Show("Email já cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				else
					MessageBox.Show($"Erro de banco: {mex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void button3_Click(object sender, EventArgs e)
        {
			this.Close();
			telaAdminClientes telaAdminClientes = new telaAdminClientes();
			telaAdminClientes.Show();
        }
    }
}
