using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef_configs.Migrations
{
    public partial class ChangeSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Shop");

            migrationBuilder.RenameTable(
                name: "Kalaha",
                newName: "Kalaha",
                newSchema: "Shop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Kalaha",
                schema: "Shop",
                newName: "Kalaha");
        }
    }
}
