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
                values: new object[,]
                {
                    { 1, "banana.png", "Banana" },
                    { 2, "barley.png", "Barley" },
                    { 3, "cocoa.png", "Cocoa" },
                    { 4, "corn.png", "Corn" },
                    { 5, "cotton.png", "Cotton" },
                    { 6, "soybean.png", "Soybean" },
                    { 7, "sugar.png", "Sugar" },
                    { 8, "sunfloweroil.png", "SunflowerOil" },
                    { 9, "wheat.png", "Wheat" }
                });

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
                    { 2, new Guid("1fbef5d8-950a-47df-b03d-755b9cb90aae"), "RRZ6bNDpVSywsMZvNmwtD1AYFtnupWaEH4", "hms45267@gmail.com", null, 0m, "Habil Mevlut", "admin123", 2, "Sayar" },
                    { 3, new Guid("9d503f4f-db9c-49d3-996b-24e0eba679ec"), "", "user3@user.com", null, 0m, "User3", "user123", 2, "User3" },
                    { 4, new Guid("c2535cc2-8314-4e43-8b25-a1bfe5286e73"), "", "user4@user.com", null, 0m, "User4", "user123", 2, "User4" },
                    { 5, new Guid("1e300305-f613-4433-a42b-dcb3857f390f"), "", "user5@user.com", null, 0m, "User5", "user123", 2, "User5" },
                    { 6, new Guid("1022c804-71c3-431f-a008-8a9fd48bb0e6"), "", "user6@user.com", null, 0m, "User6", "user123", 2, "User6" },
                    { 7, new Guid("331301b4-b6a5-439c-9f08-cc7ead4a9b44"), "", "user7@user.com", null, 0m, "User7", "user123", 2, "User7" },
                    { 8, new Guid("12725ba0-c976-4841-b7e9-40cc8b965775"), "", "user8@user.com", null, 0m, "User8", "user123", 2, "User8" },
                    { 9, new Guid("54fddf33-ce5f-4aa1-bb49-8849f6aab20b"), "", "user9@user.com", null, 0m, "User9", "user123", 2, "User9" },
                    { 10, new Guid("75e16c0f-a9ea-4230-a88a-b757c33b2b0a"), "", "user10@user.com", null, 0m, "User10", "user123", 2, "User10" },
                    { 11, new Guid("537a20fa-1c3b-46c2-a585-6214a616ed18"), "", "user11@user.com", null, 0m, "User11", "user123", 2, "User11" },
                    { 12, new Guid("90dce2c7-5147-49bc-ad0e-0ec3c477a668"), "", "user12@user.com", null, 0m, "User12", "user123", 2, "User12" },
                    { 13, new Guid("cf3fc2fb-52f9-4ed3-ab86-5dfd5ef830a6"), "", "user13@user.com", null, 0m, "User13", "user123", 2, "User13" },
                    { 14, new Guid("380b3bc4-a787-4b98-a890-c7a450b225ce"), "", "user14@user.com", null, 0m, "User14", "user123", 2, "User14" }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Quantity", "StatusId", "UnitPrice", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(2991), 1, 100, 3, 1614m, 3 },
                    { 2, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3001), 1, 100, 3, 1614m, 4 },
                    { 3, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3004), 1, 100, 3, 1595m, 3 },
                    { 4, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3005), 1, 100, 3, 1595m, 4 },
                    { 5, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3007), 1, 100, 3, 1554m, 3 },
                    { 6, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3007), 1, 100, 3, 1554m, 4 },
                    { 7, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3009), 1, 100, 3, 1560m, 3 },
                    { 8, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3009), 1, 100, 3, 1560m, 4 },
                    { 9, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3010), 1, 100, 3, 1567m, 3 },
                    { 10, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3012), 1, 100, 3, 1567m, 4 },
                    { 11, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3014), 2, 100, 3, 180m, 4 },
                    { 12, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3015), 2, 100, 3, 180m, 5 },
                    { 13, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3016), 2, 100, 3, 175m, 4 },
                    { 14, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3017), 2, 100, 3, 175m, 5 },
                    { 15, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3018), 2, 100, 3, 172m, 4 },
                    { 16, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3019), 2, 100, 3, 172m, 5 },
                    { 17, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3020), 2, 100, 3, 159m, 4 },
                    { 18, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3021), 2, 100, 3, 159m, 5 },
                    { 19, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3024), 2, 100, 3, 148m, 4 },
                    { 20, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3024), 2, 100, 3, 148m, 5 },
                    { 21, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3026), 3, 100, 3, 2905m, 5 },
                    { 22, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3026), 3, 100, 3, 2905m, 6 },
                    { 23, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3027), 3, 100, 3, 3124m, 5 },
                    { 24, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3028), 3, 100, 3, 3124m, 6 },
                    { 25, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3029), 3, 100, 3, 3346m, 5 },
                    { 26, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3030), 3, 100, 3, 3346m, 6 },
                    { 27, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3031), 3, 100, 3, 3434m, 5 },
                    { 28, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3031), 3, 100, 3, 3434m, 6 },
                    { 29, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3032), 3, 100, 3, 3629m, 5 },
                    { 30, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3033), 3, 100, 3, 3629m, 6 },
                    { 31, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3034), 4, 100, 3, 268m, 6 },
                    { 32, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3035), 4, 100, 3, 268m, 7 },
                    { 33, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3036), 4, 100, 3, 266m, 6 },
                    { 34, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3037), 4, 100, 3, 266m, 7 },
                    { 35, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3040), 4, 100, 3, 235m, 6 },
                    { 36, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3040), 4, 100, 3, 235m, 7 },
                    { 37, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3041), 4, 100, 3, 207m, 6 },
                    { 38, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3042), 4, 100, 3, 207m, 7 },
                    { 39, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3043), 4, 100, 3, 223m, 6 },
                    { 40, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3044), 4, 100, 3, 223m, 7 },
                    { 41, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3045), 5, 100, 3, 93m, 7 },
                    { 42, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3074), 5, 100, 3, 93m, 8 },
                    { 43, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3075), 5, 100, 3, 92m, 7 },
                    { 44, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3076), 5, 100, 3, 92m, 8 },
                    { 45, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3077), 5, 100, 3, 93m, 7 },
                    { 46, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3077), 5, 100, 3, 93m, 8 },
                    { 47, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3078), 5, 100, 3, 95m, 7 },
                    { 48, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3079), 5, 100, 3, 95m, 8 },
                    { 49, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3080), 5, 100, 3, 97m, 7 },
                    { 50, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3081), 5, 100, 3, 97m, 8 },
                    { 51, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3082), 6, 100, 3, 508m, 8 },
                    { 52, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3082), 6, 100, 3, 508m, 9 },
                    { 53, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3083), 6, 100, 3, 526m, 8 },
                    { 54, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3084), 6, 100, 3, 526m, 9 },
                    { 55, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3085), 6, 100, 3, 555m, 8 },
                    { 56, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3086), 6, 100, 3, 555m, 9 },
                    { 57, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3087), 6, 100, 3, 510m, 8 },
                    { 58, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3087), 6, 100, 3, 510m, 9 },
                    { 59, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3088), 6, 100, 3, 487m, 8 },
                    { 60, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3089), 6, 100, 3, 487m, 9 },
                    { 61, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3090), 7, 100, 3, 21m, 9 },
                    { 62, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3090), 7, 100, 3, 21m, 10 },
                    { 63, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3092), 7, 100, 3, 20m, 9 },
                    { 64, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3092), 7, 100, 3, 20m, 10 },
                    { 65, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3093), 7, 100, 3, 21m, 9 },
                    { 66, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3095), 7, 100, 3, 21m, 10 },
                    { 67, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3098), 7, 100, 3, 21m, 9 },
                    { 68, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3098), 7, 100, 3, 21m, 10 },
                    { 69, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3099), 7, 100, 3, 21m, 9 },
                    { 70, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3100), 7, 100, 3, 21m, 10 },
                    { 71, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3101), 8, 100, 3, 1129m, 10 },
                    { 72, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3102), 8, 100, 3, 1129m, 11 },
                    { 73, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3103), 8, 100, 3, 1108m, 10 },
                    { 74, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3103), 8, 100, 3, 1108m, 11 },
                    { 75, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3104), 8, 100, 3, 1253m, 10 },
                    { 76, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3105), 8, 100, 3, 1253m, 11 },
                    { 77, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3106), 8, 100, 3, 1182m, 10 },
                    { 78, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3106), 8, 100, 3, 1182m, 11 },
                    { 79, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3107), 8, 100, 3, 1084m, 10 },
                    { 80, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3108), 8, 100, 3, 1084m, 11 },
                    { 81, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3109), 9, 100, 3, 299m, 11 },
                    { 82, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3110), 9, 100, 3, 299m, 12 },
                    { 83, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3111), 9, 100, 3, 282m, 11 },
                    { 84, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3111), 9, 100, 3, 282m, 12 },
                    { 85, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3112), 9, 100, 3, 278m, 11 },
                    { 86, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3113), 9, 100, 3, 278m, 12 },
                    { 87, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3114), 9, 100, 3, 241m, 11 },
                    { 88, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3115), 9, 100, 3, 241m, 12 },
                    { 89, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3116), 9, 100, 3, 229m, 11 },
                    { 90, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3116), 9, 100, 3, 229m, 12 },
                    { 91, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3118), 1, 100, 1, 1540m, 13 },
                    { 92, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3119), 1, 100, 1, 1530m, 12 },
                    { 93, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3120), 1, 100, 1, 1550m, 13 },
                    { 94, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3121), 1, 100, 1, 1520m, 12 },
                    { 95, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3121), 1, 100, 1, 1560m, 13 },
                    { 96, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3169), 1, 100, 1, 1510m, 12 },
                    { 97, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3170), 1, 100, 1, 1570m, 13 },
                    { 98, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3170), 1, 100, 1, 1500m, 12 },
                    { 99, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3171), 1, 100, 1, 1580m, 13 },
                    { 100, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3171), 1, 100, 1, 1490m, 12 },
                    { 101, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3172), 2, 100, 1, 155m, 12 },
                    { 102, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3173), 2, 100, 1, 150m, 11 },
                    { 103, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3174), 2, 100, 1, 156m, 12 },
                    { 104, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3174), 2, 100, 1, 145m, 11 },
                    { 105, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3175), 2, 100, 1, 157m, 12 },
                    { 106, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3175), 2, 100, 1, 140m, 11 },
                    { 107, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3176), 2, 100, 1, 158m, 12 },
                    { 108, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3176), 2, 100, 1, 135m, 11 },
                    { 109, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3177), 2, 100, 1, 159m, 12 },
                    { 110, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3178), 2, 100, 1, 130m, 11 },
                    { 111, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3178), 3, 100, 1, 3450m, 11 },
                    { 112, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3179), 3, 100, 1, 3440m, 10 },
                    { 113, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3179), 3, 100, 1, 3460m, 11 },
                    { 114, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3180), 3, 100, 1, 3430m, 10 },
                    { 115, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3180), 3, 100, 1, 3470m, 11 },
                    { 116, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3181), 3, 100, 1, 3420m, 10 },
                    { 117, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3182), 3, 100, 1, 3480m, 11 },
                    { 118, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3182), 3, 100, 1, 3410m, 10 },
                    { 119, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3183), 3, 100, 1, 3490m, 11 },
                    { 120, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3183), 3, 100, 1, 3400m, 10 },
                    { 121, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3184), 4, 100, 1, 200m, 10 },
                    { 122, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3185), 4, 100, 1, 190m, 9 },
                    { 123, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3185), 4, 100, 1, 210m, 10 },
                    { 124, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3186), 4, 100, 1, 180m, 9 },
                    { 125, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3186), 4, 100, 1, 220m, 10 },
                    { 126, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3187), 4, 100, 1, 170m, 9 },
                    { 127, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3188), 4, 100, 1, 230m, 10 },
                    { 128, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3188), 4, 100, 1, 160m, 9 },
                    { 129, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3189), 4, 100, 1, 240m, 10 },
                    { 130, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3191), 4, 100, 1, 150m, 9 },
                    { 131, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3192), 5, 100, 1, 100m, 9 },
                    { 132, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3193), 5, 100, 1, 95m, 8 },
                    { 133, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3194), 5, 100, 1, 110m, 9 },
                    { 134, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3194), 5, 100, 1, 90m, 8 },
                    { 135, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3195), 5, 100, 1, 120m, 9 },
                    { 136, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3195), 5, 100, 1, 85m, 8 },
                    { 137, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3196), 5, 100, 1, 130m, 9 },
                    { 138, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3197), 5, 100, 1, 80m, 8 },
                    { 139, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3197), 5, 100, 1, 140m, 9 },
                    { 140, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3198), 5, 100, 1, 75m, 8 },
                    { 141, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3198), 6, 100, 1, 510m, 8 },
                    { 142, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3199), 6, 100, 1, 500m, 7 },
                    { 143, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3200), 6, 100, 1, 520m, 8 },
                    { 144, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3200), 6, 100, 1, 490m, 7 },
                    { 145, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3201), 6, 100, 1, 530m, 8 },
                    { 146, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3201), 6, 100, 1, 480m, 7 },
                    { 147, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3202), 6, 100, 1, 540m, 8 },
                    { 148, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3202), 6, 100, 1, 470m, 7 },
                    { 149, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3203), 6, 100, 1, 550m, 8 },
                    { 150, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3203), 6, 100, 1, 460m, 7 },
                    { 151, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3204), 7, 100, 1, 22m, 7 },
                    { 152, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3205), 7, 100, 1, 21m, 6 },
                    { 153, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3205), 7, 100, 1, 23m, 7 },
                    { 154, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3206), 7, 100, 1, 20m, 6 },
                    { 155, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3206), 7, 100, 1, 24m, 7 },
                    { 156, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3207), 7, 100, 1, 19m, 6 },
                    { 157, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3208), 7, 100, 1, 25m, 7 },
                    { 158, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3208), 7, 100, 1, 18m, 6 },
                    { 159, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3235), 7, 100, 1, 26m, 7 },
                    { 160, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3236), 7, 100, 1, 17m, 6 },
                    { 161, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3237), 8, 100, 1, 1150m, 6 },
                    { 162, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3237), 8, 100, 1, 1140m, 5 },
                    { 163, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3238), 8, 100, 1, 1160m, 6 },
                    { 164, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3239), 8, 100, 1, 1130m, 5 },
                    { 165, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3239), 8, 100, 1, 1270m, 6 },
                    { 166, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3240), 8, 100, 1, 1120m, 5 },
                    { 167, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3240), 8, 100, 1, 1180m, 6 },
                    { 168, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3241), 8, 100, 1, 1110m, 5 },
                    { 169, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3241), 8, 100, 1, 1090m, 6 },
                    { 170, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3242), 8, 100, 1, 1100m, 5 },
                    { 171, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3242), 9, 100, 1, 230m, 5 },
                    { 172, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3243), 9, 100, 1, 220m, 4 },
                    { 173, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3244), 9, 100, 1, 240m, 5 },
                    { 174, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3244), 9, 100, 1, 210m, 4 },
                    { 175, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3245), 9, 100, 1, 250m, 5 },
                    { 176, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3245), 9, 100, 1, 200m, 4 },
                    { 177, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3246), 9, 100, 1, 260m, 5 },
                    { 178, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3247), 9, 100, 1, 190m, 4 },
                    { 179, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3247), 9, 100, 1, 270m, 5 },
                    { 180, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3248), 9, 100, 1, 180m, 4 }
                });

            migrationBuilder.InsertData(
                table: "AdvertBuys",
                column: "Id",
                values: new object[]
                {
                    2,
                    4,
                    6,
                    8,
                    10,
                    12,
                    14,
                    16,
                    18,
                    20,
                    22,
                    24,
                    26,
                    28,
                    30,
                    32,
                    34,
                    36,
                    38,
                    40,
                    42,
                    44,
                    46,
                    48,
                    50,
                    52,
                    54,
                    56,
                    58,
                    60,
                    62,
                    64,
                    66,
                    68,
                    70,
                    72,
                    74,
                    76,
                    78,
                    80,
                    82,
                    84,
                    86,
                    88,
                    90,
                    92,
                    94,
                    96,
                    98,
                    100,
                    102,
                    104,
                    106,
                    108,
                    110,
                    112,
                    114,
                    116,
                    118,
                    120,
                    122,
                    124,
                    126,
                    128,
                    130,
                    132,
                    134,
                    136,
                    138,
                    140,
                    142,
                    144,
                    146,
                    148,
                    150,
                    152,
                    154,
                    156,
                    158,
                    160,
                    162,
                    164,
                    166,
                    168,
                    170,
                    172,
                    174,
                    176,
                    178,
                    180
                });

            migrationBuilder.InsertData(
                table: "AdvertSells",
                column: "Id",
                values: new object[]
                {
                    1,
                    3,
                    5,
                    7,
                    9,
                    11,
                    13,
                    15,
                    17,
                    19,
                    21,
                    23,
                    25,
                    27,
                    29,
                    31,
                    33,
                    35,
                    37,
                    39,
                    41,
                    43,
                    45,
                    47,
                    49,
                    51,
                    53,
                    55,
                    57,
                    59,
                    61,
                    63,
                    65,
                    67,
                    69,
                    71,
                    73,
                    75,
                    77,
                    79,
                    81,
                    83,
                    85,
                    87,
                    89,
                    91,
                    93,
                    95,
                    97,
                    99,
                    101,
                    103,
                    105,
                    107,
                    109,
                    111,
                    113,
                    115,
                    117,
                    119,
                    121,
                    123,
                    125,
                    127,
                    129,
                    131,
                    133,
                    135,
                    137,
                    139,
                    141,
                    143,
                    145,
                    147,
                    149,
                    151,
                    153,
                    155,
                    157,
                    159,
                    161,
                    163,
                    165,
                    167,
                    169,
                    171,
                    173,
                    175,
                    177,
                    179
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "BuyAdvertId", "CreatedAt", "SellAdvertId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3003), 1 },
                    { 2, 4, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3006), 3 },
                    { 3, 6, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3008), 5 },
                    { 4, 8, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3010), 7 },
                    { 5, 10, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3013), 9 },
                    { 6, 12, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3016), 11 },
                    { 7, 14, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3017), 13 },
                    { 8, 16, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3019), 15 },
                    { 9, 18, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3022), 17 },
                    { 10, 20, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3025), 19 },
                    { 11, 22, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3027), 21 },
                    { 12, 24, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3029), 23 },
                    { 13, 26, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3030), 25 },
                    { 14, 28, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3032), 27 },
                    { 15, 30, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3033), 29 },
                    { 16, 32, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3035), 31 },
                    { 17, 34, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3038), 33 },
                    { 18, 36, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3041), 35 },
                    { 19, 38, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3042), 37 },
                    { 20, 40, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3044), 39 },
                    { 21, 42, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3074), 41 },
                    { 22, 44, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3076), 43 },
                    { 23, 46, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3078), 45 },
                    { 24, 48, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3079), 47 },
                    { 25, 50, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3081), 49 },
                    { 26, 52, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3083), 51 },
                    { 27, 54, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3084), 53 },
                    { 28, 56, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3086), 55 },
                    { 29, 58, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3088), 57 },
                    { 30, 60, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3089), 59 },
                    { 31, 62, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3091), 61 },
                    { 32, 64, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3093), 63 },
                    { 33, 66, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3096), 65 },
                    { 34, 68, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3099), 67 },
                    { 35, 70, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3100), 69 },
                    { 36, 72, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3102), 71 },
                    { 37, 74, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3104), 73 },
                    { 38, 76, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3105), 75 },
                    { 39, 78, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3107), 77 },
                    { 40, 80, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3109), 79 },
                    { 41, 82, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3110), 81 },
                    { 42, 84, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3112), 83 },
                    { 43, 86, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3114), 85 },
                    { 44, 88, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3115), 87 },
                    { 45, 90, new DateTime(2024, 1, 19, 0, 27, 31, 88, DateTimeKind.Local).AddTicks(3117), 89 }
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
                name: "GuestMessages");

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
