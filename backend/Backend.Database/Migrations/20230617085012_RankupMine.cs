using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Business.Database.Migrations
{
    /// <inheritdoc />
    public partial class RankupMine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_villages_LevelHdvs_LevelHdvId",
                table: "villages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LevelHdvs",
                table: "LevelHdvs");

            migrationBuilder.RenameTable(
                name: "LevelHdvs",
                newName: "levelHdvs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_levelHdvs",
                table: "levelHdvs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "rankupMines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Irons = table.Column<int>(type: "integer", nullable: false),
                    Diamonds = table.Column<int>(type: "integer", nullable: false),
                    Emeralds = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rankupMines", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_villages_levelHdvs_LevelHdvId",
                table: "villages",
                column: "LevelHdvId",
                principalTable: "levelHdvs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_villages_levelHdvs_LevelHdvId",
                table: "villages");

            migrationBuilder.DropTable(
                name: "rankupMines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_levelHdvs",
                table: "levelHdvs");

            migrationBuilder.RenameTable(
                name: "levelHdvs",
                newName: "LevelHdvs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LevelHdvs",
                table: "LevelHdvs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_villages_LevelHdvs_LevelHdvId",
                table: "villages",
                column: "LevelHdvId",
                principalTable: "LevelHdvs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
