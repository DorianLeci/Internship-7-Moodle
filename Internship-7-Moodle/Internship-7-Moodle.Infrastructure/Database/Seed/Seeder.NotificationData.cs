using Internship_7_Moodle.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Database.Seed;

internal static partial class Seeder
{
    private static class NotificationData
    { 
        public static void NotificationSeed(ModelBuilder modelBuilder)
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
    }
}