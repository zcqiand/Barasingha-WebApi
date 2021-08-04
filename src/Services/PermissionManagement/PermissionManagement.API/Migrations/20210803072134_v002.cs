using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UltraNuke.Barasingha.PermissionManagement.API.Migrations
{
    public partial class v002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordAnswer",
                table: "PM_User");

            migrationBuilder.DropColumn(
                name: "PasswordQuestion",
                table: "PM_User");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "PM_User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "PM_Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "PM_Menu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "PM_User");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "PM_Role");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "PM_Menu");

            migrationBuilder.AddColumn<string>(
                name: "PasswordAnswer",
                table: "PM_User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordQuestion",
                table: "PM_User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
