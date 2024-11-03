using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMusicWebData.Migrations
{
    /// <inheritdoc />
    public partial class MusicInstrumentsBuyersAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MusicInstrumentsBuyers",
                columns: table => new
                {
                    MusicInstrumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicInstrumentsBuyers", x => new { x.MusicInstrumentId, x.BuyerId });
                    table.ForeignKey(
                        name: "FK_MusicInstrumentsBuyers_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MusicInstrumentsBuyers_MusicInstuments_MusicInstrumentId",
                        column: x => x.MusicInstrumentId,
                        principalTable: "MusicInstuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicInstrumentsBuyers_BuyerId",
                table: "MusicInstrumentsBuyers",
                column: "BuyerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicInstrumentsBuyers");
        }
    }
}
