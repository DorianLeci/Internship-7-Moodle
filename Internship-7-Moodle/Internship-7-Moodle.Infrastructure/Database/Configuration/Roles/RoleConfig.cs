using Internship_7_Moodle.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Internship_7_Moodle.Infrastructure.Database.Configuration.Roles;

public class RoleConfig:IEntityTypeConfiguration<Domain.Entities.Roles.Role>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Roles.Role> builder)
    {
        var converter = new EnumToStringConverter<RoleEnum>();
        
        builder.ToTable("roles");
        
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("id");
        builder.Property(r=>r.Description).HasColumnName("description").IsRequired().HasMaxLength(Domain.Entities.Roles.Role.MaxDescriptionLength);
        builder.Property(r=>r.RoleName).HasConversion(converter).HasColumnName("role_name").IsRequired();
        
    }
}