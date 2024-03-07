using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMaterialInteriorRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interior_detail_material_interior_detail_InteriorDetailsId",
                schema: "chc",
                table: "interior_detail_material");

            migrationBuilder.DropForeignKey(
                name: "FK_interior_detail_material_material_MaterialsId",
                schema: "chc",
                table: "interior_detail_material");

            migrationBuilder.RenameColumn(
                name: "MaterialsId",
                schema: "chc",
                table: "interior_detail_material",
                newName: "MaterialId");

            migrationBuilder.RenameColumn(
                name: "InteriorDetailsId",
                schema: "chc",
                table: "interior_detail_material",
                newName: "InteriorDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_interior_detail_material_MaterialsId",
                schema: "chc",
                table: "interior_detail_material",
                newName: "IX_interior_detail_material_MaterialId");

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                schema: "chc",
                table: "interior_detail_material",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_interior_detail_material_interior_detail_InteriorDetailId",
                schema: "chc",
                table: "interior_detail_material",
                column: "InteriorDetailId",
                principalSchema: "chc",
                principalTable: "interior_detail",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_interior_detail_material_material_MaterialId",
                schema: "chc",
                table: "interior_detail_material",
                column: "MaterialId",
                principalSchema: "chc",
                principalTable: "material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interior_detail_material_interior_detail_InteriorDetailId",
                schema: "chc",
                table: "interior_detail_material");

            migrationBuilder.DropForeignKey(
                name: "FK_interior_detail_material_material_MaterialId",
                schema: "chc",
                table: "interior_detail_material");

            migrationBuilder.DropColumn(
                name: "quantity",
                schema: "chc",
                table: "interior_detail_material");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                schema: "chc",
                table: "interior_detail_material",
                newName: "MaterialsId");

            migrationBuilder.RenameColumn(
                name: "InteriorDetailId",
                schema: "chc",
                table: "interior_detail_material",
                newName: "InteriorDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_interior_detail_material_MaterialId",
                schema: "chc",
                table: "interior_detail_material",
                newName: "IX_interior_detail_material_MaterialsId");

            migrationBuilder.AddForeignKey(
                name: "FK_interior_detail_material_interior_detail_InteriorDetailsId",
                schema: "chc",
                table: "interior_detail_material",
                column: "InteriorDetailsId",
                principalSchema: "chc",
                principalTable: "interior_detail",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_interior_detail_material_material_MaterialsId",
                schema: "chc",
                table: "interior_detail_material",
                column: "MaterialsId",
                principalSchema: "chc",
                principalTable: "material",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
