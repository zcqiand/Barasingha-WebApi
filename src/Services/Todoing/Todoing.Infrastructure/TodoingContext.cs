using Microsoft.EntityFrameworkCore;
using UltraNuke.Barasingha.Todoing.Domain.AggregatesModel;

namespace UltraNuke.Barasingha.Todoing.Infrastructure
{
    public partial class TodoingContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public TodoingContext(DbContextOptions<TodoingContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
