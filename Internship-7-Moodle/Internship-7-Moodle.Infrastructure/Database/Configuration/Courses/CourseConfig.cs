using Internship_7_Moodle.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internship_7_Moodle.Infrastructure.Database.Configuration.Courses;

public class CourseConfig:IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("course");
        
        builder.HasKey(c=>c.Id);
        
        builder.Property(c=>c.Id).HasColumnName("id");
        
        builder.Property(c=>c.Name).HasColumnName("name").IsRequired();
        
        builder.Property(c=>c.Description).HasColumnName("description").IsRequired();
        
        builder.Property(c=>c.Ects).HasColumnName("ects").IsRequired();
        
        builder.HasOne(c=>c.Owner).WithOne().HasForeignKey<Course>(c=>c.OwnerId);
        builder.Property(c=>c.OwnerId).HasColumnName("owner_id");
        
    }
}