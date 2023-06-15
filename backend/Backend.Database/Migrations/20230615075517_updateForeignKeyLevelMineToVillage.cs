using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business.Database.Migrations
{
    /// <inheritdoc />
    public partial class updateForeignKeyLevelMineToVillage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_villages_levelMines_LevelMinId",
                table: "villages");

            migrationBuilder.RenameColumn(
                name: "LevelMinId",
                table: "villages",
                newName: "LevelMineId");

            migrationBuilder.RenameIndex(
                name: "IX_villages_LevelMinId",
                table: "villages",
                newName: "IX_villages_LevelMineId");

            migrationBuilder.AddForeignKey(
                name: "FK_villages_levelMines_LevelMineId",
                table: "villages",
                column: "LevelMineId",
                principalTable: "levelMines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_villages_levelMines_LevelMineId",
                table: "villages");

            migrationBuilder.RenameColumn(
                name: "LevelMineId",
                table: "villages",
                newName: "LevelMinId");

            migrationBuilder.RenameIndex(
                name: "IX_villages_LevelMineId",
                table: "villages",
                newName: "IX_villages_LevelMinId");

            migrationBuilder.AddForeignKey(
                name: "FK_villages_levelMines_LevelMinId",
                table: "villages",
                column: "LevelMinId",
                principalTable: "levelMines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
