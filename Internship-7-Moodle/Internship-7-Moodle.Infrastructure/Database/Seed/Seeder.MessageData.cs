using Internship_7_Moodle.Domain.Entities.Messages;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Database.Seed;

internal static partial class Seeder
{
    private static class MessageData
    { 
        public static void PrivateMessageSeed(ModelBuilder builder)
        {
            builder.Entity<PrivateMessage>().HasData(
                new PrivateMessage 
                { 
                    Id = 1, 
                    CreatedAt = new DateTime(2025, 11, 11, 07, 45, 0),
                    UpdatedAt = new DateTime(2025, 11, 11, 07, 45, 0),
                    Text="Poštovani,\nimam nedoumica u vezi predavanja o polimorfizmu i nasljeđivanju.Možete li dodatno pojasniti polimorfizam.", 
                    SenderId = 1, 
                    ReceiverId = 8, 
                    ChatId =1,
                    IsRead = true 
                },
                new PrivateMessage
                {
                    Id = 2,
                    CreatedAt = new DateTime(2025, 11, 11, 09, 45, 0),
                    UpdatedAt = new DateTime(2025, 11, 11, 09, 45, 0),
                    Text = "Poštovani,\n" +
                           "Hvala na pitanju! 🙂\n" +
                           "Polimorfizam u OOP-u omogućava da ista metoda ima različito ponašanje ovisno o tipu objekta. " +
                           "Primjer: bazna klasa definira metodu, a izvedene klase je implementiraju na svoj način.",
                    
                    SenderId = 8,
                    ReceiverId = 1,
                    ChatId=1,
                    IsRead = true
                },
                
                new PrivateMessage
                {
                    Id = 3, 
                    CreatedAt = new DateTime(2025, 10, 03, 09, 30, 0),
                    UpdatedAt = new DateTime(2025, 10, 03, 09, 30, 0),
                    Text="Poštovani,\nimam pitanje u vezi ažuriranja profila.Na kraju godine ću postati profesor te sam htio pitati je li moguća promjena uloge.", 
                    SenderId = 1, 
                    ReceiverId = 10, 
                    ChatId =2,
                    IsRead = true                 
                },
                new PrivateMessage
                {
                    Id = 4, 
                    CreatedAt = new DateTime(2025, 10, 03, 09, 45, 0),
                    UpdatedAt = new DateTime(2025, 10, 03, 09, 45, 0),
                    Text="Poštovani,\nvaša uloga će biti promijenjena kada postanete profesor,pratiti ćemo novosti.", 
                    SenderId = 10, 
                    ReceiverId = 1, 
                    ChatId=2,
                    IsRead = true                 
                },
                new PrivateMessage
                {
                    Id = 5, 
                    CreatedAt = new DateTime(2025, 12, 03, 14, 01, 0),
                    UpdatedAt = new DateTime(2025, 12, 03, 14, 01, 0),
                    Text="Bok,jel imaš skriptu iz Matematike 1 slučajno?", 
                    SenderId = 1, 
                    ReceiverId = 2, 
                    ChatId=3,
                    IsRead = true                 
                },
                new PrivateMessage
                {
                    Id = 6, 
                    CreatedAt = new DateTime(2025, 12, 03, 14, 07, 0),
                    UpdatedAt = new DateTime(2025, 12, 03, 14, 07, 0),
                    Text="Bok,imam naravno,sutra ti dam na faksu.", 
                    SenderId = 2, 
                    ReceiverId = 1, 
                    ChatId=3,
                    IsRead = true                 
                }
                
                );
            
            
        }
    }
}