using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesDatabase.Data.Migrations
{
    public partial class GameAnnouncedChangedToReleased : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Announced",
                table: "Games",
                newName: "Released");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Released",
                table: "Games",
                newName: "Announced");
        }
    }
}
