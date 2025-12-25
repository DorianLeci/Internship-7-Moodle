using Internship_7_Moodle.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internship_7_Moodle.Infrastructure.Database.Configuration.Courses;

public class CourseNotificationConfig:IEntityTypeConfiguration<CourseNotification>
{
    public void Configure(EntityTypeBuilder<CourseNotification> builder)
    {
        builder.ToTable("course_notification");
        
        builder.HasKey(cn=>cn.Id);
        builder.Property(cn=>cn.Id).HasColumnName("id");
        
        builder.Property(cn=>cn.Subject).HasColumnName("subject").IsRequired();
        builder.Property(cn=>cn.Content).HasColumnName("content").IsRequired();
        
        builder.HasOne(cn=>cn.Course).WithMany(c=>c.Notifications).HasForeignKey(cn=>cn.CourseId).IsRequired();
        
        builder.Property(cn => cn.CourseId).HasColumnName("course_id");
        
    }
}