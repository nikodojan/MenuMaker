using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ParentCatNotRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCategories_GroceryCategories_ParentCategoryId",
                table: "GroceryCategories");

            migrationBuilder.AlterColumn<int>(
                name: "ParentCategoryId",
                table: "GroceryCategories",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryCategories_GroceryCategories_ParentCategoryId",
                table: "GroceryCategories",
                column: "ParentCategoryId",
                principalTable: "GroceryCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCategories_GroceryCategories_ParentCategoryId",
                table: "GroceryCategories");

            migrationBuilder.AlterColumn<int>(
                name: "ParentCategoryId",
                table: "GroceryCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryCategories_GroceryCategories_ParentCategoryId",
                table: "GroceryCategories",
                column: "ParentCategoryId",
                principalTable: "GroceryCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
