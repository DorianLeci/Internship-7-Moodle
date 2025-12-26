using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration_SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "role",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    last_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: true),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_role_role_id",
                        column: x => x.role_id,
                        principalSchema: "public",
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "course",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ects = table.Column<int>(type: "integer", nullable: false),
                    owner_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.id);
                    table.ForeignKey(
                        name: "FK_course_users_owner_id",
                        column: x => x.owner_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "private_message",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "text", nullable: false),
                    is_read = table.Column<bool>(type: "boolean", nullable: false),
                    sender_id = table.Column<int>(type: "integer", nullable: false),
                    receiver_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_private_message", x => x.id);
                    table.ForeignKey(
                        name: "FK_private_message_users_receiver_id",
                        column: x => x.receiver_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_private_message_users_sender_id",
                        column: x => x.sender_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "course_material",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    author_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    published_date = table.Column<DateOnly>(type: "date", nullable: true),
                    url = table.Column<string>(type: "text", nullable: false),
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_material", x => x.id);
                    table.ForeignKey(
                        name: "FK_course_material_course_course_id",
                        column: x => x.course_id,
                        principalSchema: "public",
                        principalTable: "course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "course_notification",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    subject = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    content = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_notification", x => x.id);
                    table.ForeignKey(
                        name: "FK_course_notification_course_course_id",
                        column: x => x.course_id,
                        principalSchema: "public",
                        principalTable: "course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "course_user",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_course_user_course_course_id",
                        column: x => x.course_id,
                        principalSchema: "public",
                        principalTable: "course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_course_user_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "role",
                columns: new[] { "id", "created_at", "description", "role_name", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Može samo gledati podatke o kolegijima (nema prava da išta izmijeni)", "Student", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Može dodavati studente u kolegije te slati obavijesti i materijale", "Professor", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ima ovlasti brisati i dodavati korisnike bilo koje uloge", "Admin", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "users",
                columns: new[] { "id", "birth_date", "created_at", "email", "first_name", "gender", "last_name", "password", "role_id", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateOnly(2000, 4, 4), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "zandzartz@gmail.com", "John", "M", "Doe", "AQAAAAEAACcQAAAAEL9Yy9ZHVvDbm5A4KKu3q/6wjinFJYqI39RJ2sg8HuXsmFNe/4yO+gE+Z0hvPh4//A==", 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateOnly(2000, 3, 3), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dorianleci@gmail.com", "Dorian", "M", "Leci", "AQAAAAEAACcQAAAAEKOh9TMoGv3JvmfF75GFUDQy1ToNOifM8SzTB8hrkO7lGVfF06s8HLLTkDYPRfiTpQ==", 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateOnly(2004, 3, 28), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "damirleci@gmail.com", "Damir", "M", "Leci", "AQAAAAEAACcQAAAAEJcgfyydNl2JH68dLga3TBpa+NAwdiDmo4eV4CUIM3XmlnXYytdl8De58dwbFXcgZQ==", 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateOnly(2005, 11, 28), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vesnaleci@gmail.com", "Vesna", "F", "Leci", "AQAAAAEAACcQAAAAEPJBiHtJzd8f2ZZo5vIWsOg2R+LHlRX9jRz7b/gYbyPGaKoO5+Cc0EJDP44mb3KRhg==", 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateOnly(1990, 10, 12), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "zoraleci@gmail.com", "Zora", "F", "Leci", "AQAAAAEAACcQAAAAEPkLzKF4xvEgmMpBS85B7gQ1cE5F5xxE3GnmAB9KtM8dvfdF2xfU2JgZYdpguA9Juw==", 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateOnly(1989, 9, 12), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ivoivić@gmail.com", "Ivo", "M", "Ivić", "AQAAAAEAACcQAAAAEM8p46LMsUpgGnNmeIXac0iPJciGAonc0hnYN2g0gMzssGYNh9uPBPQnlBhz7Kt/YQ==", 2, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateOnly(1988, 9, 12), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "petarpetrović@gmail.com", "Petar", "M", "Petrović", "AQAAAAEAACcQAAAAEC3Duur/K7XpOaqV0cX+XSW4Pbf/RT1vVZvqmlExFfqWbgnkp2L2whSN5WZfbQb+ww==", 2, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateOnly(1995, 1, 1), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "majamajić@gmail.com", "Maja", "F", "Majić", "AQAAAAEAACcQAAAAELOtmm+XIcpu8DuI0MvJGqmLxDyVmPhDOvJgpEyhpwmBKk+WbB4JGwnFTZO8Gq+ABA==", 2, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateOnly(1997, 2, 2), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vesnavesnić@gmail.com", "Vesna", "F", "Vesnić", "AQAAAAEAACcQAAAAEE/iYbGNOFYeE2Goqb3jGQ9ak2W7wpZYTMihA2URmady+i1yH2+oQ6eCQG17MH77Dw==", 2, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateOnly(1997, 3, 8), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sebaleci@gmail.com", "Sebastian", "M", "Leci", "AQAAAAEAACcQAAAAEH4QZHN/xMatg/wvXFkFzDceIfyR/O8w4lrFNz7SWr1YvIgPNbOqHCBdSWs0ujgABg==", 3, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "course",
                columns: new[] { "id", "created_at", "description", "ects", "name", "owner_id", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Osnove algebre i teorije brojeva.", 7, "Matematika 1", 6, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Integrali i diferencijalne jednadžbe.", 7, "Matematika 2", 7, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Osnovni koncepti OOP-a", 6, "Objektno orijentirano programiranje", 8, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Proučavanje vremena izvršavanja i optimizacije algoritama za sortiranje i pretraživanje.", 6, "Algoritmi", 9, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "course_material",
                columns: new[] { "id", "author_name", "course_id", "created_at", "published_date", "title", "updated_at", "url" },
                values: new object[,]
                {
                    { 1, "Ivo Ivić", 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2015, 1, 1), "Matematika1 FESB", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://fesbmaterijali.net/ivo/Matematika1%20FESB.pdf" },
                    { 2, "Ivo Ivić", 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2015, 1, 1), "Zbirka zadataka 2015", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://fesbmaterijali.net/ivo/Zbirka%zadataka%2015/" },
                    { 3, "Petar Petrović", 2, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2017, 3, 28), "Uvod u viševarijabilni račun", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://fesbmaterijali.net/petar/multivariable%calculus/" },
                    { 4, "Petar Petrović", 2, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2018, 4, 27), "Uvod u integralni račun", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://fesbmaterijali.net/petar/integrals%book/" },
                    { 5, "Marjan Marjanović", 3, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2003, 11, 11), "OOP skripta, FESB 2003", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://fesbmaterijali.net/marjanovic/oop%skripta/" },
                    { 6, "Bjourn Stroustrup", 3, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1986, 2, 27), "The C++ programming Language,", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.stroustrup.com/4th.html" },
                    { 7, "Hrvoje Hrvojić", 4, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2010, 2, 27), "„Algoritmi“, interna skripta", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://fesbmaterijali.net/hrvojic/interna%skripta/" },
                    { 8, "T.Cormen", 4, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(202, 5, 14), "„Introduction to Algorithms“, second edition", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.cs.mcgill.ca/~akroit/math/compsci/Cormen%20Introduction%20to%20Algorithms.pdf" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "course_notification",
                columns: new[] { "id", "content", "course_id", "created_at", "subject", "updated_at" },
                values: new object[,]
                {
                    { 1, "Poštovani,\nzbog bolesti otkazujem sutrašnje predavanje.", 1, new DateTime(2025, 10, 26, 11, 10, 0, 0, DateTimeKind.Unspecified), "Otkazano predavanje", new DateTime(2025, 10, 26, 11, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Poštovani,\nsutra se održava prvi kolokvij iz kolegija Matematika 1.\nMolimo ponesite iksice i pribor za pisanje.Ostalo je zabranjeno.", 1, new DateTime(2025, 11, 26, 8, 15, 0, 0, DateTimeKind.Unspecified), "Prvi kolokvij", new DateTime(2025, 11, 26, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Poštovani,\nNapomena: tko nije položio prvi kolokvij ne može izaći na drugi.Morati će čekati do ispitnog roka.", 1, new DateTime(2025, 11, 30, 8, 15, 0, 0, DateTimeKind.Unspecified), "Drugi kolokvij", new DateTime(2025, 11, 30, 8, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Poštovani,\nna predavanju idući tjedan održati će se teorijski ispit za dodatne bodove.\nGradivo koje ulazi u ispit: Dvostruki integrali.", 2, new DateTime(2025, 11, 18, 9, 15, 0, 0, DateTimeKind.Unspecified), "Teorijski ispit za bodove", new DateTime(2025, 11, 18, 9, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Poštovani,\nu prilogu se nalaze rezultati kolokvija.\nhttps://moodle.rezultati/prvi_kolokvij.pdf", 2, new DateTime(2025, 11, 29, 10, 30, 0, 0, DateTimeKind.Unspecified), "Rezultati prvog kolokvija", new DateTime(2025, 11, 29, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Poštovani,\nrok za predaju praktičnog rada kojeg smo spominjali na predavanju je 10.1.2026.\nOcjena iz praktičnog rada nosi 40% završne ocjene.", 3, new DateTime(2025, 12, 1, 7, 45, 0, 0, DateTimeKind.Unspecified), "Praktični rad", new DateTime(2025, 12, 1, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Poštovani,\nsutrašnje predavanje održati će se u sali A102 (umjesto u predviđenoj A302)", 3, new DateTime(2025, 11, 1, 7, 45, 0, 0, DateTimeKind.Unspecified), "Promjena dvorane", new DateTime(2025, 11, 1, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Poštovani,\nidući tjedan (8.10.) počinju laboratorijske vježbe iz kolegija algoritmi.", 4, new DateTime(2025, 10, 1, 7, 45, 0, 0, DateTimeKind.Unspecified), "Laboratorijske vježbe", new DateTime(2025, 10, 1, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Poštovani,\nidući tjedan (25.10.) predavanje će se održati s početkom u 11:45 (umjesto 10:45) u sali A101.", 4, new DateTime(2025, 10, 18, 7, 45, 0, 0, DateTimeKind.Unspecified), "Promjena rasporeda", new DateTime(2025, 10, 18, 7, 45, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "course_user",
                columns: new[] { "id", "course_id", "created_at", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, 2, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, 2, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 7, 2, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 8, 3, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, 3, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, 3, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, 3, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 12, 4, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, 4, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 14, 4, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_course_owner_id",
                schema: "public",
                table: "course",
                column: "owner_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_course_material_course_id",
                schema: "public",
                table: "course_material",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_course_notification_course_id",
                schema: "public",
                table: "course_notification",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_course_user_course_id",
                schema: "public",
                table: "course_user",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_course_user_user_id",
                schema: "public",
                table: "course_user",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_private_message_receiver_id",
                schema: "public",
                table: "private_message",
                column: "receiver_id");

            migrationBuilder.CreateIndex(
                name: "IX_private_message_sender_id",
                schema: "public",
                table: "private_message",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                schema: "public",
                table: "users",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "course_material",
                schema: "public");

            migrationBuilder.DropTable(
                name: "course_notification",
                schema: "public");

            migrationBuilder.DropTable(
                name: "course_user",
                schema: "public");

            migrationBuilder.DropTable(
                name: "private_message",
                schema: "public");

            migrationBuilder.DropTable(
                name: "course",
                schema: "public");

            migrationBuilder.DropTable(
                name: "users",
                schema: "public");

            migrationBuilder.DropTable(
                name: "role",
                schema: "public");
        }
    }
}
