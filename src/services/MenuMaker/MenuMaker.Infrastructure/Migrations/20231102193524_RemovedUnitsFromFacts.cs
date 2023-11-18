using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUnitsFromFacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories_Amount",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "Calories_Unit",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "Carbonhydrates_Amount",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "Carbonhydrates_Unit",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "Fat_Amount",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "Fat_Unit",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "Protein_Amount",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "Protein_Unit",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "Sugar_Amount",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "Sugar_Unit",
                table: "NutritionFacts");

            migrationBuilder.AddColumn<int>(
                name: "Calories",
                table: "NutritionFacts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GrammsCarbonhydrates",
                table: "NutritionFacts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GrammsFat",
                table: "NutritionFacts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GrammsProtein",
                table: "NutritionFacts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GrammsSugar",
                table: "NutritionFacts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "GrammsCarbonhydrates",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "GrammsFat",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "GrammsProtein",
                table: "NutritionFacts");

            migrationBuilder.DropColumn(
                name: "GrammsSugar",
                table: "NutritionFacts");

            migrationBuilder.AddColumn<double>(
                name: "Calories_Amount",
                table: "NutritionFacts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Calories_Unit",
                table: "NutritionFacts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Carbonhydrates_Amount",
                table: "NutritionFacts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Carbonhydrates_Unit",
                table: "NutritionFacts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Fat_Amount",
                table: "NutritionFacts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Fat_Unit",
                table: "NutritionFacts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Protein_Amount",
                table: "NutritionFacts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Protein_Unit",
                table: "NutritionFacts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Sugar_Amount",
                table: "NutritionFacts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Sugar_Unit",
                table: "NutritionFacts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
