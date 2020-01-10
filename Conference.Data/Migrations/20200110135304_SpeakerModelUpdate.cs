using Microsoft.EntityFrameworkCore.Migrations;

namespace Confapi.Migrations
{
    public partial class SpeakerModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Speakers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Speakers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Speakers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterHandle",
                table: "Speakers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "TwitterHandle",
                table: "Speakers");
        }
    }
}
