using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Business.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddLevelUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "users",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 26, 14, 21, 8, 948, DateTimeKind.Local).AddTicks(7369));
        }
    }
}
