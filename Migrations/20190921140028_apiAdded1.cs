using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_Healthcheck.Migrations
{
    public partial class apiAdded1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Method",
                table: "Apies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Method",
                table: "Apies");
        }
    }
}
