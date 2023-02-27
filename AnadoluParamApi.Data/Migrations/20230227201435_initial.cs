using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnadoluParamApi.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastActivity = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatorUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdaterUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeleterUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatorUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdaterUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeleterUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatorUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdaterUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeleterUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatorUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdaterUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeleterUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UnitsInStock = table.Column<short>(type: "smallint", nullable: false),
                    UnitType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatorUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdaterUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeleterUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    UnitType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatorUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdaterUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedComputerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeletedIP = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DeleterUserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountId",
                table: "Orders",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
