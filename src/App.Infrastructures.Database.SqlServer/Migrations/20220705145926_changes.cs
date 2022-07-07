using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructures.Database.SqlServer.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasValue",
                table: "Tags");

            migrationBuilder.AddColumn<bool>(
                name: "HasValue",
                table: "TagCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasValue",
                table: "TagCategories");

            migrationBuilder.AddColumn<bool>(
                name: "HasValue",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
