using KeyPass_Sabitov.Models;
using Microsoft.EntityFrameworkCore;

namespace KeyPass_Sabitov.Classes
{
    public class DataBaseManager : DbContext
    {
        public DbSet<Storage> Storages { get; set; }
        public DbSet<User> Users { get; set; }
        public DataBaseManager() => 
            Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=127.0.0.1;uid=student;pwd=;database=Storage;",
                new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
