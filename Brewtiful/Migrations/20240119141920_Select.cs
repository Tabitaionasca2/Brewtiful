using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Brewtiful.Migrations
{
    /// <inheritdoc />
    public partial class Select : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CaffeeCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaffeeID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaffeeCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CaffeeCategory_Caffee_CaffeeID",
                        column: x => x.CaffeeID,
                        principalTable: "Caffee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaffeeCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaffeeCategory_CaffeeID",
                table: "CaffeeCategory",
                column: "CaffeeID");

            migrationBuilder.CreateIndex(
                name: "IX_CaffeeCategory_CategoryID",
                table: "CaffeeCategory",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaffeeCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
