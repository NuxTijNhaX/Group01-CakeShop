using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeShopAPI.Migrations
{
    public partial class refactorordertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_PaymentMethods_PaymentMethodId",
                schema: "Sales",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_PaymentMethodId",
                schema: "Sales",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                schema: "Sales",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodId",
                schema: "Sales",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                schema: "Sales",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentMethodId",
                schema: "Sales",
                table: "Orders",
                column: "PaymentMethodId",
                principalSchema: "Sales",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentMethodId",
                schema: "Sales",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentMethodId",
                schema: "Sales",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                schema: "Sales",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodId",
                schema: "Sales",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PaymentMethodId",
                schema: "Sales",
                table: "Invoices",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_PaymentMethods_PaymentMethodId",
                schema: "Sales",
                table: "Invoices",
                column: "PaymentMethodId",
                principalSchema: "Sales",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
