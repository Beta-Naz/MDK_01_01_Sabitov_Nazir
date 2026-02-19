using ComputerClub_Сабитов.Core.DataBaseHelper;
using ComputerClub_Сабитов.Interface;
using ComputerClub_Сабитов.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error text: {ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return new List<object>();
            }
        }
        public void Save()
        {
            try
            {
                using (MySqlConnection connection = DBConnection.Connection())
                {
                    string quere = $@"INSERT INTO playercomputer(startTimeRent, endTimeRent, fullName)
                                    VALUES ({StartTimeRent},{EndTimeRent}, {FullName}),";
                    DBConnection.Query(quere, connection);
                    DBConnection.CloseConnection(connection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error text: {ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void Update()
        {
            try
            {
                using (MySqlConnection connection = DBConnection.Connection())
                {
                    string quere = $@"UPDATE playercomputer
                                SET startTimeRent = {StartTimeRent}, 
                                   endTimeRent = {EndTimeRent}, 
                                   fullName = {FullName};
                                   Where id = {Id}";
                    DBConnection.Query(quere, connection);
                    DBConnection.CloseConnection(connection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error text: {ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
