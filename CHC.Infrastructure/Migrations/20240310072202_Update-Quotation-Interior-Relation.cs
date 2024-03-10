using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuotationInteriorRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "quotation_detail",
                schema: "chc");

            migrationBuilder.AddColumn<Guid>(
                name: "interior_id",
                schema: "chc",
                table: "quotation",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_quotation_interior_id",
                schema: "chc",
                table: "quotation",
                column: "interior_id");

            migrationBuilder.AddForeignKey(
                name: "FK_quotation_interior_interior_id",
                schema: "chc",
                table: "quotation",
                column: "interior_id",
                principalSchema: "chc",
                principalTable: "interior",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quotation_interior_interior_id",
                schema: "chc",
                table: "quotation");

            migrationBuilder.DropIndex(
                name: "IX_quotation_interior_id",
                schema: "chc",
                table: "quotation");

            migrationBuilder.DropColumn(
                name: "interior_id",
                schema: "chc",
                table: "quotation");

            migrationBuilder.CreateTable(
                name: "quotation_detail",
                schema: "chc",
                columns: table => new
                {
                    InteriorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuotationsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotation_detail", x => new { x.InteriorsId, x.QuotationsId });
                    table.ForeignKey(
                        name: "FK_quotation_detail_interior_InteriorsId",
                        column: x => x.InteriorsId,
                        principalSchema: "chc",
                        principalTable: "interior",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quotation_detail_quotation_QuotationsId",
                        column: x => x.QuotationsId,
                        principalSchema: "chc",
                        principalTable: "quotation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_quotation_detail_QuotationsId",
                schema: "chc",
                table: "quotation_detail",
                column: "QuotationsId");
        }
    }
}
