using ComputerClub_Сабитов.Core.DataBaseHelper;
using ComputerClub_Сабитов.Interface;
using ComputerClub_Сабитов.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace ComputerClub_Сабитов.Core.Context
{
    public class ContextPlayerComputer : PlayerComputer, IContext
    {
        public ContextPlayerComputer() { }
        public ContextPlayerComputer(int id, DateTime startTimeRent, DateTime endTimeRent, string fullName) :
            base(id, startTimeRent, endTimeRent, fullName)
        {
        }

        public void Delete()
        {
            try
            {
                using (MySqlConnection connection = DBConnection.Connection())
                {
                    string quere = $@"DELETE FROM playercomputer
                                      WHERE id = {Id}";
                    DBConnection.Query(quere, connection);
                    DBConnection.CloseConnection(connection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error text: {ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public List<object> GetAll()
        {

                List<object> allObject = new List<object>();
                using (MySqlConnection connection = DBConnection.Connection())
                {
                    string quere = $@"SELECT * FROM playercomputer";
                    using (MySqlDataReader reader = DBConnection.Query(quere, connection))
                    {
                        while (reader.Read())
                        {
                            ContextPlayerComputer playerComputer =
                                new ContextPlayerComputer(
                                    reader.GetInt32(0),
                                    reader.GetDateTime(1),
                                    reader.GetDateTime(2),
                                    reader.GetString(3)
                                );
                            allObject.Add(playerComputer);
                        }
                    }
                    DBConnection.CloseConnection(connection);
                }
                return allObject;
            
        }
        public void Save(bool update = false)
        {

                using (MySqlConnection connection = DBConnection.Connection())
                {
                    string query;
                    if (update)
                    {
                        query = $@"UPDATE playercomputer
                                SET startTimeRent = @start, 
                                   endTimeRent = @end, 
                                   fullName = @name
                                   Where id = @id";
                    }
                    else
                    {
                        query = $@"INSERT INTO playercomputer(startTimeRent,endTimeRent,fullName)
                                    VALUES (@start,@end,@name)";
                    }
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@start", StartTimeRent);
                        command.Parameters.AddWithValue("@end", EndTimeRent);
                        command.Parameters.AddWithValue("@name", FullName);

                        if (update)
                        {
                            command.Parameters.AddWithValue("@id", Id);
                        }

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Сохранение успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Сохранение провалилось!", "Успех", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    DBConnection.CloseConnection(connection);
                }

        }
    }
}
