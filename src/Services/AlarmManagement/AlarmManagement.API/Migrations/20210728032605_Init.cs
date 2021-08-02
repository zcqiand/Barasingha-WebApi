using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UltraNuke.Barasingha.AlarmManagement.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AM_Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AM_Dispatch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaitTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_Dispatch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AM_Level",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_Level", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AM_Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AM_DispatchCondition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlarmDispatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    No = table.Column<int>(type: "int", nullable: false),
                    ConditionField = table.Column<int>(type: "int", nullable: false),
                    ConditionLogical = table.Column<int>(type: "int", nullable: false),
                    ConditionValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConditionAndOr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_DispatchCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AM_DispatchCondition_AM_Dispatch_AlarmDispatchId",
                        column: x => x.AlarmDispatchId,
                        principalTable: "AM_Dispatch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AM_DispatchUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlarmDispatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Immediately = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_DispatchUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AM_DispatchUser_AM_Dispatch_AlarmDispatchId",
                        column: x => x.AlarmDispatchId,
                        principalTable: "AM_Dispatch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AM_Alarm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OccurrenceTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimMethod = table.Column<int>(type: "int", nullable: false),
                    ClaimTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClaimUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CloseMethod = table.Column<int>(type: "int", nullable: false),
                    CloseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CloseUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Handling = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_Alarm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AM_Alarm_AM_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AM_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AM_Alarm_AM_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "AM_Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AM_NotificationItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NotificationTime = table.Column<int>(type: "int", nullable: false),
                    DelayStrategy = table.Column<int>(type: "int", nullable: false),
                    AlarmState = table.Column<int>(type: "int", nullable: false),
                    NotificationMode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_NotificationItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AM_NotificationItem_AM_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "AM_Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AM_NotificationItem_AM_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "AM_Notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AM_AlarmEvidence",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlarmId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_AlarmEvidence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AM_AlarmEvidence_AM_Alarm_AlarmId",
                        column: x => x.AlarmId,
                        principalTable: "AM_Alarm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AM_AlarmWaitingStaff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlarmId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AM_AlarmWaitingStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AM_AlarmWaitingStaff_AM_Alarm_AlarmId",
                        column: x => x.AlarmId,
                        principalTable: "AM_Alarm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AM_Alarm_CategoryId",
                table: "AM_Alarm",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AM_Alarm_LevelId",
                table: "AM_Alarm",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_AM_AlarmEvidence_AlarmId",
                table: "AM_AlarmEvidence",
                column: "AlarmId");

            migrationBuilder.CreateIndex(
                name: "IX_AM_AlarmWaitingStaff_AlarmId",
                table: "AM_AlarmWaitingStaff",
                column: "AlarmId");

            migrationBuilder.CreateIndex(
                name: "IX_AM_DispatchCondition_AlarmDispatchId",
                table: "AM_DispatchCondition",
                column: "AlarmDispatchId");

            migrationBuilder.CreateIndex(
                name: "IX_AM_DispatchUser_AlarmDispatchId",
                table: "AM_DispatchUser",
                column: "AlarmDispatchId");

            migrationBuilder.CreateIndex(
                name: "IX_AM_NotificationItem_LevelId",
                table: "AM_NotificationItem",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_AM_NotificationItem_NotificationId",
                table: "AM_NotificationItem",
                column: "NotificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AM_AlarmEvidence");

            migrationBuilder.DropTable(
                name: "AM_AlarmWaitingStaff");

            migrationBuilder.DropTable(
                name: "AM_DispatchCondition");

            migrationBuilder.DropTable(
                name: "AM_DispatchUser");

            migrationBuilder.DropTable(
                name: "AM_NotificationItem");

            migrationBuilder.DropTable(
                name: "AM_Alarm");

            migrationBuilder.DropTable(
                name: "AM_Dispatch");

            migrationBuilder.DropTable(
                name: "AM_Notification");

            migrationBuilder.DropTable(
                name: "AM_Category");

            migrationBuilder.DropTable(
                name: "AM_Level");
        }
    }
}
