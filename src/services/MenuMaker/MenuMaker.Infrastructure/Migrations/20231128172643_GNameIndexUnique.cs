using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GNameIndexUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Groceries_NameSelectable",
                table: "Groceries");

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_NameSelectable",
                table: "Groceries",
                column: "NameSelectable",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Groceries_NameSelectable",
                table: "Groceries");

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_NameSelectable",
                table: "Groceries",
                column: "NameSelectable");
        }
    }
}
