using System.Data.OleDb;

namespace Shop_Сабитов.Classes.Common
{
    internal class DBConnection
    {
        public static readonly string Path = @"C:\Users\Сабитов Назир\Desktop\MDK_01_01_Sabitov_Nazir--25\bin\Debug\Shop.accdb";
        public static OleDbConnection Connection()
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path);
            connection.Open();
            return connection;
        }
        public static OleDbDataReader Query(string query, OleDbConnection connection)
        {
            return new OleDbCommand(query, connection).ExecuteReader();
        }
        public static void CloseConnection(OleDbConnection connection)
        {
            connection.Close();
        }
    }
}
