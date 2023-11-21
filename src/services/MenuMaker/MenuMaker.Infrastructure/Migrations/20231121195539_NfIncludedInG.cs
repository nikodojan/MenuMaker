using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MenuMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NfIncludedInG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "NutritionFacts");

            migrationBuilder.AddColumn<double>(
                name: "NF_Calories",
                table: "Groceries",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NF_GrammsCarbonhydrates",
                table: "Groceries",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NF_GrammsFat",
                table: "Groceries",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NF_GrammsFiber",
                table: "Groceries",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NF_GrammsProtein",
                table: "Groceries",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NF_GrammsSugar",
                table: "Groceries",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NF_Serving_Amount",
                table: "Groceries",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "NF_Serving_Unit",
                table: "Groceries",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NF_Calories",
                table: "Groceries");

            migrationBuilder.DropColumn(
                name: "NF_GrammsCarbonhydrates",
                table: "Groceries");

            migrationBuilder.DropColumn(
                name: "NF_GrammsFat",
                table: "Groceries");

            migrationBuilder.DropColumn(
                name: "NF_GrammsFiber",
                table: "Groceries");

            migrationBuilder.DropColumn(
                name: "NF_GrammsProtein",
                table: "Groceries");

            migrationBuilder.DropColumn(
                name: "NF_GrammsSugar",
                table: "Groceries");

            migrationBuilder.DropColumn(
                name: "NF_Serving_Amount",
                table: "Groceries");

            migrationBuilder.DropColumn(
                name: "NF_Serving_Unit",
                table: "Groceries");

            //migrationBuilder.CreateTable(
            //    name: "NutritionFacts",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        Calories = table.Column<double>(type: "double precision", nullable: false),
            //        GrammsCarbonhydrates = table.Column<double>(type: "double precision", nullable: false),
            //        GrammsFat = table.Column<double>(type: "double precision", nullable: false),
            //        GrammsFiber = table.Column<double>(type: "double precision", nullable: false),
            //        GrammsProtein = table.Column<double>(type: "double precision", nullable: false),
            //        GrammsSugar = table.Column<double>(type: "double precision", nullable: false),
            //        GroceryId = table.Column<int>(type: "integer", nullable: false),
            //        ServingSize_Amount = table.Column<double>(type: "double precision", nullable: false),
            //        ServingSize_Unit = table.Column<string>(type: "text", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_NutritionFacts", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_NutritionFacts_Groceries_GroceryId",
            //            column: x => x.GroceryId,
            //            principalTable: "Groceries",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_NutritionFacts_GroceryId",
            //    table: "NutritionFacts",
            //    column: "GroceryId",
            //    unique: true);
        }
    }
}
