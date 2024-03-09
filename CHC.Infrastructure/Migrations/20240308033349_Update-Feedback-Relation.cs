using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFeedbackRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "interior_id",
                schema: "chc",
                table: "feedback",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_feedback_interior_id",
                schema: "chc",
                table: "feedback",
                column: "interior_id");

            migrationBuilder.AddForeignKey(
                name: "FK_feedback_interior_interior_id",
                schema: "chc",
                table: "feedback",
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
                name: "FK_feedback_interior_interior_id",
                schema: "chc",
                table: "feedback");

            migrationBuilder.DropIndex(
                name: "IX_feedback_interior_id",
                schema: "chc",
                table: "feedback");

            migrationBuilder.DropColumn(
                name: "interior_id",
                schema: "chc",
                table: "feedback");
        }
    }
}
