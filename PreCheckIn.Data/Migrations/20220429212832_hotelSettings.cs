using Microsoft.EntityFrameworkCore.Migrations;

namespace PreCheckIn.Data.Migrations
{
    public partial class hotelSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelAdmin_HotelSettings_HotelSettingsId",
                table: "HotelAdmin");

            migrationBuilder.DropIndex(
                name: "IX_HotelAdmin_HotelSettingsId",
                table: "HotelAdmin");

            migrationBuilder.DropColumn(
                name: "HotelSettingsId",
                table: "HotelAdmin");

            migrationBuilder.AddColumn<int>(
                name: "HotelAdminId",
                table: "HotelSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HotelSettings_HotelAdminId",
                table: "HotelSettings",
                column: "HotelAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelSettings_HotelAdmin_HotelAdminId",
                table: "HotelSettings",
                column: "HotelAdminId",
                principalTable: "HotelAdmin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelSettings_HotelAdmin_HotelAdminId",
                table: "HotelSettings");

            migrationBuilder.DropIndex(
                name: "IX_HotelSettings_HotelAdminId",
                table: "HotelSettings");

            migrationBuilder.DropColumn(
                name: "HotelAdminId",
                table: "HotelSettings");

            migrationBuilder.AddColumn<int>(
                name: "HotelSettingsId",
                table: "HotelAdmin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HotelAdmin_HotelSettingsId",
                table: "HotelAdmin",
                column: "HotelSettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelAdmin_HotelSettings_HotelSettingsId",
                table: "HotelAdmin",
                column: "HotelSettingsId",
                principalTable: "HotelSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
