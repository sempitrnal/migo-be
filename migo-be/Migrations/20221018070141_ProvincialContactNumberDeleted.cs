using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alliance_API.Migrations
{
    public partial class ProvincialContactNumberDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProvincialContactNumber",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProvincialContactNumber",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
