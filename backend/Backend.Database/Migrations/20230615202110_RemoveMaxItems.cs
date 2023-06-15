using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Business.Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMaxItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_villages_maxItems_LevelHDVId",
                table: "villages");

            migrationBuilder.DropTable(
                name: "maxItems");

            migrationBuilder.DropIndex(
                name: "IX_villages_LevelHDVId",
                table: "villages");

            migrationBuilder.DropColumn(
                name: "LevelHDVId",
                table: "villages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelHDVId",
                table: "villages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "maxItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaxGolems = table.Column<int>(type: "integer", nullable: false),
                    MaxTowers = table.Column<int>(type: "integer", nullable: false),
                    MaxWalls = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maxItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_villages_LevelHDVId",
                table: "villages",
                column: "LevelHDVId");

            migrationBuilder.AddForeignKey(
                name: "FK_villages_maxItems_LevelHDVId",
                table: "villages",
                column: "LevelHDVId",
                principalTable: "maxItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
