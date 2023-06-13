using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsersVillageId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillageId",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_VillageId",
                table: "users",
                column: "VillageId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_villages_VillageId",
                table: "users",
                column: "VillageId",
                principalTable: "villages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_villages_VillageId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_VillageId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "VillageId",
                table: "users");
        }
    }
}
