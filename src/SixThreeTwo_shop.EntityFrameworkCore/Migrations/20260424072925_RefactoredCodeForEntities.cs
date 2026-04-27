using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SixThreeTwo_shop.Migrations
{
    /// <inheritdoc />
    public partial class RefactoredCodeForEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "VehicleVariants",
                newName: "YearTo");

            migrationBuilder.AddColumn<short>(
                name: "YearFrom",
                table: "VehicleVariants",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "YearFrom",
                table: "CarBrands",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "YearTo",
                table: "CarBrands",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearFrom",
                table: "VehicleVariants");

            migrationBuilder.DropColumn(
                name: "YearFrom",
                table: "CarBrands");

            migrationBuilder.DropColumn(
                name: "YearTo",
                table: "CarBrands");

            migrationBuilder.RenameColumn(
                name: "YearTo",
                table: "VehicleVariants",
                newName: "Year");
        }
    }
}
