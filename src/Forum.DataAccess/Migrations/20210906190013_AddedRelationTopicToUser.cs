using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.DataAccess.Migrations
{
    public partial class AddedRelationTopicToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicMessage_User_UserId",
                table: "TopicMessage");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Topic",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Topic_UserId",
                table: "Topic",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_User_UserId",
                table: "Topic",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicMessage_User_UserId",
                table: "TopicMessage",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_User_UserId",
                table: "Topic");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicMessage_User_UserId",
                table: "TopicMessage");

            migrationBuilder.DropIndex(
                name: "IX_Topic_UserId",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Topic");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicMessage_User_UserId",
                table: "TopicMessage",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
