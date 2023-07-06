using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Database.Migrations
{
    /// <inheritdoc />
    public partial class InsertLevelMines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"LevelMines\"(\"IronRate\", \"DiamondRate\", \"EmeraldRate\", \"IronMaxRate\", \"DiamondMaxRate\", \"EmeraldMaxRate\") VALUES(3, 2, 1, 2000, 1000, 250)");
            migrationBuilder.Sql("INSERT INTO \"LevelMines\"(\"IronRate\", \"DiamondRate\", \"EmeraldRate\", \"IronMaxRate\", \"DiamondMaxRate\", \"EmeraldMaxRate\") VALUES(7, 5, 2, 4200, 2100, 520)");
            migrationBuilder.Sql("INSERT INTO \"LevelMines\"(\"IronRate\", \"DiamondRate\", \"EmeraldRate\", \"IronMaxRate\", \"DiamondMaxRate\", \"EmeraldMaxRate\") VALUES(16, 12, 4, 9240, 4620, 1150)");
            migrationBuilder.Sql("INSERT INTO \"LevelMines\"(\"IronRate\", \"DiamondRate\", \"EmeraldRate\", \"IronMaxRate\", \"DiamondMaxRate\", \"EmeraldMaxRate\") VALUES(40, 28, 8, 21250, 10620, 2650)");
            migrationBuilder.Sql("INSERT INTO \"LevelMines\"(\"IronRate\", \"DiamondRate\", \"EmeraldRate\", \"IronMaxRate\", \"DiamondMaxRate\", \"EmeraldMaxRate\") VALUES(100, 64, 20, 51000, 25500, 6370)");
            migrationBuilder.Sql("INSERT INTO \"LevelMines\"(\"IronRate\", \"DiamondRate\", \"EmeraldRate\", \"IronMaxRate\", \"DiamondMaxRate\", \"EmeraldMaxRate\") VALUES(230, 135, 50, 127510, 63750, 15930)");
            migrationBuilder.Sql("INSERT INTO \"LevelMines\"(\"IronRate\", \"DiamondRate\", \"EmeraldRate\", \"IronMaxRate\", \"DiamondMaxRate\", \"EmeraldMaxRate\") VALUES(490, 285, 120, 331530, 165760, 41440)");
            migrationBuilder.Sql("INSERT INTO \"LevelMines\"(\"IronRate\", \"DiamondRate\", \"EmeraldRate\", \"IronMaxRate\", \"DiamondMaxRate\", \"EmeraldMaxRate\") VALUES(910, 590, 255, 895130, 447650, 111890)");
            migrationBuilder.Sql("INSERT INTO \"LevelMines\"(\"IronRate\", \"DiamondRate\", \"EmeraldRate\", \"IronMaxRate\", \"DiamondMaxRate\", \"EmeraldMaxRate\") VALUES(1950, 1200, 530, 2506370, 1253180, 313290)");
            migrationBuilder.Sql("INSERT INTO \"LevelMines\"(\"IronRate\", \"DiamondRate\", \"EmeraldRate\", \"IronMaxRate\", \"DiamondMaxRate\", \"EmeraldMaxRate\") VALUES(3000, 2500, 1200, 7268490, 3634240, 908560)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
