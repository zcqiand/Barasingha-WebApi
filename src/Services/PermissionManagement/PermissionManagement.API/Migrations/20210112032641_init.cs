using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UltraNuke.Barasingha.PermissionManagement.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "S_Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NavigateUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    No = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentNodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsRootNode = table.Column<bool>(type: "bit", nullable: false),
                    IsLeafNode = table.Column<bool>(type: "bit", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    FullSortNo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_S_Menu_S_Menu_ParentNodeId",
                        column: x => x.ParentNodeId,
                        principalTable: "S_Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "S_Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "S_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "S_RoleMenu",
                columns: table => new
                {
                    MenusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_RoleMenu", x => new { x.MenusId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_S_RoleMenu_S_Menu_MenusId",
                        column: x => x.MenusId,
                        principalTable: "S_Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_S_RoleMenu_S_Role_RolesId",
                        column: x => x.RolesId,
                        principalTable: "S_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "S_UserRole",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_UserRole", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_S_UserRole_S_Role_RolesId",
                        column: x => x.RolesId,
                        principalTable: "S_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_S_UserRole_S_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "S_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_S_Menu_ParentNodeId",
                table: "S_Menu",
                column: "ParentNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_S_RoleMenu_RolesId",
                table: "S_RoleMenu",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_S_UserRole_UsersId",
                table: "S_UserRole",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "S_RoleMenu");

            migrationBuilder.DropTable(
                name: "S_UserRole");

            migrationBuilder.DropTable(
                name: "S_Menu");

            migrationBuilder.DropTable(
                name: "S_Role");

            migrationBuilder.DropTable(
                name: "S_User");
        }
    }
}
