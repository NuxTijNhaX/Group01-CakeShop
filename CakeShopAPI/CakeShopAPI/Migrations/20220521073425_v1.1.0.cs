using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeShopAPI.Migrations
{
    public partial class v110 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCost",
                schema: "Sales",
                table: "OrderLines");

            migrationBuilder.AddColumn<double>(
                name: "TotalCost",
                schema: "Sales",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCost",
                schema: "Sales",
                table: "Orders");

            migrationBuilder.AddColumn<double>(
                name: "TotalCost",
                schema: "Sales",
                table: "OrderLines",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
