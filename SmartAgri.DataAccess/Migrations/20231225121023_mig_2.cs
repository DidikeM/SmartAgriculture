using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAgri.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdvertBuys",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 15, 10, 23, 622, DateTimeKind.Local).AddTicks(3260));

            migrationBuilder.UpdateData(
                table: "AdvertBuys",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 15, 10, 23, 622, DateTimeKind.Local).AddTicks(3269));

            migrationBuilder.UpdateData(
                table: "AdvertSells",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 15, 10, 23, 622, DateTimeKind.Local).AddTicks(3277));

            migrationBuilder.UpdateData(
                table: "AdvertSells",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 15, 10, 23, 622, DateTimeKind.Local).AddTicks(3278));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "admin@admin.com", "admin123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdvertBuys",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 20, 23, 12, 29, 538, DateTimeKind.Local).AddTicks(2826));

            migrationBuilder.UpdateData(
                table: "AdvertBuys",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 20, 23, 12, 29, 538, DateTimeKind.Local).AddTicks(2837));

            migrationBuilder.UpdateData(
                table: "AdvertSells",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 20, 23, 12, 29, 538, DateTimeKind.Local).AddTicks(2843));

            migrationBuilder.UpdateData(
                table: "AdvertSells",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 20, 23, 12, 29, 538, DateTimeKind.Local).AddTicks(2844));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "admin", "admin" });
        }
    }
}
