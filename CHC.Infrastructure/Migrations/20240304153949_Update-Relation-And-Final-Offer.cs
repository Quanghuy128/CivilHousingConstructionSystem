using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationAndFinalOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interior_detail_material_material_id",
                schema: "chc",
                table: "interior_detail");

            migrationBuilder.DropIndex(
                name: "IX_interior_detail_material_id",
                schema: "chc",
                table: "interior_detail");

            migrationBuilder.AddColumn<double>(
                name: "final_offer",
                schema: "chc",
                table: "contract",
                type: "double precision",
                maxLength: 500,
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "interior_detail_material",
                schema: "chc",
                columns: table => new
                {
                    InteriorDetailsId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaterialsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interior_detail_material", x => new { x.InteriorDetailsId, x.MaterialsId });
                    table.ForeignKey(
                        name: "FK_interior_detail_material_interior_detail_InteriorDetailsId",
                        column: x => x.InteriorDetailsId,
                        principalSchema: "chc",
                        principalTable: "interior_detail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_interior_detail_material_material_MaterialsId",
                        column: x => x.MaterialsId,
                        principalSchema: "chc",
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_interior_detail_material_MaterialsId",
                schema: "chc",
                table: "interior_detail_material",
                column: "MaterialsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "interior_detail_material",
                schema: "chc");

            migrationBuilder.DropColumn(
                name: "final_offer",
                schema: "chc",
                table: "contract");

            migrationBuilder.CreateIndex(
                name: "IX_interior_detail_material_id",
                schema: "chc",
                table: "interior_detail",
                column: "material_id");

            migrationBuilder.AddForeignKey(
                name: "FK_interior_detail_material_material_id",
                schema: "chc",
                table: "interior_detail",
                column: "material_id",
                principalSchema: "chc",
                principalTable: "material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
