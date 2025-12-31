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
                    PublishedDate =  new DateOnly(2020,05,14),
                    Url="https://www.cs.mcgill.ca/~akroit/math/compsci/Cormen%20Introduction%20to%20Algorithms.pdf"
                },
                
                new CourseMaterial
                {
                    Id = 9,
                    CourseId = 5,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime,
                    
                    Title="Fizička razina",
                    AuthorName = "Ante Antić",
                    PublishedDate =  new DateOnly(2020,05,15),
                    Url="https://fesbmaterijali.net/antic/fizicka%razina/"
                },
                                
                new CourseMaterial
                {
                    Id = 10,
                    CourseId = 5,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime,
                    
                    Title="Podatkovna razina",
                    AuthorName = "Ante Antić",
                    PublishedDate =  new DateOnly(2020,05,15),
                    Url="https://fesbmaterijali.net/antic/podatkovna%razina/"
                },
                new CourseMaterial
                {
                    Id = 11,
                    CourseId = 5,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime,
                    
                    Title="Transportna razina",
                    AuthorName = "Ante Antić",
                    PublishedDate =  new DateOnly(2020,05,15),
                    Url="https://fesbmaterijali.net/antic/transportna%razina/"
                },
                
                new CourseMaterial
                {
                    Id = 12,
                    CourseId = 6,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime,
                    
                    Title="Booleova algebra",
                    AuthorName = "David Davidović",
                    PublishedDate =  new DateOnly(2010,05,15),
                    Url="https://fesbmaterijali.net/davidovic/booleova%algebra/"
                },
                
                new CourseMaterial
                {
                    Id = 13,
                    CourseId = 6,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime,
                    
                    Title="Digitalni sklopovi (1.izadnje)",
                    AuthorName = "David Davidović",
                    PublishedDate =  new DateOnly(2008,05,15),
                    Url="https://fesbmaterijali.net/davidovic/digitalni%sklopovi1/"
                },
                
                new CourseMaterial
                {
                    Id = 14,
                    CourseId = 7,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime,
                    
                    Title="Računalne mreže u sklopovlju(2007)",
                    AuthorName = "Vesna Vesnić",
                    PublishedDate =  new DateOnly(2007,03,14),
                    Url="https://fesbmaterijali.net/vesnic/mreze%sklopovlje/"
                },
                
                new CourseMaterial
                {
                    Id = 15,
                    CourseId = 8,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime,
                    
                    Title="Clean Code",
                    AuthorName = "Robert Cecil Martin",
                    PublishedDate =  new DateOnly(2005,04,18),
                    Url="https://ptgmedia.pearsoncmg.com/images/9780132928472/samplepages/0132928477.pdf"
                },
                
                new CourseMaterial
                {
                    Id = 16,
                    CourseId = 8,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime,
                    
                    Title="The C Programming Language. 2nd Edition",
                    AuthorName = "Dennis Ritchie",
                    PublishedDate =  new DateOnly(1988,01,12),
                    Url="https://seriouscomputerist.atariverse.com/media/pdf/book/C%20Programming%20Language%20-%202nd%20Edition"
                },
                
                new CourseMaterial
                {
                    Id = 17,
                    CourseId = 9,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime,
                    
                    Title="Zbirka zadataka-C",
                    AuthorName = "Maja Majić",
                    PublishedDate =  new DateOnly(2013,01,13),
                    Url="https://fesbmaterijali.net/majic/zbirka%zadatakac/"
                },
                
                new CourseMaterial
                {
                    Id = 18,
                    CourseId = 13,
                    CreatedAt = seedTime,
                    UpdatedAt = seedTime,
                    
                    Title="Uvod u ekonomiju i poduzetništvo",
                    AuthorName = "Petar Petrović",
                    PublishedDate =  new DateOnly(2013,07,13),
                    Url="https://fesbmaterijali.net/petrovic/ekonimija%uvod/"
                }
                
                
                
                
                
                );

        }
    }
}