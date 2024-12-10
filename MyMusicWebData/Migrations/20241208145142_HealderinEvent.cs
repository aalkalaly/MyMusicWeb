using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyMusicWebData.Migrations
{
    /// <inheritdoc />
    public partial class HealderinEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organisation_OrganisationId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ApplicationUsers_BuyerId",
                table: "Tickets");

           

            migrationBuilder.DropTable(
                name: "Organisations");

            migrationBuilder.DropIndex(
                name: "IX_Events_OrganisationId",
                table: "Events");

           

            migrationBuilder.DropColumn(
                name: "OrganisationId",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                comment: "the person who bought the ticket",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "the person who bought the ticket");

            migrationBuilder.AddColumn<string>(
                name: "HealderId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "The person who organizes the event");

           

            migrationBuilder.CreateIndex(
                name: "IX_Events_HealderId",
                table: "Events",
                column: "HealderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_HealderId",
                table: "Events",
                column: "HealderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_BuyerId",
                table: "Tickets",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_HealderId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_BuyerId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Events_HealderId",
                table: "Events");

            

            migrationBuilder.DropColumn(
                name: "HealderId",
                table: "Events");

            migrationBuilder.AlterColumn<Guid>(
                name: "BuyerId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                comment: "the person who bought the ticket",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "the person who bought the ticket");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganisationId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

           

            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganisationName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "name of the organisation"),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.Id);
                });

            

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganisationId",
                table: "Events",
                column: "OrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organisations_OrganisationId",
                table: "Events",
                column: "OrganisationId",
                principalTable: "Organisations",
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
    }
}
