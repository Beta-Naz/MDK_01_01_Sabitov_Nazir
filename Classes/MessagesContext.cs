using ChatStudents_Sabitov.Classes.Common;
using ChatStudents_Sabitov.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatStudents_Sabitov.Classes
{
    public class MessagesContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public MessagesContext() =>
            Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.config);
        }
    }
}
