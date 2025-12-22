using Internship_7_Moodle.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internship_7_Moodle.Infrastructure.Database.Configuration.Courses;

public class CourseMaterialConfig:IEntityTypeConfiguration<CourseMaterial>
{
    public void Configure(EntityTypeBuilder<CourseMaterial> builder)
    {
        builder.ToTable("course_material");
        
        builder.HasKey(cm=>cm.Id);
        builder.Property(cm=>cm.Id).HasColumnName("id");
        
        builder.Property(cm=>cm.Name).HasColumnName("name").IsRequired();
        builder.Property(cm=>cm.Url).HasColumnName("url").IsRequired();
        
        builder.HasOne(cm=>cm.Course).WithMany(c=>c.Materials)
            .HasForeignKey(cm=>cm.CourseId).IsRequired();

        builder.Property(cm => cm.CourseId).HasColumnName("course_id");
        
        builder.Property(cm => cm.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(cm => cm.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();
    }
}