using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_course_user_course_CourseId",
                schema: "public",
                table: "course_user");

            migrationBuilder.DropForeignKey(
                name: "FK_course_user_users_UserId",
                schema: "public",
                table: "course_user");

            migrationBuilder.DropForeignKey(
                name: "FK_private_message_users_ReceiverId",
                schema: "public",
                table: "private_message");

            migrationBuilder.DropForeignKey(
                name: "FK_private_message_users_SenderId",
                schema: "public",
                table: "private_message");

            migrationBuilder.RenameColumn(
                name: "Text",
                schema: "public",
                table: "private_message",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                schema: "public",
                table: "private_message",
                newName: "sender_id");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                schema: "public",
                table: "private_message",
                newName: "receiver_id");

            migrationBuilder.RenameColumn(
                name: "IsRead",
                schema: "public",
                table: "private_message",
                newName: "is_read");

            migrationBuilder.RenameIndex(
                name: "IX_private_message_SenderId",
                schema: "public",
                table: "private_message",
                newName: "IX_private_message_sender_id");

            migrationBuilder.RenameIndex(
                name: "IX_private_message_ReceiverId",
                schema: "public",
                table: "private_message",
                newName: "IX_private_message_receiver_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "public",
                table: "course_user",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                schema: "public",
                table: "course_user",
                newName: "course_id");

            migrationBuilder.RenameIndex(
                name: "IX_course_user_UserId",
                schema: "public",
                table: "course_user",
                newName: "IX_course_user_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_course_user_CourseId",
                schema: "public",
                table: "course_user",
                newName: "IX_course_user_course_id");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                schema: "public",
                table: "users",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                schema: "public",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                schema: "public",
                table: "users",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                schema: "public",
                table: "users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_course_user_course_course_id",
                schema: "public",
                table: "course_user",
                column: "course_id",
                principalSchema: "public",
                principalTable: "course",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_course_user_users_user_id",
                schema: "public",
                table: "course_user",
                column: "user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_private_message_users_receiver_id",
                schema: "public",
                table: "private_message",
                column: "receiver_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_private_message_users_sender_id",
                schema: "public",
                table: "private_message",
                column: "sender_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_course_user_course_course_id",
                schema: "public",
                table: "course_user");

            migrationBuilder.DropForeignKey(
                name: "FK_course_user_users_user_id",
                schema: "public",
                table: "course_user");

            migrationBuilder.DropForeignKey(
                name: "FK_private_message_users_receiver_id",
                schema: "public",
                table: "private_message");

            migrationBuilder.DropForeignKey(
                name: "FK_private_message_users_sender_id",
                schema: "public",
                table: "private_message");

            migrationBuilder.RenameColumn(
                name: "text",
                schema: "public",
                table: "private_message",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "sender_id",
                schema: "public",
                table: "private_message",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "receiver_id",
                schema: "public",
                table: "private_message",
                newName: "ReceiverId");

            migrationBuilder.RenameColumn(
                name: "is_read",
                schema: "public",
                table: "private_message",
                newName: "IsRead");

            migrationBuilder.RenameIndex(
                name: "IX_private_message_sender_id",
                schema: "public",
                table: "private_message",
                newName: "IX_private_message_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_private_message_receiver_id",
                schema: "public",
                table: "private_message",
                newName: "IX_private_message_ReceiverId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                schema: "public",
                table: "course_user",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "course_id",
                schema: "public",
                table: "course_user",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_course_user_user_id",
                schema: "public",
                table: "course_user",
                newName: "IX_course_user_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_course_user_course_id",
                schema: "public",
                table: "course_user",
                newName: "IX_course_user_CourseId");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                schema: "public",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "gender",
                schema: "public",
                table: "users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                schema: "public",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                schema: "public",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_course_user_course_CourseId",
                schema: "public",
                table: "course_user",
                column: "CourseId",
                principalSchema: "public",
                principalTable: "course",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_course_user_users_UserId",
                schema: "public",
                table: "course_user",
                column: "UserId",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_private_message_users_ReceiverId",
                schema: "public",
                table: "private_message",
                column: "ReceiverId",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_private_message_users_SenderId",
                schema: "public",
                table: "private_message",
                column: "SenderId",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
