using Microsoft.EntityFrameworkCore;
namespace Практическая_работа_29.Classes.Common
{
    public class Config
    {
        public static string Login = "root";
        public static string Password = "1234";
        public static readonly string ConnectionConfig = $"server=10.0.201.4;uid={Login};pwd={Password};database=pcClub";
        public static MySqlServerVersion Version = new MySqlServerVersion(new Version(8,0,11));
    }
}
