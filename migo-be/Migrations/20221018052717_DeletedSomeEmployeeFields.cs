using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alliance_API.Migrations
{
    public partial class DeletedSomeEmployeeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmergencyOfficeContactNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmergencyResidentialContactNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ProvincialAddress",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "CivicClubAffiliation",
                table: "Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CivicClubAffiliation",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyOfficeContactNumber",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyResidentialContactNumber",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProvincialAddress",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
