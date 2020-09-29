using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SelahSeries.Migrations
{
    public partial class Database_Update_EMI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPostCount",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "FacebookPostLink",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedInPostLink",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterPostLink",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Testtimonies",
                columns: table => new
                {
                    TestimonyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Testimonial = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testtimonies", x => x.TestimonyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Testtimonies");

            migrationBuilder.DropColumn(
                name: "FacebookPostLink",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "LinkedInPostLink",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "TwitterPostLink",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "TotalPostCount",
                table: "Posts",
                nullable: false,
                defaultValue: 0);
        }
    }
}
