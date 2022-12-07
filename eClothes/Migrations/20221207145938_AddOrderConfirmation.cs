using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eClothes.Migrations
{
    public partial class AddOrderConfirmation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderConfirmed",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderConfirmed",
                table: "Orders");
        }
    }
}
