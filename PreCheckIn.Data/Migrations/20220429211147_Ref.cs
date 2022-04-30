using Microsoft.EntityFrameworkCore.Migrations;

namespace PreCheckIn.Data.Migrations
{
    public partial class Ref : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reference",
                table: "HotelSettings",
                newName: "Ref");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ref",
                table: "HotelSettings",
                newName: "Reference");
        }
    }
}
