using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCostField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "construction_cost",
                schema: "chc",
                table: "quotation",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "shipping_cost",
                schema: "chc",
                table: "quotation",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "discount",
                schema: "chc",
                table: "contract",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "construction_cost",
                schema: "chc",
                table: "quotation");

            migrationBuilder.DropColumn(
                name: "shipping_cost",
                schema: "chc",
                table: "quotation");

            migrationBuilder.DropColumn(
                name: "discount",
                schema: "chc",
                table: "contract");
        }
    }
}
