using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SixThreeTwo_shop.Migrations
{
    /// <inheritdoc />
    public partial class AddedIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransmissionFluids_ProductId",
                table: "TransmissionFluids");

            migrationBuilder.DropIndex(
                name: "IX_MotorOils_ProductId",
                table: "MotorOils");

            migrationBuilder.DropIndex(
                name: "IX_Coolants_ProductId",
                table: "Coolants");

            migrationBuilder.DropIndex(
                name: "IX_Additives_ProductId",
                table: "Additives");

            migrationBuilder.CreateIndex(
                name: "IX_TransmissionFluids_ProductId",
                table: "TransmissionFluids",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MotorOils_ProductId",
                table: "MotorOils",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coolants_ProductId",
                table: "Coolants",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Additives_ProductId",
                table: "Additives",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransmissionFluids_ProductId",
                table: "TransmissionFluids");

            migrationBuilder.DropIndex(
                name: "IX_MotorOils_ProductId",
                table: "MotorOils");

            migrationBuilder.DropIndex(
                name: "IX_Coolants_ProductId",
                table: "Coolants");

            migrationBuilder.DropIndex(
                name: "IX_Additives_ProductId",
                table: "Additives");

            migrationBuilder.CreateIndex(
                name: "IX_TransmissionFluids_ProductId",
                table: "TransmissionFluids",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorOils_ProductId",
                table: "MotorOils",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Coolants_ProductId",
                table: "Coolants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Additives_ProductId",
                table: "Additives",
                column: "ProductId");
        }
    }
}
