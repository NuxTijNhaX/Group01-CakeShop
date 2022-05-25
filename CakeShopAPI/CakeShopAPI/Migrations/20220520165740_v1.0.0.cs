using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeShopAPI.Migrations
{
    public partial class v100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                schema: "Production",
                table: "Products");

            migrationBuilder.DropTable(
                name: "InvoiceDetails",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "InvoiceHeaders",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "UnitMeasures",
                schema: "Production");

            migrationBuilder.AlterColumn<int>(
                name: "ProductCategoryId",
                schema: "Production",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                schema: "Person",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Sales",
                columns: table => new
                {
                    guidOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.guidOrder);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Person",
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrderguidOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Orders_OrderguidOrder",
                        column: x => x.OrderguidOrder,
                        principalSchema: "Sales",
                        principalTable: "Orders",
                        principalColumn: "guidOrder",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalSchema: "Sales",
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    OrderguidOrder = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderguidOrder",
                        column: x => x.OrderguidOrder,
                        principalSchema: "Sales",
                        principalTable: "Orders",
                        principalColumn: "guidOrder",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalSchema: "Production",
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderguidOrder",
                schema: "Sales",
                table: "Invoices",
                column: "OrderguidOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PaymentMethodId",
                schema: "Sales",
                table: "Invoices",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderguidOrder",
                schema: "Sales",
                table: "OrderLines",
                column: "OrderguidOrder");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductId",
                schema: "Sales",
                table: "OrderLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_SizeId",
                schema: "Sales",
                table: "OrderLines",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                schema: "Sales",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                schema: "Production",
                table: "Products",
                column: "ProductCategoryId",
                principalSchema: "Production",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                schema: "Production",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "OrderLines",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Sizes",
                schema: "Production");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "Person",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductCategoryId",
                schema: "Production",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "InvoiceHeaders",
                schema: "Sales",
                columns: table => new
                {
                    guidInvoice = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        principalSchema: "Sales",
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitMeasures",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitMeasures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceHeaderguidInvoice = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    UnitMeasureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_InvoiceHeaders_InvoiceHeaderguidInvoice",
                        column: x => x.InvoiceHeaderguidInvoice,
                        principalSchema: "Sales",
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
                schema: "Sales",
                table: "InvoiceDetails",
                column: "InvoiceHeaderguidInvoice");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ProductId",
                schema: "Sales",
                table: "InvoiceDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_UnitMeasureId",
                schema: "Sales",
                table: "InvoiceDetails",
                column: "UnitMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaders_CustomerId",
                schema: "Sales",
                table: "InvoiceHeaders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaders_PaymentMethodId",
                schema: "Sales",
                table: "InvoiceHeaders",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                schema: "Production",
                table: "Products",
                column: "ProductCategoryId",
                principalSchema: "Production",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
