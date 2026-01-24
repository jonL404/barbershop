using System;
using System.Data;
using System.Windows.Forms;
using BARBEARIA.Data;

namespace BARBEARIA
{
    public partial class telaRemoverCliente : Form
    {
        private DataTable currentUsers;

        public telaRemoverCliente()
        {
            InitializeComponent();
            // carregar lista ao abrir
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                currentUsers = DbHelper.GetUsers();
                listBoxClientes.Items.Clear();

                if (currentUsers.Rows.Count == 0)
                {
                    listBoxClientes.Items.Add("Nenhum usuário encontrado.");
                    return;
                }

                foreach (DataRow row in currentUsers.Rows)
                {
                    var nome = row["nome"]?.ToString();
                    var email = row["email"]?.ToString();
                    var nivel = row["nivel"]?.ToString();
                    listBoxClientes.Items.Add(string.Format("{0} - {1} ({2})", nome, email, nivel));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar usuários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (currentUsers == null || currentUsers.Rows.Count == 0 || listBoxClientes.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um cliente para remover.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var row = currentUsers.Rows[listBoxClientes.SelectedIndex];
                var email = row["email"]?.ToString();
                var nome = row["nome"]?.ToString();

                var confirm = MessageBox.Show(string.Format("Confirma a remoção do cliente {0} ({1})?", nome, email), "Confirmar remoção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                var removed = DbHelper.DeleteUserByEmail(email);
                if (removed)
                {
                    MessageBox.Show("Cliente removido com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("Falha ao remover cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            telaAdminClientes adminClientForms = new telaAdminClientes();
            adminClientForms.Show();
        }
    }
}
