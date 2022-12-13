using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alliance_API.Migrations
{
    public partial class AddedImageTrainingProjectBenefits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Benefits");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Trainings",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Benefits",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Benefits");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Benefits",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
