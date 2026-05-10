using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SixThreeTwo_shop.Migrations
{
    /// <inheritdoc />
    public partial class AddedRefactoredEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategory_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "OilSpecApprovals");

            migrationBuilder.DropTable(
                name: "OilSpecManufacturerApprovals");

            migrationBuilder.DropTable(
                name: "ProductsToCategories");

            migrationBuilder.DropTable(
                name: "ApprovalStandards");

            migrationBuilder.DropTable(
                name: "OilSpecs");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ApiStandard",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ContainerSize",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OilType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Sku",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AltText",
                table: "ProductImages");

            migrationBuilder.RenameColumn(
                name: "ViscosityGrade",
                table: "Products",
                newName: "CountryOfOrigin");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Products",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "StockQuality",
                table: "Products",
                newName: "ProductType");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Products",
                newName: "Capacity");

            migrationBuilder.RenameColumn(
                name: "IsPublished",
                table: "Products",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "S3Key",
                table: "ProductImages",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ManufacturerApprovals",
                newName: "ManufacturerName");

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Products",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ManufacturerApprovals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Additives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditiveType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Additives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Additives_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coolants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Approval = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coolants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coolants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotorOils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Viscosity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorOils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotorOils_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OilApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StandardType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilApprovals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransmissionFluids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransmissionType = table.Column<int>(type: "int", nullable: false),
                    Viscosity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransmissionFluids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransmissionFluids_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleSpecToManufacturerApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleSpecId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerApprovalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleSpecToManufacturerApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleSpecToManufacturerApprovals_ManufacturerApprovals_ManufacturerApprovalId",
                        column: x => x.ManufacturerApprovalId,
                        principalTable: "ManufacturerApprovals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleSpecToManufacturerApprovals_VehicleVariants_VehicleSpecId",
                        column: x => x.VehicleSpecId,
                        principalTable: "VehicleVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotorOilManufacturerApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotorOilId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerApprovalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorOilManufacturerApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotorOilManufacturerApprovals_ManufacturerApprovals_ManufacturerApprovalId",
                        column: x => x.ManufacturerApprovalId,
                        principalTable: "ManufacturerApprovals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotorOilManufacturerApprovals_MotorOils_MotorOilId",
                        column: x => x.MotorOilId,
                        principalTable: "MotorOils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotorsOilToOilApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotorOilId = table.Column<int>(type: "int", nullable: false),
                    OilApprovalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorsOilToOilApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotorsOilToOilApprovals_MotorOils_MotorOilId",
                        column: x => x.MotorOilId,
                        principalTable: "MotorOils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotorsOilToOilApprovals_OilApprovals_OilApprovalId",
                        column: x => x.OilApprovalId,
                        principalTable: "OilApprovals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleSpecToOilApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleSpecId = table.Column<int>(type: "int", nullable: false),
                    OilApprovalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleSpecToOilApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleSpecToOilApprovals_OilApprovals_OilApprovalId",
                        column: x => x.OilApprovalId,
                        principalTable: "OilApprovals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleSpecToOilApprovals_VehicleVariants_VehicleSpecId",
                        column: x => x.VehicleSpecId,
                        principalTable: "VehicleVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransmissionFluidManufacturerApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransmissionFluidId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerApprovalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransmissionFluidManufacturerApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransmissionFluidManufacturerApprovals_ManufacturerApprovals_ManufacturerApprovalId",
                        column: x => x.ManufacturerApprovalId,
                        principalTable: "ManufacturerApprovals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransmissionFluidManufacturerApprovals_TransmissionFluids_TransmissionFluidId",
                        column: x => x.TransmissionFluidId,
                        principalTable: "TransmissionFluids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Additives_ProductId",
                table: "Additives",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Coolants_ProductId",
                table: "Coolants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorOilManufacturerApprovals_ManufacturerApprovalId",
                table: "MotorOilManufacturerApprovals",
                column: "ManufacturerApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorOilManufacturerApprovals_MotorOilId",
                table: "MotorOilManufacturerApprovals",
                column: "MotorOilId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorOils_ProductId",
                table: "MotorOils",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorsOilToOilApprovals_MotorOilId",
                table: "MotorsOilToOilApprovals",
                column: "MotorOilId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorsOilToOilApprovals_OilApprovalId",
                table: "MotorsOilToOilApprovals",
                column: "OilApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_TransmissionFluidManufacturerApprovals_ManufacturerApprovalId",
                table: "TransmissionFluidManufacturerApprovals",
                column: "ManufacturerApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_TransmissionFluidManufacturerApprovals_TransmissionFluidId",
                table: "TransmissionFluidManufacturerApprovals",
                column: "TransmissionFluidId");

            migrationBuilder.CreateIndex(
                name: "IX_TransmissionFluids_ProductId",
                table: "TransmissionFluids",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSpecToManufacturerApprovals_ManufacturerApprovalId",
                table: "VehicleSpecToManufacturerApprovals",
                column: "ManufacturerApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSpecToManufacturerApprovals_VehicleSpecId",
                table: "VehicleSpecToManufacturerApprovals",
                column: "VehicleSpecId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSpecToOilApprovals_OilApprovalId",
                table: "VehicleSpecToOilApprovals",
                column: "OilApprovalId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSpecToOilApprovals_VehicleSpecId",
                table: "VehicleSpecToOilApprovals",
                column: "VehicleSpecId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Additives");

            migrationBuilder.DropTable(
                name: "Coolants");

            migrationBuilder.DropTable(
                name: "MotorOilManufacturerApprovals");

            migrationBuilder.DropTable(
                name: "MotorsOilToOilApprovals");

            migrationBuilder.DropTable(
                name: "TransmissionFluidManufacturerApprovals");

            migrationBuilder.DropTable(
                name: "VehicleSpecToManufacturerApprovals");

            migrationBuilder.DropTable(
                name: "VehicleSpecToOilApprovals");

            migrationBuilder.DropTable(
                name: "MotorOils");

            migrationBuilder.DropTable(
                name: "TransmissionFluids");

            migrationBuilder.DropTable(
                name: "OilApprovals");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ManufacturerApprovals");

            migrationBuilder.RenameColumn(
                name: "ProductType",
                table: "Products",
                newName: "StockQuality");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Products",
                newName: "IsPublished");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "Products",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CountryOfOrigin",
                table: "Products",
                newName: "ViscosityGrade");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Products",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "ProductImages",
                newName: "S3Key");

            migrationBuilder.RenameColumn(
                name: "ManufacturerName",
                table: "ManufacturerApprovals",
                newName: "Code");

            migrationBuilder.AddColumn<string>(
                name: "ApiStandard",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ContainerSize",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OilType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AltText",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "OilSpecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleVariantId = table.Column<int>(type: "int", nullable: false),
                    ChangeInterval = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OilCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OilType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViscosityGrade = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
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
                    ManufacturerSpecId = table.Column<int>(type: "int", nullable: false),
                    OilSpecId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ProductsToCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsToCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsToCategories_ProductCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsToCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductsToCategories_CategoryId",
                table: "ProductsToCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsToCategories_ProductId",
                table: "ProductsToCategories",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategory_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
