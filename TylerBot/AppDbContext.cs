using Microsoft.EntityFrameworkCore;
using TylerBot.Models;

namespace TylerBot
{
    public class AppDbContext : DbContext
    {
        public DbSet<ChatModel> Chats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=tylerbot;Username=tylerbot_user;Password=denpol");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatModel>().HasKey(c => c.Id);
        }
    }
}