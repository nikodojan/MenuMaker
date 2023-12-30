using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MenuMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ParentCat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroceryCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroceryCategories_GroceryCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "GroceryCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ImgPath = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Instructions = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Portions = table.Column<int>(type: "integer", nullable: true),
                    TimeInMinutes = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groceries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameSelectable = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    NameSingular = table.Column<string>(type: "text", nullable: true),
                    NamePlural = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    StandardUnit = table.Column<string>(type: "text", nullable: false, defaultValue: "g"),
                    NF_Serving_Unit = table.Column<string>(type: "text", nullable: false, defaultValue: "g"),
                    NF_Serving_Amount = table.Column<double>(type: "double precision", nullable: false),
                    NF_Calories = table.Column<double>(type: "double precision", nullable: false),
                    NF_GrammsFat = table.Column<double>(type: "double precision", nullable: false),
                    NF_GrammsCarbonhydrates = table.Column<double>(type: "double precision", nullable: false),
                    NF_GrammsSugar = table.Column<double>(type: "double precision", nullable: false),
                    NF_GrammsProtein = table.Column<double>(type: "double precision", nullable: false),
                    NF_GrammsFiber = table.Column<double>(type: "double precision", nullable: false),
                    HasNutritionValues = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groceries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groceries_GroceryCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "GroceryCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<double>(type: "double precision", nullable: true),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    GroceryId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PartOfDish = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    RecipeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Groceries_GroceryId",
                        column: x => x.GroceryId,
                        principalTable: "Groceries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_CategoryId",
                table: "Groceries",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_NameSelectable",
                table: "Groceries",
                column: "NameSelectable",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroceryCategories_ParentCategoryId",
                table: "GroceryCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_GroceryId",
                table: "Ingredients",
                column: "GroceryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Groceries");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "GroceryCategories");
        }
    }
}
