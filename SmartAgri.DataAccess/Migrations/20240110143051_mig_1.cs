using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartAgri.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    CoinAccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    CoinAddress = table.Column<string>(type: "text", nullable: false),
                    ExternalCoinAddress = table.Column<string>(type: "text", nullable: true),
                    LockedBalance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adverts_AdvertStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "AdvertStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adverts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adverts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvertBuys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertBuys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertBuys_Adverts_Id",
                        column: x => x.Id,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvertSells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertSells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertSells_Adverts_Id",
                        column: x => x.Id,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TopicId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Replies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BuyAdvertId = table.Column<int>(type: "integer", nullable: false),
                    SellAdvertId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_AdvertBuys_BuyAdvertId",
                        column: x => x.BuyAdvertId,
                        principalTable: "AdvertBuys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_AdvertSells_SellAdvertId",
                        column: x => x.SellAdvertId,
                        principalTable: "AdvertSells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdvertStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "notProccess" },
                    { 3, "complated" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImagePath", "Name" },
                values: new object[] { 9, "wheat.png", "Buğday" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CoinAccountId", "CoinAddress", "Email", "ExternalCoinAddress", "LockedBalance", "Name", "Password", "RoleId", "Surname" },
                values: new object[,]
                {
                    { 1, new Guid("00000000-0000-0000-0000-000000000000"), "", "admin@admin.com", null, 0m, "admin", "admin123", 1, "admin" },
                    { 2, new Guid("1fbef5d8-950a-47df-b03d-755b9cb90aae"), "RRZ6bNDpVSywsMZvNmwtD1AYFtnupWaEH4", "hms45267@gmail.com", null, 0m, "Habil Mevlut", "admin123", 2, "Sayar" }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Quantity", "StatusId", "UnitPrice", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5474), 9, 100, 1, 295m, 2 },
                    { 2, new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5481), 9, 200, 1, 285m, 2 },
                    { 3, new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5482), 9, 250, 1, 280m, 2 },
                    { 4, new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5482), 9, 125, 1, 240m, 2 },
                    { 5, new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5483), 9, 175, 1, 230m, 2 },
                    { 6, new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5493), 9, 300, 1, 220m, 2 },
                    { 7, new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5493), 9, 200, 1, 210m, 2 },
                    { 8, new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5494), 9, 180, 1, 200m, 2 },
                    { 9, new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5495), 9, 150, 1, 190m, 2 },
                    { 10, new DateTime(2024, 1, 10, 17, 30, 51, 307, DateTimeKind.Local).AddTicks(5496), 9, 200, 1, 180m, 2 }
                });

            migrationBuilder.InsertData(
                table: "AdvertBuys",
                column: "Id",
                values: new object[]
                {
                    6,
                    7,
                    8,
                    9,
                    10
                });

            migrationBuilder.InsertData(
                table: "AdvertSells",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_ProductId",
                table: "Adverts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_StatusId",
                table: "Adverts",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_UserId",
                table: "Adverts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_TopicId",
                table: "Replies",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_UserId",
                table: "Replies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_UserId",
                table: "Topics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BuyAdvertId",
                table: "Transactions",
                column: "BuyAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SellAdvertId",
                table: "Transactions",
                column: "SellAdvertId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "AdvertBuys");

            migrationBuilder.DropTable(
                name: "AdvertSells");

            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "AdvertStatuses");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
