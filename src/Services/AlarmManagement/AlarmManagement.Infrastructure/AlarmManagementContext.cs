using Microsoft.EntityFrameworkCore;
using UltraNuke.Barasingha.AlarmManagement.Domain.AggregatesModel;

namespace UltraNuke.Barasingha.AlarmManagement.Infrastructure
{
    public partial class AlarmManagementContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<AlarmEvidence> AlarmEvidences { get; set; }
        public DbSet<AlarmWaitingStaff> AlarmWaitingStaffs { get; set; }
        public DbSet<Dispatch> Dispatchs { get; set; }
        public DbSet<DispatchCondition> DispatchConditions { get; set; }
        public DbSet<DispatchUser> DispatchUsers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationItem> NotificationItems { get; set; }

        public AlarmManagementContext(DbContextOptions<AlarmManagementContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
