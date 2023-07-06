using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddLevelHdvToVillage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelHdvId",
                table: "Villages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Villages_LevelHdvId",
                table: "Villages",
                column: "LevelHdvId");

            migrationBuilder.AddForeignKey(
                name: "FK_Villages_LevelHdvs_LevelHdvId",
                table: "Villages",
                column: "LevelHdvId",
                principalTable: "LevelHdvs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Villages_LevelHdvs_LevelHdvId",
                table: "Villages");

            migrationBuilder.DropIndex(
                name: "IX_Villages_LevelHdvId",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "LevelHdvId",
                table: "Villages");
        }
    }
}
