using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeShopAPI.Migrations
{
    public partial class updateusertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                schema: "Person",
                table: "Users",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_PhoneNumber",
                schema: "Person",
                table: "Users");
        }
    }
}
