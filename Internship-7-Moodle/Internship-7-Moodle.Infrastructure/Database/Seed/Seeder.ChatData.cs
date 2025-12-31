using Internship_7_Moodle.Domain.Entities.Chats;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Database.Seed;

internal static partial class Seeder
{
    private static class ChatData
    {
        public static void ChatSeed(ModelBuilder builder)
        {
            builder.Entity<Chat>().HasData(
                new Chat
                {
                    Id=1,
                    UserAId = 1,
                    UserBId = 8,
                    CreatedAt = new DateTime(2025, 11, 11, 07, 45, 0),
                    UpdatedAt = new DateTime(2025, 11, 11, 07, 45, 0)
                },
                new Chat
                {
                    Id=2,
                    UserAId = 1,
                    UserBId = 10,
                    CreatedAt = new DateTime(2025, 10, 03, 09, 30, 0),
                    UpdatedAt = new DateTime(2025, 10, 03, 09, 30, 0),
                },
                new Chat
                {
                    Id=3,
                    UserAId = 1,
                    UserBId = 2,
                    CreatedAt = new DateTime(2025, 12, 03, 14, 01, 0),
                    UpdatedAt = new DateTime(2025, 12, 03, 14, 01, 0),

                }
            
            );
        }
    }
}