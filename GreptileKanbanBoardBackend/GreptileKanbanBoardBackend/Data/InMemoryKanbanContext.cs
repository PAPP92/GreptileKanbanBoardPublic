using GreptileKanbanBoardBackend.Models;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;

namespace GreptileKanbanBoardBackend.Data
{
    public class InMemoryKanbanContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public InMemoryKanbanContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("KanbanBoard");
        }

        public DbSet<Column> Columns { get; set; }
        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Column>().HasKey(c => c.Id);
            modelBuilder.Entity<Card>().HasKey(c => c.Id);

            modelBuilder.Entity<Column>().HasData(
                new Column { Id = 1, Title = "To Do" },
                new Column { Id = 2, Title = "In Progress" },
                new Column { Id = 3, Title = "Done" }
            );

            // Generate mock data
            var random = new Random();
            var cards = new List<Card>();
            for (int i = 1; i <= random.Next(20, 30); i++)
            {
                cards.Add(new Card
                {
                    Id = 1000 + i,
                    Title = "Task " + i,
                    Body = GenerateRandomString(1).ToUpper() + GenerateRandomString(random.Next(6, 12)) + " " + GenerateRandomString(random.Next(6, 12)),
                    Column_Id = random.Next(1, 4) // Ensure Id is set correctly
                });
            }
            modelBuilder.Entity<Card>().HasData(cards);
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
