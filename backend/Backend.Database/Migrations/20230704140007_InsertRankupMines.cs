using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Database.Migrations
{
    /// <inheritdoc />
    public partial class InsertRankupMines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"RankupMines\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(200, 100, 25)");
            migrationBuilder.Sql("INSERT INTO \"RankupMines\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(420, 210, 52)");
            migrationBuilder.Sql("INSERT INTO \"RankupMines\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(924, 462, 115)");
            migrationBuilder.Sql("INSERT INTO \"RankupMines\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(2125, 1062, 265)");
            migrationBuilder.Sql("INSERT INTO \"RankupMines\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(5100, 2550, 637)");
            migrationBuilder.Sql("INSERT INTO \"RankupMines\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(12751, 6375, 1593)");
            migrationBuilder.Sql("INSERT INTO \"RankupMines\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(33153, 16576, 4144)");
            migrationBuilder.Sql("INSERT INTO \"RankupMines\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(89513, 44765, 11189)");
            migrationBuilder.Sql("INSERT INTO \"RankupMines\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(250637, 125318, 31329)");
            migrationBuilder.Sql("INSERT INTO \"RankupMines\"(\"Irons\", \"Diamonds\", \"Emeralds\") VALUES(726849, 363424, 90856)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
