using Internship_7_Moodle.Domain.Entities.Courses.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internship_7_Moodle.Infrastructure.Database.Configuration.Courses;

public class CourseMaterialConfig:IEntityTypeConfiguration<CourseMaterial>
{
    public void Configure(EntityTypeBuilder<CourseMaterial> builder)
    {
        builder.ToTable("course_materials");
        
        builder.HasKey(cm=>cm.Id);
        builder.Property(cm=>cm.Id).HasColumnName("id");
        
        builder.Property(cm=>cm.Title).HasColumnName("title").IsRequired().HasMaxLength(CourseMaterial.MaxTitleLength);
        
        builder.Property(cm=>cm.AuthorName).HasColumnName("author_name").IsRequired().HasMaxLength(CourseMaterial.MaxAuthorNameLength);
        
        builder.Property(cm=>cm.PublishedDate).HasColumnName("published_date");
        
        builder.Property(cm=>cm.Url).HasColumnName("url").IsRequired();
        
        builder.HasOne(cm=>cm.Course).WithMany(c=>c.Materials)
            .HasForeignKey(cm=>cm.CourseId).IsRequired();

        builder.Property(cm => cm.CourseId).HasColumnName("course_id");
        
    }
}