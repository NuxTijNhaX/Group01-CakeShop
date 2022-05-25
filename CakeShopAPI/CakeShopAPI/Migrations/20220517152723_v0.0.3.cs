using Microsoft.EntityFrameworkCore.Migrations;

namespace CakeShopAPI.Migrations
{
    public partial class v003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductDescriptions_ProductDescriptionId",
                schema: "Production",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductPhotos_ProductPhotoId",
                schema: "Production",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductDescriptions",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductPhotos",
                schema: "Production");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductDescriptionId",
                schema: "Production",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductPhotoId",
                schema: "Production",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductDescriptionId",
                schema: "Production",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductPhotoId",
                schema: "Production",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "AvgRating",
                schema: "Production",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Production",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPurchases",
                schema: "Production",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Photos",
                schema: "Production",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgRating",
                schema: "Production",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Production",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NumberOfPurchases",
                schema: "Production",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Photos",
                schema: "Production",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductDescriptionId",
                schema: "Production",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductPhotoId",
                schema: "Production",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductDescriptions",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvgRating = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPurchases = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductPhotos",
                schema: "Production",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmallPhotoArray = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbNail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPhotos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductDescriptionId",
                schema: "Production",
                table: "Products",
                column: "ProductDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductPhotoId",
                schema: "Production",
                table: "Products",
                column: "ProductPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductDescriptions_ProductDescriptionId",
                schema: "Production",
                table: "Products",
                column: "ProductDescriptionId",
                principalSchema: "Production",
                principalTable: "ProductDescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
