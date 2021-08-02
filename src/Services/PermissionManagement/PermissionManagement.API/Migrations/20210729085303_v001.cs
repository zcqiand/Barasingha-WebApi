using Microsoft.EntityFrameworkCore.Migrations;

namespace UltraNuke.Barasingha.PermissionManagement.API.Migrations
{
    public partial class v001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_S_Menu_S_Menu_ParentNodeId",
                table: "S_Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_S_RoleMenu_S_Menu_MenusId",
                table: "S_RoleMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_S_RoleMenu_S_Role_RolesId",
                table: "S_RoleMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_S_UserRole_S_Role_RolesId",
                table: "S_UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_S_UserRole_S_User_UsersId",
                table: "S_UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_S_UserRole",
                table: "S_UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_S_User",
                table: "S_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_S_RoleMenu",
                table: "S_RoleMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_S_Role",
                table: "S_Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_S_Menu",
                table: "S_Menu");

            migrationBuilder.RenameTable(
                name: "S_UserRole",
                newName: "PM_UserRole");

            migrationBuilder.RenameTable(
                name: "S_User",
                newName: "PM_User");

            migrationBuilder.RenameTable(
                name: "S_RoleMenu",
                newName: "PM_RoleMenu");

            migrationBuilder.RenameTable(
                name: "S_Role",
                newName: "PM_Role");

            migrationBuilder.RenameTable(
                name: "S_Menu",
                newName: "PM_Menu");

            migrationBuilder.RenameIndex(
                name: "IX_S_UserRole_UsersId",
                table: "PM_UserRole",
                newName: "IX_PM_UserRole_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_S_RoleMenu_RolesId",
                table: "PM_RoleMenu",
                newName: "IX_PM_RoleMenu_RolesId");

            migrationBuilder.RenameIndex(
                name: "IX_S_Menu_ParentNodeId",
                table: "PM_Menu",
                newName: "IX_PM_Menu_ParentNodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PM_UserRole",
                table: "PM_UserRole",
                columns: new[] { "RolesId", "UsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PM_User",
                table: "PM_User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PM_RoleMenu",
                table: "PM_RoleMenu",
                columns: new[] { "MenusId", "RolesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PM_Role",
                table: "PM_Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PM_Menu",
                table: "PM_Menu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PM_Menu_PM_Menu_ParentNodeId",
                table: "PM_Menu",
                column: "ParentNodeId",
                principalTable: "PM_Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PM_RoleMenu_PM_Menu_MenusId",
                table: "PM_RoleMenu",
                column: "MenusId",
                principalTable: "PM_Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PM_RoleMenu_PM_Role_RolesId",
                table: "PM_RoleMenu",
                column: "RolesId",
                principalTable: "PM_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PM_UserRole_PM_Role_RolesId",
                table: "PM_UserRole",
                column: "RolesId",
                principalTable: "PM_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PM_UserRole_PM_User_UsersId",
                table: "PM_UserRole",
                column: "UsersId",
                principalTable: "PM_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PM_Menu_PM_Menu_ParentNodeId",
                table: "PM_Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_PM_RoleMenu_PM_Menu_MenusId",
                table: "PM_RoleMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_PM_RoleMenu_PM_Role_RolesId",
                table: "PM_RoleMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_PM_UserRole_PM_Role_RolesId",
                table: "PM_UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_PM_UserRole_PM_User_UsersId",
                table: "PM_UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PM_UserRole",
                table: "PM_UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PM_User",
                table: "PM_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PM_RoleMenu",
                table: "PM_RoleMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PM_Role",
                table: "PM_Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PM_Menu",
                table: "PM_Menu");

            migrationBuilder.RenameTable(
                name: "PM_UserRole",
                newName: "S_UserRole");

            migrationBuilder.RenameTable(
                name: "PM_User",
                newName: "S_User");

            migrationBuilder.RenameTable(
                name: "PM_RoleMenu",
                newName: "S_RoleMenu");

            migrationBuilder.RenameTable(
                name: "PM_Role",
                newName: "S_Role");

            migrationBuilder.RenameTable(
                name: "PM_Menu",
                newName: "S_Menu");

            migrationBuilder.RenameIndex(
                name: "IX_PM_UserRole_UsersId",
                table: "S_UserRole",
                newName: "IX_S_UserRole_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_PM_RoleMenu_RolesId",
                table: "S_RoleMenu",
                newName: "IX_S_RoleMenu_RolesId");

            migrationBuilder.RenameIndex(
                name: "IX_PM_Menu_ParentNodeId",
                table: "S_Menu",
                newName: "IX_S_Menu_ParentNodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_S_UserRole",
                table: "S_UserRole",
                columns: new[] { "RolesId", "UsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_S_User",
                table: "S_User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_S_RoleMenu",
                table: "S_RoleMenu",
                columns: new[] { "MenusId", "RolesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_S_Role",
                table: "S_Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_S_Menu",
                table: "S_Menu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_S_Menu_S_Menu_ParentNodeId",
                table: "S_Menu",
                column: "ParentNodeId",
                principalTable: "S_Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_S_RoleMenu_S_Menu_MenusId",
                table: "S_RoleMenu",
                column: "MenusId",
                principalTable: "S_Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_S_RoleMenu_S_Role_RolesId",
                table: "S_RoleMenu",
                column: "RolesId",
                principalTable: "S_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_S_UserRole_S_Role_RolesId",
                table: "S_UserRole",
                column: "RolesId",
                principalTable: "S_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_S_UserRole_S_User_UsersId",
                table: "S_UserRole",
                column: "UsersId",
                principalTable: "S_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
