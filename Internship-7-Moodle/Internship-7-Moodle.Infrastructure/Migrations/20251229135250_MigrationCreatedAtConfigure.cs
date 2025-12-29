using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationCreatedAtConfigure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "chat",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "public",
                table: "chat",
                newName: "created_at");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                schema: "public",
                table: "chat",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "chat",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "public",
                table: "chat",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "public",
                table: "chat",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "public",
                table: "chat",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "chat",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()");

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
        }
    }
}
