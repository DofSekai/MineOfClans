using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business.Database.Migrations
{
    /// <inheritdoc />
    public partial class InsertRankupHdv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"rankupHdvs\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(800, 400, 100)");
            migrationBuilder.Sql("INSERT INTO \"rankupHdvs\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(331530, 165760, 41440)");
            migrationBuilder.Sql("INSERT INTO \"rankupHdvs\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(7268490, 3634240, 908560)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
