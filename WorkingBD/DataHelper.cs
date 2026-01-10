using MySql.Data.MySqlClient;
using System;
namespace WorkingBD
{
    public class DataHelper
    {
        public static MySqlDataReader Query(string sql, MySqlConnection connection)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(sql, connection);
                return command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка выполнения запроса: {ex.Message}");
            }
        }
    }
}
