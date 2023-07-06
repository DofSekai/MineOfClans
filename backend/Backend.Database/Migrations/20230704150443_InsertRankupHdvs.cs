using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Database.Migrations
{
    /// <inheritdoc />
    public partial class InsertRankupHdvs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"RankupHdvs\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(800, 400, 100)");
            migrationBuilder.Sql("INSERT INTO \"RankupHdvs\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(9000, 5000, 1000)");
            migrationBuilder.Sql("INSERT INTO \"RankupHdvs\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(35000, 20000, 10000)");
            migrationBuilder.Sql("INSERT INTO \"RankupHdvs\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(50000, 50000, 30000)");
            migrationBuilder.Sql("INSERT INTO \"RankupHdvs\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(200000, 100000, 99000)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
