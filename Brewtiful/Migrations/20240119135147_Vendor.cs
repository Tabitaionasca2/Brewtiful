using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Brewtiful.Migrations
{
    /// <inheritdoc />
    public partial class Vendor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vendor",
                table: "Caffee");

            migrationBuilder.AddColumn<int>(
                name: "VendorID",
                table: "Caffee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caffee_VendorID",
                table: "Caffee",
                column: "VendorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Caffee_Vendor_VendorID",
                table: "Caffee",
                column: "VendorID",
                principalTable: "Vendor",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caffee_Vendor_VendorID",
                table: "Caffee");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropIndex(
                name: "IX_Caffee_VendorID",
                table: "Caffee");

            migrationBuilder.DropColumn(
                name: "VendorID",
                table: "Caffee");

            migrationBuilder.AddColumn<string>(
                name: "Vendor",
                table: "Caffee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
