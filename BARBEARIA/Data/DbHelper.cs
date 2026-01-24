using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace BARBEARIA.Data
{
    public static class DbHelper
    {
        // Atualize aqui com sua string de conexão
        private static string ConnectionString => "Server=localhost;Database=project;Uid=Jonas;Pwd=Jon2864@;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // Mantém a propriedade do nível do usuário autenticado para uso em outras telas
        public static string CurrentUserLevel { get; private set; }

        // Retorna o nível do usuário se email+senha forem válidos; caso contrário, retorna null
        public static string AuthenticateUserLevel(string email, string senha)
        {
            const string query = "SELECT nivel FROM barbershop WHERE email = @email AND senha = @senha LIMIT 1;";
            using (var conn = GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senha);
                conn.Open();
                var result = cmd.ExecuteScalar();
                var nivel = result?.ToString();
                CurrentUserLevel = nivel; // pode ser null se não autenticado
                return nivel;
            }
        }

        // Compatibilidade: mantém ValidateUser para código antigo
        public static bool ValidateUser(string email, string senha)
        {
            return AuthenticateUserLevel(email, senha) != null;
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

        // Retorna agendamentos do profissional em uma data (serviço + horário)
        public static DataTable GetAppointments(string profissional, DateTime data)
        {
            const string query = "SELECT servico, horario FROM service WHERE profissional = @profissional AND data_agendamento = @data ORDER BY horario;";
            using (var conn = GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@profissional", profissional);
                cmd.Parameters.AddWithValue("@data", data.Date);
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // Cancela (remove) um agendamento específico (profissional + data + horário)
        public static bool CancelAppointment(string profissional, DateTime data, string horario)
        {
            const string query = "DELETE FROM service WHERE profissional = @profissional AND data_agendamento = @data AND horario = @horario LIMIT 1;";
            using (var conn = GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@profissional", profissional);
                cmd.Parameters.AddWithValue("@data", data.Date);
                cmd.Parameters.AddWithValue("@horario", horario);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Insere um novo agendamento
        public static bool CreateAppointment(string profissional, string servico, DateTime data, string horario)
        {
            const string query = "INSERT INTO service (profissional, servico, data_agendamento, horario) VALUES (@profissional, @servico, @data, @horario);";
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

        // Cria um novo usuário — passa nível como opcional (padrão 'cliente')
        public static bool CreateUser(string nome, string email, string senha, string nivel = "cliente")
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand("INSERT INTO barbershop (nome, email, senha, nivel) VALUES (@nome, @email, @senha, @nivel)", conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    cmd.Parameters.AddWithValue("@nivel", nivel);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Retorna todos os usuários (id/email/nome/nivel)
        public static DataTable GetUsers()
        {
            const string query = "SELECT nome, email, nivel FROM barbershop ORDER BY nome;";
            using (var conn = GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            using (var adapter = new MySqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Remove usuário por email (email deve ser único)
        public static bool DeleteUserByEmail(string email)
        {
            const string query = "DELETE FROM barbershop WHERE email = @email LIMIT 1;";
            using (var conn = GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}