using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContractRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "interior_id",
                schema: "chc",
                table: "contract",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "staff_id",
                schema: "chc",
                table: "contract",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_contract_interior_id",
                schema: "chc",
                table: "contract",
                column: "interior_id");

            migrationBuilder.CreateIndex(
                name: "IX_contract_staff_id",
                schema: "chc",
                table: "contract",
                column: "staff_id");

            migrationBuilder.AddForeignKey(
                name: "FK_contract_account_staff_id",
                schema: "chc",
                table: "contract",
                column: "staff_id",
                principalSchema: "chc",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contract_account_staff_id",
                schema: "chc",
                table: "contract");

            migrationBuilder.DropForeignKey(
                name: "FK_contract_interior_interior_id",
                schema: "chc",
                table: "contract");

            migrationBuilder.DropIndex(
                name: "IX_contract_interior_id",
                schema: "chc",
                table: "contract");

            migrationBuilder.DropIndex(
                name: "IX_contract_staff_id",
                schema: "chc",
                table: "contract");

            migrationBuilder.DropColumn(
                name: "interior_id",
                schema: "chc",
                table: "contract");

            migrationBuilder.DropColumn(
                name: "staff_id",
                schema: "chc",
                table: "contract");
        }
    }
}
