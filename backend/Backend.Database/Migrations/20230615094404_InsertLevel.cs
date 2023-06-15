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
            migrationBuilder.Sql("INSERT INTO \"levelMines\"(\"IronRate\", \"DiamondRate\", \"EmeraldRate\", \"IronMaxRate\", \"DiamondMaxRate\", \"EmeraldMaxRate\") VALUES(3, 2, 1, 10000, 10000, 10000)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
