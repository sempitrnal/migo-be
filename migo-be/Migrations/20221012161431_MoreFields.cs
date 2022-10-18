using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alliance_API.Migrations
{
    public partial class MoreFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Employees",
                newName: "SpouseOccupation");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Employees",
                newName: "SpouseName");

            migrationBuilder.AddColumn<string>(
                name: "Birthdate",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CityAddress",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CityContactNumber",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CivicClubAffiliation",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyAddress",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactNumber",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyName",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyOfficeContactNumber",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyRelationship",
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

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDependents",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PositionApplied",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PositionCode",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Profession",
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

            migrationBuilder.AddColumn<string>(
                name: "ProvincialContactNumber",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpouseContactNumber",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "YearsOfExperience",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CityAddress",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CityContactNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CivicClubAffiliation",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmergencyAddress",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmergencyContactNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmergencyName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmergencyOfficeContactNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmergencyRelationship",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmergencyResidentialContactNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NumberOfChildren",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NumberOfDependents",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PositionApplied",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PositionCode",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Profession",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ProvincialAddress",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ProvincialContactNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SpouseContactNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "YearsOfExperience",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "SpouseOccupation",
                table: "Employees",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "SpouseName",
                table: "Employees",
                newName: "Birthday");
        }
    }
}
