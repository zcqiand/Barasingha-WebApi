using Microsoft.EntityFrameworkCore;
using UltraNuke.Barasingha.Novel.API.Application.DTO;

namespace UltraNuke.Barasingha.Novel.API.Infrastructure
{
    public partial class NovelQueriesContext : DbContext
    {
        public NovelQueriesContext(DbContextOptions<NovelQueriesContext> options)
            : base(options)
        {

        }

        public DbSet<MainCategoryDTO> MainCategories { get; set; }
        public DbSet<SubCategoryDTO> SubCategories { get; set; }
        public DbSet<BookDTO> Books { get; set; }
        public DbSet<SegmentDTO> Segments { get; set; }
        public DbSet<ChapterDTO> Chapters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
