using System.Data.OleDb;

namespace Documents_Сабитов.Classes.Common
{
    public class DBConnection
    {
        public static readonly string Path = @"C:\\Users\\student-a502.PERMAVIAT\\Desktop\\4пр\\Documents_Сабитов\\Documents_Сабитов\\bin\\Debug\\DataBase.accdb";
        public static OleDbConnection Connection()
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path);
            conn.Open();
            return conn;
        }
        public static OleDbDataReader Query(string Query, OleDbConnection connection)
        {
            return new OleDbCommand(Query, connection).ExecuteReader();
        }
        public static void CloseConnection(OleDbConnection connection)
        {
            connection.Close();
        }
    }
}
