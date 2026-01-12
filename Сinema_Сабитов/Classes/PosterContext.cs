using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Сinema_Сабитов.Interface;
using Сinema_Сабитов.Models;
using Сinema_Сабитов.Classes.Common;
using System;

namespace Сinema_Сабитов.Classes
{
    public class PosterContext : Poster, IContext
    {
        public PosterContext() { }
        public PosterContext(int id, string idCinema, string film, 
            TimeSpan timeSession, decimal priceSession, decimal priceTicket) : 
            base(id, idCinema, film, timeSession, priceSession, priceTicket)
        {
        }
        public List<object> All()
        {
            List<object> allPoster = new List<object>();
            using (MySqlConnection connection = DBConnection.Connection())
            {
                string sqlScript = $@"SELECT * FROM [Cinema]";
                using (MySqlDataReader reader = DBConnection.Query(sqlScript, connection))
                {
                    while (reader.Read())
                    {
                        Poster newPoster = new Poster(
                            Id = Convert.ToInt32(reader[0]),
                            IdCinema = Convert.ToInt32(reader[1]),
                            Film = reader.GetString(2),
                            TimeSession = reader.GetTimeSpan(3),
                            PriceSession = Convert.ToDecimal(4),
                            PriceTicket = Convert.ToDecimal(4));
                        allPoster.Add(newPoster);
                    }
                }
            }
            return allPoster;
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