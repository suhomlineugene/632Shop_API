using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SixThreeTwo_shop.Migrations
{
    /// <inheritdoc />
    public partial class DeleteEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCompabilities");

            migrationBuilder.DropTable(
                name: "VehicleCompabilities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCompabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    FilterRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OilCapacityMl = table.Column<int>(type: "int", nullable: false),
                    OilSpec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCompabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCompabilities_VehicleVariants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "VehicleVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleCompabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Engine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearFrom = table.Column<int>(type: "int", nullable: false),
                    YearTo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCompabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleCompabilities_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCompabilities_VariantId",
                table: "ProductCompabilities",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleCompabilities_ProductId",
                table: "VehicleCompabilities",
                column: "ProductId");
        }
    }
}
