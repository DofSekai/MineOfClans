using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Business.Database.Migrations
{
    /// <inheritdoc />
    public partial class addLevelMineToVillage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelMineId",
                table: "villages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "levelMines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IronRate = table.Column<int>(type: "integer", nullable: false),
                    DiamondRate = table.Column<int>(type: "integer", nullable: false),
                    EmeraldRate = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_levelMines", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_villages_LevelMineId",
                table: "villages",
                column: "LevelMineId");

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

            migrationBuilder.DropTable(
                name: "levelMines");

            migrationBuilder.DropIndex(
                name: "IX_villages_LevelMineId",
                table: "villages");

            migrationBuilder.DropColumn(
                name: "LevelMineId",
                table: "villages");
        }
    }
}
