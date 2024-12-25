using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class NewBussines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_branshes_BranshId",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Sells_branshes_BranshId",
                table: "Sells");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "TransactionItems");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "branshes");

            migrationBuilder.DropIndex(
                name: "IX_Sells_BranshId",
                table: "Sells");

            migrationBuilder.DropIndex(
                name: "IX_employees_BranshId",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "BranshId",
                table: "Sells");

            migrationBuilder.DropColumn(
                name: "BranshId",
                table: "employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranshId",
                table: "Sells",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BranshId",
                table: "employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "branshes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branshes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_branshes_admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranshId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_branshes_BranshId",
                        column: x => x.BranshId,
                        principalTable: "branshes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    BranshId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactions_branshes_BranshId",
                        column: x => x.BranshId,
                        principalTable: "branshes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactions_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransactionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionItems_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionItems_transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sells_BranshId",
                table: "Sells",
                column: "BranshId");

            migrationBuilder.CreateIndex(
                name: "IX_employees_BranshId",
                table: "employees",
                column: "BranshId");

            migrationBuilder.CreateIndex(
                name: "IX_branshes_AdminId",
                table: "branshes",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_BranshId",
                table: "Stock",
                column: "BranshId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductId",
                table: "Stock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItems_ProductId",
                table: "TransactionItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItems_TransactionId",
                table: "TransactionItems",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_AdminId",
                table: "transactions",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_BranshId",
                table: "transactions",
                column: "BranshId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_InventoryId",
                table: "transactions",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_branshes_BranshId",
                table: "employees",
                column: "BranshId",
                principalTable: "branshes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sells_branshes_BranshId",
                table: "Sells",
                column: "BranshId",
                principalTable: "branshes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
