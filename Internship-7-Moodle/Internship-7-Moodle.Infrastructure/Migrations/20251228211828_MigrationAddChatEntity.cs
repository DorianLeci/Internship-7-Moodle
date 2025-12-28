using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationAddChatEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "chat_id",
                schema: "public",
                table: "private_message",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "chat",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_a_id = table.Column<int>(type: "integer", nullable: false),
                    user_b_id = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat", x => x.id);
                    table.ForeignKey(
                        name: "FK_chat_users_user_a_id",
                        column: x => x.user_a_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chat_users_user_b_id",
                        column: x => x.user_b_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "chat",
                columns: new[] { "id", "CreatedAt", "UpdatedAt", "user_a_id", "user_b_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 11, 7, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 1, 7, 45, 0, 0, DateTimeKind.Unspecified), 1, 8 },
                    { 2, new DateTime(2025, 10, 3, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 3, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, 10 },
                    { 3, new DateTime(2025, 12, 3, 14, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 3, 14, 1, 0, 0, DateTimeKind.Unspecified), 1, 2 }
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "private_message",
                keyColumn: "id",
                keyValue: 1,
                column: "chat_id",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "private_message",
                keyColumn: "id",
                keyValue: 2,
                column: "chat_id",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "private_message",
                keyColumn: "id",
                keyValue: 3,
                column: "chat_id",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "private_message",
                keyColumn: "id",
                keyValue: 4,
                column: "chat_id",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "private_message",
                keyColumn: "id",
                keyValue: 5,
                column: "chat_id",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "private_message",
                keyColumn: "id",
                keyValue: 6,
                column: "chat_id",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAENOJGnVbpV6SUwqQE2Y1et3T1Vb5jSRukSY+gtHGp1XM2bJFxtUbh+h6SO1maG06tQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEGmvVKgtnONVcf2WO+6p6lQLW9M3eAOZR1eni7gnf5GjDfCD8xAP5KAdMK53hjxTmg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAEFf4uTLX7FMfey57LyYVYVukiN1j+TtUS0ldyKOtqhVP14rup/UTL3z3HuYtWm7tIw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAECnJMg8angLvpFUgu31EQBV9qTqgMqIlFNtRr69WQOWOG6YpQlK2nX8ke3/zaNghWA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAELiBlQ66SEPM9Xyt6G8XAajG8a1A1cRM9bFShvCbSy76XQMwqlKybidtHRwDc6hfQg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMGAnnLLlniNKfatGWbz1kz2H4iZ+Ld3AWgjDKIhLiyh4WEFlDK+F83hzvQ6/UdcgQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEJ3nty0A7BpAFxcQoQ2lk0dbXajGSw9XWFO0oxnHG7wWXuPiI8SzNVaZ8R4ZASL78Q==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMjxcpzlccs2YBB6eO9Jy9c06Vb+kc3GPYFLVZ23iHUzhJARWVpWtxrZaBf78rCDaA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMaawkwwmjJxl3V8JGkxo3ReVeHF3jlixduTtb54BQv2qttvL+biR6VO4os2ElHhIA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEP9fMXhsJI7YElVjkqx6hl8lbvQ3csoEsuQWs7Wy1RKAPVtjxLoO/zyq2UjFcaEM5g==");

            migrationBuilder.CreateIndex(
                name: "IX_private_message_chat_id",
                schema: "public",
                table: "private_message",
                column: "chat_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_user_a_id",
                schema: "public",
                table: "chat",
                column: "user_a_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_user_b_id",
                schema: "public",
                table: "chat",
                column: "user_b_id");

            migrationBuilder.AddForeignKey(
                name: "FK_private_message_chat_chat_id",
                schema: "public",
                table: "private_message",
                column: "chat_id",
                principalSchema: "public",
                principalTable: "chat",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_private_message_chat_chat_id",
                schema: "public",
                table: "private_message");

            migrationBuilder.DropTable(
                name: "chat",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_private_message_chat_id",
                schema: "public",
                table: "private_message");

            migrationBuilder.DropColumn(
                name: "chat_id",
                schema: "public",
                table: "private_message");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEKm/3IHqckA8OdyqTPVkWPmQyS4WMoGyNEyyYlrZwgzi/lgADDCJTvMcjusDDOW3Rw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEBakWKqFhbHxUpy4qFEj+7UlvjiqUCojS4a7VuOyVmTJCVS0lRSfaVWAnGS0nZbxBw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAEAyUS4sBFgKgPllHNCNuKgRfOWTZgdZTDkpVtCvQ9ofL7YPGICPnlyOQv/AV8dVdmg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAEAaliDfOwHojT58+56LVOO19mBUp/cse7F9Mg40XxKPzbIiyjGsui8Mf8f7SnHbrXQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAENciAk7mZA0GHZ4fBw+HfeZUbcfAxcxe8V1Ha+jIvZ8WuCNu5xHo+cnbZE+zrXY0Wg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEGok0uHumKhUrnTUsjPyJ89eskxOrmHlbQ69tgOh2QPZZMjU3crF3+WAoZACwJRSGw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAECzvAeEYV4h7TPUywV42Q9QBWmR+LN8T01BvG8NKuiqGVV2g5IoH51+Dqsi8EG6mfw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAEESK9A3HW5QNCdsccfzomp3WOS3YBn6nylwSPsT8aYpCubBXeF9LvDYXz7ZTGPU6IQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAEDULlQ5srg6yIrT79kh/mPtMcofB4/GG5dZwfNJk5Cpty6rRnw0d75lzMD0Pzlp8PQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEINAbLu7vyYgs4/K8605FcDzDBoZncxaanrgSVedjqaEpbMqOHOC8rgRDFwdy2XpsA==");
        }
    }
}
