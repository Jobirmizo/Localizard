using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Localizard.Migrations
{
    /// <inheritdoc />
    public partial class TranslationsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Translation",
                table: "ProjectDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "ProjectDetails",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "TranslationId1",
                table: "ProjectDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Translation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    ProjectDetailId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translation_ProjectDetails_ProjectDetailId",
                        column: x => x.ProjectDetailId,
                        principalTable: "ProjectDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDetails_TranslationId1",
                table: "ProjectDetails",
                column: "TranslationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_ProjectDetailId",
                table: "Translation",
                column: "ProjectDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDetails_Translation_TranslationId1",
                table: "ProjectDetails",
                column: "TranslationId1",
                principalTable: "Translation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDetails_Translation_TranslationId1",
                table: "ProjectDetails");

            migrationBuilder.DropTable(
                name: "Translation");

            migrationBuilder.DropIndex(
                name: "IX_ProjectDetails_TranslationId1",
                table: "ProjectDetails");

            migrationBuilder.DropColumn(
                name: "TranslationId1",
                table: "ProjectDetails");

            migrationBuilder.AlterColumn<int>(
                name: "Key",
                table: "ProjectDetails",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Translation",
                table: "ProjectDetails",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
