using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddLevelMineToVillage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelMineId",
                table: "Villages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Villages_LevelMineId",
                table: "Villages",
                column: "LevelMineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Villages_LevelMines_LevelMineId",
                table: "Villages",
                column: "LevelMineId",
                principalTable: "LevelMines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Villages_LevelMines_LevelMineId",
                table: "Villages");

            migrationBuilder.DropIndex(
                name: "IX_Villages_LevelMineId",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "LevelMineId",
                table: "Villages");
        }
    }
}
