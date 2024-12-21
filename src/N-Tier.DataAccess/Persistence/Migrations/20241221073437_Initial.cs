using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace N_Tier.DataAccess.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LearnTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearnTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surahs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AyahSize = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surahs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TelegramId = table.Column<long>(type: "bigint", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LearnTypeId = table.Column<int>(type: "integer", nullable: false),
                    SurahId = table.Column<int>(type: "integer", nullable: true),
                    From = table.Column<int>(type: "integer", nullable: false),
                    To = table.Column<int>(type: "integer", nullable: false),
                    DateLearned = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LearningTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    RepetitionCount = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issues_LearnTypes_LearnTypeId",
                        column: x => x.LearnTypeId,
                        principalTable: "LearnTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issues_Surahs_SurahId",
                        column: x => x.SurahId,
                        principalTable: "Surahs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Issues_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepetitionPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IssuesId = table.Column<int>(type: "integer", nullable: false),
                    RepetitionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RepetitionTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    RepetitionCount = table.Column<long>(type: "bigint", nullable: false),
                    RepetitionDay = table.Column<int>(type: "integer", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    RemindMe = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    IssueId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepetitionPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepetitionPlans_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepetitionPlans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RepetitionPlanId = table.Column<int>(type: "integer", nullable: false),
                    NotificationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    NotificationTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    IsSend = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_RepetitionPlans_RepetitionPlanId",
                        column: x => x.RepetitionPlanId,
                        principalTable: "RepetitionPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_LearnTypeId",
                table: "Issues",
                column: "LearnTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_SurahId",
                table: "Issues",
                column: "SurahId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_UserId",
                table: "Issues",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_RepetitionPlanId",
                table: "Notifications",
                column: "RepetitionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RepetitionPlans_IssueId",
                table: "RepetitionPlans",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_RepetitionPlans_UserId",
                table: "RepetitionPlans",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "RepetitionPlans");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "LearnTypes");

            migrationBuilder.DropTable(
                name: "Surahs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
