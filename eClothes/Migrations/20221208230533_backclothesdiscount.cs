using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eClothes.Migrations
{
    public partial class backclothesdiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Clothes_Discounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Clothes_Discounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
