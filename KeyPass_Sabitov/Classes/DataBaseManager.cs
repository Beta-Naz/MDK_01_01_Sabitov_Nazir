using KeyPass_Sabitov.Models;
using Microsoft.EntityFrameworkCore;

namespace KeyPass_Sabitov.Classes
{
    public class DataBaseManager : DbContext
    {
        private static readonly string _sourse = "Server=10.0.201.112;" +
            "Database=base1_ISP_23_1_21;" +
            "User Id=ISP_23_1_21;" +
            "Password=D7x7gZZp-3_;";
        public DbSet<Storage> Storages { get; set; }
        public DbSet<User> Users { get; set; }
        public DataBaseManager() => 
            Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                _sourse,
                new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
