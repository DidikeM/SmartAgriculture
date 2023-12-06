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
            migrationBuilder.CreateSequence(
                name: "AdvertSequence");

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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvertBuys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"AdvertSequence\"')"),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertBuys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertBuys_AdvertStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "AdvertStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertBuys_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertBuys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvertSells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"AdvertSequence\"')"),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertSells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertSells_AdvertStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "AdvertStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertSells_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertSells_Users_UserId",
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

            migrationBuilder.InsertData(
                table: "AdvertStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Aktif" },
                    { 2, "Pasif" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImagePath", "Name" },
                values: new object[] { 1, "wheat.png", "Buğday" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Surname" },
                values: new object[] { 1, "admin", "admin", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AdvertBuys",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Quantity", "StatusId", "UnitPrice", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 6, 14, 40, 54, 90, DateTimeKind.Local).AddTicks(4487), 1, 100, 1, 10m, 1 },
                    { 2, new DateTime(2023, 12, 6, 14, 40, 54, 90, DateTimeKind.Local).AddTicks(4495), 1, 200, 1, 20m, 1 }
                });

            migrationBuilder.InsertData(
                table: "AdvertSells",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Quantity", "StatusId", "UnitPrice", "UserId" },
                values: new object[,]
                {
                    { 3, new DateTime(2023, 12, 6, 14, 40, 54, 90, DateTimeKind.Local).AddTicks(4504), 1, 300, 1, 30m, 1 },
                    { 4, new DateTime(2023, 12, 6, 14, 40, 54, 90, DateTimeKind.Local).AddTicks(4505), 1, 400, 1, 40m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertBuys_ProductId",
                table: "AdvertBuys",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertBuys_StatusId",
                table: "AdvertBuys",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertBuys_UserId",
                table: "AdvertBuys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertSells_ProductId",
                table: "AdvertSells",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertSells_StatusId",
                table: "AdvertSells",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertSells_UserId",
                table: "AdvertSells",
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
                name: "AdvertStatuses");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropSequence(
                name: "AdvertSequence");
        }
    }
}
