using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Business.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddMaxItemsForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelHDV",
                table: "villages");

            migrationBuilder.RenameColumn(
                name: "Tours",
                table: "villages",
                newName: "Towers");

            migrationBuilder.AddColumn<int>(
                name: "LevelHDV_Id",
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
                    MaxWalls = table.Column<int>(type: "integer", nullable: false),
                    MaxTowers = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maxItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_villages_LevelHDV_Id",
                table: "villages",
                column: "LevelHDV_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_villages_maxItems_LevelHDV_Id",
                table: "villages",
                column: "LevelHDV_Id",
                principalTable: "maxItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_villages_maxItems_LevelHDV_Id",
                table: "villages");

            migrationBuilder.DropTable(
                name: "maxItems");

            migrationBuilder.DropIndex(
                name: "IX_villages_LevelHDV_Id",
                table: "villages");

            migrationBuilder.DropColumn(
                name: "LevelHDV_Id",
                table: "villages");

            migrationBuilder.RenameColumn(
                name: "Towers",
                table: "villages",
                newName: "Tours");

            migrationBuilder.AddColumn<int>(
                name: "LevelHDV",
                table: "villages",
                type: "integer",
                nullable: false,
                defaultValue: 1);
        }
    }
}
