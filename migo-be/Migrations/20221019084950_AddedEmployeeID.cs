using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alliance_API.Migrations
{
    public partial class AddedEmployeeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTimeLogs_Employees_employeeId",
                table: "EmployeeTimeLogs");

            migrationBuilder.RenameColumn(
                name: "employeeId",
                table: "EmployeeTimeLogs",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTimeLogs_employeeId",
                table: "EmployeeTimeLogs",
                newName: "IX_EmployeeTimeLogs_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTimeLogs_Employees_EmployeeId",
                table: "EmployeeTimeLogs",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTimeLogs_Employees_EmployeeId",
                table: "EmployeeTimeLogs");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "EmployeeTimeLogs",
                newName: "employeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTimeLogs_EmployeeId",
                table: "EmployeeTimeLogs",
                newName: "IX_EmployeeTimeLogs_employeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTimeLogs_Employees_employeeId",
                table: "EmployeeTimeLogs",
                column: "employeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
