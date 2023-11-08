using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_WebApplication_Admin.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.CategoryID);
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
                });

            migrationBuilder.CreateTable(
                name: "trainings",
                columns: table => new
                {
                    tId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tCategory = table.Column<int>(type: "int", nullable: false),
                    tDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    TrainingCategoryCategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainings", x => x.tId);
                    table.ForeignKey(
                        name: "FK_trainings_category_TrainingCategoryCategoryID",
                        column: x => x.TrainingCategoryCategoryID,
                        principalTable: "category",
                        principalColumn: "CategoryID");
                });

            migrationBuilder.CreateTable(
                name: "AppUserTraining",
                columns: table => new
                {
                    TrainingUsersUserId = table.Column<int>(type: "int", nullable: false),
                    UserTrainingstId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTraining", x => new { x.TrainingUsersUserId, x.UserTrainingstId });
                    table.ForeignKey(
                        name: "FK_AppUserTraining_trainings_UserTrainingstId",
                        column: x => x.UserTrainingstId,
                        principalTable: "trainings",
                        principalColumn: "tId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserTraining_Users_TrainingUsersUserId",
                        column: x => x.TrainingUsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_AppUserTraining_UserTrainingstId",
                table: "AppUserTraining",
                column: "UserTrainingstId");

            migrationBuilder.CreateIndex(
                name: "IX_trainingGalleries_trainingID",
                table: "trainingGalleries",
                column: "trainingID");

            migrationBuilder.CreateIndex(
                name: "IX_trainings_TrainingCategoryCategoryID",
                table: "trainings",
                column: "TrainingCategoryCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserTraining");

            migrationBuilder.DropTable(
                name: "trainingGalleries");

            migrationBuilder.DropTable(
                name: "UserTrainings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "trainings");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
