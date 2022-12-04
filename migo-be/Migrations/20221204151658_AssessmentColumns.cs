using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alliance_API.Migrations
{
    public partial class AssessmentColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgilityRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EfficiencyRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FunctionalComponentsRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InnovationRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IntegrityRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PerformanceRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QualityRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgilityRemark",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "EfficiencyRemark",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "FunctionalComponentsRemark",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "InnovationRemark",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "IntegrityRemark",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "PerformanceRemark",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "QualityRemark",
                table: "Assessments");
        }
    }
}
