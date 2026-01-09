using System.Collections.Generic;
using System.Data.OleDb;
using Shop_Сабитов.Interfaces;
using Shop_Сабитов.Models;
using Shop_Сабитов.Classes.Common;
using System;

namespace Shop_Сабитов.Classes
{
    public class SportContext : Sport, IContext
    {
        public SportContext() {}
        public SportContext(int id, string Name, int Price, string Size, int idShop) : base(id, Name, Price, Size, idShop)
        {
        }
        public List<object> All()
        {
            List<object> allSports = new List<object>();
            List<object> allShop = new ShopContext().All();
            using( OleDbConnection connection = DBConnection.Connection())
            {
                string query = @"SELECT * FROM [Спорт]";
                using (OleDbDataReader reader = DBConnection.Query(query, connection))
                {
                    while (reader.Read())
                    {
                        ShopContext shopElements = allShop.Find(x => (x as ShopContext).Id == reader.GetInt32(2)) as ShopContext;
                        SportContext newSport = new SportContext(
                        
                            shopElements.Id,
                            shopElements.Name,
                            shopElements.Price,
                            reader.GetString(1),
                            reader.GetInt32(2)
                        );
                        allSports.Add(newSport);
                    }
                }
            }
            return allSports;
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Save(bool Update = false)
        {
            throw new NotImplementedException();
        }
    }
}
