using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business.Database.Migrations
{
    /// <inheritdoc />
    public partial class InsertMaxItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"maxItems\"(\"MaxGolems\", \"MaxWalls\", \"MaxTowers\") VALUES(2, 20, 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
