using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eClothes.Migrations
{
    public partial class plm3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Discounts_Clothes_ClothesId",
                table: "Clothes_Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_Discounts_ClothesId",
                table: "Clothes_Discounts");

            migrationBuilder.DropColumn(
                name: "ClothesId",
                table: "Clothes_Discounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClothesId",
                table: "Clothes_Discounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_Discounts_ClothesId",
                table: "Clothes_Discounts",
                column: "ClothesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Discounts_Clothes_ClothesId",
                table: "Clothes_Discounts",
                column: "ClothesId",
                principalTable: "Clothes",
                principalColumn: "Id");
        }
    }
}
