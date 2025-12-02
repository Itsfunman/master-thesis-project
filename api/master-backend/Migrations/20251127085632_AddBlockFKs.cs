using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;

#nullable disable

namespace master_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddBlockFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyWeights",
                columns: table => new
                {
                    companyWeightId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    companyWeights = table.Column<NpgsqlTsVector>(type: "tsvector", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyWeights", x => x.companyWeightId);
                });

            migrationBuilder.CreateTable(
                name: "FuzzyBlocks",
                columns: table => new
                {
                    fuzzyBlockId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    blockId = table.Column<long>(type: "bigint", nullable: false),
                    businessAllignments = table.Column<NpgsqlTsVector>(type: "tsvector", nullable: false),
                    departmentAllignments = table.Column<NpgsqlTsVector>(type: "tsvector", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuzzyBlocks", x => x.fuzzyBlockId);
                    table.ForeignKey(
                        name: "FK_FuzzyBlocks_Blocks_blockId",
                        column: x => x.blockId,
                        principalTable: "Blocks",
                        principalColumn: "blockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWeights",
                columns: table => new
                {
                    userWeightId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userWeights = table.Column<NpgsqlTsVector>(type: "tsvector", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWeights", x => x.userWeightId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuzzyBlocks_blockId",
                table: "FuzzyBlocks",
                column: "blockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyWeights");

            migrationBuilder.DropTable(
                name: "FuzzyBlocks");

            migrationBuilder.DropTable(
                name: "UserWeights");
        }
    }
}
