using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internship_7_Moodle.Infrastructure.Database.Configuration.Roles;

public class RoleConfig:IEntityTypeConfiguration<Domain.Entities.Roles.Role>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Roles.Role> builder)
    {
        builder.ToTable("roles");
        
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("id");
        builder.Property(r=>r.Description).HasColumnName("description").IsRequired();
        
        builder.Property(r => r.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(r => r.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();
    }
}