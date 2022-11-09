using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eClothes.Migrations
{
    public partial class addProducers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Discounts",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ProducerId",
                table: "Clothes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileBio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_ProducerId",
                table: "Clothes",
                column: "ProducerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Producers_ProducerId",
                table: "Clothes",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Producers_ProducerId",
                table: "Clothes");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_ProducerId",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "ProducerId",
                table: "Clothes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Discounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);
        }
    }
}
