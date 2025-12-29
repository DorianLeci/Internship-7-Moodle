using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUpdateChatSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "chat",
                keyColumn: "id",
                keyValue: 1,
                column: "updated_at",
                value: new DateTime(2025, 11, 11, 7, 45, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "chat",
                keyColumn: "id",
                keyValue: 2,
                column: "updated_at",
                value: new DateTime(2025, 10, 3, 9, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "chat",
                keyColumn: "id",
                keyValue: 3,
                column: "updated_at",
                value: new DateTime(2025, 12, 3, 14, 1, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "private_message",
                keyColumn: "id",
                keyValue: 5,
                column: "updated_at",
                value: new DateTime(2025, 12, 3, 14, 1, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "private_message",
                keyColumn: "id",
                keyValue: 6,
                column: "updated_at",
                value: new DateTime(2025, 12, 3, 14, 7, 0, 0, DateTimeKind.Unspecified));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "public",
                table: "chat",
                keyColumn: "id",
                keyValue: 1,
                column: "updated_at",
                value: new DateTime(2025, 11, 11, 9, 45, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "chat",
                keyColumn: "id",
                keyValue: 2,
                column: "updated_at",
                value: new DateTime(2025, 10, 3, 9, 45, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "chat",
                keyColumn: "id",
                keyValue: 3,
                column: "updated_at",
                value: new DateTime(2025, 10, 3, 14, 7, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "private_message",
                keyColumn: "id",
                keyValue: 5,
                column: "updated_at",
                value: new DateTime(2025, 10, 3, 14, 1, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "private_message",
                keyColumn: "id",
                keyValue: 6,
                column: "updated_at",
                value: new DateTime(2025, 10, 3, 14, 7, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEIBFy61RxwSkxbSmLSMns4NcTFVl6zSahOeFmiX31DwWhUBBDYW1UCpo9k9PWmHdQg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAENUW1gitQsJbd8RmFRRODEUR3srMvHQTHEk3PYw+r1eYFVqy7RX/Y74Km9jnIkvXtQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAEPqgci5Qfh9tKinXwI/3kpPoZ8rsbAqiSJsgadG3urreA7BOho8f96uPz78dcWVNeA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAEM2JiSP/Wqw1iAlT/u4Pac/UMZcngdLvBaxpwVl1ghloNVMjhqmaK2d9qNIvXz1F4Q==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAEImUURcrnV82w3sYQCIQcf00MU0v9JT9KotwozDhDROB58GwFYXRF1OXtI2FZsfvYA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAELURQJy7sJf7ByWb1Vlq7E/UbEeagFJfeLGu27pSoEYoYC9MzcDehUSCrBePfs8NKg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEADyaSFXsh5IpxahMm9QQZNPGSInXdo6drMoHUBgo62vERVvQeZPl/yM323Sh5Z2MQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAENQuump6N9d44GCJVsZISsEvHjQwKggpdxMsH3Gn027puoE6ZoQo39VT//ASmw1+Gw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHS3aHbkdXeeT1PnA2EL0igr4VpPCDdYJVq/cS9+bsc0Ikd+NDuWAJsrIHMpCvv0rA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEGsuOeWgeHJvQiBS277PP7VAHPEF7mZIOA919djuaWklixCDdx/aySzO5MP8gtoFdA==");
        }
    }
}
