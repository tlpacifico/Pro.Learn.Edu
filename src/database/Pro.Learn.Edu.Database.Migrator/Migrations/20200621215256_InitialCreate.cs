using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Pro.Learn.Edu.Database.Migrator.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Exam");

            migrationBuilder.CreateTable(
                name: "Answer",
                schema: "Exam",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExternalId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.UniqueConstraint("AK_Answer_ExternalId", x => x.ExternalId);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                schema: "Exam",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExternalId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    ExamOccurredOn = table.Column<DateTimeOffset>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
                    table.UniqueConstraint("AK_Exam_ExternalId", x => x.ExternalId);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                schema: "Exam",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExternalId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CorrectAnswerId = table.Column<long>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 64, nullable: false),
                    ExamEntityId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.UniqueConstraint("AK_Question_ExternalId", x => x.ExternalId);
                    table.ForeignKey(
                        name: "FK_Question_Answer_CorrectAnswerId",
                        column: x => x.CorrectAnswerId,
                        principalSchema: "Exam",
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Question_Exam_ExamEntityId",
                        column: x => x.ExamEntityId,
                        principalSchema: "Exam",
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnwser",
                schema: "Exam",
                columns: table => new
                {
                    QuestionId = table.Column<long>(nullable: false),
                    AnswerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnwser", x => new { x.QuestionId, x.AnswerId });
                    table.ForeignKey(
                        name: "FK_QuestionAnwser_Answer_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Exam",
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnwser_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Exam",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_CorrectAnswerId",
                schema: "Exam",
                table: "Question",
                column: "CorrectAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ExamEntityId",
                schema: "Exam",
                table: "Question",
                column: "ExamEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionAnwser",
                schema: "Exam");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "Exam");

            migrationBuilder.DropTable(
                name: "Answer",
                schema: "Exam");

            migrationBuilder.DropTable(
                name: "Exam",
                schema: "Exam");
        }
    }
}
