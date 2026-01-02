using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationDeleteBehaviorUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_users_owner_id",
                schema: "public",
                table: "courses");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAELndo0Y4jIxUCA7zlj7SDaEwwWqm/VR0zWFZWuxNuzDEkIRPX8cZB1W4NYXxGq958g==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEG9fvvIaFoUStTeFfs2SkSayq4Mw5d7cHCZTlPWJzvwMr7hrhZX8ln8EiJ0SG1h5tQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAELIgcjh5fYslmOdNSSY0++fGfKWmgI25cgKVQ7+2eKHCpDrII9ZB7+U1Zzk4hfsPEQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAEJuHllVm+W4ZIqr/S4PUbTgdX6tBSI/SPmsj3WQuP6bqg8TjeMdQE0Gh5ZoE3Sel2Q==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAEGS1jZKX1TW5YdjP1y9m4hcYUauCNZpMRz7lY5VWaI/4puOGXL/s4yRjNJ9YF2EvlA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEGWlZhsnu91vw4iUDAyw3q3zNHkST7uqaPPUMY2A4c2zzsIwQ29bxYPDMZx0kVu8Zg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEA7bzoJy+ILBc8qXDM/C6vQ/DhpcHMycNr2lxF67oVyvCvvvNW3Ri3RnXMRVTUSgUw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAENsFCAF9NBHol4pDq/LYPLViU0003mC8CL22/tAcwIDWuq4kTlLLUFCRfCzUNvq9Hg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAELt/HQ48/oCwszqzzq35RmyNYfw2wtVY/kCJ3AdoeU0Qe6UvQOJOrZwcIC8MyJKCyA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEIW+I9D8bYJgu9QWQzOYzVhLD6fYQ82KX6r7XHfzz4DaPPBta6bIL4mF+7t0T4lJiA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                column: "password",
                value: "AQAAAAEAACcQAAAAEODEaJuIv7D2h49jh/EgXwU0YiftpAexApwUovYFVUKC+KLAqV8W/iGFo2Xk0U+LIQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 12,
                column: "password",
                value: "AQAAAAEAACcQAAAAEDCNUxNKaLpheAfvufdGtSxKpOn+rwddszWpX490soYXJQ3JYvAQod3gGzUVi3U1gA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 13,
                column: "password",
                value: "AQAAAAEAACcQAAAAECJ9VlAv8umWDQnxXn9iqf3dxQQSPHufTgun5EQv4NAvUSPehzfPsVHZaUXgHEgpgA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 14,
                column: "password",
                value: "AQAAAAEAACcQAAAAEFH7Bn56268SvHUc1JZRvZREe8ff/wTe/QRAWcajbMU4S3RmsxD9GE3o23i2C3ZpNg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 15,
                column: "password",
                value: "AQAAAAEAACcQAAAAENAAYzfJtM8lpZXpVJC76RnKYwjzbahisvyIABbfiHQlQ3qTup1tZvo3MvENDyP6Dw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 16,
                column: "password",
                value: "AQAAAAEAACcQAAAAEGTJwZF6+hzxbpkL1UV24C/0sJkwgFwgkXHBVGT6KGML/V2u6lvGsUNtJA4pIgqM3Q==");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_users_owner_id",
                schema: "public",
                table: "courses",
                column: "owner_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_users_owner_id",
                schema: "public",
                table: "courses");

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

            migrationBuilder.AddForeignKey(
                name: "FK_courses_users_owner_id",
                schema: "public",
                table: "courses",
                column: "owner_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
