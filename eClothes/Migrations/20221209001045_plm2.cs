using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eClothes.Migrations
{
    public partial class plm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Discounts_Clothes_DiscountId",
                table: "Clothes_Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Discounts_Discounts_ClothId",
                table: "Clothes_Discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clothes_Discounts",
                table: "Clothes_Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_Discounts_ClothId",
                table: "Clothes_Discounts");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Clothes_Discounts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ClothesId",
                table: "Clothes_Discounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountsId",
                table: "Clothes_Discounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                table: "Clothes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clothes_Discounts",
                table: "Clothes_Discounts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_Discounts_ClothesId",
                table: "Clothes_Discounts",
                column: "ClothesId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_Discounts_DiscountsId",
                table: "Clothes_Discounts",
                column: "DiscountsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Discounts_Clothes_ClothesId",
                table: "Clothes_Discounts",
                column: "ClothesId",
                principalTable: "Clothes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Discounts_Discounts_DiscountsId",
                table: "Clothes_Discounts",
                column: "DiscountsId",
                principalTable: "Discounts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Discounts_Clothes_ClothesId",
                table: "Clothes_Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Discounts_Discounts_DiscountsId",
                table: "Clothes_Discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clothes_Discounts",
                table: "Clothes_Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_Discounts_ClothesId",
                table: "Clothes_Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_Discounts_DiscountsId",
                table: "Clothes_Discounts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Clothes_Discounts");

            migrationBuilder.DropColumn(
                name: "ClothesId",
                table: "Clothes_Discounts");

            migrationBuilder.DropColumn(
                name: "DiscountsId",
                table: "Clothes_Discounts");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Clothes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clothes_Discounts",
                table: "Clothes_Discounts",
                columns: new[] { "DiscountId", "ClothId" });

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_Discounts_ClothId",
                table: "Clothes_Discounts",
                column: "ClothId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Discounts_Clothes_DiscountId",
                table: "Clothes_Discounts",
                column: "DiscountId",
                principalTable: "Clothes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Discounts_Discounts_ClothId",
                table: "Clothes_Discounts",
                column: "ClothId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
