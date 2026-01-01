using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationAddUniqueIdx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_course_users_course_id",
                schema: "public",
                table: "course_users");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEPD+L8RXHv7ClK097ht3JzUu+i2aqFfUCaIXcACZgsyXUv8NRQIQXvHXYBURRwdj7Q==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEPcq/ghyWOccIgpVBF+Ab+B05Ippdrwh3n6mtxfpf7w6UOO/hCVZ4fudReLwzyun1w==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMzrzmN6zPqh8Ys8tlBIpVVLsd1QQJjDTqqAZsylikkzGQ/VVLR3vnVNU8oOBCMbbw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAEPlg43EPxiIDNzdMy50v+DN5yuNjGNrWZM8stXwtNSipAIE/5MkJgfkkxkAXonb4DQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAED4i6IA8lv2Ro4zbpMH3akTkrp/tfA8uf2bl461dGH7Vb9RdWGdoV/b7prxXfu7u6Q==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEKvcqmF7o1q1+L1O3T8Q34pEHKNcH5ENlAOp3cAJpJeS9CEoq4kE+LdT2rK5dgbVgA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHKFIQraFDcB/psFNNBVHEXedhUH5GAnYjwWFx3hA4vMkrxYosjS5E/ffHwqvgWFjA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAED1IMdvS7CCfimJ8xGsoY4EOj6R9by2wSyrTFHML/e/o8hML+HTtUJEfX5oLAnUSLg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAEL7JHg2QBL33S67svqH7hxpPK8aDY8t742mYgygGRulE7JXFsuHV5gulz7c5hDjQcw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEOrBOlbvTLKx2Pw1oyK+TwFGJN71FHmuEXqJEfvwWE+MKb3pIa2a+6AbUc7jWhMtKA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMPU0r4iUAZQH9aY9fygngrBMH7iUac4QmQJcjH2Gppoy5/aNF78BZFZoH4h71pT1Q==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 12,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMkmxEcIeK8qDnoM4lnhahj2fYeBdYAVCGvHyRsqzoBO11616MaO2Y8+OMDRlaRkLw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 13,
                column: "password",
                value: "AQAAAAEAACcQAAAAEJteQFHgXKznRu22NF45Itz2qzoNu9y+c5QvqWpu/O74F1nc4y8NWddv6rmodMCg9w==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 14,
                column: "password",
                value: "AQAAAAEAACcQAAAAEOww8zzK089iiKT8cgQzUMEvlqOS8S+lgE/QY8M1H4DPswEYuOt0Ys5yJvycJxaR6g==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 15,
                column: "password",
                value: "AQAAAAEAACcQAAAAEDDVXRfoDntjurF1ZeaGfl3dGicowb9sz3L4zB31y+JI4hY6CT287hioq9fcWMrmwQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 16,
                column: "password",
                value: "AQAAAAEAACcQAAAAEH0oEHehh2B0rRQqEjGkAiblr6Zr2g10IBUK4AD0P4ZQNkV4a0f1FW3qp3K2baoaDg==");

            migrationBuilder.CreateIndex(
                name: "IX_course_users_course_id_user_id",
                schema: "public",
                table: "course_users",
                columns: new[] { "course_id", "user_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_course_users_course_id_user_id",
                schema: "public",
                table: "course_users");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAELlVtvsc8M4EiRZ7FmLD4Btf214yEXkXnWlwce2E9hMHsGGeZdZhhZxXvT6/V/dm3w==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEL1wJ0JEOjLD2VhH7kB/TXnPNdRahIkEzHiCiPMr/iCP5GVGbunkaanoPiRRa8iN6g==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAELKCxygVaRPanhMMXMcwMp8YiF1cOt+pc6yaqKKhAMw48frlo2cJgimkPS2wf9YppA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAEOqosTg6DcBkkMfOfHeAwz0F+VwNzFOrLFiMdG0jMr4qqzrb25rOMIakvCwIKkKE8Q==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMPvAdlvX5DjAmd++1BhVR/seLcn3LCMbsjayt1c0iU6sdh+q7QGo/TWWBuPzrQfaQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEEkgqoHclO9AR5eCPQCP6fURv6WlJJNE3bj6ls6SwHSjW8+gYtpsyHuimyB86TSzag==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEJoCDo9HT5s3jZbLoYX/zuZFmRODEZ8ISaTfIWuPrtBddOKRUZ6lutBD5ZN8SbHZ/w==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMjWaVzxsRkghmOqPEYSVHOwHAYNXbO0WClhFfLK3yYVKPmzN5pQt01eOswbpN/iTQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAEBfQsmM1tkjz9bc14N82dVoJhcOXyfvR5sZljOjAtex/+9N4vlf1kpIAiWRuTU+OXQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEFjNqmNq0eTao3nroh4roz5gXYJHQl19ZFtVFo5j19iNxsV22KxoBQ6r5GSFx2h3qg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMdYSeuRIbVWW6qPJsTPLylliFsOUt97rFOxMmTwia+RXUALlyJdORFlasPLh9GEJg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 12,
                column: "password",
                value: "AQAAAAEAACcQAAAAEO7xt7VRnkC5bbkrVIK8rH/2Xb4gHzUDX3QCNcWLAzn66uOfwJpsgQREHdR9h++qQA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 13,
                column: "password",
                value: "AQAAAAEAACcQAAAAEH8lgFHiNeMBVUPZk85vUxdszpF4raKMSj/RrePHs+8BvLAS8gess82LG3dD1w3/eg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 14,
                column: "password",
                value: "AQAAAAEAACcQAAAAENDR1J3mjWCwNgYLV+cY0JgREqDuEuoh8iXMppuy4RFrXe4rXPRgHKhT08YmTrozXQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 15,
                column: "password",
                value: "AQAAAAEAACcQAAAAEF0hWn2KSQo3ZADOc+BhWOg6lfoAxlrLkvgOGl1kPBqp6U1ngTlyygcQ4wobOj4KlA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 16,
                column: "password",
                value: "AQAAAAEAACcQAAAAEF4XXYl/MnC1I3n+7Kz1b75TSkh6VH+QNInPopONm4PxofHirRjXf8Pb7xpHKBxGaA==");

            migrationBuilder.CreateIndex(
                name: "IX_course_users_course_id",
                schema: "public",
                table: "course_users",
                column: "course_id");
        }
    }
}
