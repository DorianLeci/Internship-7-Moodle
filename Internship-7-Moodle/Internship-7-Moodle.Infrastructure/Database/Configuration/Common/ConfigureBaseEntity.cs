using Internship_7_Moodle.Domain.Common.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internship_7_Moodle.Infrastructure.Database.Configuration.Common;

public static class ConfigureBaseEntity
{
    public static void Configure<T>(this EntityTypeBuilder<T> builder) where T:BaseEntity
    {
        builder.Property(u => u.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("NOW()")
            .IsRequired();

        builder.Property(u => u.UpdatedAt)
            .HasColumnName("updated_at")
            .HasDefaultValueSql("NOW()")
            .IsRequired();
    }
}