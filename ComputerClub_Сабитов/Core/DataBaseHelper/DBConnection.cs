using ComputerClub_Сабитов.Core.Enums;
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
        public static string UserId = "root";
        public static string Password = "1234";
        private static string ConnectionString => $"Server={_localHost};Database={_database};Uid={UserId};Pwd={Password}";
        public static MySqlConnection Connection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(ConnectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
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
        public static RoleType TestConnectionRole(MySqlConnection connection)
        {
            if (connection == null)
            {
                MessageBox.Show("Соединение закрыто попробуйте позже", "Сетевая ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return RoleType.Unnamed;
            }
            try
            {
                string query = $@"SELECT 1 from `compiterclub`";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteScalar();
                    MessageBox.Show("Вы зашли на правах админа.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    return RoleType.Admin;
                }
            }
            catch
            {

                try
                {
                    string query = $@"SELECT 1 from `playercomputer`";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteScalar();
                        MessageBox.Show("Вы зашли на правах пользователя.\nВы можете только бронировать!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        return RoleType.User;
                    }
                }
                catch
                {
                    MessageBox.Show("Неправильный логин или пароль. Попробуйте еще", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return RoleType.Unnamed;
                }
            }
        }
    }
}
