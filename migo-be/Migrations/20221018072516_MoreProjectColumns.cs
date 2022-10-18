using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alliance_API.Migrations
{
    public partial class MoreProjectColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Deadline",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Projects");
        }
    }
}
