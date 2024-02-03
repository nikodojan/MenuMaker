using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GrGrcDeleteBehaviour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groceries_GroceryCategories_CategoryId",
                table: "Groceries");

            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCategories_GroceryCategories_ParentCategoryId",
                table: "GroceryCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_Groceries_GroceryCategories_CategoryId",
                table: "Groceries",
                column: "CategoryId",
                principalTable: "GroceryCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryCategories_GroceryCategories_ParentCategoryId",
                table: "GroceryCategories",
                column: "ParentCategoryId",
                principalTable: "GroceryCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groceries_GroceryCategories_CategoryId",
                table: "Groceries");

            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCategories_GroceryCategories_ParentCategoryId",
                table: "GroceryCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_Groceries_GroceryCategories_CategoryId",
                table: "Groceries",
                column: "CategoryId",
                principalTable: "GroceryCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryCategories_GroceryCategories_ParentCategoryId",
                table: "GroceryCategories",
                column: "ParentCategoryId",
                principalTable: "GroceryCategories",
                principalColumn: "Id");
        }
    }
}
