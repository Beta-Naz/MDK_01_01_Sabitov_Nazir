using System.Collections.Generic;
using System.Data.OleDb;
using Shop_Сабитов.Interfaces;
using Shop_Сабитов.Models;
using Shop_Сабитов.Classes.Common;

namespace Shop_Сабитов.Classes
{
    public class ShopContext : Shop, IContext
    {
        public ShopContext(int id, string Name, int Price) : base(id, Name, Price)
        {
        }
        public List<object> All()
        {
            List<object> allShops = new List<object>();
            using (OleDbConnection connection = DBConnection.Connection())
            {
                connection.Open();
                string query = $@"SELECT * FROM [Товар]";
                using (OleDbDataReader reader = DBConnection.Query(query, connection))
                {
                    while (reader.Read())
                    {
                        ShopContext newShop = new ShopContext(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2));
                        allShops.Add(newShop);
                    }
                }
                ;
            }
            return allShops;
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
