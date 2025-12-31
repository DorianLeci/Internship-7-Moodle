using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internship_7_Moodle.Infrastructure.Database.Configuration.Messages;

public class PrivateMessageConfig:IEntityTypeConfiguration<Domain.Entities.Messages.PrivateMessage>
{
    
    public void Configure(EntityTypeBuilder<Domain.Entities.Messages.PrivateMessage> builder)
    {
        builder.ToTable("private_messages");

        builder.HasKey(pm=>pm.Id);
        builder.Property(pm=>pm.Id).HasColumnName("id");
        
        builder.Property(pm=>pm.IsRead).HasColumnName("is_read").IsRequired().HasDefaultValue(false);
        builder.Property(pm=>pm.Text).HasColumnName("text").IsRequired().HasMaxLength(Domain.Entities.Messages.PrivateMessage.MaxTextLength);
        
        builder.HasOne(pm=>pm.Receiver).WithMany(u=>u.ReceivedMessages)
            .HasForeignKey(pm=>pm.ReceiverId).IsRequired();
        
        builder.HasOne(pm=>pm.Sender).WithMany(u=>u.SentMessages)
            .HasForeignKey(pm=>pm.SenderId).IsRequired();
        
        builder.Property(pm=>pm.ReceiverId).HasColumnName("receiver_id");
        builder.Property(pm=>pm.SenderId).HasColumnName("sender_id");
        
        builder.HasOne(pm=>pm.Chat).WithMany(c=>c.PrivateMessages).HasForeignKey(pm=>pm.ChatId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        builder.Property(pm=>pm.ChatId).HasColumnName("chat_id");
        
    }
}