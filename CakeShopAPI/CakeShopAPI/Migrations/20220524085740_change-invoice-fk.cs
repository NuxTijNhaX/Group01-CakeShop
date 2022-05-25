using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeShopAPI.Migrations
{
    public partial class changeinvoicefk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Orders_OrderguidOrder",
                schema: "Sales",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Orders_guidOrder",
                schema: "Sales",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "Sales",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "guidOrder",
                schema: "Sales",
                table: "OrderLines",
                newName: "OrderGuid");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_guidOrder",
                schema: "Sales",
                table: "OrderLines",
                newName: "IX_OrderLines_OrderGuid");

            migrationBuilder.RenameColumn(
                name: "OrderguidOrder",
                schema: "Sales",
                table: "Invoices",
                newName: "OrderGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_OrderguidOrder",
                schema: "Sales",
                table: "Invoices",
                newName: "IX_Invoices_OrderGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Orders_OrderGuid",
                schema: "Sales",
                table: "Invoices",
                column: "OrderGuid",
                principalSchema: "Sales",
                principalTable: "Orders",
                principalColumn: "guidOrder",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Orders_OrderGuid",
                schema: "Sales",
                table: "OrderLines",
                column: "OrderGuid",
                principalSchema: "Sales",
                principalTable: "Orders",
                principalColumn: "guidOrder",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Orders_OrderGuid",
                schema: "Sales",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Orders_OrderGuid",
                schema: "Sales",
                table: "OrderLines");

            migrationBuilder.RenameColumn(
                name: "OrderGuid",
                schema: "Sales",
                table: "OrderLines",
                newName: "guidOrder");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_OrderGuid",
                schema: "Sales",
                table: "OrderLines",
                newName: "IX_OrderLines_guidOrder");

            migrationBuilder.RenameColumn(
                name: "OrderGuid",
                schema: "Sales",
                table: "Invoices",
                newName: "OrderguidOrder");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_OrderGuid",
                schema: "Sales",
                table: "Invoices",
                newName: "IX_Invoices_OrderguidOrder");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                schema: "Sales",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Orders_OrderguidOrder",
                schema: "Sales",
                table: "Invoices",
                column: "OrderguidOrder",
                principalSchema: "Sales",
                principalTable: "Orders",
                principalColumn: "guidOrder",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Orders_guidOrder",
                schema: "Sales",
                table: "OrderLines",
                column: "guidOrder",
                principalSchema: "Sales",
                principalTable: "Orders",
                principalColumn: "guidOrder",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
