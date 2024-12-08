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

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("38e55ec0-f1b8-4b75-9094-79cf3c00126c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("90d8ae6e-c4b4-4998-839a-1e992eb54119"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("1975029b-e2d9-4a4f-88fb-056ce16f8dee"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("ab1ac228-015b-4a3e-8498-1b8a3606ad54"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("f34256eb-2452-497d-84d7-7c715967a01a"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("fe5d16a2-7678-4baa-98ac-5e31f8b66651"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("86cb8016-f186-4274-a9e1-62e14b511cd0"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("a3e0a34e-a29d-43d3-bbcb-61f736767507"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("f6861e85-81b2-405f-93d2-84a3d1f07134"));

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f9239a2-5aa3-47f6-a8f4-c9415f2ee357"), "guitars" },
                    { new Guid("8320f31d-655f-4117-b059-111fb41f032a"), "drums" }
                });

            migrationBuilder.InsertData(
                table: "Genra",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5b9625ad-c210-4533-bebc-caaa41bfc96c"), "rock" },
                    { new Guid("84c495f7-f259-4ee3-8c5b-52aca5392355"), "jazz" },
                    { new Guid("c88e80fa-aa68-4fa6-9392-0bcc0fb07183"), "metal" },
                    { new Guid("d74d2a18-1f6e-4d17-85d2-313454505f53"), "rap" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Adress", "Name" },
                values: new object[,]
                {
                    { new Guid("00a5c8e5-5ee6-45fa-8de0-f98e5dbba22a"), "Парк, Борисова Градина, бул. „Евлоги и Христо Георгиеви“ 38, 1164 София", "Vasil Levski Stadium" },
                    { new Guid("cbb96c84-eb5e-4c14-b8ad-6c90225b79e1"), "ж.к. Студентски град, ул. „Акад. Стефан Младенов“ 3, 1700 София", "Joy Station" },
                    { new Guid("d954385d-87f8-4999-9130-4b552a19fe8a"), " Ндк, бул. България, 1463 София", "NDK" }
                });

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

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0f9239a2-5aa3-47f6-a8f4-c9415f2ee357"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8320f31d-655f-4117-b059-111fb41f032a"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("5b9625ad-c210-4533-bebc-caaa41bfc96c"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("84c495f7-f259-4ee3-8c5b-52aca5392355"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("c88e80fa-aa68-4fa6-9392-0bcc0fb07183"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("d74d2a18-1f6e-4d17-85d2-313454505f53"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("00a5c8e5-5ee6-45fa-8de0-f98e5dbba22a"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("cbb96c84-eb5e-4c14-b8ad-6c90225b79e1"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("d954385d-87f8-4999-9130-4b552a19fe8a"));

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("38e55ec0-f1b8-4b75-9094-79cf3c00126c"), "guitars" },
                    { new Guid("90d8ae6e-c4b4-4998-839a-1e992eb54119"), "drums" }
                });

            migrationBuilder.InsertData(
                table: "Genra",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1975029b-e2d9-4a4f-88fb-056ce16f8dee"), "rock" },
                    { new Guid("ab1ac228-015b-4a3e-8498-1b8a3606ad54"), "metal" },
                    { new Guid("f34256eb-2452-497d-84d7-7c715967a01a"), "jazz" },
                    { new Guid("fe5d16a2-7678-4baa-98ac-5e31f8b66651"), "rap" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Adress", "Name" },
                values: new object[,]
                {
                    { new Guid("86cb8016-f186-4274-a9e1-62e14b511cd0"), " Ндк, бул. България, 1463 София", "NDK" },
                    { new Guid("a3e0a34e-a29d-43d3-bbcb-61f736767507"), "ж.к. Студентски град, ул. „Акад. Стефан Младенов“ 3, 1700 София", "Joy Station" },
                    { new Guid("f6861e85-81b2-405f-93d2-84a3d1f07134"), "Парк, Борисова Градина, бул. „Евлоги и Христо Георгиеви“ 38, 1164 София", "Vasil Levski Stadium" }
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
