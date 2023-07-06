using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Database.Migrations
{
    /// <inheritdoc />
    public partial class LevelMines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LevelMines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IronRate = table.Column<int>(type: "integer", nullable: false),
                    DiamondRate = table.Column<int>(type: "integer", nullable: false),
                    EmeraldRate = table.Column<int>(type: "integer", nullable: false),
                    IronMaxRate = table.Column<int>(type: "integer", nullable: false),
                    DiamondMaxRate = table.Column<int>(type: "integer", nullable: false),
                    EmeraldMaxRate = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelMines", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LevelMines");
        }
    }
}
