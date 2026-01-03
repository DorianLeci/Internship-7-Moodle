using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUpdateSeedForStatistics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEL+UvpzLEsyIQh5gYijNvR4zJ7LvosgSDWWgSUe0UkWMqyWTb4w3LJndhjZyrGnnwA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMMJP0PCidjPtHwOKMJOWeBvPRETbGHPFzMQ7d3mkl9QLjVPHHIrvLd+5LvAj87C5A==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAENwM67HaV5VzD9J0H8ySFt5/5eNGRpU8tL1963YNnLmRktf9xGpy3WmwqxR2BPUz1Q==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 29, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2010), "AQAAAAEAACcQAAAAEOYHRus5XGt42wC4iqhAH6vFrcSmrv24HXU+aViG42fLoAk4eoAmb2aM/dNoIXIf2Q==", new DateTime(2025, 12, 29, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2097) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHwHV3wjY7X+0CZ1Pq334YzhPwkO7jaCRnx0zUXBVprPOyp4bBaEQ1vUFKfF4FoKkQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEJ/91If39vQHJ73u2n6cSRqe2cdO7w9xPZE02o/yDMnT2wq2OzE560CU4Ow8TwCYKQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEI6OuciziYTrm6ARLf5UZYd47i/UHCLcXTNiz6WsHOyiwyWJXjCuFiSLxvc4yaqAwA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAEDB4uy2XOI8BHFI76gnYDuBpUshYhygHssZMyBQLT/RZKZ7PfHei98bfRXbIDz32+g==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAEDq0wcHR6InJEU+9lMC/dZvr03xd5m28fDH/CNN/x+gcIbfPtTauo/yOy9j7mSsdeQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHHkFZ9kUD6kz5g1w91t4F9VVhILvdQ9NrC5Wzss+d0GuuoRhyxug2FeDJnG1FCycg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 3, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2114), "AQAAAAEAACcQAAAAENiKU3/Ah5CAGEJdPOELHUH8sgtASi5eUD+ASTjD/mngaH3E02e0DS/2QhKWoO3Y9A==", new DateTime(2025, 12, 3, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2121) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 12,
                column: "password",
                value: "AQAAAAEAACcQAAAAENaeylGFYjpfNznDxK80qmuibOumXoXLlnUMxVKPYnFRehRVxpnZ0X/YWVvIruSZIw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 24, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2142), "AQAAAAEAACcQAAAAEGmYAJ0lz5jbCaCd82PQrZ8B9CNxncXURtR7nekQZXLWDwq2wJh2SSdG9nnvLwPXDw==", new DateTime(2025, 12, 24, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2144) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 14,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMTaXrMgeX8r8SgHyaKxIhJHT1aPjrZFaqnESFK3dDVTpPNMA6A2u36385bQhJ5Sug==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 15,
                column: "password",
                value: "AQAAAAEAACcQAAAAEPdeafaiKFwWMvwQxcTn1cT+r9S42vqCobKKfdH2J2uzqBXQczPApL3YuZEl7QMppw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 16,
                column: "password",
                value: "AQAAAAEAACcQAAAAEI06JHfGoBSerP0Fd9iLOr1Ng4iFyH/FgURpHgX21NDtKSrhgaHQGNNG7ffEtwmgSA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 17,
                column: "password",
                value: "AQAAAAEAACcQAAAAENlB9G8J4T1fLM6nFJprgbjeTIHnf8xLiDH58pILY2IayiypXmzVQJwkF/fYwYXBfA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 18,
                column: "password",
                value: "AQAAAAEAACcQAAAAEF9Ta1kExkzHNNQNCnFBwEEyWb1Jg7tRnAGhxzKdMBc2YiVNhKcogaTaJhek7m/0Zw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 19,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMCzGuTqbVHL64WDOYMsJBZFfU+0v/YhQ6mQu1BAU55HyAhThzvhzw3dXZN9yLoEXA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 20,
                column: "password",
                value: "AQAAAAEAACcQAAAAEFGBEa36n+p7aqStmXAqWPif4/oloXH1NBstUlwu2dJyc3d6HpslwMLAOGDsKd/IgQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 21,
                column: "password",
                value: "AQAAAAEAACcQAAAAEAmz9DGrryxY6hlpUHUW4tNKApZIF6NPxpcUiKHVmEMGt0MM5iuMAgA1CkZ2gVrMwQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2026, 1, 2, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2163), "AQAAAAEAACcQAAAAEDcfHdWDHJnx8ftfadHOgmGNrWnH8fhyozVYs5LEcv4BEb/W7u0jyUYqDE2PFq2Cxw==", new DateTime(2026, 1, 2, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2165) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2026, 1, 3, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2168), "AQAAAAEAACcQAAAAEMRrfe2k3rf+m+jgRKIkWvYXAg9NA1J9mdpy4ZCh0gWQzFxR2BVA0qD84HLU9bIgVg==", new DateTime(2026, 1, 3, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2169) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2026, 1, 2, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2172), "AQAAAAEAACcQAAAAEJNqZUTylEvjJLOVzEyAWJIzdDXhDV1JpzR9M6G9kaC8gSMZ+/8p92+/IjVYTUVY1g==", new DateTime(2026, 1, 2, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2174) });

            migrationBuilder.InsertData(
                schema: "public",
                table: "users",
                columns: new[] { "id", "birth_date", "created_at", "email", "first_name", "gender", "last_name", "password", "role_id", "updated_at" },
                values: new object[,]
                {
                    { 25, new DateOnly(1983, 2, 17), new DateTime(2026, 1, 2, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2177), "marijanm@gmail.com", "Marijan", "M", "Marjanović", "AQAAAAEAACcQAAAAENarYOskdhzzvW51Y9x+bLINYyE59Mb4+piMsS7Loo+0RMDonqENws0an4fMl0ry/w==", 2, new DateTime(2026, 1, 2, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2179) },
                    { 26, new DateOnly(1978, 2, 18), new DateTime(2026, 1, 1, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2187), "zoranz@gmail.com", "Zoran", "M", "Zoranović", "AQAAAAEAACcQAAAAELRVsN2swDmMIoAhbGIXdWrUl+l/fAoXRziiKLxDc/FXfugbq6lDK9tbba4DtphJuw==", 2, new DateTime(2026, 1, 1, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2196) },
                    { 27, new DateOnly(1979, 2, 18), new DateTime(2025, 12, 31, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2200), "zrinkaz@gmail.com", "Zrinka", "F", "Zrinković", "AQAAAAEAACcQAAAAEGKXBfKEDgj2wTiQII1z7ElbpqEB7/+jtIEEJIajmLGpnwIitfJh0RkoGmJWtsTiug==", 2, new DateTime(2025, 12, 31, 15, 8, 26, 618, DateTimeKind.Local).AddTicks(2201) }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "courses",
                columns: new[] { "id", "created_at", "description", "ects", "name", "owner_id", "updated_at" },
                values: new object[,]
                {
                    { 16, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(1913), "Kako kompjuteri funkcioniraju i njegovi dijelovi funkcioniraju-matematički i teorijski", 7, "Elektronika", 25, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(1958) },
                    { 17, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(1961), "Kako kompjuteri funkcioniraju i njegovi dijelovi funkcioniraju-matematički i teorijski", 7, "Elektronički sklopovi", 25, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(1962) },
                    { 18, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(1965), "Praktična primjena znanja stečenih na elektronici", 2, "Praktikum", 25, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(1966) },
                    { 19, new DateTime(2026, 1, 2, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(1969), "Matematički proračuni u elektromagnetizmu", 5, "Elektromagnetizam", 26, new DateTime(2026, 1, 2, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(1981) },
                    { 20, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(1984), "Matematički proračuni u elektroenergetici", 6, "Elektroenergetika", 26, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(1985) },
                    { 21, new DateTime(2025, 12, 31, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(1987), "Matematički proračuni u termodinamici", 7, "Termodinamika", 27, new DateTime(2025, 12, 31, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(1988) }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "course_users",
                columns: new[] { "id", "course_id", "created_at", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 48, 16, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2108), new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2110), 13 },
                    { 49, 16, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2112), new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2113), 14 },
                    { 50, 16, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2115), new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2116), 16 },
                    { 51, 17, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2118), new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2120), 4 },
                    { 52, 17, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2121), new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2123), 5 },
                    { 53, 17, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2125), new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2126), 11 },
                    { 54, 17, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2128), new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2130), 12 },
                    { 55, 18, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2131), new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2133), 22 },
                    { 56, 18, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2134), new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2136), 23 },
                    { 57, 19, new DateTime(2026, 1, 2, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2137), new DateTime(2026, 1, 2, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2140), 16 },
                    { 58, 19, new DateTime(2026, 1, 2, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2142), new DateTime(2026, 1, 2, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2143), 22 },
                    { 59, 19, new DateTime(2026, 1, 2, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2145), new DateTime(2026, 1, 2, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2147), 23 },
                    { 60, 20, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2148), new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2150), 1 },
                    { 61, 20, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2152), new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2153), 2 },
                    { 62, 20, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2155), new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2156), 3 },
                    { 63, 20, new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2158), new DateTime(2026, 1, 3, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2159), 4 },
                    { 64, 21, new DateTime(2026, 1, 1, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2161), new DateTime(2026, 1, 1, 15, 8, 26, 761, DateTimeKind.Local).AddTicks(2162), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "courses",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "courses",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "courses",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "courses",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "courses",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "courses",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEJ4WhYEJhY6JmkxodUaq1ykOR5dBU06Mdtp2WmqlVTdYMjnrmfZg5qFJmBKbWLH1KA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAELFfWc+GuyANdrRjdy1klVEY8Kp5WMwgrX6LWWbEchYi7S18xp5n8HVZoA0R27ipqA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAEBnG3CBQZgDlAnczYe5wQfKxFMkbaRn97du7A1OBmKptjt0lCKmzGjN8WCquZQJgNQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 28, 23, 46, 16, 740, DateTimeKind.Local).AddTicks(5604), "AQAAAAEAACcQAAAAEPlDzLwIvMVuqyLBy3Bb8b7EG9JUyboh88hnYnhzZgqY6E6n/0AvOXDTy9RW3qRgtA==", new DateTime(2025, 12, 28, 23, 46, 16, 740, DateTimeKind.Local).AddTicks(5684) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMlY4x4YYpGQoAp7ZEXfTGBmazto+V955FDin4uckWY8Ye/jWcUszBOZjgEoSoc9lg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMMNFPhSYqOB9Tl5d5UimCnv3RJpC/xMIqlCkuHmfXXsi4Mc52Boqmd9dUcYBQcR6w==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEATgPiId+EXqqCJNfZiqFJb30nnOGwKcV4b4CInuNydSpkP2J8bukToIpw7iMQKVzg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAENBbWNqBpjlUH7fTMrcvKHHnuqkEnf/t55pV3ryJXy7HXGZ/6+BZ+BnFfX0NCOopLw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAEBR44dYjYrJNM3bSpyWBMqVfnkZ5E0QjDUwtwBDuu65KmXbpfI05fNkO924pietPCg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEPVIa7xG7A+DAn1TU6qRfKwQzyJxIykK1vg2KsjCLDI8Z/LJT7oJSP0jV7QrNJYg5Q==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 2, 23, 46, 16, 740, DateTimeKind.Local).AddTicks(5700), "AQAAAAEAACcQAAAAEJwryKgXxFeoLZsVEn71lVGr3Aa9qZdtBBVe+b8kwlwsatZ3gsQQvCw70yplHUYgVQ==", new DateTime(2025, 12, 2, 23, 46, 16, 740, DateTimeKind.Local).AddTicks(5702) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 12,
                column: "password",
                value: "AQAAAAEAACcQAAAAECpeYfkIVXZE9dB0L21RA5QASiJLSw+9UMxFZaCJ0waZYbPAeQRxLbFr+tOOQnKxMA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2025, 12, 23, 23, 46, 16, 740, DateTimeKind.Local).AddTicks(5707), "AQAAAAEAACcQAAAAEMasx/XzJ4JvankRRU5aH/mGSKvGdPI37LdcYO440PEbfpIJpg8sUy+R5hep42MyzA==", new DateTime(2025, 12, 23, 23, 46, 16, 740, DateTimeKind.Local).AddTicks(5708) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 14,
                column: "password",
                value: "AQAAAAEAACcQAAAAEGk4k9FasXDHwc8MT1azrJK7C1zbEfrVF0hOJfzwJemk1dRLADw8K9JL+nSQNa9Fqg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 15,
                column: "password",
                value: "AQAAAAEAACcQAAAAEKvjY8ApxnsS/AHgF7k0kWqT2lU3DV9sEkuuptFZQqS6ZqZVbul/LpUi5jU5NKT3cg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 16,
                column: "password",
                value: "AQAAAAEAACcQAAAAEG4O3dc9Ci2ZYcvgfCIZbhAfm/hgtt+/onRDXn4KtbI8zkGUzdrY7wl74rpz5jXIAA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 17,
                column: "password",
                value: "AQAAAAEAACcQAAAAEK5gzXzXH3ygiYBNcwZiOFDvh2ktjYgfns8iGxWkURJxw8eExSTGmBcAJlCFg+0VFQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 18,
                column: "password",
                value: "AQAAAAEAACcQAAAAEP4u8fUxmbPiJWLEC1025Ee/Us3HHUHZXnVOol7G1hEx5hwvqHGy4ap4H+f5Iz4S/g==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 19,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMStZWkpoPK1nPBxgnpT42Q+WyRbkTEstVuEIrjX5GOW/7C4ev7uDntaZBdK/7PJGA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 20,
                column: "password",
                value: "AQAAAAEAACcQAAAAEAoR9Np8+fnE8s3RO9imEQg7IF/cG272w6g4noz/GcTaDr3yQ59teHJlIRrep1JH0Q==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 21,
                column: "password",
                value: "AQAAAAEAACcQAAAAEC0ToBAFwWAFoomTf7+cloQXQoHDfGm4/0ajXthwnqScD8FG4eLaPYoiDydxmtGX5A==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2026, 1, 1, 23, 46, 16, 740, DateTimeKind.Local).AddTicks(5726), "AQAAAAEAACcQAAAAEOIDOVQwTZAXp4CzDBtlCs3loTxUcx5RiBO4QVYV7uNV0o4idZtsfHkMORzBIy7PPQ==", new DateTime(2026, 1, 1, 23, 46, 16, 740, DateTimeKind.Local).AddTicks(5727) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2026, 1, 2, 23, 46, 16, 740, DateTimeKind.Local).AddTicks(5730), "AQAAAAEAACcQAAAAEIe2EgKOkw5wIu6dlO0giK8+fkXBqbIkz/OZ2tbZlCcKBHF1Y9xrmISWWJW6sHA4SA==", new DateTime(2026, 1, 2, 23, 46, 16, 740, DateTimeKind.Local).AddTicks(5730) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2026, 1, 1, 23, 46, 16, 740, DateTimeKind.Local).AddTicks(5737), "AQAAAAEAACcQAAAAENbNveKDYU83NkpizvL0yi5SeEDwpFP1dIyjl8zcBofoCJUX1xNLERX7PBwCEdRLQw==", new DateTime(2026, 1, 1, 23, 46, 16, 740, DateTimeKind.Local).AddTicks(5738) });
        }
    }
}
