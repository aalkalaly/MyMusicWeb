using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyMusicWebData.Migrations
{
    /// <inheritdoc />
    public partial class Organisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ApplicationUser_BuyerId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser");

           
            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newName: "ApplicationUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganisationId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUsers",
                table: "ApplicationUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Organisation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganisationName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "name of the organisation"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisation", x => x.Id);
                });

           
            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganisationId",
                table: "Events",
                column: "OrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organisation_OrganisationId",
                table: "Events",
                column: "OrganisationId",
                principalTable: "Organisation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ApplicationUsers_BuyerId",
                table: "Tickets",
                column: "BuyerId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organisation_OrganisationId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ApplicationUsers_BuyerId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Organisation");

            migrationBuilder.DropIndex(
                name: "IX_Events_OrganisationId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUsers",
                table: "ApplicationUsers");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44ad4e7a-abe5-484a-bcdd-43e406bd627b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6c818b2d-50d9-41d7-98a3-c83fa6447c48"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("3074654c-eef5-4148-b2ad-4007e1adc7f2"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("35139ee0-faf9-4bef-8348-fa234767f700"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("64b6d60c-bb16-4e05-9366-aeee776d923d"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("88c464ba-1f68-4eeb-b0e6-ca04e74e0873"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("0f3bf280-5c8f-4534-bf80-1ba60fd029e6"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("449cda97-7d92-42e1-905e-c757dae122b4"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("8f7c0d37-05b8-4bda-bb5a-5b643653ea4e"));

            migrationBuilder.DropColumn(
                name: "OrganisationId",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "ApplicationUsers",
                newName: "ApplicationUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser",
                column: "Id");

           

            

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ApplicationUser_BuyerId",
                table: "Tickets",
                column: "BuyerId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
