using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationSecondMessageSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "text",
                schema: "public",
                table: "private_message",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.InsertData(
                schema: "public",
                table: "private_message",
                columns: new[] { "id", "created_at", "is_read", "receiver_id", "sender_id", "text", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 11, 7, 45, 0, 0, DateTimeKind.Unspecified), true, 8, 1, "Poštovani,\nimam nedoumica u vezi predavanja o polimorfizmu i nasljeđivanju.Možete li dodatno pojasniti polimorfizam.", new DateTime(2025, 10, 1, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 11, 11, 9, 45, 0, 0, DateTimeKind.Unspecified), true, 1, 8, "Poštovani,\nHvala na pitanju! 🙂\nPolimorfizam je koncept u objektno-orijentiranom programiranju koji omogućava da se ista metoda ili operacija ponaša različito ovisno o tipu objekta koji je poziva.\nU praksi, to znači da možete imati baznu klasu s apstraktnom ili virtualnom metodom, a različite izvedene klase mogu implementirati tu metodu na svoj način.\nKada pozovete metodu preko referenci na baznu klasu, program automatski izvršava implementaciju odgovarajuće izvedene klase.\nAko želite, možemo na primjeru vaše konzolne aplikacije s MenuManager klasama pokazati kako polimorfizam radi u stvarnom kodu.\nNadam se da ovo pojašnjava. Javite ako želite detaljniji primjer koda.", new DateTime(2025, 11, 11, 9, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 10, 3, 9, 30, 0, 0, DateTimeKind.Unspecified), true, 10, 1, "Poštovani,\nimam pitanje u vezi ažuriranja profila.Na kraju godine ću postati profesor te sam htio pitati je li moguća promjena uloge.", new DateTime(2025, 10, 3, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2025, 10, 3, 9, 45, 0, 0, DateTimeKind.Unspecified), true, 1, 10, "Poštovani,\nvaša uloga će biti promijenjena kada postanete profesor,pratiti ćemo novosti.", new DateTime(2025, 10, 3, 9, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2025, 12, 3, 14, 1, 0, 0, DateTimeKind.Unspecified), true, 2, 1, "Bok,jel imaš skriptu iz Matematike 1 slučajno?", new DateTime(2025, 10, 3, 14, 1, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2025, 12, 3, 14, 7, 0, 0, DateTimeKind.Unspecified), true, 1, 2, "Bok,imam naravno,sutra ti dam na faksu.", new DateTime(2025, 10, 3, 14, 7, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEKm/3IHqckA8OdyqTPVkWPmQyS4WMoGyNEyyYlrZwgzi/lgADDCJTvMcjusDDOW3Rw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEBakWKqFhbHxUpy4qFEj+7UlvjiqUCojS4a7VuOyVmTJCVS0lRSfaVWAnGS0nZbxBw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAEAyUS4sBFgKgPllHNCNuKgRfOWTZgdZTDkpVtCvQ9ofL7YPGICPnlyOQv/AV8dVdmg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAEAaliDfOwHojT58+56LVOO19mBUp/cse7F9Mg40XxKPzbIiyjGsui8Mf8f7SnHbrXQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAENciAk7mZA0GHZ4fBw+HfeZUbcfAxcxe8V1Ha+jIvZ8WuCNu5xHo+cnbZE+zrXY0Wg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEGok0uHumKhUrnTUsjPyJ89eskxOrmHlbQ69tgOh2QPZZMjU3crF3+WAoZACwJRSGw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAECzvAeEYV4h7TPUywV42Q9QBWmR+LN8T01BvG8NKuiqGVV2g5IoH51+Dqsi8EG6mfw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAEESK9A3HW5QNCdsccfzomp3WOS3YBn6nylwSPsT8aYpCubBXeF9LvDYXz7ZTGPU6IQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAEDULlQ5srg6yIrT79kh/mPtMcofB4/GG5dZwfNJk5Cpty6rRnw0d75lzMD0Pzlp8PQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEINAbLu7vyYgs4/K8605FcDzDBoZncxaanrgSVedjqaEpbMqOHOC8rgRDFwdy2XpsA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "private_message",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "private_message",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "private_message",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "private_message",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "private_message",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "private_message",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "text",
                schema: "public",
                table: "private_message",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEAdeNgs8HW/71ZZ+kaPejYvp13/i30DBNK15Ax2sSQYS0Q0G4N/tg4JuKLPHTZKGqQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEDQc7CU2Y0mJUixlsryvB/5tf+6xOt1nj8mFxs16vJYoCqSQYC3/UuMj0SSKn/Hb2w==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAEJ/rRQEKKa1tdYWzVd+MBfTGIE3v14S0MnjzZi21mnarK7NpncLEFX0llKH8XQnwig==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAEE4F3ukcXSL6iDNNA5xXoRwrfVMiWHqwOvq+BuzeNGFQA7NVNpztVMBpUvoO+PgeOw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAENPOiD9S6lt0EzM5Xit2k5bICQjfp8IL+mzFRxzUjj1W8Vt14k5eEWir+CrWcxjcwg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHIlCpTH8dIP7XRtKjZ3KfdqpiT1bpm1QK/NKhsMEiFlbuYXvxBCPUWdqxYxCjmPKA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEK8gKikNF7yg9BG+td+pTB42OVzy2GcsgvJ2Wo3BVUYQfggaJ4bnbxNOQ/KCVeu+1w==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAEEV4ufKsiIFm3gxKTCd2ZhfOPCNoHCeS5ooMLy8dUgPEQ/cWNx96QILeDuwNG04Zrw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAEIE1xKfkQeLAY4xjG/RoAALVuyXQcWFQu5X5KrD3uDa5s4cQYg/Z0mvj+tbNOhYRxw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEGHQMIUkK8C6L79f8PNtG1T9/ufYYMDX/h55xiWn/7ckYQnh22FyseRp2sxd4ddURQ==");
        }
    }
}
