using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationInteriorStaff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "staff_id",
                schema: "chc",
                table: "interior",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_interior_staff_id",
                schema: "chc",
                table: "interior",
                column: "staff_id");

            migrationBuilder.AddForeignKey(
                name: "FK_interior_account_staff_id",
                schema: "chc",
                table: "interior",
                column: "staff_id",
                principalSchema: "chc",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interior_account_staff_id",
                schema: "chc",
                table: "interior");

            migrationBuilder.DropIndex(
                name: "IX_interior_staff_id",
                schema: "chc",
                table: "interior");

            migrationBuilder.DropColumn(
                name: "staff_id",
                schema: "chc",
                table: "interior");
        }
    }
}
