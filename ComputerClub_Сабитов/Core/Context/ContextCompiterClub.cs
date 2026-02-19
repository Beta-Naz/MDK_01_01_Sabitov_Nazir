using ComputerClub_Сабитов.Core.DataBaseHelper;
using ComputerClub_Сабитов.Interface;
using ComputerClub_Сабитов.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComputerClub_Сабитов.Core.Context
{
    public class ContextCompiterClub : CompiterClub, IContext
    {
        public ContextCompiterClub() { }
        public ContextCompiterClub(int id, string name, string address, DateTime startTimeWork, DateTime endTimeWork)
            : base(id, name, address, startTimeWork, endTimeWork)
        {
        }
        public void Delete()
        {
            try
            {
                using (MySqlConnection connection = DBConnection.Connection())
                {
                    string quere = $@"DELETE FROM compiterclub
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
                    string quere = $@"SELECT * FROM compiterclub";
                    using (MySqlDataReader reader = DBConnection.Query(quere, connection))
                    {
                        while (reader.Read())
                        {
                            ContextCompiterClub compiterclub =
                                new ContextCompiterClub(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetDateTime(3),
                                    reader.GetDateTime(4)
                                );
                            allObject.Add(compiterclub);
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
                    string quere = $@"INSERT INTO compiterclub(name, address, startTimeWork,  endTimeWork)
                                    VALUES ({Name},{Address},{StartTimeWork},{EndTimeWork})";
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
                    string quere = $@"UPDATE compiterclub
                                SET name = {Name}, 
                                    address = {Address}, 
                                    startTimeWork = {StartTimeWork},  
                                    endTimeWork = {EndTimeWork};
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
