using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BARBEARIA.Data;
using MySql.Data.MySqlClient;

namespace BARBEARIA
{
    public partial class telaServico : Form
    {
        public telaServico()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Horários_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var profissional = comboBox1.SelectedItem as string;
            var servico = comboBox2.SelectedItem as string;
            var horario = comboBox3.SelectedItem as string;
            var data = dateTimePicker1.Value.Date;

            if (string.IsNullOrWhiteSpace(profissional))
            {
                MessageBox.Show("Selecione um profissional.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(servico))
            {
                MessageBox.Show("Selecione um serviço.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(horario))
            {
                MessageBox.Show("Selecione um horário.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Regra atualizada: permite vários agendamentos no mesmo dia para o profissional,
                // desde que não sejam no mesmo horário.
                // Remove-se a verificação que bloqueava qualquer agendamento no mesmo dia.

                // Verifica apenas conflito de horário para o mesmo profissional na mesma data
                if (DbHelper.IsTimeSlotTaken(profissional, data, horario))
                {
                    MessageBox.Show("O horário selecionado já está reservado para este profissional.", "Horário indisponível", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Se passou nas validações, cria o agendamento no banco
                var created = DbHelper.CreateAppointment(profissional, servico, data, horario);
                if (created)
                {
                    MessageBox.Show("Agendamento confirmado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // opcional: limpar seleções
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    comboBox3.SelectedIndex = -1;
                    dateTimePicker1.Value = DateTime.Today;
                }
                else
                {
                    MessageBox.Show("Falha ao confirmar o agendamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro de conexão com o banco: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar agendar o serviço: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Fecha o formulário ao clicar no botão "Sair"
            this.Close();
            telaLogin loginForm = new telaLogin();
            loginForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            telaCancelamentoServico cancelForms = new telaCancelamentoServico();
            cancelForms.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
