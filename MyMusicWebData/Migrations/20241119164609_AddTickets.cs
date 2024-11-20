using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyMusicWebData.Migrations
{
    /// <inheritdoc />
    public partial class AddTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("368e332f-7d8e-4afe-befa-90221ccd8255"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c43fc4b7-c7dd-409f-ae53-c1b15245164e"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("362a68b5-c693-4eb0-8914-0b7983f09dcd"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("83d49bdd-9184-4cd1-9aed-cfe78d6c2ecf"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("e9ca0d62-6232-49b9-95e5-010ec7ff0e06"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("e9e812e3-b040-49c3-98a2-40872f3e7b48"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("23cccbd3-00c3-4dce-adb3-d98f958b926d"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("472f8f6f-7855-473f-a3ca-7cda962b9d62"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("7a01efed-3d5c-474c-b4d7-4e19dbd9f3f0"));

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "the ticket's Id"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "the ticket's Id"),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "the event that this ticket is for"),
                    BuyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "the person who bought the ticket")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_ApplicationUser_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d1f53143-9346-4176-98fc-29e94bece85d"), "guitars" },
                    { new Guid("e90edd84-e0cd-4704-8391-046028897e45"), "drums" }
                });

            migrationBuilder.InsertData(
                table: "Genra",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("37cb8771-b173-4f32-a3f1-e7b0b5ec80b3"), "rap" },
                    { new Guid("53b59f58-29d4-4e9f-9e5a-e804f114cc6f"), "metal" },
                    { new Guid("a2938f89-627a-4727-9601-aa89bb0f56ea"), "rock" },
                    { new Guid("dd5d7116-7e1c-4c4c-aaca-02ddaa04ff71"), "jazz" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Adress", "Name" },
                values: new object[,]
                {
                    { new Guid("776ab401-f1fd-4b85-88a5-347b841cdfaf"), "Парк, Борисова Градина, бул. „Евлоги и Христо Георгиеви“ 38, 1164 София", "Vasil Levski Stadium" },
                    { new Guid("9fc0c24a-3a9d-4bd4-9ccf-9cbe80bfb111"), "ж.к. Студентски град, ул. „Акад. Стефан Младенов“ 3, 1700 София", "Joy Station" },
                    { new Guid("dbd9b819-28a0-4121-88e8-44dd2930fab8"), " Ндк, бул. България, 1463 София", "NDK" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BuyerId",
                table: "Tickets",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                table: "Tickets",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d1f53143-9346-4176-98fc-29e94bece85d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e90edd84-e0cd-4704-8391-046028897e45"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("37cb8771-b173-4f32-a3f1-e7b0b5ec80b3"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("53b59f58-29d4-4e9f-9e5a-e804f114cc6f"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("a2938f89-627a-4727-9601-aa89bb0f56ea"));

            migrationBuilder.DeleteData(
                table: "Genra",
                keyColumn: "Id",
                keyValue: new Guid("dd5d7116-7e1c-4c4c-aaca-02ddaa04ff71"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("776ab401-f1fd-4b85-88a5-347b841cdfaf"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("9fc0c24a-3a9d-4bd4-9ccf-9cbe80bfb111"));

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: new Guid("dbd9b819-28a0-4121-88e8-44dd2930fab8"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("368e332f-7d8e-4afe-befa-90221ccd8255"), "guitars" },
                    { new Guid("c43fc4b7-c7dd-409f-ae53-c1b15245164e"), "drums" }
                });

            migrationBuilder.InsertData(
                table: "Genra",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("362a68b5-c693-4eb0-8914-0b7983f09dcd"), "rock" },
                    { new Guid("83d49bdd-9184-4cd1-9aed-cfe78d6c2ecf"), "metal" },
                    { new Guid("e9ca0d62-6232-49b9-95e5-010ec7ff0e06"), "rap" },
                    { new Guid("e9e812e3-b040-49c3-98a2-40872f3e7b48"), "jazz" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Adress", "Name" },
                values: new object[,]
                {
                    { new Guid("23cccbd3-00c3-4dce-adb3-d98f958b926d"), "ж.к. Студентски град, ул. „Акад. Стефан Младенов“ 3, 1700 София", "Joy Station" },
                    { new Guid("472f8f6f-7855-473f-a3ca-7cda962b9d62"), " Ндк, бул. България, 1463 София", "NDK" },
                    { new Guid("7a01efed-3d5c-474c-b4d7-4e19dbd9f3f0"), "Парк, Борисова Градина, бул. „Евлоги и Христо Георгиеви“ 38, 1164 София", "Vasil Levski Stadium" }
                });
        }
    }
}
