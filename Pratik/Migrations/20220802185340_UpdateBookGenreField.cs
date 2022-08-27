using Microsoft.EntityFrameworkCore.Migrations;

namespace Pratik.Migrations
{
    public partial class UpdateBookGenreField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_book_genreid",
                table: "book",
                column: "genreid");

            migrationBuilder.AddForeignKey(
                name: "FK_book_genre_genreid",
                table: "book",
                column: "genreid",
                principalTable: "genre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_genre_genreid",
                table: "book");

            migrationBuilder.DropIndex(
                name: "IX_book_genreid",
                table: "book");
        }
    }
}
