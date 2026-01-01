using Internship_7_Moodle.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using CourseNotification = Internship_7_Moodle.Domain.Entities.Courses.Notifications.CourseNotification;

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
                    UpdatedAt = new DateTime(2025, 11, 30, 08, 15, 0)
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
                    UpdatedAt = new DateTime(2025, 12, 01, 07, 45, 0)
                },
                new CourseNotification
                {
                    Id=7,
                    Subject="Promjena dvorane",
                    Content="Poštovani,\nsutrašnje predavanje održati će se u sali A102 (umjesto u predviđenoj A302)",
                    CourseId =3,
                    CreatedAt = new DateTime(2025, 11, 01, 07, 45, 0),
                    UpdatedAt = new DateTime(2025, 11, 01, 07, 45, 0)
                },
                new CourseNotification
                {
                    Id=8,
                    Subject="Laboratorijske vježbe",
                    Content="Poštovani,\nidući tjedan (8.10.) počinju laboratorijske vježbe iz kolegija algoritmi.",
                    CourseId =4,
                    CreatedAt = new DateTime(2025, 10, 01, 07, 45, 0),
                    UpdatedAt = new DateTime(2025, 10, 01, 07, 45, 0)
                },
                new CourseNotification
                {
                    Id=9,
                    Subject="Promjena rasporeda",
                    Content="Poštovani,\nidući tjedan (25.10.) predavanje će se održati s početkom u 11:45 (umjesto 10:45) u sali A101.",
                    CourseId =4,
                    CreatedAt = new DateTime(2025, 10, 18, 07, 45, 0),
                    UpdatedAt = new DateTime(2025, 10, 18, 07, 45, 0)
                },
                new CourseNotification
                {
                    Id=10,
                    Subject="Promjena rasporeda",
                    Content="Poštovani,\nidući tjedan (25.10.) predavanje će se održati s početkom u 11:45 (umjesto 10:45) u sali A102.",
                    CourseId =5,
                    CreatedAt = new DateTime(2025, 10, 18, 07, 45, 0),
                    UpdatedAt = new DateTime(2025, 10, 18, 07, 45, 0)
                },
                new CourseNotification
                {
                    Id=11,
                    Subject="Laboratorijske vježbe",
                    Content="Poštovani,\nu prvom mjesecu kreću laboratorijske vježbe.U prvom mjesecu će biti obavijest o rasporedu po grupama",
                    CourseId =5,
                    CreatedAt = new DateTime(2025, 12, 20, 15, 03, 0),
                    UpdatedAt = new DateTime(2025, 12, 20, 15, 03, 0)
                },
                new CourseNotification
                {
                    Id=12,
                    Subject="Laboratorijske vježbe: Napomena",
                    Content="Poštovani,\nNapomena u vezi laboratorijskih vježbi.Prije svake vježbe pisati će se ulazni ispiti.",
                    CourseId =5,
                    CreatedAt = new DateTime(2025, 12, 20, 16, 10, 0),
                    UpdatedAt = new DateTime(2025, 12, 20, 16, 10, 0)
                },
                new CourseNotification
                {
                    Id=13,
                    Subject="Laboratorijske vježbe: Napomena",
                    Content="Poštovani,\nNapomena u vezi laboratorijskih vježbi.Prije svake vježbe pisati će se ulazni ispiti.",
                    CourseId =5,
                    CreatedAt = new DateTime(2025, 12, 20, 16, 10, 0),
                    UpdatedAt = new DateTime(2025, 12, 20, 16, 10, 0)
                },
                new CourseNotification
                {
                    Id=14,
                    Subject="Promjena predavača",
                    Content="Poštovani,\nu prvom mjesecu ću biti na poslovnom putu u Japanu,pa će asistent držati sva predavanja kroz mjesec.",
                    CourseId =6,
                    CreatedAt = new DateTime(2025, 12, 21, 16, 10, 0),
                    UpdatedAt = new DateTime(2025, 12, 21, 16, 10, 0)
                },
                new CourseNotification
                {
                    Id=15,
                    Subject="Konzultacije",
                    Content="Poštovani,\ndobio sam dosta upita što se tiče konzultacija. Možete doći bilo kada dok sam na faksu,samo se najavite preko maila.",
                    CourseId =6,
                    CreatedAt = new DateTime(2025, 11, 21, 13, 12, 0),
                    UpdatedAt = new DateTime(2025, 11, 21, 13, 12, 0)
                },
                new CourseNotification
                {
                    Id=16,
                    Subject="Predaja praktičnog rada",
                    Content="Poštovani,\nrok za predaju praktičnog rada je do kraja prvog mjeseca.Sretno!",
                    CourseId =7,
                    CreatedAt = new DateTime(2025, 12, 30, 13, 12, 0),
                    UpdatedAt = new DateTime(2025, 12, 30, 13, 12, 0)
                },
                new CourseNotification
                {
                    Id=17,
                    Subject="Drugi kolokvij",
                    Content="Poštovani,\novaj kolegij ne sadrži drugi kolokvij.U završnu ocjenu ulazi prvi kolokvij i ocjena iz praktičnog rada.",
                    CourseId =7,
                    CreatedAt = new DateTime(2025, 12, 30, 20, 0, 0),
                    UpdatedAt = new DateTime(2025, 12, 30, 20, 0, 0)
                },
                new CourseNotification
                {
                    Id=18,
                    Subject="Pretkolokvij",
                    Content="Poštovani,\ns obzirom da svake godine bude studenata koji su prije ovog kolegija naučili programirate,možete se prijaviti na predkolokvij.\nOdržati će se idući tjedan u uskoro najavljenom terminu.",
                    CourseId =8,
                    CreatedAt = new DateTime(2025, 10, 10, 12, 05, 0),
                    UpdatedAt = new DateTime(2025, 10, 10, 12, 05, 0)
                },
                new CourseNotification
                {
                    Id=19,
                    Subject="Pretkolokvij-Termin",
                    Content="Poštovani,\nobavijest za sve prijavljene na pretkolokvij.Održati će se 18.10 u 18:30 (laboratorij B420).",
                    CourseId =8,
                    CreatedAt = new DateTime(2025, 10, 11, 12, 05, 0),
                    UpdatedAt = new DateTime(2025, 10, 11, 12, 05, 0)
                },
                new CourseNotification
                {
                    Id=20,
                    Subject="Način ocjenjivanja",
                    Content="Poštovani,\nocjene na ovom kolegiju dodjeljuju se relativno.Najboljih 20% posto dobiti će ocjenu 5.\nSvakih 20% je nova ocjena niže.",
                    CourseId =9,
                    CreatedAt = new DateTime(2025, 10, 11, 12, 05, 0),
                    UpdatedAt = new DateTime(2025, 10, 11, 12, 05, 0)
                },
                new CourseNotification
                {
                    Id=21,
                    Subject="Prvi kolokvij",
                    Content="Poštovani,\nprvi kolokvij piše se u laboratoriju B420.\nKolokvij se sadrži od 2 zadataka pod a) i b).Svaki točno riješeni nosi 10 bodova.",
                    CourseId =9,
                    CreatedAt = new DateTime(2025, 11, 15, 07, 07, 0),
                    UpdatedAt = new DateTime(2025, 11, 15, 07, 07, 0)
                },
                new CourseNotification
                {
                    Id=22,
                    Subject="Strukture podataka-Laboratorijske vježbe",
                    Content="Poštovani,\nprije prvih laboratorijskih vježbi proučite upute za korištenje GitHub-a koje su spomenute na predavanju",
                    CourseId =10,
                    CreatedAt = new DateTime(2025, 10, 15, 07, 07, 0),
                    UpdatedAt = new DateTime(2025, 10, 15, 07, 07, 0)
                },
                new CourseNotification
                {
                    Id=23,
                    Subject="Praznici",
                    Content="Poštovani,\nzbog praznika koji počinju idući tjedan primorani smo odgoditi predavanje.Uskoro više o terminu...",
                    CourseId =11,
                    CreatedAt = new DateTime(2025, 12, 18, 10, 05, 0),
                    UpdatedAt = new DateTime(2025, 12, 18, 10, 05, 0)
                },
                new CourseNotification
                {
                    Id=24,
                    Subject="Praznici-Novi termin",
                    Content="Poštovani,\npredavanje odgođeno zbog praznika NEĆE se nadoknaditi jer smatram da smo prošli dovoljnu količinu gradiva do sada.",
                    CourseId =11,
                    CreatedAt = new DateTime(2025, 12, 20, 10, 30, 0),
                    UpdatedAt = new DateTime(2025, 12, 20, 10, 30, 0)
                },
                
                new CourseNotification
                {
                    Id=25,
                    Subject="Gradivo za prvi kolokvij",
                    Content="Poštovani,\ngradivo koje ulazi za prvi kolokvij je prvih 7 predavanja.\nSretne pripreme!",
                    CourseId =13,
                    CreatedAt = new DateTime(2025, 11, 15, 10, 30, 0),
                    UpdatedAt = new DateTime(2025, 11, 15, 10, 30, 0)
                }
                
                
            );

        }
    }
}