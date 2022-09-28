using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RudsECom.Migrations
{
    public partial class ProdSellLinkModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sellers",
                newName: "SellerId");

            migrationBuilder.CreateTable(
                name: "ProdSellLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerId = table.Column<int>(type: "int", nullable: true),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdSellLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdSellLinks_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdSellLinks_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "SellerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdSellLinks_ProductsProductId",
                table: "ProdSellLinks",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdSellLinks_SellerId",
                table: "ProdSellLinks",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdSellLinks");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "Sellers",
                newName: "Id");
        }
    }
}
