using Microsoft.EntityFrameworkCore;
using UltraNuke.Barasingha.Permission.API.Application.DTO;

namespace UltraNuke.Barasingha.Permission.API.Infrastructure
{
    public partial class PermissionQueriesContext : DbContext
    {
        public DbSet<MenuDTO> Menus { get; set; }
        public DbSet<RoleDTO> Roles { get; set; }
        public DbSet<UserDTO> Users { get; set; }

        public PermissionQueriesContext(DbContextOptions<PermissionQueriesContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UserDTO>()
                .HasMany(p => p.Roles)
                .WithMany(p => p.Users)
                .UsingEntity(j => j.ToTable("S_UserRole"));

            modelBuilder
                .Entity<RoleDTO>()
                .HasMany(p => p.Menus)
                .WithMany(p => p.Roles)
                .UsingEntity(j => j.ToTable("S_RoleMenu"));
        }
    }
}
