using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWeb.Data.Migrations
{
    public partial class Typos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "MovieGenres",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MovieGenres",
                newName: "Naam");
        }
    }
}
