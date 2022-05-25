using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeShopAPI.Migrations
{
    public partial class v004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfPurchases",
                schema: "Production",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceHeaders",
                columns: table => new
                {
                    guidInvoice = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceHeaders", x => x.guidInvoice);
                    table.ForeignKey(
                        name: "FK_InvoiceHeaders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Person",
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceHeaders_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guidInvoice = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitMeasureId = table.Column<int>(type: "int", nullable: true),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    InvoiceHeaderguidInvoice = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_InvoiceHeaders_InvoiceHeaderguidInvoice",
                        column: x => x.InvoiceHeaderguidInvoice,
                        principalTable: "InvoiceHeaders",
                        principalColumn: "guidInvoice",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_UnitMeasures_UnitMeasureId",
                        column: x => x.UnitMeasureId,
                        principalSchema: "Production",
                        principalTable: "UnitMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceHeaderguidInvoice",
                table: "InvoiceDetails",
                column: "InvoiceHeaderguidInvoice");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ProductId",
                table: "InvoiceDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_UnitMeasureId",
                table: "InvoiceDetails",
                column: "UnitMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaders_CustomerId",
                table: "InvoiceHeaders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaders_PaymentMethodId",
                table: "InvoiceHeaders",
                column: "PaymentMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "InvoiceHeaders");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPurchases",
                schema: "Production",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
