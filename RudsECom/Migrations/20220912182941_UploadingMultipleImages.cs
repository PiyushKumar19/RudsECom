using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RudsECom.Migrations
{
    public partial class UploadingMultipleImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductsModelProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductGallery_Products_ProductsModelProductId",
                        column: x => x.ProductsModelProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductGallery_ProductsModelProductId",
                table: "ProductGallery",
                column: "ProductsModelProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductGallery");
        }
    }
}
