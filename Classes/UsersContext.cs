using ChatStudents_Sabitov.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatStudents_Sabitov.Classes
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UsersContext() =>
            Database.EnsureCreated();
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=users.db");
        }
    }
}
