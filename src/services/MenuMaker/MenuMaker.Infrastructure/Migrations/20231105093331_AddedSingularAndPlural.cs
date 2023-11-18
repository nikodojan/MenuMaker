using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedSingularAndPlural : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Groceries",
                newName: "NameSelectable");

            migrationBuilder.AlterColumn<string>(
                name: "StandardUnit",
                table: "Groceries",
                type: "text",
                nullable: false,
                defaultValue: "g",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamePlural",
                table: "Groceries",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameSingular",
                table: "Groceries",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NamePlural",
                table: "Groceries");

            migrationBuilder.DropColumn(
                name: "NameSingular",
                table: "Groceries");

            migrationBuilder.RenameColumn(
                name: "NameSelectable",
                table: "Groceries",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "StandardUnit",
                table: "Groceries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "g");
        }
    }
}
