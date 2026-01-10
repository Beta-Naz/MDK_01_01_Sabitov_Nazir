using Airlines_Сабитов.Models;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;
using WorkingBD;

namespace Airlines_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<TicketClass> ticketClasses = new List<TicketClass>();
        public MainWindow()
        {
            InitializeComponent();
            LoadTikets();
            frame.Navigate(new Pages.Main(this));
        }
        public void LoadTikets()
        {
            ticketClasses.Clear();
            string connection = @"server=localhost;port=3306;database=airlines;uid=root;pwd=1234;";
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                mySqlConnection.Open();
                using (MySqlDataReader tiket_reader = DataHelper.Query("SELECT * FROM airlines.tickets;", mySqlConnection))
                {
                    while (tiket_reader.Read())
                    {
                        ticketClasses.Add(new TicketClass(
                            tiket_reader.GetInt32(0),
                            tiket_reader.GetValue(1).ToString(),
                            tiket_reader.GetValue(2).ToString(),
                            tiket_reader.GetValue(3).ToString(),
                            tiket_reader.GetDateTime(4),
                            tiket_reader.GetDateTime(5)
                            ));
                    }
                }
            }
        }
    }
}
