using Microsoft.EntityFrameworkCore;
using UltraNuke.Barasingha.Todoing.API.Application.DTO;

namespace UltraNuke.Barasingha.Todoing.API.Infrastructure
{
    public partial class TodoingQueriesContext : DbContext
    {
        public DbSet<TodoDTO> Todos { get; set; }

        public TodoingQueriesContext(DbContextOptions<TodoingQueriesContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
