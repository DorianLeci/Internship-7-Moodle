using Internship_7_Moodle.Domain.Entities.Courses;
using Internship_7_Moodle.Domain.Entities.PivotTables;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Database.Seed;

internal static partial class Seeder
{
    private static class CourseData
    { 
        public static void CourseDataSeed(ModelBuilder modelBuilder,DateTime seedTime)
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
                },
                new Course
                {
                    Id=5,
                    Name = "Računalne mreže",
                    Description = "Osnove interneta.",
                    Ects = 5,
                    OwnerId = 9,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new Course
                {
                    Id=6,
                    Name = "Diskretni sustavi i strukture",
                    Description = "Uvod u digitalnu logiku.",
                    Ects = 6,
                    OwnerId = 9,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new Course
                {
                    Id=7,
                    Name = "Praktična izrada računalnih mreža",
                    Description = "Stvaranje vlastite računalne mreže kroz parktični rad.",
                    Ects = 6,
                    OwnerId = 9,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new Course
                {
                    Id=8,
                    Name = "Uvod u računala i programiranje",
                    Description = "Upoznavanje s programskim jezikom C i zapisom brojeva na računalima.",
                    Ects = 4,
                    OwnerId = 8,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new Course
                {
                    Id=9,
                    Name = "Programiranje",
                    Description = "Pokazivači i structovi te njihova primjena u C jeziku",
                    Ects = 7,
                    OwnerId = 8,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new Course
                {
                    Id=10,
                    Name = "Strukture podataka",
                    Description = "Upoznavanje s osnovnim strukturama podataka i vremenom izvršavanja",
                    Ects = 8,
                    OwnerId = 8,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new Course
                {
                    Id=11,
                    Name = "Matematika 3",
                    Description = "Linijski integrali i vektorska polja.",
                    Ects = 6,
                    OwnerId = 6,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new Course
                {
                    Id=12,
                    Name = "Diskretna matematika",
                    Description = "Teorija brojeva i kombinatorika.",
                    Ects = 5,
                    OwnerId = 6,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new Course
                {
                    Id=13,
                    Name = "Ekonomija",
                    Description = "Teorija ekonomije i poduzetništva.",
                    Ects = 3,
                    OwnerId = 7,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new Course
                {
                    Id=14,
                    Name = "Računalna grafika",
                    Description = "Matematika iza prikaza računalne grafike.",
                    Ects = 5,
                    OwnerId = 7,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                },
                new Course
                {
                    Id=15,
                    Name = "Signali i sustavi",
                    Description = "Teorija obrade signala.",
                    Ects = 4,
                    OwnerId = 7,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime
                }); 
        }
        
        public static void CourseUserDataSeed(ModelBuilder modelBuilder,DateTime seedTime)
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
                new CourseUser { Id=14,UserId = 5, CourseId = 4, CreatedAt = seedTime,UpdatedAt = seedTime },
                
                new CourseUser { Id=15,UserId = 1, CourseId = 5, CreatedAt = seedTime,UpdatedAt = seedTime },
                new CourseUser { Id=16,UserId = 2, CourseId = 5, CreatedAt = seedTime,UpdatedAt = seedTime },
                new CourseUser { Id=17,UserId = 3, CourseId = 5, CreatedAt = seedTime,UpdatedAt = seedTime },
                new CourseUser { Id=18,UserId = 4, CourseId = 5, CreatedAt = seedTime,UpdatedAt = seedTime },
                new CourseUser { Id=19,UserId = 11, CourseId = 5, CreatedAt = seedTime,UpdatedAt = seedTime }
                
                
                
                );
        }
    }
}