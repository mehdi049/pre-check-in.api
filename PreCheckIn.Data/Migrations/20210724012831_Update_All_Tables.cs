using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PreCheckIn.Data.Migrations
{
    public partial class Update_All_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Guest_GuestId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Guest_AspNetUsers_IdentityId",
                table: "Guest");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Guest_IdentityId",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Booking_GuestId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "Postcode",
                table: "Guest",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Guest",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "Guest",
                newName: "Birthday");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Guest",
                newName: "StreetNumber");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Booking",
                newName: "LastStatusUpdate");

            migrationBuilder.RenameColumn(
                name: "Reference",
                table: "Booking",
                newName: "BookingReference");

            migrationBuilder.AddColumn<bool>(
                name: "Business",
                table: "Guest",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuestComment",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuestNumber",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GuestType",
                table: "Guest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GuestTypeText",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Iso3",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsoCode",
                table: "Guest",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Passport",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Guest",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salutation",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceAddressId",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookingAdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingAddNumber = table.Column<int>(type: "int", nullable: false),
                    BookingAddText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingAddAmount = table.Column<int>(type: "int", nullable: false),
                    BookingAddSingle = table.Column<float>(type: "real", nullable: false),
                    BookingAddTotal = table.Column<float>(type: "real", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingAdd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingAdd_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salutation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iso3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsoCode = table.Column<int>(type: "int", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceComment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomType = table.Column<int>(type: "int", nullable: false),
                    RoomTypeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Package = table.Column<int>(type: "int", nullable: false),
                    PackageText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    RoomComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RateNumber = table.Column<int>(type: "int", nullable: false),
                    RateText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RateAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RateSingle = table.Column<float>(type: "real", nullable: false),
                    RateTotal = table.Column<float>(type: "real", nullable: false),
                    RateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rate_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomAdds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomAddNumber = table.Column<int>(type: "int", nullable: false),
                    RoomAddText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomAddAmount = table.Column<int>(type: "int", nullable: false),
                    RoomAddSingle = table.Column<float>(type: "real", nullable: false),
                    RoomAddTotal = table.Column<float>(type: "real", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAdds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomAdds_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guest_RoomId",
                table: "Guest",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_InvoiceAddressId",
                table: "Booking",
                column: "InvoiceAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_StatusId",
                table: "Booking",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingAdd_BookingId",
                table: "BookingAdd",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_RoomId",
                table: "Rate",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_BookingId",
                table: "Room",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAdds_RoomId",
                table: "RoomAdds",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_BookingStatus_StatusId",
                table: "Booking",
                column: "StatusId",
                principalTable: "BookingStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_InvoiceAddress_InvoiceAddressId",
                table: "Booking",
                column: "InvoiceAddressId",
                principalTable: "InvoiceAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Room_RoomId",
                table: "Guest",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_BookingStatus_StatusId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_InvoiceAddress_InvoiceAddressId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Room_RoomId",
                table: "Guest");

            migrationBuilder.DropTable(
                name: "BookingAdd");

            migrationBuilder.DropTable(
                name: "BookingStatus");

            migrationBuilder.DropTable(
                name: "InvoiceAddress");

            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "RoomAdds");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Guest_RoomId",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Booking_InvoiceAddressId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_StatusId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Business",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "GuestComment",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "GuestNumber",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "GuestType",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "GuestTypeText",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Iso3",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "IsoCode",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Passport",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Salutation",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "InvoiceAddressId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "Guest",
                newName: "Postcode");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Guest",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "StreetNumber",
                table: "Guest",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Guest",
                newName: "Birthdate");

            migrationBuilder.RenameColumn(
                name: "LastStatusUpdate",
                table: "Booking",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "BookingReference",
                table: "Booking",
                newName: "Reference");

            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "Guest",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guest_IdentityId",
                table: "Guest",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_GuestId",
                table: "Booking",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Guest_GuestId",
                table: "Booking",
                column: "GuestId",
                principalTable: "Guest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_AspNetUsers_IdentityId",
                table: "Guest",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
