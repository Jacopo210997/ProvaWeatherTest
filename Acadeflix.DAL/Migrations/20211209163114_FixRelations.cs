using Microsoft.EntityFrameworkCore.Migrations;

namespace Acadeflix.DAL.Migrations
{
    public partial class FixRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Contents_ContentId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_ContentId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "Genres");

            migrationBuilder.CreateTable(
                name: "ContentGenre",
                columns: table => new
                {
                    ContentsId = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentGenre", x => new { x.ContentsId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_ContentGenre_Contents_ContentsId",
                        column: x => x.ContentsId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentGenre_GenresId",
                table: "ContentGenre",
                column: "GenresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentGenre");

            migrationBuilder.AddColumn<int>(
                name: "ContentId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_ContentId",
                table: "Genres",
                column: "ContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Contents_ContentId",
                table: "Genres",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
