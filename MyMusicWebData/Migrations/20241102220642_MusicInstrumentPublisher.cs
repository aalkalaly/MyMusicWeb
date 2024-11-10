using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMusicWebData.Migrations
{
    /// <inheritdoc />
    public partial class MusicInstrumentPublisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "MusicInstruments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MusicInstruments_SellerId",
                table: "MusicInstruments",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicInstruments_AspNetUsers_SellerId",
                table: "MusicInstruments",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicInstruments_AspNetUsers_SellerId",
                table: "MusicInstruments");

            migrationBuilder.DropIndex(
                name: "IX_MusicInstruments_SellerId",
                table: "MusicInstruments");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "MusicInstruments");
        }
    }
}
