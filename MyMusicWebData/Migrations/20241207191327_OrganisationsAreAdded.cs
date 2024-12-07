using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyMusicWebData.Migrations
{
    /// <inheritdoc />
    public partial class OrganisationsAreAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.RenameTable(
                name: "Organisation",
                newName: "Organisations");

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.RenameTable(
                name: "Organisations",
                newName: "Organisation");

            
        }
    }
}
