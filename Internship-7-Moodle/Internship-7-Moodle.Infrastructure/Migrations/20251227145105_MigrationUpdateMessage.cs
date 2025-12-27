using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUpdateMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "text",
                schema: "public",
                table: "private_message",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "is_read",
                schema: "public",
                table: "private_message",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "course_material",
                keyColumn: "id",
                keyValue: 6,
                column: "title",
                value: "The C++ programming Language");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHqPeYf0y9Z/MHJv5V2XbSvd2K8LpMBkhDyi3w02oSmjy36MiJJKB4koJbkfHzaYKw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAENSuUTYeymnFQwMhmq3eLz8Oo6aobuxpcCqQseqaZy6Mi31Sd1n9xIsYi76ts+WA0g==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAENUfYIPBkxajBPa+w2Ss3/3zYaegUsaiPh2YE570dm7mei18/VyFv1CF5crgIBes+A==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAELr7QO6WlgcN/41P7bD+/SsyFqnTPTokUwQeeh+MbiIO/AJsPyb59V+PZPNOXnotrQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAEBICKLueA0+DS2/L5aeNkx2H6xndroi/Kgga2lPZiU5QOMB6ef/hIz3A+yzhaukmuA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEL66+bNCaKBHRvxY7OAfDlE7v1YBw9AUd8hoKvg1p+ySBEvPd6che8aAdjZNY/qZGQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEKnOraCDC8OB6/fQc70LgnmX/O5qEoGz4oJZa34Edx3Tt3aQ5wt++ALutj+GbUNwJQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAEA64fobg9Vma6Y4Bt8WoD+cWbRX2vO+342wD1QPqZ0Mw1Ycn/rDagjDdQgeUeoF6gQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAECNOmb/k3WXqrekVT8pYniuq3/UykdiRl1NdD+UJrxWSbMRVI8yHZsmsW7MRAQZ8PA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEE9IVoVqmqkLh65al8Bmd1B8C6Z6+AUy4XNvEEM5s92nZiqb69YkAlTTL5R22CnuuQ==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "text",
                schema: "public",
                table: "private_message",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<bool>(
                name: "is_read",
                schema: "public",
                table: "private_message",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "course_material",
                keyColumn: "id",
                keyValue: 6,
                column: "title",
                value: "The C++ programming Language,");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEL9Yy9ZHVvDbm5A4KKu3q/6wjinFJYqI39RJ2sg8HuXsmFNe/4yO+gE+Z0hvPh4//A==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEKOh9TMoGv3JvmfF75GFUDQy1ToNOifM8SzTB8hrkO7lGVfF06s8HLLTkDYPRfiTpQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAEJcgfyydNl2JH68dLga3TBpa+NAwdiDmo4eV4CUIM3XmlnXYytdl8De58dwbFXcgZQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAEPJBiHtJzd8f2ZZo5vIWsOg2R+LHlRX9jRz7b/gYbyPGaKoO5+Cc0EJDP44mb3KRhg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAEPkLzKF4xvEgmMpBS85B7gQ1cE5F5xxE3GnmAB9KtM8dvfdF2xfU2JgZYdpguA9Juw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEM8p46LMsUpgGnNmeIXac0iPJciGAonc0hnYN2g0gMzssGYNh9uPBPQnlBhz7Kt/YQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEC3Duur/K7XpOaqV0cX+XSW4Pbf/RT1vVZvqmlExFfqWbgnkp2L2whSN5WZfbQb+ww==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAELOtmm+XIcpu8DuI0MvJGqmLxDyVmPhDOvJgpEyhpwmBKk+WbB4JGwnFTZO8Gq+ABA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAEE/iYbGNOFYeE2Goqb3jGQ9ak2W7wpZYTMihA2URmady+i1yH2+oQ6eCQG17MH77Dw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEH4QZHN/xMatg/wvXFkFzDceIfyR/O8w4lrFNz7SWr1YvIgPNbOqHCBdSWs0ujgABg==");
        }
    }
}
