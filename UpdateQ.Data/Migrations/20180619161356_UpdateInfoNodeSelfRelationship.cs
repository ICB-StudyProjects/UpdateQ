using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UpdateQ.Data.Migrations
{
    public partial class UpdateInfoNodeSelfRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoNodes_InfoNodes_InfoNodeId",
                table: "InfoNodes");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoNodes_Users_UserId",
                table: "InfoNodes");

            migrationBuilder.DropIndex(
                name: "IX_InfoNodes_UserId",
                table: "InfoNodes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "InfoNodes");

            migrationBuilder.RenameColumn(
                name: "InfoNodeId",
                table: "InfoNodes",
                newName: "ParentInfoNodeId");

            migrationBuilder.RenameIndex(
                name: "IX_InfoNodes_InfoNodeId",
                table: "InfoNodes",
                newName: "IX_InfoNodes_ParentInfoNodeId");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "InfoNodes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InfoNodes_OwnerId",
                table: "InfoNodes",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoNodes_Users_OwnerId",
                table: "InfoNodes",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoNodes_InfoNodes_ParentInfoNodeId",
                table: "InfoNodes",
                column: "ParentInfoNodeId",
                principalTable: "InfoNodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoNodes_Users_OwnerId",
                table: "InfoNodes");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoNodes_InfoNodes_ParentInfoNodeId",
                table: "InfoNodes");

            migrationBuilder.DropIndex(
                name: "IX_InfoNodes_OwnerId",
                table: "InfoNodes");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "InfoNodes");

            migrationBuilder.RenameColumn(
                name: "ParentInfoNodeId",
                table: "InfoNodes",
                newName: "InfoNodeId");

            migrationBuilder.RenameIndex(
                name: "IX_InfoNodes_ParentInfoNodeId",
                table: "InfoNodes",
                newName: "IX_InfoNodes_InfoNodeId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "InfoNodes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfoNodes_UserId",
                table: "InfoNodes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoNodes_InfoNodes_InfoNodeId",
                table: "InfoNodes",
                column: "InfoNodeId",
                principalTable: "InfoNodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoNodes_Users_UserId",
                table: "InfoNodes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
