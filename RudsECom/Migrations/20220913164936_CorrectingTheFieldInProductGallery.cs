using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RudsECom.Migrations
{
    public partial class CorrectingTheFieldInProductGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "ProductGallery");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "ProductGallery",
                type: "int",
                nullable: true);
        }
    }
}
