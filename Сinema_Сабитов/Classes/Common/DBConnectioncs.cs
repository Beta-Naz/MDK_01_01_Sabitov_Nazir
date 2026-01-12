using MySql.Data.MySqlClient;

namespace Сinema_Сабитов.Classes.Common
{
    public class DBHelper
    {
        public static MySqlDataReader Query(string sqlScript, MySqlConnection connection)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(sqlScript, connection);
                return command.ExecuteReader();
            }
            catch
            {
                return null;
            }
        }
    }
}
