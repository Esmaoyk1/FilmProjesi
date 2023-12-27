using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esel.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieCategoryModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieCategoryModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCategoryModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductionYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IMDbStar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yonetmen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oyuncular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    MovieCategoryModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_MovieCategoryModels_MovieCategoryModelId",
                        column: x => x.MovieCategoryModelId,
                        principalTable: "MovieCategoryModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_MovieCategoryModelId",
                table: "Category",
                column: "MovieCategoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategoryModels_MovieId",
                table: "MovieCategoryModels",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieCategoryModelId",
                table: "Movies",
                column: "MovieCategoryModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_MovieCategoryModels_MovieCategoryModelId",
                table: "Category",
                column: "MovieCategoryModelId",
                principalTable: "MovieCategoryModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCategoryModels_Movies_MovieId",
                table: "MovieCategoryModels",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieCategoryModels_MovieCategoryModelId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "MovieCategoryModels");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
