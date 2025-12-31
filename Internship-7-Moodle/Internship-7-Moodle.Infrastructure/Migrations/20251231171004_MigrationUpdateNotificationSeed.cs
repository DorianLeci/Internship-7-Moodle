using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Internship_7_Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUpdateNotificationSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "subject",
                schema: "public",
                table: "course_notifications",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.InsertData(
                schema: "public",
                table: "course_notifications",
                columns: new[] { "id", "content", "course_id", "created_at", "subject", "updated_at" },
                values: new object[,]
                {
                    { 10, "Poštovani,\nidući tjedan (25.10.) predavanje će se održati s početkom u 11:45 (umjesto 10:45) u sali A102.", 5, new DateTime(2025, 10, 18, 7, 45, 0, 0, DateTimeKind.Unspecified), "Promjena rasporeda", new DateTime(2025, 10, 18, 7, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Poštovani,\nu prvom mjesecu kreću laboratorijske vježbe.U prvom mjesecu će biti obavijest o rasporedu po grupama", 5, new DateTime(2025, 12, 20, 15, 3, 0, 0, DateTimeKind.Unspecified), "Laboratorijske vježbe", new DateTime(2025, 12, 20, 15, 3, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Poštovani,\nNapomena u vezi laboratorijskih vježbi.Prije svake vježbe pisati će se ulazni ispiti.", 5, new DateTime(2025, 12, 20, 16, 10, 0, 0, DateTimeKind.Unspecified), "Laboratorijske vježbe: Napomena", new DateTime(2025, 12, 20, 16, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Poštovani,\nNapomena u vezi laboratorijskih vježbi.Prije svake vježbe pisati će se ulazni ispiti.", 5, new DateTime(2025, 12, 20, 16, 10, 0, 0, DateTimeKind.Unspecified), "Laboratorijske vježbe: Napomena", new DateTime(2025, 12, 20, 16, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Poštovani,\nu prvom mjesecu ću biti na poslovnom putu u Japanu,pa će asistent držati sva predavanja kroz mjesec.", 6, new DateTime(2025, 12, 21, 16, 10, 0, 0, DateTimeKind.Unspecified), "Promjena predavača", new DateTime(2025, 12, 21, 16, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Poštovani,\ndobio sam dosta upita što se tiče konzultacija. Možete doći bilo kada dok sam na faksu,samo se najavite preko maila.", 6, new DateTime(2025, 11, 21, 13, 12, 0, 0, DateTimeKind.Unspecified), "Konzultacije", new DateTime(2025, 11, 21, 13, 12, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "Poštovani,\nrok za predaju praktičnog rada je do kraja prvog mjeseca.Sretno!", 7, new DateTime(2025, 12, 30, 13, 12, 0, 0, DateTimeKind.Unspecified), "Predaja praktičnog rada", new DateTime(2025, 12, 30, 13, 12, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "Poštovani,\novaj kolegij ne sadrži drugi kolokvij.U završnu ocjenu ulazi prvi kolokvij i ocjena iz praktičnog rada.", 7, new DateTime(2025, 12, 30, 20, 0, 0, 0, DateTimeKind.Unspecified), "Drugi kolokvij", new DateTime(2025, 12, 30, 20, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEP/vRrCcD4IGBZ//hjPKYsq7wgzgOiB59Fbgg2LPVeVNf9ovU8bRvevy6ymcLPITmw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEFPk+z7JQ8vRD1lEaNmgNgsr7S3lIiRuu3GAprj8foQnFjss5HK8GNWJztLIoHb/vQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHM67djB23fMslWNGPBo0dZ1b2GFF6jsNDaIZw+0t2hpc8cbUptCKMrt7KdHlr4Irg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAENVeq5vwudUyG1E6xDUUZXozknZQhVG9712cIWSvy57VVuGYUDg15Gf4YUTmKEf5Cw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAEOKHZ1xF6YqqRNYrBc99Y8NU6H5OxmN5vMkNNZ3f6eClDIPapK0Es1irMF4ZtfPDGw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAEEMWHi9taeRqtqFZ7bxqahlNGoyn/wV3XV2y+Y2IxzZ/Nzi+O1OQnTCWOJGC9ZgtNQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEL6b22vTiXssoomuNoYmy6nXO85k3Vivrvs3iHjyQKhLzDRey6ieZPrZD/6zeOgFag==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAEMjp5ZLi2j8APSJlRQTG0t3fv6b42MYU/oX+WqA6gKNmSdzr6ckFDQxN2mxwVhttaA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAEAadp7cAToqrgLbcvJy+CRCRCHsBIsl3CmmLtBEfjn7/L0mq/KmlI/DcMLm7y6s2cw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEFeSDOl/5oJf/LOcVR3QRN/EefckEUycWFCabPetQJxQcP4eC1OYFbhGaz/q3fdZuA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                column: "password",
                value: "AQAAAAEAACcQAAAAEK+DfWMY798lWfnFfqVx4XgESiQgryZilUmF4Qm1OKBA3wiDOP6PYT2bvvz3fUsb9w==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 12,
                column: "password",
                value: "AQAAAAEAACcQAAAAEC56RbtJpMxhRsHZZSsOYN+FdsPvsJ/8CJqjLr1jT63LuAuU4xHbXL4pR8/iBa/kGw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 13,
                column: "password",
                value: "AQAAAAEAACcQAAAAEBKOYbwqtKSCjJsZT7AlCGzgXjtmSJl699kpjMN11S2Z+ToOwx4w7wEFwVO5gaND8A==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 14,
                column: "password",
                value: "AQAAAAEAACcQAAAAEM0jFEv+FLmo9h8PxcPEttz0W8y+v/kyVSko7bybKfHvJKnFoDXx/tqOD+WzPRtfmA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 15,
                column: "password",
                value: "AQAAAAEAACcQAAAAENJ8I8g3JeaA7XbmQBNMp69XBLdb7kYZZdtIqnl2cBr+Y1/eJ6tUWKyBBSdvFqj5Lw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 16,
                column: "password",
                value: "AQAAAAEAACcQAAAAEJWHkqnJxeVEp66ebacqpVMICjy4X0eQ4lhZ1PI3b9afRJK1azMuPpczU66oGGZc+Q==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "course_notifications",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.AlterColumn<string>(
                name: "subject",
                schema: "public",
                table: "course_notifications",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHm4WbHEoNZ2G+k12lSe5vki11Uvrs3tki+XjnkMZj8P+gapujObj9yaJ7zFtbqB8w==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "AQAAAAEAACcQAAAAEKeVUKLd5b/q/eySR+kEReyrckk1ifyDTa6gXIHMSC49o0cpmmkTx0FscynrcbiRNQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHYLmB0OPIN3psDR2486ew5l/Qzo8l0YyT2ujOyIRtO7fPZ8MHyI71/ngkYhlwA6WQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "AQAAAAEAACcQAAAAEEqvEuoun+UWVlDU1b0ziVs6Df0T4IULB4rMItGRcJ1JiVFYGJbx0jlOaibBBroDEg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "AQAAAAEAACcQAAAAEKAeqjDTevwDwe1lX7cgbGOJL6XoWp3AkXXniLT/AwfEHObMPP7K1N+ymMiVPPsJiA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "AQAAAAEAACcQAAAAELK1xn9GBHGbcQ2qdIfcq9JsjXZubNBvSbJvlRWLjCUA7j3hX6OpfahGK0ZCVjzEGA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 7,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHHxWwKjYtT0QMr2Ia/1n/yk9zm8+EERtM2ZIp45RJEc91QuSVJ29Ai0tH5E6WJSwA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 8,
                column: "password",
                value: "AQAAAAEAACcQAAAAEN6lstBrm1I4iuZmze4kEYsfnQqIKEfz7IK9PJ9HHKA339g36nRU/bz+rVJwSJ6eMA==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 9,
                column: "password",
                value: "AQAAAAEAACcQAAAAEGYRNEtkTMsIXLNck+VFviyT1KPMjAc5hrl9/01YDjhgAGDJfYsyVhttib9xV48oEQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 10,
                column: "password",
                value: "AQAAAAEAACcQAAAAEH5KthH4MsXQIfYHMpEuK5SAnikqmLA5F8fN2gcwG7sx5/92ZfPcf6MlhMjyPeqJTQ==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 11,
                column: "password",
                value: "AQAAAAEAACcQAAAAEB0VGaE9zxzUn8B5Xn699dKy33xPd4Q+GEJ3DUTlRAlYkBBQUxm/Igtq+GByXWS+Lw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 12,
                column: "password",
                value: "AQAAAAEAACcQAAAAEPy0cLxpJCClUsH9bSTgYxk3cgemA6OBsiQ5Q4tgyBG+c9KdjVqAPfIuZ42WyfVH7g==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 13,
                column: "password",
                value: "AQAAAAEAACcQAAAAEAg9gCAtxyzVHKIj8BvPnymKEXT9mbyzk099yWWIMO/gpTW2aO7KFwbmnhOK4pwpWg==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 14,
                column: "password",
                value: "AQAAAAEAACcQAAAAEBX8We+zehFHGxl3uuNh9St8Xqpd5gVkDoCSTyU6m5NuAPqmMkOZIlZkPEGH3pG9Qw==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 15,
                column: "password",
                value: "AQAAAAEAACcQAAAAEJ11FuealVkeTpqgcfkTf7mSe1lNuAvCsFp4cokVVMoQpeNouJymTjQJF6YUS0ll5A==");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "users",
                keyColumn: "id",
                keyValue: 16,
                column: "password",
                value: "AQAAAAEAACcQAAAAEHJOIb0hXtBatgmDMxvExmhC2brpVWNOVFTkkZt/pPWM/ZYsEL1pel/52wZQcs0XCw==");
        }
    }
}
