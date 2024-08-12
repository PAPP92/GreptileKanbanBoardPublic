using GreptileKanbanBoardBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer; // Add this line
using Microsoft.Extensions.Configuration;

namespace GreptileKanbanBoardBackend.Data
{
    public class KanbanContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public KanbanContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Column> Columns { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
