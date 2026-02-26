using Microsoft.EntityFrameworkCore;
using Практическая_работа_29.Classes.Common;
using Практическая_работа_29.Models;

namespace Практическая_работа_29.Classes.Context
{
    public class ClubContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public ClubContext() =>
            Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);
    }
}
