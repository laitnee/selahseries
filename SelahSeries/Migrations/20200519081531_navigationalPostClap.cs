using Microsoft.EntityFrameworkCore.Migrations;

namespace SelahSeries.Migrations
{
    public partial class navigationalPostClap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostClaps_PostClapId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostClapId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostClapId",
                table: "Posts");

            migrationBuilder.AddForeignKey(
                name: "FK_PostClaps_Posts_PostClapId",
                table: "PostClaps",
                column: "PostClapId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostClaps_Posts_PostClapId",
                table: "PostClaps");

            migrationBuilder.AddColumn<int>(
                name: "PostClapId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostClapId",
                table: "Posts",
                column: "PostClapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostClaps_PostClapId",
                table: "Posts",
                column: "PostClapId",
                principalTable: "PostClaps",
                principalColumn: "PostClapId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
