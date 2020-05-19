using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SelahSeries.Migrations
{
    public partial class new_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_HardBooks_HardBookId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_SoftBooks_Categories_CategoryId",
                table: "SoftBooks");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "SoftBooks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SoftBooks");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "SoftBooks");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "SoftBooks");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "HardBooks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "HardBooks");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "HardBooks");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "HardBooks");

            migrationBuilder.RenameColumn(
                name: "HardBookId",
                table: "Orders",
                newName: "HardBookHarbookId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_HardBookId",
                table: "Orders",
                newName: "IX_Orders_HardBookHarbookId");

            migrationBuilder.RenameColumn(
                name: "CatergoryId",
                table: "HardBooks",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "HardBookId",
                table: "HardBooks",
                newName: "HarbookId");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "SoftBooks",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "SoftBooks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "SoftBooks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "HardBooks",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Author = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 100, nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    IsHardBook = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoftBooks_BookId",
                table: "SoftBooks",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HardBooks_BookId",
                table: "HardBooks",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_HardBooks_Books_BookId",
                table: "HardBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_HardBooks_HardBookHarbookId",
                table: "Orders",
                column: "HardBookHarbookId",
                principalTable: "HardBooks",
                principalColumn: "HarbookId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftBooks_Books_BookId",
                table: "SoftBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftBooks_Categories_CategoryId",
                table: "SoftBooks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HardBooks_Books_BookId",
                table: "HardBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_HardBooks_HardBookHarbookId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_SoftBooks_Books_BookId",
                table: "SoftBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_SoftBooks_Categories_CategoryId",
                table: "SoftBooks");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropIndex(
                name: "IX_SoftBooks_BookId",
                table: "SoftBooks");

            migrationBuilder.DropIndex(
                name: "IX_HardBooks_BookId",
                table: "HardBooks");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "SoftBooks");

            migrationBuilder.RenameColumn(
                name: "HardBookHarbookId",
                table: "Orders",
                newName: "HardBookId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_HardBookHarbookId",
                table: "Orders",
                newName: "IX_Orders_HardBookId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "HardBooks",
                newName: "CatergoryId");

            migrationBuilder.RenameColumn(
                name: "HarbookId",
                table: "HardBooks",
                newName: "HardBookId");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "SoftBooks",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "SoftBooks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "SoftBooks",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SoftBooks",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "SoftBooks",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "SoftBooks",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "HardBooks",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "HardBooks",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "HardBooks",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "HardBooks",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "HardBooks",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_HardBooks_HardBookId",
                table: "Orders",
                column: "HardBookId",
                principalTable: "HardBooks",
                principalColumn: "HardBookId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SoftBooks_Categories_CategoryId",
                table: "SoftBooks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
