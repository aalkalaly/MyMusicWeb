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

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9d4a204f-a663-43f4-861c-6804739788ee"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c8a40d7b-0300-401e-8009-d21b07528386"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("02cad017-b4b1-4963-aeff-8e34577463c0"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("1d5c2295-e9fd-4b09-bff3-0fb9a19fff87"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("2639581e-29a3-460a-b40f-ea33683259f3"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("5e1a97df-971e-4d12-b138-9c3547e04f91"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("3642b515-8a36-44e3-9179-648e35626e8f"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("4e93995e-47b2-493c-8d70-7b64e0c09544"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("720f051c-a86d-4157-a477-54eba67d9181"));

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("44ad4e7a-abe5-484a-bcdd-43e406bd627b"), "drums" },
                    { new Guid("6c818b2d-50d9-41d7-98a3-c83fa6447c48"), "guitars" }
                });

            migrationBuilder.InsertData(
                table: "Genra",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3074654c-eef5-4148-b2ad-4007e1adc7f2"), "metal" },
                    { new Guid("35139ee0-faf9-4bef-8348-fa234767f700"), "jazz" },
                    { new Guid("64b6d60c-bb16-4e05-9366-aeee776d923d"), "rock" },
                    { new Guid("88c464ba-1f68-4eeb-b0e6-ca04e74e0873"), "rap" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Adress", "Name" },
                values: new object[,]
                {
                    { new Guid("0f3bf280-5c8f-4534-bf80-1ba60fd029e6"), "ж.к. Студентски град, ул. „Акад. Стефан Младенов“ 3, 1700 София", "Joy Station" },
                    { new Guid("449cda97-7d92-42e1-905e-c757dae122b4"), "Парк, Борисова Градина, бул. „Евлоги и Христо Георгиеви“ 38, 1164 София", "Vasil Levski Stadium" },
                    { new Guid("8f7c0d37-05b8-4bda-bb5a-5b643653ea4e"), " Ндк, бул. България, 1463 София", "NDK" }
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9d4a204f-a663-43f4-861c-6804739788ee"), "drums" },
                    { new Guid("c8a40d7b-0300-401e-8009-d21b07528386"), "guitars" }
                });

            migrationBuilder.InsertData(
                table: "Genra",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("02cad017-b4b1-4963-aeff-8e34577463c0"), "rap" },
                    { new Guid("1d5c2295-e9fd-4b09-bff3-0fb9a19fff87"), "jazz" },
                    { new Guid("2639581e-29a3-460a-b40f-ea33683259f3"), "rock" },
                    { new Guid("5e1a97df-971e-4d12-b138-9c3547e04f91"), "metal" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Adress", "Name" },
                values: new object[,]
                {
                    { new Guid("3642b515-8a36-44e3-9179-648e35626e8f"), " Ндк, бул. България, 1463 София", "NDK" },
                    { new Guid("4e93995e-47b2-493c-8d70-7b64e0c09544"), "Парк, Борисова Градина, бул. „Евлоги и Христо Георгиеви“ 38, 1164 София", "Vasil Levski Stadium" },
                    { new Guid("720f051c-a86d-4157-a477-54eba67d9181"), "ж.к. Студентски град, ул. „Акад. Стефан Младенов“ 3, 1700 София", "Joy Station" }
                });

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
