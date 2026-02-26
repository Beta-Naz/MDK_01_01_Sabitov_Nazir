using Microsoft.EntityFrameworkCore;
using Практическая_работа_29.Classes.Common;
using Практическая_работа_29.Models;

namespace Практическая_работа_29.Classes.Context
{
    class UserContext : DbContext
    {
        public DbSet<User> Clubs { get; set; }
        public UserContext() =>
            Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);
    }
}
