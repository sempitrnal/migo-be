using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alliance_API.Migrations
{
    public partial class EmployeeProjectRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    AssignedEmployeesId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignedProjectsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => new { x.AssignedEmployeesId, x.AssignedProjectsId });
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employees_AssignedEmployeesId",
                        column: x => x.AssignedEmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Project_AssignedProjectsId",
                        column: x => x.AssignedProjectsId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_AssignedProjectsId",
                table: "EmployeeProject",
                column: "AssignedProjectsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
