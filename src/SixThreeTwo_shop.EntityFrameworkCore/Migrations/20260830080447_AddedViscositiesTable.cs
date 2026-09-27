using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SixThreeTwo_shop.Migrations
{
    /// <inheritdoc />
    public partial class AddedViscositiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Viscosity",
                table: "TransmissionFluids");

            migrationBuilder.DropColumn(
                name: "Viscosity",
                table: "MotorOils");

            migrationBuilder.AddColumn<int>(
                name: "ViscosityId",
                table: "TransmissionFluids",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ViscosityId",
                table: "MotorOils",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EngineOilViscosities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineOilViscosities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TransmissionOilViscosity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransmissionOilViscosity", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TransmissionFluids_ViscosityId",
                table: "TransmissionFluids",
                column: "ViscosityId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorOils_ViscosityId",
                table: "MotorOils",
                column: "ViscosityId");

            migrationBuilder.AddForeignKey(
                name: "FK_MotorOils_EngineOilViscosities_ViscosityId",
                table: "MotorOils",
                column: "ViscosityId",
                principalTable: "EngineOilViscosities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransmissionFluids_TransmissionOilViscosity_ViscosityId",
                table: "TransmissionFluids",
                column: "ViscosityId",
                principalTable: "TransmissionOilViscosity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotorOils_EngineOilViscosities_ViscosityId",
                table: "MotorOils");

            migrationBuilder.DropForeignKey(
                name: "FK_TransmissionFluids_TransmissionOilViscosity_ViscosityId",
                table: "TransmissionFluids");

            migrationBuilder.DropTable(
                name: "EngineOilViscosities");

            migrationBuilder.DropTable(
                name: "TransmissionOilViscosity");

            migrationBuilder.DropIndex(
                name: "IX_TransmissionFluids_ViscosityId",
                table: "TransmissionFluids");

            migrationBuilder.DropIndex(
                name: "IX_MotorOils_ViscosityId",
                table: "MotorOils");

            migrationBuilder.DropColumn(
                name: "ViscosityId",
                table: "TransmissionFluids");

            migrationBuilder.DropColumn(
                name: "ViscosityId",
                table: "MotorOils");

            migrationBuilder.AddColumn<string>(
                name: "Viscosity",
                table: "TransmissionFluids",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Viscosity",
                table: "MotorOils",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
