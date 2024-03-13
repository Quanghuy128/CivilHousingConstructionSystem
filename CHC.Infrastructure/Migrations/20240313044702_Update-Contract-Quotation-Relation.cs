using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContractQuotationRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contract_interior_interior_id",
                schema: "chc",
                table: "contract");

            migrationBuilder.RenameColumn(
                name: "interior_id",
                schema: "chc",
                table: "contract",
                newName: "quotation_id");

            migrationBuilder.RenameIndex(
                name: "IX_contract_interior_id",
                schema: "chc",
                table: "contract",
                newName: "IX_contract_quotation_id");

            migrationBuilder.AddForeignKey(
                name: "FK_contract_quotation_quotation_id",
                schema: "chc",
                table: "contract",
                column: "quotation_id",
                principalSchema: "chc",
                principalTable: "quotation",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contract_quotation_quotation_id",
                schema: "chc",
                table: "contract");

            migrationBuilder.RenameColumn(
                name: "quotation_id",
                schema: "chc",
                table: "contract",
                newName: "interior_id");

            migrationBuilder.RenameIndex(
                name: "IX_contract_quotation_id",
                schema: "chc",
                table: "contract",
                newName: "IX_contract_interior_id");

            migrationBuilder.AddForeignKey(
                name: "FK_contract_interior_interior_id",
                schema: "chc",
                table: "contract",
                column: "interior_id",
                principalSchema: "chc",
                principalTable: "interior",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
