using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UltraNuke.Barasingha.Novel.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "N_MainCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    No = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_N_MainCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "N_SubCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MainCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    No = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_N_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_N_SubCategory_N_MainCategory_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "N_MainCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "N_Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    No = table.Column<int>(type: "int", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageToReader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WordCount = table.Column<int>(type: "int", nullable: false),
                    Favorites = table.Column<int>(type: "int", nullable: false),
                    BookStatus = table.Column<int>(type: "int", nullable: false),
                    SerialStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_N_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_N_Book_N_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "N_SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "N_Segment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    No = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_N_Segment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_N_Segment_N_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "N_Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "N_Chapter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SegmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    No = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleaseTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_N_Chapter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_N_Chapter_N_Segment_SegmentId",
                        column: x => x.SegmentId,
                        principalTable: "N_Segment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_N_Book_SubCategoryId",
                table: "N_Book",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_N_Chapter_SegmentId",
                table: "N_Chapter",
                column: "SegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_N_Segment_BookId",
                table: "N_Segment",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_N_SubCategory_MainCategoryId",
                table: "N_SubCategory",
                column: "MainCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "N_Chapter");

            migrationBuilder.DropTable(
                name: "N_Segment");

            migrationBuilder.DropTable(
                name: "N_Book");

            migrationBuilder.DropTable(
                name: "N_SubCategory");

            migrationBuilder.DropTable(
                name: "N_MainCategory");
        }
    }
}
