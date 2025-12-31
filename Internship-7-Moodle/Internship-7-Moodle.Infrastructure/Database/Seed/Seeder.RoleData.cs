using Internship_7_Moodle.Domain.Entities.Roles;
using Internship_7_Moodle.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_Moodle.Infrastructure.Database.Seed;

internal static partial class Seeder
{
    private static class RoleData
    {
        public static void RoleSeed(ModelBuilder modelBuilder,DateTime seedTime)
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
    }
}