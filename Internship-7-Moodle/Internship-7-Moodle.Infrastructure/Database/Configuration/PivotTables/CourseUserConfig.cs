using Internship_7_Moodle.Domain.Entities.PivotTables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internship_7_Moodle.Infrastructure.Database.Configuration.PivotTables;

public class CourseUserConfig:IEntityTypeConfiguration<CourseUser>
{
    public void Configure(EntityTypeBuilder<CourseUser> builder)
    {
        builder.ToTable("course_users");
        
        builder.HasKey(cu=>cu.Id);
        builder.Property(cu=>cu.Id).HasColumnName("id");

        builder.HasOne(cu => cu.Course).WithMany(c => c.CourseStudents)
            .HasForeignKey(cu => cu.CourseId).IsRequired();
        
        builder.HasOne(cu => cu.User).WithMany(u=>u.CourseEnrollments)
            .HasForeignKey(cu => cu.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(cu=>cu.UserId).HasColumnName("user_id");
        builder.Property(cu=>cu.CourseId).HasColumnName("course_id");
        
    }
}