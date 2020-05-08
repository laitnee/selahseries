using Microsoft.EntityFrameworkCore.Migrations;

namespace SelahSeries.Migrations
{
    public partial class cascadedelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostClaps_Posts_PostId",
                table: "PostClaps");

            migrationBuilder.DropIndex(
                name: "IX_PostClaps_PostId",
                table: "PostClaps");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "PostClaps");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommentId1",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostClapId",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CommentId1",
                table: "Posts",
                column: "CommentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostClapId",
                table: "Posts",
                column: "PostClapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Comments_CommentId1",
                table: "Posts",
                column: "CommentId1",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostClaps_PostClapId",
                table: "Posts",
                column: "PostClapId",
                principalTable: "PostClaps",
                principalColumn: "PostClapId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Comments_CommentId1",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostClaps_PostClapId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CommentId1",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostClapId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CommentId1",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostClapId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "PostClaps",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostClaps_PostId",
                table: "PostClaps",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostClaps_Posts_PostId",
                table: "PostClaps",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
