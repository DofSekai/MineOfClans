using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business.Database.Migrations
{
    /// <inheritdoc />
    public partial class InsertLevelHdv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"LevelHdvs\"(\"MaxGolems\", \"MaxWalls\", \"MaxTowers\") VALUES(2, 20, 0)");
            migrationBuilder.Sql("INSERT INTO \"LevelHdvs\"(\"MaxGolems\", \"MaxWalls\", \"MaxTowers\") VALUES(4, 40, 1)");
            migrationBuilder.Sql("INSERT INTO \"LevelHdvs\"(\"MaxGolems\", \"MaxWalls\", \"MaxTowers\") VALUES(8, 60, 2)");
            migrationBuilder.Sql("INSERT INTO \"LevelHdvs\"(\"MaxGolems\", \"MaxWalls\", \"MaxTowers\") VALUES(15, 80, 3)");
            migrationBuilder.Sql("INSERT INTO \"LevelHdvs\"(\"MaxGolems\", \"MaxWalls\", \"MaxTowers\") VALUES(25, 100, 5)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
