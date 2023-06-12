using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Business.Database.Migrations
{
    /// <inheritdoc />
    public partial class Village : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "villages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Irons = table.Column<int>(type: "integer", nullable: false, defaultValue: 30),
                    Diamonds = table.Column<int>(type: "integer", nullable: false, defaultValue: 20),
                    Emeralds = table.Column<int>(type: "integer", nullable: false, defaultValue: 10),
                    WallLevel = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    GolemLevel = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    LastUpdate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_villages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "villages");
        }
    }
}
