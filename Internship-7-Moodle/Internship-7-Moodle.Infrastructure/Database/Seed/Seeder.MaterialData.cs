using Internship_7_Moodle.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Database.Seed;

internal static partial class Seeder
{
    private static class MaterialData
    {
        public static void MaterialSeed(ModelBuilder builder, DateTime seedTime)
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
    }
}