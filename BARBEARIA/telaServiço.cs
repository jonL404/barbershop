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
    public static class DbHelper
    {
        public static bool HasAppointmentOnDate(string profissional, DateTime data)
        {
            // Implemente a lógica de verificação aqui
            return false;
        }

        public static bool IsTimeSlotTaken(string profissional, DateTime data, string horario)
        {
            // Implemente a lógica de verificação aqui
            return false;
        }
    }

    public partial class telaServiço : Form
    {
        public telaServiço()
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
                // Regra: apenas 1 agendamento por profissional por dia
                if (DbHelper.HasAppointmentOnDate(profissional, data))
                {
                    MessageBox.Show("O profissional já possui um agendamento neste dia.", "Horário indisponível", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Regras adicionais: horário não pode ser duplicado para o mesmo profissional na mesma data
                if (DbHelper.IsTimeSlotTaken(profissional, data, horario))
                {
                    MessageBox.Show("O horário selecionado já está reservado para este profissional.", "Horário indisponível", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar agendar o serviço: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
