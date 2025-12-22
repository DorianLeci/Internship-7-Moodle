using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_course_material_course_CourseId",
                schema: "public",
                table: "course_material");

            migrationBuilder.DropForeignKey(
                name: "FK_course_notification_course_CourseId",
                schema: "public",
                table: "course_notification");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                schema: "public",
                table: "course_notification",
                newName: "course_id");

            migrationBuilder.RenameIndex(
                name: "IX_course_notification_CourseId",
                schema: "public",
                table: "course_notification",
                newName: "IX_course_notification_course_id");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                schema: "public",
                table: "course_material",
                newName: "course_id");

            migrationBuilder.RenameIndex(
                name: "IX_course_material_CourseId",
                schema: "public",
                table: "course_material",
                newName: "IX_course_material_course_id");

            migrationBuilder.AddForeignKey(
                name: "FK_course_material_course_course_id",
                schema: "public",
                table: "course_material",
                column: "course_id",
                principalSchema: "public",
                principalTable: "course",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_course_notification_course_course_id",
                schema: "public",
                table: "course_notification",
                column: "course_id",
                principalSchema: "public",
                principalTable: "course",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_course_material_course_course_id",
                schema: "public",
                table: "course_material");

            migrationBuilder.DropForeignKey(
                name: "FK_course_notification_course_course_id",
                schema: "public",
                table: "course_notification");

            migrationBuilder.RenameColumn(
                name: "course_id",
                schema: "public",
                table: "course_notification",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_course_notification_course_id",
                schema: "public",
                table: "course_notification",
                newName: "IX_course_notification_CourseId");

            migrationBuilder.RenameColumn(
                name: "course_id",
                schema: "public",
                table: "course_material",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_course_material_course_id",
                schema: "public",
                table: "course_material",
                newName: "IX_course_material_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_course_material_course_CourseId",
                schema: "public",
                table: "course_material",
                column: "CourseId",
                principalSchema: "public",
                principalTable: "course",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_course_notification_course_CourseId",
                schema: "public",
                table: "course_notification",
                column: "CourseId",
                principalSchema: "public",
                principalTable: "course",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
