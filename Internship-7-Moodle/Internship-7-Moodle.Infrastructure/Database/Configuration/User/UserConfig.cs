using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internship_7_Moodle.Infrastructure.Database.Configuration.User;

public class UserConfig:IEntityTypeConfiguration<Domain.Entities.Users.User>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Users.User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.Id).HasColumnName("id");
        builder.Property(u => u.FirstName).HasColumnName("first_name").IsRequired().HasMaxLength(Domain.Entities.Users.User.MaxFirstNameLength);
        builder.Property(u => u.LastName).HasColumnName("last_name").IsRequired().HasMaxLength(Domain.Entities.Users.User.MaxLastNameLength);
        builder.Property(u=>u.BirthDate).HasColumnName("birth_date").IsRequired();
        builder.Property(u => u.Email).HasColumnName("email").IsRequired().HasMaxLength(Domain.Entities.Users.User.MaxEmailLength);
        builder.Property(u => u.Password).HasColumnName("password").IsRequired();
        builder.Property(u=>u.Gender).HasConversion<string>().HasColumnName("gender");
        
        builder.HasOne(u=>u.Role).WithMany().HasForeignKey(u=>u.RoleId).OnDelete(DeleteBehavior.Restrict);
        builder.Property(u=>u.RoleId).HasColumnName("role_id").IsRequired();
        

    }
}