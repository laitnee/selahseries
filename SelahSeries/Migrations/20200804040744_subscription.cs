using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SelahSeries.Migrations
{
    public partial class subscription : Migration
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
                name: "EmailSubcriptions",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubscriberEmail = table.Column<string>(maxLength: 50, nullable: true),
                    ConfirmEmail = table.Column<bool>(nullable: false),
                    ConfirmationCode = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSubcriptions", x => x.SubscriptionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailSubcriptions");

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
