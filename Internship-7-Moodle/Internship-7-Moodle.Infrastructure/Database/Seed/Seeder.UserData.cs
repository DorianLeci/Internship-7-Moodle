using Internship_7_Moodle.Domain.Entities.Users;
using Internship_7_Moodle.Domain.Enumerations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Database.Seed;

internal static partial class Seeder
{
    private static class UserData
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
        
        public static void UserDataSeed(ModelBuilder modelBuilder, DateTime seedTime)
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
                    CreatedAt = DateTime.Now.AddDays(-5),
                    UpdatedAt = DateTime.Now.AddDays(-5)
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
                },
                new User
                {
                    Id = 11,
                    Email = "nikolaf@gmail.com",
                    Password = "StudentNikola#",
                    FirstName = "Nikola",
                    LastName = "Filipović",
                    BirthDate = new DateOnly(1997, 03, 08),
                    Gender = GenderEnum.M,
                    RoleId = 1,
                    CreatedAt = DateTime.Now.AddMonths(-1),
                    UpdatedAt = DateTime.Now.AddMonths(-1)
                },
                new User
                {
                    Id = 12,
                    Email = "tonic@gmail.com",
                    Password = "StudentToni#",
                    FirstName = "Toni",
                    LastName = "Crnčić",
                    BirthDate = new DateOnly(2004, 03, 08),
                    Gender = GenderEnum.M,
                    RoleId = 1,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new User
                {
                    Id = 13,
                    Email = "marijah@gmail.com",
                    Password = "StudentMarija#",
                    FirstName = "Marija",
                    LastName = "Hanić",
                    BirthDate = new DateOnly(2005, 03, 10),
                    Gender = GenderEnum.F,
                    RoleId = 1,
                    CreatedAt = DateTime.Now.AddDays(-10),
                    UpdatedAt = DateTime.Now.AddDays(-10)
                },
                new User
                {
                    Id = 14,
                    Email = "tomislavt@gmail.com",
                    Password = "StudentTomislav#",
                    FirstName = "Tomislav",
                    LastName = "Turjan",
                    BirthDate = new DateOnly(2005, 03, 27),
                    Gender = GenderEnum.M,
                    RoleId = 1,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new User
                {
                    Id = 15,
                    Email = "emabolj@gmail.com",
                    Password = "StudentEma#",
                    FirstName = "Ema",
                    LastName = "Boljevčan",
                    BirthDate = new DateOnly(2001, 11, 03),
                    Gender = GenderEnum.F,
                    RoleId = 1,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new User
                {
                    Id = 16,
                    Email = "lukajer@gmail.com",
                    Password = "StudentLuka#",
                    FirstName = "Luka",
                    LastName = "Jerković",
                    BirthDate = new DateOnly(2003, 10, 17),
                    Gender = GenderEnum.M,
                    RoleId = 1,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new User
                {
                    Id = 17,
                    Email = "matijam@gmail.com",
                    Password = "ProfMatija#",
                    FirstName = "Matija",
                    LastName = "Matijović",
                    BirthDate = new DateOnly(1977, 10, 17),
                    Gender = GenderEnum.M,
                    RoleId = 2,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new User
                {
                    Id = 18,
                    Email = "mirkom@gmail.com",
                    Password = "ProfMirko#",
                    FirstName = "Mirko",
                    LastName = "Mirković",
                    BirthDate = new DateOnly(1978, 10, 19),
                    Gender = GenderEnum.M,
                    RoleId = 2,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new User
                {
                    Id = 19,
                    Email = "tarat@gmail.com",
                    Password = "ProfTara#",
                    FirstName = "Tara",
                    LastName = "Tarić",
                    BirthDate = new DateOnly(1979, 10, 19),
                    Gender = GenderEnum.F,
                    RoleId = 2,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new User
                {
                    Id = 20,
                    Email = "zlatkol@gmail.com",
                    Password = "ProfZlatko#",
                    FirstName = "Zlatko",
                    LastName = "Leci",
                    BirthDate = new DateOnly(1960, 11, 19),
                    Gender = GenderEnum.M,
                    RoleId = 2,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new User
                {
                    Id = 21,
                    Email = "dragol@gmail.com",
                    Password = "ProfesorDrago#",
                    FirstName = "Drago",
                    LastName = "Leci",
                    BirthDate = new DateOnly(1955, 05, 05),
                    Gender = GenderEnum.M,
                    RoleId = 2,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new User
                {
                    Id = 22,
                    Email = "novikorisnik@gmail.com",
                    Password = "StudentKorisnik#",
                    FirstName = "Korisnik",
                    LastName = "Novi",
                    BirthDate = new DateOnly(2000, 05, 05),
                    Gender = GenderEnum.M,
                    RoleId = 1,
                    CreatedAt = DateTime.Now.AddDays(-1),
                    UpdatedAt = DateTime.Now.AddDays(-1)
                },
                new User
                {
                    Id = 23,
                    Email = "karlok@gmail.com",
                    Password = "StudentKarlo#",
                    FirstName = "Karlo",
                    LastName = "Karlović",
                    BirthDate = new DateOnly(2002, 04, 15),
                    Gender = GenderEnum.M,
                    RoleId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new User
                {
                    Id = 24,
                    Email = "markom@gmail.com",
                    Password = "StudentMarko#",
                    FirstName = "Marko",
                    LastName = "Marković",
                    BirthDate = new DateOnly(2002, 04, 15),
                    Gender = GenderEnum.M,
                    RoleId = 1,
                    CreatedAt = DateTime.Now.AddDays(-1),
                    UpdatedAt = DateTime.Now.AddDays(-1)
                },
                new User
                {
                    Id = 25,
                    Email = "marijanm@gmail.com",
                    Password = "ProfMarijan#",
                    FirstName = "Marijan",
                    LastName = "Marjanović",
                    BirthDate = new DateOnly(1983, 02, 17),
                    Gender = GenderEnum.M,
                    RoleId = 2,
                    CreatedAt = DateTime.Now.AddDays(-1),
                    UpdatedAt = DateTime.Now.AddDays(-1)
                },
                new User
                {
                    Id = 26,
                    Email = "zoranz@gmail.com",
                    Password = "ProfZoran#",
                    FirstName = "Zoran",
                    LastName = "Zoranović",
                    BirthDate = new DateOnly(1978, 02, 18),
                    Gender = GenderEnum.M,
                    RoleId = 2,
                    CreatedAt = DateTime.Now.AddDays(-2),
                    UpdatedAt = DateTime.Now.AddDays(-2)
                },
                new User
                {
                    Id = 27,
                    Email = "zrinkaz@gmail.com",
                    Password = "ProfZrinka#",
                    FirstName = "Zrinka",
                    LastName = "Zrinković",
                    BirthDate = new DateOnly(1979, 02, 18),
                    Gender = GenderEnum.F,
                    RoleId = 2,
                    CreatedAt = DateTime.Now.AddDays(-3),
                    UpdatedAt = DateTime.Now.AddDays(-3)
                }
            };

            HashAllPasswords(users);
            modelBuilder.Entity<User>().HasData(users);
    }
        
    }
}