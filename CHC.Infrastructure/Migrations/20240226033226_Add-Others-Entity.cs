using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOthersEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                schema: "chc",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transaction",
                schema: "chc",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction", x => x.id);
                    table.ForeignKey(
                        name: "FK_transaction_account_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "chc",
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "material",
                schema: "chc",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    size = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    supplier_id = table.Column<Guid>(type: "uuid", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    seller_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_material", x => x.id);
                    table.ForeignKey(
                        name: "FK_material_account_seller_id",
                        column: x => x.seller_id,
                        principalSchema: "chc",
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_material_category_category_id",
                        column: x => x.category_id,
                        principalSchema: "chc",
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_material_supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalSchema: "chc",
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transaction_detail",
                schema: "chc",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    transaction_id = table.Column<Guid>(type: "uuid", nullable: false),
                    material_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_transaction_detail_transaction_transaction_id",
                        column: x => x.transaction_id,
                        principalSchema: "chc",
                        principalTable: "transaction",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "owner_material",
                schema: "chc",
                columns: table => new
                {
                    OwnedMaterialsId = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerAccountsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner_material", x => new { x.OwnedMaterialsId, x.OwnerAccountsId });
                    table.ForeignKey(
                        name: "FK_owner_material_account_OwnerAccountsId",
                        column: x => x.OwnerAccountsId,
                        principalSchema: "chc",
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_owner_material_material_OwnedMaterialsId",
                        column: x => x.OwnedMaterialsId,
                        principalSchema: "chc",
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transactiondetail_material",
                schema: "chc",
                columns: table => new
                {
                    MaterialsId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionDetailsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactiondetail_material", x => new { x.MaterialsId, x.TransactionDetailsId });
                    table.ForeignKey(
                        name: "FK_transactiondetail_material_material_MaterialsId",
                        column: x => x.MaterialsId,
                        principalSchema: "chc",
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactiondetail_material_transaction_detail_TransactionDe~",
                        column: x => x.TransactionDetailsId,
                        principalSchema: "chc",
                        principalTable: "transaction_detail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_material_category_id",
                schema: "chc",
                table: "material",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_material_seller_id",
                schema: "chc",
                table: "material",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_material_supplier_id",
                schema: "chc",
                table: "material",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_owner_material_OwnerAccountsId",
                schema: "chc",
                table: "owner_material",
                column: "OwnerAccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_customer_id",
                schema: "chc",
                table: "transaction",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_detail_transaction_id",
                schema: "chc",
                table: "transaction_detail",
                column: "transaction_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_transactiondetail_material_TransactionDetailsId",
                schema: "chc",
                table: "transactiondetail_material",
                column: "TransactionDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "owner_material",
                schema: "chc");

            migrationBuilder.DropTable(
                name: "transactiondetail_material",
                schema: "chc");

            migrationBuilder.DropTable(
                name: "material",
                schema: "chc");

            migrationBuilder.DropTable(
                name: "transaction_detail",
                schema: "chc");

            migrationBuilder.DropTable(
                name: "category",
                schema: "chc");

            migrationBuilder.DropTable(
                name: "transaction",
                schema: "chc");
        }
    }
}
