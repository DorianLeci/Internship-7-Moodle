using Internship_7_Moodle.Domain.Entities.Chats;
using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Entities.Messages;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Database.Seed;

internal static partial class Seeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        var seedTime=new DateTime(2025, 09, 01);
        
        RoleData.RoleSeed(modelBuilder,seedTime);
        UserData.UserDataSeed(modelBuilder,seedTime);
        CourseData.CourseDataSeed(modelBuilder,seedTime);
        CourseData.CourseUserDataSeed(modelBuilder,seedTime);
        NotificationData.NotificationSeed(modelBuilder);
        MaterialData.MaterialSeed(modelBuilder,seedTime);
        MessageData.PrivateMessageSeed(modelBuilder);
        ChatData.ChatSeed(modelBuilder);
    }
    
    
}
