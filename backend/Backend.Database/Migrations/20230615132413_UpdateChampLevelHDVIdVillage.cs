using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChampLevelHDVIdVillage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_villages_maxItems_LevelHDV_Id",
                table: "villages");

            migrationBuilder.RenameColumn(
                name: "LevelHDV_Id",
                table: "villages",
                newName: "LevelHDVId");

            migrationBuilder.RenameIndex(
                name: "IX_villages_LevelHDV_Id",
                table: "villages",
                newName: "IX_villages_LevelHDVId");

            migrationBuilder.AddForeignKey(
                name: "FK_villages_maxItems_LevelHDVId",
                table: "villages",
                column: "LevelHDVId",
                principalTable: "maxItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_villages_maxItems_LevelHDVId",
                table: "villages");

            migrationBuilder.RenameColumn(
                name: "LevelHDVId",
                table: "villages",
                newName: "LevelHDV_Id");

            migrationBuilder.RenameIndex(
                name: "IX_villages_LevelHDVId",
                table: "villages",
                newName: "IX_villages_LevelHDV_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_villages_maxItems_LevelHDV_Id",
                table: "villages",
                column: "LevelHDV_Id",
                principalTable: "maxItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
