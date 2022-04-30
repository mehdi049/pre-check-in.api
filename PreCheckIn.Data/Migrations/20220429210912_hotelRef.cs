using Microsoft.EntityFrameworkCore.Migrations;

namespace PreCheckIn.Data.Migrations
{
    public partial class hotelRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Reference",
                table: "HotelSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reference",
                table: "HotelSettings");
        }
    }
}
