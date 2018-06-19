using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UpdateQ.Data.Migrations
{
    public partial class InitialDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Age = table.Column<int>(nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoNodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    InfoNodeId = table.Column<int>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoNodes_InfoNodes_InfoNodeId",
                        column: x => x.InfoNodeId,
                        principalTable: "InfoNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfoNodes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeSeriesNodes",
                columns: table => new
                {
                    SensorId = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    InfoNodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSeriesNodes", x => x.SensorId);
                    table.ForeignKey(
                        name: "FK_TimeSeriesNodes_InfoNodes_InfoNodeId",
                        column: x => x.InfoNodeId,
                        principalTable: "InfoNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InfoNodes_InfoNodeId",
                table: "InfoNodes",
                column: "InfoNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoNodes_UserId",
                table: "InfoNodes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSeriesNodes_InfoNodeId",
                table: "TimeSeriesNodes",
                column: "InfoNodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSeriesNodes");

            migrationBuilder.DropTable(
                name: "InfoNodes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
