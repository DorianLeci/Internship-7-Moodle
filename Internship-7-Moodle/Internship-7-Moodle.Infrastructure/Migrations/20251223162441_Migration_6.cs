using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_course_users_owner_id",
                schema: "public",
                table: "course");

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

            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_role_id",
                schema: "public",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                schema: "public",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                schema: "public",
                table: "roles");

            migrationBuilder.RenameTable(
                name: "users",
                schema: "public",
                newName: "user",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "roles",
                schema: "public",
                newName: "role",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_users_role_id",
                schema: "public",
                table: "user",
                newName: "IX_user_role_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                schema: "public",
                table: "user",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "user",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                schema: "public",
                table: "role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                schema: "public",
                table: "user",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_role",
                schema: "public",
                table: "role",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_course_user_owner_id",
                schema: "public",
                table: "course",
                column: "owner_id",
                principalSchema: "public",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_course_user_user_user_id",
                schema: "public",
                table: "course_user",
                column: "user_id",
                principalSchema: "public",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_private_message_user_receiver_id",
                schema: "public",
                table: "private_message",
                column: "receiver_id",
                principalSchema: "public",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_private_message_user_sender_id",
                schema: "public",
                table: "private_message",
                column: "sender_id",
                principalSchema: "public",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_role_role_id",
                schema: "public",
                table: "user",
                column: "role_id",
                principalSchema: "public",
                principalTable: "role",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_course_user_owner_id",
                schema: "public",
                table: "course");

            migrationBuilder.DropForeignKey(
                name: "FK_course_user_user_user_id",
                schema: "public",
                table: "course_user");

            migrationBuilder.DropForeignKey(
                name: "FK_private_message_user_receiver_id",
                schema: "public",
                table: "private_message");

            migrationBuilder.DropForeignKey(
                name: "FK_private_message_user_sender_id",
                schema: "public",
                table: "private_message");

            migrationBuilder.DropForeignKey(
                name: "FK_user_role_role_id",
                schema: "public",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                schema: "public",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_role",
                schema: "public",
                table: "role");

            migrationBuilder.RenameTable(
                name: "user",
                schema: "public",
                newName: "users",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "role",
                schema: "public",
                newName: "roles",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_user_role_id",
                schema: "public",
                table: "users",
                newName: "IX_users_role_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                schema: "public",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                schema: "public",
                table: "roles",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "roles",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                schema: "public",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                schema: "public",
                table: "roles",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_course_users_owner_id",
                schema: "public",
                table: "course",
                column: "owner_id",
                principalSchema: "public",
                principalTable: "users",
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

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_role_id",
                schema: "public",
                table: "users",
                column: "role_id",
                principalSchema: "public",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
