using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameChampVillage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WallLevel",
                table: "villages",
                newName: "Walls");

            migrationBuilder.RenameColumn(
                name: "GolemLevel",
                table: "villages",
                newName: "Golems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Walls",
                table: "villages",
                newName: "WallLevel");

            migrationBuilder.RenameColumn(
                name: "Golems",
                table: "villages",
                newName: "GolemLevel");
        }
    }
}
