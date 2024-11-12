using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyMusicWebData.Migrations
{
    /// <inheritdoc />
    public partial class SeedLocationsAndGenra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Location",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "The location's adress",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "The location's name");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Location",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "The location's name");

           

            
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
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

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Location");

          

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Genras_GenraId",
                table: "Events",
                column: "GenraId",
                principalTable: "Genras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
