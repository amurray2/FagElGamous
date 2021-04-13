using Microsoft.EntityFrameworkCore.Migrations;

namespace FagElGamous.Migrations
{
    public partial class AddFieldBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FieldBooks",
                columns: table => new
                {
                    FieldBookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurialId = table.Column<int>(nullable: false),
                    FieldBookUrl = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_FieldBooks_BurialId",
                table: "FieldBooks",
                column: "BurialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldBooks");
        }
    }
}
