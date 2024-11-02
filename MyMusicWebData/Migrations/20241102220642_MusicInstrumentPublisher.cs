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
                table: "MusicInstuments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MusicInstuments_SellerId",
                table: "MusicInstuments",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicInstuments_AspNetUsers_SellerId",
                table: "MusicInstuments",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicInstuments_AspNetUsers_SellerId",
                table: "MusicInstuments");

            migrationBuilder.DropIndex(
                name: "IX_MusicInstuments_SellerId",
                table: "MusicInstuments");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "MusicInstuments");
        }
    }
}
