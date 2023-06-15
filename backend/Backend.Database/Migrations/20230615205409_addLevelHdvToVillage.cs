using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Business.Database.Migrations
{
    /// <inheritdoc />
    public partial class addLevelHdvToVillage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelHdvId",
                table: "villages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LevelHdvs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaxGolems = table.Column<int>(type: "integer", nullable: false),
                    MaxWalls = table.Column<int>(type: "integer", nullable: false),
                    MaxTowers = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelHdvs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_villages_LevelHdvId",
                table: "villages",
                column: "LevelHdvId");

            migrationBuilder.AddForeignKey(
                name: "FK_villages_LevelHdvs_LevelHdvId",
                table: "villages",
                column: "LevelHdvId",
                principalTable: "LevelHdvs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_villages_LevelHdvs_LevelHdvId",
                table: "villages");

            migrationBuilder.DropTable(
                name: "LevelHdvs");

            migrationBuilder.DropIndex(
                name: "IX_villages_LevelHdvId",
                table: "villages");

            migrationBuilder.DropColumn(
                name: "LevelHdvId",
                table: "villages");
        }
    }
}
