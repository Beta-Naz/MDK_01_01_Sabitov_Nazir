using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Windows;

namespace ComputerClub_Сабитов.Core.DataBaseHelper
{
    public class DBConnection
    {
        private static readonly string _localHost = "localhost";
        private static readonly string _database = "computerclub";
        private static readonly string _userId = "root";
        private static readonly string _password = "1234";
        private static string ConnectionString => $"Server={_localHost};Database={_database};Uid={_userId};Pwd={_password}";
        public static MySqlConnection Connection()
        {
            try
            {
                return new MySqlConnection (ConnectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error text: {ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        public static MySqlDataReader Query(string sqlText, MySqlConnection connection)
        {
            MySqlCommand newQuery = new MySqlCommand(sqlText, connection);
            return newQuery.ExecuteReader();
        }
        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
            MySqlConnection.ClearAllPools();
        }
    }
}
