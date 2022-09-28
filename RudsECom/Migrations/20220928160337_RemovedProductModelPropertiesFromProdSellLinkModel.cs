using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RudsECom.Migrations
{
    public partial class RemovedProductModelPropertiesFromProdSellLinkModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdSellLinks_Products_ProductsProductId",
                table: "ProdSellLinks");

            migrationBuilder.DropIndex(
                name: "IX_ProdSellLinks_ProductsProductId",
                table: "ProdSellLinks");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "ProdSellLinks");

            migrationBuilder.DropColumn(
                name: "ProductsProductId",
                table: "ProdSellLinks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "ProdSellLinks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductsProductId",
                table: "ProdSellLinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProdSellLinks_ProductsProductId",
                table: "ProdSellLinks",
                column: "ProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdSellLinks_Products_ProductsProductId",
                table: "ProdSellLinks",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
