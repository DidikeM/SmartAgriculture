using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmartAgri.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuestMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    IsReaded = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestMessages", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 16, 33, 22, 784, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 16, 33, 22, 784, DateTimeKind.Local).AddTicks(8850));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 16, 33, 22, 784, DateTimeKind.Local).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 16, 33, 22, 784, DateTimeKind.Local).AddTicks(8852));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 16, 33, 22, 784, DateTimeKind.Local).AddTicks(8853));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 16, 33, 22, 784, DateTimeKind.Local).AddTicks(8861));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 16, 33, 22, 784, DateTimeKind.Local).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 16, 33, 22, 784, DateTimeKind.Local).AddTicks(8863));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 16, 33, 22, 784, DateTimeKind.Local).AddTicks(8864));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 14, 16, 33, 22, 784, DateTimeKind.Local).AddTicks(8865));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestMessages");

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5474));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5481));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5482));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5482));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5494));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5495));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5496));
        }
    }
}
