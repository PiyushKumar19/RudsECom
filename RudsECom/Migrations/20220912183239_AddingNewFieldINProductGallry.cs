using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RudsECom.Migrations
{
    public partial class AddingNewFieldINProductGallry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGallery_Products_ProductsModelProductId",
                table: "ProductGallery");

            migrationBuilder.DropIndex(
                name: "IX_ProductGallery_ProductsModelProductId",
                table: "ProductGallery");

            migrationBuilder.DropColumn(
                name: "ProductsModelProductId",
                table: "ProductGallery");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductGallery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductGallery_ProductId",
                table: "ProductGallery",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGallery_Products_ProductId",
                table: "ProductGallery",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGallery_Products_ProductId",
                table: "ProductGallery");

            migrationBuilder.DropIndex(
                name: "IX_ProductGallery_ProductId",
                table: "ProductGallery");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductGallery");

            migrationBuilder.AddColumn<int>(
                name: "ProductsModelProductId",
                table: "ProductGallery",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductGallery_ProductsModelProductId",
                table: "ProductGallery",
                column: "ProductsModelProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGallery_Products_ProductsModelProductId",
                table: "ProductGallery",
                column: "ProductsModelProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }
    }
}
