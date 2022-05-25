using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeShopAPI.Migrations
{
    public partial class deletecustomercontacttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                schema: "Sales",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "ProductReviews",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Person");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                schema: "Sales",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                schema: "Sales",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Person",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                schema: "Person",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Person",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                schema: "Person",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Person",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "Person",
                table: "Users",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "guidOrder",
                schema: "Sales",
                table: "OrderLines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                schema: "Sales",
                table: "Orders",
                column: "UserId",
                principalSchema: "Person",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                schema: "Sales",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Person",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                schema: "Person",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Person",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                schema: "Person",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Person",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "Person",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "guidOrder",
                schema: "Sales",
                table: "OrderLines");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Sales",
                table: "Orders",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                schema: "Sales",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Person",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Person",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "Person",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_Customers_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "Person",
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Person",
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_CustomerId",
                schema: "Production",
                table: "ProductReviews",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                schema: "Production",
                table: "ProductReviews",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                schema: "Sales",
                table: "Orders",
                column: "CustomerId",
                principalSchema: "Person",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
