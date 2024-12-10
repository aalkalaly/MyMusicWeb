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

           

            
            

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
           

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
