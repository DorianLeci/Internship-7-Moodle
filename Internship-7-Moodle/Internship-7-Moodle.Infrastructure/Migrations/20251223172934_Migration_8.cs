using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration_8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_role_id",
                schema: "public",
                table: "user");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_id",
                schema: "public",
                table: "user",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_role_id",
                schema: "public",
                table: "user");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_id",
                schema: "public",
                table: "user",
                column: "role_id",
                unique: true);
        }
    }
}
