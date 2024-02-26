using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSupplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                schema: "chc",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Accounts",
                schema: "chc",
                newName: "account",
                newSchema: "chc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_account",
                schema: "chc",
                table: "account",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "supplier",
                schema: "chc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    founded_year = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "supplier",
                schema: "chc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_account",
                schema: "chc",
                table: "account");

            migrationBuilder.RenameTable(
                name: "account",
                schema: "chc",
                newName: "Accounts",
                newSchema: "chc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                schema: "chc",
                table: "Accounts",
                column: "Id");
        }
    }
}
