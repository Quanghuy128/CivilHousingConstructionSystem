using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMaterialIdIn_IniteriorDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interior_detail_material_interior_detail_InteriorDetailId",
                schema: "chc",
                table: "interior_detail_material");

            migrationBuilder.DropPrimaryKey(
                name: "PK_interior_detail_material",
                schema: "chc",
                table: "interior_detail_material");

            migrationBuilder.DropColumn(
                name: "material_id",
                schema: "chc",
                table: "interior_detail");

            migrationBuilder.AddColumn<Guid>(
                name: "Material",
                schema: "chc",
                table: "interior_detail_material",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_interior_detail_material",
                schema: "chc",
                table: "interior_detail_material",
                columns: new[] { "Material", "MaterialId" });

            migrationBuilder.CreateTable(
                name: "InteriorDetailMaterial",
                schema: "chc",
                columns: table => new
                {
                    Material = table.Column<Guid>(type: "uuid", nullable: false),
                    MaterialsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteriorDetailMaterial", x => new { x.Material, x.MaterialsId });
                });

            migrationBuilder.AddForeignKey(
                name: "FK_interior_detail_material_interior_detail_Material",
                schema: "chc",
                table: "interior_detail_material",
                column: "Material",
                principalSchema: "chc",
                principalTable: "interior_detail",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interior_detail_material_interior_detail_Material",
                schema: "chc",
                table: "interior_detail_material");

            migrationBuilder.DropTable(
                name: "InteriorDetailMaterial",
                schema: "chc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_interior_detail_material",
                schema: "chc",
                table: "interior_detail_material");

            migrationBuilder.DropColumn(
                name: "Material",
                schema: "chc",
                table: "interior_detail_material");

            migrationBuilder.AddColumn<Guid>(
                name: "material_id",
                schema: "chc",
                table: "interior_detail",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_interior_detail_material",
                schema: "chc",
                table: "interior_detail_material",
                columns: new[] { "InteriorDetailId", "MaterialId" });

            migrationBuilder.AddForeignKey(
                name: "FK_interior_detail_material_interior_detail_InteriorDetailId",
                schema: "chc",
                table: "interior_detail_material",
                column: "InteriorDetailId",
                principalSchema: "chc",
                principalTable: "interior_detail",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
