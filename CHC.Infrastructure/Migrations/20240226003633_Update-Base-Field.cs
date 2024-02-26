using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBaseField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "chc",
                table: "supplier",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "chc",
                table: "supplier",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "chc",
                table: "supplier",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "chc",
                table: "supplier",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                schema: "chc",
                table: "supplier",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "chc",
                table: "supplier",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "chc",
                table: "account",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                schema: "chc",
                table: "account",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "chc",
                table: "account",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "chc",
                table: "account",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                schema: "chc",
                table: "account",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "chc",
                table: "account",
                newName: "created_at");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                schema: "chc",
                table: "supplier",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                schema: "chc",
                table: "supplier",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "chc",
                table: "supplier",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "chc",
                table: "supplier",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "created_by",
                schema: "chc",
                table: "supplier",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "chc",
                table: "supplier",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "chc",
                table: "account",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                schema: "chc",
                table: "account",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                schema: "chc",
                table: "account",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "chc",
                table: "account",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "created_by",
                schema: "chc",
                table: "account",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "chc",
                table: "account",
                newName: "CreatedAt");
        }
    }
}
