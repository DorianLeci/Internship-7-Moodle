using Internship_7_Moodle.Domain.Entities.Courses;
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
        RoleSeed(modelBuilder);
        UserDataSeed(modelBuilder);
        CourseSeed(modelBuilder);
        CourseUserDataSeed(modelBuilder);
        
    }

    private static void RoleSeed(ModelBuilder modelBuilder)
    {
        const string studentDescription = "Može samo gledati podatke o kolegijima (nema prava da išta izmijeni)";
        const string professorDescription = "Može dodavati studente u kolegije te slati obavijesti i materijale";
        const string adminDescription = "Ima ovlasti brisati i dodavati korisnike bilo koje uloge";
        
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, RoleName = RoleEnum.Student, Description = studentDescription },
            new Role { Id = 2, RoleName = RoleEnum.Professor, Description = professorDescription },
            new Role { Id = 3, RoleName = RoleEnum.Admin, Description = adminDescription }
        );        
    }
    private static void UserDataSeed(ModelBuilder modelBuilder)
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
                RoleId = 1
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
                RoleId = 1
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
                RoleId = 1
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
                RoleId = 1
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
                RoleId = 1
            },
            
            new User{
                Id = 6,
                Email = "ivoivić@gmail.com",
                Password = "ProfIvo#",
                FirstName = "Ivo",
                LastName = "Ivić",
                BirthDate = new DateOnly(1989, 9, 12),
                Gender = GenderEnum.M,
                RoleId = 2
            },
            
            new User{
                Id = 7,
                Email = "petarpetrović@gmail.com",
                Password = "ProfPetar#",
                FirstName = "Petar",
                LastName = "Petrović",
                BirthDate = new DateOnly(1988, 9, 12),
                Gender = GenderEnum.M,
                RoleId = 2
            },
            
            new User{
                Id = 8,
                Email = "majamajić@gmail.com",
                Password = "ProfMaja#",
                FirstName = "Maja",
                LastName = "Majić",
                BirthDate = new DateOnly(1995, 01, 01),
                Gender = GenderEnum.F,
                RoleId = 2
            },
            
            new User{
                Id = 9,
                Email = "vesnavesnić@gmail.com",
                Password = "ProfVesna#",
                FirstName = "Vesna",
                LastName = "Vesnić",
                BirthDate = new DateOnly(1997, 02, 02),
                Gender = GenderEnum.F,
                RoleId = 2
            },
            
            new User{
                Id = 10,
                Email = "sebaleci@gmail.com",
                Password = "AdminSeba#",
                FirstName = "Sebastian",
                LastName = "Leci",
                BirthDate = new DateOnly(1997, 03, 08),
                Gender = GenderEnum.M,
                RoleId = 3
            }
        };
        
        HashAllPasswords(users);
        
        modelBuilder.Entity<User>().HasData(users);        
    }


    private static void CourseSeed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                Id=1,
                Name = "Matematika 1",
                Description = "Osnove algebre i teorije brojeva.",
                Ects = 7,
                OwnerId = 6
            },
            new Course
            {
                Id=2,
                Name = "Matematika 2",
                Description = "Integrali i diferencijalne jednadžbe.",
                Ects = 7,
                OwnerId = 7
            },
            new Course
            {
                Id=3,
                Name = "Objektno orijentirano programiranje",
                Description = "Osnovni koncepti OOP-a",
                Ects = 6,
                OwnerId = 8
            },
            new Course
            {
                Id=4,
                Name = "Algoritmi",
                Description =
                    "Proučavanje vremena izvršavanja i optimizacije algoritama za sortiranje i pretraživanje.",
                Ects = 6,
                OwnerId = 9
            });       
    }

    public static void CourseUserDataSeed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseUser>().HasData(
            new CourseUser { UserId = 1, CourseId = 1 },
            new CourseUser { UserId = 2, CourseId = 1 },
            new CourseUser { UserId = 3, CourseId = 1 },
            new CourseUser { UserId = 4, CourseId = 1 },
            
            new CourseUser { UserId = 3, CourseId = 2 },
            new CourseUser { UserId = 4, CourseId = 2 },
            new CourseUser { UserId = 5, CourseId = 2 },
            
            new CourseUser { UserId = 1, CourseId = 3 },
            new CourseUser { UserId = 2, CourseId = 3 },
            new CourseUser { UserId = 3, CourseId = 3 },
            new CourseUser { UserId = 4, CourseId = 3 },
            
            new CourseUser { UserId = 1, CourseId = 4 },
            new CourseUser { UserId = 4, CourseId = 4 },
            new CourseUser { UserId = 5, CourseId = 4 });
    }
}
