using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EmailMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CorrectInstructorId",
                table: "UsersClasses",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CorrectStudentId",
                table: "UsersClasses",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersClasses_CorrectInstructorId",
                table: "UsersClasses",
                column: "CorrectInstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersClasses_CorrectStudentId",
                table: "UsersClasses",
                column: "CorrectStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersClasses_AspNetUsers_CorrectInstructorId",
                table: "UsersClasses",
                column: "CorrectInstructorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersClasses_AspNetUsers_CorrectStudentId",
                table: "UsersClasses",
                column: "CorrectStudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersClasses_AspNetUsers_CorrectInstructorId",
                table: "UsersClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersClasses_AspNetUsers_CorrectStudentId",
                table: "UsersClasses");

            migrationBuilder.DropIndex(
                name: "IX_UsersClasses_CorrectInstructorId",
                table: "UsersClasses");

            migrationBuilder.DropIndex(
                name: "IX_UsersClasses_CorrectStudentId",
                table: "UsersClasses");

            migrationBuilder.DropColumn(
                name: "CorrectInstructorId",
                table: "UsersClasses");

            migrationBuilder.DropColumn(
                name: "CorrectStudentId",
                table: "UsersClasses");
        }
    }
}
