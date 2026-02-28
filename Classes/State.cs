using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace VinylRecordsApplication_Sabitov.Classes
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subname { get; set; }
        public string Description { get; set; }
        public static IEnumerable<State> AllStates()
        {
            List<State> states = new List<State>();
            string sql = "SELECT * FROM [dbo].[State]";
            DataTable requestStates = DBConnection.Connection(sql);
            foreach (DataRow state in requestStates.Rows)
            {
                states.Add(new State()
                {
                    Id = Convert.ToInt32(state[0]),
                    Name = Convert.ToString(state[1]),
                    Subname = Convert.ToString(state[2]),
                    Description = Convert.ToString(state[3]),
                });
            }
            return states;
        }
        public void Save(bool Update = false)
        {
            if (!Update)
            {
                string sql = $@"INSERT INTO [dbo].[State]([Name], [Subname], [Description])
                              VALUES (N`{Name}`, N`{Subname}`, N`{Description}`);";
                DBConnection.Connection(sql);
                Id = AllStates().Where(x=> x.Name == Name &&
                                            x.Subname == Subname &&
                                            x.Description == Description).First().Id;
            }
            else
            {
                string sql = $@"UPDATE [dbo].[State] SET 
                             [Name] = N`{Name}`, 
                             [Subname] = N`{Subname}`,  
                             [Description] = N`{Description}`
                             WHERE [Id] = {Id},";
                DBConnection.Connection(sql);
            }
        }
        public void Delete()
        {
            string sql = $"DELETE FROM [dbo].[State] WHERE [Id] = {Id};";
            DBConnection.Connection(sql);
        }
    }
}
