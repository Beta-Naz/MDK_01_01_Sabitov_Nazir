using System;
using System.Data.OleDb;
using System.Windows;

namespace Documents_Сабитов.Classes.Common
{
    public class DBConnection
    {
        public static readonly string Path = @"C:\Users\student-a502.PERMAVIAT\Desktop\MDK_01_01_Sabitov_Nazir--21\Documents_Сабитов\bin\Debug\DataBase.accdb";
        public static OleDbConnection Connection()
        {
            try
            {
                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static OleDbDataReader Query(string Query, OleDbConnection connection)
        {
            try
            {
                return new OleDbCommand(Query, connection).ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static void CloseConnection(OleDbConnection connection)
        {
            connection.Close();
        }
    }
}
