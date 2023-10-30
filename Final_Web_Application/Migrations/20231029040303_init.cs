using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Web_Application.Migrations
{
    public partial class init : Migration
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
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
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

            migrationBuilder.CreateTable(
                name: "UserTrainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TrainingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTrainings_trainings_TrainingID",
                        column: x => x.TrainingID,
                        principalTable: "trainings",
                        principalColumn: "tId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTrainings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_trainingGalleries_trainingID",
                table: "trainingGalleries",
                column: "trainingID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainings_UserId",
                table: "UserTrainings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainings_TrainingID",
                table: "UserTrainings",
                column: "TrainingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trainingGalleries");

            migrationBuilder.DropTable(
                name: "UserTrainings");

            migrationBuilder.DropTable(
                name: "trainings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
