using Internship_7_Moodle.Domain.Entities.Chats;
using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Entities.Messages;
using Internship_7_Moodle.Domain.Entities.PivotTables;
using Internship_7_Moodle.Domain.Entities.Roles;
using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Enumerations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Database.Seed;

public static class Seeder
{
    private static string HashPassword(User user)
    {
        var hasher = new PasswordHasher<User>();
        return hasher.HashPassword(user, user.Password);
    }

    private static void HashAllPasswords(User[] users)
    {
        foreach (var user in users)
        {
            user.Password = HashPassword(user);
        }
    }

    public static void SeedData(ModelBuilder modelBuilder)
    {
        var seedTime=new DateTime(2025, 09, 01);
        
        RoleSeed(modelBuilder,seedTime);
        UserDataSeed(modelBuilder,seedTime);
        CourseSeed(modelBuilder,seedTime);
        CourseUserDataSeed(modelBuilder,seedTime);
        NotificationSeed(modelBuilder);
        MaterialSeed(modelBuilder,seedTime);
        PrivateMessageSeed(modelBuilder);
        ChatSeed(modelBuilder);

    }

    private static void RoleSeed(ModelBuilder modelBuilder,DateTime seedTime)
    {
        const string studentDescription = "Može samo gledati podatke o kolegijima (nema prava da išta izmijeni)";
        const string professorDescription = "Može dodavati studente u kolegije te slati obavijesti i materijale";
        const string adminDescription = "Ima ovlasti brisati i dodavati korisnike bilo koje uloge";
        
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, RoleName = RoleEnum.Student, Description = "Može samo gledati podatke o kolegijima (nema prava da išta izmijeni)", CreatedAt = seedTime, UpdatedAt = seedTime },
            new Role { Id = 2, RoleName = RoleEnum.Professor, Description = "Može dodavati studente u kolegije te slati obavijesti i materijale", CreatedAt = seedTime, UpdatedAt = seedTime },
            new Role { Id = 3, RoleName = RoleEnum.Admin, Description = "Ima ovlasti brisati i dodavati korisnike bilo koje uloge", CreatedAt = seedTime, UpdatedAt = seedTime }
        );
    }
    private static void UserDataSeed(ModelBuilder modelBuilder, DateTime seedTime)
    {
        var users = new[]
        {
            new User
            {
                Id = 1,
                Email = "zandzartz@gmail.com",
                Password = "FujF48Ym#",
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateOnly(2000, 04, 04),
                Gender = GenderEnum.M,
                RoleId = 1,
                CreatedAt = seedTime,
                UpdatedAt = seedTime
            },
            new User
            {
                Id = 2,
                Email = "dorianleci@gmail.com",
                Password = "FujF48Ym#",
                FirstName = "Dorian",
                LastName = "Leci",
                BirthDate = new DateOnly(2000, 03, 03),
                Gender = GenderEnum.M,
                RoleId = 1,
                CreatedAt = seedTime,
                UpdatedAt = seedTime
            },
            new User
            {
                Id = 3,
                Email = "damirleci@gmail.com",
                Password = "StudentDamir#",
                FirstName = "Damir",
                LastName = "Leci",
                BirthDate = new DateOnly(2004, 03, 28),
                Gender = GenderEnum.M,
                RoleId = 1,
                CreatedAt = seedTime,
                UpdatedAt = seedTime
            },
            new User
            {
                Id = 4,
                Email = "vesnaleci@gmail.com",
                Password = "StudentVesna#",
                FirstName = "Vesna",
                LastName = "Leci",
                BirthDate = new DateOnly(2005, 11, 28),
                Gender = GenderEnum.F,
                RoleId = 1,
                CreatedAt = seedTime,
                UpdatedAt = seedTime
            },
            new User
            {
                Id = 5,
                Email = "zoraleci@gmail.com",
                Password = "StudentZora#",
                FirstName = "Zora",
                LastName = "Leci",
                BirthDate = new DateOnly(1990, 10, 12),
                Gender = GenderEnum.F,
                RoleId = 1,
                CreatedAt = seedTime,
                UpdatedAt = seedTime
            },
            new User
            {
                Id = 6,
                Email = "ivoivić@gmail.com",
                Password = "ProfIvo#",
                FirstName = "Ivo",
                LastName = "Ivić",
                BirthDate = new DateOnly(1989, 9, 12),
                Gender = GenderEnum.M,
                RoleId = 2,
                CreatedAt = seedTime,
                UpdatedAt = seedTime
            },
            new User
            {
                Id = 7,
                Email = "petarpetrović@gmail.com",
                Password = "ProfPetar#",
                FirstName = "Petar",
                LastName = "Petrović",
                BirthDate = new DateOnly(1988, 9, 12),
                Gender = GenderEnum.M,
                RoleId = 2,
                CreatedAt = seedTime,
                UpdatedAt = seedTime
            },
            new User
            {
                Id = 8,
                Email = "majamajić@gmail.com",
                Password = "ProfMaja#",
                FirstName = "Maja",
                LastName = "Majić",
                BirthDate = new DateOnly(1995, 01, 01),
                Gender = GenderEnum.F,
                RoleId = 2,
                CreatedAt = seedTime,
                UpdatedAt = seedTime
            },
            new User
            {
                Id = 9,
                Email = "vesnavesnić@gmail.com",
                Password = "ProfVesna#",
                FirstName = "Vesna",
                LastName = "Vesnić",
                BirthDate = new DateOnly(1997, 02, 02),
                Gender = GenderEnum.F,
                RoleId = 2,
                CreatedAt = seedTime,
                UpdatedAt = seedTime
            },
            new User
            {
                Id = 10,
                Email = "sebaleci@gmail.com",
                Password = "AdminSeba#",
                FirstName = "Sebastian",
                LastName = "Leci",
                BirthDate = new DateOnly(1997, 03, 08),
                Gender = GenderEnum.M,
                RoleId = 3,
                CreatedAt = seedTime,
                UpdatedAt = seedTime
            }
        };

        HashAllPasswords(users);
        modelBuilder.Entity<User>().HasData(users);
}



    private static void CourseSeed(ModelBuilder modelBuilder,DateTime seedTime)
    {
        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                Id=1,
                Name = "Matematika 1",
                Description = "Osnove algebre i teorije brojeva.",
                Ects = 7,
                OwnerId = 6,
                CreatedAt =seedTime,
                UpdatedAt = seedTime
            },
            new Course
            {
                Id=2,
                Name = "Matematika 2",
                Description = "Integrali i diferencijalne jednadžbe.",
                Ects = 7,
                OwnerId = 7,
                CreatedAt = seedTime,
                UpdatedAt = seedTime
            },
            new Course
            {
                Id=3,
                Name = "Objektno orijentirano programiranje",
                Description = "Osnovni koncepti OOP-a",
                Ects = 6,
                OwnerId = 8,
                CreatedAt = seedTime,
                UpdatedAt = seedTime
            },
            new Course
            {
                Id=4,
                Name = "Algoritmi",
                Description =
                    "Proučavanje vremena izvršavanja i optimizacije algoritama za sortiranje i pretraživanje.",
                Ects = 6,
                OwnerId = 9,
                CreatedAt = seedTime,
                UpdatedAt = seedTime
            });       
    }

    private static void CourseUserDataSeed(ModelBuilder modelBuilder,DateTime seedTime)
    {
        modelBuilder.Entity<CourseUser>().HasData(
            new CourseUser { Id=1,UserId = 1, CourseId = 1, CreatedAt = seedTime, UpdatedAt = seedTime},
            new CourseUser { Id=2,UserId = 2, CourseId = 1, CreatedAt = seedTime, UpdatedAt = seedTime},
            new CourseUser { Id=3,UserId = 3, CourseId = 1, CreatedAt = seedTime, UpdatedAt = seedTime },
            new CourseUser { Id=4,UserId = 4, CourseId = 1, CreatedAt =  seedTime, UpdatedAt = seedTime },
            
            new CourseUser { Id=5,UserId = 3, CourseId = 2, CreatedAt = seedTime,UpdatedAt = seedTime },
            new CourseUser { Id=6,UserId = 4, CourseId = 2, CreatedAt = seedTime,UpdatedAt = seedTime },
            new CourseUser { Id=7,UserId = 5, CourseId = 2, CreatedAt = seedTime, UpdatedAt = seedTime },
            
            new CourseUser { Id=8,UserId = 1, CourseId = 3, CreatedAt = seedTime,UpdatedAt = seedTime},
            new CourseUser { Id=9,UserId = 2, CourseId = 3, CreatedAt = seedTime,UpdatedAt = seedTime },
            new CourseUser { Id=10,UserId = 3, CourseId = 3, CreatedAt = seedTime,UpdatedAt = seedTime },
            new CourseUser { Id=11,UserId = 4, CourseId = 3, CreatedAt = seedTime,UpdatedAt = seedTime },
            
            new CourseUser { Id=12,UserId = 1, CourseId = 4, CreatedAt = seedTime,UpdatedAt = seedTime },
            new CourseUser { Id=13,UserId = 4, CourseId = 4, CreatedAt = seedTime,UpdatedAt = seedTime },
            new CourseUser { Id=14,UserId = 5, CourseId = 4, CreatedAt = seedTime,UpdatedAt = seedTime });
    }

    private static void NotificationSeed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseNotification>().HasData(
            new CourseNotification
            {
                Id=1,
                Subject="Otkazano predavanje",
                Content="Poštovani,\nzbog bolesti otkazujem sutrašnje predavanje.",
                CourseId=1,
                CreatedAt = new DateTime(2025, 10, 26, 11, 10, 0),
                UpdatedAt = new DateTime(2025, 10, 26, 11, 10, 0)
            },
            new CourseNotification
            {
                Id=2,
                Subject="Prvi kolokvij",
                Content="Poštovani,\nsutra se održava prvi kolokvij iz kolegija Matematika 1.\nMolimo ponesite iksice i pribor za pisanje.Ostalo je zabranjeno.",
                CourseId =1,
                CreatedAt = new DateTime(2025, 11, 26, 08, 15, 0),
                UpdatedAt = new DateTime(2025, 11, 26, 08, 15, 0)
            },
            new CourseNotification
            {
                Id=3,
                Subject="Drugi kolokvij",
                Content="Poštovani,\nNapomena: tko nije položio prvi kolokvij ne može izaći na drugi.Morati će čekati do ispitnog roka.",
                CourseId =1,
                CreatedAt = new DateTime(2025, 11, 30, 08, 15, 0),
                UpdatedAt =  new DateTime(2025, 11, 30, 08, 15, 0)
            },
            new CourseNotification
            {
                Id=4,
                Subject="Teorijski ispit za bodove",
                Content="Poštovani,\nna predavanju idući tjedan održati će se teorijski ispit za dodatne bodove.\nGradivo koje ulazi u ispit: Dvostruki integrali.",
                CourseId =2,
                CreatedAt = new DateTime(2025, 11, 18, 09, 15, 0),
                UpdatedAt = new DateTime(2025, 11, 18, 09, 15, 0)
            },
            new CourseNotification
            {
                Id=5,
                Subject="Rezultati prvog kolokvija",
                Content="Poštovani,\nu prilogu se nalaze rezultati kolokvija.\nhttps://moodle.rezultati/prvi_kolokvij.pdf",
                CourseId =2,
                CreatedAt = new DateTime(2025, 11, 29, 10, 30, 0),
                UpdatedAt = new DateTime(2025, 11, 29, 10, 30, 0)
            },
            new CourseNotification
            {
                Id=6,
                Subject="Praktični rad",
                Content="Poštovani,\nrok za predaju praktičnog rada kojeg smo spominjali na predavanju je 10.1.2026.\nOcjena iz praktičnog rada nosi 40% završne ocjene.",
                CourseId =3,
                CreatedAt = new DateTime(2025, 12, 01, 07, 45, 0),
                UpdatedAt =  new DateTime(2025, 12, 01, 07, 45, 0)
            },
            new CourseNotification
            {
                Id=7,
                Subject="Promjena dvorane",
                Content="Poštovani,\nsutrašnje predavanje održati će se u sali A102 (umjesto u predviđenoj A302)",
                CourseId =3,
                CreatedAt = new DateTime(2025, 11, 01, 07, 45, 0),
                UpdatedAt =  new DateTime(2025, 11, 01, 07, 45, 0)
            },
            new CourseNotification
            {
                Id=8,
                Subject="Laboratorijske vježbe",
                Content="Poštovani,\nidući tjedan (8.10.) počinju laboratorijske vježbe iz kolegija algoritmi.",
                CourseId =4,
                CreatedAt = new DateTime(2025, 10, 01, 07, 45, 0),
                UpdatedAt = new  DateTime(2025, 10, 01, 07, 45, 0)
            },
            new CourseNotification
            {
                Id=9,
                Subject="Promjena rasporeda",
                Content="Poštovani,\nidući tjedan (25.10.) predavanje će se održati s početkom u 11:45 (umjesto 10:45) u sali A101.",
                CourseId =4,
                CreatedAt = new DateTime(2025, 10, 18, 07, 45, 0),
                UpdatedAt = new   DateTime(2025, 10, 18, 07, 45, 0)
            }          
            
        );

    }

    private static void MaterialSeed(ModelBuilder builder, DateTime seedTime)
    {
        builder.Entity<CourseMaterial>().HasData(
            new CourseMaterial
            {
                Id = 1,
                CourseId = 1,
                CreatedAt = seedTime,
                UpdatedAt = seedTime,
                
                Title="Matematika1 FESB",
                AuthorName = "Ivo Ivić",
                PublishedDate =  new DateOnly(2015,01,01),
                Url="https://fesbmaterijali.net/ivo/Matematika1%20FESB.pdf"
            },
            new CourseMaterial
            {
                Id = 2,
                CourseId = 1,
                CreatedAt = seedTime,
                UpdatedAt = seedTime,
                
                Title="Zbirka zadataka 2015",
                AuthorName = "Ivo Ivić",
                PublishedDate =  new DateOnly(2015,01,01),
                Url="https://fesbmaterijali.net/ivo/Zbirka%zadataka%2015/"
            },
            
            new CourseMaterial
            {
                Id = 3,
                CourseId = 2,
                CreatedAt = seedTime,
                UpdatedAt = seedTime,
                
                Title="Uvod u viševarijabilni račun",
                AuthorName = "Petar Petrović",
                PublishedDate =  new DateOnly(2017,03,28),
                Url="https://fesbmaterijali.net/petar/multivariable%calculus/"
            },
            new CourseMaterial
            {
                Id = 4,
                CourseId = 2,
                CreatedAt = seedTime,
                UpdatedAt = seedTime,
                
                Title="Uvod u integralni račun",
                AuthorName = "Petar Petrović",
                PublishedDate =  new DateOnly(2018,04,27),
                Url="https://fesbmaterijali.net/petar/integrals%book/"
            },
            new CourseMaterial
            {
                Id = 5,
                CourseId = 3,
                CreatedAt = seedTime,
                UpdatedAt = seedTime,
                
                Title="OOP skripta, FESB 2003",
                AuthorName = "Marjan Marjanović",
                PublishedDate =  new DateOnly(2003,11,11),
                Url="https://fesbmaterijali.net/marjanovic/oop%skripta/"
            },
            new CourseMaterial
            {
                Id = 6,
                CourseId = 3,
                CreatedAt = seedTime,
                UpdatedAt = seedTime,
                
                Title="The C++ programming Language",
                AuthorName = "Bjourn Stroustrup",
                PublishedDate =  new DateOnly(1986,02,27),
                Url="https://www.stroustrup.com/4th.html"
            },
            new CourseMaterial
            {
                Id = 7,
                CourseId = 4,
                CreatedAt = seedTime,
                UpdatedAt = seedTime,
                
                Title="„Algoritmi“, interna skripta",
                AuthorName = "Hrvoje Hrvojić",
                PublishedDate =  new DateOnly(2010,02,27),
                Url="https://fesbmaterijali.net/hrvojic/interna%skripta/"
            },
            new CourseMaterial
            {
                Id = 8,
                CourseId = 4,
                CreatedAt = seedTime,
                UpdatedAt = seedTime,
                
                Title="„Introduction to Algorithms“, second edition",
                AuthorName = "T.Cormen",
                PublishedDate =  new DateOnly(202,05,14),
                Url="https://www.cs.mcgill.ca/~akroit/math/compsci/Cormen%20Introduction%20to%20Algorithms.pdf"
            }
            
            
            );

    }


    private static void PrivateMessageSeed(ModelBuilder builder)
    {
        builder.Entity<PrivateMessage>().HasData(
            new PrivateMessage 
            { 
                Id = 1, 
                CreatedAt = new DateTime(2025, 11, 11, 07, 45, 0),
                UpdatedAt = new DateTime(2025, 10, 01, 07, 45, 0),
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
                       "Polimorfizam je koncept u objektno-orijentiranom programiranju koji omogućava da se ista metoda ili operacija ponaša različito ovisno o tipu objekta koji je poziva.\n" +
                       "U praksi, to znači da možete imati baznu klasu s apstraktnom ili virtualnom metodom, a različite izvedene klase mogu implementirati tu metodu na svoj način.\n" +
                       "Kada pozovete metodu preko referenci na baznu klasu, program automatski izvršava implementaciju odgovarajuće izvedene klase.\n" +
                       "Ako želite, možemo na primjeru vaše konzolne aplikacije s MenuManager klasama pokazati kako polimorfizam radi u stvarnom kodu.\n" +
                       "Nadam se da ovo pojašnjava. Javite ako želite detaljniji primjer koda.",
                
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

    private static void ChatSeed(ModelBuilder builder)
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
