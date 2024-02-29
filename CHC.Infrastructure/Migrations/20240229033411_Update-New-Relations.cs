using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CHC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_material_account_seller_id",
                schema: "chc",
                table: "material");

            migrationBuilder.DropForeignKey(
                name: "FK_material_category_category_id",
                schema: "chc",
                table: "material");

            migrationBuilder.DropForeignKey(
                name: "FK_material_supplier_supplier_id",
                schema: "chc",
                table: "material");

            migrationBuilder.DropTable(
                name: "category",
                schema: "chc");

            migrationBuilder.DropTable(
                name: "owner_material",
                schema: "chc");

            migrationBuilder.DropTable(
                name: "supplier",
                schema: "chc");

            migrationBuilder.DropTable(
                name: "transactiondetail_material",
                schema: "chc");

            migrationBuilder.DropTable(
                name: "transaction_detail",
                schema: "chc");

            migrationBuilder.DropTable(
                name: "transaction",
                schema: "chc");

            migrationBuilder.DropIndex(
                name: "IX_material_category_id",
                schema: "chc",
                table: "material");

            migrationBuilder.DropIndex(
                name: "IX_material_seller_id",
                schema: "chc",
                table: "material");

            migrationBuilder.DropIndex(
                name: "IX_material_supplier_id",
                schema: "chc",
                table: "material");

            migrationBuilder.DropColumn(
                name: "category_id",
                schema: "chc",
                table: "material");

            migrationBuilder.DropColumn(
                name: "description",
                schema: "chc",
                table: "material");

            migrationBuilder.DropColumn(
                name: "owner_id",
                schema: "chc",
                table: "material");

            migrationBuilder.DropColumn(
                name: "price",
                schema: "chc",
                table: "material");

            migrationBuilder.DropColumn(
                name: "seller_id",
                schema: "chc",
                table: "material");

            migrationBuilder.DropColumn(
                name: "size",
                schema: "chc",
                table: "material");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "chc",
                table: "material");

            migrationBuilder.DropColumn(
                name: "supplier_id",
                schema: "chc",
                table: "material");

            migrationBuilder.RenameColumn(
                name: "type",
                schema: "chc",
                table: "material",
                newName: "image_url");

            migrationBuilder.AddColumn<string>(
                name: "image_url",
                schema: "chc",
                table: "account",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "contract",
                schema: "chc",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    agreement_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contract", x => x.id);
                    table.ForeignKey(
                        name: "FK_contract_account_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "chc",
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feedback",
                schema: "chc",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_account_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "chc",
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "interior",
                schema: "chc",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interior", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quotation",
                schema: "chc",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    request_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    estimate_price = table.Column<double>(type: "double precision", nullable: false),
                    content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotation", x => x.id);
                    table.ForeignKey(
                        name: "FK_quotation_account_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "chc",
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "interior_detail",
                schema: "chc",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    total_price = table.Column<double>(type: "double precision", nullable: false),
                    interior_id = table.Column<Guid>(type: "uuid", nullable: false),
                    material_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interior_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_interior_detail_interior_interior_id",
                        column: x => x.interior_id,
                        principalSchema: "chc",
                        principalTable: "interior",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_interior_detail_material_material_id",
                        column: x => x.material_id,
                        principalSchema: "chc",
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quotation_detail",
                schema: "chc",
                columns: table => new
                {
                    InteriorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuotationsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotation_detail", x => new { x.InteriorsId, x.QuotationsId });
                    table.ForeignKey(
                        name: "FK_quotation_detail_interior_InteriorsId",
                        column: x => x.InteriorsId,
                        principalSchema: "chc",
                        principalTable: "interior",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quotation_detail_quotation_QuotationsId",
                        column: x => x.QuotationsId,
                        principalSchema: "chc",
                        principalTable: "quotation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contract_customer_id",
                schema: "chc",
                table: "contract",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_customer_id",
                schema: "chc",
                table: "feedback",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_interior_detail_interior_id",
                schema: "chc",
                table: "interior_detail",
                column: "interior_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_interior_detail_material_id",
                schema: "chc",
                table: "interior_detail",
                column: "material_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotation_customer_id",
                schema: "chc",
                table: "quotation",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_quotation_detail_QuotationsId",
                schema: "chc",
                table: "quotation_detail",
                column: "QuotationsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contract",
                schema: "chc");

            migrationBuilder.DropTable(
                name: "feedback",
                schema: "chc");

            migrationBuilder.DropTable(
                name: "interior_detail",
                schema: "chc");

            migrationBuilder.DropTable(
                name: "quotation_detail",
                schema: "chc");

            migrationBuilder.DropTable(
                name: "interior",
                schema: "chc");

            migrationBuilder.DropTable(
                name: "quotation",
                schema: "chc");

            migrationBuilder.DropColumn(
                name: "image_url",
                schema: "chc",
                table: "account");

            migrationBuilder.RenameColumn(
                name: "image_url",
                schema: "chc",
                table: "material",
                newName: "type");

            migrationBuilder.AddColumn<Guid>(
                name: "category_id",
                schema: "chc",
                table: "material",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "chc",
                table: "material",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "owner_id",
                schema: "chc",
                table: "material",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "price",
                schema: "chc",
                table: "material",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "seller_id",
                schema: "chc",
                table: "material",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "size",
                schema: "chc",
                table: "material",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "chc",
                table: "material",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "supplier_id",
                schema: "chc",
                table: "material",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "category",
                schema: "chc",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
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
                name: "supplier",
                schema: "chc",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    founded_year = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transaction",
                schema: "chc",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: true)
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
                name: "transaction_detail",
                schema: "chc",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    transaction_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    material_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_material_account_seller_id",
                schema: "chc",
                table: "material",
                column: "seller_id",
                principalSchema: "chc",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_material_category_category_id",
                schema: "chc",
                table: "material",
                column: "category_id",
                principalSchema: "chc",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_material_supplier_supplier_id",
                schema: "chc",
                table: "material",
                column: "supplier_id",
                principalSchema: "chc",
                principalTable: "supplier",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
