using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddMaxRateToMine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiamondMaxRate",
                table: "levelMines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmeraldMaxRate",
                table: "levelMines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IronMaxRate",
                table: "levelMines",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiamondMaxRate",
                table: "levelMines");

            migrationBuilder.DropColumn(
                name: "EmeraldMaxRate",
                table: "levelMines");

            migrationBuilder.DropColumn(
                name: "IronMaxRate",
                table: "levelMines");
        }
    }
}
