using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchemaLinkForeignKeys5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AcademicInfos_StudentId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AdvisorInfos_StudentId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_ContactInfos_StudentId",
                table: "Students");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AcademicInfoId",
                table: "Students",
                column: "AcademicInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_AdvisorInfoId",
                table: "Students",
                column: "AdvisorInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ContactInfoId",
                table: "Students",
                column: "ContactInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AcademicInfos_AcademicInfoId",
                table: "Students",
                column: "AcademicInfoId",
                principalTable: "AcademicInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AdvisorInfos_AdvisorInfoId",
                table: "Students",
                column: "AdvisorInfoId",
                principalTable: "AdvisorInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ContactInfos_ContactInfoId",
                table: "Students",
                column: "ContactInfoId",
                principalTable: "ContactInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AcademicInfos_AcademicInfoId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AdvisorInfos_AdvisorInfoId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_ContactInfos_ContactInfoId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AcademicInfoId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AdvisorInfoId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ContactInfoId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AcademicInfos_StudentId",
                table: "Students",
                column: "StudentId",
                principalTable: "AcademicInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AdvisorInfos_StudentId",
                table: "Students",
                column: "StudentId",
                principalTable: "AdvisorInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_ContactInfos_StudentId",
                table: "Students",
                column: "StudentId",
                principalTable: "ContactInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
