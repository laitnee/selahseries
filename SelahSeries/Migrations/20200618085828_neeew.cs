using Microsoft.EntityFrameworkCore.Migrations;

namespace SelahSeries.Migrations
{
    public partial class neeew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalPostCount",
                table: "Posts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPostCount",
                table: "Posts");
        }
    }
}
