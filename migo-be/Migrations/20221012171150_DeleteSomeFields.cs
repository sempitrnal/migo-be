using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alliance_API.Migrations
{
    public partial class DeleteSomeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NumberOfChildren",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SpouseContactNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SpouseName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SpouseOccupation",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfChildren",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SpouseContactNumber",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpouseName",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpouseOccupation",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
