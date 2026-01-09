using System.Collections.Generic;
using System.Data.OleDb;
using Shop_Сабитов.Interfaces;
using Shop_Сабитов.Models;
using Shop_Сабитов.Classes.Common;

namespace Shop_Сабитов.Classes
{
    public class ChildrenContext : Children, IContext
    {
        public ChildrenContext() { }
        public ChildrenContext(int id, string Name, int Price, int Age, int IdShop) : base(id, Name, Price, Age, IdShop)
        {
        }
        public List<object> All()
        {
            List<object> AllShop = new ShopContext().All();
            List<object> allChildren = new List<object>();
            using (OleDbConnection connection = DBConnection.Connection())
            {
                connection.Open();
                string query = $@"SELECT * FROM [Детские Вещи]";
                using (OleDbDataReader reader = DBConnection.Query(query, connection))
                {
                    while (reader.Read())
                    {
                        ShopContext shopElement = AllShop.Find(x => (x as ShopContext).Id == reader.GetInt32(2)) as ShopContext;
                        ChildrenContext newChildren = new ChildrenContext(
                            shopElement.Id,
                            shopElement.Name,
                            shopElement.Price,
                            reader.GetInt32(1),
                            reader.GetInt32(2));
                        allChildren.Add(newChildren);
                    }
                }
                ;
            }
            return allChildren;
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
