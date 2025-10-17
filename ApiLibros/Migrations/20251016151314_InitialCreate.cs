using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiLibros.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    isbn = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    author = table.Column<string>(type: "TEXT", nullable: false),
                    year_of_publication = table.Column<int>(type: "INTEGER", nullable: false),
                    publisher = table.Column<string>(type: "TEXT", nullable: false),
                    image_url_s = table.Column<string>(type: "TEXT", nullable: false),
                    image_url_m = table.Column<string>(type: "TEXT", nullable: false),
                    image_url_l = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.isbn);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
