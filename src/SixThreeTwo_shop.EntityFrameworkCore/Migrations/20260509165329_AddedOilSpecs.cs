using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SixThreeTwo_shop.Migrations
{
    /// <inheritdoc />
    public partial class AddedOilSpecs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprovalStandards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalStandards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturerApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturerApprovals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OilSpecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViscosityGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OilType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OilCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChangeInterval = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleVariantId = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilSpecs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OilSpecs_VehicleVariants_VehicleVariantId",
                        column: x => x.VehicleVariantId,
                        principalTable: "VehicleVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OilSpecApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OilSpecId = table.Column<int>(type: "int", nullable: false),
                    StandardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilSpecApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OilSpecApprovals_ApprovalStandards_StandardId",
                        column: x => x.StandardId,
                        principalTable: "ApprovalStandards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OilSpecApprovals_OilSpecs_OilSpecId",
                        column: x => x.OilSpecId,
                        principalTable: "OilSpecs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OilSpecManufacturerApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OilSpecId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerSpecId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilSpecManufacturerApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OilSpecManufacturerApprovals_ManufacturerApprovals_ManufacturerSpecId",
                        column: x => x.ManufacturerSpecId,
                        principalTable: "ManufacturerApprovals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OilSpecManufacturerApprovals_OilSpecs_OilSpecId",
                        column: x => x.OilSpecId,
                        principalTable: "OilSpecs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OilSpecApprovals_OilSpecId",
                table: "OilSpecApprovals",
                column: "OilSpecId");

            migrationBuilder.CreateIndex(
                name: "IX_OilSpecApprovals_StandardId",
                table: "OilSpecApprovals",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_OilSpecManufacturerApprovals_ManufacturerSpecId",
                table: "OilSpecManufacturerApprovals",
                column: "ManufacturerSpecId");

            migrationBuilder.CreateIndex(
                name: "IX_OilSpecManufacturerApprovals_OilSpecId",
                table: "OilSpecManufacturerApprovals",
                column: "OilSpecId");

            migrationBuilder.CreateIndex(
                name: "IX_OilSpecs_VehicleVariantId",
                table: "OilSpecs",
                column: "VehicleVariantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OilSpecApprovals");

            migrationBuilder.DropTable(
                name: "OilSpecManufacturerApprovals");

            migrationBuilder.DropTable(
                name: "ApprovalStandards");

            migrationBuilder.DropTable(
                name: "ManufacturerApprovals");

            migrationBuilder.DropTable(
                name: "OilSpecs");
        }
    }
}
