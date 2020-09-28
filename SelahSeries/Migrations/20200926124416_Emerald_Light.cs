using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SelahSeries.Migrations
{
    public partial class Emerald_Light : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Testtimonies",
                table: "Testtimonies");

            migrationBuilder.RenameTable(
                name: "Testtimonies",
                newName: "Testimonies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testimonies",
                table: "Testimonies",
                column: "TestimonyId");

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PictureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Testimonies",
                table: "Testimonies");

            migrationBuilder.RenameTable(
                name: "Testimonies",
                newName: "Testtimonies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testtimonies",
                table: "Testtimonies",
                column: "TestimonyId");
        }
    }
}
