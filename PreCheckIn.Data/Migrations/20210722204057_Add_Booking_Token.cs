using Microsoft.EntityFrameworkCore.Migrations;

namespace PreCheckIn.Data.Migrations
{
    public partial class Add_Booking_Token : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SignInToken",
                table: "Guest");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Booking");

            migrationBuilder.AddColumn<string>(
                name: "SignInToken",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
