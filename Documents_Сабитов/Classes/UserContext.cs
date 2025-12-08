using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documents_Сабитов.Classes.Common;
using Documents_Сабитов.Interfaces;
using Documents_Сабитов.Model;

namespace Documents_Сабитов.Classes
{
    public class UserContext : Model.User, IUser
    {
        public List<Model.User> AllUser()
        {
            List<Model.User> allUser = new List<Model.User>();
            OleDbConnection connection = DBConnection.Connection();
            using (OleDbDataReader dataUser = DBConnection.Query("SELECT * FROM [Ответственные]", connection))
            {
                while (dataUser.Read())
                {
                    allUser.Add(new UserContext()
                    {
                        Id = dataUser.GetInt32(0),
                        FIO = dataUser.GetString(1)
                    });
                }
                return allUser;
            }
        }

        public void Delete()
        {
            OleDbConnection connection = Common.DBConnection.Connection();
            Common.DBConnection.Query($"DELETE FROM [Ответственные] WHERE [Код] = {this.Id}", connection);
            Common.DBConnection.CloseConnection(connection);
        }

        public void Save(bool update = false)
        {
            using (OleDbConnection connection = DBConnection.Connection())
            {
                if (update)
                {
                    string queryUpdate = $"UPDATE " +
                            $"[Ответственные] " +
                        $"SET " +
                            $"[ФИО] = '{this.FIO}'" +
                        $"WHERE " +
                            $"[Код]= {this.Id}";
                    DBConnection.Query(queryUpdate, connection);
                }
                else
                {
                    string queryInsert = $"INSERT INTO " +
                             $"[Ответственные](" +
                                 $"[ФИО]) " +
                            $"VALUES " +
                               $"('{this.FIO}')";
                    DBConnection.Query(queryInsert, connection);
                }
            }
        }
    }
}
