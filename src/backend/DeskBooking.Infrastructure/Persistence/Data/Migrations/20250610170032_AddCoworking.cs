using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DeskBooking.Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCoworking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.AddColumn<int>(
                name: "CoworkingId",
                table: "Workspaces",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Coworkings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coworkings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkspacePhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkspaceTypeId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkspacePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkspacePhotos_WorkspaceTypes_WorkspaceTypeId",
                        column: x => x.WorkspaceTypeId,
                        principalTable: "WorkspaceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoworkingPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CoworkingId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoworkingPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoworkingPhotos_Coworkings_CoworkingId",
                        column: x => x.CoworkingId,
                        principalTable: "Coworkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workspaces_CoworkingId",
                table: "Workspaces",
                column: "CoworkingId");

            migrationBuilder.CreateIndex(
                name: "IX_CoworkingPhotos_CoworkingId",
                table: "CoworkingPhotos",
                column: "CoworkingId");

            migrationBuilder.CreateIndex(
                name: "IX_Coworkings_Name",
                table: "Coworkings",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkspacePhotos_WorkspaceTypeId",
                table: "WorkspacePhotos",
                column: "WorkspaceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workspaces_Coworkings_CoworkingId",
                table: "Workspaces",
                column: "CoworkingId",
                principalTable: "Coworkings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workspaces_Coworkings_CoworkingId",
                table: "Workspaces");

            migrationBuilder.DropTable(
                name: "CoworkingPhotos");

            migrationBuilder.DropTable(
                name: "WorkspacePhotos");

            migrationBuilder.DropTable(
                name: "Coworkings");

            migrationBuilder.DropIndex(
                name: "IX_Workspaces_CoworkingId",
                table: "Workspaces");

            migrationBuilder.DropColumn(
                name: "CoworkingId",
                table: "Workspaces");

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkspaceTypeId = table.Column<int>(type: "integer", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_WorkspaceTypes_WorkspaceTypeId",
                        column: x => x.WorkspaceTypeId,
                        principalTable: "WorkspaceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_WorkspaceTypeId",
                table: "Photos",
                column: "WorkspaceTypeId");
        }
    }
}
