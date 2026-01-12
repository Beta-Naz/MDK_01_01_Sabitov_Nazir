using MySql.Data.MySqlClient;

namespace Сinema_Сабитов.Classes.Common
{
    public class DBConnection
    {
        private static readonly string _connectionString = $@"server=localhost;port=3306;database=dbcinema;uid=root;pwd=1234;";
        public static MySqlConnection Connection()
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
        public static MySqlDataReader Query(string sql, MySqlConnection connection)
        {
            return new MySqlCommand(sql, connection).ExecuteReader();
        }
        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
        }
    }
}
