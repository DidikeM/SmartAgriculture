using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartAgri.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AdvertBuys",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 20, 21, 42, 13, 300, DateTimeKind.Local).AddTicks(5127));

            migrationBuilder.UpdateData(
                table: "AdvertBuys",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 20, 21, 42, 13, 300, DateTimeKind.Local).AddTicks(5136));

            migrationBuilder.UpdateData(
                table: "AdvertSells",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 20, 21, 42, 13, 300, DateTimeKind.Local).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "AdvertSells",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 20, 21, 42, 13, 300, DateTimeKind.Local).AddTicks(5146));

            migrationBuilder.UpdateData(
                table: "AdvertStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "AdvertStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "notProccess");

            migrationBuilder.InsertData(
                table: "AdvertStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "complated" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "AdvertStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "AdvertBuys",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 6, 14, 40, 54, 90, DateTimeKind.Local).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "AdvertBuys",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 6, 14, 40, 54, 90, DateTimeKind.Local).AddTicks(4495));

            migrationBuilder.UpdateData(
                table: "AdvertSells",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 6, 14, 40, 54, 90, DateTimeKind.Local).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "AdvertSells",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 6, 14, 40, 54, 90, DateTimeKind.Local).AddTicks(4505));

            migrationBuilder.UpdateData(
                table: "AdvertStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Aktif");

            migrationBuilder.UpdateData(
                table: "AdvertStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Pasif");
        }
    }
}
