using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACars.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCityToCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CityId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CityId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CityId",
                table: "Cars",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Cities_CityId",
                table: "Cars",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Cities_CityId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CityId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Cars");
        }
    }
}
