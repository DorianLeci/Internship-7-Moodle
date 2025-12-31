using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUpdateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_courses_owner_id",
                schema: "public",
                table: "courses");

            migrationBuilder.InsertData(
                schema: "public",
                table: "courses",
                columns: new[] { "id", "created_at", "description", "ects", "name", "owner_id", "updated_at" },
                values: new object[,]
                {
                    { 5, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Osnove interneta.", 5, "Računalne mreže", 9, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uvod u digitalnu logiku.", 6, "Diskretni sustavi i strukture", 9, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stvaranje vlastite računalne mreže kroz parktični rad.", 6, "Praktična izrada računalnih mreža", 9, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upoznavanje s programskim jezikom C i zapisom brojeva na računalima.", 4, "Uvod u računala i programiranje", 8, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pokazivači i structovi te njihova primjena u C jeziku", 7, "Programiranje", 8, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upoznavanje s osnovnim strukturama podataka i vremenom izvršavanja", 8, "Strukture podataka", 8, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Linijski integrali i vektorska polja.", 6, "Matematika 3", 6, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teorija brojeva i kombinatorika.", 5, "Diskretna matematika", 6, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teorija ekonomije i poduzetništva.", 3, "Ekonomija", 7, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matematika iza prikaza računalne grafike.", 5, "Računalna grafika", 7, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teorija obrade signala.", 4, "Signali i sustavi", 7, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "private_messages",
                keyColumn: "id",
                keyValue: 1,
                column: "updated_at",
                value: new DateTime(2025, 11, 11, 7, 45, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEG7bZmjIDmJEy/YFuaaKIZE/UG3AhwodxbqiHbRkKlmpfFrh5IKdwBDAeDLbHg0m5g==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEETg2SiRxbT7W9TG7YxTyoeXND+ypT6pOaTjXBSNOryrIG0qDnpd+v/sd8qIb9ck3A==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAEEZAXTSPjNWTNHqPHlrgg6oxYz4So00rVGU2P0qM1UcXNyyv8NhKu+SRWnXVegKc6A==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAED15gaHrOCCbsmf5o+31bLkZvf7Z6RGFhU1H+yvUsNEUT8NZtHB3+OF1m6rFCVlVMQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAEDHFyUR6hjKRm6tZmojd8mbRbqw4zc+H4dZBoUCMn/4kgjut1pZ9ydAdYuBJj7UCjQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEBIcHEUG2o2nVHVQePi9oC5NSfSpBmWXh0g4kRCHT7+F2zMhUq4/f/HAagUj9Akxjw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMx2u7Y/OwAkDxtHQQ0PU6ZJG9Nc9uOghA+6/swAwxJMDXS8ZIkRv/DXg/wCLikvYA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAEItSw6u6wgLd3zV3/q/BJ2oN93o0QWx/OyXAs6C0tUNL5sjR8zOGkGyhwuuU64b66A==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAEA+i9AG8TR0lT6tXw/mAIPkMp7Vc0bIXW3tmz6EuYxiqkQdTessI2AXEzgie5n610Q==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEBtIu4uqeRMJFV/9qTJz/Hquywc1PnTtnlEbPe63owuwCsNYoHzl3nc04RB68UEmxw==");

            migrationBuilder.InsertData(
                schema: "public",
                table: "users",
                columns: new[] { "id", "birth_date", "created_at", "email", "first_name", "gender", "last_name", "password", "role_id", "updated_at" },
                values: new object[] { 11, new DateOnly(1997, 3, 8), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nikolaf@gmail.com", "Nikola", "M", "Filipović", "AQAAAAEAACcQAAAAECGtn2o0rNWvFWCqIox9S3DkRCnbXn2MXpJEovxW8p01TY+YrvuKLpntTbROouZDfA==", 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "public",
                table: "course_users",
                columns: new[] { "id", "course_id", "created_at", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 15, 5, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, 5, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, 5, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 18, 5, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 19, 5, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_courses_owner_id",
                schema: "public",
                table: "courses",
                column: "owner_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_courses_owner_id",
                schema: "public",
                table: "courses");

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "courses",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "courses",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "courses",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "courses",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "courses",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "courses",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "courses",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "courses",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "courses",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "courses",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "courses",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "private_messages",
                keyColumn: "id",
                keyValue: 1,
                column: "updated_at",
                value: new DateTime(2025, 10, 1, 7, 45, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAED0RKdwXXiThKlZHp3dFjDucTl2uNNL4qietrqMqiOIcMsjS55mjStyUBcDDaLwpIQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMjwAkEtEM/I2tjAyHCsBZno5aXANL4cxqPWU4dWTNZ3Ia+AtDt8BCKEzPpROV0Ktg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAENcUYBLyNFUf43Ca4xqN6uZlAhJVoSg1UjVBUkuA2L7JMwWS9AVKZexsiwLBnzh/fw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAEFYIdJmqJ28+HHvLHD/yPzPPzyWqppzMtFr1E9m6ZtliizDUBrLAcbQWidAEljAjXg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAEKniGTaj3dfPIO5sf9wwYdcRRp8MorEAQ91UsfwKz+z3XJLwupGWbYfc1IB70X5Gow==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEOauarmR9SNsHOKRnSykbGkHco6JkFlaYNj0nB3GAtBm17Wx7/ETujQNxdlVYW5HpQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEIZ92o4RG7o+jKHV01vmZTEMJg/AV1HNQ67y/+VW2yH1jis8V8X4QIhD4/gpHzFLYA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAELKjSG0LuV0pz9b6bC6eaz34OyN6bknEz80zcREYO+oqIZOJMquEjnVjgKYcZpSyyw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAELwLp0FzuP/ZGj7fY1vNQjhNHI+uWGEopI/cKHzt4EH2/Fdrp7/SqCEUnwerdPeztQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEPPzlSS10EzoERhVIaUA0CWq5FuGhdzdFiTESY4Xk4jwnXNTGi3dYZ1RCa8iERDsuA==");

            migrationBuilder.CreateIndex(
                name: "IX_courses_owner_id",
                schema: "public",
                table: "courses",
                column: "owner_id",
                unique: true);
        }
    }
}
