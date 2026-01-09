using Shop_Сабитов.Classes.Common;
using Shop_Сабитов.Interfaces;
using Shop_Сабитов.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Shop_Сабитов.Classes
{
    public class ElectronicsContext : Electronics, IContext
    {
        public ElectronicsContext() { }
        public ElectronicsContext(int id, string Name, int Price, int BatteryCapacity, int DrivingSpeed, int idShop) : 
            base(id, Name, Price, BatteryCapacity, DrivingSpeed, idShop)
        {

        }
        public List<object> All()
        {
            List<object> allElectronics = new List<object>();
            List<object> allShop = new ShopContext().All();
            using (OleDbConnection connection = DBConnection.Connection())
            {
                string query = @"SELECT * FROM [Электроника]";
                using (OleDbDataReader reader = DBConnection.Query(query, connection))
                {
                    while (reader.Read())
                    {
                        ShopContext shopElements = allShop.Find(x => (x as ShopContext).Id == reader.GetInt32(3)) as ShopContext;
                        ElectronicsContext newElectronic = new ElectronicsContext(

                            shopElements.Id,
                            shopElements.Name,
                            shopElements.Price,
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3)
                        );
                        allElectronics.Add(newElectronic);
                    }
                }
            }
            return allElectronics;
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
