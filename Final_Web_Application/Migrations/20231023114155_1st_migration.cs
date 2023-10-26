using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Web_Application.Migrations
{
    public partial class _1st_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trainings",
                columns: table => new
                {
                    tId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainings", x => x.tId);
                });

            migrationBuilder.CreateTable(
                name: "trainingGalleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trainingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainingGalleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trainingGalleries_trainings_trainingID",
                        column: x => x.trainingID,
                        principalTable: "trainings",
                        principalColumn: "tId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trainingGalleries_trainingID",
                table: "trainingGalleries",
                column: "trainingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trainingGalleries");

            migrationBuilder.DropTable(
                name: "trainings");
        }
    }
}
