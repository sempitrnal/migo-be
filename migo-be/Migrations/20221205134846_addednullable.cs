using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alliance_API.Migrations
{
    public partial class addednullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Agilities_AgilityId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Efficiencies_EfficiencyId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_FunctionalComponents_FunctionalComponentsId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Innovations_InnovationId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Integrities_IntegrityId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Performances_PerformanceId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Quality_QualityId",
                table: "Assessments");

            migrationBuilder.AlterColumn<string>(
                name: "QualityRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "QualityId",
                table: "Assessments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "PerformanceRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "PerformanceId",
                table: "Assessments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "IntegrityRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "IntegrityId",
                table: "Assessments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "InnovationRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "InnovationId",
                table: "Assessments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "FunctionalComponentsRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "FunctionalComponentsId",
                table: "Assessments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "EfficiencyRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "EfficiencyId",
                table: "Assessments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "AgilityRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "AgilityId",
                table: "Assessments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Agilities_AgilityId",
                table: "Assessments",
                column: "AgilityId",
                principalTable: "Agilities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Efficiencies_EfficiencyId",
                table: "Assessments",
                column: "EfficiencyId",
                principalTable: "Efficiencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_FunctionalComponents_FunctionalComponentsId",
                table: "Assessments",
                column: "FunctionalComponentsId",
                principalTable: "FunctionalComponents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Innovations_InnovationId",
                table: "Assessments",
                column: "InnovationId",
                principalTable: "Innovations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Integrities_IntegrityId",
                table: "Assessments",
                column: "IntegrityId",
                principalTable: "Integrities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Performances_PerformanceId",
                table: "Assessments",
                column: "PerformanceId",
                principalTable: "Performances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Quality_QualityId",
                table: "Assessments",
                column: "QualityId",
                principalTable: "Quality",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Agilities_AgilityId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Efficiencies_EfficiencyId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_FunctionalComponents_FunctionalComponentsId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Innovations_InnovationId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Integrities_IntegrityId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Performances_PerformanceId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Quality_QualityId",
                table: "Assessments");

            migrationBuilder.AlterColumn<string>(
                name: "QualityRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QualityId",
                table: "Assessments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PerformanceRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PerformanceId",
                table: "Assessments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IntegrityRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IntegrityId",
                table: "Assessments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InnovationRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InnovationId",
                table: "Assessments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FunctionalComponentsRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FunctionalComponentsId",
                table: "Assessments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EfficiencyRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EfficiencyId",
                table: "Assessments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgilityRemark",
                table: "Assessments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgilityId",
                table: "Assessments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Agilities_AgilityId",
                table: "Assessments",
                column: "AgilityId",
                principalTable: "Agilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Efficiencies_EfficiencyId",
                table: "Assessments",
                column: "EfficiencyId",
                principalTable: "Efficiencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_FunctionalComponents_FunctionalComponentsId",
                table: "Assessments",
                column: "FunctionalComponentsId",
                principalTable: "FunctionalComponents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Innovations_InnovationId",
                table: "Assessments",
                column: "InnovationId",
                principalTable: "Innovations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Integrities_IntegrityId",
                table: "Assessments",
                column: "IntegrityId",
                principalTable: "Integrities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Performances_PerformanceId",
                table: "Assessments",
                column: "PerformanceId",
                principalTable: "Performances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Quality_QualityId",
                table: "Assessments",
                column: "QualityId",
                principalTable: "Quality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
