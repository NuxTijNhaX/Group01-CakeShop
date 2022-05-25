using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeShopAPI.Migrations
{
    public partial class v001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductPhotoId",
                schema: "Production",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AvgRating",
                schema: "Production",
                table: "ProductDescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductPhotos",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThumbNail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmallPhotoArray = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPhotos", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductPhotoId",
                schema: "Production",
                table: "Products",
                column: "ProductPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductPhotos_ProductPhotoId",
                schema: "Production",
                table: "Products",
                column: "ProductPhotoId",
                principalSchema: "Production",
                principalTable: "ProductPhotos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductPhotos_ProductPhotoId",
                schema: "Production",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductPhotos",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "UnitMeasures",
                schema: "Production");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductPhotoId",
                schema: "Production",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductPhotoId",
                schema: "Production",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AvgRating",
                schema: "Production",
                table: "ProductDescriptions");
        }
    }
}
