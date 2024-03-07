using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationInteriorMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "interior_detail_material",
                schema: "chc");

            migrationBuilder.DropTable(
                name: "InteriorDetailMaterial",
                schema: "chc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_interior_detail",
                schema: "chc",
                table: "interior_detail");

            migrationBuilder.DropIndex(
                name: "IX_interior_detail_interior_id",
                schema: "chc",
                table: "interior_detail");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "chc",
                table: "interior_detail");

            migrationBuilder.DropColumn(
                name: "created_by",
                schema: "chc",
                table: "interior_detail");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                schema: "chc",
                table: "interior_detail");

            migrationBuilder.DropColumn(
                name: "total_price",
                schema: "chc",
                table: "interior_detail");

            migrationBuilder.DropColumn(
                name: "updated_at",
                schema: "chc",
                table: "interior_detail");

            migrationBuilder.DropColumn(
                name: "updated_by",
                schema: "chc",
                table: "interior_detail");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "chc",
                table: "interior_detail",
                newName: "material_id");

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                schema: "chc",
                table: "interior_detail",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "total_price",
                schema: "chc",
                table: "interior",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_interior_detail",
                schema: "chc",
                table: "interior_detail",
                columns: new[] { "interior_id", "material_id" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interior_detail_material_material_id",
                schema: "chc",
                table: "interior_detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_interior_detail",
                schema: "chc",
                table: "interior_detail");

            migrationBuilder.DropIndex(
                name: "IX_interior_detail_material_id",
                schema: "chc",
                table: "interior_detail");

            migrationBuilder.DropColumn(
                name: "quantity",
                schema: "chc",
                table: "interior_detail");

            migrationBuilder.DropColumn(
                name: "total_price",
                schema: "chc",
                table: "interior");

            migrationBuilder.RenameColumn(
                name: "material_id",
                schema: "chc",
                table: "interior_detail",
                newName: "id");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "chc",
                table: "interior_detail",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                schema: "chc",
                table: "interior_detail",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                schema: "chc",
                table: "interior_detail",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "total_price",
                schema: "chc",
                table: "interior_detail",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                schema: "chc",
                table: "interior_detail",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                schema: "chc",
                table: "interior_detail",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_interior_detail",
                schema: "chc",
                table: "interior_detail",
                column: "id");

            migrationBuilder.CreateTable(
                name: "interior_detail_material",
                schema: "chc",
                columns: table => new
                {
                    Material = table.Column<Guid>(type: "uuid", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uuid", nullable: false),
                    InteriorDetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interior_detail_material", x => new { x.Material, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_interior_detail_material_interior_detail_Material",
                        column: x => x.Material,
                        principalSchema: "chc",
                        principalTable: "interior_detail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_interior_detail_material_material_MaterialId",
                        column: x => x.MaterialId,
                        principalSchema: "chc",
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_interior_detail_interior_id",
                schema: "chc",
                table: "interior_detail",
                column: "interior_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_interior_detail_material_MaterialId",
                schema: "chc",
                table: "interior_detail_material",
                column: "MaterialId");
        }
    }
}
