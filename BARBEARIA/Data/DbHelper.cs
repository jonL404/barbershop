using System;
using MySql.Data.MySqlClient;

namespace BARBEARIA.Data
{
    public static class DbHelper
    {
        // Atualize aqui com sua string de conexão
        private static string ConnectionString => "Server=192.168.25.32;Database=TI;Uid=gvb_analist;Pwd=z#\"S=0yToL5x;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // Valida usuário por email e senha (use hashing em produção)
        public static bool ValidateUser(string email, string senha)
        {
            const string query = "SELECT COUNT(1) FROM barbershop WHERE email = @email AND senha = @senha LIMIT 1;";

            using (var conn = GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senha);

                conn.Open();
                var result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        // Verifica se já existe agendamento para o profissional na mesma data
        public static bool HasAppointmentOnDate(string profissional, DateTime data)
        {
            const string query = "SELECT COUNT(1) FROM service WHERE profissional = @profissional AND data_agendamento = @data;";
            using (var conn = GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@profissional", profissional);
                cmd.Parameters.AddWithValue("@data", data.Date);
                conn.Open();
                var result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        // Verifica se o horário já está ocupado para o profissional na mesma data
        public static bool IsTimeSlotTaken(string profissional, DateTime data, string horario)
        {
            const string query = "SELECT COUNT(1) FROM service WHERE profissional = @profissional AND data_agendamento = @data AND horario = @horario;";
            using (var conn = GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@profissional", profissional);
                cmd.Parameters.AddWithValue("@data", data.Date);
                cmd.Parameters.AddWithValue("@horario", horario);
                conn.Open();
                var result = cmd.ExecuteScalar();
                return (result != null && Convert.ToInt32(result) > 0);
            }
        }

        // Insere um novo agendamento
        public static bool CreateAppointment(string profissional, string servico, DateTime data, string horario)
        {
            const string query = "INSERT INTO services (profissional, servico, data_agendamento, horario) VALUES (@profissional, @servico, @data, @horario);";
            using (var conn = GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@profissional", profissional);
                cmd.Parameters.AddWithValue("@servico", servico);
                cmd.Parameters.AddWithValue("@data", data.Date);
                cmd.Parameters.AddWithValue("@horario", horario);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cria um novo usuário
        public static bool CreateUser(string nome, string email, string senha)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand("INSERT INTO usuarios (nome, email, senha) VALUES (@nome, @email, @senha)", conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}