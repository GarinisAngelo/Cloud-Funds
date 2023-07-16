using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundRaiserProject2023.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectCreators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCreators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FundingGoal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentFunding = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProjectCreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectCreators_ProjectCreatorId",
                        column: x => x.ProjectCreatorId,
                        principalTable: "ProjectCreators",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Backers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Backers_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPhotos_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectVideos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectVideos_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RewardPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RewardDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RewardPackages_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectFundings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountContributed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BackerId = table.Column<int>(type: "int", nullable: true),
                    ProjectsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFundings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectFundings_Backers_BackerId",
                        column: x => x.BackerId,
                        principalTable: "Backers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectFundings_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Backers_ProjectId",
                table: "Backers",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProjectsId",
                table: "Categories",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFundings_BackerId",
                table: "ProjectFundings",
                column: "BackerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFundings_ProjectsId",
                table: "ProjectFundings",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPhotos_ProjectsId",
                table: "ProjectPhotos",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectCreatorId",
                table: "Projects",
                column: "ProjectCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectVideos_ProjectsId",
                table: "ProjectVideos",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardPackages_ProjectsId",
                table: "RewardPackages",
                column: "ProjectsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ProjectFundings");

            migrationBuilder.DropTable(
                name: "ProjectPhotos");

            migrationBuilder.DropTable(
                name: "ProjectVideos");

            migrationBuilder.DropTable(
                name: "RewardPackages");

            migrationBuilder.DropTable(
                name: "Backers");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectCreators");
        }
    }
}
