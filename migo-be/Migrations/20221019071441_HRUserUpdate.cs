using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alliance_API.Migrations
{
    public partial class HRUserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "HRUsers");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "HRUsers",
                newName: "Username");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "HRUsers",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "HRUsers",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "HRUsers");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "HRUsers");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "HRUsers",
                newName: "username");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "HRUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
