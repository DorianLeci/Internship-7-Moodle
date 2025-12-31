using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUpdateCourseInfoSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "course_materials",
                keyColumn: "id",
                keyValue: 8,
                column: "published_date",
                value: new DateOnly(2020, 5, 14));

            migrationBuilder.InsertData(
                schema: "public",
                table: "course_materials",
                columns: new[] { "id", "author_name", "course_id", "created_at", "published_date", "title", "updated_at", "url" },
                values: new object[,]
                {
                    { 9, "Ante Antić", 5, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2020, 5, 15), "Fizička razina", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://fesbmaterijali.net/antic/fizicka%razina/" },
                    { 10, "Ante Antić", 5, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2020, 5, 15), "Podatkovna razina", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://fesbmaterijali.net/antic/podatkovna%razina/" },
                    { 11, "Ante Antić", 5, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2020, 5, 15), "Transportna razina", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://fesbmaterijali.net/antic/transportna%razina/" },
                    { 12, "David Davidović", 6, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2010, 5, 15), "Booleova algebra", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://fesbmaterijali.net/davidovic/booleova%algebra/" },
                    { 13, "David Davidović", 6, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2008, 5, 15), "Digitalni sklopovi (1.izadnje)", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://fesbmaterijali.net/davidovic/digitalni%sklopovi1/" },
                    { 14, "Vesna Vesnić", 7, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2007, 3, 14), "Računalne mreže u sklopovlju(2007)", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://fesbmaterijali.net/vesnic/mreze%sklopovlje/" },
                    { 15, "Robert Cecil Martin", 8, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2005, 4, 18), "Clean Code", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://ptgmedia.pearsoncmg.com/images/9780132928472/samplepages/0132928477.pdf" },
                    { 16, "Dennis Ritchie", 8, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1988, 1, 12), "The C Programming Language. 2nd Edition", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://seriouscomputerist.atariverse.com/media/pdf/book/C%20Programming%20Language%20-%202nd%20Edition%20(OCR).pdf" },
                    { 17, "Maja Majić", 9, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2013, 1, 13), "Zbirka zadataka-C", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://fesbmaterijali.net/majic/zbirka%zadatakac/" },
                    { 18, "Petar Petrović", 13, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2013, 7, 13), "Uvod u ekonomiju i poduzetništvo", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://fesbmaterijali.net/petrovic/ekonimija%uvod/" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "course_notifications",
                columns: new[] { "id", "content", "course_id", "created_at", "subject", "updated_at" },
                values: new object[,]
                {
                    { 18, "Poštovani,\ns obzirom da svake godine bude studenata koji su prije ovog kolegija naučili programirate,možete se prijaviti na predkolokvij.\nOdržati će se idući tjedan u uskoro najavljenom terminu.", 8, new DateTime(2025, 10, 10, 12, 5, 0, 0, DateTimeKind.Unspecified), "Pretkolokvij", new DateTime(2025, 10, 10, 12, 5, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "Poštovani,\nobavijest za sve prijavljene na pretkolokvij.Održati će se 18.10 u 18:30 (laboratorij B420).", 8, new DateTime(2025, 10, 10, 12, 5, 0, 0, DateTimeKind.Unspecified), "Pretkolokvij-Termin", new DateTime(2025, 10, 10, 12, 5, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "Poštovani,\nocjene na ovom kolegiju dodjeljuju se relativno.Najboljih 20% posto dobiti će ocjenu 5.\nSvakih 20% je nova ocjena niže.", 9, new DateTime(2025, 10, 11, 12, 5, 0, 0, DateTimeKind.Unspecified), "Način ocjenjivanja", new DateTime(2025, 10, 11, 12, 5, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "Poštovani,\nprvi kolokvij piše se u laboratoriju B420.\nKolokvij se sadrži od 2 zadataka pod a) i b).Svaki točno riješeni nosi 10 bodova.", 9, new DateTime(2025, 11, 15, 7, 7, 0, 0, DateTimeKind.Unspecified), "Prvi kolokvij", new DateTime(2025, 11, 15, 7, 7, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "Poštovani,\nprije prvih laboratorijskih vježbi proučite upute za korištenje GitHub-a koje su spomenute na predavanju", 10, new DateTime(2025, 10, 15, 7, 7, 0, 0, DateTimeKind.Unspecified), "Strukture podataka-Laboratorijske vježbe", new DateTime(2025, 10, 15, 7, 7, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "Poštovani,\nzbog praznika koji počinju idući tjedan primorani smo odgoditi predavanje.Uskoro više o terminu...", 11, new DateTime(2025, 12, 18, 10, 5, 0, 0, DateTimeKind.Unspecified), "Praznici", new DateTime(2025, 12, 18, 10, 5, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "Poštovani,\npredavanje odgođeno zbog praznika NEĆE se nadoknaditi jer smatram da smo prošli dovoljnu količinu gradiva do sada.", 11, new DateTime(2025, 12, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), "Praznici-Novi termin", new DateTime(2025, 12, 20, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 25, "Poštovani,\ngradivo koje ulazi za prvi kolokvij je prvih 7 predavanja.\nSretne pripreme!", 13, new DateTime(2025, 11, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), "Gradivo za prvi kolokvij", new DateTime(2025, 11, 15, 10, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "course_users",
                columns: new[] { "id", "course_id", "created_at", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 42, 11, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 43, 11, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 44, 11, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 45, 13, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 46, 13, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 47, 13, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16 }
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEJ8dDpyf4B9r764KpM+HQSCAAZaSrwNu5ZGLLKFIIBC7ee6rQb6VMI0uG36uYH3/GQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEEt7xBW8bkfB9vKZk7NfBnAO55vkXQanhyK709ZuSDubPjJCm8Nfu8APqqaOfrj9lw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAEA1a1cWokqg34hmZtfUwMCMLvUWyKdz1HVbqU+u/tadrZuABNJX/W/hH+DjfR+AFZw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAEDzDeUTn4akXKiKRyQgqtgXz5NWmRvbdcP4r9VQMnez7DIAlrnyo+c3oEhNcQQ+4qw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAEFTofV/fMq08xVHhatR7Uwz8MFGGzozQ4O1t2fkN7VPYtzlTyw6UDFnyVxBoT8l8bQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAENSa+YxMaZu/NFioTCmz8+LKJIxcq8g7Xvb65wrZD2dVCuNJA/J6xVnUoJtDSD/MbA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEAXmpnAUI2yicSjxglfmBz8ASAF9drYmHjcablZfCviTy2amYOiVZwkCxjAavkUTPA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAEGMH/zyGeI3CGvH5wDjjoR2T8aIUvworeLGTfRKjkHTlhiaNTibsDNArkP598HAarA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAEJZL6ERt0013zXIMlokR2OKuQGQ+mhZ9oHlOjAvxncyC6CWnVQew9C/7S9M00AZ88w==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAECRufhpGPQ9kb2lc5IUGawVFruGTYH0lRxTBLoWuKvMHwapzYxkmYw79xe9D6BOvww==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMWfAPEScv1LB9Z0mpFsrPWvqpMUDVK/rYtgf6vkE2XyRVoETkZvCHD9meqxp63Uvw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 12,
                column: "password",
                value: "AQAAAAEAACcQAAAAEANN1M3AvKctEsTlxg47zQPXMTzIVzuxteFYcL6wQxErT7/Xr41zVrobgtkiQka88g==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 13,
                column: "password",
                value: "AQAAAAEAACcQAAAAELzmfdmWxIy3mYZGiXZ0Gx0t/ZIV3tY949BraUglRkIA95Ek9v8BqGfcJ1G3cRfqow==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 14,
                column: "password",
                value: "AQAAAAEAACcQAAAAEIzC/osZKF92OuQzj2coZQKe4LuoH49QidoYXENKLbh9s2kJEz4lis4PwyqnthkfCA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 15,
                column: "password",
                value: "AQAAAAEAACcQAAAAEKFv99Dt8NLiPpDaccwoWUluu8LMO2GlMMLTKV08KWsEaeh6AJzLwqylUpgPDWTHhA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 16,
                column: "password",
                value: "AQAAAAEAACcQAAAAEK2leSno9bUkB5HN4sOTvwn1neYJ8EuFMfydR4LpyWNgS4GqmQKhIcwCGh90HLJGUA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_materials",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_materials",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_materials",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_materials",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_materials",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_materials",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_materials",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_materials",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_materials",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_materials",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 47);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "course_materials",
                keyColumn: "id",
                keyValue: 8,
                column: "published_date",
                value: new DateOnly(202, 5, 14));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEP/vRrCcD4IGBZ//hjPKYsq7wgzgOiB59Fbgg2LPVeVNf9ovU8bRvevy6ymcLPITmw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEFPk+z7JQ8vRD1lEaNmgNgsr7S3lIiRuu3GAprj8foQnFjss5HK8GNWJztLIoHb/vQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHM67djB23fMslWNGPBo0dZ1b2GFF6jsNDaIZw+0t2hpc8cbUptCKMrt7KdHlr4Irg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAENVeq5vwudUyG1E6xDUUZXozknZQhVG9712cIWSvy57VVuGYUDg15Gf4YUTmKEf5Cw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAEOKHZ1xF6YqqRNYrBc99Y8NU6H5OxmN5vMkNNZ3f6eClDIPapK0Es1irMF4ZtfPDGw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEEMWHi9taeRqtqFZ7bxqahlNGoyn/wV3XV2y+Y2IxzZ/Nzi+O1OQnTCWOJGC9ZgtNQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEL6b22vTiXssoomuNoYmy6nXO85k3Vivrvs3iHjyQKhLzDRey6ieZPrZD/6zeOgFag==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMjp5ZLi2j8APSJlRQTG0t3fv6b42MYU/oX+WqA6gKNmSdzr6ckFDQxN2mxwVhttaA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAEAadp7cAToqrgLbcvJy+CRCRCHsBIsl3CmmLtBEfjn7/L0mq/KmlI/DcMLm7y6s2cw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEFeSDOl/5oJf/LOcVR3QRN/EefckEUycWFCabPetQJxQcP4eC1OYFbhGaz/q3fdZuA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                column: "password",
                value: "AQAAAAEAACcQAAAAEK+DfWMY798lWfnFfqVx4XgESiQgryZilUmF4Qm1OKBA3wiDOP6PYT2bvvz3fUsb9w==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 12,
                column: "password",
                value: "AQAAAAEAACcQAAAAEC56RbtJpMxhRsHZZSsOYN+FdsPvsJ/8CJqjLr1jT63LuAuU4xHbXL4pR8/iBa/kGw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 13,
                column: "password",
                value: "AQAAAAEAACcQAAAAEBKOYbwqtKSCjJsZT7AlCGzgXjtmSJl699kpjMN11S2Z+ToOwx4w7wEFwVO5gaND8A==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 14,
                column: "password",
                value: "AQAAAAEAACcQAAAAEM0jFEv+FLmo9h8PxcPEttz0W8y+v/kyVSko7bybKfHvJKnFoDXx/tqOD+WzPRtfmA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 15,
                column: "password",
                value: "AQAAAAEAACcQAAAAENJ8I8g3JeaA7XbmQBNMp69XBLdb7kYZZdtIqnl2cBr+Y1/eJ6tUWKyBBSdvFqj5Lw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 16,
                column: "password",
                value: "AQAAAAEAACcQAAAAEJWHkqnJxeVEp66ebacqpVMICjy4X0eQ4lhZ1PI3b9afRJK1azMuPpczU66oGGZc+Q==");
        }
    }
}
