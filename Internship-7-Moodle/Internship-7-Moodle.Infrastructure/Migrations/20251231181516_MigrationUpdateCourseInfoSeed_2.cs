using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUpdateCourseInfoSeed_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "course_materials",
                keyColumn: "id",
                keyValue: 16,
                column: "url",
                value: "https://seriouscomputerist.atariverse.com/media/pdf/book/C%20Programming%20Language%20-%202nd%20Edition");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 10, 11, 12, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 11, 12, 5, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHCEXuhT1aIZHOT5NHCnLRYZAY45DccYxNI2SFXUBQi/dVA7BD1tBxQ45TjN+gE9Zg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEOD0XWvOaz9B2UFcw5RrhcipgjcSd+XPNWVLSy04coSnlVWGfwMeKQesvyfp7mWz+g==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAEApj4wdj8PshRBeBHvd2SsSr18NS/QWB+rmYv1OCftXreLIwY71Ia4oUFJ/sOfQd/Q==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHta1CW5R/e8UgU9GuMDkbWsFZl72aDT8mgV4R6c9ij8RPurSufXz4/Ub/gvcJ4jSA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAEFCWALX41EmIc6CCL1irScxsux+FLhF9r0YWCkb8ztkrptUbAZnMr/2OnjMFbDYxJg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEAy1p2qm3XfYvfmnSu9icpAeKDOovc0rgAC84IubA0U6kLWweAxHvp21ELiCb+rprA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAECH+ldeARDVxwIhH5o92Mz2ou0jvLdJ65mTo68Hrrt5jOxGTntX1BESQQAi9pV0dAw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMxhxabsf6zhzP8P6kA9eX2t+ipel6e2RdMdLcjjuYIKV3/m8nk9KjA7UJrjYHezWg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAEBl7QcHI4z0tS5TeD3dRu5HrTVC2p5sL0LvshE7egY3W9c+xF0MW+wFwNw+hJZwg0g==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEPkjSFXFBvwFBpCNqIYIy1ewsKHKuk4LdLwIBr7WAeIdVFv3+nkFfp19sOhtfefC8w==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                column: "password",
                value: "AQAAAAEAACcQAAAAEEw6r/tQ/maZbgwX8ojmZtumVO8Cj3Wtkd9fDC4dr+fShC5YSTzDEYoIlVr+YoDD7g==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 12,
                column: "password",
                value: "AQAAAAEAACcQAAAAEIR0Wx9aNU0srhUYWH6YIINg11dddii2REBIbRz2sgwckP2RhVSRY1nHYsn1xOBypA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 13,
                column: "password",
                value: "AQAAAAEAACcQAAAAEOMyM29V1HmP7rDsxylKV0bo0ZtAE23QPIP9Xek7YuVDt32I8F9Y2hSHO+zsI4xGHA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 14,
                column: "password",
                value: "AQAAAAEAACcQAAAAEF+h5z7BLd28DFQ5D/hmCbAtFElEbZet7exYGGcto4/59bP97U8XfwCQwFrPkXeKOw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 15,
                column: "password",
                value: "AQAAAAEAACcQAAAAEKGvKei91MWBCIdgL+vZPwNCwyAbuPqqYbypS0ee2Jpgl+4HpciHUDiw75XHEY6TFg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 16,
                column: "password",
                value: "AQAAAAEAACcQAAAAEKZSaWLA5CczfCY7DHNjSqoOvPqn2ffZQKJ+wyGybaTEVriJZMmoLyttRmrhGWCfqA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "course_materials",
                keyColumn: "id",
                keyValue: 16,
                column: "url",
                value: "https://seriouscomputerist.atariverse.com/media/pdf/book/C%20Programming%20Language%20-%202nd%20Edition%20(OCR).pdf");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2025, 10, 10, 12, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 10, 12, 5, 0, 0, DateTimeKind.Unspecified) });

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
    }
}
