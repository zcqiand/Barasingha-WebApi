using Microsoft.EntityFrameworkCore;
using UltraNuke.Barasingha.Novel.Domain.AggregatesModel;

namespace UltraNuke.Barasingha.Novel.Infrastructure
{
    public partial class NovelContext : DbContext
    {
        public NovelContext(DbContextOptions<NovelContext> options)
            : base(options)
        {

        }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Segment> Segments { get; set; }
        public DbSet<Chapter> Chapters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
