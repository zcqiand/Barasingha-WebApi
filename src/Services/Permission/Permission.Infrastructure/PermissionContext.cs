using Microsoft.EntityFrameworkCore;
using UltraNuke.Barasingha.Permission.Domain.AggregatesModel;

namespace UltraNuke.Barasingha.Permission.Infrastructure
{
    public partial class PermissionContext : DbContext
    {
        public PermissionContext(DbContextOptions<PermissionContext> options)
            : base(options)
        {

        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<User>()
                .HasMany(p => p.Roles)
                .WithMany(p => p.Users)
                .UsingEntity(j => j.ToTable("S_UserRole"));

            modelBuilder
                .Entity<Role>()
                .HasMany(p => p.Menus)
                .WithMany(p => p.Roles)
                .UsingEntity(j => j.ToTable("S_RoleMenu"));
        }
    }
}
