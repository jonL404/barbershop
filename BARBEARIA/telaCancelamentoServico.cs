using System;
using System.Data;
using System.Windows.Forms;
using BARBEARIA.Data;

namespace BARBEARIA
{
    public partial class telaCancelamentoServico : Form
    {
        private DataTable currentAppointments;

        public telaCancelamentoServico()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            var profissional = comboBoxProfissionais.SelectedItem as string;
            var data = dateTimePicker1.Value.Date;

            if (string.IsNullOrWhiteSpace(profissional))
            {
                MessageBox.Show("Selecione um profissional.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                currentAppointments = DbHelper.GetAppointments(profissional, data);
                listBoxAgendamentos.Items.Clear();

                if (currentAppointments.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhum agendamento encontrado para este profissional na data selecionada.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (DataRow row in currentAppointments.Rows)
                {
                    var horario = row["horario"].ToString();
                    var servico = row["servico"].ToString();
                    listBoxAgendamentos.Items.Add(string.Format("{0} - {1}", horario, servico));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar agendamentos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            var profissional = comboBoxProfissionais.SelectedItem as string;
            var data = dateTimePicker1.Value.Date;

            if (string.IsNullOrWhiteSpace(profissional))
            {
                MessageBox.Show("Selecione um profissional.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listBoxAgendamentos.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um agendamento para cancelar.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var row = currentAppointments.Rows[listBoxAgendamentos.SelectedIndex];
                var horario = row["horario"].ToString();

                var confirm = MessageBox.Show(string.Format("Confirma o cancelamento do agendamento às {0}?", horario), "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                var cancelled = DbHelper.CancelAppointment(profissional, data, horario);
                if (cancelled)
                {
                    MessageBox.Show("Agendamento cancelado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // atualizar lista
                    buttonBuscar_Click(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Falha ao cancelar o agendamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cancelar agendamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            telaAdmin adminForms = new telaAdmin();
            adminForms.Show();
        }
    }
}
