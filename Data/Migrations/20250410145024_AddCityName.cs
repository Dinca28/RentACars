using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACars.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCityName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Cities",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cities",
                newName: "name");
        }
    }
}
