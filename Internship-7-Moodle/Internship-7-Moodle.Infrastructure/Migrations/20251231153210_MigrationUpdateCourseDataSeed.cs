using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUpdateCourseDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "public",
                table: "course_users",
                columns: new[] { "id", "course_id", "created_at", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 20, 6, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, 6, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 26, 7, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 27, 7, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 32, 8, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 33, 8, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 35, 9, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 36, 9, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 38, 10, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 39, 10, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 40, 10, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 }
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHm4WbHEoNZ2G+k12lSe5vki11Uvrs3tki+XjnkMZj8P+gapujObj9yaJ7zFtbqB8w==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEKeVUKLd5b/q/eySR+kEReyrckk1ifyDTa6gXIHMSC49o0cpmmkTx0FscynrcbiRNQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHYLmB0OPIN3psDR2486ew5l/Qzo8l0YyT2ujOyIRtO7fPZ8MHyI71/ngkYhlwA6WQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAEEqvEuoun+UWVlDU1b0ziVs6Df0T4IULB4rMItGRcJ1JiVFYGJbx0jlOaibBBroDEg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAEKAeqjDTevwDwe1lX7cgbGOJL6XoWp3AkXXniLT/AwfEHObMPP7K1N+ymMiVPPsJiA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAELK1xn9GBHGbcQ2qdIfcq9JsjXZubNBvSbJvlRWLjCUA7j3hX6OpfahGK0ZCVjzEGA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHHxWwKjYtT0QMr2Ia/1n/yk9zm8+EERtM2ZIp45RJEc91QuSVJ29Ai0tH5E6WJSwA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAEN6lstBrm1I4iuZmze4kEYsfnQqIKEfz7IK9PJ9HHKA339g36nRU/bz+rVJwSJ6eMA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAEGYRNEtkTMsIXLNck+VFviyT1KPMjAc5hrl9/01YDjhgAGDJfYsyVhttib9xV48oEQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEH5KthH4MsXQIfYHMpEuK5SAnikqmLA5F8fN2gcwG7sx5/92ZfPcf6MlhMjyPeqJTQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                column: "password",
                value: "AQAAAAEAACcQAAAAEB0VGaE9zxzUn8B5Xn699dKy33xPd4Q+GEJ3DUTlRAlYkBBQUxm/Igtq+GByXWS+Lw==");

            migrationBuilder.InsertData(
                schema: "public",
                table: "users",
                columns: new[] { "id", "birth_date", "created_at", "email", "first_name", "gender", "last_name", "password", "role_id", "updated_at" },
                values: new object[,]
                {
                    { 12, new DateOnly(2004, 3, 8), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tonic@gmail.com", "Toni", "M", "Crnčić", "AQAAAAEAACcQAAAAEPy0cLxpJCClUsH9bSTgYxk3cgemA6OBsiQ5Q4tgyBG+c9KdjVqAPfIuZ42WyfVH7g==", 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateOnly(2005, 3, 10), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "marijah@gmail.com", "Marija", "F", "Hanić", "AQAAAAEAACcQAAAAEAg9gCAtxyzVHKIj8BvPnymKEXT9mbyzk099yWWIMO/gpTW2aO7KFwbmnhOK4pwpWg==", 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateOnly(2005, 3, 27), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tomislavt@gmail.com", "Tomislav", "M", "Turjan", "AQAAAAEAACcQAAAAEBX8We+zehFHGxl3uuNh9St8Xqpd5gVkDoCSTyU6m5NuAPqmMkOZIlZkPEGH3pG9Qw==", 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateOnly(2001, 11, 3), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "emabolj@gmail.com", "Ema", "F", "Boljevčan", "AQAAAAEAACcQAAAAEJ11FuealVkeTpqgcfkTf7mSe1lNuAvCsFp4cokVVMoQpeNouJymTjQJF6YUS0ll5A==", 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateOnly(2003, 10, 17), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lukajer@gmail.com", "Luka", "M", "Jerković", "AQAAAAEAACcQAAAAEHJOIb0hXtBatgmDMxvExmhC2brpVWNOVFTkkZt/pPWM/ZYsEL1pel/52wZQcs0XCw==", 1, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "course_users",
                columns: new[] { "id", "course_id", "created_at", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 22, 6, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 23, 6, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 24, 6, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 25, 6, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 28, 7, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 29, 7, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 30, 7, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 31, 7, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 34, 8, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 37, 9, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 41, 10, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_users",
                keyColumn: "id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 15);

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

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                column: "password",
                value: "AQAAAAEAACcQAAAAECGtn2o0rNWvFWCqIox9S3DkRCnbXn2MXpJEovxW8p01TY+YrvuKLpntTbROouZDfA==");
        }
    }
}
