using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeShopAPI.Migrations
{
    public partial class changeorderlinestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Orders_OrderguidOrder",
                schema: "Sales",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_OrderguidOrder",
                schema: "Sales",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "OrderguidOrder",
                schema: "Sales",
                table: "OrderLines");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_guidOrder",
                schema: "Sales",
                table: "OrderLines",
                column: "guidOrder");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Orders_guidOrder",
                schema: "Sales",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_guidOrder",
                schema: "Sales",
                table: "OrderLines");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderguidOrder",
                schema: "Sales",
                table: "OrderLines",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderguidOrder",
                schema: "Sales",
                table: "OrderLines",
                column: "OrderguidOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Orders_OrderguidOrder",
                schema: "Sales",
                table: "OrderLines",
                column: "OrderguidOrder",
                principalSchema: "Sales",
                principalTable: "Orders",
                principalColumn: "guidOrder",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
