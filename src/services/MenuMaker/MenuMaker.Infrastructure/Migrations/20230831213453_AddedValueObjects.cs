using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedValueObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Groceries_GroceryId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Calories",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "NutritionFacts",
                newName: "Sugar_Unit");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "NutritionFacts",
                newName: "Sugar_Amount");

            migrationBuilder.RenameColumn(
                name: "Sugar",
                table: "NutritionFacts",
                newName: "ServingSize_Amount");

            migrationBuilder.RenameColumn(
                name: "Protein",
                table: "NutritionFacts",
                newName: "Protein_Amount");

            migrationBuilder.RenameColumn(
                name: "Fat",
                table: "NutritionFacts",
                newName: "Fat_Amount");

            migrationBuilder.RenameColumn(
                name: "Carbonhydrates",
                table: "NutritionFacts",
                newName: "Carbonhydrates_Amount");

            migrationBuilder.AlterColumn<double>(
                name: "Sugar_Amount",
                table: "NutritionFacts",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "Calories_Amount",
                table: "NutritionFacts",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Calories_Unit",
                table: "NutritionFacts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Carbonhydrates_Unit",
                table: "NutritionFacts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Fat_Unit",
                table: "NutritionFacts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Protein_Unit",
                table: "NutritionFacts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ServingSize_Unit",
                table: "NutritionFacts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "GroceryId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Groceries_GroceryId",
                table: "Ingredients",
                column: "GroceryId",
                principalTable: "Groceries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Groceries_GroceryId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Calories_Amount",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "Calories_Unit",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "Carbonhydrates_Unit",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "Fat_Unit",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "Protein_Unit",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "ServingSize_Unit",
                table: "NutritionFacts");

            migrationBuilder.RenameColumn(
                name: "Sugar_Unit",
                table: "NutritionFacts",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "Sugar_Amount",
                table: "NutritionFacts",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "ServingSize_Amount",
                table: "NutritionFacts",
                newName: "Sugar");

            migrationBuilder.RenameColumn(
                name: "Protein_Amount",
                table: "NutritionFacts",
                newName: "Protein");

            migrationBuilder.RenameColumn(
                name: "Fat_Amount",
                table: "NutritionFacts",
                newName: "Fat");

            migrationBuilder.RenameColumn(
                name: "Carbonhydrates_Amount",
                table: "NutritionFacts",
                newName: "Carbonhydrates");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "NutritionFacts",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AddColumn<int>(
                name: "Calories",
                table: "NutritionFacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "GroceryId",
                table: "Ingredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ingredients",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Groceries_GroceryId",
                table: "Ingredients",
                column: "GroceryId",
                principalTable: "Groceries",
                principalColumn: "Id");
        }
    }
}
