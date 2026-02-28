using System.Data;
using System.Data.SqlClient;

namespace VinylRecordsApplication_Sabitov.Classes
{
    public class DBConnection
    {
        public static readonly string ConnectionString = "server=localhost;Trusted_Connection=No;DataBase=vimylrecordsapplication;User=root;PWD=1234";
        public static DataTable Connection(string SQL)
        {
            DataTable dataTable = new DataTable("Datatable");
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = SQL;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
    }
}
