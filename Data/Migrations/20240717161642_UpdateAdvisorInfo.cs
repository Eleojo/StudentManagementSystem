using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdvisorInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdvisorName",
                table: "AdvisorInfos",
                newName: "AdvisorLastName");

            migrationBuilder.AddColumn<string>(
                name: "AdvisorFirstName",
                table: "AdvisorInfos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdvisorFirstName",
                table: "AdvisorInfos");

            migrationBuilder.RenameColumn(
                name: "AdvisorLastName",
                table: "AdvisorInfos",
                newName: "AdvisorName");
        }
    }
}
