using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_course_notification_users_CreatorId1",
                schema: "public",
                table: "course_notification");

            migrationBuilder.DropIndex(
                name: "IX_course_notification_CreatorId1",
                schema: "public",
                table: "course_notification");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                schema: "public",
                table: "course_notification");

            migrationBuilder.DropColumn(
                name: "CreatorId1",
                schema: "public",
                table: "course_notification");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                schema: "public",
                table: "course_notification",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId1",
                schema: "public",
                table: "course_notification",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_course_notification_CreatorId1",
                schema: "public",
                table: "course_notification",
                column: "CreatorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_course_notification_users_CreatorId1",
                schema: "public",
                table: "course_notification",
                column: "CreatorId1",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
