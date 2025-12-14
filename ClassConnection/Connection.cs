using ClassModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ClassConnection
{
    public class Connection
    {
        #region списки
        public List<User> users = new List<User>();
        public List<Call> calls = new List<Call>();
        #endregion
        public enum tabels
        {
            users, calls
        }
        public string localPath = @"C:\Users\Сабитов Назир\Desktop\PhoneBook_Сабитов\PhoneBook_Сабитов\bin\Debug";
        public OleDbDataReader QueryAccess(string query)
        {
            try
            {
                localPath = Directory.GetCurrentDirectory();
                OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                             localPath + "/accesbase.accdb");
                connect.Open();
                OleDbCommand cmd = new OleDbCommand(query, connect);

                if (query.Trim().ToUpper().StartsWith("SELECT"))
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                else
                {
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    return null;
                }

            }
            catch
            {
                throw;
            } 
        }
        public int SetLastId(tabels tabel)
        {
            try
            {
                LoadData(tabel);
                switch (tabel.ToString())
                {
                    case "users":
                        if(users.Count >= 1)
                        {
                            int max = users[0].id;
                            max = users.Max(x => x.id);
                            return max + 1;
                        }
                        return 1;
                    case "calls":
                        if (calls.Count >= 1)
                        {
                            int max = calls[0].id;
                            max = calls.Max(x => x.id);
                            return max + 1;
                        }
                        return 1;
                    default:
                        return -1;
                }
            }
            catch
            {
                return -1;
            }
        }
        public void LoadData(tabels zap)
        {
            try
            {

                OleDbDataReader itemQuery = QueryAccess(
                    $@"SELECT *
                FROM [{zap.ToString()}]
                ORDER BY [Код]
                ");
                #region
                if (zap.ToString() == "users")
                {
                    users.Clear();
                    while (itemQuery.Read())
                    {
                        User newE1 = new User()
                        {
                            id = Convert.ToInt32(itemQuery.GetValue(0)),
                            phone_num = Convert.ToString(itemQuery.GetValue(1)),
                            fio_user = Convert.ToString(itemQuery.GetValue(2)),
                            pasport_data = Convert.ToString(itemQuery.GetValue(3))
                        };
                        users.Add(newE1);
                    }
                }
                if (zap.ToString() == "calls")
                {
                    calls.Clear();
                    while (itemQuery.Read())
                    {
                        Call newE1 = new Call()
                        {
                            id = Convert.ToInt32(itemQuery.GetValue(0)),
                            user_id = Convert.ToInt32(itemQuery.GetValue(1)),
                            category_call = Convert.ToInt32(itemQuery.GetValue(2)),
                            date = Convert.ToString(itemQuery.GetValue(3)),
                            time_start = Convert.ToString(itemQuery.GetValue(4)),
                            time_end = Convert.ToString(itemQuery.GetValue(5))
                        };
                        calls.Add(newE1);
                    }
                }
                #endregion
                if(itemQuery != null)
                {
                    itemQuery.Close();
                }
            }
            catch
            {
                Console.WriteLine("Null");
            }
        }
        public bool RegularMath(string stroka, string regularStroka)
        {
            return Regex.Match(stroka, regularStroka).Success;
        }
        public bool ItsNumber(string str)
        {
            try
            {
                if (RegularMath(str, @"^(\+?7|8)?[\s\-]?\(?([3489][0-9]{2})\)?[\s\-]?([0-9]{3})[\s\-]?([0-9]{2})[\s\-]?([0-9]{2})$"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ItsOnlyFIO(string str)
        {
            try
            {
                if (str.Trim().Split(' ', ',').Length >= 2 && str.Trim().Split(' ', ',').Length < 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }

}
