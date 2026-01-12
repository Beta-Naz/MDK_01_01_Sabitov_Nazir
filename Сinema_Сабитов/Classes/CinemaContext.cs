using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Сinema_Сабитов.Interface;
using Сinema_Сабитов.Models;
using Сinema_Сабитов.Classes.Common;
using System;

namespace Сinema_Сабитов.Classes
{
    public class CinemaContext : Cinema, IContext
    {
        public CinemaContext() { }
        public CinemaContext(int id, int countHall, int countPlace) :
            base(id, countHall, countPlace)
        {
        }
        public List<object> All()
        {
            List<object> allCinema = new List<object>();
            using (MySqlConnection connection = DBConnection.Connection())
            {
                string sqlScript = $@"SELECT * FROM [Cinema]";
                using (MySqlDataReader reader = DBConnection.Query(sqlScript, connection))
                {
                    while (reader.Read())
                    {
                        Cinema newCinema = new Cinema(
                            Id = Convert.ToInt32(reader[0]),
                            CountHall = Convert.ToInt32(reader[0]),
                            CountPlace = Convert.ToInt32(reader[0]));
                        allCinema.Add(newCinema);
                    }
                }
            }
            return allCinema;
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }
        public void Save(bool Update = false)
        {
            throw new System.NotImplementedException();
        }
    }
}
