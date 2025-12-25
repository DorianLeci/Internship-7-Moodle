using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Entities.Messages;
using Internship_7_Moodle.Domain.Entities.PivotTables;
using Internship_7_Moodle.Infrastructure.Database.Configuration.Common;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Database;

public sealed class ApplicationDbContext:DbContext
{
    public DbSet<Domain.Entities.Users.User> Users { get; set; }
    public DbSet<Domain.Entities.Roles.Role> Roles { get; set; }
    public DbSet<CourseUser> CourseUsers { get; set; }
    public DbSet<PrivateMessage> PrivateMessages { get; set; }
    public DbSet<CourseNotification> CourseNotifications { get; set; }
    public DbSet<CourseMaterial> CourseMaterials { get; set; }
    public DbSet<Course> Courses { get; set; }
    
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.HasDefaultSchema(Schemas.Default);
        
        modelBuilder.Entity<Domain.Entities.Users.User>().Configure();
        modelBuilder.Entity<Domain.Entities.Roles.Role>().Configure();
        modelBuilder.Entity<CourseUser>().Configure();
        modelBuilder.Entity<PrivateMessage>().Configure();
        modelBuilder.Entity<CourseNotification>().Configure();
        modelBuilder.Entity<CourseMaterial>().Configure();
        modelBuilder.Entity<Course>().Configure();
    }
}