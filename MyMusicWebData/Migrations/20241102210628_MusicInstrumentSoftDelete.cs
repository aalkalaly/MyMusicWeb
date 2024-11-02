using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMusicWebData.Migrations
{
    /// <inheritdoc />
    public partial class MusicInstrumentSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MusicInstuments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the Instrument Deleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MusicInstuments");
        }
    }
}
