using System;
using System.Collections.Generic;
using System.Data;

namespace VinylRecordsApplication_Sabitov.Classes
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static IEnumerable<Country> AllCountries()
        {
            List<Country> countries = new List<Country>();
            string sql = "SELECT * FROM [dbo].[Country]";
            DataTable requestCountrys = DBConnection.Connection(sql);
            foreach (DataRow row in requestCountrys.Rows)
            {
                countries.Add(new Country()
                {
                    Id = Convert.ToInt32(row[0]),
                    Name = Convert.ToString(row[1])
                });
            }
            return countries;
        }
    }
}
