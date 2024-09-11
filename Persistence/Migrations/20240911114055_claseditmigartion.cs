using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class claseditmigartion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersClasses_AspNetUsers_CorrectStudentId",
                table: "UsersClasses");

            migrationBuilder.DropIndex(
                name: "IX_UsersClasses_CorrectStudentId",
                table: "UsersClasses");

            migrationBuilder.DropColumn(
                name: "CorrectStudentId",
                table: "UsersClasses");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddingDate",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CorrectInstructorId",
                table: "Classes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Classes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "InstructorId",
                table: "Classes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ClassCorrectStudent",
                columns: table => new
                {
                    ClassesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassCorrectStudent", x => new { x.ClassesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ClassCorrectStudent_AspNetUsers_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassCorrectStudent_Classes_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CorrectInstructorId",
                table: "Classes",
                column: "CorrectInstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CourseId",
                table: "Classes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_InstructorId",
                table: "Classes",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassCorrectStudent_StudentsId",
                table: "ClassCorrectStudent",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AspNetUsers_CorrectInstructorId",
                table: "Classes",
                column: "CorrectInstructorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AspNetUsers_InstructorId",
                table: "Classes",
                column: "InstructorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Courses_CourseId",
                table: "Classes",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AspNetUsers_CorrectInstructorId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AspNetUsers_InstructorId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Courses_CourseId",
                table: "Classes");

            migrationBuilder.DropTable(
                name: "ClassCorrectStudent");

            migrationBuilder.DropIndex(
                name: "IX_Classes_CorrectInstructorId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_CourseId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_InstructorId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "AddingDate",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CorrectInstructorId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Classes");

            migrationBuilder.AddColumn<string>(
                name: "CorrectStudentId",
                table: "UsersClasses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersClasses_CorrectStudentId",
                table: "UsersClasses",
                column: "CorrectStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersClasses_AspNetUsers_CorrectStudentId",
                table: "UsersClasses",
                column: "CorrectStudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
