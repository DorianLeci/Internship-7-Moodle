using Internship_7_Moodle.Domain.Entities.Chats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internship_7_Moodle.Infrastructure.Database.Configuration.Chats;

public class ChatConfig:IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.ToTable("chat");
        
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("id");
        
        builder.HasOne(c => c.UserA).WithMany(u=>u.ChatsAsUserA).HasForeignKey(c => c.UserAId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(c => c.UserB).WithMany(u=>u.ChatsAsUserB).HasForeignKey(c => c.UserBId).OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(c=>c.UserAId).HasColumnName("user_a_id");
        builder.Property(c=>c.UserBId).HasColumnName("user_b_id");
    }
}