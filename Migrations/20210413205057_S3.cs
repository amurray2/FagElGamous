using Microsoft.EntityFrameworkCore.Migrations;

namespace FagElGamous.Migrations
{
    public partial class S3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldBooks");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurialId = table.Column<int>(nullable: false),
                    FileUrl = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_Files_Burial_BurialId",
                        column: x => x.BurialId,
                        principalTable: "Burial",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_BurialId",
                table: "Files",
                column: "BurialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.CreateTable(
                name: "FieldBooks",
                columns: table => new
                {
                    FieldBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurialId = table.Column<int>(type: "int", nullable: false),
                    FieldBookUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldBooks", x => x.FieldBookId);
                    table.ForeignKey(
                        name: "FK_FieldBooks_Burial_BurialId",
                        column: x => x.BurialId,
                        principalTable: "Burial",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurialId = table.Column<int>(type: "int", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photos_Burial_BurialId",
                        column: x => x.BurialId,
                        principalTable: "Burial",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldBooks_BurialId",
                table: "FieldBooks",
                column: "BurialId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_BurialId",
                table: "Photos",
                column: "BurialId");
        }
    }
}
