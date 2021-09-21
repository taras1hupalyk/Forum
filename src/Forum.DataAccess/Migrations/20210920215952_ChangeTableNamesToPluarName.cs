using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.DataAccess.Migrations
{
    public partial class ChangeTableNamesToPluarName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_AspNetUsers_UserId",
                table: "Topic");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Category_CategoryId",
                table: "Topic");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicMessage_AspNetUsers_UserId",
                table: "TopicMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicMessage_Topic_TopicId",
                table: "TopicMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TopicMessage",
                table: "TopicMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topic",
                table: "Topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "TopicMessage",
                newName: "TopicMessages");

            migrationBuilder.RenameTable(
                name: "Topic",
                newName: "Topics");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_TopicMessage_UserId",
                table: "TopicMessages",
                newName: "IX_TopicMessages_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TopicMessage_TopicId",
                table: "TopicMessages",
                newName: "IX_TopicMessages_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Topic_UserId",
                table: "Topics",
                newName: "IX_Topics_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Topic_CategoryId",
                table: "Topics",
                newName: "IX_Topics_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TopicMessages",
                table: "TopicMessages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topics",
                table: "Topics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicMessages_AspNetUsers_UserId",
                table: "TopicMessages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicMessages_Topics_TopicId",
                table: "TopicMessages",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_UserId",
                table: "Topics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Categories_CategoryId",
                table: "Topics",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicMessages_AspNetUsers_UserId",
                table: "TopicMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicMessages_Topics_TopicId",
                table: "TopicMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_UserId",
                table: "Topics");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Categories_CategoryId",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topics",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TopicMessages",
                table: "TopicMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Topics",
                newName: "Topic");

            migrationBuilder.RenameTable(
                name: "TopicMessages",
                newName: "TopicMessage");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Topics_UserId",
                table: "Topic",
                newName: "IX_Topic_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Topics_CategoryId",
                table: "Topic",
                newName: "IX_Topic_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_TopicMessages_UserId",
                table: "TopicMessage",
                newName: "IX_TopicMessage_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TopicMessages_TopicId",
                table: "TopicMessage",
                newName: "IX_TopicMessage_TopicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topic",
                table: "Topic",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TopicMessage",
                table: "TopicMessage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_AspNetUsers_UserId",
                table: "Topic",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Category_CategoryId",
                table: "Topic",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicMessage_AspNetUsers_UserId",
                table: "TopicMessage",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicMessage_Topic_TopicId",
                table: "TopicMessage",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
