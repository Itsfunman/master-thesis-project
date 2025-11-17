using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace master_backend.Migrations
{
    /// <inheritdoc />
    public partial class blockAndProb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlockKeywords",
                columns: table => new
                {
                    blockKeywordId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    keyword = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockKeywords", x => x.blockKeywordId);
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    blockId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    blockTitle = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    blockDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    blockHTML = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.blockId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCategoryActions",
                columns: table => new
                {
                    businessCategoryActionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    businessCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    totalActions = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCategoryActions", x => x.businessCategoryActionId);
                    table.ForeignKey(
                        name: "FK_BusinessCategoryActions_Businesses_businessCategoryId",
                        column: x => x.businessCategoryId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyActions",
                columns: table => new
                {
                    companyActionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    companyId = table.Column<long>(type: "bigint", nullable: false),
                    totalActions = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyActions", x => x.companyActionId);
                    table.ForeignKey(
                        name: "FK_CompanyActions_Companies_companyId",
                        column: x => x.companyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentCategoryActions",
                columns: table => new
                {
                    departmentCategoryActionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    departmentCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    totalActions = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentCategoryActions", x => x.departmentCategoryActionId);
                    table.ForeignKey(
                        name: "FK_DepartmentCategoryActions_Departments_departmentCategoryId",
                        column: x => x.departmentCategoryId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserActions",
                columns: table => new
                {
                    userActionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    totalActions = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActions", x => x.userActionId);
                    table.ForeignKey(
                        name: "FK_UserActions_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlockContextWeights",
                columns: table => new
                {
                    blockContextWeightId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    baseBlockId = table.Column<long>(type: "bigint", nullable: false),
                    connectedBlockId = table.Column<long>(type: "bigint", nullable: false),
                    timesConnected = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockContextWeights", x => x.blockContextWeightId);
                    table.ForeignKey(
                        name: "FK_BlockContextWeights_Blocks_baseBlockId",
                        column: x => x.baseBlockId,
                        principalTable: "Blocks",
                        principalColumn: "blockId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockContextWeights_Blocks_connectedBlockId",
                        column: x => x.connectedBlockId,
                        principalTable: "Blocks",
                        principalColumn: "blockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlockKeywordLinks",
                columns: table => new
                {
                    blockKeywordLinkId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    blockId = table.Column<long>(type: "bigint", nullable: false),
                    blockKeywordId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockKeywordLinks", x => x.blockKeywordLinkId);
                    table.ForeignKey(
                        name: "FK_BlockKeywordLinks_BlockKeywords_blockKeywordId",
                        column: x => x.blockKeywordId,
                        principalTable: "BlockKeywords",
                        principalColumn: "blockKeywordId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockKeywordLinks_Blocks_blockId",
                        column: x => x.blockId,
                        principalTable: "Blocks",
                        principalColumn: "blockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCategoryProbabilities",
                columns: table => new
                {
                    businessCategoryProbabilityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    businessCategoryActionId = table.Column<long>(type: "bigint", nullable: false),
                    blockId = table.Column<long>(type: "bigint", nullable: false),
                    timesUsed = table.Column<int>(type: "integer", nullable: false),
                    lastUsed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCategoryProbabilities", x => x.businessCategoryProbabilityId);
                    table.ForeignKey(
                        name: "FK_BusinessCategoryProbabilities_Blocks_blockId",
                        column: x => x.blockId,
                        principalTable: "Blocks",
                        principalColumn: "blockId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessCategoryProbabilities_BusinessCategoryActions_busin~",
                        column: x => x.businessCategoryActionId,
                        principalTable: "BusinessCategoryActions",
                        principalColumn: "businessCategoryActionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProbabilities",
                columns: table => new
                {
                    companyProbabilityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    companyActionId = table.Column<long>(type: "bigint", nullable: false),
                    blockId = table.Column<long>(type: "bigint", nullable: false),
                    timesUsed = table.Column<int>(type: "integer", nullable: false),
                    lastUsed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProbabilities", x => x.companyProbabilityId);
                    table.ForeignKey(
                        name: "FK_CompanyProbabilities_Blocks_blockId",
                        column: x => x.blockId,
                        principalTable: "Blocks",
                        principalColumn: "blockId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyProbabilities_CompanyActions_companyActionId",
                        column: x => x.companyActionId,
                        principalTable: "CompanyActions",
                        principalColumn: "companyActionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentCategoryProbabilities",
                columns: table => new
                {
                    departmentCategoryProbabilityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    departmentCategoryActionId = table.Column<long>(type: "bigint", nullable: false),
                    blockId = table.Column<long>(type: "bigint", nullable: false),
                    timesUsed = table.Column<int>(type: "integer", nullable: false),
                    lastUsed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentCategoryProbabilities", x => x.departmentCategoryProbabilityId);
                    table.ForeignKey(
                        name: "FK_DepartmentCategoryProbabilities_Blocks_blockId",
                        column: x => x.blockId,
                        principalTable: "Blocks",
                        principalColumn: "blockId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentCategoryProbabilities_DepartmentCategoryActions_d~",
                        column: x => x.departmentCategoryActionId,
                        principalTable: "DepartmentCategoryActions",
                        principalColumn: "departmentCategoryActionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProbabilities",
                columns: table => new
                {
                    userProbabilityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userActionId = table.Column<long>(type: "bigint", nullable: false),
                    blockId = table.Column<long>(type: "bigint", nullable: false),
                    timesUsed = table.Column<int>(type: "integer", nullable: false),
                    lastUsed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProbabilities", x => x.userProbabilityId);
                    table.ForeignKey(
                        name: "FK_UserProbabilities_Blocks_blockId",
                        column: x => x.blockId,
                        principalTable: "Blocks",
                        principalColumn: "blockId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProbabilities_UserActions_userActionId",
                        column: x => x.userActionId,
                        principalTable: "UserActions",
                        principalColumn: "userActionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlockProbabilityHistories",
                columns: table => new
                {
                    blockProbabilityHistoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    blockId = table.Column<long>(type: "bigint", nullable: false),
                    userProbabilityId = table.Column<long>(type: "bigint", nullable: false),
                    departmentCategoryProbabilityId = table.Column<long>(type: "bigint", nullable: false),
                    companyProbabilityId = table.Column<long>(type: "bigint", nullable: false),
                    businessCategoryProbabilityId = table.Column<long>(type: "bigint", nullable: false),
                    probability = table.Column<float>(type: "real", nullable: false),
                    lastUsed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockProbabilityHistories", x => x.blockProbabilityHistoryId);
                    table.ForeignKey(
                        name: "FK_BlockProbabilityHistories_Blocks_blockId",
                        column: x => x.blockId,
                        principalTable: "Blocks",
                        principalColumn: "blockId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockProbabilityHistories_BusinessCategoryProbabilities_bus~",
                        column: x => x.businessCategoryProbabilityId,
                        principalTable: "BusinessCategoryProbabilities",
                        principalColumn: "businessCategoryProbabilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockProbabilityHistories_CompanyProbabilities_companyProba~",
                        column: x => x.companyProbabilityId,
                        principalTable: "CompanyProbabilities",
                        principalColumn: "companyProbabilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockProbabilityHistories_DepartmentCategoryProbabilities_d~",
                        column: x => x.departmentCategoryProbabilityId,
                        principalTable: "DepartmentCategoryProbabilities",
                        principalColumn: "departmentCategoryProbabilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockProbabilityHistories_UserProbabilities_userProbability~",
                        column: x => x.userProbabilityId,
                        principalTable: "UserProbabilities",
                        principalColumn: "userProbabilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlockContextWeights_baseBlockId",
                table: "BlockContextWeights",
                column: "baseBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockContextWeights_connectedBlockId",
                table: "BlockContextWeights",
                column: "connectedBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockKeywordLinks_blockId",
                table: "BlockKeywordLinks",
                column: "blockId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockKeywordLinks_blockKeywordId",
                table: "BlockKeywordLinks",
                column: "blockKeywordId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockProbabilityHistories_blockId",
                table: "BlockProbabilityHistories",
                column: "blockId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockProbabilityHistories_businessCategoryProbabilityId",
                table: "BlockProbabilityHistories",
                column: "businessCategoryProbabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockProbabilityHistories_companyProbabilityId",
                table: "BlockProbabilityHistories",
                column: "companyProbabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockProbabilityHistories_departmentCategoryProbabilityId",
                table: "BlockProbabilityHistories",
                column: "departmentCategoryProbabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockProbabilityHistories_userProbabilityId",
                table: "BlockProbabilityHistories",
                column: "userProbabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCategoryActions_businessCategoryId",
                table: "BusinessCategoryActions",
                column: "businessCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCategoryProbabilities_blockId",
                table: "BusinessCategoryProbabilities",
                column: "blockId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCategoryProbabilities_businessCategoryActionId",
                table: "BusinessCategoryProbabilities",
                column: "businessCategoryActionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyActions_companyId",
                table: "CompanyActions",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProbabilities_blockId",
                table: "CompanyProbabilities",
                column: "blockId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProbabilities_companyActionId",
                table: "CompanyProbabilities",
                column: "companyActionId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCategoryActions_departmentCategoryId",
                table: "DepartmentCategoryActions",
                column: "departmentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCategoryProbabilities_blockId",
                table: "DepartmentCategoryProbabilities",
                column: "blockId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCategoryProbabilities_departmentCategoryActionId",
                table: "DepartmentCategoryProbabilities",
                column: "departmentCategoryActionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActions_userId",
                table: "UserActions",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProbabilities_blockId",
                table: "UserProbabilities",
                column: "blockId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProbabilities_userActionId",
                table: "UserProbabilities",
                column: "userActionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockContextWeights");

            migrationBuilder.DropTable(
                name: "BlockKeywordLinks");

            migrationBuilder.DropTable(
                name: "BlockProbabilityHistories");

            migrationBuilder.DropTable(
                name: "BlockKeywords");

            migrationBuilder.DropTable(
                name: "BusinessCategoryProbabilities");

            migrationBuilder.DropTable(
                name: "CompanyProbabilities");

            migrationBuilder.DropTable(
                name: "DepartmentCategoryProbabilities");

            migrationBuilder.DropTable(
                name: "UserProbabilities");

            migrationBuilder.DropTable(
                name: "BusinessCategoryActions");

            migrationBuilder.DropTable(
                name: "CompanyActions");

            migrationBuilder.DropTable(
                name: "DepartmentCategoryActions");

            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "UserActions");
        }
    }
}
