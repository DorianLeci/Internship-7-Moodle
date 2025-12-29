using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationAddChatEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_chat_user_a_id",
                schema: "public",
                table: "chat");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "chat",
                keyColumn: "id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 11, 9, 45, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "chat",
                keyColumn: "id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 3, 9, 45, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "chat",
                keyColumn: "id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 3, 14, 7, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEPt3ow7n6GrKHMHTbvOLL75SLkVxatuIRzxC/NQZKnOnN/L4FBxV46Vm4Q7XWbvz5g==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEB8sbhcDliZH8FwBeUSdvRdiTnVCLAfdJuNHgEv+UibWgJ7+h0OKG5uYJuQC2qVYyg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHff8cLnLAf8lG+mm/++07ZRhYfxIGSj/PSYhw0Vf73o2SiJgAJqfJJ/+sANuA7I5Q==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAEEFmDPKGMx7MahF8hcFbBLnnz0aMDqCPWklkqRo14/2UAilekMx1UXIdue5MPiYlFg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMaly9IqZ6lFjIAGJiMCnMlMkhc5PlN6uCXobImxJFbZ//e9aic9NxCbFIo9TZg7Bw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMqFKI5LeyKAX3rtV/za0NUM/uKJ0MaNB4aR9DCWODM2CoemLahjNKPaTnDfKZ4ILg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEFtBrCxaK9PxOhlK/Wsg8fTd+CD0tbUJWhrb/ZAIxkRSIWDC6wRL0YwxCb7ypHSsAA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMx0p/EzZOWFxPxRtat96bXlpSbfGBV/8qERb9ohYLdvMGmbttLPq/nex/2vUaWWtw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAECqulhIjh1QV51V2vicel0I9feXW1Nf07LyLKjpQKpMDJ0RRJtViHp5yv2wSKsCYVg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEDNaHuodd0AKU2jhvl2fMUCSoc3ePPb2DJQK0ElISq1AMTq5JdCtscNi8DfP+Wus6g==");

            migrationBuilder.CreateIndex(
                name: "IX_chat_user_a_id_user_b_id",
                schema: "public",
                table: "chat",
                columns: new[] { "user_a_id", "user_b_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_chat_user_a_id_user_b_id",
                schema: "public",
                table: "chat");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "chat",
                keyColumn: "id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 1, 7, 45, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "chat",
                keyColumn: "id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 3, 9, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "chat",
                keyColumn: "id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 3, 14, 1, 0, 0, DateTimeKind.Unspecified));

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
                name: "IX_chat_user_a_id",
                schema: "public",
                table: "chat",
                column: "user_a_id");
        }
    }
}
