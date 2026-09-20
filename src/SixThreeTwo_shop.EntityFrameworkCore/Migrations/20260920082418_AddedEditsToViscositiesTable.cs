using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SixThreeTwo_shop.Migrations
{
    /// <inheritdoc />
    public partial class AddedEditsToViscositiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransmissionFluids_TransmissionOilViscosity_ViscosityId",
                table: "TransmissionFluids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransmissionOilViscosity",
                table: "TransmissionOilViscosity");

            migrationBuilder.RenameTable(
                name: "TransmissionOilViscosity",
                newName: "TransmissionOilViscosities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransmissionOilViscosities",
                table: "TransmissionOilViscosities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransmissionFluids_TransmissionOilViscosities_ViscosityId",
                table: "TransmissionFluids",
                column: "ViscosityId",
                principalTable: "TransmissionOilViscosities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransmissionFluids_TransmissionOilViscosities_ViscosityId",
                table: "TransmissionFluids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransmissionOilViscosities",
                table: "TransmissionOilViscosities");

            migrationBuilder.RenameTable(
                name: "TransmissionOilViscosities",
                newName: "TransmissionOilViscosity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransmissionOilViscosity",
                table: "TransmissionOilViscosity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransmissionFluids_TransmissionOilViscosity_ViscosityId",
                table: "TransmissionFluids",
                column: "ViscosityId",
                principalTable: "TransmissionOilViscosity",
                principalColumn: "Id");
        }
    }
}
