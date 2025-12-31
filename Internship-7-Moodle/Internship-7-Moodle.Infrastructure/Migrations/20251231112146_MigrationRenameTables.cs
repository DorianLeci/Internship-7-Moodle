using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationRenameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chat_users_user_a_id",
                schema: "public",
                table: "chat");

            migrationBuilder.DropForeignKey(
                name: "FK_chat_users_user_b_id",
                schema: "public",
                table: "chat");

            migrationBuilder.DropForeignKey(
                name: "FK_course_users_owner_id",
                schema: "public",
                table: "course");

            migrationBuilder.DropForeignKey(
                name: "FK_course_material_course_course_id",
                schema: "public",
                table: "course_material");

            migrationBuilder.DropForeignKey(
                name: "FK_course_notification_course_course_id",
                schema: "public",
                table: "course_notification");

            migrationBuilder.DropForeignKey(
                name: "FK_course_user_course_course_id",
                schema: "public",
                table: "course_user");

            migrationBuilder.DropForeignKey(
                name: "FK_course_user_users_user_id",
                schema: "public",
                table: "course_user");

            migrationBuilder.DropForeignKey(
                name: "FK_private_message_chat_chat_id",
                schema: "public",
                table: "private_message");

            migrationBuilder.DropForeignKey(
                name: "FK_private_message_users_receiver_id",
                schema: "public",
                table: "private_message");

            migrationBuilder.DropForeignKey(
                name: "FK_private_message_users_sender_id",
                schema: "public",
                table: "private_message");

            migrationBuilder.DropForeignKey(
                name: "FK_users_role_role_id",
                schema: "public",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_role",
                schema: "public",
                table: "role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_private_message",
                schema: "public",
                table: "private_message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_course_user",
                schema: "public",
                table: "course_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_course_notification",
                schema: "public",
                table: "course_notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_course_material",
                schema: "public",
                table: "course_material");

            migrationBuilder.DropPrimaryKey(
                name: "PK_course",
                schema: "public",
                table: "course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_chat",
                schema: "public",
                table: "chat");

            migrationBuilder.RenameTable(
                name: "role",
                schema: "public",
                newName: "roles",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "private_message",
                schema: "public",
                newName: "private_messages",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "course_user",
                schema: "public",
                newName: "course_users",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "course_notification",
                schema: "public",
                newName: "course_notifications",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "course_material",
                schema: "public",
                newName: "course_materials",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "course",
                schema: "public",
                newName: "courses",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "chat",
                schema: "public",
                newName: "chats",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_private_message_sender_id",
                schema: "public",
                table: "private_messages",
                newName: "IX_private_messages_sender_id");

            migrationBuilder.RenameIndex(
                name: "IX_private_message_receiver_id",
                schema: "public",
                table: "private_messages",
                newName: "IX_private_messages_receiver_id");

            migrationBuilder.RenameIndex(
                name: "IX_private_message_chat_id",
                schema: "public",
                table: "private_messages",
                newName: "IX_private_messages_chat_id");

            migrationBuilder.RenameIndex(
                name: "IX_course_user_user_id",
                schema: "public",
                table: "course_users",
                newName: "IX_course_users_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_course_user_course_id",
                schema: "public",
                table: "course_users",
                newName: "IX_course_users_course_id");

            migrationBuilder.RenameIndex(
                name: "IX_course_notification_course_id",
                schema: "public",
                table: "course_notifications",
                newName: "IX_course_notifications_course_id");

            migrationBuilder.RenameIndex(
                name: "IX_course_material_course_id",
                schema: "public",
                table: "course_materials",
                newName: "IX_course_materials_course_id");

            migrationBuilder.RenameIndex(
                name: "IX_course_owner_id",
                schema: "public",
                table: "courses",
                newName: "IX_courses_owner_id");

            migrationBuilder.RenameIndex(
                name: "IX_chat_user_b_id",
                schema: "public",
                table: "chats",
                newName: "IX_chats_user_b_id");

            migrationBuilder.RenameIndex(
                name: "IX_chat_user_a_id_user_b_id",
                schema: "public",
                table: "chats",
                newName: "IX_chats_user_a_id_user_b_id");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                schema: "public",
                table: "users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                schema: "public",
                table: "users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                schema: "public",
                table: "users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                schema: "public",
                table: "roles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_private_messages",
                schema: "public",
                table: "private_messages",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_course_users",
                schema: "public",
                table: "course_users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_course_notifications",
                schema: "public",
                table: "course_notifications",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_course_materials",
                schema: "public",
                table: "course_materials",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_courses",
                schema: "public",
                table: "courses",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_chats",
                schema: "public",
                table: "chats",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_chats_users_user_a_id",
                schema: "public",
                table: "chats",
                column: "user_a_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_chats_users_user_b_id",
                schema: "public",
                table: "chats",
                column: "user_b_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_course_materials_courses_course_id",
                schema: "public",
                table: "course_materials",
                column: "course_id",
                principalSchema: "public",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_course_notifications_courses_course_id",
                schema: "public",
                table: "course_notifications",
                column: "course_id",
                principalSchema: "public",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_course_users_courses_course_id",
                schema: "public",
                table: "course_users",
                column: "course_id",
                principalSchema: "public",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_course_users_users_user_id",
                schema: "public",
                table: "course_users",
                column: "user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_courses_users_owner_id",
                schema: "public",
                table: "courses",
                column: "owner_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_private_messages_chats_chat_id",
                schema: "public",
                table: "private_messages",
                column: "chat_id",
                principalSchema: "public",
                principalTable: "chats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_private_messages_users_receiver_id",
                schema: "public",
                table: "private_messages",
                column: "receiver_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_private_messages_users_sender_id",
                schema: "public",
                table: "private_messages",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_user_a_id",
                schema: "public",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "FK_chats_users_user_b_id",
                schema: "public",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "FK_course_materials_courses_course_id",
                schema: "public",
                table: "course_materials");

            migrationBuilder.DropForeignKey(
                name: "FK_course_notifications_courses_course_id",
                schema: "public",
                table: "course_notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_course_users_courses_course_id",
                schema: "public",
                table: "course_users");

            migrationBuilder.DropForeignKey(
                name: "FK_course_users_users_user_id",
                schema: "public",
                table: "course_users");

            migrationBuilder.DropForeignKey(
                name: "FK_courses_users_owner_id",
                schema: "public",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "FK_private_messages_chats_chat_id",
                schema: "public",
                table: "private_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_private_messages_users_receiver_id",
                schema: "public",
                table: "private_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_private_messages_users_sender_id",
                schema: "public",
                table: "private_messages");

            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_role_id",
                schema: "public",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                schema: "public",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_private_messages",
                schema: "public",
                table: "private_messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_courses",
                schema: "public",
                table: "courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_course_users",
                schema: "public",
                table: "course_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_course_notifications",
                schema: "public",
                table: "course_notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_course_materials",
                schema: "public",
                table: "course_materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_chats",
                schema: "public",
                table: "chats");

            migrationBuilder.RenameTable(
                name: "roles",
                schema: "public",
                newName: "role",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "private_messages",
                schema: "public",
                newName: "private_message",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "courses",
                schema: "public",
                newName: "course",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "course_users",
                schema: "public",
                newName: "course_user",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "course_notifications",
                schema: "public",
                newName: "course_notification",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "course_materials",
                schema: "public",
                newName: "course_material",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "chats",
                schema: "public",
                newName: "chat",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_private_messages_sender_id",
                schema: "public",
                table: "private_message",
                newName: "IX_private_message_sender_id");

            migrationBuilder.RenameIndex(
                name: "IX_private_messages_receiver_id",
                schema: "public",
                table: "private_message",
                newName: "IX_private_message_receiver_id");

            migrationBuilder.RenameIndex(
                name: "IX_private_messages_chat_id",
                schema: "public",
                table: "private_message",
                newName: "IX_private_message_chat_id");

            migrationBuilder.RenameIndex(
                name: "IX_courses_owner_id",
                schema: "public",
                table: "course",
                newName: "IX_course_owner_id");

            migrationBuilder.RenameIndex(
                name: "IX_course_users_user_id",
                schema: "public",
                table: "course_user",
                newName: "IX_course_user_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_course_users_course_id",
                schema: "public",
                table: "course_user",
                newName: "IX_course_user_course_id");

            migrationBuilder.RenameIndex(
                name: "IX_course_notifications_course_id",
                schema: "public",
                table: "course_notification",
                newName: "IX_course_notification_course_id");

            migrationBuilder.RenameIndex(
                name: "IX_course_materials_course_id",
                schema: "public",
                table: "course_material",
                newName: "IX_course_material_course_id");

            migrationBuilder.RenameIndex(
                name: "IX_chats_user_b_id",
                schema: "public",
                table: "chat",
                newName: "IX_chat_user_b_id");

            migrationBuilder.RenameIndex(
                name: "IX_chats_user_a_id_user_b_id",
                schema: "public",
                table: "chat",
                newName: "IX_chat_user_a_id_user_b_id");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                schema: "public",
                table: "users",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                schema: "public",
                table: "users",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                schema: "public",
                table: "users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_role",
                schema: "public",
                table: "role",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_private_message",
                schema: "public",
                table: "private_message",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_course",
                schema: "public",
                table: "course",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_course_user",
                schema: "public",
                table: "course_user",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_course_notification",
                schema: "public",
                table: "course_notification",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_course_material",
                schema: "public",
                table: "course_material",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_chat",
                schema: "public",
                table: "chat",
                column: "id");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEDVAifB5Hwe7pOIOUfvPeMWtQr1Z1BMAgVEvSwq4vkI0S2+GYbMPu6KZ255rWbf8oQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEF5cmrJwzBC3756o2oZdp0DkmOlmjCenB5akwvJ6ZoZFU8IHdz15aSBkCkqAJu0mJw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAEFDGfBygrehxBmeDrM8LsQ3gKrOa49Vin0OC19dbvwavgGXKwYPm39AZBtG4qiDBSg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAENjlPbaKBM1hFDOSr71VFwvssht+4JCxOAwDXUDF8UiQJBs9f550VTzClx8x3a5dJA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHI1toPMjqGUWqKIjxJaHoyMs7jLTzDJZmrRQ9JAd/YmDFhY1OovL2ETTsTNdWd2Bg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEJnEEWwAmTCvUU7IsNAlu/s6FRxgR28OU+uWQDaketzy0JRrieEfkLWIzGIGuXiZqQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEGduA/cHdcM1hGmC93mR2XTAlL0U0ydnXkOTIG/NJX1Md7bXvWtr3YiNNJz6NSuStQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHLsp5KWl/K2BRfnJYLl6gHYhDicHu7qfndVjxwBQQb7QxPTPKr1cdzCLOZzf33beA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAECWWt49/ltdnCvHlaGPVf58EAVNq02VCZbYIoCbz4LLOC/hDNxkZkW8cS3rKLi0R+Q==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEGF74BrfjxLifrfiqCDICDwFYnkN6CoBCyJbkMr4TFiYDk1rj61fEuLsVWX9WbkLuA==");

            migrationBuilder.AddForeignKey(
                name: "FK_chat_users_user_a_id",
                schema: "public",
                table: "chat",
                column: "user_a_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_chat_users_user_b_id",
                schema: "public",
                table: "chat",
                column: "user_b_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_private_message_chat_chat_id",
                schema: "public",
                table: "private_message",
                column: "chat_id",
                principalSchema: "public",
                principalTable: "chat",
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
                name: "FK_users_role_role_id",
                schema: "public",
                table: "users",
                column: "role_id",
                principalSchema: "public",
                principalTable: "role",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
