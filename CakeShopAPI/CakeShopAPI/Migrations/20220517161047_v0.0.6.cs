using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeShopAPI.Migrations
{
    public partial class v006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.RenameTable(
                name: "PaymentMethods",
                newName: "PaymentMethods",
                newSchema: "Sales");

            migrationBuilder.RenameTable(
                name: "InvoiceHeaders",
                newName: "InvoiceHeaders",
                newSchema: "Sales");

            migrationBuilder.RenameTable(
                name: "InvoiceDetails",
                newName: "InvoiceDetails",
                newSchema: "Sales");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "PaymentMethods",
                schema: "Sales",
                newName: "PaymentMethods");

            migrationBuilder.RenameTable(
                name: "InvoiceHeaders",
                schema: "Sales",
                newName: "InvoiceHeaders");

            migrationBuilder.RenameTable(
                name: "InvoiceDetails",
                schema: "Sales",
                newName: "InvoiceDetails");
        }
    }
}
