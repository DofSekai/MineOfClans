using Backend.Common.DAO;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business.Database.Migrations
{
    /// <inheritdoc />
    public partial class InsertLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"levelMines\"(\"IronRate\", \"DiamondRate\", \"EmeraldRate\", \"IronMaxRate\", \"DiamondMaxRate\", \"EmeraldMaxRate\") VALUES(10, 5, 1, 100, 50, 20)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
